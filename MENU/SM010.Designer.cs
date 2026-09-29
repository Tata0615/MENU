namespace customerApp
{
    partial class SM010
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle15 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            G_得意先名 = new TextBox();
            L_得意先名 = new Label();
            GB_登録内容 = new GroupBox();
            DG1 = new DataGridView();
            groupBox1 = new GroupBox();
            B_Key03 = new Button();
            B_Key01 = new Button();
            得意先CD = new DataGridViewTextBoxColumn();
            得意先名 = new DataGridViewTextBoxColumn();
            郵便番号 = new DataGridViewTextBoxColumn();
            住所1 = new DataGridViewTextBoxColumn();
            住所2 = new DataGridViewTextBoxColumn();
            TEL1 = new DataGridViewTextBoxColumn();
            TEL2 = new DataGridViewTextBoxColumn();
            FAX = new DataGridViewTextBoxColumn();
            MAIL = new DataGridViewTextBoxColumn();
            担当者名 = new DataGridViewTextBoxColumn();
            備考 = new DataGridViewTextBoxColumn();
            選択不可FLG = new DataGridViewTextBoxColumn();
            前回請求締年月日 = new DataGridViewTextBoxColumn();
            GB_処理区分.SuspendLayout();
            GB_登録内容.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DG1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
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
            GB_処理区分.Controls.Add(G_得意先名);
            GB_処理区分.Controls.Add(L_得意先名);
            GB_処理区分.Location = new Point(5, -2);
            GB_処理区分.Name = "GB_処理区分";
            GB_処理区分.Size = new Size(874, 74);
            GB_処理区分.TabIndex = 1;
            GB_処理区分.TabStop = false;
            // 
            // G_得意先名
            // 
            G_得意先名.BackColor = Color.White;
            G_得意先名.BorderStyle = BorderStyle.FixedSingle;
            G_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_得意先名.ImeMode = ImeMode.Hiragana;
            G_得意先名.Location = new Point(100, 29);
            G_得意先名.MaximumSize = new Size(300, 25);
            G_得意先名.MaxLength = 8;
            G_得意先名.MinimumSize = new Size(20, 25);
            G_得意先名.Name = "G_得意先名";
            G_得意先名.Size = new Size(300, 25);
            G_得意先名.TabIndex = 1;
            // 
            // L_得意先名
            // 
            L_得意先名.BackColor = SystemColors.ControlDark;
            L_得意先名.BorderStyle = BorderStyle.FixedSingle;
            L_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_得意先名.Location = new Point(21, 29);
            L_得意先名.Margin = new Padding(0);
            L_得意先名.MinimumSize = new Size(50, 25);
            L_得意先名.Name = "L_得意先名";
            L_得意先名.Size = new Size(80, 25);
            L_得意先名.TabIndex = 8;
            L_得意先名.Text = "得意先名";
            L_得意先名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GB_登録内容
            // 
            GB_登録内容.Controls.Add(DG1);
            GB_登録内容.Location = new Point(5, 67);
            GB_登録内容.Name = "GB_登録内容";
            GB_登録内容.Size = new Size(874, 420);
            GB_登録内容.TabIndex = 2;
            GB_登録内容.TabStop = false;
            // 
            // DG1
            // 
            DG1.AllowUserToAddRows = false;
            DG1.AllowUserToDeleteRows = false;
            DG1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DG1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DG1.ColumnHeadersHeight = 25;
            DG1.Columns.AddRange(new DataGridViewColumn[] { 得意先CD, 得意先名, 郵便番号, 住所1, 住所2, TEL1, TEL2, FAX, MAIL, 担当者名, 備考, 選択不可FLG, 前回請求締年月日 });
            DG1.EnableHeadersVisualStyles = false;
            DG1.Location = new Point(7, 18);
            DG1.Name = "DG1";
            DG1.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = SystemColors.Control;
            dataGridViewCellStyle15.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle15.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = DataGridViewTriState.True;
            DG1.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            DG1.RowHeadersVisible = false;
            DG1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG1.Size = new Size(860, 394);
            DG1.TabIndex = 0;
            DG1.CellContentDoubleClick += DG1_CellDoubleClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(B_Key03);
            groupBox1.Controls.Add(B_Key01);
            groupBox1.Controls.Add(B_Key12);
            groupBox1.Location = new Point(5, 482);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(874, 55);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
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
            // 得意先CD
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            得意先CD.DefaultCellStyle = dataGridViewCellStyle2;
            得意先CD.HeaderText = "得意先CD";
            得意先CD.Name = "得意先CD";
            得意先CD.ReadOnly = true;
            // 
            // 得意先名
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            得意先名.DefaultCellStyle = dataGridViewCellStyle3;
            得意先名.HeaderText = "得意先名";
            得意先名.Name = "得意先名";
            得意先名.ReadOnly = true;
            // 
            // 郵便番号
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            郵便番号.DefaultCellStyle = dataGridViewCellStyle4;
            郵便番号.HeaderText = "郵便番号";
            郵便番号.Name = "郵便番号";
            郵便番号.ReadOnly = true;
            // 
            // 住所1
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            住所1.DefaultCellStyle = dataGridViewCellStyle5;
            住所1.HeaderText = "住所1";
            住所1.Name = "住所1";
            住所1.ReadOnly = true;
            住所1.Width = 70;
            // 
            // 住所2
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            住所2.DefaultCellStyle = dataGridViewCellStyle6;
            住所2.HeaderText = "住所2";
            住所2.Name = "住所2";
            住所2.ReadOnly = true;
            // 
            // TEL1
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TEL1.DefaultCellStyle = dataGridViewCellStyle7;
            TEL1.HeaderText = "TEL1";
            TEL1.Name = "TEL1";
            TEL1.ReadOnly = true;
            // 
            // TEL2
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            TEL2.DefaultCellStyle = dataGridViewCellStyle8;
            TEL2.HeaderText = "TEL2";
            TEL2.Name = "TEL2";
            TEL2.ReadOnly = true;
            // 
            // FAX
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            FAX.DefaultCellStyle = dataGridViewCellStyle9;
            FAX.HeaderText = "FAX";
            FAX.Name = "FAX";
            FAX.ReadOnly = true;
            // 
            // MAIL
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            MAIL.DefaultCellStyle = dataGridViewCellStyle10;
            MAIL.HeaderText = "MAIL";
            MAIL.Name = "MAIL";
            MAIL.ReadOnly = true;
            // 
            // 担当者名
            // 
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            担当者名.DefaultCellStyle = dataGridViewCellStyle11;
            担当者名.HeaderText = "担当者名";
            担当者名.Name = "担当者名";
            担当者名.ReadOnly = true;
            // 
            // 備考
            // 
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            備考.DefaultCellStyle = dataGridViewCellStyle12;
            備考.HeaderText = "備考";
            備考.Name = "備考";
            備考.ReadOnly = true;
            // 
            // 選択不可FLG
            // 
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleLeft;
            選択不可FLG.DefaultCellStyle = dataGridViewCellStyle13;
            選択不可FLG.HeaderText = "選択不可FLG";
            選択不可FLG.Name = "選択不可FLG";
            選択不可FLG.ReadOnly = true;
            // 
            // 前回請求締年月日
            // 
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            前回請求締年月日.DefaultCellStyle = dataGridViewCellStyle14;
            前回請求締年月日.HeaderText = "前回請求締年月日";
            前回請求締年月日.Name = "前回請求締年月日";
            前回請求締年月日.ReadOnly = true;
            // 
            // SM010
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
            Name = "SM010";
            Text = "SM010【得意先検索】";
            Load += SM010_Load;
            KeyDown += SM010_KeyDown;
            GB_処理区分.ResumeLayout(false);
            GB_処理区分.PerformLayout();
            GB_登録内容.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DG1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button B_Key12;
        private GroupBox GB_処理区分;
        private GroupBox GB_登録内容;
        private GroupBox groupBox1;
        private Button B_Key03;
        private Button B_Key01;
        private Label 締日;
        private TextBox G_得意先名;
        private DataGridView DG1;
        private TextBox G_得意先CD;
        private TextBox G_商品CD;
        private TextBox G_商品名;
        private Label L_商品;
        private TextBox G_売上NO1;
        private Label L_売上NO;
        private Label L_得意先名;
        private Label label2;
        private TextBox G_売上NO2;
        private Label L_売上日;
        private TextBox G_売上日2;
        private TextBox G_売上日1;
        private Label label1;
        private DataGridViewTextBoxColumn 得意先CD;
        private DataGridViewTextBoxColumn 得意先名;
        private DataGridViewTextBoxColumn 郵便番号;
        private DataGridViewTextBoxColumn 住所1;
        private DataGridViewTextBoxColumn 住所2;
        private DataGridViewTextBoxColumn TEL1;
        private DataGridViewTextBoxColumn TEL2;
        private DataGridViewTextBoxColumn FAX;
        private DataGridViewTextBoxColumn MAIL;
        private DataGridViewTextBoxColumn 担当者名;
        private DataGridViewTextBoxColumn 備考;
        private DataGridViewTextBoxColumn 選択不可FLG;
        private DataGridViewTextBoxColumn 前回請求締年月日;
    }
}
