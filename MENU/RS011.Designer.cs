namespace customerApp
{
    partial class RS011
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            H_タイトル = new Label();
            H_請求先名 = new Label();
            H_請求日 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            L_御買上金額ラベル = new Label();
            H_御買上金額 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            L_消費税額ラベル = new Label();
            H_消費税額 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            label4 = new Label();
            H_御請求金額 = new Label();
            H_会社名 = new Label();
            H_自社郵便番号 = new Label();
            H_自社住所1 = new Label();
            H_自社住所2 = new Label();
            label6 = new Label();
            DG1 = new DataGridView();
            日付 = new DataGridViewTextBoxColumn();
            商品CD = new DataGridViewTextBoxColumn();
            商品名 = new DataGridViewTextBoxColumn();
            数量 = new DataGridViewTextBoxColumn();
            単位 = new DataGridViewTextBoxColumn();
            売上単価 = new DataGridViewTextBoxColumn();
            売上金額 = new DataGridViewTextBoxColumn();
            明細備考 = new DataGridViewTextBoxColumn();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DG1).BeginInit();
            SuspendLayout();
            // 
            // H_タイトル
            // 
            H_タイトル.Font = new Font("Yu Gothic UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 128);
            H_タイトル.Location = new Point(12, 9);
            H_タイトル.Name = "H_タイトル";
            H_タイトル.Size = new Size(754, 51);
            H_タイトル.TabIndex = 0;
            H_タイトル.Text = "請　求　書";
            H_タイトル.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // H_請求先名
            // 
            H_請求先名.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_請求先名.Location = new Point(12, 79);
            H_請求先名.Name = "H_請求先名";
            H_請求先名.Size = new Size(373, 38);
            H_請求先名.TabIndex = 1;
            H_請求先名.Text = "請求先名X1XXXXXXXXX2XXXXXXXXX3";
            // 
            // H_請求日
            // 
            H_請求日.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_請求日.Location = new Point(619, 45);
            H_請求日.Name = "H_請求日";
            H_請求日.Size = new Size(147, 38);
            H_請求日.TabIndex = 1;
            H_請求日.Text = "請求日：yyyy/MM/dd";
            H_請求日.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(L_御買上金額ラベル);
            panel1.Controls.Add(H_御買上金額);
            panel1.Location = new Point(12, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(121, 68);
            panel1.TabIndex = 2;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(0, 20);
            label3.Name = "label3";
            label3.Size = new Size(120, 1);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // L_御買上金額ラベル
            // 
            L_御買上金額ラベル.BackColor = Color.Silver;
            L_御買上金額ラベル.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_御買上金額ラベル.Location = new Point(0, 0);
            L_御買上金額ラベル.Name = "L_御買上金額ラベル";
            L_御買上金額ラベル.Size = new Size(120, 21);
            L_御買上金額ラベル.TabIndex = 1;
            L_御買上金額ラベル.Text = "御買上金額";
            L_御買上金額ラベル.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // H_御買上金額
            // 
            H_御買上金額.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_御買上金額.Location = new Point(0, 21);
            H_御買上金額.Name = "H_御買上金額";
            H_御買上金額.Size = new Size(120, 45);
            H_御買上金額.TabIndex = 1;
            H_御買上金額.Text = "999,999,999";
            H_御買上金額.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(L_消費税額ラベル);
            panel2.Controls.Add(H_消費税額);
            panel2.Location = new Point(139, 143);
            panel2.Name = "panel2";
            panel2.Size = new Size(121, 68);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(0, 20);
            label1.Name = "label1";
            label1.Size = new Size(120, 1);
            label1.TabIndex = 3;
            label1.Text = "label3";
            // 
            // L_消費税額ラベル
            // 
            L_消費税額ラベル.BackColor = Color.Silver;
            L_消費税額ラベル.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            L_消費税額ラベル.Location = new Point(0, -1);
            L_消費税額ラベル.Name = "L_消費税額ラベル";
            L_消費税額ラベル.Size = new Size(120, 21);
            L_消費税額ラベル.TabIndex = 1;
            L_消費税額ラベル.Text = "消費税額";
            L_消費税額ラベル.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // H_消費税額
            // 
            H_消費税額.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_消費税額.Location = new Point(0, 21);
            H_消費税額.Name = "H_消費税額";
            H_消費税額.Size = new Size(120, 45);
            H_消費税額.TabIndex = 1;
            H_消費税額.Text = "999,999,999";
            H_消費税額.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(H_御請求金額);
            panel3.Location = new Point(266, 143);
            panel3.Name = "panel3";
            panel3.Size = new Size(121, 68);
            panel3.TabIndex = 2;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(0, 20);
            label2.Name = "label2";
            label2.Size = new Size(120, 1);
            label2.TabIndex = 3;
            label2.Text = "label3";
            // 
            // label4
            // 
            label4.BackColor = Color.Silver;
            label4.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(0, -1);
            label4.Name = "label4";
            label4.Size = new Size(120, 21);
            label4.TabIndex = 1;
            label4.Text = "御請求金額";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // H_御請求金額
            // 
            H_御請求金額.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_御請求金額.Location = new Point(0, 21);
            H_御請求金額.Name = "H_御請求金額";
            H_御請求金額.Size = new Size(120, 45);
            H_御請求金額.TabIndex = 1;
            H_御請求金額.Text = "999,999,999";
            H_御請求金額.TextAlign = ContentAlignment.MiddleRight;
            // 
            // H_会社名
            // 
            H_会社名.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 128);
            H_会社名.Location = new Point(510, 98);
            H_会社名.Name = "H_会社名";
            H_会社名.Size = new Size(147, 38);
            H_会社名.TabIndex = 1;
            H_会社名.Text = "○○株式会社";
            H_会社名.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // H_自社郵便番号
            // 
            H_自社郵便番号.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_自社郵便番号.Location = new Point(510, 131);
            H_自社郵便番号.Name = "H_自社郵便番号";
            H_自社郵便番号.Size = new Size(147, 20);
            H_自社郵便番号.TabIndex = 1;
            H_自社郵便番号.Text = "〒999-9999";
            H_自社郵便番号.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // H_自社住所1
            // 
            H_自社住所1.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_自社住所1.Location = new Point(510, 151);
            H_自社住所1.Name = "H_自社住所1";
            H_自社住所1.Size = new Size(234, 20);
            H_自社住所1.TabIndex = 3;
            H_自社住所1.Text = "静岡県静岡市清水区○○1-2-34";
            H_自社住所1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // H_自社住所2
            // 
            H_自社住所2.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            H_自社住所2.Location = new Point(510, 171);
            H_自社住所2.Name = "H_自社住所2";
            H_自社住所2.Size = new Size(234, 20);
            H_自社住所2.TabIndex = 3;
            H_自社住所2.Text = "静岡ビル1Ｆ";
            H_自社住所2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Yu Gothic UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(510, 191);
            label6.Name = "label6";
            label6.Size = new Size(234, 20);
            label6.TabIndex = 3;
            label6.Text = "TEL:888-8888-8888 FAX:555-5555-5555";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DG1
            // 
            DG1.AllowUserToAddRows = false;
            DG1.AllowUserToDeleteRows = false;
            DG1.AllowUserToResizeColumns = false;
            DG1.AllowUserToResizeRows = false;
            DG1.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DG1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DG1.Columns.AddRange(new DataGridViewColumn[] { 日付, 商品CD, 商品名, 数量, 単位, 売上単価, 売上金額, 明細備考 });
            DG1.EnableHeadersVisualStyles = false;
            DG1.Location = new Point(12, 228);
            DG1.Name = "DG1";
            DG1.ReadOnly = true;
            DG1.RowHeadersVisible = false;
            DG1.RowTemplate.Height = 28;
            DG1.ScrollBars = ScrollBars.None;
            DG1.Size = new Size(754, 809);
            DG1.TabIndex = 4;
            // 
            // 日付
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("MS UI Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            日付.DefaultCellStyle = dataGridViewCellStyle2;
            日付.HeaderText = "日付";
            日付.Name = "日付";
            日付.ReadOnly = true;
            日付.Width = 60;
            // 
            // 商品CD
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleRight;
            商品CD.DefaultCellStyle = dataGridViewCellStyle3;
            商品CD.HeaderText = "商品CD";
            商品CD.Name = "商品CD";
            商品CD.ReadOnly = true;
            // 
            // 商品名
            // 
            商品名.HeaderText = "商品名";
            商品名.Name = "商品名";
            商品名.ReadOnly = true;
            商品名.Width = 171;
            // 
            // 数量
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleRight;
            数量.DefaultCellStyle = dataGridViewCellStyle4;
            数量.HeaderText = "数量";
            数量.Name = "数量";
            数量.ReadOnly = true;
            数量.Width = 80;
            // 
            // 単位
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            単位.DefaultCellStyle = dataGridViewCellStyle5;
            単位.HeaderText = "単位";
            単位.Name = "単位";
            単位.ReadOnly = true;
            単位.Width = 60;
            // 
            // 売上単価
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            売上単価.DefaultCellStyle = dataGridViewCellStyle6;
            売上単価.HeaderText = "売上単価";
            売上単価.Name = "売上単価";
            売上単価.ReadOnly = true;
            売上単価.Width = 80;
            // 
            // 売上金額
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleRight;
            売上金額.DefaultCellStyle = dataGridViewCellStyle7;
            売上金額.HeaderText = "売上金額";
            売上金額.Name = "売上金額";
            売上金額.ReadOnly = true;
            売上金額.Width = 80;
            // 
            // 明細備考
            // 
            明細備考.HeaderText = "明細備考";
            明細備考.Name = "明細備考";
            明細備考.ReadOnly = true;
            明細備考.Width = 120;
            // 
            // label7
            // 
            label7.Font = new Font("Yu Gothic UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(72, 120);
            label7.Name = "label7";
            label7.Size = new Size(320, 20);
            label7.TabIndex = 1;
            label7.Text = "※本システムにおいて、商品の消費税率は一律10%とする。";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // RS011
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(778, 1061);
            Controls.Add(DG1);
            Controls.Add(label6);
            Controls.Add(H_自社住所2);
            Controls.Add(H_自社住所1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(H_会社名);
            Controls.Add(label7);
            Controls.Add(H_自社郵便番号);
            Controls.Add(H_請求日);
            Controls.Add(H_請求先名);
            Controls.Add(H_タイトル);
            Name = "RS011";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "請求書";
            Load += RS011_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DG1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label H_タイトル;
        private Label H_請求先名;
        private Label H_請求日;
        private Panel panel1;
        private Label label3;
        private Label L_御買上金額ラベル;
        private Label H_御買上金額;
        private Panel panel2;
        private Label label1;
        private Label L_消費税額ラベル;
        private Label H_消費税額;
        private Panel panel3;
        private Label label2;
        private Label label4;
        private Label H_御請求金額;
        private Label H_会社名;
        private Label H_自社郵便番号;
        private Label H_自社住所1;
        private Label H_自社住所2;
        private Label label6;
        private DataGridView DG1;
        private Label label7;
        private DataGridViewTextBoxColumn 日付;
        private DataGridViewTextBoxColumn 商品CD;
        private DataGridViewTextBoxColumn 商品名;
        private DataGridViewTextBoxColumn 数量;
        private DataGridViewTextBoxColumn 単位;
        private DataGridViewTextBoxColumn 売上単価;
        private DataGridViewTextBoxColumn 売上金額;
        private DataGridViewTextBoxColumn 明細備考;
    }
}