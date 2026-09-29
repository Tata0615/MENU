using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace customerApp
{
    public partial class RS011 : Form
    {

        #region プライベート変数

        private string m_SeiCD;
        private string m_SeiSN;
        private int m_Page;

        #endregion

        #region コンストラクタ
        public RS011(string o_seiCD, string o_seiSN, int o_Page)
        {
            InitializeComponent();

            m_SeiCD = o_seiCD;
            m_SeiSN = o_seiSN;
            m_Page = o_Page;
        }
        #endregion

        #region RS011_Load / フォームロード
        private void RS011_Load(object sender, EventArgs e)
        {

            //明細部を編集不可にする。高さの調節も不可に
            foreach (DataGridViewColumn col in DG1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DG1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //帳票のサイズをタスクバーに隠れないようにする
            var area = Screen.PrimaryScreen?.WorkingArea;
            if (area != null)
            {
                this.Height = area.Value.Height;   // 高さを合わせる
                this.Width += 15;                  // 幅の微調整
            }
            this.StartPosition = FormStartPosition.CenterScreen;

            // 画面初期化処理
            F_DispT();

            //スクロール位置を一番上に
            BeginInvoke(new Action(() =>
            {
                AutoScrollPosition = new Point(0, 0);
            }));
        }
        #endregion

        #region F_DispT / 帳票表示処理
        /// <summary>
        /// F_DispT / 帳票表示処理
        /// </summary>
        private void F_DispT()
        {
            int w_Start = (m_Page - 1) * 28;

            //帳票情報をクリア
            H_請求日.Text = "";
            H_請求先名.Text = "";
            H_御買上金額.Text = "";
            H_消費税額.Text = "";
            H_御請求金額.Text = "";
            DG1.Rows.Clear();

            using (SqlConnection conn = new SqlConnection(Common.DB))
            {
                conn.Open();

                //帳票出力用SQL
                string SSEIsql = @"
                   SELECT 
                      DUMS.売上NO
                     ,DUMS.売上NO行
                     ,DUHD.売上日
                     ,DUHD.得意先CD
                     ,DUHD.得意先名
                     ,DUHD.請求締年月日
                     ,DUHD.得意先敬称
                     ,DUMS.商品CD
                     ,DUMS.商品名
                     ,DUMS.数量
                     ,DUMS.単位名
                     ,DUMS.売上単価
                     ,DUMS.売上金額
                     ,DUMS.明細備考
                     ,SSEI.合計売上金額税抜
                     ,SSEI.合計売上消費税
                     ,SSEI.合計売上金額
                   FROM 
                     Ｄ売上ヘッダー DUHD WITH(NOLOCK)
                   INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK) ON
                         DUHD.売上NO = DUMS.売上NO
                   INNER JOIN Ｓ請求残高 SSEI WITH(NOLOCK) ON
                         DUHD.得意先CD = SSEI.請求先CD
                     AND DUHD.請求締年月日 = SSEI.請求締年月日                
                   WHERE 0 = 0
                     AND SSEI.請求先CD = @SeiCD
                     AND SSEI.請求締年月日 = @SeiSN
                   ORDER BY 
                      DUHD.売上日
                     ,DUMS.売上NO
                     ,DUMS.売上NO行
                   OFFSET @Start ROWS
                   FETCH NEXT 28 ROWS ONLY";

                //デバッグ用
                string w_DebugSQL =
                $" SELECT  " +
                $"    DUMS.売上NO " +
                $"   ,DUMS.売上NO行 " +
                $"   ,DUHD.売上日 " +
                $"   ,DUHD.得意先CD " +
                $"   ,DUHD.得意先名 " +
                $"   ,DUHD.請求締年月日 " +
                $"   ,DUHD.得意先敬称 " +
                $"   ,DUMS.商品CD " +
                $"   ,DUMS.商品名 " +
                $"   ,DUMS.数量 " +
                $"   ,DUMS.単位名 " +
                $"   ,DUMS.売上単価 " +
                $"   ,DUMS.売上金額 " +
                $"   ,DUMS.明細備考 " +
                $"   ,SSEI.合計売上金額税抜 " +
                $"   ,SSEI.合計売上消費税 " +
                $"   ,SSEI.合計売上金額 " +
                $" FROM  " +
                $"   Ｄ売上ヘッダー DUHD WITH(NOLOCK) " +
                $" INNER JOIN Ｄ売上明細 DUMS WITH(NOLOCK) ON " +
                $"       DUHD.売上NO = DUMS.売上NO " +
                $" INNER JOIN Ｓ請求残高 SSEI WITH(NOLOCK) ON " +
                $"       DUHD.得意先CD = SSEI.請求先CD " +
                $"   AND DUHD.請求締年月日 = SSEI.請求締年月日 " +
                $" WHERE 0 = 0 " +
                $"   AND SSEI.請求先CD = " + m_SeiCD +
                $"   AND SSEI.請求締年月日 = '" + Convert.ToDateTime(m_SeiSN).ToString("yyyy/MM/dd") + "'" +
                $" ORDER BY   " +
                $"    DUHD.売上日  " +
                $"   ,DUMS.売上NO  " +
                $"   ,DUMS.売上NO行" + 
                $" OFFSET " + w_Start + " ROWS " +
                $" FETCH NEXT 28 ROWS ONLY";


                using (SqlCommand cmd = new SqlCommand(SSEIsql, conn))
                {
                    cmd.Parameters.AddWithValue("@SeiCD", m_SeiCD);
                    cmd.Parameters.AddWithValue("@SeiSN", m_SeiSN);
                    cmd.Parameters.AddWithValue("@Start", w_Start);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        int w_Row = 0;
                        bool w_First = true;

                        while (reader.Read())
                        {

                            if (w_First)
                            {
                                string w_Name = reader["得意先名"]?.ToString() ?? "";

                                H_請求日.Text = Convert.ToDateTime(reader["請求締年月日"]).ToString("yyyy年MM月dd日") + "締";
                                H_請求先名.Text = w_Name.Length > 30 ? w_Name.Substring(0, 30) : w_Name + "  " + reader["得意先敬称"].ToString();
                                H_御買上金額.Text = Convert.ToDecimal(reader["合計売上金額税抜"]).ToString("#,##0");
                                H_消費税額.Text = Convert.ToDecimal(reader["合計売上消費税"]).ToString("#,##0");
                                H_御請求金額.Text = Convert.ToDecimal(reader["合計売上金額"]).ToString("#,##0");

                                w_First = false;
                            }

                            DG1.Rows.Add(
                                Convert.ToDateTime(reader["売上日"]).ToString("MM/dd"),
                                reader["商品CD"],
                                reader["商品名"],
                                Convert.ToDecimal(reader["数量"]).ToString("#,##0"),
                                reader["単位名"],
                                Convert.ToDecimal(reader["売上単価"]).ToString("#,##0"),
                                Convert.ToDecimal(reader["売上金額"]).ToString("#,##0"),
                                reader["明細備考"]
                            );

                            w_Row++;
                        }

                        // 28行まで空行を追加
                        while (w_Row < 28)
                        {
                            DG1.Rows.Add();
                            w_Row++;
                        }

                        DG1.EndEdit();
                    }
                }
            }
        }
        #endregion

    }
}
