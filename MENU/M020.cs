using Microsoft.Data.SqlClient;
using System.Collections;

namespace customerApp
{
    public partial class M020 : Form
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
        private string m_TanCDOld = "";
        private string m_TanmeiOld = "";
        private int m_SyoriKbnOld = 9;  //登録～削除以外の区分を設定
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
        private string m_TorokuPROID = "M020";
        private string m_KosinPROID = "M020";
        #endregion

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public M020()
        {
            InitializeComponent();
        }
        #endregion

        #region MHE020_Load /　フォームロード
        /// <summary>
        /// MHE010_Load /　フォームロード
        /// </summary>
        private void MHE020_Load(object sender, EventArgs e)
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

        #region G_担当者CD_KeyPress /　担当者CD入力制御
        /// <summary>
        /// G_担当者CD_KeyPress /　担当者CD入力制御
        /// </summary>
        private void G_担当者CD_KeyPress(object sender, KeyPressEventArgs e)
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
                //if (C_処理区分.SelectedIndex == 1)  // 1:変更
                //{
                //    CB_選択不可FLG.Visible = true;
                //}
                //else
                //{
                //    CB_選択不可FLG.Checked = false;
                //    CB_選択不可FLG.Visible = false;
                //}

                F_InitializeInput(1);
                F_AllLock(1);

                m_SyoriKbnOld = C_処理区分.SelectedIndex;
            }
        }
        #endregion

        #region CB_選択不可FLG_CheckedChanged /　選択不可FLG変更時
        /// <summary>
        /// CB_選択不可FLG_CheckedChanged /　選択不可FLG変更時
        /// </summary>
        private void CB_選択不可FLG_CheckedChanged(object sender, EventArgs e)
        {

            if (CB_選択不可FLG.Checked == true)
            {
                CB_選択不可FLG.ForeColor = Color.Red;
            }
            else
            {
                CB_選択不可FLG.ForeColor = Color.Black;
            }
        }
        #endregion

        #region G_担当者CD_Validating /　担当者CD変更時
        /// <summary>
        /// G_担当者CD_Validating /　担当者CD変更時
        /// </summary>
        private void G_担当者CD_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //排他データの削除
            F_DeleteHaita(m_TanCDOld);

            if (G_担当者CD.Text != m_TanCDOld && G_担当者CD.Text != "")
            {
                string w_TokCD = G_担当者CD.Text;

                m_TanCDOld = G_担当者CD.Text;

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

        #region G_担当者名_Validating /　担当者名変更時
        /// <summary>
        /// G_担当者名_Validaiting /　担当者名変更時
        /// </summary>
        private void G_担当者名_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (G_担当者名.Text != m_TanmeiOld)
            {
                m_TanmeiOld = G_担当者名.Text;
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
            using (SM020 frm = new SM020())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    G_担当者CD.Text = frm.m_担当者CD;
                    G_担当者CD_Validating(G_担当者CD, new System.ComponentModel.CancelEventArgs());
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
                G_担当者CD.Focus();
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
                    using (SM020 frm = new SM020())
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            G_担当者CD.Text = frm.m_担当者CD;
                            G_担当者CD_Validating(G_担当者CD, new System.ComponentModel.CancelEventArgs());
                        }
                    }
                    break;

                case Keys.F12:
                    if (F_Check())
                    {
                        if (F_Key012Syori() == true)
                        {
                            F_InitializeInput(1);
                            G_担当者CD.Focus();
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
            if (sender == G_担当者CD)
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

        #region F_Disp / 担当者情報の表示
        /// <summary>
        /// 担当者情報を表示する
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
                 WHERE FHTA.キー項目_1 = @TantousyaCD";

                //担当者データ用SQL
                string sql = @"
                 SELECT *
                 FROM Ｍ担当者
                 WHERE 担当者CD = @TantousyaCD";

                //担当者データ確認用SQL
                string w_DebugSQL =
                $"SELECT COUNT(*) FROM Ｍ担当者 WHERE 担当者CD = '{G_担当者CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(HaitaChecksql, conn))
                {
                    cmd.Parameters.AddWithValue("@TantousyaCD", G_担当者CD.Text);

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
                        "@TantousyaCD",
                        G_担当者CD.Text);

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
                                G_担当者CD.Focus();

                                w_Ok = false;
                            }

                            //G_担当者CDの内容を画面に表示
                            G_担当者名.Text = reader["担当者名"].ToString();
                            CB_選択不可FLG.Checked = Convert.ToBoolean(reader["選択不可FLG"]);
                            G_郵便番号.Text = reader["郵便番号"].ToString();
                            G_住所1.Text = reader["住所1"].ToString();
                            G_住所2.Text = reader["住所2"].ToString();
                            G_TEL1.Text = reader["TEL1"].ToString();
                            G_TEL2.Text = reader["TEL2"].ToString();
                            G_FAX.Text = reader["FAX"].ToString();
                            G_MAIL.Text = reader["MAIL"].ToString();
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
                            Haitacmd.Parameters.AddWithValue("@w_Tablemei", "Ｍ担当者");
                            Haitacmd.Parameters.AddWithValue("@w_Key1", G_担当者CD.Text);
                            Haitacmd.Parameters.AddWithValue("@w_Key2", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key3", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Key4", 0);
                            Haitacmd.Parameters.AddWithValue("@w_Promei", "担当者マスタ");
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

        #region F_Update / 担当者情報の更新
        /// <summary>
        /// 担当者情報を更新する
        /// </summary>
        private bool F_Update()
        {
            bool w_ok = false;

            int w_TantousyaCD = int.Parse(G_担当者CD.Text);
            string w_Tantousyamei = G_担当者名.Text;
            bool w_SentakuFLG = CB_選択不可FLG.Checked;
            string w_Yubinbango = G_郵便番号.Text;
            string w_Jusyo1 = G_住所1.Text;
            string w_Jusyo2 = G_住所2.Text;
            string w_TEL1 = G_TEL1.Text;
            string w_TEL2 = G_TEL2.Text;
            string w_FAX = G_FAX.Text;
            string w_MAIL = G_MAIL.Text;
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
                                INSERT INTO Ｍ担当者
                                (
                                    担当者CD,
                                    担当者名,
                                    選択不可FLG,
                                    郵便番号,
                                    住所1,
                                    住所2,
                                    TEL1,
                                    TEL2,
                                    FAX,
                                    MAIL,
                                    登録PROID,
                                    更新PROID,
                                    登録日時,
                                    更新日時,
                                    オペレータCD
                                )
                                VALUES
                                (
                                    @w_TantousyaCD,
                                    @w_Tantousyamei,
                                    @w_SentakuFLG,
                                    @w_Yubinbango,
                                    @w_Jusyo1,
                                    @w_Jusyo2,
                                    @w_TEL1,
                                    @w_TEL2,
                                    @w_FAX,
                                    @w_MAIL,
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
                                UPDATE Ｍ担当者
                                SET
                                    担当者名 = @w_Tantousyamei,
                                    選択不可FLG = @w_SentakuFLG,
                                    郵便番号 = @w_Yubinbango,
                                    住所1 = @w_Jusyo1,
                                    住所2 = @w_Jusyo2,
                                    TEL1 = @w_TEL1,
                                    TEL2 = @w_TEL2,
                                    FAX = @w_FAX,
                                    MAIL = @w_MAIL,
                                    更新PROID = @w_KosinPROID,
                                    更新日時 = @w_KosinDay,
                                    オペレータCD = @w_OperatorCD
                                WHERE 担当者CD = @w_TantousyaCD";
                        }

                        using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@w_TantousyaCD", w_TantousyaCD);
                            cmd.Parameters.AddWithValue("@w_Tantousyamei", w_Tantousyamei);
                            cmd.Parameters.AddWithValue("@w_SentakuFLG", w_SentakuFLG);
                            cmd.Parameters.AddWithValue("@w_Yubinbango", F_DBValue(w_Yubinbango));
                            cmd.Parameters.AddWithValue("@w_Jusyo1", F_DBValue(w_Jusyo1));
                            cmd.Parameters.AddWithValue("@w_Jusyo2", F_DBValue(w_Jusyo2));
                            cmd.Parameters.AddWithValue("@w_TEL1", F_DBValue(w_TEL1));
                            cmd.Parameters.AddWithValue("@w_TEL2", F_DBValue(w_TEL2));
                            cmd.Parameters.AddWithValue("@w_FAX", F_DBValue(w_FAX));
                            cmd.Parameters.AddWithValue("@w_MAIL", F_DBValue(w_MAIL));
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

        #region F_Delete / 担当者情報の削除
        /// <summary>
        /// 担当者情報の削除
        /// </summary>
        private void F_Delete()
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                string sql = @"
                 DELETE 
                 FROM Ｍ担当者
                 WHERE 担当者CD = @TantousyaCD";

                //デバッグ用
                string w_DebugSQL =
                $"SELECT COUNT(*) FROM Ｍ担当者 WHERE 担当者CD = '{G_担当者CD.Text}'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@TantousyaCD",
                        G_担当者CD.Text);

                    cmd.ExecuteNonQuery();
                }

            }
        }
        #endregion

        #region F_DeleteHaita / 排他情報の削除
        /// <summary>
        /// 排他情報の削除
        /// </summary>
        private void F_DeleteHaita(string i_MtanCD)
        {
            using (SqlConnection conn = new SqlConnection(Common.DB))
            {

                conn.Open();

                //オペレータCDも条件に入れなければならないが、オペレータが複数人いる想定の設計にしていないため未実装とする
                string sql = @"
                   DELETE 
                   FROM Ｆ排他
                   WHERE キー項目_1 = @MtanCD";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue(
                        "@MtanCD",
                        i_MtanCD);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region M020_FormClosing / 画面の終了
        /// <summary>
        /// 画面の終了
        /// </summary>
        private void M020_Closing(object? sender, FormClosingEventArgs e)
        {
            if (!m_CloseFLG)
            {
                if (MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //排他情報の削除
                    if (!string.IsNullOrWhiteSpace(G_担当者CD.Text))
                    {
                        F_DeleteHaita(G_担当者CD.Text);
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
                if (!string.IsNullOrWhiteSpace(G_担当者CD.Text))
                {
                    F_DeleteHaita(G_担当者CD.Text);
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
        /// 2:担当者CD入力時(登録済みCDが画面に表示されているときの処理)
        /// </param>
        /// </summary>
        private void F_InitializeInput(int i_Kbn)
        {
            //排他情報の削除
            if (!string.IsNullOrWhiteSpace(G_担当者CD.Text) && !m_FormLoadFLG && i_Kbn != 2)
            {
                F_DeleteHaita(G_担当者CD.Text);
            }

            CB_選択不可FLG.Checked = false;

            if (i_Kbn == 0)
            {
                C_処理区分.SelectedIndex = 0; // 0:登録
            }

            if (i_Kbn != 2)
            {
                G_担当者CD.Text = "";

                m_TanCDOld = "";
                m_TanmeiOld = "";
                m_SyoriKbnOld = 9;   //登録～削除以外の区分を設定
            }

            G_担当者名.Text = "";
            G_郵便番号.Text = "";
            G_住所1.Text = "";
            G_住所2.Text = "";
            G_TEL1.Text = "";
            G_TEL2.Text = "";
            G_FAX.Text = "";
            G_MAIL.Text = "";

        }
        #endregion

        #region F_Check / 入力内容チェック
        /// <summary>
        /// 入力内容チェック
        /// </summary>
        private bool F_Check()
        {
            //必須項目のチェック
            if (string.IsNullOrWhiteSpace(G_担当者CD.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_担当者CD.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(G_担当者名.Text))
            {
                MessageBox.Show("入力必須です", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                G_担当者名.Focus();
                return false;
            }

            //得意先CDの重複チェック
            if (C_処理区分.SelectedIndex == 0) // 0:登録
            {
                using (SqlConnection conn = new SqlConnection(Common.DB))
                {
                    conn.Open();

                    string sql = @"
                     SELECT COUNT(*)
                     FROM Ｍ担当者
                     WHERE 担当者CD = @TantousyaCD";

                    //デバッグ用
                    string w_DebugSQL =
                    $"SELECT COUNT(*) FROM Ｍ担当者 WHERE 担当者CD = '{G_担当者CD.Text}'";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue(
                            "@TantousyaCD",
                            G_担当者CD.Text);

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

                            G_担当者CD.Focus();
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

                //    G_得意先CD.BackColor = w_ReadOnlyColor;
                //    G_得意先CD.ReadOnly = true;

                G_担当者名.BackColor = w_ReadOnlyColor;
                G_郵便番号.BackColor = w_ReadOnlyColor;
                G_住所1.BackColor = w_ReadOnlyColor;
                G_住所2.BackColor = w_ReadOnlyColor;
                G_TEL1.BackColor = w_ReadOnlyColor;
                G_TEL2.BackColor = w_ReadOnlyColor;
                G_FAX.BackColor = w_ReadOnlyColor;
                G_MAIL.BackColor = w_ReadOnlyColor;

                CB_選択不可FLG.Enabled = false;
                G_担当者名.ReadOnly = true;
                G_郵便番号.ReadOnly = true;
                G_住所1.ReadOnly = true;
                G_住所2.ReadOnly = true;
                G_TEL1.ReadOnly = true;
                G_TEL2.ReadOnly = true;
                G_FAX.ReadOnly = true;
                G_MAIL.ReadOnly = true;
            }
            else // UnLock
            {
                G_担当者CD.BackColor = w_ReadOnlyColor2;
                G_担当者名.BackColor = w_ReadOnlyColor2;
                G_郵便番号.BackColor = w_ReadOnlyColor2;
                G_住所1.BackColor = w_ReadOnlyColor2;
                G_住所2.BackColor = w_ReadOnlyColor2;
                G_TEL1.BackColor = w_ReadOnlyColor2;
                G_TEL2.BackColor = w_ReadOnlyColor2;
                G_FAX.BackColor = w_ReadOnlyColor2;
                G_MAIL.BackColor = w_ReadOnlyColor2;

                CB_選択不可FLG.Enabled = true;
                G_担当者CD.ReadOnly = false;
                G_担当者名.ReadOnly = false;
                G_郵便番号.ReadOnly = false;
                G_住所1.ReadOnly = false;
                G_住所2.ReadOnly = false;
                G_TEL1.ReadOnly = false;
                G_TEL2.ReadOnly = false;
                G_FAX.ReadOnly = false;
                G_MAIL.ReadOnly = false;
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
