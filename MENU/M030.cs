using Microsoft.Data.SqlClient;
using System.Collections;

namespace customerApp
{
    public partial class M030 : Form
    {

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
        private string m_SyoCDOld = "";
        private string m_SyomeiOld = "";
        private int m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
        private bool m_SelectAll = false;
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

        #endregion

        #region プライベート定数

        #region PROID
        /// <summary>
        /// PROID
        /// </summary>
        private string m_TorokuPROID = "M030";
        private string m_KosinPROID = "M030";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public M030()
        {
            InitializeComponent();
        }
        #endregion

        #region M030_Load /　フォームロード
        /// <summary>
        /// M030_Load /　フォームロード
        /// </summary>
        private void M030_Load(object sender, EventArgs e)
        {

            m_FormLoadFLG = true;

            //初期値の設定
            F_InitializeInput(0);
            B_Key04.Enabled = false;

            //オペレータCDの設定
#if DEBUG
            m_OperatorCD = "-1";
#else
                m_OperatorCD = "9999";
#endif

            m_FormLoadFLG = false;
        }
        #endregion

        #region イベント関数

        #region G_商品CD_KeyPress /　商品CD入力制御
        /// <summary>
        /// G_商品CD_KeyPress /　商品CD入力制御
        /// </summary>
        private void G_商品CD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
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
        }
        #endregion     

        #region G_商品CD_Validating /　商品CD変更時
        /// <summary>
        /// G_商品CD_Validating /　商品CD変更時
        /// </summary>
        private void G_商品CD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //排他データの削除
            F_DeleteHaita(m_SyoCDOld);

            string w_TokCD = G_商品CD.Text;
            if (G_商品CD.Text != "")
            {
                G_商品CD.Text = w_TokCD.PadLeft(10, '0');
            }

            if (G_商品CD.Text != m_SyoCDOld && G_商品CD.Text != "")
            {

                m_SyoCDOld = G_商品CD.Text;

                if (F_Disp())
                {
                    B_Key12.Enabled = true;
                }
                else
                {
                    B_Key12.Enabled = false;
                }
            }
        }
        #endregion

        #region G_商品名_Validating /　商品名変更時
        /// <summary>
        /// G_商品名_Validaiting /　商品名変更時
        /// </summary>
        private void G_商品名_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //if (G_商品名.Text != m_SyomeiOld)
            //{
            //    O_商品名.Text = G_商品名.Text;
            //    m_SyomeiOld = G_商品名.Text;
            //}
            O_商品名.Text = G_商品名.Text;
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
        /// B_Key03_Click /　F1押下時
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
            using (SM030 frm = new SM030())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    G_商品CD.Text = frm.m_商品CD;
                    G_商品CD_Validating(G_商品CD, new System.ComponentModel.CancelEventArgs());
                }
            }
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
                G_商品CD.Focus();
            }
        }
        #endregion

        #region B_Key_KeyDown /　ファンクション押下時
        /// <summary>
        /// B_Key_KeyDown /　ファンクション押下時
        /// </summary>
        private void MHE010_KeyDown(object sender, KeyEventArgs e)
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
                    using (SM030 frm = new SM030())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            G_商品CD.Text = frm.m_商品CD;
                            G_商品CD_Validating(G_商品CD, new System.ComponentModel.CancelEventArgs());
                        }
                    }
                    break;

                case Keys.F12:
                    if (F_Check())
                    {
                        if (F_Key012Syori() == true)
                        {
                            F_InitializeInput(1);
                            G_商品CD.Focus();
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
            if (sender == G_商品CD)
            {
                B_Key04.Enabled = true;
            }
            else
            {
                B_Key04.Enabled = false;
            }

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
            // 次に押したのが F4 ボタンなら有効のまま
            if (this.ActiveControl != B_Key04)
            {
                B_Key04.Enabled = false;
            }

            m_SelectAll = false;
        }
        #endregion

        #endregion

        #region ■関数

        #region F_Disp / 商品情報の表示
        /// <summary>
        /// 商品情報を表示する
        /// </summary>
        private bool F_Disp()
        {
            bool w_Ok = true;

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                //排他チェック用SQL
                string HaitaChecksql = @"
                 SELECT *
                 FROM Ｆ排他 FHTA WITH(NOLOCK)
                 WHERE FHTA.キー項目_1 = @SyoCD";

                //商品データ用SQL
                string sql = @"
                 SELECT *
                 FROM Ｍ商品
                 WHERE 商品CD = @SyoCD";

                //商品データ確認用SQL
                string w_DebugSQL =
                $"SELECT COUNT(*) FROM Ｍ商品 WHERE 商品CD = '{G_商品CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(HaitaChecksql, conn))
                {
                    cmd.Parameters.AddWithValue("@SyoCD", G_商品CD.Text);

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
                    cmd.Parameters.AddWithValue(
                        "@SyoCD",
                        G_商品CD.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            if (C_処理区分.SelectedIndex == 0) // 0:登録
                            {
                                MessageBox.Show(
                                    "登録済みです",
                                    "警告",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);

                                F_AllLock(0);
                                G_商品CD.Focus();

                                w_Ok = false;
                            }

                            //G_商品CDの内容を画面に表示
                            O_商品名.Text = reader["商品名"].ToString();
                            G_商品名.Text = reader["商品名"].ToString();
                            G_単位名.Text = reader["単位名"].ToString();

                            if (reader["消費税率"].ToString() == "8")
                            {
                                C_消費税率.SelectedIndex = 0; // 0:8%
                            }
                            else
                            {
                                C_消費税率.SelectedIndex = 1; // 1:10%
                            }


                            N_単価.Text = reader["単価"].ToString();
                            G_備考.Text = reader["備考"].ToString();
                        }
                        else
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
                            else
                            {
                                F_AllLock(1);
                                F_InitializeInput(2);
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
                            Haitacmd.Parameters.AddWithValue("@w_NyuSyurui", 0);
                            Haitacmd.Parameters.AddWithValue("@w_NyuNO", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Tablemei", "Ｍ商品");
                            Haitacmd.Parameters.AddWithValue("@w_Key1", G_商品CD.Text);
                            Haitacmd.Parameters.AddWithValue("@w_Key2", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key3", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key4", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Promei", "商品マスタ");
                            Haitacmd.Parameters.AddWithValue("@w_HaitaDay", DateTime.Now);
                            Haitacmd.Parameters.AddWithValue("@w_HaitaSyubetu", 0);
                            Haitacmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            //画面のロック
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

        #region F_Update / 商品情報の更新
        /// <summary>
        /// 商品情報を更新する
        /// </summary>
        private bool F_Update()
        {

            bool w_ok = false;

            string w_SyoCD = G_商品CD.Text;
            string w_Syomei = G_商品名.Text;
            string w_Tani = G_単位名.Text;
            int w_Syohizei = C_消費税率.SelectedIndex;
            int w_Tanka = (int)N_単価.Value;
            string w_Biko = G_備考.Text;
            DateTime w_TorokuDay = DateTime.Now;
            DateTime w_KosinDay = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    try
                    {

                        string sql;

                        if (C_処理区分.SelectedIndex == 0) // 0:登録
                        {
                            sql = @"
                                INSERT INTO Ｍ商品
                                (
                                    商品CD,
                                    商品名,
                                    単位名,
                                    消費税率,
                                    単価,
                                    備考,
                                    登録PROID,
                                    更新PROID,
                                    登録日時,
                                    更新日時,
                                    オペレータCD
                                )
                                VALUES
                                (
                                    @w_SyoCD,
                                    @w_Syomei,
                                    @w_Tani,
                                    @w_Syohizei,
                                    @w_Tanka,
                                    @w_Biko,
                                    @w_TorokuPROID,
                                    @w_KosinPROID,
                                    @w_TorokuDay,
                                    @w_KosinDay,
                                    @w_OperatorCD
                                )";

                        }
                        else
                        {
                            sql = @"
                                UPDATE Ｍ商品
                                SET
                                    商品名 = @w_Syomei,
                                    単位名 = @w_Tani,
                                    消費税率 = @w_Syohizei,
                                    単価 = @w_Tanka,
                                    備考 = @w_Biko,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                                WHERE 商品CD = @w_SyoCD";
                        }

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@w_SyoCD", w_SyoCD);
                            cmd.Parameters.AddWithValue("@w_Syomei", w_Syomei);
                            cmd.Parameters.AddWithValue("@w_Tani", F_DBValue(w_Tani));

                            if (w_Syohizei == 0)
                            {
                                w_Syohizei = 8;
                            }
                            else
                            {
                                w_Syohizei = 10;
                            }
                            cmd.Parameters.AddWithValue("@w_Syohizei", w_Syohizei);

                            cmd.Parameters.AddWithValue("@w_Tanka", w_Tanka);
                            cmd.Parameters.AddWithValue("@w_Biko", F_DBValue(w_Biko));
                            cmd.Parameters.AddWithValue("@w_TorokuPROID", m_TorokuPROID);
                            cmd.Parameters.AddWithValue("@w_KosinPROID", m_KosinPROID);
                            cmd.Parameters.AddWithValue("@w_TorokuDay", w_TorokuDay);
                            cmd.Parameters.AddWithValue("@w_KosinDay", w_KosinDay);
                            cmd.Parameters.AddWithValue("@w_OperatorCD", m_OperatorCD);
                            cmd.ExecuteNonQuery();
                        }

                        // 正常終了なら確定
                        tran.Commit();
                        w_ok = true;
                    }
                    catch
                    {
                        // エラーなら取り消し
                        tran.Rollback();
                        w_ok = false;

                        throw;
                    }
                }
            }

            return w_ok;
        }

        #endregion

        #region F_Delete / 商品情報の削除
        /// <summary>
        /// 商品情報の削除
        /// </summary>
        private void F_Delete()
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                string sql = @"
                 DELETE 
                 FROM Ｍ商品
                 WHERE 商品CD = @SyoCD";

                //デバッグ用
                string w_DebugSQL =
                $"SELECT COUNT(*) FROM Ｍ商品 WHERE 商品CD = '{G_商品CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@SyoCD",
                        G_商品CD.Text);

                    cmd.ExecuteNonQuery();
                }

            }
        }
        #endregion

        #region F_DeleteHaita / 排他情報の削除
        /// <summary>
        /// 排他情報の削除
        /// </summary>
        private void F_DeleteHaita(string i_MsyoCD)
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                //オペレータCDも条件に入れなければならないが、オペレータが複数人いる想定の設計にしていないため未実装とする
                string sql = @"
                   DELETE 
                   FROM Ｆ排他
                   WHERE キー項目_1 = @MSyoCD";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MSyoCD",
                        i_MsyoCD);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region M030_FormClosing / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void M030_Closing(object? sender, FormClosingEventArgs e)
        {
            if (!m_CloseFLG)
            {
                if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //排他情報の削除
                    if (!string.IsNullOrWhiteSpace(G_商品CD.Text))
                    {
                        F_DeleteHaita(G_商品CD.Text);
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
                if (!string.IsNullOrWhiteSpace(G_商品CD.Text))
                {
                    F_DeleteHaita(G_商品CD.Text);
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
        /// 2:商品CD入力時
        /// </param>
        /// </summary>
        private void F_InitializeInput(int i_Kbn)
        {
            //排他情報の削除
            if (!string.IsNullOrWhiteSpace(G_商品CD.Text) && !m_FormLoadFLG && i_Kbn != 2)
            {
                F_DeleteHaita(G_商品CD.Text);
            }

            if (i_Kbn == 0)
            {
                C_処理区分.SelectedIndex = 0; // 0:登録
            }

            if (i_Kbn != 2)
            {
                G_商品CD.Text = "";

                m_SyoCDOld = "";
                m_SyomeiOld = "";
                m_SyoriKbnOld = 9;  //登録～照会以外の区分を設定
            }
            O_商品名.Text = "";

            G_商品名.Text = "";
            G_単位名.Text = "";
            C_消費税率.SelectedIndex = 1; // 1:10%
            N_単価.Text = "";
            G_備考.Text = "";
        }
        #endregion

        #region F_Check / 入力内容チェック
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        private bool F_Check()
        {
            //必須項目のチェック
            if (string.IsNullOrWhiteSpace(G_商品CD.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_商品CD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(G_商品名.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_商品名.Focus();
                return false;
            }

            //商品CDの重複チェック
            if (C_処理区分.SelectedIndex == 0) // 0:登録
            {
                using (SqlConnection conn = new SqlConnection(Common.DB))
                {
                    conn.Open();

                    string sql = @"
                     SELECT COUNT(*)
                     FROM Ｍ商品
                     WHERE 商品CD = @SyoCD";

                    //デバッグ用
                    string w_DebugSQL =
                    $"SELECT COUNT(*) FROM Ｍ商品 WHERE 商品CD = '{G_商品CD.Text}'";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@SyoCD",
                            G_商品CD.Text);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show(
                                "登録済みです",
                                "警告",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            F_Disp();
                            F_AllLock(0);

                            G_商品CD.Focus();
                            return false;
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

                G_商品名.BackColor = w_ReadOnlyColor;
                G_単位名.BackColor = w_ReadOnlyColor;
                C_消費税率.BackColor = w_ReadOnlyColor;
                N_単価.BackColor = w_ReadOnlyColor;
                G_備考.BackColor = w_ReadOnlyColor;

                G_商品名.ReadOnly = true;
                G_単位名.ReadOnly = true;
                N_単価.Enabled = false;
                G_備考.ReadOnly = true;
            }
            else // UnLock
            {
                G_商品CD.BackColor = w_ReadOnlyColor2;
                G_商品名.BackColor = w_ReadOnlyColor2;
                G_単位名.BackColor = w_ReadOnlyColor2;
                C_消費税率.BackColor = w_ReadOnlyColor2;
                N_単価.BackColor = w_ReadOnlyColor2;
                G_備考.BackColor = w_ReadOnlyColor2;

                G_商品CD.ReadOnly = false;
                G_商品名.ReadOnly = false;
                G_単位名.ReadOnly = false;
                N_単価.Enabled = true;
                G_備考.ReadOnly = false;

            }

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

        #region F_DBValue / DBのNULLの制御
        /// <summary>
        /// DBのNULLの制御
        /// </summary>
        private object F_DBValue(string text)
        {
            return string.IsNullOrWhiteSpace(text) ? DBNull.Value : text;
        }
        #endregion

        #endregion

    }
}
