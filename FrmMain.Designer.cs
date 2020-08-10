namespace YjmInactiveDocuments
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoad = new System.Windows.Forms.TextBox();
            this.btnChooseRoad = new System.Windows.Forms.Button();
            this.btnGoodsBatch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.lbCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbXml = new System.Windows.Forms.Label();
            this.lbGoodBacth = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(639, 52);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 0;
            this.btnExportExcel.Text = "导出Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件读取路径：";
            // 
            // txtRoad
            // 
            this.txtRoad.Location = new System.Drawing.Point(168, 52);
            this.txtRoad.Name = "txtRoad";
            this.txtRoad.ReadOnly = true;
            this.txtRoad.Size = new System.Drawing.Size(302, 21);
            this.txtRoad.TabIndex = 2;
            // 
            // btnChooseRoad
            // 
            this.btnChooseRoad.Location = new System.Drawing.Point(477, 51);
            this.btnChooseRoad.Name = "btnChooseRoad";
            this.btnChooseRoad.Size = new System.Drawing.Size(75, 23);
            this.btnChooseRoad.TabIndex = 3;
            this.btnChooseRoad.Text = "选择路径";
            this.btnChooseRoad.UseVisualStyleBackColor = true;
            this.btnChooseRoad.Click += new System.EventHandler(this.btnChooseRoad_Click);
            // 
            // btnGoodsBatch
            // 
            this.btnGoodsBatch.Location = new System.Drawing.Point(558, 52);
            this.btnGoodsBatch.Name = "btnGoodsBatch";
            this.btnGoodsBatch.Size = new System.Drawing.Size(75, 23);
            this.btnGoodsBatch.TabIndex = 4;
            this.btnGoodsBatch.Text = "查询品批";
            this.btnGoodsBatch.UseVisualStyleBackColor = true;
            this.btnGoodsBatch.Click += new System.EventHandler(this.btnGoodsBatch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(519, 101);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(492, 328);
            this.dataGridView1.TabIndex = 5;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(54, 101);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(236, 328);
            this.listBox1.TabIndex = 6;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(296, 101);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(217, 328);
            this.listBox2.TabIndex = 7;
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Location = new System.Drawing.Point(335, 437);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(11, 12);
            this.lbCode.TabIndex = 8;
            this.lbCode.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "共有:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "共有:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(517, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "共有:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 437);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "个XML文件";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(400, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "个药监码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(610, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "个未激活品批";
            // 
            // lbXml
            // 
            this.lbXml.AutoSize = true;
            this.lbXml.Location = new System.Drawing.Point(92, 437);
            this.lbXml.Name = "lbXml";
            this.lbXml.Size = new System.Drawing.Size(11, 12);
            this.lbXml.TabIndex = 13;
            this.lbXml.Text = "0";
            // 
            // lbGoodBacth
            // 
            this.lbGoodBacth.AutoSize = true;
            this.lbGoodBacth.Location = new System.Drawing.Point(557, 437);
            this.lbGoodBacth.Name = "lbGoodBacth";
            this.lbGoodBacth.Size = new System.Drawing.Size(11, 12);
            this.lbGoodBacth.TabIndex = 14;
            this.lbGoodBacth.Text = "0";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 514);
            this.Controls.Add(this.lbGoodBacth);
            this.Controls.Add(this.lbXml);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCode);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGoodsBatch);
            this.Controls.Add(this.btnChooseRoad);
            this.Controls.Add(this.txtRoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportExcel);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "未激活单据处理程序";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoad;
        private System.Windows.Forms.Button btnChooseRoad;
        private System.Windows.Forms.Button btnGoodsBatch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbXml;
        private System.Windows.Forms.Label lbGoodBacth;
    }
}

