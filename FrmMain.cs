using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace YjmInactiveDocuments
{
    public partial class FrmMain : Form
    {
        DataTable table = new DataTable();
        List<string> CodeList = new List<string>();
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //if (!SysFunc.IfWmsOpen)
            //{
            //    SysFunc.WMSDBConn();
            //}
            txtRoad.Text = "J:\\SFDA\\未激活码单据";
    
        }
           
        private void btnChooseRoad_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK)
            {
                txtRoad.Text = folder.SelectedPath;
                string folderFullName = txtRoad.Text;           
            }
        }

        private void btnGoodsBatch_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            try
            {
                if (txtRoad.Text == null || txtRoad.Text == "")
                {
                    MessageBox.Show("请先选择药监码对应的文件路径！！！");
                    return;
                }
                //读取指定路径下的XML文件列表：
                string folderName = txtRoad.Text;
                DirectoryInfo folder = new DirectoryInfo(folderName);
                //遍历xml文件列表：
                foreach (FileInfo nextName in folder.GetFiles())
                {
                    //1.指定文件路径
                    string folderFullName = folderName + "\\" + nextName.Name;
                    //2.读取指定路径下每个xml文件节点指定属性的值：
                    GetCodeAttributeValues(folderFullName, "Data", "Code");
                    this.listBox1.Items.Add(nextName.Name);
                }
                this.lbXml.Text = this.listBox1.Items.Count.ToString();
                this.lbCode.Text = this.listBox2.Items.Count.ToString();
                //==================================================
                #region 品批查询：
                //1.t通过药监码查询品批：
                #region 拼接药监码：
                string concateCode = "";
                string strCode = "";
                int count = 0;
                foreach (string lineCode in CodeList)
                {
                    count++;
                    if (count>=999)
                    {
                        concateCode = strCode.TrimEnd(',');
                        string CodeSql = "insert into  YjmInactive_Code_Help@db2wg values(select * from(select wi.goods_id 商品编码, gi.goods_name 商品名称, wi.batch_no 批次号, wi.code 药监码 " +
                            "from warehouseindrug wi " +
                   "inner join goods_inf gi on wi.goods_id = gi.goods_id and wi.org_id = gi.org_id and wi.owner_id = gi.owner_id " +
                   "where wi.code in (" + concateCode + ") " +
                   "union all " +
                   "select w.corpproductid,gi.goods_name,w.corpbatchno,w.code from warehouseoutdrug w " +
                   "inner join goods_inf gi on w.corpproductid = gi.goods_id and w.org_id = gi.org_id and w.owner_id = gi.owner_id " +
                   "where w.code in (" + concateCode + ")) T " +
                   "group by 商品编码, 商品名称, 批次号, 药监码 " +
                   "order by 商品编码)";
                        FCXFuncC.FCXFuncClass.cmd(CodeSql,SysFunc.wmsConnectString);
                        count = 0;
                        strCode = "";
                        concateCode = "";
                       
                    }
                    strCode += "'" + lineCode + "'" + ",";

                }
                //开始查 ：
                string checkSql = "select * from YjmInactive_Code_Help yj " +
                     "left join warehouseindrug wi on wi.code = yj.code" +
                     " left join warehouseoutdrug wo on wo.code = yj.code " +
                     "where org_id = '130'";
                OleDbDataAdapter da = new OleDbDataAdapter(checkSql, SysFunc.wmsConnectString);
                DataSet ds = new DataSet();
                da.Fill(ds, "CODE");
                dataGridView1.DataSource = ds.Tables["CODE"];
                int dGVCount = dataGridView1.RowCount;
                this.lbGoodBacth.Text = (dGVCount - 1).ToString();
                table = ds.Tables["CODE"];
                #endregion

                //药监码查询sql

                //string CodeSql = "select * from warehouseoutdrug";


                // SqlDataAdapter da = new SqlDataAdapter(CodeSql, SysFunc.wmsConnectString);

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取药监码指定节点的特性的值的列表
        /// </summary>
        /// <param name="xmlFile">xml文件</param>
        /// <param name="nodeName">节点名</param>
        /// <param name="attributeName">节点的属性</param>
        /// <returns></returns>
        protected void GetCodeAttributeValues(string xmlFile, string nodeName, string attributeName)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            XmlNodeList xmlList = xml.GetElementsByTagName(nodeName);
            foreach (XmlNode xmlNode in xmlList)
            {
                this.listBox2.Items.Add(xmlNode.Attributes[attributeName].Value);
                CodeList.Add(xmlNode.Attributes[attributeName].Value);
            }   
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
           
            ExportExcel(table);
        }

        private void ExportExcel(DataTable dt)
        {
            if (dt == null && dt.Rows.Count == 0) return;
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null) return;
            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;
            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;

            //Microsoft.Office.Interop.Excel.Range rngB = (Microsoft.Office.Interop.Excel.Range)worksheet.Columns[10, Type.Missing];//设置单元格格式

            //rngB.NumberFormatLocal = "@";//字符型格式

            //Microsoft.Office.Interop.Excel.Range rngC = (Microsoft.Office.Interop.Excel.Range)worksheet.Columns[17, Type.Missing];//设置单元格格式

            //rngC.NumberFormatLocal = "@";//字符型格式
            worksheet.Cells.NumberFormat= "@";
            

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
                range.Interior.ColorIndex = 15;
                range.Font.Bold = true;
            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                rowRead++;
                percent = ((float)(100 * rowRead)) / totalCount;
            }
            xlApp.Visible = true;

        }

    }
}
