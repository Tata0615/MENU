using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace customerApp
{
    public partial class MENU : Form
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

        #endregion

        #region プライベート定数

        #endregion

        #region コンストラクタ
        //コンストラクタ
        public MENU()
        {
            InitializeComponent();
        }
        #endregion

        #region MENU_Load /　フォームロード
        /// <summary>
        /// MENU_Load /　フォームロード
        /// </summary>
        private void MENU_Load(object sender, EventArgs e)
        {
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

        #region B_得意先マスタ_Click /　得意先マスタ押下時
        /// <summary>
        /// B_得意先マスタ_Click /　得意先マスタ押下時
        /// </summary>
        private void B_得意先マスタ_Click(object sender, EventArgs e)
        {
            M010 frm = new M010();
            frm.ShowDialog();
        }
        #endregion

        #region B_担当者マスタ_Click /　担当者マスタ押下時
        /// <summary>
        /// B_担当者マスタ_Click /　担当者マスタ押下時
        /// </summary>
        private void B_担当者マスタ_Click(object sender, EventArgs e)
        {
            M020 frm = new M020();
            frm.ShowDialog();
        }
        #endregion

        #region B_商品マスタ_Click /　商品マスタ押下時
        /// <summary>
        /// B_商品マスタ_Click /　商品マスタ押下時
        /// </summary>
        private void B_商品マスタ_Click(object sender, EventArgs e)
        {
            M030 frm = new M030();
            frm.ShowDialog();
        }
        #endregion

        #region B_売上入力_Click /　売上入力押下時
        /// <summary>
        /// B_売上入力_Click /　売上入力押下時
        /// </summary>
        private void B_売上入力_Click(object sender, EventArgs e)
        {
            D030 frm = new D030();
            frm.ShowDialog();
        }
        #endregion

        #region B_売上明細照会_Click /　売上明細照会押下時
        /// <summary>
        /// B_売上明細照会_Click /　売上明細照会押下時
        /// </summary>
        private void B_売上明細照会_Click(object sender, EventArgs e)
        {
            MD030 frm = new MD030();
            frm.ShowDialog();
        }
        #endregion

        #region B_請求集計処理_Click /　請求集計処理押下時
        /// <summary>
        /// B_請求集計処理_Click /　請求集計処理押下時
        /// </summary>
        private void B_請求集計処理_Click(object sender, EventArgs e)
        {
            S010 frm = new S010();
            frm.ShowDialog();
        }
        #endregion

        #region B_請求書_Click /　請求書押下時
        /// <summary>
        /// B_請求書_Click /　請求書押下時
        /// </summary>
        private void B_請求書_Click(object sender, EventArgs e)
        {
            RS010 frm = new RS010();
            frm.ShowDialog();
        }
        #endregion

        #region B_Key_KeyDown /　ファンクション押下時
        /// <summary>
        /// B_Key_KeyDown /　ファンクション押下時
        /// </summary>
        private void MENU_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
        #endregion

        #endregion

        #region ■関数

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

        #endregion

    }
}
