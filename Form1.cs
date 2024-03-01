using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace htmlToC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取输入的html代码
            string html = textBox1.Text;
            //根据换行符分割html代码为数组
            string[] htmlArr = html.Split('\n');
            //给每个数组前面添加双引号 后面添加 \r\n"
            for (int i = 0; i < htmlArr.Length; i++)
            {

                //判断数组是否为空字符串或者空格等情况
                if (htmlArr[i] != "")
                {
                    //将数组中连续两个以上的空格替换为一个空格
                    htmlArr[i] = System.Text.RegularExpressions.Regex.Replace(htmlArr[i], "\\s{2,}", "");
                    //将	替换为空格
                    htmlArr[i] = htmlArr[i].Replace("\t", "");
                    htmlArr[i] = "\"" + htmlArr[i] + "\\r\\n\"";
                }
            }
            //打印到文本框 每个数组换行显示
            textBox2.Text = string.Join("\r\n", htmlArr);
            //文本前面加上const char Html login[]={  后面加上  };
            textBox2.Text = "const char Html_login[]={\r\n" + textBox2.Text + "\r\n};";
        }
    }
}
