using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private delegate void CloseUI();

        private void CloseLoading()
        {
            if (this.IsDisposed)
                return;
            if (!this.IsDisposed)
            {
                this.Dispose();
            }
        }


        /// <summary>
        /// 关闭命令
        /// </summary>
        /// 
        public void closeOrder()
        {
            if (this.InvokeRequired)
            {
                //这里利用委托进行窗体的操作，避免跨线程调用时抛异常，后面给出具体定义
                this.Invoke(new CloseUI(delegate () {
                    while (!this.IsHandleCreated)
                    {
                        ;
                    }
                    CloseLoading();
                }));

            }
            else
            {
                CloseLoading();
            }
        }

        private void LoaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.IsDisposed)
            {
                this.Dispose(true);
            }

        }
    }
}
