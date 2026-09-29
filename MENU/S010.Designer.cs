namespace customerApp
{
    partial class S010
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            L_処理区分 = new Label();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            G_締日 = new TextBox();
            C_処理区分 = new ComboBox();
            label1 = new Label();
            L_請求締年月日 = new Label();
            D_請求締年月日 = new DateTimePicker();
            締日 = new Label();
            GB_登録内容 = new GroupBox();
            DG1 = new DataGridView();
            groupBox1 = new GroupBox();
            B_Key03 = new Button();
            B_Key01 = new Button();
            対象 = new DataGridViewCheckBoxColumn();
            請求先CD = new DataGridViewTextBoxColumn();
            請求先名 = new DataGridViewTextBoxColumn();
            税抜売上金額 = new DataGridViewTextBoxColumn();
            消費税額 = new DataGridViewTextBoxColumn();
            税込売上金額 = new DataGridViewTextBoxColumn();
            前回請求締年月日 = new DataGridViewTextBoxColumn();
            GB_処理区分.SuspendLayout();
            GB_登録内容.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DG1).BeginInit();
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
            L_処理区分.Size = new Size(100, 25);
            L_処理区分.TabIndex = 0;
            L_処理区分.Text = "処理区分";
            L_処理区分.TextAlign = ContentAlignment.MiddleCenter;
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
            GB_処理区分.Controls.Add(G_締日);
            GB_処理区分.Controls.Add(C_処理区分);
            GB_処理区分.Controls.Add(label1);
            GB_処理区分.Controls.Add(L_請求締年月日);
            GB_処理区分.Controls.Add(D_請求締年月日);
            GB_処理区分.Controls.Add(締日);
            GB_処理区分.Controls.Add(L_処理区分);
            GB_処理区分.Location = new Point(5, -2);
            GB_処理区分.Name = "GB_処理区分";
            GB_処理区分.Size = new Size(874, 103);
            GB_処理区分.TabIndex = 1;
            GB_処理区分.TabStop = false;
            // 
            // G_締日
            // 
            G_締日.BackColor = Color.FromArgb(255, 255, 192);
            G_締日.BorderStyle = BorderStyle.FixedSingle;
            G_締日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_締日.ImeMode = ImeMode.Disable;
            G_締日.Location = new Point(129, 43);
            G_締日.MaximumSize = new Size(300, 25);
            G_締日.MaxLength = 8;
            G_締日.MinimumSize = new Size(20, 25);
            G_締日.Name = "G_締日";
            G_締日.ReadOnly = true;
            G_締日.Size = new Size(30, 25);
            G_締日.TabIndex = 3;
            G_締日.TabStop = false;
            G_締日.TextAlign = HorizontalAlignment.Right;
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
            C_処理区分.Items.AddRange(new object[] { "1:集計", "2:取消" });
            C_処理区分.Location = new Point(131, 19);
            C_処理区分.Name = "C_処理区分";
            C_処理区分.Size = new Size(73, 25);
            C_処理区分.TabIndex = 1;
            C_処理区分.SelectedIndexChanged += C_処理区分_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(268, 77);
            label1.Name = "label1";
            label1.Size = new Size(268, 15);
            label1.TabIndex = 22;
            label1.Text = "※本システムにおいて、締日は31日(月末日)固定とする";
            // 
            // L_請求締年月日
            // 
            L_請求締年月日.BackColor = SystemColors.ControlDark;
            L_請求締年月日.BorderStyle = BorderStyle.FixedSingle;
            L_請求締年月日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_請求締年月日.Location = new Point(30, 67);
            L_請求締年月日.Margin = new Padding(0);
            L_請求締年月日.MinimumSize = new Size(50, 25);
            L_請求締年月日.Name = "L_請求締年月日";
            L_請求締年月日.Size = new Size(100, 25);
            L_請求締年月日.TabIndex = 4;
            L_請求締年月日.Text = "請求締年月日";
            L_請求締年月日.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // D_請求締年月日
            // 
            D_請求締年月日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            D_請求締年月日.Location = new Point(129, 67);
            D_請求締年月日.Name = "D_請求締年月日";
            D_請求締年月日.Size = new Size(133, 25);
            D_請求締年月日.TabIndex = 5;
            // 
            // 締日
            // 
            締日.BackColor = SystemColors.ControlDark;
            締日.BorderStyle = BorderStyle.FixedSingle;
            締日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            締日.Location = new Point(30, 43);
            締日.Margin = new Padding(0);
            締日.MinimumSize = new Size(50, 25);
            締日.Name = "締日";
            締日.Size = new Size(100, 25);
            締日.TabIndex = 2;
            締日.Text = "締日";
            締日.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GB_登録内容
            // 
            GB_登録内容.Controls.Add(DG1);
            GB_登録内容.Location = new Point(5, 96);
            GB_登録内容.Name = "GB_登録内容";
            GB_登録内容.Size = new Size(874, 391);
            GB_登録内容.TabIndex = 2;
            GB_登録内容.TabStop = false;
            // 
            // DG1
            // 
            DG1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new Padding(15, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DG1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DG1.ColumnHeadersHeight = 25;
            DG1.Columns.AddRange(new DataGridViewColumn[] { 対象, 請求先CD, 請求先名, 税抜売上金額, 消費税額, 税込売上金額, 前回請求締年月日 });
            DG1.EnableHeadersVisualStyles = false;
            DG1.Location = new Point(7, 18);
            DG1.Name = "DG1";
            DG1.RowHeadersVisible = false;
            DG1.Size = new Size(860, 362);
            DG1.TabIndex = 0;
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
            // 対象
            // 
            対象.HeaderText = "対象";
            対象.Name = "対象";
            対象.Width = 40;
            // 
            // 請求先CD
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Padding = new Padding(10, 0, 0, 0);
            請求先CD.DefaultCellStyle = dataGridViewCellStyle2;
            請求先CD.HeaderText = "請求先CD";
            請求先CD.Name = "請求先CD";
            請求先CD.ReadOnly = true;
            // 
            // 請求先名
            // 
            請求先名.HeaderText = "請求先名";
            請求先名.Name = "請求先名";
            請求先名.ReadOnly = true;
            請求先名.Width = 130;
            // 
            // 税抜売上金額
            // 
            税抜売上金額.HeaderText = "税抜売上金額";
            税抜売上金額.Name = "税抜売上金額";
            税抜売上金額.ReadOnly = true;
            税抜売上金額.Width = 120;
            // 
            // 消費税額
            // 
            消費税額.HeaderText = "消費税額";
            消費税額.Name = "消費税額";
            消費税額.ReadOnly = true;
            消費税額.Width = 120;
            // 
            // 税込売上金額
            // 
            税込売上金額.HeaderText = "税込売上金額";
            税込売上金額.Name = "税込売上金額";
            税込売上金額.ReadOnly = true;
            税込売上金額.Width = 120;
            // 
            // 前回請求締年月日
            // 
            前回請求締年月日.HeaderText = "前回請求締年月日";
            前回請求締年月日.Name = "前回請求締年月日";
            // 
            // S010
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
            Name = "S010";
            Text = "S010【請求集計処理】";
            Load += S010_Load;
            KeyDown += S010_KeyDown;
            GB_処理区分.ResumeLayout(false);
            GB_処理区分.PerformLayout();
            GB_登録内容.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DG1).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label L_処理区分;
        private Button B_Key12;
        private GroupBox GB_処理区分;
        private ComboBox C_処理区分;
        private GroupBox GB_登録内容;
        private GroupBox groupBox1;
        private Button B_Key03;
        private Button B_Key01;
        private Label 締日;
        private TextBox G_締日;
        private Label L_請求締年月日;
        private DateTimePicker D_請求締年月日;
        private DataGridView DG1;
        private Label label1;
        private DataGridViewCheckBoxColumn 対象;
        private DataGridViewTextBoxColumn 請求先CD;
        private DataGridViewTextBoxColumn 請求先名;
        private DataGridViewTextBoxColumn 税抜売上金額;
        private DataGridViewTextBoxColumn 消費税額;
        private DataGridViewTextBoxColumn 税込売上金額;
        private DataGridViewTextBoxColumn 前回請求締年月日;
    }
}
