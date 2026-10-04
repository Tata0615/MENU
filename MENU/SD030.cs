using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace customerApp
{
    public partial class SD030 : Form
    {
        #region パブリック変数

        public string w_売上NO { get; set; } = "";

        #endregion

        #region プライベート変数

        #region オペレータCD
        /// <summary>
        /// オペレータCD
        /// </summary>
        private string m_OperatorCD = "";
        #endregion

        #region 変更前データ保存用
        /// <summary>
        /// 変更前データ保存用
        /// </summary>
        private string m_TokCDOld = "";
        private string m_TokmeiOld = "";
        private int m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
        private bool m_SelectAll = false;
        #endregion

        #region 画面終了FLG
        /// <summary>
        /// 画面終了FLG
        /// </summary>
        private bool m_CloseFLG = false;
        #endregion

        #endregion

        #region プライベート定数

        #region PROID
        /// <summary>
        /// PROID
        /// </summary>
        private string m_TorokuPROID = "SD030";
        private string m_KosinPROID = "SD030";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public SD030()
        {
            InitializeComponent();
        }
        #endregion

        #region SD030_Load /　フォームロード
        /// <summary>
        /// SD030_Load /　フォームロード
        /// </summary>
        private void SD030_Load(object sender, EventArgs e)
        {

            //明細部の高さの調節を不可にする
            //foreach (DataGridViewColumn col in DG1.Columns)
            //{
            //    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //初期値の設定
            F_InitializeInput(0);

            DG1.Columns["数量"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["数量"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["売上単価"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["売上単価"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["売上金額"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["売上金額"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["合計売上金額税抜"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["合計売上金額税抜"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["合計売上消費税"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["合計売上消費税"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["合計売上金額"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["合計売上金額"].DefaultCellStyle.Format = "#,##0";

            //明細クリック時、列単位で選択されるようにする
            DG1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DG1.MultiSelect = false;
            DG1.ColumnHeadersDefaultCellStyle.SelectionBackColor = DG1.ColumnHeadersDefaultCellStyle.BackColor;

            //オペレータCDの設定
#if DEBUG
            m_OperatorCD = "-1";
#else
                m_OperatorCD = "9999";
#endif
        }
        #endregion

        #region イベント関数

        #region B_Key01_Click /　F1押下時
        /// <summary>
        /// B_Key01_Click /　F1押下時
        /// </summary>
        private void B_Key01_Click(object sender, EventArgs e)
        {
            F_Close();
        }
        #endregion

        #region B_Key03_Click /　F3押下時
        /// <summary>
        /// B_Key03_Click /　F1押下時
        /// </summary>
        private void B_Key03_Click(object sender, EventArgs e)
        {
            F_Clear();
        }
        #endregion

        #region B_Key12_Click /　F12押下時
        /// <summary>
        /// B_Key12_Click /　F12押下時
        /// </summary>
        private void B_Key12_Click(object sender, EventArgs e)
        {
            if (F_Key012Syori() == true)
            {

            }
        }
        #endregion

        #region B_Key_KeyDown /　ファンクション押下時
        /// <summary>
        /// B_Key_KeyDown /　ファンクション押下時
        /// </summary>
        private void SD030_KeyDown(object sender, KeyEventArgs e)
        {
            // Enterで次のコントロールへ移動
            if (e.KeyCode == Keys.Enter)
            {
                SelectNextControl(
                    ActiveControl,
                    true,
                    true,
                    true,
                    true
                );

                e.SuppressKeyPress = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.F1:
                    F_Close();
                    break;

                case Keys.F3:
                    F_Clear();
                    break;

                case Keys.F12:
                    if (F_Key012Syori() == true)
                    {

                    }
                    break;
            }
        }
        #endregion

        #region G_売上日1_Validating /　売上日入力時
        /// <summary>
        /// G_売上日1_Validating /　売上日入力時
        /// </summary>
        private void G_売上日1_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "") return;

            tb.Text = F_DateFormat(tb.Text);
        }
        #endregion

        #region G_売上日2_Validating /　売上日入力時
        /// <summary>
        /// G_売上日2_Validating /　売上日入力時
        /// </summary>
        private void G_売上日2_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb.Text == "") return;

            tb.Text = F_DateFormat(tb.Text);
        }
        #endregion

        #region G_得意先CD_Validating /　得意先CD変更時
        /// <summary>
        /// G_得意先CD_Validating /　得意先CD変更時
        /// </summary>
        private void G_得意先CD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string w_TokCD = G_得意先CD.Text;
            if (G_得意先CD.Text != "")
            {
                G_得意先CD.Text = w_TokCD.PadLeft(10, '0');
            }

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string sql = @"
                     SELECT *
                     FROM Ｍ得意先
                     WHERE 得意先CD = @TokuisakiCD";

                //デバッグ用
                string w_DebugSQL =
                $"SELECT * FROM Ｍ得意先 WHERE 得意先CD = '{G_得意先CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TokuisakiCD",
                        G_得意先CD.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            G_得意先名.Text = reader["得意先名"].ToString();
                            B_Key12.Enabled = true;
                        }
                        else
                        {
                            if (G_得意先CD.Text != "")
                            {
                                MessageBox.Show(
                                "入力されたCDは存在しません",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                                G_得意先CD.Text = "";
                                G_得意先名.Text = "";

                                G_得意先CD.Focus();
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region G_商品CD_Validating /　商品CD変更時
        /// <summary>
        /// G_商品CD_Validating /　商品CD変更時
        /// </summary>
        private void G_商品CD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string w_SyoCD = G_商品CD.Text;
            if (G_商品CD.Text != "")
            {
                G_商品CD.Text = w_SyoCD.PadLeft(10, '0');
            }

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string sql = @"
                     SELECT *
                     FROM Ｍ商品
                     WHERE 商品CD = @SyoCD";

                //デバッグ用
                string w_DebugSQL =
                $"SELECT * FROM Ｍ商品 WHERE 商品CD = '{G_商品CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@SyoCD",
                        G_商品CD.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            G_商品名.Text = reader["商品名"].ToString();
                            B_Key12.Enabled = true;
                        }
                        else
                        {
                            if (G_商品CD.Text != "")
                            {
                                MessageBox.Show(
                                "入力されたCDは存在しません",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                                G_商品CD.Text = "";
                                G_商品名.Text = "";

                                G_商品CD.Focus();
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region TextBox_Click / コントロールのクリック時
        /// <summary>
        /// コントロールのクリック時
        /// </summary>
        private void TextBox_Click(object sender, EventArgs e)
        {
            if (m_SelectAll == false)
            {
                m_SelectAll = true;
                TextBox tb = (TextBox)sender;
                BeginInvoke(new Action(tb.SelectAll));
            }
        }
        #endregion

        #region TextBox_Enter / エンター押下時
        /// <summary>
        /// エンター押下時
        /// </summary>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (m_SelectAll == false)
            {
                m_SelectAll = true;
                TextBox tb = (TextBox)sender;
                BeginInvoke(new Action(tb.SelectAll));
            }
        }
        #endregion

        #region TextBox_Leave / コントロールから離れたとき
        /// <summary>
        /// コントロールから離れたとき
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            m_SelectAll = false;
        }
        #endregion

        #region DG1_CellDoubleClick / 明細部をダブルクリックしたとき
        /// <summary>
        /// 明細部をダブルクリックしたとき
        /// </summary>
        private void DG1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            w_売上NO = DG1.Rows[e.RowIndex].Cells["売上NO"].Value?.ToString() ?? "";

            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #endregion

        #region ■関数

        #region F_Disp / 得意先情報の表示
        /// <summary>
        /// 得意先情報を表示する
        /// </summary>
        private bool F_Disp()
        {
            bool w_Ok = true;
            string sql = "";
            string w_DebugSQL = "";
            string w_Where = "";
            string w_WhereD = "";

            if (G_売上NO1.Text != "")
            {
                w_Where += " AND DUHD.売上NO >= @UriNO1";
                w_WhereD += " AND DUHD.売上NO >= " + G_売上NO1.Text;
            }
            if (G_売上NO2.Text != "")
            {
                w_Where += " AND DUHD.売上NO <= @UriNO2";
                w_WhereD += " AND DUHD.売上NO <= " + G_売上NO2.Text;
            }
            if (G_売上日1.Text != "")
            {
                w_Where += " AND DUHD.売上日 >= @UriDay1";
                w_WhereD += " AND DUHD.売上日 >= '" + G_売上日1.Text + "'";
            }
            if (G_売上日2.Text != "")
            {
                w_Where += " AND DUHD.売上日 <= @UriDay2";
                w_WhereD += " AND DUHD.売上日 <= '" + G_売上日2.Text + "'";
            }
            if (G_得意先CD.Text != "")
            {
                w_Where += " AND DUHD.得意先CD = @MtokCD";
                w_WhereD += " AND DUHD.得意先CD = '" + G_得意先CD.Text + "'";
            }
            if (G_商品CD.Text != "")
            {
                w_Where += " AND DUMS.商品CD = @MsyoCD";
                w_WhereD += " AND DUMS.商品CD = '" + G_商品CD.Text + "'";
            }

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                sql = @"
                  SELECT *, MTAN.担当者名
                  FROM Ｄ売上ヘッダー DUHD WITH(NOLOCK)
                  INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK) ON
                        DUHD.売上NO = DUMS.売上NO
                  LEFT JOIN Ｍ担当者 MTAN WITH(NOLOCK) ON
                        DUHD.担当者CD = MTAN.担当者CD
                  WHERE 0 = 0
                    ";

                sql += w_Where;

                //デバッグ用
                w_DebugSQL =
                $"  SELECT *, MTAN.担当者名" +
                $"  FROM Ｄ売上ヘッダー DUHD WITH(NOLOCK)" +
                $"  INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK) ON" +
                $"        DUHD.売上NO = DUMS.売上NO" +
                $"  LEFT JOIN Ｍ担当者 MTAN WITH(NOLOCK) ON      " +
                $"        DUHD.担当者CD = MTAN.担当者CD      " +
                $"  WHERE 0 = 0";

                w_DebugSQL += w_WhereD;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    if (G_売上NO1.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@UriNO1", G_売上NO1.Text);
                    }
                    if (G_売上NO2.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@UriNO2", G_売上NO2.Text);
                    }
                    if (G_売上日1.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@UriDay1", G_売上日1.Text);
                    }
                    if (G_売上日2.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@UriDay2", G_売上日2.Text);
                    }
                    if (G_得意先CD.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@MtokCD", G_得意先CD.Text);
                    }
                    if (G_商品CD.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@MsyoCD", G_商品CD.Text);
                    }

                    DG1.Rows.Clear();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            string w_Kanno = "";


                            switch (Convert.ToInt32(reader["完納区分"]))
                            {
                                case 0:
                                    w_Kanno = "未完納";
                                    break;
                                case 1:
                                    w_Kanno = "完納済";
                                    break;
                            }

                            DG1.Rows.Add(
                                reader["売上NO"],
                                reader["売上NO行"],
                                Convert.ToDateTime(reader["売上日"]).ToString("yyyy/MM/dd"),
                                reader["得意先CD"],
                                reader["得意先名"],
                                reader["得意先担当者名"],
                                reader["担当者CD"],
                                reader["担当者名"],
                                reader["件名"],
                                reader["条件"],
                                reader["注文番号"],
                                reader["備考1"],
                                reader["備考2"],
                                reader["備考3"],
                                reader["商品CD"],
                                reader["商品名"],
                                "外税" + reader["消費税率"] + "%",
                                reader["数量"],
                                reader["単位名"],
                                reader["売上単価"],
                                reader["売上金額"],
                                reader["明細備考"],
                                reader["合計売上金額税抜"],
                                reader["合計売上消費税"],
                                reader["合計売上金額"],
                                w_Kanno

                            );
                        }
                        DG1.EndEdit();
                    }
                }
            }

            return w_Ok;
        }
        #endregion

        #region SD030_FormClosing / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void SD030_Closing(object? sender, FormClosingEventArgs e)
        {
            if (!m_CloseFLG)
            {
                if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //何もせず終了
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        #endregion

        #region F_Close / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void F_Close()
        {
            if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                m_CloseFLG = true;
                this.Close();
            }
        }
        #endregion

        #region F_Clear / 画面のクリア
        /// <summary>
        /// 画面のクリア
        /// </summary>
        private void F_Clear()
        {
            if (MessageBox.Show("ｸﾘｱしますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                F_InitializeInput(0);
            }
        }
        #endregion

        #region F_InitializeInput / 画面のクリア
        /// <summary>
        /// 画面のクリア
        /// <param name="i_Kbn">
        /// </param>
        /// </summary>
        private void F_InitializeInput(int i_Kbn)
        {
            G_売上NO1.Text = "";
            G_売上NO2.Text = "";
            G_売上日1.Text = "";
            G_売上日2.Text = "";
            G_得意先CD.Text = "";
            G_得意先名.Text = "";
            G_商品CD.Text = "";
            G_商品名.Text = "";

            DG1.Rows.Clear();
            B_Key12.Text = "F12:" + "表示";
            G_売上NO1.Focus();

        }
        #endregion                    

        #region F_Key012Syori / F12キー押下時の処理
        /// <summary>
        /// F12キー押下時の処理
        /// </summary>
        private bool F_Key012Syori()
        {

            bool w_ok = false;

            if (F_Disp())
            {
                w_ok = true;
            }

            return w_ok;
        }
        #endregion

        #region F_DateFormat / 日付の自動入力
        /// <summary>
        /// 日付の自動入力
        /// </summary>
        private string F_DateFormat(string i_value)
        {
            i_value = i_value.Trim();

            // 28～31 → 当月末日
            if (i_value.Length <= 2 && int.TryParse(i_value, out int day))
            {
                DateTime now = DateTime.Now;
                int lastDay = DateTime.DaysInMonth(now.Year, now.Month);

                if (day >= 28)
                    day = lastDay;

                return new DateTime(now.Year, now.Month, day).ToString("yyyy/MM/dd");
            }

            // 通常の日付
            if (DateTime.TryParse(i_value, out DateTime dt))
            {
                return dt.ToString("yyyy/MM/dd");
            }

            return "";
        }
        #endregion

        #region F_DBValue / DBのNULLの制御
        /// <summary>
        /// DBのNULLの制御
        /// </summary>
        private object F_DBValue(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? DBNull.Value : text;
        }

        private object F_DBValue(DateTime? value)
        {
            return value ?? (object)DBNull.Value;
        }
        #endregion

        #endregion

    }
}
