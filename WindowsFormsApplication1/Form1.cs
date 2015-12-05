using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();//获取当前激活窗口

        [DllImport("user32", SetLastError = true)]
        public static extern int GetWindowText(
        IntPtr hWnd, //窗口句柄
        StringBuilder lpString, //标题
        int nMaxCount  //最大值
        );

        [DllImport("user32.dll")]
        private static extern int GetClassName(
            IntPtr hWnd, //句柄
            StringBuilder lpString, //类名
            int nMaxCount //最大值
        );

        public Form1()
        {
            InitializeComponent();

            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private StringBuilder titleT;
        private void timer1_Tick(object sender, EventArgs e)
        {
            IntPtr myPtr = GetForegroundWindow();

            // 窗口标题
            StringBuilder title = new StringBuilder(255);
            
            GetWindowText(myPtr, title, title.Capacity);
            if (title.ToString()!="Form1")
            {
                label2.Text = title.ToString()+"  PID:"+myPtr.ToString();
                titleT = title;
            }
            // 窗口类名
            StringBuilder className = new StringBuilder(256);
            GetClassName(myPtr, className, className.Capacity);

            label1.Text = myPtr.ToString() + "\n" + title.ToString() + "\n" + className.ToString();
        }
    }
}