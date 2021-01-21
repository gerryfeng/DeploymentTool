
namespace PublishTool
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.text_port = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.text_site = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_path = new System.Windows.Forms.Label();
            this.lblWriteStatus = new System.Windows.Forms.Label();
            this.pgbWrite = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_pull = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.init = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.init.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Location = new System.Drawing.Point(18, 18);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(380, 1138);
            this.treeView1.TabIndex = 3;
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 124);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(240, 30);
            this.toolStripMenuItem2.Text = "刷新";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(240, 30);
            this.toolStripMenuItem3.Text = "更新";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(240, 30);
            this.toolStripMenuItem4.Text = "删除";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(240, 30);
            this.toolStripMenuItem1.Text = "浏览";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(104, 25);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 26);
            this.comboBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "请选择站点：";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(274, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "更新";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(18, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(756, 342);
            this.panel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(24, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 222);
            this.panel1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "日志";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "是否启用网关：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "站点名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(428, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "端口号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 25;
            this.label2.Text = "ip地址：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Controls.Add(this.groupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(1394, 1108);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "服务部署";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.txt_log);
            this.groupBox3.Location = new System.Drawing.Point(26, 456);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(1325, 621);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志";
            // 
            // txt_log
            // 
            this.txt_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_log.Location = new System.Drawing.Point(28, 40);
            this.txt_log.Margin = new System.Windows.Forms.Padding(4);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(1262, 556);
            this.txt_log.TabIndex = 5;
            this.txt_log.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.text_ip);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.text_port);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.text_site);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(959, 27);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(392, 398);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网站配置";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 117);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 35;
            this.label7.Text = "ip地址：";
            // 
            // text_ip
            // 
            this.text_ip.Location = new System.Drawing.Point(168, 117);
            this.text_ip.Margin = new System.Windows.Forms.Padding(4);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(183, 28);
            this.text_ip.TabIndex = 34;
            this.text_ip.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(51, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 18);
            this.label9.TabIndex = 33;
            this.label9.Text = "端口号：";
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(168, 174);
            this.text_port.Margin = new System.Windows.Forms.Padding(4);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(183, 28);
            this.text_port.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(51, 72);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 31;
            this.label10.Text = "站点名：";
            // 
            // text_site
            // 
            this.text_site.Location = new System.Drawing.Point(168, 62);
            this.text_site.Margin = new System.Windows.Forms.Padding(4);
            this.text_site.Name = "text_site";
            this.text_site.Size = new System.Drawing.Size(183, 28);
            this.text_site.TabIndex = 30;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(255, 249);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(51, 22);
            this.radioButton3.TabIndex = 29;
            this.radioButton3.Text = "否";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(194, 249);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(51, 22);
            this.radioButton4.TabIndex = 28;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "是";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 252);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "是否启用网关：";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(114, 333);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 34);
            this.button4.TabIndex = 26;
            this.button4.Text = "确定";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.lblWriteStatus);
            this.groupBox1.Controls.Add(this.pgbWrite);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.btn_pull);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(26, 27);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(852, 398);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "获取安装包";
            // 
            // txt_path
            // 
            this.txt_path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_path.Location = new System.Drawing.Point(143, 56);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(469, 27);
            this.txt_path.TabIndex = 12;
            // 
            // lblWriteStatus
            // 
            this.lblWriteStatus.Location = new System.Drawing.Point(627, 342);
            this.lblWriteStatus.Name = "lblWriteStatus";
            this.lblWriteStatus.Size = new System.Drawing.Size(57, 27);
            this.lblWriteStatus.TabIndex = 11;
            // 
            // pgbWrite
            // 
            this.pgbWrite.Location = new System.Drawing.Point(362, 342);
            this.pgbWrite.Name = "pgbWrite";
            this.pgbWrite.Size = new System.Drawing.Size(250, 23);
            this.pgbWrite.TabIndex = 10;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(41, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(571, 181);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "安装包";
            // 
            // btn_pull
            // 
            this.btn_pull.Location = new System.Drawing.Point(144, 333);
            this.btn_pull.Margin = new System.Windows.Forms.Padding(4);
            this.btn_pull.Name = "btn_pull";
            this.btn_pull.Size = new System.Drawing.Size(112, 34);
            this.btn_pull.TabIndex = 7;
            this.btn_pull.Text = "获取";
            this.btn_pull.UseVisualStyleBackColor = true;
            this.btn_pull.Click += new System.EventHandler(this.btn_pull_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(667, 51);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(112, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = "选择文件夹";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_chooseFile);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 56);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "安装位置：";
            // 
            // init
            // 
            this.init.Controls.Add(this.tabPage3);
            this.init.Location = new System.Drawing.Point(410, 18);
            this.init.Margin = new System.Windows.Forms.Padding(4);
            this.init.Name = "init";
            this.init.SelectedIndex = 0;
            this.init.Size = new System.Drawing.Size(1402, 1140);
            this.init.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1821, 1167);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.init);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务部署工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.init.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeView1;
       
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox text_ip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox text_site;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_pull;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl init;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ProgressBar pgbWrite;
        private System.Windows.Forms.Label lblWriteStatus;
        private System.Windows.Forms.Label txt_path;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

