using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        /*
         *中缀表达式转后缀表达式 
         */
        public static string infixToPostfix(string expression)
        {
            Stack<char> operators = new Stack<char>();
            System.Text.StringBuilder result = new System.Text.StringBuilder();
            for (int i = 0; i < expression.Length; i++)
            {
                char ch = expression[i];
                if (char.IsWhiteSpace(ch)) continue;
                switch (ch)
                {
                    case '+':
                    case '-':
                        while (operators.Count > 0)// 栈堆长度大于0
                        {
                            char c = operators.Pop();   //pop Operator
                            if (c == '(')
                            {
                                operators.Push(c);      //push Operator
                                break;
                            }
                            else
                            {
                                result.Append(c);
                            }
                        }
                        operators.Push(ch);
                        result.Append(" ");
                        break;
                    case '*':
                    case '/':
                        while (operators.Count > 0)
                        {
                            char c = operators.Pop();
                            if (c == '(')
                            {
                                operators.Push(c);
                                break;
                            }
                            else
                            {
                                if (c == '+' || c == '-')
                                {
                                    operators.Push(c);
                                    break;
                                }
                                else
                                {
                                    result.Append(c);
                                }
                            }
                        }
                        operators.Push(ch);
                        result.Append(" ");
                        break;
                    case '^':
                    case '%':
                        while (operators.Count > 0)
                        {
                            char c = operators.Pop();
                            if (c == '(')
                            {
                                operators.Push(c);
                                break;
                            }
                            else
                            {
                                if (c == '*' || c == '/')
                                {
                                    operators.Push(c);
                                    break;
                                }
                                else
                                {
                                    if (c == '+' || c == '-')
                                    {
                                        operators.Push(c);
                                        break;
                                    }
                                    else
                                    {
                                        result.Append(c);
                                    }
                                }

                            }
                        }
                        operators.Push(ch);
                        result.Append(" ");
                        break;

                    case '(':
                        operators.Push(ch);
                        break;
                    case ')':
                        while (operators.Count > 0)
                        {
                            char c = operators.Pop();
                            if (c == '(')
                            {
                                break;
                            }
                            else
                            {
                                result.Append(c);
                            }
                        }
                        break;
                    default:
                        result.Append(ch);
                        break;
                }
            }
            while (operators.Count > 0)
            {
                result.Append(operators.Pop()); //pop All Operator
            }
            return result.ToString();
        }

        /*
         * 分析表达式并计算
         */
        public static double cal(string expression)
        {
            string postfixExpression = infixToPostfix(expression);
            Stack<double> results = new Stack<double>();//存放数的栈
            double x, y;//两个计算数
            for (int i = 0; i < postfixExpression.Length; i++)
            {
                char ch = postfixExpression[i];
                if (char.IsWhiteSpace(ch)) continue;
                switch (ch)
                {
                    case '+':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(x + y);
                        break;
                    case '-':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(x - y);
                        break;
                    case '*':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(x * y);
                        break;
                    case '/':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(x / y);
                        break;
                    case '^':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(Math.Pow(x, y));
                        break;
                    case '%':
                        y = results.Pop();
                        x = results.Pop();
                        results.Push(x % y);
                        break;
                    default:
                        int pos = i;
                        System.Text.StringBuilder operand = new System.Text.StringBuilder();
                        do
                        {
                            operand.Append(postfixExpression[pos]);
                            pos++;
                        } while (char.IsDigit(postfixExpression[pos]) || postfixExpression[pos] == '.');
                        i = --pos;
                        results.Push(double.Parse(operand.ToString()));
                        break;
                }
            }
            return results.Peek();
        }

        /* 
         * 这个函数用来计算阶乘
         * 它将表达式中阶乘部分计算出来，然后将阶乘部分替换为计算所得答案，返回此表达式。
         * 支持括号和连续阶乘 比如(1+3)!  3!!
         */
        public static string factorial(string expression)
        {
            bool mark = false;//记录阶乘号前是否有括号
            int index = expression.IndexOf("!");
            index--;
            Stack<char> st = new Stack<char>();//存放需要阶乘计算表达式的栈
            int counter = 0;
            string exp = null;
            int a = 0;


            if (expression.ElementAt(index) == ')') // 有括号的情况
            {
                do
                {
                    st.Push(expression.ElementAt(index));
                    index--;
                    counter++;
                } while (expression.ElementAt(index) != '(');
                for (int i = 0; i < counter - 1; i++)
                {
                    exp += st.Pop();
                }
                a = (int)cal(exp);//计算括号中的值
                mark = true;
            }
            else// 无括号的情况
            {
                do
                {
                    st.Push(expression.ElementAt(index));
                    index--;
                    counter++;
                    if (index < 0) break;// 防止阶乘在最前面
                } while (char.IsDigit(expression.ElementAt(index)));
                for (int i = 0; i < counter; i++)
                {
                    exp += st.Pop();
                }
                a = int.Parse(exp);
            }
            int value = 1;
            for (int i = 1; i <= a;i++)//阶乘运算
            {
                value *= i;
            }
            exp = null;
            int begin = expression.IndexOf("!") - counter;
            int end = expression.IndexOf("!");
           
            //把表达式中阶乘部分替换成阶乘的答案
            for (int i = 0; i < (mark?begin-1:begin);i++ )//阶乘答案之前
            {
                exp += expression.ElementAt(i);
            }
            exp += value.ToString();//阶乘答案
            for (int i = end+1; i < expression.Length; i++)//阶乘答案之后
            {
                exp += expression.ElementAt(i);
            }

                return exp;

        }

        /* 
         * 这个函数用来计算开方 开方符号用#代替
         * 它将表达式中需要开方部分计算出来，然后将需要开方部分替换为计算所得答案，返回此表达式。
         * 支持括号 比如#(1+8)
         */
         public static string rooting(string expression)
         {
             bool mark = false;//标记根号后是否有括号
             int index = expression.IndexOf("#");
             index++;
             int counter = 0;
             string exp = null;
             double a = 0;
             if (expression.ElementAt(index)=='(')
             {
                 index++;
                 do
                 {
                     exp += expression.ElementAt(index);
                     index++;
                     counter++;
                 } while (expression.ElementAt(index) != ')');

                 a = cal(exp);//用计算的函数计算
                 mark = true;
             }
             else
             {
                 do
                 {
                     exp += expression.ElementAt(index);
                     index++;
                     counter++;
                     if (index >= expression.Length) break;//防止表达式中只有开方一种运算
                 } while (char.IsDigit(expression.ElementAt(index)));

                 a = double.Parse(exp);//转为int
             }
             double value = Math.Sqrt(a);//开方运算
             exp = null;
             int begin = expression.IndexOf("#");
             int end = expression.IndexOf("#") + counter;


             for (int i = 0; i < begin; i++)//开方运算前半部分
             {
                 exp += expression.ElementAt(i);
             }
             exp += value.ToString();//开方运算答案
             for (int i = mark? end+3:end+1; i < expression.Length; i++)//开方运算后半部分表达式
             {
                 exp += expression.ElementAt(i);
             }
                 return exp;
         }
    }
}
