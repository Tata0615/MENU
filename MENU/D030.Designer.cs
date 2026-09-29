namespace customerApp
{
    partial class D030
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            L_処理区分 = new Label();
            G_得意先CD = new TextBox();
            B_Key12 = new Button();
            GB_処理区分 = new GroupBox();
            L_見積NO = new Label();
            G_見積NO = new TextBox();
            L_受注NO = new Label();
            G_受注NO = new TextBox();
            L_売上NO = new Label();
            G_売上NO = new TextBox();
            C_処理区分 = new ComboBox();
            L_得意先 = new Label();
            O_得意先名 = new TextBox();
            L_得意先担当 = new Label();
            G_得意先担当 = new TextBox();
            GB_ヘッダー = new GroupBox();
            D_請求計上日 = new DateTimePicker();
            D_売上日 = new DateTimePicker();
            G_備考3 = new TextBox();
            G_備考2 = new TextBox();
            G_備考1 = new TextBox();
            O_納品書種類 = new TextBox();
            G_納品書種類 = new TextBox();
            L_即伝区分 = new Label();
            C_即伝区分 = new ComboBox();
            L_納品書種類 = new Label();
            L_条件 = new Label();
            G_条件 = new TextBox();
            G_担当者CD = new TextBox();
            L_請求計上日 = new Label();
            L_売上日 = new Label();
            L_備考 = new Label();
            L_注文番号 = new Label();
            G_注文番号 = new TextBox();
            L_件名 = new Label();
            G_件名 = new TextBox();
            L_担当者 = new Label();
            O_担当者名 = new TextBox();
            groupBox1 = new GroupBox();
            B_Key04 = new Button();
            B_Key03 = new Button();
            B_Key01 = new Button();
            groupBox2 = new GroupBox();
            L_注釈1 = new Label();
            L_フッター売上金額 = new Label();
            O_フッター売上金額 = new TextBox();
            L_売上消費税 = new Label();
            O_売上消費税 = new TextBox();
            L_合計売上金額 = new Label();
            O_合計売上金額 = new TextBox();
            DG1 = new DataGridView();
            商品CD = new DataGridViewTextBoxColumn();
            商品名 = new DataGridViewTextBoxColumn();
            税率 = new DataGridViewTextBoxColumn();
            数量 = new DataGridViewTextBoxColumn();
            単位 = new DataGridViewTextBoxColumn();
            売上単価 = new DataGridViewTextBoxColumn();
            売上金額 = new DataGridViewTextBoxColumn();
            明細備考 = new DataGridViewTextBoxColumn();
            完納 = new DataGridViewCheckBoxColumn();
            見積ID = new DataGridViewTextBoxColumn();
            見積NO = new DataGridViewTextBoxColumn();
            受注ID = new DataGridViewTextBoxColumn();
            受注NO = new DataGridViewTextBoxColumn();
            売上ID = new DataGridViewTextBoxColumn();
            売上単価税抜 = new DataGridViewTextBoxColumn();
            売上単価消費税 = new DataGridViewTextBoxColumn();
            売上金額税抜 = new DataGridViewTextBoxColumn();
            GB_処理区分.SuspendLayout();
            GB_ヘッダー.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DG1).BeginInit();
            SuspendLayout();
            // 
            // L_処理区分
            // 
            L_処理区分.BackColor = SystemColors.ControlDark;
            L_処理区分.BorderStyle = BorderStyle.FixedSingle;
            L_処理区分.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_処理区分.Location = new Point(30, 15);
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
            G_得意先CD.TabIndex = 5;
            G_得意先CD.Click += TextBox_Click;
            G_得意先CD.Enter += TextBox_Enter;
            G_得意先CD.KeyPress += G_得意先CD_KeyPress;
            G_得意先CD.Leave += TextBox_Leave;
            G_得意先CD.Validating += G_得意先CD_Validating;
            // 
            // B_Key12
            // 
            B_Key12.BackColor = Color.White;
            B_Key12.Location = new Point(864, 13);
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
            GB_処理区分.Controls.Add(L_見積NO);
            GB_処理区分.Controls.Add(G_見積NO);
            GB_処理区分.Controls.Add(L_受注NO);
            GB_処理区分.Controls.Add(G_受注NO);
            GB_処理区分.Controls.Add(L_売上NO);
            GB_処理区分.Controls.Add(G_売上NO);
            GB_処理区分.Controls.Add(L_処理区分);
            GB_処理区分.Controls.Add(C_処理区分);
            GB_処理区分.Location = new Point(5, -2);
            GB_処理区分.Name = "GB_処理区分";
            GB_処理区分.Size = new Size(975, 49);
            GB_処理区分.TabIndex = 1;
            GB_処理区分.TabStop = false;
            // 
            // L_見積NO
            // 
            L_見積NO.BackColor = SystemColors.ControlDark;
            L_見積NO.BorderStyle = BorderStyle.FixedSingle;
            L_見積NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_見積NO.Location = new Point(366, 15);
            L_見積NO.Margin = new Padding(0);
            L_見積NO.MinimumSize = new Size(50, 25);
            L_見積NO.Name = "L_見積NO";
            L_見積NO.Size = new Size(80, 25);
            L_見積NO.TabIndex = 24;
            L_見積NO.Text = "見積NO";
            L_見積NO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_見積NO
            // 
            G_見積NO.BackColor = Color.White;
            G_見積NO.BorderStyle = BorderStyle.FixedSingle;
            G_見積NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_見積NO.ImeMode = ImeMode.Disable;
            G_見積NO.Location = new Point(445, 15);
            G_見積NO.MaximumSize = new Size(300, 25);
            G_見積NO.MaxLength = 20;
            G_見積NO.MinimumSize = new Size(65, 25);
            G_見積NO.Name = "G_見積NO";
            G_見積NO.Size = new Size(67, 25);
            G_見積NO.TabIndex = 25;
            // 
            // L_受注NO
            // 
            L_受注NO.BackColor = SystemColors.ControlDark;
            L_受注NO.BorderStyle = BorderStyle.FixedSingle;
            L_受注NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_受注NO.Location = new Point(528, 15);
            L_受注NO.Margin = new Padding(0);
            L_受注NO.MinimumSize = new Size(50, 25);
            L_受注NO.Name = "L_受注NO";
            L_受注NO.Size = new Size(80, 25);
            L_受注NO.TabIndex = 22;
            L_受注NO.Text = "受注NO";
            L_受注NO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_受注NO
            // 
            G_受注NO.BackColor = Color.White;
            G_受注NO.BorderStyle = BorderStyle.FixedSingle;
            G_受注NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_受注NO.ImeMode = ImeMode.Disable;
            G_受注NO.Location = new Point(607, 15);
            G_受注NO.MaximumSize = new Size(300, 25);
            G_受注NO.MaxLength = 20;
            G_受注NO.MinimumSize = new Size(65, 25);
            G_受注NO.Name = "G_受注NO";
            G_受注NO.Size = new Size(67, 25);
            G_受注NO.TabIndex = 23;
            // 
            // L_売上NO
            // 
            L_売上NO.BackColor = SystemColors.ControlDark;
            L_売上NO.BorderStyle = BorderStyle.FixedSingle;
            L_売上NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_売上NO.Location = new Point(202, 15);
            L_売上NO.Margin = new Padding(0);
            L_売上NO.MinimumSize = new Size(50, 25);
            L_売上NO.Name = "L_売上NO";
            L_売上NO.Size = new Size(80, 25);
            L_売上NO.TabIndex = 20;
            L_売上NO.Text = "売上NO";
            L_売上NO.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_売上NO
            // 
            G_売上NO.BackColor = Color.White;
            G_売上NO.BorderStyle = BorderStyle.FixedSingle;
            G_売上NO.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_売上NO.ImeMode = ImeMode.Disable;
            G_売上NO.Location = new Point(281, 15);
            G_売上NO.MaximumSize = new Size(300, 25);
            G_売上NO.MaxLength = 20;
            G_売上NO.MinimumSize = new Size(65, 25);
            G_売上NO.Name = "G_売上NO";
            G_売上NO.Size = new Size(67, 25);
            G_売上NO.TabIndex = 21;
            G_売上NO.Enter += TextBox_Enter;
            G_売上NO.Leave += TextBox_Leave;
            G_売上NO.Validating += G_売上NO_Validating;
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
            C_処理区分.Location = new Point(111, 15);
            C_処理区分.Name = "C_処理区分";
            C_処理区分.Size = new Size(73, 25);
            C_処理区分.TabIndex = 1;
            C_処理区分.SelectedIndexChanged += C_処理区分_SelectedIndexChanged;
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
            L_得意先.TabIndex = 4;
            L_得意先.Text = "得意先";
            L_得意先.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_得意先名
            // 
            O_得意先名.BackColor = Color.FromArgb(255, 255, 192);
            O_得意先名.BorderStyle = BorderStyle.FixedSingle;
            O_得意先名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_得意先名.Location = new Point(183, 43);
            O_得意先名.MaximumSize = new Size(500, 25);
            O_得意先名.MaxLength = 60;
            O_得意先名.MinimumSize = new Size(65, 25);
            O_得意先名.Name = "O_得意先名";
            O_得意先名.ReadOnly = true;
            O_得意先名.Size = new Size(270, 25);
            O_得意先名.TabIndex = 6;
            O_得意先名.TabStop = false;
            // 
            // L_得意先担当
            // 
            L_得意先担当.BackColor = SystemColors.ControlDark;
            L_得意先担当.BorderStyle = BorderStyle.FixedSingle;
            L_得意先担当.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_得意先担当.Location = new Point(30, 67);
            L_得意先担当.Margin = new Padding(0);
            L_得意先担当.MinimumSize = new Size(50, 25);
            L_得意先担当.Name = "L_得意先担当";
            L_得意先担当.Size = new Size(80, 25);
            L_得意先担当.TabIndex = 7;
            L_得意先担当.Text = "得意先担当";
            L_得意先担当.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_得意先担当
            // 
            G_得意先担当.BackColor = Color.White;
            G_得意先担当.BorderStyle = BorderStyle.FixedSingle;
            G_得意先担当.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_得意先担当.ImeMode = ImeMode.Hiragana;
            G_得意先担当.Location = new Point(109, 67);
            G_得意先担当.MaximumSize = new Size(500, 25);
            G_得意先担当.MaxLength = 60;
            G_得意先担当.MinimumSize = new Size(65, 25);
            G_得意先担当.Name = "G_得意先担当";
            G_得意先担当.Size = new Size(344, 25);
            G_得意先担当.TabIndex = 8;
            G_得意先担当.Click += TextBox_Click;
            G_得意先担当.Enter += TextBox_Enter;
            G_得意先担当.Leave += TextBox_Leave;
            // 
            // GB_ヘッダー
            // 
            GB_ヘッダー.Controls.Add(G_得意先CD);
            GB_ヘッダー.Controls.Add(O_得意先名);
            GB_ヘッダー.Controls.Add(D_請求計上日);
            GB_ヘッダー.Controls.Add(D_売上日);
            GB_ヘッダー.Controls.Add(G_備考3);
            GB_ヘッダー.Controls.Add(G_備考2);
            GB_ヘッダー.Controls.Add(G_備考1);
            GB_ヘッダー.Controls.Add(O_納品書種類);
            GB_ヘッダー.Controls.Add(G_納品書種類);
            GB_ヘッダー.Controls.Add(L_即伝区分);
            GB_ヘッダー.Controls.Add(C_即伝区分);
            GB_ヘッダー.Controls.Add(L_納品書種類);
            GB_ヘッダー.Controls.Add(L_条件);
            GB_ヘッダー.Controls.Add(G_条件);
            GB_ヘッダー.Controls.Add(G_担当者CD);
            GB_ヘッダー.Controls.Add(L_請求計上日);
            GB_ヘッダー.Controls.Add(L_売上日);
            GB_ヘッダー.Controls.Add(L_備考);
            GB_ヘッダー.Controls.Add(L_得意先);
            GB_ヘッダー.Controls.Add(L_注文番号);
            GB_ヘッダー.Controls.Add(G_注文番号);
            GB_ヘッダー.Controls.Add(L_件名);
            GB_ヘッダー.Controls.Add(G_件名);
            GB_ヘッダー.Controls.Add(L_担当者);
            GB_ヘッダー.Controls.Add(O_担当者名);
            GB_ヘッダー.Controls.Add(L_得意先担当);
            GB_ヘッダー.Controls.Add(G_得意先担当);
            GB_ヘッダー.Location = new Point(5, 41);
            GB_ヘッダー.Name = "GB_ヘッダー";
            GB_ヘッダー.Size = new Size(975, 179);
            GB_ヘッダー.TabIndex = 2;
            GB_ヘッダー.TabStop = false;
            // 
            // D_請求計上日
            // 
            D_請求計上日.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            D_請求計上日.CustomFormat = "yyyy/MM/dd";
            D_請求計上日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            D_請求計上日.Format = DateTimePickerFormat.Custom;
            D_請求計上日.Location = new Point(298, 19);
            D_請求計上日.Name = "D_請求計上日";
            D_請求計上日.Size = new Size(111, 25);
            D_請求計上日.TabIndex = 3;
            D_請求計上日.Value = new DateTime(2026, 9, 1, 0, 0, 0, 0);
            // 
            // D_売上日
            // 
            D_売上日.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            D_売上日.CustomFormat = "yyyy/MM/dd";
            D_売上日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            D_売上日.Format = DateTimePickerFormat.Custom;
            D_売上日.Location = new Point(109, 19);
            D_売上日.Name = "D_売上日";
            D_売上日.Size = new Size(111, 25);
            D_売上日.TabIndex = 1;
            D_売上日.Value = new DateTime(2026, 9, 1, 0, 0, 0, 0);
            // 
            // G_備考3
            // 
            G_備考3.BackColor = Color.White;
            G_備考3.BorderStyle = BorderStyle.FixedSingle;
            G_備考3.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_備考3.ImeMode = ImeMode.Hiragana;
            G_備考3.Location = new Point(581, 139);
            G_備考3.MaximumSize = new Size(500, 50);
            G_備考3.MaxLength = 100;
            G_備考3.MinimumSize = new Size(65, 25);
            G_備考3.Multiline = true;
            G_備考3.Name = "G_備考3";
            G_備考3.Size = new Size(347, 25);
            G_備考3.TabIndex = 26;
            // 
            // G_備考2
            // 
            G_備考2.BackColor = Color.White;
            G_備考2.BorderStyle = BorderStyle.FixedSingle;
            G_備考2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_備考2.ImeMode = ImeMode.Hiragana;
            G_備考2.Location = new Point(581, 115);
            G_備考2.MaximumSize = new Size(500, 50);
            G_備考2.MaxLength = 100;
            G_備考2.MinimumSize = new Size(65, 25);
            G_備考2.Multiline = true;
            G_備考2.Name = "G_備考2";
            G_備考2.Size = new Size(347, 25);
            G_備考2.TabIndex = 25;
            // 
            // G_備考1
            // 
            G_備考1.BackColor = Color.White;
            G_備考1.BorderStyle = BorderStyle.FixedSingle;
            G_備考1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_備考1.ImeMode = ImeMode.Hiragana;
            G_備考1.Location = new Point(581, 91);
            G_備考1.MaximumSize = new Size(500, 50);
            G_備考1.MaxLength = 100;
            G_備考1.MinimumSize = new Size(65, 25);
            G_備考1.Multiline = true;
            G_備考1.Name = "G_備考1";
            G_備考1.Size = new Size(347, 25);
            G_備考1.TabIndex = 24;
            G_備考1.Click += TextBox_Click;
            G_備考1.Enter += TextBox_Enter;
            G_備考1.Leave += TextBox_Leave;
            // 
            // O_納品書種類
            // 
            O_納品書種類.BackColor = Color.FromArgb(255, 255, 192);
            O_納品書種類.BorderStyle = BorderStyle.FixedSingle;
            O_納品書種類.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_納品書種類.ImeMode = ImeMode.Hiragana;
            O_納品書種類.Location = new Point(620, 43);
            O_納品書種類.MaximumSize = new Size(500, 25);
            O_納品書種類.MaxLength = 60;
            O_納品書種類.MinimumSize = new Size(65, 25);
            O_納品書種類.Name = "O_納品書種類";
            O_納品書種類.ReadOnly = true;
            O_納品書種類.Size = new Size(308, 25);
            O_納品書種類.TabIndex = 18;
            O_納品書種類.TabStop = false;
            // 
            // G_納品書種類
            // 
            G_納品書種類.BackColor = Color.FromArgb(255, 255, 192);
            G_納品書種類.BorderStyle = BorderStyle.FixedSingle;
            G_納品書種類.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_納品書種類.Location = new Point(581, 43);
            G_納品書種類.MaximumSize = new Size(100, 25);
            G_納品書種類.MaxLength = 10;
            G_納品書種類.MinimumSize = new Size(40, 25);
            G_納品書種類.Name = "G_納品書種類";
            G_納品書種類.ReadOnly = true;
            G_納品書種類.Size = new Size(40, 25);
            G_納品書種類.TabIndex = 17;
            G_納品書種類.TabStop = false;
            G_納品書種類.TextAlign = HorizontalAlignment.Right;
            // 
            // L_即伝区分
            // 
            L_即伝区分.BackColor = SystemColors.ControlDark;
            L_即伝区分.BorderStyle = BorderStyle.FixedSingle;
            L_即伝区分.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_即伝区分.Location = new Point(690, 67);
            L_即伝区分.Margin = new Padding(0);
            L_即伝区分.MinimumSize = new Size(50, 25);
            L_即伝区分.Name = "L_即伝区分";
            L_即伝区分.Size = new Size(80, 25);
            L_即伝区分.TabIndex = 21;
            L_即伝区分.Text = "即伝区分";
            L_即伝区分.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // C_即伝区分
            // 
            C_即伝区分.BackColor = Color.White;
            C_即伝区分.DropDownStyle = ComboBoxStyle.DropDownList;
            C_即伝区分.FlatStyle = FlatStyle.Flat;
            C_即伝区分.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            C_即伝区分.FormattingEnabled = true;
            C_即伝区分.IntegralHeight = false;
            C_即伝区分.ItemHeight = 17;
            C_即伝区分.Items.AddRange(new object[] { "1:入力時発行", "2:ﾊﾞｯﾁ発行" });
            C_即伝区分.Location = new Point(771, 67);
            C_即伝区分.Name = "C_即伝区分";
            C_即伝区分.Size = new Size(110, 25);
            C_即伝区分.TabIndex = 22;
            // 
            // L_納品書種類
            // 
            L_納品書種類.BackColor = SystemColors.ControlDark;
            L_納品書種類.BorderStyle = BorderStyle.FixedSingle;
            L_納品書種類.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_納品書種類.Location = new Point(502, 43);
            L_納品書種類.Margin = new Padding(0);
            L_納品書種類.MinimumSize = new Size(50, 25);
            L_納品書種類.Name = "L_納品書種類";
            L_納品書種類.Size = new Size(80, 25);
            L_納品書種類.TabIndex = 16;
            L_納品書種類.Text = "納品書種類";
            L_納品書種類.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // L_条件
            // 
            L_条件.BackColor = SystemColors.ControlDark;
            L_条件.BorderStyle = BorderStyle.FixedSingle;
            L_条件.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_条件.Location = new Point(30, 139);
            L_条件.Margin = new Padding(0);
            L_条件.MinimumSize = new Size(50, 25);
            L_条件.Name = "L_条件";
            L_条件.Size = new Size(80, 25);
            L_条件.TabIndex = 14;
            L_条件.Text = "条件";
            L_条件.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_条件
            // 
            G_条件.BackColor = Color.White;
            G_条件.BorderStyle = BorderStyle.FixedSingle;
            G_条件.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_条件.ImeMode = ImeMode.Hiragana;
            G_条件.Location = new Point(109, 139);
            G_条件.MaximumSize = new Size(500, 25);
            G_条件.MaxLength = 60;
            G_条件.MinimumSize = new Size(65, 25);
            G_条件.Name = "G_条件";
            G_条件.Size = new Size(344, 25);
            G_条件.TabIndex = 15;
            // 
            // G_担当者CD
            // 
            G_担当者CD.BackColor = Color.White;
            G_担当者CD.BorderStyle = BorderStyle.FixedSingle;
            G_担当者CD.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_担当者CD.Location = new Point(109, 91);
            G_担当者CD.MaximumSize = new Size(100, 25);
            G_担当者CD.MaxLength = 10;
            G_担当者CD.MinimumSize = new Size(65, 25);
            G_担当者CD.Name = "G_担当者CD";
            G_担当者CD.Size = new Size(75, 25);
            G_担当者CD.TabIndex = 10;
            G_担当者CD.TextAlign = HorizontalAlignment.Right;
            G_担当者CD.Enter += TextBox_Enter;
            G_担当者CD.KeyPress += G_担当者CD_KeyPress;
            G_担当者CD.Validating += G_担当者CD_Validating;
            // 
            // L_請求計上日
            // 
            L_請求計上日.BackColor = SystemColors.ControlDark;
            L_請求計上日.BorderStyle = BorderStyle.FixedSingle;
            L_請求計上日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_請求計上日.Location = new Point(219, 19);
            L_請求計上日.Margin = new Padding(0);
            L_請求計上日.MinimumSize = new Size(50, 25);
            L_請求計上日.Name = "L_請求計上日";
            L_請求計上日.Size = new Size(80, 25);
            L_請求計上日.TabIndex = 2;
            L_請求計上日.Text = "請求計上日";
            L_請求計上日.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // L_売上日
            // 
            L_売上日.BackColor = SystemColors.ControlDark;
            L_売上日.BorderStyle = BorderStyle.FixedSingle;
            L_売上日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_売上日.Location = new Point(30, 19);
            L_売上日.Margin = new Padding(0);
            L_売上日.MinimumSize = new Size(50, 25);
            L_売上日.Name = "L_売上日";
            L_売上日.Size = new Size(80, 25);
            L_売上日.TabIndex = 0;
            L_売上日.Text = "売上日";
            L_売上日.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // L_備考
            // 
            L_備考.BackColor = SystemColors.ControlDark;
            L_備考.BorderStyle = BorderStyle.FixedSingle;
            L_備考.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_備考.Location = new Point(502, 91);
            L_備考.Margin = new Padding(0);
            L_備考.MinimumSize = new Size(50, 25);
            L_備考.Name = "L_備考";
            L_備考.Size = new Size(80, 73);
            L_備考.TabIndex = 23;
            L_備考.Text = "備考";
            L_備考.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // L_注文番号
            // 
            L_注文番号.BackColor = SystemColors.ControlDark;
            L_注文番号.BorderStyle = BorderStyle.FixedSingle;
            L_注文番号.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_注文番号.Location = new Point(502, 67);
            L_注文番号.Margin = new Padding(0);
            L_注文番号.MinimumSize = new Size(50, 25);
            L_注文番号.Name = "L_注文番号";
            L_注文番号.Size = new Size(80, 25);
            L_注文番号.TabIndex = 19;
            L_注文番号.Text = "注文番号";
            L_注文番号.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_注文番号
            // 
            G_注文番号.BackColor = Color.White;
            G_注文番号.BorderStyle = BorderStyle.FixedSingle;
            G_注文番号.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_注文番号.ImeMode = ImeMode.Disable;
            G_注文番号.Location = new Point(581, 67);
            G_注文番号.MaximumSize = new Size(300, 25);
            G_注文番号.MaxLength = 15;
            G_注文番号.MinimumSize = new Size(65, 25);
            G_注文番号.Name = "G_注文番号";
            G_注文番号.Size = new Size(110, 25);
            G_注文番号.TabIndex = 20;
            G_注文番号.Click += TextBox_Click;
            G_注文番号.Enter += TextBox_Enter;
            G_注文番号.Leave += TextBox_Leave;
            // 
            // L_件名
            // 
            L_件名.BackColor = SystemColors.ControlDark;
            L_件名.BorderStyle = BorderStyle.FixedSingle;
            L_件名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_件名.Location = new Point(30, 115);
            L_件名.Margin = new Padding(0);
            L_件名.MinimumSize = new Size(50, 25);
            L_件名.Name = "L_件名";
            L_件名.Size = new Size(80, 25);
            L_件名.TabIndex = 12;
            L_件名.Text = "件名";
            L_件名.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // G_件名
            // 
            G_件名.BackColor = Color.White;
            G_件名.BorderStyle = BorderStyle.FixedSingle;
            G_件名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            G_件名.ImeMode = ImeMode.Hiragana;
            G_件名.Location = new Point(109, 115);
            G_件名.MaximumSize = new Size(500, 25);
            G_件名.MaxLength = 60;
            G_件名.MinimumSize = new Size(65, 25);
            G_件名.Name = "G_件名";
            G_件名.Size = new Size(344, 25);
            G_件名.TabIndex = 13;
            G_件名.Click += TextBox_Click;
            G_件名.Enter += TextBox_Enter;
            G_件名.Leave += TextBox_Leave;
            // 
            // L_担当者
            // 
            L_担当者.BackColor = SystemColors.ControlDark;
            L_担当者.BorderStyle = BorderStyle.FixedSingle;
            L_担当者.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_担当者.Location = new Point(30, 91);
            L_担当者.Margin = new Padding(0);
            L_担当者.MinimumSize = new Size(50, 25);
            L_担当者.Name = "L_担当者";
            L_担当者.Size = new Size(80, 25);
            L_担当者.TabIndex = 9;
            L_担当者.Text = "担当者";
            L_担当者.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_担当者名
            // 
            O_担当者名.BackColor = Color.FromArgb(255, 255, 192);
            O_担当者名.BorderStyle = BorderStyle.FixedSingle;
            O_担当者名.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_担当者名.ImeMode = ImeMode.Hiragana;
            O_担当者名.Location = new Point(183, 91);
            O_担当者名.MaximumSize = new Size(500, 25);
            O_担当者名.MaxLength = 60;
            O_担当者名.MinimumSize = new Size(65, 25);
            O_担当者名.Name = "O_担当者名";
            O_担当者名.ReadOnly = true;
            O_担当者名.Size = new Size(270, 25);
            O_担当者名.TabIndex = 11;
            O_担当者名.TabStop = false;
            O_担当者名.Click += TextBox_Click;
            O_担当者名.Enter += TextBox_Enter;
            O_担当者名.Leave += TextBox_Leave;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(B_Key04);
            groupBox1.Controls.Add(B_Key03);
            groupBox1.Controls.Add(B_Key01);
            groupBox1.Controls.Add(B_Key12);
            groupBox1.Location = new Point(5, 603);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(975, 55);
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
            // groupBox2
            // 
            groupBox2.Controls.Add(L_注釈1);
            groupBox2.Controls.Add(L_フッター売上金額);
            groupBox2.Controls.Add(O_フッター売上金額);
            groupBox2.Controls.Add(L_売上消費税);
            groupBox2.Controls.Add(O_売上消費税);
            groupBox2.Controls.Add(L_合計売上金額);
            groupBox2.Controls.Add(O_合計売上金額);
            groupBox2.Controls.Add(DG1);
            groupBox2.Location = new Point(5, 214);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(975, 395);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            // 
            // L_注釈1
            // 
            L_注釈1.AutoSize = true;
            L_注釈1.Location = new Point(5, 372);
            L_注釈1.Name = "L_注釈1";
            L_注釈1.Size = new Size(456, 15);
            L_注釈1.TabIndex = 32;
            L_注釈1.Text = "※本システムの消費税は、伝票単位でまとめて算出するものとする。(小数点第1位を四捨五入)";
            // 
            // L_フッター売上金額
            // 
            L_フッター売上金額.BackColor = SystemColors.ControlDark;
            L_フッター売上金額.BorderStyle = BorderStyle.FixedSingle;
            L_フッター売上金額.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_フッター売上金額.Location = new Point(616, 338);
            L_フッター売上金額.Margin = new Padding(0);
            L_フッター売上金額.MinimumSize = new Size(50, 25);
            L_フッター売上金額.Name = "L_フッター売上金額";
            L_フッター売上金額.Size = new Size(118, 25);
            L_フッター売上金額.TabIndex = 31;
            L_フッター売上金額.Text = "売上金額";
            L_フッター売上金額.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_フッター売上金額
            // 
            O_フッター売上金額.BackColor = Color.FromArgb(255, 255, 192);
            O_フッター売上金額.BorderStyle = BorderStyle.FixedSingle;
            O_フッター売上金額.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_フッター売上金額.ImeMode = ImeMode.Hiragana;
            O_フッター売上金額.Location = new Point(616, 362);
            O_フッター売上金額.MaximumSize = new Size(500, 25);
            O_フッター売上金額.MaxLength = 60;
            O_フッター売上金額.MinimumSize = new Size(65, 25);
            O_フッター売上金額.Name = "O_フッター売上金額";
            O_フッター売上金額.ReadOnly = true;
            O_フッター売上金額.Size = new Size(118, 25);
            O_フッター売上金額.TabIndex = 30;
            O_フッター売上金額.TabStop = false;
            O_フッター売上金額.TextAlign = HorizontalAlignment.Right;
            // 
            // L_売上消費税
            // 
            L_売上消費税.BackColor = SystemColors.ControlDark;
            L_売上消費税.BorderStyle = BorderStyle.FixedSingle;
            L_売上消費税.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_売上消費税.Location = new Point(733, 338);
            L_売上消費税.Margin = new Padding(0);
            L_売上消費税.MinimumSize = new Size(50, 25);
            L_売上消費税.Name = "L_売上消費税";
            L_売上消費税.Size = new Size(118, 25);
            L_売上消費税.TabIndex = 29;
            L_売上消費税.Text = "売上消費税";
            L_売上消費税.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_売上消費税
            // 
            O_売上消費税.BackColor = Color.FromArgb(255, 255, 192);
            O_売上消費税.BorderStyle = BorderStyle.FixedSingle;
            O_売上消費税.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_売上消費税.ImeMode = ImeMode.Hiragana;
            O_売上消費税.Location = new Point(733, 362);
            O_売上消費税.MaximumSize = new Size(500, 25);
            O_売上消費税.MaxLength = 60;
            O_売上消費税.MinimumSize = new Size(65, 25);
            O_売上消費税.Name = "O_売上消費税";
            O_売上消費税.ReadOnly = true;
            O_売上消費税.Size = new Size(118, 25);
            O_売上消費税.TabIndex = 28;
            O_売上消費税.TabStop = false;
            O_売上消費税.TextAlign = HorizontalAlignment.Right;
            // 
            // L_合計売上金額
            // 
            L_合計売上金額.BackColor = SystemColors.ControlDark;
            L_合計売上金額.BorderStyle = BorderStyle.FixedSingle;
            L_合計売上金額.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_合計売上金額.Location = new Point(850, 338);
            L_合計売上金額.Margin = new Padding(0);
            L_合計売上金額.MinimumSize = new Size(50, 25);
            L_合計売上金額.Name = "L_合計売上金額";
            L_合計売上金額.Size = new Size(118, 25);
            L_合計売上金額.TabIndex = 27;
            L_合計売上金額.Text = "合計売上金額";
            L_合計売上金額.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // O_合計売上金額
            // 
            O_合計売上金額.BackColor = Color.FromArgb(255, 255, 192);
            O_合計売上金額.BorderStyle = BorderStyle.FixedSingle;
            O_合計売上金額.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            O_合計売上金額.ImeMode = ImeMode.Hiragana;
            O_合計売上金額.Location = new Point(850, 362);
            O_合計売上金額.MaximumSize = new Size(500, 25);
            O_合計売上金額.MaxLength = 60;
            O_合計売上金額.MinimumSize = new Size(65, 25);
            O_合計売上金額.Name = "O_合計売上金額";
            O_合計売上金額.ReadOnly = true;
            O_合計売上金額.Size = new Size(118, 25);
            O_合計売上金額.TabIndex = 16;
            O_合計売上金額.TabStop = false;
            O_合計売上金額.TextAlign = HorizontalAlignment.Right;
            // 
            // DG1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonShadow;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DG1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DG1.Columns.AddRange(new DataGridViewColumn[] { 商品CD, 商品名, 税率, 数量, 単位, 売上単価, 売上金額, 明細備考, 完納, 見積ID, 見積NO, 受注ID, 受注NO, 売上ID, 売上単価税抜, 売上単価消費税, 売上金額税抜 });
            DG1.EnableHeadersVisualStyles = false;
            DG1.Location = new Point(5, 12);
            DG1.Name = "DG1";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.White;
            dataGridViewCellStyle9.Font = new Font("Yu Gothic UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            DG1.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            DG1.RowHeadersVisible = false;
            DG1.Size = new Size(963, 320);
            DG1.TabIndex = 0;
            DG1.CellEndEdit += DG1_CellEndEdit;
            DG1.CellEnter += DG1_CellEnter;
            DG1.EditingControlShowing += DG1_EditingControlShowing;
            DG1.KeyPress += NumberOnly_KeyPress;
            DG1.Leave += DG1_Leave;
            // 
            // 商品CD
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleRight;
            商品CD.DefaultCellStyle = dataGridViewCellStyle2;
            商品CD.HeaderText = "商品CD";
            商品CD.Name = "商品CD";
            // 
            // 商品名
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            商品名.DefaultCellStyle = dataGridViewCellStyle3;
            商品名.HeaderText = "商品名";
            商品名.Name = "商品名";
            商品名.ReadOnly = true;
            商品名.Width = 210;
            // 
            // 税率
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(255, 255, 192);
            税率.DefaultCellStyle = dataGridViewCellStyle4;
            税率.HeaderText = "税率";
            税率.Name = "税率";
            税率.ReadOnly = true;
            // 
            // 数量
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            数量.DefaultCellStyle = dataGridViewCellStyle5;
            数量.HeaderText = "数量";
            数量.Name = "数量";
            数量.Width = 60;
            // 
            // 単位
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            単位.DefaultCellStyle = dataGridViewCellStyle6;
            単位.HeaderText = "単位";
            単位.Name = "単位";
            単位.Width = 60;
            // 
            // 売上単価
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            売上単価.DefaultCellStyle = dataGridViewCellStyle7;
            売上単価.HeaderText = "売上単価";
            売上単価.Name = "売上単価";
            // 
            // 売上金額
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            売上金額.DefaultCellStyle = dataGridViewCellStyle8;
            売上金額.HeaderText = "売上金額";
            売上金額.Name = "売上金額";
            // 
            // 明細備考
            // 
            明細備考.HeaderText = "備考";
            明細備考.Name = "明細備考";
            明細備考.Width = 190;
            // 
            // 完納
            // 
            完納.HeaderText = "完納";
            完納.Name = "完納";
            完納.Width = 40;
            // 
            // 見積ID
            // 
            見積ID.HeaderText = "見積ID";
            見積ID.Name = "見積ID";
            見積ID.Visible = false;
            // 
            // 見積NO
            // 
            見積NO.HeaderText = "見積NO";
            見積NO.Name = "見積NO";
            見積NO.Visible = false;
            // 
            // 受注ID
            // 
            受注ID.HeaderText = "受注ID";
            受注ID.Name = "受注ID";
            受注ID.Visible = false;
            // 
            // 受注NO
            // 
            受注NO.HeaderText = "受注NO";
            受注NO.Name = "受注NO";
            受注NO.Visible = false;
            // 
            // 売上ID
            // 
            売上ID.HeaderText = "売上ID";
            売上ID.Name = "売上ID";
            売上ID.Visible = false;
            // 
            // 売上単価税抜
            // 
            売上単価税抜.HeaderText = "売上単価税抜";
            売上単価税抜.Name = "売上単価税抜";
            売上単価税抜.Visible = false;
            // 
            // 売上単価消費税
            // 
            売上単価消費税.HeaderText = "売上単価消費税";
            売上単価消費税.Name = "売上単価消費税";
            売上単価消費税.Visible = false;
            // 
            // 売上金額税抜
            // 
            売上金額税抜.HeaderText = "売上金額税抜";
            売上金額税抜.Name = "売上金額税抜";
            売上金額税抜.Visible = false;
            // 
            // D030
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(984, 661);
            Controls.Add(GB_処理区分);
            Controls.Add(GB_ヘッダー);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            KeyPreview = true;
            MaximumSize = new Size(1000, 700);
            MinimumSize = new Size(1000, 700);
            Name = "D030";
            Text = "D030【売上入力】";
            Load += D030_Load;
            KeyDown += D030_KeyDown;
            Leave += TextBox_Leave;
            GB_処理区分.ResumeLayout(false);
            GB_処理区分.PerformLayout();
            GB_ヘッダー.ResumeLayout(false);
            GB_ヘッダー.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DG1).EndInit();
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
        private Label L_得意先担当;
        private TextBox G_得意先担当;
        private GroupBox GB_ヘッダー;
        private Label L_郵便番号;
        private TextBox G_郵便番号;
        private Label L_件名;
        private TextBox G_件名;
        private Label L_担当者;
        private TextBox O_担当者名;
        private Label L_注文番号;
        private TextBox G_注文番号;
        private GroupBox groupBox1;
        private Button B_Key03;
        private Button B_Key01;
        private Label L_備考;
        private TextBox G_備考1;
        private Label L_見積NO;
        private TextBox G_見積NO;
        private Label L_受注NO;
        private TextBox G_受注NO;
        private Label L_売上NO;
        private TextBox G_売上NO;
        private Label L_売上日;
        private Label L_請求計上日;
        private TextBox G_担当者CD;
        private Label L_条件;
        private TextBox G_条件;
        private TextBox O_納品書種類;
        private TextBox G_納品書種類;
        private Label L_納品書種類;
        private Label L_即伝区分;
        private ComboBox C_即伝区分;
        private TextBox G_備考3;
        private TextBox G_備考2;
        private GroupBox groupBox2;
        private DateTimePicker D_売上日;
        private DateTimePicker D_請求計上日;
        private DataGridView DG1;
        private Label L_合計売上金額;
        private TextBox O_合計売上金額;
        private Label L_売上消費税;
        private TextBox O_売上消費税;
        private Label L_フッター売上金額;
        private TextBox O_フッター売上金額;
        private Label L_注釈1;
        private DataGridViewTextBoxColumn 商品CD;
        private DataGridViewTextBoxColumn 商品名;
        private DataGridViewTextBoxColumn 税率;
        private DataGridViewTextBoxColumn 数量;
        private DataGridViewTextBoxColumn 単位;
        private DataGridViewTextBoxColumn 売上単価;
        private DataGridViewTextBoxColumn 売上金額;
        private DataGridViewTextBoxColumn 明細備考;
        private DataGridViewCheckBoxColumn 完納;
        private DataGridViewTextBoxColumn 見積ID;
        private DataGridViewTextBoxColumn 見積NO;
        private DataGridViewTextBoxColumn 受注ID;
        private DataGridViewTextBoxColumn 受注NO;
        private DataGridViewTextBoxColumn 売上ID;
        private DataGridViewTextBoxColumn 売上単価税抜;
        private DataGridViewTextBoxColumn 売上単価消費税;
        private DataGridViewTextBoxColumn 売上金額税抜;
        private Button B_Key04;
    }
}
