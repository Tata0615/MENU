using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace customerApp
{
    public partial class D030 : Form
    {

        #region パブリック変数

        public string m_UriageNO = "";

        #endregion

        #region プライベート変数

        #region オペレータCD
        /// <summary>
        /// オペレータCD
        /// </summary>
        private string m_OperatorCD = "";
        #endregion

        #region 請求計上日チェックFLG
        /// <summary>
        /// 請求計上日チェックFLG
        /// </summary>
        private bool m_IsUpdatingSeiDay = false;
        #endregion

        #region 画面終了FLG
        /// <summary>
        /// 画面終了FLG
        /// </summary>
        private bool m_CloseFLG = false;
        #endregion

        #region フォームロード判定FLG
        /// <summary>
        /// 画面終了FLG
        /// </summary>
        private bool m_FormLoadFLG = true;
        #endregion

        #region 検索用変数
        /// <summary>
        /// 検索用変数
        /// </summary>
        private bool m_SeachUri = false;
        private bool m_SeachTok = false;
        private bool m_SeachTan = false;
        private bool m_SeachSyo = false;
        #endregion

        #region 変更前データ保存用
        /// <summary>
        /// 変更前データ保存用
        /// </summary>
        private Decimal m_UriNOOld = 0;
        private Decimal m_JyuNOOld = 0;
        private Decimal m_MitNOOld = 0;
        private int m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
        private bool m_SelectAll = false;
        private bool m_SyoNULLFLG = false;
        #endregion

        #endregion

        #region プライベート定数

        #region PROID
        /// <summary>
        /// PROID
        /// </summary>
        private string m_TorokuPROID = "D030";
        private string m_KosinPROID = "D030";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public D030()
        {
            InitializeComponent();

        }
        #endregion

        #region D030_Load /　フォームロード
        /// <summary>
        /// D030_Load /　フォームロード
        /// </summary>
        private void D030_Load(object sender, EventArgs e)
        {

            m_FormLoadFLG = true;

            //明細部のソートを不可にする
            foreach (DataGridViewColumn col in DG1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //初期値の設定
            F_InitializeInput(0);
            D_売上日.Text = DateTime.Now.ToString("yyyy/MM/dd");
            D_請求計上日.Text = DateTime.Now.ToString("yyyy/MM/dd");
            G_納品書種類.Text = "1201";
            O_納品書種類.Text = "納品書";
            C_即伝区分.SelectedIndex = 0; // 0:入力時発行

            //オペレータCDの設定
#if DEBUG
            m_OperatorCD = "-1";
#else
                m_OperatorCD = "9999";
#endif

            //照会画面から呼ばれたとき
            if (m_UriageNO != "")
            {
                //呼び出された売上NOで、変更のみ可能とする
                B_Key03.Enabled = false;
                C_処理区分.SelectedIndex = 1; // 1:変更
                C_処理区分.Enabled = false;

                //売上NOを画面に表示する
                G_売上NO.Text = m_UriageNO;
                F_DispUri();
                G_売上NO.BackColor = Color.FromArgb(255, 255, 192);
                G_売上NO.ReadOnly = true;

                //明細の選択状態を解除する(青い部分が残ったままになるので)
                DG1.ClearSelection();
                D_売上日.Focus();
            }

            m_FormLoadFLG = false;
        }
        #endregion

        #region イベント関数

        #region G_売上NO_Validating /　売上NO変更時
        /// <summary>
        /// G_売上NO_Validating /　売上NO変更時
        /// </summary>
        private void G_売上NO_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (G_売上NO.Text != "" && m_UriNOOld != Decimal.Parse(G_売上NO.Text) && m_UriageNO == "")
            {
                //排他データの削除
                F_DeleteHaita(m_UriNOOld);

                m_UriNOOld = Decimal.Parse(G_売上NO.Text);

                if (F_OnDisp(3))
                {
                    B_Key12.Enabled = true;
                    //明細の選択状態を解除する(青い部分が残ったままになるので)
                    DG1.ClearSelection();
                    D_売上日.Focus();
                }
                else
                {
                    B_Key12.Enabled = false;
                    G_売上NO.Focus();
                }
            }
        }
        #endregion

        #region C_処理区分_SelectedIndexChanged /　処理区分変更時
        /// <summary>
        /// C_処理区分_SelectedIndexChanged /　処理区分変更時
        /// </summary>
        private void C_処理区分_SelectedIndexChanged(object sender, EventArgs e)
        {
            string w_SyoriKbn = C_処理区分.Text.Split(':').Last();

            B_Key12.Text = "F12:" + w_SyoriKbn;

            if (C_処理区分.SelectedIndex != m_SyoriKbnOld)
            {
                F_InitializeInput(1);
                F_AllLock(1);

                m_SyoriKbnOld = C_処理区分.SelectedIndex;
            }

            B_Key12.Enabled = true;
        }
        #endregion

        #region D_売上日_ValueChanged /　売上日変更時
        /// <summary>
        /// D_売上日_ValueChanged /　売上日変更時
        /// </summary>
        private void D_売上日_ValueChanged(object sender, EventArgs e)
        {
            m_IsUpdatingSeiDay = true;
            D_請求計上日.Value = D_売上日.Value;
            m_IsUpdatingSeiDay = false;
            F_SeiSNCheck();
        }
        #endregion

        #region D_請求計上日_ValueChanged /　請求計上日変更時
        /// <summary>
        /// D_請求計上日_ValueChanged /　請求計上日変更時
        /// </summary>
        private void D_請求計上日_ValueChanged(object sender, EventArgs e)
        {
            bool w_Ok = true;

            // 売上日変更による自動変更なら何もしない
            if (m_IsUpdatingSeiDay)
            {
                return;
            }

            if (!F_SeiSNCheck())
            {
                w_Ok = false;
            }

            if (w_Ok && D_請求計上日.Value < D_売上日.Value)
            {
                MessageBox.Show(
                    "請求計上日は売上日以降の日付を入力してください",
                    "警告",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                D_請求計上日.Focus();
            }
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
                            O_得意先名.Text = reader["得意先名"].ToString();
                            G_得意先担当.Text = reader["担当者名"].ToString();
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
                                O_得意先名.Text = "";
                                G_得意先担当.Text = "";

                                G_得意先CD.Focus();
                            }
                        }

                    }
                }
            }
        }
        #endregion

        #region G_担当者CD_Validating /　担当者CD変更時
        /// <summary>
        /// G_担当者CD_Validating /　担当者CD変更時
        /// </summary>
        private void G_担当者CD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string sql = @"
                     SELECT *
                     FROM Ｍ担当者
                     WHERE 担当者CD = @TantousyaCD";

                //デバッグ用
                string w_DebugSQL =
                $"SELECT * FROM Ｍ担当者 WHERE 担当者CD = '{G_担当者CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TantousyaCD",
                        G_担当者CD.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            O_担当者名.Text = reader["担当者名"].ToString();
                            B_Key12.Enabled = true;
                        }
                        else
                        {
                            if (G_担当者CD.Text != "")
                            {
                                MessageBox.Show(
                                "入力されたCDは存在しません",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                                G_担当者CD.Text = "";
                                O_担当者名.Text = "";

                                G_担当者CD.Focus();
                            }
                        }

                    }
                }
            }
        }
        #endregion

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
        /// B_Key03_Click /　F4押下時
        /// </summary>
        private void B_Key03_Click(object sender, EventArgs e)
        {
            F_Clear();
        }
        #endregion

        #region B_Key04_Click /　F4押下時
        /// <summary>
        /// B_Key04_Click /　F4押下時
        /// </summary>
        private void B_Key04_Click(object sender, EventArgs e)
        {
            F_Search();
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
                G_売上NO.Focus();
            }
        }
        #endregion

        #region B_Key_KeyDown /　ファンクション押下時
        /// <summary>
        /// B_Key_KeyDown /　ファンクション押下時
        /// </summary>
        private void D030_KeyDown(object sender, KeyEventArgs e)
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

                case Keys.F4:
                    F_Search();
                    break;

                case Keys.F12:
                    if (F_Check())
                    {
                        if (F_Key012Syori() == true)
                        {
                            F_InitializeInput(1);
                            G_売上NO.Focus();
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
                TextBox w_tb = (TextBox)sender;
                //クリック処理終了後、テキストボックスの内容を全選択する(クリックした位置にかかわらず、全選択されてほしいので)
                BeginInvoke(new Action(w_tb.SelectAll));
            }
        }
        #endregion

        #region TextBox_Enter / フォーカス取得時
        /// <summary>
        /// フォーカス取得時
        /// </summary>
        private void TextBox_Enter(object sender, EventArgs e)
        {
            if (C_処理区分.SelectedIndex != 0 && sender == G_売上NO && m_UriageNO == "") // 0:登録
            {
                B_Key04.Enabled = true;
                m_SeachUri = true;
                m_SeachTok = false;
                m_SeachTan = false;
                m_SeachSyo = false;
            }
            else if (sender == G_得意先CD)
            {
                B_Key04.Enabled = true;
                m_SeachUri = false;
                m_SeachTok = true;
                m_SeachTan = false;
                m_SeachSyo = false;
            }
            else if (sender == G_担当者CD)
            {
                B_Key04.Enabled = true;
                m_SeachUri = false;
                m_SeachTok = false;
                m_SeachTan = true;
                m_SeachSyo = false;
            }
            else
            {
                B_Key04.Enabled = false;
                m_SeachUri = false;
                m_SeachTok = false;
                m_SeachTan = false;
                m_SeachSyo = false;
            }

            if (m_SelectAll == false)
            {
                m_SelectAll = true;
                TextBox w_tb = (TextBox)sender;
                //クリック処理終了後、テキストボックスの内容を全選択する(クリックした位置にかかわらず、全選択されてほしいので)
                BeginInvoke(new Action(w_tb.SelectAll));
            }
        }
        #endregion

        #region TextBox_Leave / コントロールから離れたとき
        /// <summary>
        /// コントロールから離れたとき
        /// </summary>
        private void TextBox_Leave(object sender, EventArgs e)
        {
            // 次に押したのが F4 ボタンなら有効のまま
            if (this.ActiveControl != B_Key04)
            {
                B_Key04.Enabled = false;
            }

            m_SelectAll = false;
        }
        #endregion

        #region DG1_EditingControlShowing / 明細部の入力制御
        /// <summary>
        /// 明細部の入力制御
        /// </summary>
        private void DG1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox w_tb)
            {
                string w_col = DG1.CurrentCell.OwningColumn.Name;

                // まず必ず解除
                w_tb.KeyPress -= NumberOnly_KeyPress;

                if (w_col == "明細備考" || w_col == "単位")
                {
                    w_tb.ImeMode = ImeMode.Hiragana;
                }
                else if (w_col == "数量" || w_col == "売上単価" || w_col == "売上金額")
                {
                    w_tb.ImeMode = ImeMode.Off;
                    w_tb.KeyPress += NumberOnly_KeyPress;
                }
                else
                {
                    w_tb.ImeMode = ImeMode.Off;
                }
            }
        }
        #endregion        

        #region NumberOnly_KeyPress / 明細部の入力制御
        /// <summary>
        /// 明細部の入力制御
        /// </summary>
        private void NumberOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            //制御文字ではない、かつ数字でない場合は入力を無効にする
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        #endregion

        #region DG1_KeyDown / 明細部Enterで次項目へ(DataGridViewだとうまくいかない?)実装断念
        //#region
        //private void DG1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.SuppressKeyPress = true;
        //        SendKeys.Send("{TAB}");
        //    }
        //}
        //#endregion

        //#region
        //private void DG1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        e.IsInputKey = true;
        //        //e.SuppressKeyPress = true;
        //            SendKeys.Send("{TAB}");
        //    }
        //}
        //#endregion
        #endregion

        #region DG1_Enter / 明細部フォーカス取得時
        /// <summary>
        /// 明細部フォーカス取得時
        /// </summary>
        private void DG1_Enter(object sender, EventArgs e)
        {
            //Tab移動した際は商品CDにフォーカスを当てる
            if (DG1.Rows.Count > 0)
            {
                DG1.CurrentCell = DG1.Rows[0].Cells["商品CD"];
            }
            //DG1.ClearSelection();
        }
        #endregion

        #region DG1_CellEnter / 明細部タブ遷移制御
        /// <summary>
        /// 明細部タブ遷移制御
        /// </summary>
        private void DG1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            string w_col = DG1.Columns[e.ColumnIndex].Name;

            // IME切替
            if (w_col == "明細備考")
                DG1.ImeMode = ImeMode.Hiragana;
            else
                DG1.ImeMode = ImeMode.Off;

            // 商品名に入ったら数量へ移動
            if (w_col == "商品名" && m_SyoNULLFLG == false)
            {
                BeginInvoke(new Action(() =>
                {
                    DG1.CurrentCell = DG1.Rows[e.RowIndex].Cells["数量"];
                }));
            }
            else if (w_col == "商品名" && m_SyoNULLFLG == true)
            {
                BeginInvoke(new Action(() =>
                {
                    DG1.CurrentCell = DG1.Rows[e.RowIndex].Cells["商品CD"];
                }));
            }

            //商品CDにフォーカスがあるなら、検索有効化
            if (w_col == "商品CD")
            {
                B_Key04.Enabled = true;
                m_SeachUri = false;
                m_SeachTok = false;
                m_SeachTan = false;
                m_SeachSyo = true;
            }
            else
            {
                B_Key04.Enabled = false;
                m_SeachUri = false;
                m_SeachTok = false;
                m_SeachTan = false;
                m_SeachSyo = false;
            }

        }

        #endregion

        #region DG1_CellEndEdit / 明細部入力時
        /// <summary>
        /// 明細部入力時
        /// </summary>
        private void DG1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            m_SyoNULLFLG = false;
            int w_Row = e.RowIndex;
            string w_Col = DG1.Columns[e.ColumnIndex].Name;
            string w_Syocd = DG1.Rows[w_Row].Cells["商品CD"].Value?.ToString() ?? "";

            //商品CD入力時の処理
            F_DispMeisai(w_Row, w_Syocd, w_Col);

            if (m_SyoNULLFLG == false)
            {
                if (DG1.Columns[e.ColumnIndex].Name == "数量" ||
                        DG1.Columns[e.ColumnIndex].Name == "売上単価")
                {
                    int w_Suryo = Convert.ToInt32(DG1.Rows[w_Row].Cells["数量"].Value ?? 0);
                    int w_Tanka = Convert.ToInt32(DG1.Rows[w_Row].Cells["売上単価"].Value ?? 0);

                    DG1.Rows[w_Row].Cells["売上金額"].Value = w_Suryo * w_Tanka;

                    if (Convert.ToInt32(DG1.Rows[w_Row].Cells["売上金額"].Value ?? 0) != 0)
                    {
                        Color w_ReadOnlyColor = Color.FromArgb(255, 255, 192);  // Lock
                        DG1.Rows[w_Row].Cells["売上金額"].ReadOnly = true;
                        DG1.Rows[w_Row].Cells["売上金額"].Style.BackColor = w_ReadOnlyColor;
                    }
                    else
                    {
                        Color w_ReadOnlyColor2 = Color.White; // UnLock
                        DG1.Rows[w_Row].Cells["売上金額"].ReadOnly = false;
                        DG1.Rows[w_Row].Cells["売上金額"].Style.BackColor = w_ReadOnlyColor2;
                    }
                }

                F_Gokei();

                string col = DG1.Columns[e.ColumnIndex].Name;

                if (col == "数量" || col == "売上単価" || col == "売上金額")
                {
                    DataGridViewCell cell = DG1[e.ColumnIndex, e.RowIndex];

                    if (int.TryParse(cell.Value?.ToString(), out int num))
                    {
                        cell.Value = num;
                    }
                }
            }
        }
        #endregion

        #region DG1_Leave / 明細部からコントロールが離れたとき
        /// <summary>
        /// 明細部からコントロールが離れたとき
        /// </summary>
        private void DG1_Leave(object sender, EventArgs e)
        {
            //明細部の選択状態を解除する
            DG1.ClearSelection();
        }

        #endregion

        #endregion

        #region ■関数

        #region F_OnDisp / 表示処理分岐
        /// <summary>
        /// 表示処理分岐
        /// 1:見積データ
        /// 2:受注データ
        /// 3:売上データ
        /// </summary>
        private bool F_OnDisp(int i_Kbn)
        {
            bool w_Ok = false;
            F_InitializeInput(2);

            switch (i_Kbn)
            {
                //case 1:
                //    w_Ok = F_DispMit();
                //    break;
                //case 2:
                //    w_Ok = F_DispJyu();
                //    break;
                case 3:
                    w_Ok = F_DispUri();
                    break;
                default:
                    w_Ok = false;
                    break;
            }

            return w_Ok;
        }
        #endregion

        #region F_DispUri / 売上データの表示
        /// <summary>
        /// 売上データの表示
        /// </summary>
        private bool F_DispUri()
        {
            bool w_Ok = true;

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                //排他チェック用SQL
                string HaitaChecksql = @"
                 SELECT *
                 FROM Ｆ排他 FHTA WITH(NOLOCK)
                 WHERE FHTA.入力種類 = 3
                   AND FHTA.入力NO = @UriNO";

                //売上データ用SQL
                string sql = @"
                 SELECT *,
                        MTAN.担当者名
                 FROM Ｄ売上ヘッダー DUHD WITH(NOLOCK)
                 INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK) ON 
                   DUHD.売上NO = DUMS.売上NO
                 LEFT JOIN Ｍ担当者 MTAN WITH(NOLOCK) ON 
                   DUHD.担当者CD = MTAN.担当者CD
                 WHERE DUHD.売上NO = @UriNO";

                //売上データ確認用SQL
                string w_DebugSQL =
                $"SELECT *,MTAN.担当者名 FROM Ｄ売上ヘッダー DUHD WITH(NOLOCK)" +
                $" INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK)" +
                $" ON DUHD.売上NO = DUMS.売上NO" +
                $" LEFT JOIN Ｍ担当者 MTAN WITH(NOLOCK) ON" +
                $" DUHD.担当者CD = MTAN.担当者CD" +
                $" WHERE DUHD.売上NO = '{G_売上NO.Text}'";

                using (SqlCommand cmd = new SqlCommand(HaitaChecksql, conn))
                {
                    if (m_UriageNO != "")
                    {
                        cmd.Parameters.AddWithValue("@UriNO", m_UriageNO);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@UriNO", G_売上NO.Text);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            MessageBox.Show(
                                "他のオペレータが編集中です",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            w_Ok = false;
                        }
                    }
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (m_UriageNO != "")
                    {
                        cmd.Parameters.AddWithValue("@UriNO", m_UriageNO);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@UriNO", G_売上NO.Text);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool w_first = true;

                        while (reader.Read())
                        {
                            //G_売上NOの内容を画面に表示
                            if (w_first)
                            {
                                if (Convert.ToInt32(reader["受注NO"].ToString()) == 0)
                                {
                                    G_受注NO.Text = "";
                                }
                                else
                                {
                                    G_受注NO.Text = reader["受注NO"].ToString();
                                }
                                if (Convert.ToInt32(reader["見積NO"].ToString()) == 0)
                                {
                                    G_見積NO.Text = "";
                                }
                                else
                                {
                                    G_見積NO.Text = reader["見積NO"].ToString();
                                }
                                D_売上日.Text = reader["売上日"].ToString();
                                D_請求計上日.Text = reader["請求計上日"].ToString();
                                G_得意先CD.Text = reader["得意先CD"].ToString();
                                O_得意先名.Text = reader["得意先名"].ToString();
                                G_得意先担当.Text = reader["得意先担当者名"].ToString();
                                G_担当者CD.Text = reader["担当者CD"].ToString();
                                O_担当者名.Text = reader["担当者名"].ToString();
                                G_件名.Text = reader["件名"].ToString();
                                G_条件.Text = reader["条件"].ToString();
                                G_注文番号.Text = reader["注文番号"].ToString();
                                C_即伝区分.SelectedIndex = Convert.ToInt32(reader["納品書即伝区分"].ToString());
                                G_備考1.Text = reader["備考1"].ToString();
                                G_備考2.Text = reader["備考2"].ToString();
                                G_備考3.Text = reader["備考3"].ToString();
                                O_フッター売上金額.Text = Convert.ToDecimal(reader["合計売上金額税抜"]).ToString("#,##0");
                                O_売上消費税.Text = Convert.ToDecimal(reader["合計売上消費税"]).ToString("#,##0");
                                O_合計売上金額.Text = Convert.ToDecimal(reader["合計売上金額"]).ToString("#,##0");

                                w_first = false;
                            }

                            DG1.Rows.Add(
                                reader["商品CD"],
                                reader["商品名"],
                                "外税" + reader["消費税率"].ToString() + "%",
                                reader["数量"],
                                reader["単位名"],
                                reader["売上単価"],
                                reader["売上金額"],
                                reader["明細備考"],
                                reader["完納区分"],
                                reader["見積ID"],
                                reader["見積NO"],
                                reader["受注ID"],
                                reader["受注NO"],
                                reader["売上ID"],
                                reader["売上単価税抜"],
                                reader["売上単価消費税"],
                                reader["売上金額税抜"]
                            );

                            DG1.EndEdit();

                        }
                        if (w_first)
                        {
                            if (C_処理区分.SelectedIndex != 0) // 0:登録
                            {
                                MessageBox.Show(
                                   "未登録です",
                                   "警告",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);

                                return false;
                            }
                        }
                    }

                    if (w_Ok)
                    {
                        //排他ロック
                        string Haitasql = @"
                                INSERT INTO Ｆ排他
                                (
                                    オペレータCD,
                                    PROID,
                                    入力種類,
                                    入力NO,
                                    テーブル名,
                                    キー項目_1,
                                    キー項目_2,
                                    キー項目_3,
                                    キー項目_4,
                                    プログラム名,
                                    排他日時,
                                    排他種別
                                )
                                VALUES
                                (
                                    @w_OperatorCD,
                                    @w_TorokuPROID,
                                    @w_NyuSyurui,
                                    @w_NyuNO,
                                    @w_Tablemei,
                                    @w_Key1,
                                    @w_Key2,
                                    @w_Key3,
                                    @w_Key4,
                                    @w_Promei,
                                    @w_HaitaDay,
                                    @w_HaitaSyubetu
                                )";

                        using (SqlCommand Haitacmd = new SqlCommand(Haitasql, conn))
                        {
                            Haitacmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);
                            Haitacmd.Parameters.AddWithValue("@w_TorokuPROID", m_TorokuPROID);
                            Haitacmd.Parameters.AddWithValue("@w_NyuSyurui", 3); // 3:売上
                            Haitacmd.Parameters.AddWithValue("@w_NyuNO", G_売上NO.Text);
                            Haitacmd.Parameters.AddWithValue("@w_Tablemei", "Ｄ売上ヘッダー");
                            Haitacmd.Parameters.AddWithValue("@w_Key1", G_売上NO.Text);
                            Haitacmd.Parameters.AddWithValue("@w_Key2", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key3", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key4", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Promei", "売上入力");
                            Haitacmd.Parameters.AddWithValue("@w_HaitaDay", DateTime.Now);
                            Haitacmd.Parameters.AddWithValue("@w_HaitaSyubetu", 0);
                            Haitacmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            //締処理済みの場合は全てロック
            if (w_Ok)
            {
                if (!F_SeiSNCheck())
                {
                    w_Ok = false;
                }
            }

            //画面のロック
            //売上金額のロック
            if (DG1.Rows.Count > 0)
            {
                for (int w_Row = 0; w_Row < DG1.Rows.Count; w_Row++)
                {
                    if (Convert.ToInt32(DG1.Rows[w_Row].Cells["売上単価"].Value ?? 0) != 0)
                    {
                        Color w_ReadOnlyColor = Color.FromArgb(255, 255, 192);
                        DG1.Rows[w_Row].Cells["売上金額"].Style.BackColor = w_ReadOnlyColor;
                        DG1.Rows[w_Row].Cells["売上金額"].ReadOnly = true;
                    }
                }
            }
            //画面のロック制御
            if (C_処理区分.SelectedIndex == 2 || w_Ok == false) // 2:削除
            {
                F_AllLock(0);
            }
            else
            {
                F_AllLock(1);
            }

            return w_Ok;
        }
        #endregion

        #region F_DispMeisai / 商品CD入力時の処理
        /// <summary>
        /// 商品CD入力時の処理
        /// </summary>
        private void F_DispMeisai(int i_Row, string i_SyoCD, string i_Col)
        {
            if (i_SyoCD != "")
            {
                DG1.Rows[i_Row].Cells["商品CD"].Value = i_SyoCD.PadLeft(10, '0');
            }
            else
            {
                return;
            }

            if (i_Col == "商品CD")
            {
                if (i_SyoCD != "")
                {
                    using (SqlConnection conn = new SqlConnection(Common.DB))
                    {
                        conn.Open();

                        string sql = @"
                         SELECT *
                         FROM Ｍ商品
                         WHERE 商品CD = @SyoCD";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue(
                            "@SyoCD",
                             DG1.Rows[i_Row].Cells["商品CD"].Value);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    DG1.Rows[i_Row].Cells["商品名"].Value = reader["商品名"];
                                    DG1.Rows[i_Row].Cells["税率"].Value = "外税" + reader["消費税率"] + "%";
                                    DG1.Rows[i_Row].Cells["単位"].Value = reader["単位名"];
                                    DG1.Rows[i_Row].Cells["売上単価"].Value = reader["単価"];
                                    DG1.Rows[i_Row].Cells["完納"].Value = 1; // 1:完納ON
                                }
                                else
                                {
                                    MessageBox.Show(
                                    "入力されたCDは存在しません",
                                    "警告",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                    m_SyoNULLFLG = true;

                                    DG1.CurrentCell = DG1.Rows[i_Row].Cells["商品CD"];
                                    F_CellClear(i_Row);

                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region F_Update / 売上情報の更新
        /// <summary>
        /// 売上情報を更新する
        /// </summary>
        private bool F_Update()
        {

            bool w_ok = false;

            //売上データの更新
            //共通項目
            Decimal w_UriNO = 0;
            Decimal w_JyuNO = string.IsNullOrWhiteSpace(G_受注NO.Text) ? 0 : decimal.Parse(G_受注NO.Text);
            Decimal w_MitNO = string.IsNullOrWhiteSpace(G_見積NO.Text) ? 0 : decimal.Parse(G_見積NO.Text);
            DateTime w_TorokuDay = DateTime.Now;
            DateTime w_KosinDay = DateTime.Now;

            //ヘッダー項目
            DateTime w_UriDay = DateTime.Parse(D_売上日.Text);
            string w_TokCD = G_得意先CD.Text;
            string w_Tokmei = O_得意先名.Text;
            string w_TokTan = G_得意先担当.Text;
            string w_Tokkeisyo = "御中";
            string w_SeiCD = G_得意先CD.Text;
            string w_TanCD = G_担当者CD.Text;
            string w_Kenmei = G_件名.Text;
            string w_Joken = G_条件.Text;
            string w_Tyumonbango = G_注文番号.Text;
            DateTime w_SeiDay = DateTime.Parse(D_請求計上日.Text);
            int w_NohinsyoSyurui = int.Parse(G_納品書種類.Text);
            int w_SokudenKbn = C_即伝区分.SelectedIndex;
            string w_Biko1 = G_備考1.Text;
            string w_Biko2 = G_備考2.Text;
            string w_Biko3 = G_備考3.Text;
            string w_SouhusakiYubin = "";
            string w_SouhusakiJUsyo1 = "";
            string w_SouhusakiJUsyo2 = "";
            string w_SouhusakiTEL1 = "";
            string w_SouhusakiTEL2 = "";
            string w_SouhusakiFAX = "";
            string w_Souhusakimei = O_得意先名.Text;
            string w_SouhusakiTanmei = G_得意先担当.Text;
            Decimal w_GoukeiUriageKingaku = Decimal.Parse(O_合計売上金額.Text);
            Decimal w_GoukeiUriageKingakuZeinuki = Decimal.Parse(O_フッター売上金額.Text);
            Decimal w_GoukeiUriageSyohizei = Decimal.Parse(O_売上消費税.Text);
            Decimal w_GoukeiUriageGaitaxSyohizei = Decimal.Parse(O_売上消費税.Text);

            //明細項目
            int w_UriNOgyo = 0;
            string w_SyoCD = "";
            string w_Syomei = "";
            int w_Syohizeiritu = 0;
            Decimal w_Suryo = 0;
            string w_Tani = "";
            Decimal w_Uriagetanka = 0;
            Decimal w_Uriagekingaku = 0;
            string w_Meisaibiko = "";
            bool w_KannoFLG = false;
            Decimal w_UriagetankaZeinuki = 0;
            Decimal w_UriagetankaSyohizei = 0;
            Decimal w_UriagekingakuZeinuki = 0;
            Decimal w_JyuID = 0;
            Decimal w_MitID = 0;
            Decimal w_UriID = 0;


            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string sql = @"
                 SELECT *
                 FROM Ｍ得意先
                 WHERE 得意先CD = @TokCD";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@TokCD", w_TokCD);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            w_SouhusakiYubin = reader["郵便番号"].ToString();
                            w_SouhusakiJUsyo1 = reader["住所1"].ToString();
                            w_SouhusakiJUsyo2 = reader["住所2"].ToString();
                            w_SouhusakiTEL1 = reader["TEL1"].ToString();
                            w_SouhusakiTEL2 = reader["TEL2"].ToString();
                            w_SouhusakiFAX = reader["FAX"].ToString();
                        }
                    }
                }

                string Urisql = @"
                 SELECT MAX(売上NO) AS 売上NO
                 FROM Ｄ売上ヘッダー";

                using (SqlCommand cmd = new SqlCommand(Urisql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (C_処理区分.SelectedIndex == 1) // 1:更新
                        {
                            w_UriNO = Decimal.Parse(G_売上NO.Text);
                        }
                        else
                        {
                            w_UriNO = reader["売上NO"] == DBNull.Value ? 1 : Convert.ToDecimal(reader["売上NO"]) + 1;
                        }
                    }
                }

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {
                        // ヘッダー更新処理
                        string sql2;

                        if (C_処理区分.SelectedIndex == 0) // 0:登録
                        {
                            sql2 = @"
                                INSERT INTO Ｄ売上ヘッダー
                                (
                                    売上NO,
                                    売上日,
                                    得意先CD,
                                    得意先名,
                                    得意先担当者名,
                                    得意先敬称,
                                    請求先CD,
                                    担当者CD,
                                    件名,
                                    条件,
                                    注文番号,
                                    請求計上日,
                                    納品書種類,
                                    納品書即伝区分,
                                    備考1,
                                    備考2,
                                    備考3,
                                    送付先郵便番号,
                                    送付先住所1,
                                    送付先住所2,
                                    送付先TEL1,
                                    送付先TEL2,
                                    送付先FAX,
                                    送付先名,
                                    送付先担当者名,
                                    受注NO,
                                    見積NO,
                                    合計売上金額,
                                    合計売上金額税抜,
                                    合計売上消費税,
                                    合計売上外税消費税,
                                    登録PROID,
                                    更新PROID,
                                    登録日時,
                                    更新日時,
                                    オペレータCD
                                )
                                VALUES
                                (
                                    @w_UriNO,
                                    @w_UriDay,
                                    @w_TokCD,
                                    @w_Tokmei,
                                    @w_TokTan,
                                    @w_Tokkeisyo,
                                    @w_SeiCD,
                                    @w_TanCD,
                                    @w_Kenmei,
                                    @w_Joken,
                                    @w_Tyumonbango,
                                    @w_SeiDay,
                                    @w_NohinsyoSyurui,
                                    @w_SokudenKbn,
                                    @w_Biko1,
                                    @w_Biko2,
                                    @w_Biko3,
                                    @w_SouhusakiYubin,
                                    @w_SouhusakiJUsyo1,
                                    @w_SouhusakiJUsyo2,
                                    @w_SouhusakiTEL1,
                                    @w_SouhusakiTEL2,
                                    @w_SouhusakiFAX,
                                    @w_Souhusakimei,
                                    @w_SouhusakiTanmei,
                                    @w_JyuNO,
                                    @w_MitNO,
                                    @w_GoukeiUriageKingaku,
                                    @w_GoukeiUriageKingakuZeinuki,
                                    @w_GoukeiUriageSyohizei,
                                    @w_GoukeiUriageGaitaxSyohizei,
                                    @w_TorokuPROID,
                                    @w_KosinPROID,
                                    @w_TorokuDay,
                                    @w_KosinDay,
                                    @w_OperatorCD
                                )";

                        }
                        else
                        {
                            sql2 = @"
                                UPDATE Ｄ売上ヘッダー
                                SET
                                    売上日 = @w_UriDay,
                                    得意先CD = @w_TokCD,
                                    得意先名 = @w_Tokmei,
                                    得意先担当者名= @w_TokTan,
                                    請求先CD = @w_SeiCD,
                                    担当者CD = @w_TanCD,
                                    件名 = @w_Kenmei,
                                    条件 = @w_Joken,
                                    注文番号 = @w_Tyumonbango,
                                    請求計上日 = @w_SeiDay,
                                    納品書種類 = @w_NohinsyoSyurui,
                                    納品書即伝区分 = @w_SokudenKbn,
                                    備考1 = @w_Biko1,
                                    備考2 = @w_Biko2,
                                    備考3 = @w_Biko3,
                                    送付先郵便番号 = @w_SouhusakiYubin,
                                    送付先住所1 = @w_SouhusakiJUsyo1,
                                    送付先住所2 = @w_SouhusakiJUsyo2,
                                    送付先TEL1 = @w_SouhusakiTEL1,
                                    送付先TEL2 = @w_SouhusakiTEL2,
                                    送付先FAX = @w_SouhusakiFAX,
                                    送付先名 = @w_Souhusakimei,
                                    送付先担当者名 = @w_SouhusakiTanmei,
                                    受注NO = @w_JyuNO,
                                    見積NO = @w_MitNO,
                                    合計売上金額 = @w_GoukeiUriageKingaku,
                                    合計売上金額税抜 = @w_GoukeiUriageKingakuZeinuki,
                                    合計売上消費税 = @w_GoukeiUriageSyohizei,
                                    合計売上外税消費税 = @w_GoukeiUriageGaitaxSyohizei,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                                WHERE 売上NO = @w_UriNO";
                        }

                        using (SqlCommand cmd = new SqlCommand(sql2, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@w_UriNO", w_UriNO);
                            cmd.Parameters.AddWithValue("@w_UriDay", w_UriDay);
                            cmd.Parameters.AddWithValue("@w_TokCD", w_TokCD);
                            cmd.Parameters.AddWithValue("@w_Tokmei", w_Tokmei);
                            cmd.Parameters.AddWithValue("@w_TokTan", F_DBValue(w_TokTan));
                            cmd.Parameters.AddWithValue("@w_Tokkeisyo", F_DBValue(w_Tokkeisyo));
                            cmd.Parameters.AddWithValue("@w_SeiCD", w_SeiCD);
                            cmd.Parameters.AddWithValue("@w_TanCD", w_TanCD);
                            cmd.Parameters.AddWithValue("@w_Kenmei", F_DBValue(w_Kenmei));
                            cmd.Parameters.AddWithValue("@w_Joken", F_DBValue(w_Joken));
                            cmd.Parameters.AddWithValue("@w_Tyumonbango", F_DBValue(w_Tyumonbango));
                            cmd.Parameters.AddWithValue("@w_SeiDay", w_SeiDay);
                            cmd.Parameters.AddWithValue("@w_NohinsyoSyurui", w_NohinsyoSyurui);
                            cmd.Parameters.AddWithValue("@w_SokudenKbn", w_SokudenKbn);
                            cmd.Parameters.AddWithValue("@w_Biko1", F_DBValue(w_Biko1));
                            cmd.Parameters.AddWithValue("@w_Biko2", F_DBValue(w_Biko2));
                            cmd.Parameters.AddWithValue("@w_Biko3", F_DBValue(w_Biko3));
                            cmd.Parameters.AddWithValue("@w_SouhusakiYubin", F_DBValue(w_SouhusakiYubin));
                            cmd.Parameters.AddWithValue("@w_SouhusakiJUsyo1", F_DBValue(w_SouhusakiJUsyo1));
                            cmd.Parameters.AddWithValue("@w_SouhusakiJUsyo2", F_DBValue(w_SouhusakiJUsyo2));
                            cmd.Parameters.AddWithValue("@w_SouhusakiTEL1", F_DBValue(w_SouhusakiTEL1));
                            cmd.Parameters.AddWithValue("@w_SouhusakiTEL2", F_DBValue(w_SouhusakiTEL2));
                            cmd.Parameters.AddWithValue("@w_SouhusakiFAX", F_DBValue(w_SouhusakiFAX));
                            cmd.Parameters.AddWithValue("@w_Souhusakimei", F_DBValue(w_Souhusakimei));
                            cmd.Parameters.AddWithValue("@w_SouhusakiTanmei", F_DBValue(w_SouhusakiTanmei));
                            cmd.Parameters.AddWithValue("@w_JyuNO", w_JyuNO);
                            cmd.Parameters.AddWithValue("@w_MitNO", w_MitNO);
                            cmd.Parameters.AddWithValue("@w_GoukeiUriageKingaku", w_GoukeiUriageKingaku);
                            cmd.Parameters.AddWithValue("@w_GoukeiUriageKingakuZeinuki", w_GoukeiUriageKingakuZeinuki);
                            cmd.Parameters.AddWithValue("@w_GoukeiUriageSyohizei", w_GoukeiUriageSyohizei);
                            cmd.Parameters.AddWithValue("@w_GoukeiUriageGaitaxSyohizei", w_GoukeiUriageGaitaxSyohizei);

                            cmd.Parameters.AddWithValue("@w_TorokuPROID", m_TorokuPROID);
                            cmd.Parameters.AddWithValue("@w_KosinPROID", m_KosinPROID);
                            cmd.Parameters.AddWithValue("@w_TorokuDay", w_TorokuDay);
                            cmd.Parameters.AddWithValue("@w_KosinDay", w_KosinDay);
                            cmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);
                            cmd.ExecuteNonQuery();
                        }

                        //明細更新処理                        
                        for (int w_Row = 0; w_Row < DG1.Rows.Count - 1; w_Row++)
                        {

                            object value = DG1.Rows[w_Row].Cells["売上ID"].Value;
                            w_UriID = (value == null || value.ToString() == "") ? 0 : Convert.ToDecimal(value);

                            //w_UriID = DG1.Rows[w_Row].Cells["売上ID"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上ID"].Value) : 0;

                            if (w_UriID == 0) // 売上IDが存在しなければINSERT、いるならUPDATE
                            {
                                sql2 = @"
                                INSERT INTO Ｄ売上明細
                                (
                                    売上NO,
                                    売上NO行,
                                    商品CD,
                                    商品名,
                                    消費税率,
                                    数量,
                                    単位名,
                                    売上単価,
                                    売上金額,
                                    明細備考,
                                    完納区分,
                                    売上単価税抜,
                                    売上単価消費税,
                                    売上金額税抜,
                                    見積ID,
                                    見積NO,
                                    受注ID,
                                    受注NO,                                    
                                    登録PROID,
                                    更新PROID,
                                    登録日時,
                                    更新日時,
                                    オペレータCD
                                )
                                VALUES
                                (
                                    @w_UriNO,
                                    @w_UriNOgyo,
                                    @w_SyoCD,
                                    @w_Syomei,
                                    @w_Syohizeiritu,
                                    @w_Suryo,
                                    @w_Tani,
                                    @w_Uriagetanka,
                                    @w_Uriagekingaku,
                                    @w_Meisaibiko,
                                    @w_KannoFLG,
                                    @w_UriagetankaZeinuki,
                                    @w_UriagetankaSyohizei,
                                    @w_UriagekingakuZeinuki,
                                    @w_JyuID,
                                    @w_JyuNO,
                                    @w_MitID,
                                    @w_MitNO,
                                    @w_TorokuPROID,
                                    @w_KosinPROID,
                                    @w_TorokuDay,
                                    @w_KosinDay,
                                    @w_OperatorCD
                                )";

                            }
                            else
                            {
                                sql2 = @"
                                UPDATE Ｄ売上明細
                                SET
                                    売上NO = @w_UriNO,
                                    売上NO行 = @w_UriNOgyo,
                                    商品CD = @w_SyoCD,
                                    商品名= @w_Syomei,
                                    消費税率= @w_Syohizeiritu,
                                    数量 = @w_Suryo,
                                    単位名 = @w_Tani,
                                    売上単価 = @w_Uriagetanka,
                                    売上金額 = @w_Uriagekingaku,
                                    明細備考 = @w_Meisaibiko,
                                    完納区分 = @w_KannoFLG,
                                    売上単価税抜 = @w_UriagetankaZeinuki,
                                    売上単価消費税 = @w_UriagetankaSyohizei,
                                    売上金額税抜 = @w_UriagekingakuZeinuki,
                                    受注ID = @w_JyuID,
                                    受注NO = @w_JyuNO,
                                    見積ID = @w_MitID,
                                    見積NO = @w_MitNO,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                                WHERE 売上ID = @w_UriID";
                            }

                            w_UriNOgyo = w_UriNOgyo + 1;

                            w_SyoCD = DG1.Rows[w_Row].Cells["商品CD"].Value?.ToString() ?? "";
                            w_Syomei = DG1.Rows[w_Row].Cells["商品名"].Value?.ToString() ?? "";
                            w_Syohizeiritu = 10;
                            w_Suryo = DG1.Rows[w_Row].Cells["数量"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["数量"].Value) : 0;
                            w_Tani = DG1.Rows[w_Row].Cells["単位"].Value?.ToString() ?? "";
                            w_Uriagetanka = DG1.Rows[w_Row].Cells["売上単価"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上単価"].Value) : 0;
                            w_Uriagekingaku = DG1.Rows[w_Row].Cells["売上金額"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上金額"].Value) : 0;
                            w_Meisaibiko = DG1.Rows[w_Row].Cells["明細備考"].Value?.ToString() ?? "";
                            w_KannoFLG = DG1.Rows[w_Row].Cells["完納"].Value != null && Convert.ToBoolean(DG1.Rows[w_Row].Cells["完納"].Value);
                            w_UriagetankaZeinuki = DG1.Rows[w_Row].Cells["売上単価税抜"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上単価税抜"].Value) : 0;
                            w_UriagetankaSyohizei = DG1.Rows[w_Row].Cells["売上単価消費税"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上単価消費税"].Value) : 0;
                            w_UriagekingakuZeinuki = DG1.Rows[w_Row].Cells["売上金額税抜"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["売上金額税抜"].Value) : 0;
                            w_JyuID = DG1.Rows[w_Row].Cells["受注ID"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["受注ID"].Value) : 0;
                            w_JyuNO = DG1.Rows[w_Row].Cells["受注NO"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["受注NO"].Value) : 0;
                            w_MitID = DG1.Rows[w_Row].Cells["見積ID"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["見積ID"].Value) : 0;
                            w_MitNO = DG1.Rows[w_Row].Cells["見積NO"].Value != null ? Convert.ToDecimal(DG1.Rows[w_Row].Cells["見積NO"].Value) : 0;


                            // 実際の明細行だけ更新する
                            using (SqlCommand cmd = new SqlCommand(sql2, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@w_UriID", w_UriID);
                                cmd.Parameters.AddWithValue("@w_UriNO", w_UriNO);
                                cmd.Parameters.AddWithValue("@w_UriNOgyo", w_UriNOgyo);
                                cmd.Parameters.AddWithValue("@w_SyoCD", w_SyoCD);
                                cmd.Parameters.AddWithValue("@w_Syomei", w_Syomei);
                                cmd.Parameters.AddWithValue("@w_Syohizeiritu", w_Syohizeiritu);
                                cmd.Parameters.AddWithValue("@w_Suryo", w_Suryo);
                                cmd.Parameters.AddWithValue("@w_Tani", F_DBValue(w_Tani));
                                cmd.Parameters.AddWithValue("@w_Uriagetanka", w_Uriagetanka);
                                cmd.Parameters.AddWithValue("@w_Uriagekingaku", w_Uriagekingaku);
                                cmd.Parameters.AddWithValue("@w_Meisaibiko", F_DBValue(w_Meisaibiko));
                                cmd.Parameters.AddWithValue("@w_KannoFLG", w_KannoFLG);
                                cmd.Parameters.AddWithValue("@w_UriagetankaZeinuki", w_UriagetankaZeinuki);
                                cmd.Parameters.AddWithValue("@w_UriagetankaSyohizei", w_UriagetankaSyohizei);
                                cmd.Parameters.AddWithValue("@w_UriagekingakuZeinuki", w_UriagekingakuZeinuki);
                                cmd.Parameters.AddWithValue("@w_JyuID", w_JyuID);
                                cmd.Parameters.AddWithValue("@w_JyuNO", w_JyuNO);
                                cmd.Parameters.AddWithValue("@w_MitID", w_MitID);
                                cmd.Parameters.AddWithValue("@w_MitNO", w_MitNO);
                                cmd.Parameters.AddWithValue("@w_TorokuPROID", m_TorokuPROID);
                                cmd.Parameters.AddWithValue("@w_KosinPROID", m_KosinPROID);
                                cmd.Parameters.AddWithValue("@w_TorokuDay", w_TorokuDay);
                                cmd.Parameters.AddWithValue("@w_KosinDay", w_KosinDay);
                                cmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        // 正常終了なら確定
                        tran.Commit();
                        DG1.EndEdit();
                        w_ok = true;
                    }
                    catch
                    {
                        // エラーなら取り消し
                        tran.Rollback();
                        DG1.EndEdit();
                        w_ok = false;

                        throw;
                    }
                }
            }
            return w_ok;
        }

        #endregion

        #region F_Delete / 売上情報の削除
        /// <summary>
        /// 売上情報の削除
        /// </summary>
        private void F_Delete()
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {

                        string sql = @"
                         DELETE 
                         FROM Ｄ売上明細
                         WHERE 売上NO = @UriageNO";

                        //デバッグ用
                        string w_DebugSQL =
                        $"SELECT COUNT(*) FROM Ｄ売上明細 WHERE 売上NO = '{G_売上NO.Text}'";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UriageNO",
                                G_売上NO.Text);

                            cmd.ExecuteNonQuery();
                        }

                        sql = @"
                         DELETE 
                         FROM Ｄ売上ヘッダー
                         WHERE 売上NO = @UriageNO";

                        //デバッグ用
                        w_DebugSQL =
                        $"SELECT COUNT(*) FROM Ｄ売上ヘッダー WHERE 売上NO = '{G_売上NO.Text}'";

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue(
                                "@UriageNO",
                                G_売上NO.Text);

                            cmd.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        #endregion

        #region F_DeleteHaita / 排他情報の削除
        /// <summary>
        /// 排他情報の削除
        /// </summary>
        private void F_DeleteHaita(decimal i_UriNO)
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                //オペレータCDも条件に入れなければならないが、オペレータが複数人いる想定の設計にしていないため未実装とする
                string sql = @"
                   DELETE 
                   FROM Ｆ排他
                   WHERE 入力NO = @UriageNO
                     AND 入力種類 = 3";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@UriageNO",
                        i_UriNO);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region F_Close / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void D030_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!m_CloseFLG)
            {
                if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //排他情報の削除
                    if (!string.IsNullOrWhiteSpace(G_売上NO.Text))
                    {
                        F_DeleteHaita(Decimal.Parse(G_売上NO.Text));
                    }
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
                //排他情報の削除
                if (!string.IsNullOrWhiteSpace(G_売上NO.Text))
                {
                    F_DeleteHaita(Decimal.Parse(G_売上NO.Text));
                }
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
        /// 2:売上NO入力時
        /// </param>
        /// </summary>
        private void F_InitializeInput(int i_Kbn)
        {

            //排他情報の削除
            if (!string.IsNullOrWhiteSpace(G_売上NO.Text) && !m_FormLoadFLG && i_Kbn != 2)
            {
                F_DeleteHaita(Decimal.Parse(G_売上NO.Text));
            }

            if (i_Kbn == 0)
            {
                C_処理区分.SelectedIndex = 0; // 0:登録
            }

            if (i_Kbn == 1)
            {

            }

            if (i_Kbn != 2)
            {
                G_売上NO.Text = "";
                m_UriNOOld = 0;
            }

            G_受注NO.Text = "";
            G_見積NO.Text = "";
            G_得意先CD.Text = "";
            O_得意先名.Text = "";
            G_得意先担当.Text = "";
            G_担当者CD.Text = "";
            O_担当者名.Text = "";
            G_件名.Text = "";
            G_条件.Text = "";
            G_注文番号.Text = "";
            C_即伝区分.SelectedIndex = 0; // 0:入力時発行
            G_備考1.Text = "";
            G_備考2.Text = "";
            G_備考3.Text = "";
            O_フッター売上金額.Text = "";
            O_売上消費税.Text = "";
            O_合計売上金額.Text = "";

            DG1.Rows.Clear();

            DG1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            DG1.EndEdit();
            this.ActiveControl = null;

            B_Key04.Enabled = false;

            m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
        }
        #endregion

        #region F_CellClear / 明細画面のクリア
        /// <summary>
        /// 画面のクリア
        /// </summary>
        private void F_CellClear(int i_Row)
        {
            DG1.Rows[i_Row].Cells["商品CD"].Value = "";
            DG1.Rows[i_Row].Cells["商品名"].Value = "";
            DG1.Rows[i_Row].Cells["税率"].Value = "";
            DG1.Rows[i_Row].Cells["数量"].Value = "";
            DG1.Rows[i_Row].Cells["単位"].Value = "";
            DG1.Rows[i_Row].Cells["売上単価"].Value = "";
            DG1.Rows[i_Row].Cells["売上金額"].Value = "";
            DG1.Rows[i_Row].Cells["明細備考"].Value = "";
            DG1.Rows[i_Row].Cells["完納"].Value = 0;
            DG1.Rows[i_Row].Cells["受注ID"].Value = 0;
            DG1.Rows[i_Row].Cells["受注NO"].Value = 0;
            DG1.Rows[i_Row].Cells["見積ID"].Value = 0;
            DG1.Rows[i_Row].Cells["見積NO"].Value = 0;
            DG1.Rows[i_Row].Cells["売上単価税抜"].Value = 0;
            DG1.Rows[i_Row].Cells["売上単価消費税"].Value = 0;
            DG1.Rows[i_Row].Cells["売上金額税抜"].Value = 0;
        }
        #endregion

        #region F_Check / 入力内容チェック
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        private bool F_Check()
        {
            bool w_ok = true;

            //必須項目のチェック
            if (C_処理区分.SelectedIndex != 0) // 0:登録
            {
                if (string.IsNullOrWhiteSpace(G_売上NO.Text))
                {
                    MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    G_売上NO.Focus();
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(G_得意先CD.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_得意先CD.Focus();
                return false;
            }
            else
            {
                w_ok = F_SeiSNCheck();

                if (!w_ok)
                {
                    return false;
                }
                else if (D_請求計上日.Value < D_売上日.Value)
                {
                    MessageBox.Show(
                        "請求計上日は売上日以降の日付を入力してください",
                        "警告",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    D_請求計上日.Focus();
                    return false;
                }
            }
            if (string.IsNullOrWhiteSpace(G_担当者CD.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_担当者CD.Focus();
                return false;
            }

            if (DG1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
            {
                MessageBox.Show("更新対象明細がありません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_得意先CD.Focus();
                return false;
            }
            for (int row = 0; row < DG1.Rows.Count - 1; row++)
            {
                if (string.IsNullOrWhiteSpace(DG1.Rows[row].Cells["数量"].Value?.ToString()))
                {
                    MessageBox.Show("数量を入力してください", "警告",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    DG1.CurrentCell = DG1.Rows[row].Cells["数量"];
                    DG1.BeginEdit(true);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region F_SeiSNCheck / 請求計上日チェック
        /// <summary>
        /// 請求計上日チェック
        /// </param>
        /// </summary>
        private bool F_SeiSNCheck()
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                string sql = @"
                     SELECT *
                     FROM Ｍ得意先
                     WHERE 得意先CD = @TokuisakiCD";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TokuisakiCD",
                        G_得意先CD.Text);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DateTime? w_SeiSN = reader["前回請求締年月日"] == DBNull.Value ? null : Convert.ToDateTime(reader["前回請求締年月日"]);

                            if (!w_SeiSN.HasValue)
                            {
                                return true;
                            }
                            else if (D_請求計上日.Value < w_SeiSN)
                            {
                                MessageBox.Show("前回請求締年月日以前の日付(" + Convert.ToDateTime(w_SeiSN).ToString("yyyy/MM/dd") + ")は入力できません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                D_請求計上日.Focus();
                                return false;
                            }
                        }
                    }
                }

            }

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

            Color w_ReadOnlyColor = Color.FromArgb(255, 255, 192);  // Lock
            Color w_ReadOnlyColor2 = Color.White;                   // UnLock

            if (i_Kbn == 0) // Lock
            {
                D_売上日.BackColor = w_ReadOnlyColor;
                D_請求計上日.BackColor = w_ReadOnlyColor;
                G_受注NO.BackColor = w_ReadOnlyColor;
                G_見積NO.BackColor = w_ReadOnlyColor;
                G_得意先CD.BackColor = w_ReadOnlyColor;
                G_得意先担当.BackColor = w_ReadOnlyColor;
                G_担当者CD.BackColor = w_ReadOnlyColor;
                G_件名.BackColor = w_ReadOnlyColor;
                G_条件.BackColor = w_ReadOnlyColor;
                G_注文番号.BackColor = w_ReadOnlyColor;
                C_即伝区分.BackColor = w_ReadOnlyColor;
                G_備考1.BackColor = w_ReadOnlyColor;
                G_備考2.BackColor = w_ReadOnlyColor;
                G_備考3.BackColor = w_ReadOnlyColor;

                D_売上日.Enabled = false;
                D_請求計上日.Enabled = false;
                G_受注NO.ReadOnly = true;
                G_見積NO.ReadOnly = true;
                G_得意先CD.ReadOnly = true;
                G_得意先担当.ReadOnly = true;
                G_担当者CD.ReadOnly = true;
                G_件名.ReadOnly = true;
                G_条件.ReadOnly = true;
                G_注文番号.ReadOnly = true;
                C_即伝区分.Enabled = false;
                G_備考1.ReadOnly = true;
                G_備考2.ReadOnly = true;
                G_備考3.ReadOnly = true;

                DG1.DefaultCellStyle.BackColor = w_ReadOnlyColor;
                DG1.ReadOnly = true;
            }
            else // UnLock
            {
                if (C_処理区分.SelectedIndex == 0) //0:登録
                {
                    G_売上NO.BackColor = w_ReadOnlyColor;
                    G_受注NO.BackColor = w_ReadOnlyColor2;
                    G_見積NO.BackColor = w_ReadOnlyColor2;

                    G_売上NO.ReadOnly = true;
                    G_受注NO.ReadOnly = false;
                    G_見積NO.ReadOnly = false;
                }
                else
                {
                    G_売上NO.BackColor = w_ReadOnlyColor2;
                    G_受注NO.BackColor = w_ReadOnlyColor;
                    G_見積NO.BackColor = w_ReadOnlyColor;

                    G_売上NO.ReadOnly = false;
                    G_受注NO.ReadOnly = true;
                    G_見積NO.ReadOnly = true;
                }

                D_売上日.BackColor = w_ReadOnlyColor2;
                D_請求計上日.BackColor = w_ReadOnlyColor2;
                G_得意先CD.BackColor = w_ReadOnlyColor2;
                G_得意先担当.BackColor = w_ReadOnlyColor2;
                G_担当者CD.BackColor = w_ReadOnlyColor2;
                G_件名.BackColor = w_ReadOnlyColor2;
                G_条件.BackColor = w_ReadOnlyColor2;
                G_注文番号.BackColor = w_ReadOnlyColor2;
                C_即伝区分.BackColor = w_ReadOnlyColor2;
                G_備考1.BackColor = w_ReadOnlyColor2;
                G_備考2.BackColor = w_ReadOnlyColor2;
                G_備考3.BackColor = w_ReadOnlyColor2;

                D_売上日.Enabled = true;
                D_請求計上日.Enabled = true;
                G_得意先CD.ReadOnly = false;
                G_得意先担当.ReadOnly = false;
                G_担当者CD.ReadOnly = false;
                G_件名.ReadOnly = false;
                G_条件.ReadOnly = false;
                G_注文番号.ReadOnly = false;
                C_即伝区分.Enabled = true;
                G_備考1.ReadOnly = false;
                G_備考2.ReadOnly = false;
                G_備考3.ReadOnly = false;

                DG1.DefaultCellStyle.BackColor = w_ReadOnlyColor2;
                DG1.ReadOnly = false;
                DG1.Columns["商品名"].DefaultCellStyle.BackColor = w_ReadOnlyColor;
                DG1.Columns["税率"].DefaultCellStyle.BackColor = w_ReadOnlyColor;
                DG1.Columns["商品名"].ReadOnly = true;
                DG1.Columns["税率"].ReadOnly = true;
            }

        }
        #endregion

        #region F_Gokei / ヘッダー部合計金額算出
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        private void F_Gokei()
        {
            Decimal w_UriageTanka = 0;
            Decimal w_UriageSyohizei = 0;
            Decimal w_UriageKingaku = 0;


            for (int w_Row = 0; w_Row < DG1.Rows.Count - 1; w_Row++)
            {
                String w_Uri = DG1.Rows[w_Row].Cells["売上金額"].Value?.ToString() ?? "";
                w_UriageTanka += decimal.TryParse(w_Uri, out decimal kingaku) ? kingaku : 0;
            }

            O_フッター売上金額.Text = w_UriageTanka.ToString("#,##0");
            w_UriageSyohizei = Math.Round(w_UriageTanka * 0.1m, 0, MidpointRounding.AwayFromZero);
            O_売上消費税.Text = w_UriageSyohizei.ToString("#,##0");
            w_UriageKingaku = w_UriageTanka + w_UriageSyohizei;
            O_合計売上金額.Text = w_UriageKingaku.ToString("#,##0");
        }
        #endregion

        #region F_Key012Syori / F12キー押下時の処理
        /// <summary>
        /// F12キー押下時の処理
        /// </summary>
        private bool F_Key012Syori()
        {

            bool w_ok = false;

            string w_SyoriKbn = C_処理区分.Text.Split(':').Last();

            if (MessageBox.Show(w_SyoriKbn + "しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (C_処理区分.SelectedIndex == 0 || C_処理区分.SelectedIndex == 1) // 0:登録 1:変更
                {
                    if (F_Update() == true)
                    {
                        B_Key12.Enabled = true;
                        w_ok = true;
                    }
                    else
                    {
                        B_Key12.Enabled = false;
                        w_ok = false;
                    }
                }
                else if (C_処理区分.SelectedIndex == 2) // 2:削除
                {
                    F_Delete();
                    return true;
                }
            }

            return w_ok;
        }
        #endregion

        #region F_Search / 検索画面の表示
        /// <summary>
        /// 検索画面の表示
        /// </summary>
        private void F_Search()
        {
            if (!m_SeachSyo)
            {
                F_SearchHeader();
            }
            else
            {
                F_SearchSyo();
            }
        }
        #endregion

        #region F_SearchHeader / 検索画面の表示(ヘッダー)
        /// <summary>
        /// 検索画面の表示(ヘッダー)
        /// </summary>
        private void F_SearchHeader()
        {
            if (m_SeachUri == true)
            {
                using (SD030 frm = new SD030())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        G_売上NO.Text = frm.w_売上NO;
                        G_売上NO_Validating(G_売上NO, new System.ComponentModel.CancelEventArgs());
                    }
                }
            }
            if (m_SeachTok == true && G_得意先CD.ReadOnly == false)
            {
                using (SM010 frm = new SM010())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        G_得意先CD.Text = frm.m_得意先CD;
                        G_得意先CD_Validating(G_得意先CD, new System.ComponentModel.CancelEventArgs());
                    }
                }
            }
            if (m_SeachTan == true && G_担当者CD.ReadOnly == false)
            {
                using (SM020 frm = new SM020())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        G_担当者CD.Text = frm.m_担当者CD;
                        G_担当者CD_Validating(G_担当者CD, new System.ComponentModel.CancelEventArgs());
                    }
                }
            }
        }
        #endregion

        #region F_SearchSyo / 検索画面の表示(明細)
        /// <summary>
        /// 検索画面の表示(明細)
        /// </summary>
        private void F_SearchSyo()
        {
            int w_Row = DG1.CurrentCell.RowIndex;
            if (m_SeachSyo == true && DG1.Rows[w_Row].Cells["商品CD"].ReadOnly == false)
            {
                using (SM030 frm = new SM030())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        DG1.Rows[w_Row].Cells["商品CD"].Value = frm.m_商品CD;
                        F_DispMeisai(w_Row, frm.m_商品CD, "商品CD");
                    }
                }
            }
        }
        #endregion

        #region F_DBValue / DBのNULLの制御
        /// <summary>
        /// DBのNULLの制御
        /// </summary>
        private object F_DBValue(string? text)
        {
            return string.IsNullOrWhiteSpace(text) ? DBNull.Value : text;
        }
        #endregion

        #endregion

    }
}
