namespace GoodsHandle
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.login = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_goods_shelves = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_worker_no = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.main = new System.Windows.Forms.TabPage();
            this.label28 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ui = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkDate = new System.Windows.Forms.TabPage();
            this.p_oldDateInput = new System.Windows.Forms.Panel();
            this.tb_oldDateNum = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl_monitor_date = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_oldDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_checkDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.TabPage();
            this.p_dateType = new System.Windows.Forms.Panel();
            this.tb_date_type = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lbl_udp_goods_no = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_save_day = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.offshelves = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.tb_func3_forcus = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.p_msg = new System.Windows.Forms.Panel();
            this.tb_ResultShow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_Confirm = new System.Windows.Forms.TextBox();
            this.statusBar2 = new System.Windows.Forms.StatusBar();
            this.tabControl1.SuspendLayout();
            this.login.SuspendLayout();
            this.main.SuspendLayout();
            this.checkDate.SuspendLayout();
            this.p_oldDateInput.SuspendLayout();
            this.update.SuspendLayout();
            this.p_dateType.SuspendLayout();
            this.offshelves.SuspendLayout();
            this.p_msg.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.login);
            this.tabControl1.Controls.Add(this.main);
            this.tabControl1.Controls.Add(this.checkDate);
            this.tabControl1.Controls.Add(this.update);
            this.tabControl1.Controls.Add(this.offshelves);
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 4;
            this.tabControl1.Size = new System.Drawing.Size(232, 295);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.TabStop = false;
            // 
            // login
            // 
            this.login.Controls.Add(this.label11);
            this.login.Controls.Add(this.tb_goods_shelves);
            this.login.Controls.Add(this.label3);
            this.login.Controls.Add(this.label14);
            this.login.Controls.Add(this.tb_password);
            this.login.Controls.Add(this.tb_worker_no);
            this.login.Controls.Add(this.label13);
            this.login.Controls.Add(this.label12);
            this.login.Location = new System.Drawing.Point(4, 25);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(224, 266);
            this.login.Text = "login";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(6, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 28);
            this.label11.Text = "货架";
            // 
            // tb_goods_shelves
            // 
            this.tb_goods_shelves.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_goods_shelves.Location = new System.Drawing.Point(65, 194);
            this.tb_goods_shelves.MaxLength = 10;
            this.tb_goods_shelves.Name = "tb_goods_shelves";
            this.tb_goods_shelves.Size = new System.Drawing.Size(137, 32);
            this.tb_goods_shelves.TabIndex = 9;
            this.tb_goods_shelves.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_goods_shelves_KeyUp);
            this.tb_goods_shelves.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(25, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 32);
            this.label3.Text = "商品日期监控";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(6, 151);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 28);
            this.label14.Text = "密码";
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_password.Location = new System.Drawing.Point(65, 147);
            this.tb_password.MaxLength = 10;
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(137, 32);
            this.tb_password.TabIndex = 5;
            this.tb_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_password_KeyUp);
            this.tb_password.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // tb_worker_no
            // 
            this.tb_worker_no.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_worker_no.Location = new System.Drawing.Point(65, 100);
            this.tb_worker_no.MaxLength = 6;
            this.tb_worker_no.Name = "tb_worker_no";
            this.tb_worker_no.Size = new System.Drawing.Size(137, 32);
            this.tb_worker_no.TabIndex = 0;
            this.tb_worker_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_worker_no_KeyUp);
            this.tb_worker_no.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(3, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 28);
            this.label13.Text = "工号";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(45, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(131, 32);
            this.label12.Text = "登录界面";
            // 
            // main
            // 
            this.main.Controls.Add(this.label28);
            this.main.Controls.Add(this.label4);
            this.main.Controls.Add(this.tb_ui);
            this.main.Controls.Add(this.label1);
            this.main.Location = new System.Drawing.Point(4, 25);
            this.main.Name = "main";
            this.main.Size = new System.Drawing.Size(224, 266);
            this.main.Text = "main";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label28.Location = new System.Drawing.Point(18, 98);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(190, 40);
            this.label28.Text = "[2]抽查商品";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(18, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 38);
            this.label4.Text = "[3]退出登录";
            // 
            // tb_ui
            // 
            this.tb_ui.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ui.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_ui.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.tb_ui.Location = new System.Drawing.Point(-7, -2);
            this.tb_ui.Name = "tb_ui";
            this.tb_ui.ReadOnly = true;
            this.tb_ui.Size = new System.Drawing.Size(10, 39);
            this.tb_ui.TabIndex = 4;
            this.tb_ui.TabStop = false;
            this.tb_ui.WordWrap = false;
            this.tb_ui.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ui_KeyUp);
            this.tb_ui.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 40);
            this.label1.Text = "[1]日期检查";
            // 
            // checkDate
            // 
            this.checkDate.Controls.Add(this.p_oldDateInput);
            this.checkDate.Controls.Add(this.label8);
            this.checkDate.Controls.Add(this.tb_checkDate);
            this.checkDate.Controls.Add(this.label7);
            this.checkDate.Location = new System.Drawing.Point(4, 25);
            this.checkDate.Name = "checkDate";
            this.checkDate.Size = new System.Drawing.Size(224, 266);
            this.checkDate.Text = "checkDate";
            // 
            // p_oldDateInput
            // 
            this.p_oldDateInput.Controls.Add(this.tb_oldDateNum);
            this.p_oldDateInput.Controls.Add(this.label22);
            this.p_oldDateInput.Controls.Add(this.lbl_monitor_date);
            this.p_oldDateInput.Controls.Add(this.label10);
            this.p_oldDateInput.Controls.Add(this.label9);
            this.p_oldDateInput.Controls.Add(this.tb_oldDate);
            this.p_oldDateInput.Controls.Add(this.label2);
            this.p_oldDateInput.Location = new System.Drawing.Point(0, 2);
            this.p_oldDateInput.Name = "p_oldDateInput";
            this.p_oldDateInput.Size = new System.Drawing.Size(224, 261);
            this.p_oldDateInput.Visible = false;
            // 
            // tb_oldDateNum
            // 
            this.tb_oldDateNum.BackColor = System.Drawing.SystemColors.Control;
            this.tb_oldDateNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_oldDateNum.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tb_oldDateNum.Location = new System.Drawing.Point(80, 208);
            this.tb_oldDateNum.Name = "tb_oldDateNum";
            this.tb_oldDateNum.Size = new System.Drawing.Size(92, 35);
            this.tb_oldDateNum.TabIndex = 6;
            this.tb_oldDateNum.Text = "1";
            this.tb_oldDateNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_oldDateNum_KeyUp);
            this.tb_oldDateNum.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.label22.Location = new System.Drawing.Point(8, 208);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 28);
            this.label22.Text = "数量:";
            // 
            // lbl_monitor_date
            // 
            this.lbl_monitor_date.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.lbl_monitor_date.Location = new System.Drawing.Point(97, 82);
            this.lbl_monitor_date.Name = "lbl_monitor_date";
            this.lbl_monitor_date.Size = new System.Drawing.Size(109, 28);
            this.lbl_monitor_date.Text = "00000000";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(8, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 28);
            this.label10.Text = "进入监控日期";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(8, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 28);
            this.label9.Text = "商品日期";
            // 
            // tb_oldDate
            // 
            this.tb_oldDate.BackColor = System.Drawing.SystemColors.Control;
            this.tb_oldDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_oldDate.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.tb_oldDate.Location = new System.Drawing.Point(8, 154);
            this.tb_oldDate.Name = "tb_oldDate";
            this.tb_oldDate.Size = new System.Drawing.Size(188, 42);
            this.tb_oldDate.TabIndex = 1;
            this.tb_oldDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_oldDate_KeyUp);
            this.tb_oldDate.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 36);
            this.label2.Text = "旧日期管理";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Green;
            this.label8.Location = new System.Drawing.Point(3, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 36);
            this.label8.Text = "检查生产日期";
            // 
            // tb_checkDate
            // 
            this.tb_checkDate.BackColor = System.Drawing.SystemColors.Control;
            this.tb_checkDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_checkDate.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.tb_checkDate.Location = new System.Drawing.Point(12, 150);
            this.tb_checkDate.Name = "tb_checkDate";
            this.tb_checkDate.Size = new System.Drawing.Size(198, 39);
            this.tb_checkDate.TabIndex = 1;
            this.tb_checkDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_checkDate_KeyUp);
            this.tb_checkDate.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(3, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 41);
            this.label7.Text = "请扫描商品编号";
            // 
            // update
            // 
            this.update.Controls.Add(this.p_dateType);
            this.update.Controls.Add(this.lbl_udp_goods_no);
            this.update.Controls.Add(this.label24);
            this.update.Controls.Add(this.label19);
            this.update.Controls.Add(this.label18);
            this.update.Controls.Add(this.tb_save_day);
            this.update.Controls.Add(this.label17);
            this.update.Location = new System.Drawing.Point(4, 25);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(224, 266);
            this.update.Text = "update";
            // 
            // p_dateType
            // 
            this.p_dateType.Controls.Add(this.tb_date_type);
            this.p_dateType.Controls.Add(this.label26);
            this.p_dateType.Controls.Add(this.label23);
            this.p_dateType.Controls.Add(this.label21);
            this.p_dateType.Controls.Add(this.label20);
            this.p_dateType.Location = new System.Drawing.Point(0, 114);
            this.p_dateType.Name = "p_dateType";
            this.p_dateType.Size = new System.Drawing.Size(228, 152);
            this.p_dateType.Visible = false;
            // 
            // tb_date_type
            // 
            this.tb_date_type.BackColor = System.Drawing.SystemColors.Control;
            this.tb_date_type.Location = new System.Drawing.Point(28, 7);
            this.tb_date_type.Name = "tb_date_type";
            this.tb_date_type.Size = new System.Drawing.Size(10, 23);
            this.tb_date_type.TabIndex = 8;
            this.tb_date_type.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_date_type_KeyUp);
            this.tb_date_type.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label26.Location = new System.Drawing.Point(44, 120);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(132, 23);
            this.label26.Text = "3、有效日期";
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(44, 88);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(132, 23);
            this.label23.Text = "2、无保质期";
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(44, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(132, 23);
            this.label21.Text = "1、生产日期";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(44, 10);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(141, 20);
            this.label20.Text = "选择日期类型";
            // 
            // lbl_udp_goods_no
            // 
            this.lbl_udp_goods_no.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_udp_goods_no.Location = new System.Drawing.Point(41, 83);
            this.lbl_udp_goods_no.Name = "lbl_udp_goods_no";
            this.lbl_udp_goods_no.Size = new System.Drawing.Size(163, 28);
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label24.Location = new System.Drawing.Point(3, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(114, 20);
            this.label24.Text = "商品编号：";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.OrangeRed;
            this.label19.Location = new System.Drawing.Point(25, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(179, 39);
            this.label19.Text = "商品信息更新";
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(165, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 28);
            this.label18.Text = "(天)";
            // 
            // tb_save_day
            // 
            this.tb_save_day.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_save_day.Location = new System.Drawing.Point(68, 158);
            this.tb_save_day.MaxLength = 6;
            this.tb_save_day.Name = "tb_save_day";
            this.tb_save_day.Size = new System.Drawing.Size(91, 32);
            this.tb_save_day.TabIndex = 2;
            this.tb_save_day.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_save_day_KeyUp);
            this.tb_save_day.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(0, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 28);
            this.label17.Text = "请输入保质期";
            // 
            // offshelves
            // 
            this.offshelves.Controls.Add(this.label25);
            this.offshelves.Controls.Add(this.tb_func3_forcus);
            this.offshelves.Controls.Add(this.label27);
            this.offshelves.Location = new System.Drawing.Point(4, 25);
            this.offshelves.Name = "offshelves";
            this.offshelves.Size = new System.Drawing.Size(224, 266);
            this.offshelves.Text = "offshelves";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Blue;
            this.label25.Location = new System.Drawing.Point(3, 24);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(222, 36);
            this.label25.Text = "检查下架商品";
            // 
            // tb_func3_forcus
            // 
            this.tb_func3_forcus.BackColor = System.Drawing.SystemColors.Control;
            this.tb_func3_forcus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_func3_forcus.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.tb_func3_forcus.Location = new System.Drawing.Point(12, 137);
            this.tb_func3_forcus.Name = "tb_func3_forcus";
            this.tb_func3_forcus.Size = new System.Drawing.Size(198, 39);
            this.tb_func3_forcus.TabIndex = 4;
            this.tb_func3_forcus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_func3_forcus_KeyUp);
            this.tb_func3_forcus.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.label27.Location = new System.Drawing.Point(3, 83);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(207, 41);
            this.label27.Text = "请扫描商品";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.textBox8.Location = new System.Drawing.Point(10, 38);
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(218, 186);
            this.textBox8.TabIndex = 7;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(37, 230);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 24);
            this.label16.Text = "按1确认处理结果";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(61, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 28);
            this.label15.Text = "操作确认";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.textBox7.Location = new System.Drawing.Point(10, 230);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(21, 24);
            this.textBox7.TabIndex = 0;
            // 
            // p_msg
            // 
            this.p_msg.Controls.Add(this.tb_ResultShow);
            this.p_msg.Controls.Add(this.label5);
            this.p_msg.Controls.Add(this.label6);
            this.p_msg.Controls.Add(this.tb_Confirm);
            this.p_msg.Location = new System.Drawing.Point(0, 27);
            this.p_msg.Name = "p_msg";
            this.p_msg.Size = new System.Drawing.Size(235, 268);
            this.p_msg.Visible = false;
            // 
            // tb_ResultShow
            // 
            this.tb_ResultShow.BackColor = System.Drawing.SystemColors.Control;
            this.tb_ResultShow.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.tb_ResultShow.Location = new System.Drawing.Point(7, 22);
            this.tb_ResultShow.Multiline = true;
            this.tb_ResultShow.Name = "tb_ResultShow";
            this.tb_ResultShow.ReadOnly = true;
            this.tb_ResultShow.Size = new System.Drawing.Size(224, 220);
            this.tb_ResultShow.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(32, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 20);
            this.label5.Text = "按1确认处理结果";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(75, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.Text = "操作确认";
            // 
            // tb_Confirm
            // 
            this.tb_Confirm.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Confirm.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.tb_Confirm.Location = new System.Drawing.Point(7, 246);
            this.tb_Confirm.Name = "tb_Confirm";
            this.tb_Confirm.Size = new System.Drawing.Size(21, 19);
            this.tb_Confirm.TabIndex = 0;
            this.tb_Confirm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_Confirm_KeyUp);
            this.tb_Confirm.LostFocus += new System.EventHandler(this.IsLostFocus);
            // 
            // statusBar2
            // 
            this.statusBar2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.statusBar2.Location = new System.Drawing.Point(0, 295);
            this.statusBar2.Name = "statusBar2";
            this.statusBar2.Size = new System.Drawing.Size(235, 27);
            this.statusBar2.Text = "登录用户：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(238, 298);
            this.ControlBox = false;
            this.Controls.Add(this.statusBar2);
            this.Controls.Add(this.p_msg);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, -28);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.login.ResumeLayout(false);
            this.main.ResumeLayout(false);
            this.checkDate.ResumeLayout(false);
            this.p_oldDateInput.ResumeLayout(false);
            this.update.ResumeLayout(false);
            this.p_dateType.ResumeLayout(false);
            this.offshelves.ResumeLayout(false);
            this.p_msg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage login;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_worker_no;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage main;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_ui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Panel p_msg;
        private System.Windows.Forms.TextBox tb_ResultShow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_Confirm;
        private System.Windows.Forms.StatusBar statusBar2;
        private System.Windows.Forms.TabPage checkDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_checkDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel p_oldDateInput;
        private System.Windows.Forms.TextBox tb_oldDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_monitor_date;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tb_goods_shelves;
        private System.Windows.Forms.TabPage update;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_save_day;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl_udp_goods_no;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel p_dateType;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tb_date_type;
        private System.Windows.Forms.TextBox tb_oldDateNum;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage offshelves;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tb_func3_forcus;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
    }
}

