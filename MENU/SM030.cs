using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace customerApp
{
    public partial class SM030 : Form
    {
        #region パブリック変数

        public string m_商品CD { get; set; } = "";

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
        private string m_TorokuPROID = "SM030";
        private string m_KosinPROID = "SM030";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public SM030()
        {
            InitializeComponent();
        }
        #endregion

        #region SM030_Load /　フォームロード
        /// <summary>
        /// SM030_Load /　フォームロード
        /// </summary>
        private void SM030_Load(object sender, EventArgs e)
        {

            //明細部の高さの調節を不可にする
            //foreach (DataGridViewColumn col in DG1.Columns)
            //{
            //    col.SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //初期値の設定
            F_InitializeInput(0);

            DG1.Columns["単価"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["単価"].DefaultCellStyle.Format = "#,##0";

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
        private void SM030_KeyDown(object sender, KeyEventArgs e)
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

            m_商品CD = DG1.Rows[e.RowIndex].Cells["商品CD"].Value?.ToString() ?? "";

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

            if (G_商品名.Text != "")
            {
                w_Where += " AND MSYO.商品名 LIKE @Mtokmei";
                w_WhereD += " AND MSYO.商品名 LIKE '%" + G_商品名.Text + "%'";
            }

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                sql = @"
                  SELECT *
                  FROM Ｍ商品 MSYO WITH(NOLOCK)
                  WHERE 0 = 0
                    ";

                sql += w_Where;

                //デバッグ用
                w_DebugSQL =
                $"  SELECT *" +
                $"  FROM Ｍ商品 MSYO WITH(NOLOCK)" +
                $"  WHERE 0 = 0";

                w_DebugSQL += w_WhereD;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {

                    if (G_商品名.Text != "")
                    {
                        cmd.Parameters.AddWithValue("@Mtokmei", "%" + G_商品名.Text + "%");
                    }

                    DG1.Rows.Clear();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DG1.Rows.Add(
                                reader["商品CD"],
                                reader["商品名"],
                                reader["単位名"],
                                "外税" + reader["消費税率"] + "%",
                                reader["単価"],
                                reader["備考"]
                            );
                        }
                        DG1.EndEdit();
                    }
                }
            }
            return w_Ok;
        }
        #endregion

        #region SM030_FormClosing / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void SM030_Closing(object? sender, FormClosingEventArgs e)
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
            G_商品名.Text = "";

            DG1.Rows.Clear();
            B_Key12.Text = "F12:" + "表示";
            G_商品名.Focus();
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
