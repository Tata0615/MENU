namespace customerApp
{
    partial class SM030
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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            G_商品名 = new TextBox();
            L_商品名 = new Label();
            GB_登録内容 = new GroupBox();
            DG1 = new DataGridView();
            商品CD = new DataGridViewTextBoxColumn();
            商品名 = new DataGridViewTextBoxColumn();
            単位名 = new DataGridViewTextBoxColumn();
            消費税率 = new DataGridViewTextBoxColumn();
            単価 = new DataGridViewTextBoxColumn();
            備考 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            B_Key03 = new Button();
            B_Key01 = new Button();
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
            GB_処理区分.Controls.Add(G_商品名);
            GB_処理区分.Controls.Add(L_商品名);
            GB_処理区分.Location = new Point(5, -2);
            GB_処理区分.Name = "GB_処理区分";
            GB_処理区分.Size = new Size(874, 74);
            GB_処理区分.TabIndex = 1;
            GB_処理区分.TabStop = false;
            // 
            // G_商品名
            // 
            G_商品名.BackColor = Color.White;
            G_商品名.BorderStyle = BorderStyle.FixedSingle;
            G_商品名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_商品名.ImeMode = ImeMode.Hiragana;
            G_商品名.Location = new Point(100, 29);
            G_商品名.MaximumSize = new Size(300, 25);
            G_商品名.MaxLength = 8;
            G_商品名.MinimumSize = new Size(20, 25);
            G_商品名.Name = "G_商品名";
            G_商品名.Size = new Size(300, 25);
            G_商品名.TabIndex = 1;
            // 
            // L_商品名
            // 
            L_商品名.BackColor = SystemColors.ControlDark;
            L_商品名.BorderStyle = BorderStyle.FixedSingle;
            L_商品名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_商品名.Location = new Point(21, 29);
            L_商品名.Margin = new Padding(0);
            L_商品名.MinimumSize = new Size(50, 25);
            L_商品名.Name = "L_商品名";
            L_商品名.Size = new Size(80, 25);
            L_商品名.TabIndex = 8;
            L_商品名.Text = "商品名";
            L_商品名.TextAlign = ContentAlignment.MiddleCenter;
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
            DG1.Columns.AddRange(new DataGridViewColumn[] { 商品CD, 商品名, 単位名, 消費税率, 単価, 備考 });
            DG1.EnableHeadersVisualStyles = false;
            DG1.Location = new Point(7, 18);
            DG1.Name = "DG1";
            DG1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            DG1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            DG1.RowHeadersVisible = false;
            DG1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG1.Size = new Size(860, 394);
            DG1.TabIndex = 0;
            DG1.CellContentDoubleClick += DG1_CellDoubleClick;
            // 
            // 商品CD
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            商品CD.DefaultCellStyle = dataGridViewCellStyle2;
            商品CD.HeaderText = "商品CD";
            商品CD.Name = "商品CD";
            商品CD.ReadOnly = true;
            // 
            // 商品名
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            商品名.DefaultCellStyle = dataGridViewCellStyle3;
            商品名.HeaderText = "商品名";
            商品名.Name = "商品名";
            商品名.ReadOnly = true;
            // 
            // 単位名
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            単位名.DefaultCellStyle = dataGridViewCellStyle4;
            単位名.HeaderText = "単位名";
            単位名.Name = "単位名";
            単位名.ReadOnly = true;
            // 
            // 消費税率
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            消費税率.DefaultCellStyle = dataGridViewCellStyle5;
            消費税率.HeaderText = "消費税率";
            消費税率.Name = "消費税率";
            消費税率.ReadOnly = true;
            消費税率.Width = 70;
            // 
            // 単価
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            単価.DefaultCellStyle = dataGridViewCellStyle6;
            単価.HeaderText = "単価";
            単価.Name = "単価";
            単価.ReadOnly = true;
            // 
            // 備考
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            備考.DefaultCellStyle = dataGridViewCellStyle7;
            備考.HeaderText = "備考";
            備考.Name = "備考";
            備考.ReadOnly = true;
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
            // SM030
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
            Name = "SM030";
            Text = "SM030【商品検索】";
            FormClosing += SM030_Closing;
            Load += SM030_Load;
            KeyDown += SM030_KeyDown;
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
        private TextBox G_商品名;
        private DataGridView DG1;
        private TextBox G_得意先CD;
        private TextBox G_商品CD;
        private Label L_商品;
        private TextBox G_売上NO1;
        private Label L_売上NO;
        private Label L_商品名;
        private Label label2;
        private TextBox G_売上NO2;
        private Label L_売上日;
        private TextBox G_売上日2;
        private TextBox G_売上日1;
        private Label label1;
        private DataGridViewTextBoxColumn 商品CD;
        private DataGridViewTextBoxColumn 商品名;
        private DataGridViewTextBoxColumn 単位名;
        private DataGridViewTextBoxColumn 消費税率;
        private DataGridViewTextBoxColumn 単価;
        private DataGridViewTextBoxColumn 備考;
    }
}
