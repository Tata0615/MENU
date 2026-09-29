namespace customerApp
{
    partial class M030
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
            G_商品CD = new TextBox();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            label1 = new Label();
            L_商品 = new Label();
            O_商品名 = new TextBox();
            C_処理区分 = new ComboBox();
            L_商品名 = new Label();
            G_商品名 = new TextBox();
            GB_登録内容 = new GroupBox();
            L_単価 = new Label();
            N_単価 = new NumericUpDown();
            L_消費税率 = new Label();
            C_消費税率 = new ComboBox();
            L_備考 = new Label();
            G_備考 = new TextBox();
            L_単位名 = new Label();
            G_単位名 = new TextBox();
            groupBox1 = new GroupBox();
            B_Key04 = new Button();
            B_Key03 = new Button();
            B_Key01 = new Button();
            GB_処理区分.SuspendLayout();
            GB_登録内容.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)N_単価).BeginInit();
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
            // G_商品CD
            // 
            G_商品CD.BackColor = Color.White;
            G_商品CD.BorderStyle = BorderStyle.FixedSingle;
            G_商品CD.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_商品CD.Location = new Point(109, 43);
            G_商品CD.MaximumSize = new Size(100, 25);
            G_商品CD.MaxLength = 10;
            G_商品CD.MinimumSize = new Size(65, 25);
            G_商品CD.Name = "G_商品CD";
            G_商品CD.Size = new Size(75, 25);
            G_商品CD.TabIndex = 3;
            G_商品CD.Click += TextBox_Click;
            G_商品CD.Enter += TextBox_Enter;
            G_商品CD.KeyPress += G_商品CD_KeyPress;
            G_商品CD.Leave += TextBox_Leave;
            G_商品CD.Validating += G_商品CD_Validating;
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
            GB_処理区分.Controls.Add(L_商品);
            GB_処理区分.Controls.Add(O_商品名);
            GB_処理区分.Controls.Add(L_処理区分);
            GB_処理区分.Controls.Add(G_商品CD);
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
            // L_商品
            // 
            L_商品.BackColor = SystemColors.ControlDark;
            L_商品.BorderStyle = BorderStyle.FixedSingle;
            L_商品.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_商品.Location = new Point(30, 43);
            L_商品.Margin = new Padding(0);
            L_商品.MinimumSize = new Size(50, 25);
            L_商品.Name = "L_商品";
            L_商品.Size = new Size(80, 25);
            L_商品.TabIndex = 2;
            L_商品.Text = "商品CD*";
            L_商品.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_商品名
            // 
            O_商品名.BackColor = Color.FromArgb(255, 255, 192);
            O_商品名.BorderStyle = BorderStyle.FixedSingle;
            O_商品名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_商品名.Location = new Point(183, 43);
            O_商品名.MaximumSize = new Size(300, 25);
            O_商品名.MaxLength = 60;
            O_商品名.MinimumSize = new Size(65, 25);
            O_商品名.Name = "O_商品名";
            O_商品名.ReadOnly = true;
            O_商品名.Size = new Size(275, 25);
            O_商品名.TabIndex = 4;
            O_商品名.TabStop = false;
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
            // L_商品名
            // 
            L_商品名.BackColor = SystemColors.ControlDark;
            L_商品名.BorderStyle = BorderStyle.FixedSingle;
            L_商品名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_商品名.Location = new Point(30, 19);
            L_商品名.Margin = new Padding(0);
            L_商品名.MinimumSize = new Size(50, 25);
            L_商品名.Name = "L_商品名";
            L_商品名.Size = new Size(80, 25);
            L_商品名.TabIndex = 0;
            L_商品名.Text = "商品名*";
            L_商品名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_商品名
            // 
            G_商品名.BackColor = Color.White;
            G_商品名.BorderStyle = BorderStyle.FixedSingle;
            G_商品名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_商品名.ImeMode = ImeMode.Hiragana;
            G_商品名.Location = new Point(109, 19);
            G_商品名.MaximumSize = new Size(300, 25);
            G_商品名.MaxLength = 60;
            G_商品名.MinimumSize = new Size(65, 25);
            G_商品名.Name = "G_商品名";
            G_商品名.Size = new Size(280, 25);
            G_商品名.TabIndex = 1;
            G_商品名.Click += TextBox_Click;
            G_商品名.Enter += TextBox_Enter;
            G_商品名.Leave += TextBox_Leave;
            G_商品名.Validating += G_商品名_Validating;
            // 
            // GB_登録内容
            // 
            GB_登録内容.Controls.Add(L_単価);
            GB_登録内容.Controls.Add(N_単価);
            GB_登録内容.Controls.Add(L_消費税率);
            GB_登録内容.Controls.Add(C_消費税率);
            GB_登録内容.Controls.Add(L_備考);
            GB_登録内容.Controls.Add(G_備考);
            GB_登録内容.Controls.Add(L_単位名);
            GB_登録内容.Controls.Add(G_単位名);
            GB_登録内容.Controls.Add(L_商品名);
            GB_登録内容.Controls.Add(G_商品名);
            GB_登録内容.Location = new Point(5, 73);
            GB_登録内容.Name = "GB_登録内容";
            GB_登録内容.Size = new Size(874, 414);
            GB_登録内容.TabIndex = 2;
            GB_登録内容.TabStop = false;
            // 
            // L_単価
            // 
            L_単価.BackColor = SystemColors.ControlDark;
            L_単価.BorderStyle = BorderStyle.FixedSingle;
            L_単価.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_単価.Location = new Point(30, 67);
            L_単価.Margin = new Padding(0);
            L_単価.MinimumSize = new Size(50, 25);
            L_単価.Name = "L_単価";
            L_単価.Size = new Size(80, 25);
            L_単価.TabIndex = 4;
            L_単価.Text = "単価";
            L_単価.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // N_単価
            // 
            N_単価.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            N_単価.Location = new Point(109, 67);
            N_単価.Maximum = new decimal(new int[] { 999999999, 0, 0, 0 });
            N_単価.Name = "N_単価";
            N_単価.Size = new Size(96, 25);
            N_単価.TabIndex = 5;
            N_単価.TextAlign = HorizontalAlignment.Right;
            N_単価.ThousandsSeparator = true;
            // 
            // L_消費税率
            // 
            L_消費税率.BackColor = SystemColors.ControlDark;
            L_消費税率.BorderStyle = BorderStyle.FixedSingle;
            L_消費税率.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_消費税率.Location = new Point(30, 91);
            L_消費税率.Margin = new Padding(0);
            L_消費税率.MinimumSize = new Size(50, 25);
            L_消費税率.Name = "L_消費税率";
            L_消費税率.Size = new Size(80, 25);
            L_消費税率.TabIndex = 6;
            L_消費税率.Text = "消費税率";
            L_消費税率.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C_消費税率
            // 
            C_消費税率.BackColor = Color.White;
            C_消費税率.DropDownStyle = ComboBoxStyle.DropDownList;
            C_消費税率.FlatStyle = FlatStyle.Flat;
            C_消費税率.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            C_消費税率.FormattingEnabled = true;
            C_消費税率.IntegralHeight = false;
            C_消費税率.ItemHeight = 17;
            C_消費税率.Items.AddRange(new object[] { "1:8％(軽減税率)", "2:10％(標準税率)" });
            C_消費税率.Location = new Point(111, 91);
            C_消費税率.Name = "C_消費税率";
            C_消費税率.Size = new Size(123, 25);
            C_消費税率.TabIndex = 7;
            // 
            // L_備考
            // 
            L_備考.BackColor = SystemColors.ControlDark;
            L_備考.BorderStyle = BorderStyle.FixedSingle;
            L_備考.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_備考.Location = new Point(30, 124);
            L_備考.Margin = new Padding(0);
            L_備考.MinimumSize = new Size(50, 25);
            L_備考.Name = "L_備考";
            L_備考.Size = new Size(80, 50);
            L_備考.TabIndex = 8;
            L_備考.Text = "備考";
            L_備考.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_備考
            // 
            G_備考.BackColor = Color.White;
            G_備考.BorderStyle = BorderStyle.FixedSingle;
            G_備考.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_備考.ImeMode = ImeMode.Hiragana;
            G_備考.Location = new Point(109, 124);
            G_備考.MaximumSize = new Size(300, 50);
            G_備考.MaxLength = 255;
            G_備考.MinimumSize = new Size(65, 25);
            G_備考.Multiline = true;
            G_備考.Name = "G_備考";
            G_備考.Size = new Size(280, 50);
            G_備考.TabIndex = 9;
            G_備考.Click += TextBox_Click;
            G_備考.Enter += TextBox_Enter;
            G_備考.Leave += TextBox_Leave;
            // 
            // L_単位名
            // 
            L_単位名.BackColor = SystemColors.ControlDark;
            L_単位名.BorderStyle = BorderStyle.FixedSingle;
            L_単位名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_単位名.Location = new Point(30, 43);
            L_単位名.Margin = new Padding(0);
            L_単位名.MinimumSize = new Size(50, 25);
            L_単位名.Name = "L_単位名";
            L_単位名.Size = new Size(80, 25);
            L_単位名.TabIndex = 2;
            L_単位名.Text = "単位名";
            L_単位名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_単位名
            // 
            G_単位名.BackColor = Color.White;
            G_単位名.BorderStyle = BorderStyle.FixedSingle;
            G_単位名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_単位名.ImeMode = ImeMode.Hiragana;
            G_単位名.Location = new Point(109, 43);
            G_単位名.MaximumSize = new Size(300, 25);
            G_単位名.MaxLength = 60;
            G_単位名.MinimumSize = new Size(65, 25);
            G_単位名.Name = "G_単位名";
            G_単位名.Size = new Size(96, 25);
            G_単位名.TabIndex = 3;
            G_単位名.Click += TextBox_Click;
            G_単位名.Enter += TextBox_Enter;
            G_単位名.Leave += TextBox_Leave;
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
            // M030
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
            Name = "M030";
            Text = "M030【商品マスタ】";
            Load += M030_Load;
            KeyDown += MHE010_KeyDown;
            GB_処理区分.ResumeLayout(false);
            GB_処理区分.PerformLayout();
            GB_登録内容.ResumeLayout(false);
            GB_登録内容.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)N_単価).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label L_処理区分;
        private TextBox G_商品CD;
        private Button B_Key12;
        private GroupBox GB_処理区分;
        private ComboBox C_処理区分;
        private Label L_商品;
        private TextBox O_商品名;
        private Label L_商品名;
        private TextBox G_商品名;
        private GroupBox GB_登録内容;
        private Label L_単位名;
        private TextBox G_単位名;
        private Label L_単価;
        private GroupBox groupBox1;
        private Button B_Key03;
        private Button B_Key01;
        private Label L_備考;
        private TextBox G_備考;
        private Label label1;
        private Label L_消費税率;
        private ComboBox C_消費税率;
        private NumericUpDown N_単価;
        private Button B_Key04;
    }
}
