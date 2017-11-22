using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        String expression;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "请从键盘输入表达式或者点击按键输入，开方符号为#";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)// 数字1
        {
            expression = expression + "1";
            textBox1.Text = expression;     
        }

        private void button2_Click(object sender, EventArgs e)// 数字2
        {
            expression = expression + "2";
            textBox1.Text = expression;
        }

        private void button3_Click(object sender, EventArgs e)// 数字3
        {
            expression = expression + "3";
            textBox1.Text = expression;
        }

        private void button6_Click(object sender, EventArgs e)// 数字4
        {
            expression = expression + "4";
            textBox1.Text = expression;
        }

        private void button7_Click(object sender, EventArgs e)// 数字5
        {
            expression = expression + "5";
            textBox1.Text = expression;
        }

        private void button8_Click(object sender, EventArgs e)// 数字6
        {
            expression = expression + "6";
            textBox1.Text = expression;
        }

        private void button11_Click(object sender, EventArgs e)// 数字7
        {
            expression = expression + "7";
            textBox1.Text = expression;
        }

        private void button12_Click(object sender, EventArgs e)// 数字8
        {
            expression = expression + "8";
            textBox1.Text = expression;
        }

        private void button13_Click(object sender, EventArgs e)// 数字9
        {
            expression = expression + "9";
            textBox1.Text = expression;
        }

        private void button17_Click(object sender, EventArgs e)// 数字0
        {
            expression = expression + "0";
            textBox1.Text = expression;
        }

        private void button4_Click(object sender, EventArgs e)// +
        {
            expression = expression + "+";
            textBox1.Text = expression;
        }

        private void button9_Click(object sender, EventArgs e)// -
        {
            expression = expression + "-";
            textBox1.Text = expression;
        }

        private void button14_Click(object sender, EventArgs e)// *
        {
            expression = expression + "*";
            textBox1.Text = expression;
        }

        private void button19_Click(object sender, EventArgs e)// /
        {
            expression = expression + "/";
            textBox1.Text = expression;
        }

        private void button5_Click(object sender, EventArgs e)// ^2
        {
            expression = expression + "^2";
            textBox1.Text = expression;
        }

        private void button10_Click(object sender, EventArgs e)// ^3
        {
            expression = expression + "^3";
            textBox1.Text = expression;
        }

        private void button15_Click(object sender, EventArgs e)// ^n
        {
            expression = expression + "^";
            textBox1.Text = expression;
        }

        private void button21_Click(object sender, EventArgs e)// %
        {
            expression = expression + "%";
            textBox1.Text = expression;
        }

        private void button23_Click(object sender, EventArgs e)// 左括号
        {
            expression = expression + "(";
            textBox1.Text = expression;
        }

        private void button24_Click(object sender, EventArgs e)// 右括号
        {
            expression = expression + ")";
            textBox1.Text = expression;
        }

        private void button16_Click(object sender, EventArgs e)// 删除
        {
            expression = null;
            textBox1.Text = expression;
        }

        private void button20_Click(object sender, EventArgs e)// 平方根
        {
            expression = expression + "#";
            textBox1.Text = expression;
        }

        private void button22_Click(object sender, EventArgs e)// 阶乘
        {
            expression = expression + "!";
            textBox1.Text = expression;
        }

        private void button18_Click(object sender, EventArgs e)//等号
        {
            expression = textBox1.Text;//可以直接在输入框输入表达式

            while (expression.Contains('!'))// 进行阶乘的运算
            {
                expression = Program.factorial(expression);
            }

            while(expression.Contains('#'))//进行开方的运算
            {
                expression = Program.rooting(expression);
            }

            bool mark = true;//用来标记表达式中是否只有阶乘运算

            for(int i=0;i<expression.Length;i++)
            {
                if (!char.IsDigit(expression.ElementAt(i)))// 判断是不是只有阶乘运算 比如 5! 如果不是则为false 说明还需要进一步计算，如果是则直接显示
                {
                    mark = false;
                }
            }
            if (mark == false)
            {
                double result = Program.cal(expression);
                textBox1.Text = result.ToString();
            }
            else 
            {
                textBox1.Text = expression;
            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        



       

        

        

       

       

       

      

        

      

    

        

      

       

        

      
        

       
    }
}
