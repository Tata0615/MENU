using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace customerApp
{
    public partial class RS010 : Form
    {

        #region プライベート変数

        #region オペレータCD
        /// <summary>
        /// オペレータCD
        /// </summary>
        private string m_OperatorCD = "";
        #endregion

        #region 画面終了FLG
        /// <summary>
        /// 画面終了FLG
        /// </summary>
        private bool m_CloseFLG = false;
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

        #endregion

        #region プライベート定数

        #region PROID
        /// <summary>
        /// PROID
        /// </summary>
        private string m_TorokuPROID = "S010";
        private string m_KosinPROID = "S010";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public RS010()
        {
            InitializeComponent();
        }
        #endregion

        #region RS010_Load /　フォームロード
        /// <summary>
        /// RS010_Load /　フォームロード
        /// </summary>
        private void RS010_Load(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn col in DG1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //初期値の設定
            F_InitializeInput(0);
            G_締日.Text = "31";
            G_請求書種類CD.Text = "1301";
            O_請求書種類名.Text = "請求書";

            DG1.Columns["税抜売上金額"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["税抜売上金額"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["消費税額"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["消費税額"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["税込売上金額"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            DG1.Columns["税込売上金額"].DefaultCellStyle.Format = "#,##0";

            DG1.Columns["対象"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DG1.Columns["対象"].HeaderCell.Style.Padding = new Padding(3, 0, 0, 0);   // 数字を変えて微調整

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
            if (!F_Check())
            {
                return;
            }

            if (F_Key012Syori() == true)
            {
                F_InitializeInput(1);
                //G_得意先CD.Focus();
            }
        }
        #endregion

        #region B_Key_KeyDown /　ファンクション押下時
        /// <summary>
        /// B_Key_KeyDown /　ファンクション押下時
        /// </summary>
        private void RS010_KeyDown(object sender, KeyEventArgs e)
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
                    if (F_Check())
                    {
                        if (F_Key012Syori() == true)
                        {
                            F_InitializeInput(1);
                        }
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
                System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
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
                System.Windows.Forms.TextBox tb = (System.Windows.Forms.TextBox)sender;
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

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                sql = @"
                     SELECT 
                       SSEI.請求先CD
                      ,MTOK.得意先名
                      ,SSEI.請求締年月日
                      ,SSEI.合計売上金額税抜
                      ,SSEI.合計売上消費税
                      ,SSEI.合計売上金額
                      ,SSEI.前回請求締年月日
                     FROM Ｓ請求残高 SSEI WITH(NOLOCK)
                     INNER JOIN Ｍ得意先 MTOK WITH(NOLOCK)
                        ON SSEI.請求先CD = MTOK.得意先CD
                     WHERE 0 = 0
                       AND SSEI.請求締年月日 = @SeiSN";

                //デバッグ用
                w_DebugSQL =
                $" SELECT " +
                $"   SSEI.請求先CD" +
                $"  ,MTOK.得意先名" +
                $"  ,SSEI.合計売上金額税抜" +
                $"  ,SSEI.合計売上消費税" +
                $"  ,SSEI.合計売上金額" +
                $"  ,SSEI.前回請求締年月日" +
                $" FROM Ｓ請求残高 SSEI WITH(NOLOCK)" +
                $" WHERE 0 = 0" +
                $"   AND SSEI.請求締年月日 = '" + Convert.ToDateTime(D_請求締年月日.Value.Date).ToString("yyyy/MM/dd") + "'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SeiSN", D_請求締年月日.Value.Date);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool w_NOMeisaiFLG = true;

                        while (reader.Read())
                        {
                            DG1.Rows.Add(
                                1,
                                reader["請求先CD"],
                                reader["得意先名"],
                                reader["合計売上金額税抜"],
                                reader["合計売上消費税"],
                                reader["合計売上金額"],
                                reader["前回請求締年月日"]
                            );

                            w_NOMeisaiFLG = false;

                        }
                        DG1.EndEdit();

                        if (w_NOMeisaiFLG)
                        {
                            MessageBox.Show(
                               "更新対象明細がありません",
                               "警告",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);

                            return false;
                        }
                    }
                }
            }

            return w_Ok;
        }
        #endregion

        #region F_Update / テーブルの更新
        /// <summary>
        /// テーブルの更新
        /// </summary>
        private bool F_Update()
        {
            bool w_ok = false;
            return w_ok;
        }

        #endregion

        #region F_Delete / 得意先情報の削除
        /// <summary>
        /// 得意先情報の削除
        /// </summary>
        private bool F_Delete()
        {

            bool w_ok = false;
            DateTime w_SeiSN = D_請求締年月日.Value.Date;
            DateTime w_KosinDay = DateTime.Now;
            DateTime? w_ZSeiSN_SSEI = null;

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {

                        //明細の数だけ回す
                        for (int w_Row = 0; w_Row < DG1.Rows.Count; w_Row++)
                        {

                            string w_MTOKCD = DG1.Rows[w_Row].Cells["請求先CD"].Value?.ToString() ?? "";

                            //前回請求締年月日を取得
                            string ZSeiSNsql = @"
                            　SELECT 
                            　  SSEI.請求先CD
                            　 ,SSEI.請求締年月日
                            　 ,SSEI.前回請求締年月日
                            　FROM Ｓ請求残高 SSEI WITH(NOLOCK)
                            　WHERE 0 = 0
                            　  AND SSEI.請求先CD = @w_MTOKCD
                            　  AND SSEI.請求締年月日 = @w_SeiSN";

                            using (SqlCommand cmd = new SqlCommand(ZSeiSNsql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@w_MTOKCD", w_MTOKCD);
                                cmd.Parameters.AddWithValue("@w_SeiSN", w_SeiSN);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        w_ZSeiSN_SSEI = reader["前回請求締年月日"] == DBNull.Value ? null : Convert.ToDateTime(reader["前回請求締年月日"]);
                                    }
                                }
                            }


                            //得意先情報の更新
                            string MTOKsql = @"
                             UPDATE Ｍ得意先 
                             SET    前回請求締年月日 = @w_ZSeiSN,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                             WHERE 得意先CD = @w_MTOKCD";

                            using (SqlCommand cmd = new SqlCommand(MTOKsql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@w_MTOKCD", w_MTOKCD);

                                cmd.Parameters.AddWithValue("@w_ZSeiSN", F_DBValue(w_ZSeiSN_SSEI));
                                cmd.Parameters.AddWithValue("@w_KosinPROID", m_KosinPROID);
                                cmd.Parameters.AddWithValue("@w_KosinDay", w_KosinDay);
                                cmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);

                                cmd.ExecuteNonQuery();
                            }

                            //売上情報の更新
                            string DUHDsql = @"
                             UPDATE Ｄ売上ヘッダー 
                             SET    請求締年月日 = @w_SeiSN_SET,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                             WHERE 得意先CD = @w_MTOKCD
                               AND 請求締年月日 = @w_SeiSN_WHERE";

                            using (SqlCommand cmd = new SqlCommand(DUHDsql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@w_MTOKCD", w_MTOKCD);

                                cmd.Parameters.AddWithValue("@w_SeiSN_SET", DBNull.Value);
                                cmd.Parameters.AddWithValue("@w_SeiSN_WHERE", w_SeiSN);
                                cmd.Parameters.AddWithValue("@w_KosinPROID", m_KosinPROID);
                                cmd.Parameters.AddWithValue("@w_KosinDay", w_KosinDay);
                                cmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);

                                cmd.ExecuteNonQuery();
                            }

                            //請求情報の更新
                            string SSEIsql = @"
                             DELETE 
                             FROM   Ｓ請求残高
                             WHERE 請求先CD = @w_MTOKCD
                               AND 請求締年月日 = @w_SeiSN";

                            using (SqlCommand cmd = new SqlCommand(SSEIsql, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@w_MTOKCD", w_MTOKCD);
                                cmd.Parameters.AddWithValue("@w_SeiSN", w_SeiSN);

                                cmd.ExecuteNonQuery();
                            }

                        }
                        // 正常終了なら確定
                        tran.Commit();
                        w_ok = true;
                    }
                    catch
                    {
                        // エラーなら取り消し
                        tran.Rollback();
                        DG1.EndEdit();
                        w_ok = false;
                    }
                }
            }

            return w_ok;
        }
        #endregion

        #region RS010_FormClosing / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void RS010_Closing(object? sender, FormClosingEventArgs e)
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
        /// 0:クリア処理時 
        /// 1:処理区分変更時 
        /// 2:得意先CD入力時
        /// </param>
        /// </summary>
        private void F_InitializeInput(int i_Kbn)
        {
            if (i_Kbn != 2)
            {
                m_TokCDOld = "";
                m_TokmeiOld = "";
                m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
            }

            DG1.Rows.Clear();
            B_Key12.Text = "F12:" + "表示";

            DateTime today = DateTime.Today;
            D_請求締年月日.Enabled = true;

            // 今月の月末
            D_請求締年月日.Value = new DateTime(
                today.Year,
                today.Month,
                DateTime.DaysInMonth(today.Year, today.Month));
        }
        #endregion

        #region F_Check / 入力内容チェック
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        private bool F_Check()
        {
            return true;
        }
        #endregion

        #region F_AllLock / コントロールの制御
        /// <summary>
        /// コントロールの制御
        /// /// <param name="i_Kbn">
        /// 0: Lock
        /// 1: UnLock
        /// </param>
        /// </summary>
        private void F_AllLock(int i_Kbn)
        {

            //Color w_ReadOnlyColor = Color.FromArgb(255, 255, 192);  // Lock
            //Color w_ReadOnlyColor2 = Color.White;                   // UnLock

            //if (i_Kbn == 0) // Lock
            //{

            //    //    G_得意先CD.BackColor = w_ReadOnlyColor;
            //    //    G_得意先CD.ReadOnly = true;

            //    G_得意先名.BackColor = w_ReadOnlyColor;
            //    G_郵便番号.BackColor = w_ReadOnlyColor;
            //    G_住所1.BackColor = w_ReadOnlyColor;
            //    G_住所2.BackColor = w_ReadOnlyColor;
            //    G_TEL1.BackColor = w_ReadOnlyColor;
            //    G_TEL2.BackColor = w_ReadOnlyColor;
            //    G_FAX.BackColor = w_ReadOnlyColor;
            //    G_MAIL.BackColor = w_ReadOnlyColor;
            //    G_担当者名.BackColor = w_ReadOnlyColor;
            //    G_備考.BackColor = w_ReadOnlyColor;

            //    CB_選択不可FLG.Enabled = false;
            //    G_得意先名.ReadOnly = true;
            //    G_郵便番号.ReadOnly = true;
            //    G_住所1.ReadOnly = true;
            //    G_住所2.ReadOnly = true;
            //    G_TEL1.ReadOnly = true;
            //    G_TEL2.ReadOnly = true;
            //    G_FAX.ReadOnly = true;
            //    G_MAIL.ReadOnly = true;
            //    G_担当者名.ReadOnly = true;
            //    G_備考.ReadOnly = true;
            //}
            //else // UnLock
            //{
            //    G_得意先CD.BackColor = w_ReadOnlyColor2;
            //    G_得意先名.BackColor = w_ReadOnlyColor2;
            //    G_郵便番号.BackColor = w_ReadOnlyColor2;
            //    G_住所1.BackColor = w_ReadOnlyColor2;
            //    G_住所2.BackColor = w_ReadOnlyColor2;
            //    G_TEL1.BackColor = w_ReadOnlyColor2;
            //    G_TEL2.BackColor = w_ReadOnlyColor2;
            //    G_FAX.BackColor = w_ReadOnlyColor2;
            //    G_MAIL.BackColor = w_ReadOnlyColor2;
            //    G_担当者名.BackColor = w_ReadOnlyColor2;
            //    G_備考.BackColor = w_ReadOnlyColor2;

            //    CB_選択不可FLG.Enabled = true;
            //    G_得意先CD.ReadOnly = false;
            //    G_得意先名.ReadOnly = false;
            //    G_郵便番号.ReadOnly = false;
            //    G_住所1.ReadOnly = false;
            //    G_住所2.ReadOnly = false;
            //    G_TEL1.ReadOnly = false;
            //    G_TEL2.ReadOnly = false;
            //    G_FAX.ReadOnly = false;
            //    G_MAIL.ReadOnly = false;
            //    G_担当者名.ReadOnly = false;
            //    G_備考.ReadOnly = false;
            //}

        }
        #endregion

        #region F_Key012Syori / F12キー押下時の処理
        /// <summary>
        /// F12キー押下時の処理
        /// </summary>
        private bool F_Key012Syori()
        {

            bool w_ok = false;

            if (DG1.Rows.Count == 0)
            {
                if (F_Disp())
                {
                    B_Key12.Text = "F12:ﾌﾟﾚﾋﾞｭｰ";
                    D_請求締年月日.Enabled = false;
                }
                w_ok = false;  //表示処理の時はFalseを返す
                return w_ok;
            }

            if (MessageBox.Show("出力しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DG1.Rows)
                {
                    bool w_Target = Convert.ToBoolean(row.Cells["対象"].Value);

                    if (!w_Target)
                    {
                        continue;
                    }

                    string w_SeiCD = row.Cells["請求先CD"].Value?.ToString() ?? "";
                    string w_SeiSN = Convert.ToDateTime(D_請求締年月日.Text).ToString("yyyy/MM/dd");

                    //件数から、ページ数を取得
                    int w_PageCnt = F_CountSql(w_SeiCD, w_SeiSN);

                    //取得したページ数だけ、同一請求先CDの帳票を作成する
                    for (int w_Page = 1; w_Page <= w_PageCnt; w_Page++)
                    {
                        RS011 frm = new RS011(w_SeiCD, w_SeiSN, w_Page);
                        frm.ShowDialog();
                    }
                }

                w_ok = true;
            }
            return w_ok;
        }
        #endregion

        #region F_CountSql / 件数の取得
        /// <summary>
        /// 件数の取得
        /// </summary>
        private int F_CountSql(string i_SeiCD, string i_SeiSN)
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string COUNTsql = @"
                SELECT COUNT(*) AS 件数
                  FROM Ｄ売上ヘッダー DUHD
                  INNER JOIN Ｄ売上明細 DUMS
                      ON DUHD.売上NO = DUMS.売上NO
                  WHERE DUHD.得意先CD = @SeiCD
                    AND DUHD.請求締年月日 = @SeiSN";

                //デバッグ用
                string w_DebugSQL =
                $"  SELECT COUNT(*)" +
                $"    FROM Ｄ売上ヘッダー DUHD" +
                $"    INNER JOIN Ｄ売上明細 DUMS" +
                $"        ON DUHD.売上NO = DUMS.売上NO" +
                $"    WHERE DUHD.得意先CD = " + i_SeiCD +
                $"      AND DUHD.請求締年月日 = '" + Convert.ToDateTime(i_SeiSN).ToString("yyyy/MM/dd") + "'";

                using (SqlCommand cmd = new SqlCommand(COUNTsql, conn))
                {
                    cmd.Parameters.AddWithValue("@SeiCD", i_SeiCD);
                    cmd.Parameters.AddWithValue("@SeiSN", i_SeiSN);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int w_Count = Convert.ToInt32(reader["件数"]);
                            int w_Page = (w_Count + 27) / 28;

                            return w_Page;
                        }
                    }
                }
            }

            return 0;
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
