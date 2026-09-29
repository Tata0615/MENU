namespace customerApp
{
    partial class M010
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            L_処理区分 = new Label();
            G_得意先CD = new TextBox();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            label1 = new Label();
            CB_選択不可FLG = new CheckBox();
            L_得意先 = new Label();
            O_得意先名 = new TextBox();
            C_処理区分 = new ComboBox();
            L_得意先名 = new Label();
            G_得意先名 = new TextBox();
            GB_登録内容 = new GroupBox();
            L_前回請求締年月日 = new Label();
            O_前回請求締年月日 = new TextBox();
            L_備考 = new Label();
            G_備考 = new TextBox();
            L_MAIL = new Label();
            G_MAIL = new TextBox();
            L_担当者名 = new Label();
            G_担当者名 = new TextBox();
            L_FAX = new Label();
            G_FAX = new TextBox();
            L_TEL2 = new Label();
            G_TEL2 = new TextBox();
            L_TEL1 = new Label();
            G_TEL1 = new TextBox();
            L_住所2 = new Label();
            G_住所2 = new TextBox();
            L_住所1 = new Label();
            G_住所1 = new TextBox();
            L_郵便番号 = new Label();
            G_郵便番号 = new TextBox();
            groupBox1 = new GroupBox();
            B_Key04 = new Button();
            B_Key03 = new Button();
            B_Key01 = new Button();
            GB_処理区分.SuspendLayout();
            GB_登録内容.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // L_処理区分
            // 
            L_処理区分.BackColor = SystemColors.ControlDark;
            L_処理区分.BorderStyle = BorderStyle.FixedSingle;
            L_処理区分.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_処理区分.Location = new Point(30, 19);
            L_処理区分.Margin = new Padding(0);
            L_処理区分.MinimumSize = new Size(50, 25);
            L_処理区分.Name = "L_処理区分";
            L_処理区分.Size = new Size(80, 25);
            L_処理区分.TabIndex = 0;
            L_処理区分.Text = "処理区分";
            L_処理区分.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_得意先CD
            // 
            G_得意先CD.BackColor = Color.White;
            G_得意先CD.BorderStyle = BorderStyle.FixedSingle;
            G_得意先CD.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_得意先CD.Location = new Point(109, 43);
            G_得意先CD.MaximumSize = new Size(100, 25);
            G_得意先CD.MaxLength = 10;
            G_得意先CD.MinimumSize = new Size(65, 25);
            G_得意先CD.Name = "G_得意先CD";
            G_得意先CD.Size = new Size(75, 25);
            G_得意先CD.TabIndex = 3;
            G_得意先CD.Click += TextBox_Click;
            G_得意先CD.Enter += TextBox_Enter;
            G_得意先CD.KeyPress += G_得意先CD_KeyPress;
            G_得意先CD.Leave += TextBox_Leave;
            G_得意先CD.Validating += G_得意先CD_Validating;
            // 
            // B_Key12
            // 
            B_Key12.BackColor = Color.White;
            B_Key12.Location = new Point(764, 13);
            B_Key12.Name = "B_Key12";
            B_Key12.Size = new Size(105, 36);
            B_Key12.TabIndex = 2;
            B_Key12.TabStop = false;
            B_Key12.Text = "F12:登録";
            B_Key12.UseVisualStyleBackColor = false;
            B_Key12.Click += B_Key12_Click;
            // 
            // GB_処理区分
            // 
            GB_処理区分.Controls.Add(label1);
            GB_処理区分.Controls.Add(CB_選択不可FLG);
            GB_処理区分.Controls.Add(L_得意先);
            GB_処理区分.Controls.Add(O_得意先名);
            GB_処理区分.Controls.Add(L_処理区分);
            GB_処理区分.Controls.Add(G_得意先CD);
            GB_処理区分.Controls.Add(C_処理区分);
            GB_処理区分.Location = new Point(5, -2);
            GB_処理区分.Name = "GB_処理区分";
            GB_処理区分.Size = new Size(874, 80);
            GB_処理区分.TabIndex = 1;
            GB_処理区分.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(368, 22);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 9;
            label1.Text = "*は必須入力です";
            // 
            // CB_選択不可FLG
            // 
            CB_選択不可FLG.AutoSize = true;
            CB_選択不可FLG.Location = new Point(193, 22);
            CB_選択不可FLG.Name = "CB_選択不可FLG";
            CB_選択不可FLG.Size = new Size(74, 19);
            CB_選択不可FLG.TabIndex = 8;
            CB_選択不可FLG.TabStop = false;
            CB_選択不可FLG.Text = "選択不可";
            CB_選択不可FLG.UseVisualStyleBackColor = true;
            CB_選択不可FLG.CheckedChanged += CB_選択不可FLG_CheckedChanged;
            // 
            // L_得意先
            // 
            L_得意先.BackColor = SystemColors.ControlDark;
            L_得意先.BorderStyle = BorderStyle.FixedSingle;
            L_得意先.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_得意先.Location = new Point(30, 43);
            L_得意先.Margin = new Padding(0);
            L_得意先.MinimumSize = new Size(50, 25);
            L_得意先.Name = "L_得意先";
            L_得意先.Size = new Size(80, 25);
            L_得意先.TabIndex = 2;
            L_得意先.Text = "得意先*";
            L_得意先.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_得意先名
            // 
            O_得意先名.BackColor = Color.FromArgb(255, 255, 192);
            O_得意先名.BorderStyle = BorderStyle.FixedSingle;
            O_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_得意先名.Location = new Point(183, 43);
            O_得意先名.MaximumSize = new Size(300, 25);
            O_得意先名.MaxLength = 60;
            O_得意先名.MinimumSize = new Size(65, 25);
            O_得意先名.Name = "O_得意先名";
            O_得意先名.ReadOnly = true;
            O_得意先名.Size = new Size(275, 25);
            O_得意先名.TabIndex = 4;
            O_得意先名.TabStop = false;
            // 
            // C_処理区分
            // 
            C_処理区分.BackColor = Color.White;
            C_処理区分.DropDownStyle = ComboBoxStyle.DropDownList;
            C_処理区分.FlatStyle = FlatStyle.Flat;
            C_処理区分.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            C_処理区分.FormattingEnabled = true;
            C_処理区分.IntegralHeight = false;
            C_処理区分.ItemHeight = 17;
            C_処理区分.Items.AddRange(new object[] { "1:登録", "2:変更", "3:削除" });
            C_処理区分.Location = new Point(111, 19);
            C_処理区分.Name = "C_処理区分";
            C_処理区分.Size = new Size(73, 25);
            C_処理区分.TabIndex = 1;
            C_処理区分.SelectedIndexChanged += C_処理区分_SelectedIndexChanged;
            // 
            // L_得意先名
            // 
            L_得意先名.BackColor = SystemColors.ControlDark;
            L_得意先名.BorderStyle = BorderStyle.FixedSingle;
            L_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_得意先名.Location = new Point(30, 19);
            L_得意先名.Margin = new Padding(0);
            L_得意先名.MinimumSize = new Size(50, 25);
            L_得意先名.Name = "L_得意先名";
            L_得意先名.Size = new Size(80, 25);
            L_得意先名.TabIndex = 0;
            L_得意先名.Text = "得意先名*";
            L_得意先名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_得意先名
            // 
            G_得意先名.BackColor = Color.White;
            G_得意先名.BorderStyle = BorderStyle.FixedSingle;
            G_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_得意先名.ImeMode = ImeMode.Hiragana;
            G_得意先名.Location = new Point(109, 19);
            G_得意先名.MaximumSize = new Size(300, 25);
            G_得意先名.MaxLength = 60;
            G_得意先名.MinimumSize = new Size(65, 25);
            G_得意先名.Name = "G_得意先名";
            G_得意先名.Size = new Size(280, 25);
            G_得意先名.TabIndex = 1;
            G_得意先名.Click += TextBox_Click;
            G_得意先名.Enter += TextBox_Enter;
            G_得意先名.Leave += TextBox_Leave;
            G_得意先名.Validating += G_得意先名_Validating;
            // 
            // GB_登録内容
            // 
            GB_登録内容.Controls.Add(L_前回請求締年月日);
            GB_登録内容.Controls.Add(O_前回請求締年月日);
            GB_登録内容.Controls.Add(L_備考);
            GB_登録内容.Controls.Add(G_備考);
            GB_登録内容.Controls.Add(L_MAIL);
            GB_登録内容.Controls.Add(G_MAIL);
            GB_登録内容.Controls.Add(L_担当者名);
            GB_登録内容.Controls.Add(G_担当者名);
            GB_登録内容.Controls.Add(L_FAX);
            GB_登録内容.Controls.Add(G_FAX);
            GB_登録内容.Controls.Add(L_TEL2);
            GB_登録内容.Controls.Add(G_TEL2);
            GB_登録内容.Controls.Add(L_TEL1);
            GB_登録内容.Controls.Add(G_TEL1);
            GB_登録内容.Controls.Add(L_住所2);
            GB_登録内容.Controls.Add(G_住所2);
            GB_登録内容.Controls.Add(L_住所1);
            GB_登録内容.Controls.Add(G_住所1);
            GB_登録内容.Controls.Add(L_郵便番号);
            GB_登録内容.Controls.Add(G_郵便番号);
            GB_登録内容.Controls.Add(L_得意先名);
            GB_登録内容.Controls.Add(G_得意先名);
            GB_登録内容.Location = new Point(5, 73);
            GB_登録内容.Name = "GB_登録内容";
            GB_登録内容.Size = new Size(874, 414);
            GB_登録内容.TabIndex = 2;
            GB_登録内容.TabStop = false;
            // 
            // L_前回請求締年月日
            // 
            L_前回請求締年月日.BackColor = SystemColors.ControlDark;
            L_前回請求締年月日.BorderStyle = BorderStyle.FixedSingle;
            L_前回請求締年月日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_前回請求締年月日.Location = new Point(30, 286);
            L_前回請求締年月日.Margin = new Padding(0);
            L_前回請求締年月日.MinimumSize = new Size(50, 25);
            L_前回請求締年月日.Name = "L_前回請求締年月日";
            L_前回請求締年月日.Size = new Size(116, 25);
            L_前回請求締年月日.TabIndex = 20;
            L_前回請求締年月日.Text = "前回請求締年月日";
            L_前回請求締年月日.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_前回請求締年月日
            // 
            O_前回請求締年月日.BackColor = Color.FromArgb(255, 255, 192);
            O_前回請求締年月日.BorderStyle = BorderStyle.FixedSingle;
            O_前回請求締年月日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_前回請求締年月日.ImeMode = ImeMode.Hiragana;
            O_前回請求締年月日.Location = new Point(145, 286);
            O_前回請求締年月日.MaximumSize = new Size(300, 25);
            O_前回請求締年月日.MaxLength = 30;
            O_前回請求締年月日.MinimumSize = new Size(65, 25);
            O_前回請求締年月日.Name = "O_前回請求締年月日";
            O_前回請求締年月日.ReadOnly = true;
            O_前回請求締年月日.Size = new Size(75, 25);
            O_前回請求締年月日.TabIndex = 21;
            O_前回請求締年月日.TabStop = false;
            O_前回請求締年月日.TextAlign = HorizontalAlignment.Right;
            // 
            // L_備考
            // 
            L_備考.BackColor = SystemColors.ControlDark;
            L_備考.BorderStyle = BorderStyle.FixedSingle;
            L_備考.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_備考.Location = new Point(30, 222);
            L_備考.Margin = new Padding(0);
            L_備考.MinimumSize = new Size(50, 25);
            L_備考.Name = "L_備考";
            L_備考.Size = new Size(80, 50);
            L_備考.TabIndex = 18;
            L_備考.Text = "備考";
            L_備考.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_備考
            // 
            G_備考.BackColor = Color.White;
            G_備考.BorderStyle = BorderStyle.FixedSingle;
            G_備考.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_備考.ImeMode = ImeMode.Hiragana;
            G_備考.Location = new Point(109, 222);
            G_備考.MaximumSize = new Size(300, 50);
            G_備考.MaxLength = 255;
            G_備考.MinimumSize = new Size(65, 25);
            G_備考.Multiline = true;
            G_備考.Name = "G_備考";
            G_備考.Size = new Size(280, 50);
            G_備考.TabIndex = 19;
            G_備考.Click += TextBox_Click;
            G_備考.Enter += TextBox_Enter;
            G_備考.Leave += TextBox_Leave;
            // 
            // L_MAIL
            // 
            L_MAIL.BackColor = SystemColors.ControlDark;
            L_MAIL.BorderStyle = BorderStyle.FixedSingle;
            L_MAIL.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_MAIL.Location = new Point(30, 170);
            L_MAIL.Margin = new Padding(0);
            L_MAIL.MinimumSize = new Size(50, 25);
            L_MAIL.Name = "L_MAIL";
            L_MAIL.Size = new Size(80, 25);
            L_MAIL.TabIndex = 14;
            L_MAIL.Text = "MAIL";
            L_MAIL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_MAIL
            // 
            G_MAIL.BackColor = Color.White;
            G_MAIL.BorderStyle = BorderStyle.FixedSingle;
            G_MAIL.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_MAIL.Location = new Point(109, 170);
            G_MAIL.MaximumSize = new Size(300, 25);
            G_MAIL.MaxLength = 100;
            G_MAIL.MinimumSize = new Size(65, 25);
            G_MAIL.Name = "G_MAIL";
            G_MAIL.Size = new Size(280, 25);
            G_MAIL.TabIndex = 15;
            G_MAIL.Click += TextBox_Click;
            G_MAIL.Enter += TextBox_Enter;
            G_MAIL.Leave += TextBox_Leave;
            // 
            // L_担当者名
            // 
            L_担当者名.BackColor = SystemColors.ControlDark;
            L_担当者名.BorderStyle = BorderStyle.FixedSingle;
            L_担当者名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_担当者名.Location = new Point(30, 194);
            L_担当者名.Margin = new Padding(0);
            L_担当者名.MinimumSize = new Size(50, 25);
            L_担当者名.Name = "L_担当者名";
            L_担当者名.Size = new Size(80, 25);
            L_担当者名.TabIndex = 16;
            L_担当者名.Text = "担当者名";
            L_担当者名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_担当者名
            // 
            G_担当者名.BackColor = Color.White;
            G_担当者名.BorderStyle = BorderStyle.FixedSingle;
            G_担当者名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_担当者名.ImeMode = ImeMode.Hiragana;
            G_担当者名.Location = new Point(109, 194);
            G_担当者名.MaximumSize = new Size(300, 25);
            G_担当者名.MaxLength = 30;
            G_担当者名.MinimumSize = new Size(65, 25);
            G_担当者名.Name = "G_担当者名";
            G_担当者名.Size = new Size(280, 25);
            G_担当者名.TabIndex = 17;
            G_担当者名.Click += TextBox_Click;
            G_担当者名.Enter += TextBox_Enter;
            G_担当者名.Leave += TextBox_Leave;
            // 
            // L_FAX
            // 
            L_FAX.BackColor = SystemColors.ControlDark;
            L_FAX.BorderStyle = BorderStyle.FixedSingle;
            L_FAX.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_FAX.Location = new Point(30, 146);
            L_FAX.Margin = new Padding(0);
            L_FAX.MinimumSize = new Size(50, 25);
            L_FAX.Name = "L_FAX";
            L_FAX.Size = new Size(80, 25);
            L_FAX.TabIndex = 12;
            L_FAX.Text = "FAX";
            L_FAX.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_FAX
            // 
            G_FAX.BackColor = Color.White;
            G_FAX.BorderStyle = BorderStyle.FixedSingle;
            G_FAX.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_FAX.ImeMode = ImeMode.Disable;
            G_FAX.Location = new Point(109, 146);
            G_FAX.MaximumSize = new Size(300, 25);
            G_FAX.MaxLength = 20;
            G_FAX.MinimumSize = new Size(65, 25);
            G_FAX.Name = "G_FAX";
            G_FAX.Size = new Size(101, 25);
            G_FAX.TabIndex = 13;
            G_FAX.Click += TextBox_Click;
            G_FAX.Enter += TextBox_Enter;
            G_FAX.Leave += TextBox_Leave;
            // 
            // L_TEL2
            // 
            L_TEL2.BackColor = SystemColors.ControlDark;
            L_TEL2.BorderStyle = BorderStyle.FixedSingle;
            L_TEL2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_TEL2.Location = new Point(209, 122);
            L_TEL2.Margin = new Padding(0);
            L_TEL2.MinimumSize = new Size(50, 25);
            L_TEL2.Name = "L_TEL2";
            L_TEL2.Size = new Size(80, 25);
            L_TEL2.TabIndex = 10;
            L_TEL2.Text = "TEL2";
            L_TEL2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_TEL2
            // 
            G_TEL2.BackColor = Color.White;
            G_TEL2.BorderStyle = BorderStyle.FixedSingle;
            G_TEL2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_TEL2.ImeMode = ImeMode.Disable;
            G_TEL2.Location = new Point(288, 122);
            G_TEL2.MaximumSize = new Size(300, 25);
            G_TEL2.MaxLength = 20;
            G_TEL2.MinimumSize = new Size(65, 25);
            G_TEL2.Name = "G_TEL2";
            G_TEL2.Size = new Size(101, 25);
            G_TEL2.TabIndex = 11;
            G_TEL2.Click += TextBox_Click;
            G_TEL2.Enter += TextBox_Enter;
            G_TEL2.Leave += TextBox_Leave;
            // 
            // L_TEL1
            // 
            L_TEL1.BackColor = SystemColors.ControlDark;
            L_TEL1.BorderStyle = BorderStyle.FixedSingle;
            L_TEL1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_TEL1.Location = new Point(30, 122);
            L_TEL1.Margin = new Padding(0);
            L_TEL1.MinimumSize = new Size(50, 25);
            L_TEL1.Name = "L_TEL1";
            L_TEL1.Size = new Size(80, 25);
            L_TEL1.TabIndex = 8;
            L_TEL1.Text = "TEL1";
            L_TEL1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_TEL1
            // 
            G_TEL1.BackColor = Color.White;
            G_TEL1.BorderStyle = BorderStyle.FixedSingle;
            G_TEL1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_TEL1.ImeMode = ImeMode.Disable;
            G_TEL1.Location = new Point(109, 122);
            G_TEL1.MaximumSize = new Size(300, 25);
            G_TEL1.MaxLength = 20;
            G_TEL1.MinimumSize = new Size(65, 25);
            G_TEL1.Name = "G_TEL1";
            G_TEL1.Size = new Size(101, 25);
            G_TEL1.TabIndex = 9;
            G_TEL1.Click += TextBox_Click;
            G_TEL1.Enter += TextBox_Enter;
            G_TEL1.Leave += TextBox_Leave;
            // 
            // L_住所2
            // 
            L_住所2.BackColor = SystemColors.ControlDark;
            L_住所2.BorderStyle = BorderStyle.FixedSingle;
            L_住所2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_住所2.Location = new Point(30, 98);
            L_住所2.Margin = new Padding(0);
            L_住所2.MinimumSize = new Size(50, 25);
            L_住所2.Name = "L_住所2";
            L_住所2.Size = new Size(80, 25);
            L_住所2.TabIndex = 6;
            L_住所2.Text = "住所2";
            L_住所2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_住所2
            // 
            G_住所2.BackColor = Color.White;
            G_住所2.BorderStyle = BorderStyle.FixedSingle;
            G_住所2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_住所2.ImeMode = ImeMode.Hiragana;
            G_住所2.Location = new Point(109, 98);
            G_住所2.MaximumSize = new Size(300, 25);
            G_住所2.MaxLength = 60;
            G_住所2.MinimumSize = new Size(65, 25);
            G_住所2.Name = "G_住所2";
            G_住所2.Size = new Size(280, 25);
            G_住所2.TabIndex = 7;
            G_住所2.Click += TextBox_Click;
            G_住所2.Enter += TextBox_Enter;
            G_住所2.Leave += TextBox_Leave;
            // 
            // L_住所1
            // 
            L_住所1.BackColor = SystemColors.ControlDark;
            L_住所1.BorderStyle = BorderStyle.FixedSingle;
            L_住所1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_住所1.Location = new Point(30, 74);
            L_住所1.Margin = new Padding(0);
            L_住所1.MinimumSize = new Size(50, 25);
            L_住所1.Name = "L_住所1";
            L_住所1.Size = new Size(80, 25);
            L_住所1.TabIndex = 4;
            L_住所1.Text = "住所1";
            L_住所1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_住所1
            // 
            G_住所1.BackColor = Color.White;
            G_住所1.BorderStyle = BorderStyle.FixedSingle;
            G_住所1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_住所1.ImeMode = ImeMode.Hiragana;
            G_住所1.Location = new Point(109, 74);
            G_住所1.MaximumSize = new Size(300, 25);
            G_住所1.MaxLength = 60;
            G_住所1.MinimumSize = new Size(65, 25);
            G_住所1.Name = "G_住所1";
            G_住所1.Size = new Size(280, 25);
            G_住所1.TabIndex = 5;
            G_住所1.Click += TextBox_Click;
            G_住所1.Enter += TextBox_Enter;
            G_住所1.Leave += TextBox_Leave;
            // 
            // L_郵便番号
            // 
            L_郵便番号.BackColor = SystemColors.ControlDark;
            L_郵便番号.BorderStyle = BorderStyle.FixedSingle;
            L_郵便番号.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_郵便番号.Location = new Point(30, 50);
            L_郵便番号.Margin = new Padding(0);
            L_郵便番号.MinimumSize = new Size(50, 25);
            L_郵便番号.Name = "L_郵便番号";
            L_郵便番号.Size = new Size(80, 25);
            L_郵便番号.TabIndex = 2;
            L_郵便番号.Text = "郵便番号";
            L_郵便番号.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_郵便番号
            // 
            G_郵便番号.BackColor = Color.White;
            G_郵便番号.BorderStyle = BorderStyle.FixedSingle;
            G_郵便番号.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_郵便番号.ImeMode = ImeMode.Disable;
            G_郵便番号.Location = new Point(109, 50);
            G_郵便番号.MaximumSize = new Size(300, 25);
            G_郵便番号.MaxLength = 8;
            G_郵便番号.MinimumSize = new Size(65, 25);
            G_郵便番号.Name = "G_郵便番号";
            G_郵便番号.Size = new Size(75, 25);
            G_郵便番号.TabIndex = 3;
            G_郵便番号.Click += TextBox_Click;
            G_郵便番号.Enter += TextBox_Enter;
            G_郵便番号.Leave += TextBox_Leave;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(B_Key04);
            groupBox1.Controls.Add(B_Key03);
            groupBox1.Controls.Add(B_Key01);
            groupBox1.Controls.Add(B_Key12);
            groupBox1.Location = new Point(5, 482);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(874, 55);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // B_Key04
            // 
            B_Key04.BackColor = Color.White;
            B_Key04.Location = new Point(217, 13);
            B_Key04.Name = "B_Key04";
            B_Key04.Size = new Size(105, 36);
            B_Key04.TabIndex = 5;
            B_Key04.TabStop = false;
            B_Key04.Text = "F4:検索";
            B_Key04.UseVisualStyleBackColor = false;
            B_Key04.Click += B_Key04_Click;
            // 
            // B_Key03
            // 
            B_Key03.BackColor = Color.White;
            B_Key03.Location = new Point(111, 13);
            B_Key03.Name = "B_Key03";
            B_Key03.Size = new Size(105, 36);
            B_Key03.TabIndex = 4;
            B_Key03.TabStop = false;
            B_Key03.Text = "F3:ｸﾘｱ";
            B_Key03.UseVisualStyleBackColor = false;
            B_Key03.Click += B_Key03_Click;
            // 
            // B_Key01
            // 
            B_Key01.BackColor = Color.White;
            B_Key01.CausesValidation = false;
            B_Key01.Location = new Point(5, 13);
            B_Key01.Name = "B_Key01";
            B_Key01.Size = new Size(105, 36);
            B_Key01.TabIndex = 3;
            B_Key01.TabStop = false;
            B_Key01.Text = "F1:終了";
            B_Key01.UseVisualStyleBackColor = false;
            B_Key01.Click += B_Key01_Click;
            // 
            // M010
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 541);
            Controls.Add(GB_処理区分);
            Controls.Add(GB_登録内容);
            Controls.Add(groupBox1);
            KeyPreview = true;
            MaximumSize = new Size(900, 580);
            MinimumSize = new Size(900, 580);
            Name = "M010";
            Text = "M010【得意先マスタ】";
            Load += MHE010_Load;
            KeyDown += MHE010_KeyDown;
            GB_処理区分.ResumeLayout(false);
            GB_処理区分.PerformLayout();
            GB_登録内容.ResumeLayout(false);
            GB_登録内容.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label L_処理区分;
        private TextBox G_得意先CD;
        private Button B_Key12;
        private GroupBox GB_処理区分;
        private ComboBox C_処理区分;
        private Label L_得意先;
        private TextBox O_得意先名;
        private Label L_得意先名;
        private TextBox G_得意先名;
        private GroupBox GB_登録内容;
        private Label L_郵便番号;
        private TextBox G_郵便番号;
        private Label L_住所2;
        private TextBox G_住所2;
        private Label L_住所1;
        private TextBox G_住所1;
        private Label L_TEL2;
        private TextBox G_TEL2;
        private Label L_TEL1;
        private TextBox G_TEL1;
        private Label L_FAX;
        private TextBox G_FAX;
        private Label L_MAIL;
        private TextBox G_MAIL;
        private Label L_担当者名;
        private TextBox G_担当者名;
        private CheckBox CB_選択不可FLG;
        private GroupBox groupBox1;
        private Button B_Key03;
        private Button B_Key01;
        private Label L_備考;
        private TextBox G_備考;
        private Label label1;
        private Label L_前回請求締年月日;
        private TextBox O_前回請求締年月日;
        private Button B_Key04;
    }
}
