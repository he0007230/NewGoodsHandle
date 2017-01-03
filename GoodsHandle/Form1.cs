using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using NLSCAN.MacCtrl;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using ArmAssistBll;
using System.Threading;
using SYNCC;
using OpenNETCF.Net.NetworkInformation;

namespace GoodsHandle
{
    
    public partial class Form1 : Form
    {
        private string _stockNo;
        private string _workerNo;
        private TextBox _nowControlModule;    //当前获取焦点的控件
        private TextBox _nextControlModule;   //下一个焦点控件
        private int _nowRunningState;        //当前运行状态
        private string _codeStr;
        private int _pFlag;
        private string _outStr;
        //private NLSScanner scanCode = new NLSScanner();
        TcpClient m_socketClient;
        private int _ConnectTimeOut;
        private string _stockName;
        private string _workerName;
        private string _applicationName;
        private string _serverIP;
        private int _serverPort;
        private int _oldTime;
        private string _IpAddress;
        // 2M 的接收缓冲区，目的是一次接收完服务器发回的消息
        byte[] m_receiveBuffer = new byte[2048 * 1024];

        private string _goodsNo;
        private string _monitorDate;
        private string _offShelvesDate;
        private string _procedureDate;
        private string _shelvesNo;
        private bool _cFlag;
        private int _off_shelves_offset;
        private DateTime _nowDate;
        private SYSTEM_POWER_STATUS_EX status;
        private DateTime _offShelvesDay;
        private string _goodsFlag;
        private string _sellDate;
        private string _remark;
        private string _oldType;
        private bool _connFlag;

        [DllImport("coredll.Dll")]
        public static extern int SetWindowPos(IntPtr hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("coredll.Dll")]
        public static extern void SetForegroundWindow(IntPtr hwnd);

        [DllImport("coredll.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        public const int SW_SHOW = 5; public const int SW_HIDE = 0;
        [DllImport("Coredll.dll", EntryPoint = "GetTickCount")]
        private static extern int GetTickCount();

        private class SYSTEM_POWER_STATUS_EX
        {
            public byte ACLineStatus = 0;
            public byte BatteryFlag = 0;
            public byte BatteryLifePercent = 0;
            public byte Reserved1 = 0;
            public uint BatteryLifeTime = 0;
            public uint BatteryFullLifeTime = 0;
            public byte Reserved2 = 0;
            public byte BackupBatteryFlag = 0;
            public byte BackupBatteryLifePercent = 0;
            public byte Reserved3 = 0;
            public uint BackupBatteryLifeTime = 0;
            public uint BackupBatteryFullLifeTime = 0;
        }
        [DllImport("coredll")]
        private static extern int GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus, bool fUpdate);

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 获取运行的毫秒数
        /// </summary>
        /// <returns></returns>
        private int GetTick()
        {
            return GetTickCount();
        }

        /// <summary>
        /// 获取电量
        /// </summary>
        /// <returns></returns>
        private int GetPower()
        {
            if (GetSystemPowerStatusEx(status, false) == 1)
            {
                if (status.BatteryLifePercent > 100)
                    status.BatteryLifePercent = 100;
                return status.BatteryLifePercent;
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// 提示出错
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title);
            /*
            try
            {
                //_nextControlModule = _nowControlModule;
                // _nowControlModule = null;
                //MessageBox.Show("test","error");
                MessageBox.Show(msg, title);
                //_nowControlModule = _nextControlModule;
            }
            catch (Exception e)
            {
                MessageBox.Show("警告出错:" + e.Message, "错误");
            }
             * */
        }

        /// <summary>
        /// 校验条码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool CheckBarCode(string code)
        {
            int mOdd = 0;
            int mEven = 0;
            int mNumber = 0;
            for (int i = 1; i < code.Length; i++)
            {
                mNumber = int.Parse(code[i - 1].ToString());
                if (i % 2 == 0)
                {
                    mEven += mNumber;
                }
                else
                {
                    mOdd += mNumber;
                }
            }
            mEven *= 3;
            mNumber = mOdd + mEven;
            mNumber = (10 - (mNumber % 10)) % 10;
            if (mNumber.ToString() == code[code.Length - 1].ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 刷新电量
        /// </summary>
        private void ShowPower()
        {
           // statusBar1.Text = "电量:" + NLSSysInfo.GetPowerPercent().ToString() + "%";
            //statusBar1.Text = GetTick().ToString();
            //statusBar2.Text = "用户:" + _workerName + "    |电量:" + GetPower();
            statusBar2.Text = _serverIP.Substring(_serverIP.Length - 3, 3) + "用户:" + _workerName + "   | 电量:" + GetPower();
        }


        /// <summary>
        /// 新的通信方式
        /// </summary>
        private void NewTransmit()
        {
            string msg;
            if (!WifiCtrl.GetInstance().isConnectWifi(_IpAddress, out msg))
            {
                //MessageBox.Show(msg + ",请换个地方重新开机!");
                _outStr = msg;
                return;
            }
            CompactFormatter.TransDTO transDTO = new CompactFormatter.TransDTO();
            transDTO.AppName = _applicationName;
            transDTO.CodeStr = _codeStr;
            transDTO.IP = _IpAddress;
            transDTO.pFlag = _pFlag;
            transDTO.StockNo = _stockNo;
            transDTO.Remark = msg;
            NetWorkScript.Instance.write(1, 1, 1, transDTO);
            NetWorkScript.Instance.AsyncReceive();
            if (NetWorkScript.Instance.messageList.Count > 0)
            {
                SocketModel socketModel = NetWorkScript.Instance.messageList[0];
                NetWorkScript.Instance.messageList.RemoveAt(0);
                _outStr = socketModel.message.ToString();
                _connFlag = true;
            }
            else
            {
                NetWorkScript.Instance.release();
                if (_connFlag)
                {
                    _connFlag = false;
                    Thread.Sleep(2000);
                    NewTransmit();
                }
                else
                {
                    _outStr = "没有返回信息!";
                }
            }
        }


        /// <summary>
        /// 程序初始化
        /// </summary>
        private void Init()
        {
            //SetWindowPos(this.Handle, -1, 0, 0, 0, 0, 1 | 2);
            //ShowWindow(this.Handle,SW_SHOW);
           // SetForegroundWindow(this.Handle);
            status = new SYSTEM_POWER_STATUS_EX();
            _connFlag = true;
            _oldTime = 0;
            _workerNo = "";
            _stockNo = "";
            _outStr = "";
            _codeStr = "";
            _stockName = "";
            _workerName = "";
            _goodsNo = "";
            _monitorDate = "";
            _offShelvesDate = "";
            _off_shelves_offset = 0;
            _applicationName = "GoodsHandle";
            _cFlag = true;
            _pFlag = 1;
            _goodsFlag = "01";
            _remark = "";
            _sellDate = "00000000";
            _oldType = "01";
            _nowRunningState = 99;
            _nowControlModule = tb_worker_no;
            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(login);
            tb_worker_no.Focus();
            //tabControl1.Focus();
            XmlDocument xml = new XmlDocument();
            xml.Load("\\Program Files\\CONFIG.XML");
            try
            {
                ProcessInfo[] list = ProcessCE.GetProcesses();
                foreach (ProcessInfo item in list)
                {
                    if (item.FullPath.IndexOf("AutoUpdate") > 0)
                    {
                        item.Kill();
                    }
                }
                _serverIP = xml.SelectSingleNode("/Root/System/server_ip").InnerText;
                _serverPort = int.Parse(xml.SelectSingleNode("/Root/System/server_port").InnerText);
                _stockName = xml.SelectSingleNode("/Root/System/stock_name").InnerText;
                _stockNo = xml.SelectSingleNode("/Root/System/stock_no").InnerText;
                _ConnectTimeOut = int.Parse(xml.SelectSingleNode("/Root/System/maxSessionTimeout").InnerText) * 1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            ShowPower();
            try
            {
                _IpAddress = WifiCtrl.GetInstance().GetWifiStatus().CurrentIpAddress.ToString();
                if (_IpAddress == "0.0.0.0")
                {
                    _IpAddress = IPHelper.GetIpAddress();
                }
            }
            catch
            {
                _IpAddress = IPHelper.GetIpAddress();
            }

        }

        /// <summary>
        /// 连接服务器
        /// </summary>
        private void Connect()
        {
           // lock (this)
            //{
                //try
                //{
                    //m_socketClient = new TcpClient(_serverIP, _serverPort);
                    //m_socketClient.ReceiveTimeout = 20 * 1000;

               // }
                //catch 
               // {
                //}
            //}
            //_oldTime = GetTick();
        }

        /// <summary>
        /// 与服务器断开连接
        /// </summary>
        private void Disconnect()
        {
           // lock (this)
            //{
               // if (m_socketClient == null)
                //{
               // //    return;
                //}

               // try
               // {
                 //   m_socketClient.Close();
                    //this.AddInfo("断开连接成功！");
               // }
               // catch(Exception err)
               // {
                    //this.AddInfo("断开连接时出错: " + err.Message);
                //     ShowMessage("断开连接时出错: " + err.Message,"错误");
              //  }
               // finally
              //  {
                 //   m_socketClient = null;
              //      _oldTime = 0;
              //  }
           // }
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="message"></param>
        private void AddInfo(string message)
        {
            ShowPower();
            //ShowMessage(msg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            tb_ResultShow.Text = "";
            if (message.Length == 0)
            {
                //ShowMessage("无返回信息！","错误");
                //tb_ResultShow.Text = "无返回信息！";
                return;
            }
            else
            {
                string[] msg = message.Split('^');
                foreach (string str in msg)
                {
                    tb_ResultShow.Text = tb_ResultShow.Text + str + "\r\n";
                }
            }
            //tb_ResultShow.Text += Test();
            p_msg.Visible = true;
            _nextControlModule = _nowControlModule;
            _nowControlModule = tb_Confirm;
            tb_Confirm.Focus();
            buz_on();
            /*
            if (message.IndexOf("成功") == -1)
            {
                tb_ResultShow.BackColor = Color.Red;
                //ShowMessage(textBox8.BackColor.ToString(),"color");
                buz_on();
            }
            else
            {
                tb_ResultShow.BackColor = Color.Green;
            }
            //_outStr="";
             * */
            
        }

        /// <summary>
        /// 发送信息
        /// </summary>
        private void SendOneDatagram()
        {
            if (GetTick()>(_oldTime+_ConnectTimeOut))
            {
                if (m_socketClient != null)
                {
                    this.Disconnect();
                }
                this.Connect();
            }

            string datagramText2 = "1#" + _pFlag + "#" + _codeStr + "#" + _applicationName+"#"+_stockNo;

            byte[] b = Encoding.UTF8.GetBytes(datagramText2);//按照指定编码将string编程字节数组
            string datagramText = string.Empty;
            for (int i = 0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                datagramText += "%" + Convert.ToString(b[i], 16);
            }

            //byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(datagramText);
            //datagramText = Convert.ToBase64String(encbuff);
            //if (ShowMessage(datagramText, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            //{
            //Application.Exit();
            //}
            //datagramText = textBox1.Text + "#" + textBox2.Text + "#" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text + "|";
            //datagramText += textBox6.Text + "|" + textBox8.Text + "|" + textBox7.Text + "|#";

            byte[] Cmd = Encoding.ASCII.GetBytes(datagramText);
            byte check = (byte)(Cmd[0] ^ Cmd[1]);
            for (int i = 2; i < Cmd.Length; i++)
            {
                check = (byte)(check ^ Cmd[i]);
            }
            datagramText = "<" + datagramText + (char)check + ">";
            byte[] datagram = Encoding.ASCII.GetBytes(datagramText);

            try
            {
                m_socketClient.Client.Send(datagram);
                //this.AddInfo("send text = " + datagramText);

                //if (ck_AsyncReceive.Checked)  // 异步接收回答
                // {
                //m_socketClient.Client.BeginReceive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None, this.EndReceiveDatagram, this);
                //}
                // else
                // {
                //}
            }
            catch (Exception err)
            {
                /*
                if (_cFlag)
                {
                    _cFlag = false;
                    if (m_socketClient != null)
                    {
                        this.Disconnect();
                    }
                    this.Connect();
                    try
                    {
                        m_socketClient.Client.Send(datagram);
                        this.Receive();
                    }
                    catch { }

                }
                else
                {
                 * */
                    //this.AddInfo("发送错误: " + err.Message);
                    ShowMessage("连接服务器失败: " + err.Message, "错误");
                    //this.AddInfo("连接服务器失败:!\r\n" + err.Message);
                    _outStr = "";
                    this.CloseClientSocket();
                    _oldTime = 0;
               // }

            }
            this.Receive();
        }

        private void Receive()
        {
            try
            {
                int len = m_socketClient.Client.Receive(m_receiveBuffer, 0, m_receiveBuffer.Length, SocketFlags.None);
                if (len > 0)
                {
                    CheckReplyDatagram(len);
                }
                _oldTime = GetTick();
            }
            catch (Exception err)
            {
                //this.AddInfo("接收错误: " + err.Message);
                ShowMessage("接收错误: " + err.Message, "错误");
                this.CloseClientSocket();
                _oldTime = 0;
            }
        }

        private void CheckReplyDatagram(int len)
        {
            string datagramText = Encoding.ASCII.GetString(m_receiveBuffer, 0, len);
            //byte[] decbuff = Convert.FromBase64String(replyMesage);
            if (datagramText[0] != '%')
            {
                _outStr = "返回的信息错误！";
                return;
            }
            string[] chars = datagramText.Substring(1, datagramText.Length - 1).Split('%');
            byte[] b = new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i = 0; i < chars.Length; i++)
            {
                b[i] = Convert.ToByte(chars[i], 16);
            }
            //按照指定编码将字节数组变为字符串
            //string content = Encoding.UTF8.GetString(b);
            _outStr = Encoding.UTF8.GetString(b, 0, b.Length);
            //this.AddInfo(replyMesage);
        }

        /// <summary>
        /// 关闭客户端连接
        /// </summary>
        private void CloseClientSocket()
        {
            try
            {
                //m_socketClient.Client.Shutdown(SocketShutdown.Both);
                m_socketClient.Client.Close();
                m_socketClient.Close();
            }
            catch
            {
            }
            finally
            {
                m_socketClient = null;
            }
        }

        /// <summary>
        /// 启动蜂鸣器
        /// </summary>
        private void buz_on()
        {
            /*
            int m_iFreq = 2730;
            int m_iVolume = 60;
            int m_iMdelay = 300;
            int m_iBuzCtrlRe = -1;
            m_iBuzCtrlRe = NLSSysCtrl.buz_ctrl(m_iFreq, m_iVolume, m_iMdelay);
            NLSSysCtrl.vibrator_ctrl(m_iMdelay);
             * */
            //Sound sound = new Sound("Program Files//GoodsHandle//buz.wav");
            //sound.Play();

        }

        /// <summary>
        /// 退出程序
        /// </summary>
        public void Quit()
        {
            if (MessageBox.Show("是否退出?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                _nowControlModule = null;
                _nextControlModule = null;
                this.Disconnect();
                ProcessContext pi = new ProcessContext();
                ProcessCE.CreateProcess("\\Program Files\\AutoUpdate\\AutoUpdate.exe",
                                  "", IntPtr.Zero,
                                  IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, pi);
                Thread.Sleep(2500);
                Application.Exit();
            }
        }

        /// <summary>
        /// 焦点控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IsLostFocus(object sender, EventArgs e)
        {
            if (_nowControlModule != null)
            {
                _nowControlModule.Focus();
            }
            else
            {
                _nowControlModule = tb_ui;
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                _nowRunningState = 0;
                tb_ui.Focus();
            }
        }

        /// <summary>
        /// 操作结果确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_Confirm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1)
            {
                /*
                try
                {
                    _pFlag = 4;
                    string codestr = _codeStr.Replace("|", "_");
                    _codeStr = _serialNo + "|" + _applicationName + "|" + _stockNo + "|" + codestr + "|" + textBox8.Text + "|" + _workerNo + "|";
                    SendOneDatagram();
                }
                catch
                {
                    ShowMessage(_outStr, "错误");
                }
                finally
                {
                    tb_Confirm.Text = "";
                    tb_ResultShow.Text = "";
                    _nowControlModule = _nextControlModule;
                    p_msg.Visible = false;
                    _nowControlModule.Text = "";
                    _nowControlModule.Focus();
                    _codeStr = "";
                    _outStr = "";
                    tb_ResultShow.BackColor = Color.Yellow;
                }
                 * */
                if(_nowRunningState==11)
                {
                    _nowRunningState = 1;
                    _nextControlModule = tb_oldDate;
                    p_oldDateInput.Visible = true;
                }
                else if (_nowRunningState == 12)
                {
                    _nowRunningState = 1;
                    string exa_flag = "01";
                    string old_type = "01";
                    DateTime dt0 = DateTime.ParseExact(_procedureDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    DateTime dt1 = DateTime.ParseExact(_offShelvesDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                    int timeCount = ((TimeSpan)(dt0 - dt1)).Days;
                    if (timeCount >= 5)
                    {
                        old_type = "03";
                    }
                    else if (timeCount > 0 && timeCount < 5)
                    {
                        old_type = "02";
                    }
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (old_type != "01")
                    {
                        _codeStr = _goodsNo + "|" + _sellDate + "|1|00000000|" + _workerNo + "|" + _stockName + "|";
                        _codeStr += _stockNo + "|" + old_type + "|" + _offShelvesDate + "|" + exa_flag + "|" + _goodsFlag + "|" + _remark + "|";
                        _pFlag = 8;
                        //SendOneDatagram();
                        NewTransmit();
                        //_nowControlModule = tb_oldDate;
                        if (_outStr != "SUCCESS")
                        {
                            ShowMessage(_outStr, "错误");
                        }
                    }
                }
                tb_Confirm.Text = "";
                tb_ResultShow.Text = "";
                _nowControlModule = _nextControlModule;
                p_msg.Visible = false;
                _nowControlModule.Text = "";
                _nowControlModule.Focus();
                _codeStr = "";
                _outStr = "";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (_nowRunningState == 11)
                {
                    p_oldDateInput.Visible = false;
                    _nowRunningState = 1;
                    tb_Confirm.Text = "";
                    tb_ResultShow.Text = "";
                    _nowControlModule = _nextControlModule;
                    p_msg.Visible = false;
                    _nowControlModule.Text = "";
                    _nowControlModule.Focus();
                    _codeStr = "";
                    _outStr = "";
                    
                }
            }
            else if (e.KeyCode == Keys.D2)
            {
                if (_nowRunningState == 11)
                {
                    lbl_udp_goods_no.Text = _goodsNo;
                    p_oldDateInput.Visible = false;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(update);
                    _nowRunningState = 12;
                    tb_Confirm.Text = "";
                    tb_ResultShow.Text = "";
                    _nowControlModule = tb_save_day;
                    p_msg.Visible = false;
                    _nowControlModule.Text = "";
                    _nowControlModule.Focus();
                    _codeStr = "";
                    _outStr = "";

                }
            }
        }

        /// <summary>
        /// 检查生产日期界面之按键捕获处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_checkDate_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //返回主界面
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                    tb_ui.Focus();
                    break;
                case Keys.Enter:
                    //检查输入
                    //if (tb_checkDate.Text.Length == 13)
                    if (true)
                    {
                        try
                        {
                            long.Parse(tb_checkDate.Text);
                        }
                        catch
                        {
                            tb_checkDate.Text = "";
                            return;
                        }
                        _codeStr = tb_checkDate.Text + "|" + _workerNo + "|" + _stockName + "|" + _stockNo + "|" + _shelvesNo + "|";
                        _pFlag = 7;
                        //SendOneDatagram();
                        NewTransmit();
                        //MessageBox.Show(_outStr,"outstr");
                        string[] data = _outStr.Split('#');
                        if (data.Length < 8)
                        {
                            AddInfo(_outStr);
                        }
                        else if (data[10] == "01")
                        {
                            int monitor_offset = 0;
                            int off_shelves_offset = 0;
                            int procedure_date_offset = 0;
                            string date_type = data[9];
                            _goodsFlag = "01";
                            _remark = "";


                            if (data[3] == "01")    //生产日期
                            {
                                try
                                {

                                    monitor_offset = int.Parse(data[2]);
                                    off_shelves_offset = int.Parse(data[2]);
                                    procedure_date_offset = int.Parse(data[2]);
                                }
                                catch
                                {
                                    AddInfo("返回的日期数据出错！");
                                    return;
                                }
                            }

                            /*
                            else if(data[3]=="02")
                            {
                                date_type="无保质期";
                            }
                            else if(data[3]=="03")
                            {
                                date_type="有效期";
                            }
                            */
                            try
                            {
                                monitor_offset -= int.Parse(data[4]);
                                off_shelves_offset -= int.Parse(data[5]);
                            }
                            catch
                            {
                                AddInfo("返回的日期数据出错！");
                                return;
                            }


                            DateTime dt0 = DateTime.ParseExact(data[6], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            _nowDate = dt0;
                            _off_shelves_offset = off_shelves_offset;
                            //TimeSpan ts1 = new TimeSpan(monitor_offset, 0, 0, 0);
                            //DateTime dt1 = dt0.Subtract(ts1);
                            //TimeSpan ts2 = new TimeSpan(off_shelves_offset, 0, 0, 0);
                            //DateTime dt2 = dt0.Subtract(ts2);
                            TimeSpan ts3 = new TimeSpan(procedure_date_offset, 0, 0, 0);
                            DateTime dt3 = dt0.Subtract(ts3);
                            //_monitorDate = string.Format("{0:yyyyMMdd}", dt1);
                            //_offShelvesDate = string.Format("{0:yyyyMMdd}", dt2);
                            _monitorDate = data[7];
                            _offShelvesDate = data[8];
                            _procedureDate = string.Format("{0:yyyyMMdd}", dt3);
                            lbl_monitor_date.Text = _monitorDate;
                            byte[] bytes = Encoding.Default.GetBytes(data[1]);
                            if (bytes.Length > 36)
                            {
                                data[1] = data[1].Substring(0, 18) + "...";
                            }
                            string message = "商品编号：" + data[0] + "^商品名：" + data[1] + "^保质期:        " + data[2];
                            message += "天^日期类型: " + date_type + "^检查标准^            " + _monitorDate;
                            //message += "^" + string.Format("{0:yyyyMMdd}", dt1) + "|" + string.Format("{0:yyyyMMdd}", dt2);
                            _goodsNo = data[0];
                            _nowRunningState = 11;
                            AddInfo(message);
                        }

                        else if (data[10] == "02")
                        {
                            byte[] bytes = Encoding.Default.GetBytes(data[1]);
                            if (bytes.Length > 36)
                            {
                                data[1] = data[1].Substring(0, 18) + "...";
                            }
                            _goodsFlag = "02";
                            _remark = tb_checkDate.Text.Substring(0,12);
                            string message = "商品编号：" + data[0] + "^商品名：" + data[1];
                            _procedureDate = data[6];
                            _monitorDate = data[7];
                            _offShelvesDate = data[8];
                            _sellDate = data[11];
                            if (_offShelvesDate.Length == 8)
                            {
                                message += "^^下架期:" + _offShelvesDate.Substring(0, 4) + "-" + _offShelvesDate.Substring(4, 2) + "-" + _offShelvesDate.Substring(6, 2);
                            }
                            if (int.Parse(_offShelvesDate) <= int.Parse(_procedureDate))
                            {
                                message += "^^商品已下架!";
                            }
                            /*
                            DateTime dt0 = DateTime.ParseExact(_procedureDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            DateTime dt1 = DateTime.ParseExact(_offShelvesDate, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            int timeCount = Math.Abs(((TimeSpan)(dt0 - dt1)).Days);
                            if (timeCount >= 5)
                            {
                                _oldType = "03";
                                message += "^^商品已过期!";
                            }
                            else if (timeCount >= 0 && timeCount < 5)
                            {
                                _oldType = "02";
                                message += "^^商品已下架!";
                            }
                             * */
                            _goodsNo = data[0];
                            _nowRunningState = 12;
                            AddInfo(message);
                        }
                    }
                    tb_checkDate.Text = "";
                    break;
            }
        }

        /// <summary>
        /// 主界面跳转
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_ui_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    _nowRunningState = 1;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(checkDate);
                    _nowControlModule = tb_checkDate;
                    tb_checkDate.Focus();
                    break;
                case Keys.D2:
                    _nowRunningState = 2;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(offshelves);
                    _nowControlModule = tb_func3_forcus;
                    tb_func3_forcus.Focus();
                    break;
                case Keys.D3:
                    _nowRunningState = 99;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(login);
                    _nowControlModule = tb_worker_no;
                    tb_worker_no.Focus();
                    break;
            }
        }

        private void tb_worker_no_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_worker_no.Text.Length > 0)
                    {
                        _nowControlModule = tb_password;
                        tb_password.Focus();
                    }
                    break;
                case Keys.Escape:
                    if (tb_worker_no.Text == "")
                    {
                        Quit();
                    }
                    else
                    {
                        tb_worker_no.Text = "";
                    }
                    break;
            }
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_password_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_password.Text.Length > 0)
                    {
                        _nowControlModule = tb_goods_shelves;
                        tb_goods_shelves.Focus();
                    }
                    break;
                case Keys.Escape:
                    if (tb_password.Text == "")
                    {
                        _nowControlModule = tb_worker_no;
                        tb_worker_no.Focus();
                    }
                    else
                    {
                        tb_password.Text = "";
                    }
                    break;
            }
        }

        private void tb_oldDate_KeyUp(object sender, KeyEventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //DateTime offShelvesDay;
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_oldDate.Text.Length == 8)
                    {
                        try
                        {
                            int.Parse(tb_oldDate.Text);
                            DateTime dt = DateTime.ParseExact(tb_oldDate.Text, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            TimeSpan ts = new TimeSpan(-(_off_shelves_offset), 0, 0, 0);
                            _offShelvesDay = dt.Subtract(ts);
                            if (int.Parse(string.Format("{0:yyyyMMdd}", dt)) < 20000101)
                            {
                                tb_oldDate.Text = "";
                                return;
                            }
                        }
                        catch 
                        {
                            tb_oldDate.Text = "";
                            return;
                        }
                        if (_stockNo == "01")
                        {
                            _nowControlModule = tb_oldDateNum;
                            _nowControlModule.Focus();
                            _nowControlModule.SelectAll();
                        }
                        else
                        {
                            tb_oldDateNum.Text = "1";
                            UpOldDate();
                        }

                        break;
                    }
                    break;
                case Keys.Escape:
                    if (tb_oldDate.Text.Length > 0)
                    {
                        tb_oldDate.Text = "";
                    }
                    else
                    {
                        _nowControlModule = tb_checkDate;
                        p_oldDateInput.Visible = false;
                        tb_checkDate.Focus();
                    }
                    break;
            }
        }

        private void UpOldDate()
        {
            string exa_flag = "03";
            
            try
            {
                string old_type = string.Empty;
                string msg = "商品编号:" + _goodsNo + "^^商品日期：" + tb_oldDate.Text;
                if (int.Parse(_monitorDate) < int.Parse(tb_oldDate.Text))
                {
                    tb_oldDate.Text = "";
                    //tb_goodsNum.Text = "";
                    _nowControlModule = tb_oldDate;
                    msg += "^^^日期不在监控范围!";
                    AddInfo(msg);
                    return;
                }
                else
                {
                    if (int.Parse(_procedureDate) >= int.Parse(tb_oldDate.Text))
                    {
                        exa_flag = "01";
                        msg += "^^            过期商品";
                        old_type = "03";
                    }
                    else if (int.Parse(_offShelvesDate) >= int.Parse(tb_oldDate.Text))
                    {
                        exa_flag = "01";
                        msg += "^^            下架商品";
                        old_type = "02";
                    }
                    else
                    {
                        int timeCount = Math.Abs(((TimeSpan)(_offShelvesDay - _nowDate)).Days);
                        if (timeCount <= 30)
                        {
                            exa_flag = "01";
                        }
                        else
                        {
                            exa_flag = "03";
                        }
                        msg += "^^下架日期：" + string.Format("{0:yyyyMMdd}", _offShelvesDay) + "^^            监控商品";
                        old_type = "01";
                    }
                }
                //string ac_date = string.Format("{0:yyyyMMdd}", DateTime.Now);
                _codeStr = _goodsNo + "|" + tb_oldDate.Text + "|" + tb_oldDateNum.Text + "|00000000|" + _workerNo + "|" + _stockName + "|";
                _codeStr += _stockNo + "|" + old_type + "|" + string.Format("{0:yyyyMMdd}", _offShelvesDay) + "|" + exa_flag + "|";
                _codeStr += _goodsFlag + "|" + _remark + "|";
                _pFlag = 8;
                //SendOneDatagram();
                NewTransmit();
                _nowControlModule = tb_oldDate;
                //p_oldDateInput.Visible = false;
                tb_oldDate.Text = "";
                if (_outStr == "SUCCESS")
                {
                    AddInfo(msg);
                }
                else
                {
                    AddInfo(_outStr);
                }
            }
            catch
            {
                _nowControlModule = tb_oldDate;
                tb_oldDate.Text = "";
                tb_oldDate.Focus();
            }
        }


        private void tb_goods_shelves_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (tb_goods_shelves.Text.Length > 0)
                    {
                        _pFlag = 9;
                        _codeStr = tb_worker_no.Text + "|" + tb_password.Text + "|" + _stockNo + "|" ;
                        //SendOneDatagram();
                        NewTransmit();
                        //ShowMessage(_outStr, "返回信息");
                        string[] data = _outStr.Split('#');
                        if (data[0] == "SUCCESS")
                        {
                            _workerNo = tb_worker_no.Text;
                            _workerName = data[1];
                            _shelvesNo = tb_goods_shelves.Text;
                            _nowControlModule = tb_ui;
                            ShowPower();
                            //buz_on();
                            tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                            _nowRunningState = 0;
                            tb_ui.Focus();
                            _outStr = "";
                            _codeStr = "";
                            //this.AddInfo("登录成功");
                            //textBox9.Focus();
                            tb_worker_no.Text = "";
                            tb_goods_shelves.Text = "";
                            tb_password.Text = "";
                        }
                        else
                        {
                            _nowControlModule = tb_goods_shelves;
                            _nowControlModule.Focus();
                            this.AddInfo(_outStr);
                            tb_goods_shelves.Text = "";
                        }

                    }
                    break;
                case Keys.Escape:
                    if (tb_goods_shelves.Text.Length > 0)
                    {
                        tb_goods_shelves.Text = "";
                    }
                    else
                    {
                        _nowControlModule = tb_password;
                        tb_password.Focus();
                    }
                    break;
            }
        }

        private void tb_date_type_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                _nowControlModule = tb_checkDate;
                _nowRunningState = 1;
                p_dateType.Visible = false;
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(checkDate);
                tb_checkDate.Focus();
                return;
            }
            string produce_flag = "00";
            tb_date_type.Text = "";
            switch (e.KeyCode)
            {
                case Keys.D1:
                    produce_flag = "01";
                    break;
                case Keys.D2:
                    produce_flag = "02";
                    break;
                case Keys.D3:
                    produce_flag = "03";
                    break;
            }
            if (produce_flag != "00")
            {
                _nowControlModule = tb_checkDate;
                _nowRunningState = 1;
                p_dateType.Visible = false;
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(checkDate);
                tb_checkDate.Focus();
                _codeStr = _goodsNo + "|" + _stockName + "|" + _stockNo + "|" + produce_flag + "|" + tb_save_day.Text + "|";
                _pFlag = 10;
                //SendOneDatagram();
                NewTransmit();
                tb_save_day.Text = ""; 
                //p_oldDateInput.Visible = false;
                if(_outStr!="SUCCESS")
                {
                    AddInfo(_outStr);
                }
            }
        }

        private void tb_save_day_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int.Parse(tb_save_day.Text);
                }
                catch
                {
                    tb_save_day.Text = "";
                    return;
                }
                _nowControlModule = tb_date_type;
                p_dateType.Visible = true;
                tb_date_type.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tb_save_day.Text = "";
                _nowControlModule = tb_checkDate;
                tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(checkDate);
                tb_checkDate.Focus();
            }

        }

        private void tb_oldDateNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int.Parse(tb_oldDateNum.Text);
                }
                catch
                {
                    tb_oldDateNum.Text = "";
                    return;
                }
                UpOldDate();
                tb_oldDateNum.Text = "1";
            }
            else if (e.KeyCode == Keys.Escape)
            {
                tb_oldDate.Text = "";
                tb_oldDateNum.Text = "1";
                _nowControlModule = tb_oldDate;
                _nowControlModule.Focus();
                _nowControlModule.SelectAll();
            }
        }

        private void tb_func3_forcus_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    //返回主界面
                    tb_func3_forcus.Text = "";
                    _nowRunningState = 0;
                    _nowControlModule = tb_ui;
                    tabControl1.SelectedIndex = tabControl1.TabPages.IndexOf(main);
                    tb_ui.Focus();
                    break;
                case Keys.Enter:
                    //检查输入
                    //if (tb_checkDate.Text.Length == 13)
                    if (true)
                    {
                        try
                        {
                            long.Parse(tb_func3_forcus.Text);
                        }
                        catch
                        {
                            tb_func3_forcus.Text = "";
                            return;
                        }
                        _codeStr = tb_func3_forcus.Text + "|" + _workerNo + "|" + _stockName + "|" + _stockNo + "|" + _shelvesNo + "|";
                        _pFlag = 28;
                        //SendOneDatagram();
                        NewTransmit();
                        //MessageBox.Show(_outStr,"outstr");

                        string[] data = _outStr.Split('#');
                        if (data.Length < 8)
                        {
                            AddInfo(_outStr);
                        }
                        else
                        {
                            int monitor_offset = 0;
                            int off_shelves_offset = 0;
                            int procedure_date_offset = 0;
                            string date_type = data[9];



                            if (data[3] == "01")    //生产日期
                            {
                                try
                                {

                                    monitor_offset = int.Parse(data[2]);
                                    off_shelves_offset = int.Parse(data[2]);
                                    procedure_date_offset = int.Parse(data[2]);
                                }
                                catch
                                {
                                    AddInfo("返回的日期数据出错！");
                                    return;
                                }
                            }

                            /*
                            else if(data[3]=="02")
                            {
                                date_type="无保质期";
                            }
                            else if(data[3]=="03")
                            {
                                date_type="有效期";
                            }
                            */
                            try
                            {
                                monitor_offset -= int.Parse(data[4]);
                                off_shelves_offset -= int.Parse(data[5]);
                            }
                            catch
                            {
                                AddInfo("返回的日期数据出错！");
                                return;
                            }


                            DateTime dt0 = DateTime.ParseExact(data[6], "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
                            _nowDate = dt0;
                            _off_shelves_offset = off_shelves_offset;
                            //TimeSpan ts1 = new TimeSpan(monitor_offset, 0, 0, 0);
                            //DateTime dt1 = dt0.Subtract(ts1);
                            //TimeSpan ts2 = new TimeSpan(off_shelves_offset, 0, 0, 0);
                            //DateTime dt2 = dt0.Subtract(ts2);
                            TimeSpan ts3 = new TimeSpan(procedure_date_offset, 0, 0, 0);
                            DateTime dt3 = dt0.Subtract(ts3);
                            //_monitorDate = string.Format("{0:yyyyMMdd}", dt1);
                            //_offShelvesDate = string.Format("{0:yyyyMMdd}", dt2);
                            _monitorDate = data[7];
                            _offShelvesDate = data[8];
                            _procedureDate = string.Format("{0:yyyyMMdd}", dt3);
                            lbl_monitor_date.Text = _monitorDate;
                            byte[] bytes = Encoding.Default.GetBytes(data[1]);
                            if (bytes.Length > 36)
                            {
                                data[1] = data[1].Substring(0, 18) + "...";
                            }
                            string message = "商品编号：" + data[0] + "^商品名：" + data[1] + "^保质期:        " + data[2];
                            message += "天^日期类型: " + date_type + "^检查标准^            " + _offShelvesDate;
                            //message += "^" + string.Format("{0:yyyyMMdd}", dt1) + "|" + string.Format("{0:yyyyMMdd}", dt2);
                            _goodsNo = data[0];
                            _nowRunningState = 21;
                            AddInfo(message);
                        }

                    }
                    tb_func3_forcus.Text = "";
                    break;
            }
        }

        /// <summary>
        /// 旧日期处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*
        private void tb_goodsNum_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    try
                    {
                        string old_type = string.Empty;
                        int.Parse(tb_goodsNum.Text);
                        string msg = "商品编号:" + _goodsNo + "^^商品日期：" + tb_oldDate.Text;
                        if (int.Parse(_monitorDate) < int.Parse(tb_oldDate.Text))
                        {
                            tb_oldDate.Text = "";
                            tb_goodsNum.Text = "";
                            _nowControlModule = tb_oldDate;
                            msg += "^^^日期大于监控时间!";
                            AddInfo(msg);
                            return;
                        }
                        else
                        {
                            if (int.Parse(_procedureDate) >= int.Parse(tb_oldDate.Text))
                            {
                                msg += "^^超过生产日期：^              " + _procedureDate;
                                old_type = "03";
                            }
                            else if (int.Parse(_offShelvesDate) >= int.Parse(tb_oldDate.Text))
                            {
                                msg += "^^超过下架日期：^              " + _offShelvesDate;
                                old_type = "02";
                            }
                            else
                            {
                                msg += "^^超过监控日期：^              " + _monitorDate;
                                old_type = "01";
                            }
                            msg += "^^    商品数量：" + tb_goodsNum.Text;
                        }
                        string ac_date = string.Format("{0:yyyyMMdd}", DateTime.Now);
                        _codeStr = _goodsNo + "|" + tb_oldDate.Text + "|" + tb_goodsNum.Text + "|" + ac_date + "|" + _workerNo + "|" + _stockName + "|" + _stockNo+"|"+old_type+"|";
                        _pFlag = 8;
                        //SendOneDatagram();
                        NewTransmit();
                        _nowControlModule = tb_oldDate;
                        //p_oldDateInput.Visible = false;
                        tb_oldDate.Text = "";
                        tb_goodsNum.Text = "";
                        if (_outStr == "SUCCESS")
                        {
                            AddInfo(msg);
                        }
                        else
                        {
                            AddInfo(_outStr);
                        }
                    }
                    catch
                    {
                        _nowControlModule = tb_oldDate;
                        tb_oldDate.Text = "";
                        tb_goodsNum.Text = "";
                        tb_oldDate.Focus();
                    }
                    break;
                case Keys.Escape:
                    if (tb_goodsNum.Text.Length > 0)
                    {
                        tb_goodsNum.Text = "";
                    }
                    else
                    {
                        tb_oldDate.Text = "";
                        _nowControlModule = tb_oldDate;
                        tb_oldDate.Focus();
                    }
                    break;
            }
        }*/
    }
}