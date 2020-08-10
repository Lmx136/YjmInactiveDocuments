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

namespace YjmInactiveDocuments
{
    public partial class FrmMain : Form
    {
        DataTable table;
        List<string> codeList = new List<string>();
        public FrmMain()
        {
            InitializeComponent();
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

            Microsoft.Office.Interop.Excel.Range rngB = (Microsoft.Office.Interop.Excel.Range)worksheet.Columns[10, Type.Missing];//设置单元格格式


            rngB.NumberFormatLocal = "@";//字符型格式


            Microsoft.Office.Interop.Excel.Range rngC = (Microsoft.Office.Interop.Excel.Range)worksheet.Columns[17, Type.Missing];//设置单元格格式


            rngC.NumberFormatLocal = "@";//字符型格式


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
           
           
                
        }    
        /// <summary>
        /// 获取指定节点的特性的值的列表
        /// </summary>
        /// <param name="xmlFile">xml文件</param>
        /// <param name="nodeName">节点名</param>
        /// <param name="attributeName">节点的属性</param>
        /// <returns></returns>
        protected void GetAttributeValues(string xmlFile, string nodeName, string attributeName)
        {
           
            XmlDocument xml = new XmlDocument();
            xml.Load(xmlFile);
            XmlNodeList xmlList = xml.GetElementsByTagName(nodeName);
            foreach (XmlNode xmlNode in xmlList)
            {
               // codeList.Add(xmlNode.Attributes[attributeName].Value);
                this.listBox2.Items.Add(xmlNode.Attributes[attributeName].Value);
                
            }   
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            //读取指定路径下的XML文件列表：
            // string folderName = txtRoad.Text;
            string folderName = " D:\\SFDA\\InData\\test";
            DirectoryInfo folder = new DirectoryInfo(folderName);

            //遍历xml文件列表：
            foreach (FileInfo nextName in folder.GetFiles())
            {
                this.listBox1.Items.Add(nextName.Name);
                //1.指定文件路径
                string folderFullName = folderName + "\\" + nextName.Name;
                //2.读取指定路径下每个xml文件节点指定属性的值：
                GetAttributeValues(folderFullName, "Data", "Code");

            }

            // this.listBox2.DataSource = codeList;
            this.label2.Text = this.listBox2.Items.Count.ToString();
        }

       

    }
}
