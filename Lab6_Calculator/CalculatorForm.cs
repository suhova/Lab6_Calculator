using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab6_Calculator
{
    public partial class CalculatorForm : Form
    {
        float x = 0f;
        float result = 0f;
        float num = 0f;
        byte op = 0;
        int p = 0;
        public CalculatorForm()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(form_KeyDown);
            b0.Click += new EventHandler(num_Click);
            b1.Click += new EventHandler(num_Click);
            b2.Click += new EventHandler(num_Click);
            b3.Click += new EventHandler(num_Click);
            b4.Click += new EventHandler(num_Click);
            b5.Click += new EventHandler(num_Click);
            b6.Click += new EventHandler(num_Click);
            b7.Click += new EventHandler(num_Click);
            b8.Click += new EventHandler(num_Click);
            b9.Click += new EventHandler(num_Click);
            plus.Click += new EventHandler(plus_Click);
            minus.Click += new EventHandler(minus_Click);
            div.Click += new EventHandler(div_Click);
            mul.Click += new EventHandler(mul_Click);
            res.Click += new EventHandler(res_Click);
            point.Click += new EventHandler(point_Click);
            ce.Click += new EventHandler(ce_Click);
            plus.Click += new EventHandler(oper_Click);
            minus.Click += new EventHandler(oper_Click);
            mul.Click += new EventHandler(oper_Click);
            div.Click += new EventHandler(oper_Click);
        }
        /// <summary>
        /// Обработчик нажатия клавиш
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void form_KeyDown(object o, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                num = int.Parse(e.KeyChar.ToString());
                numInput();
            }
            else if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                point_Click(o, e);
            }
            else if (e.KeyChar == '+')
            {
                oper_Click(o, e);
                plus_Click(o, e);
            }
            else if (e.KeyChar == '-')
            {
                oper_Click(o, e);
                minus_Click(o, e);
            }
            else if (e.KeyChar == '*')
            {
                oper_Click(o, e);
                mul_Click(o, e);
            }
            else if (e.KeyChar == '/')
            {
                oper_Click(o, e);
                div_Click(o, e);
            }
            else if (e.KeyChar == '=')
            {
                res_Click(o, e);
            }
        }
        /// <summary>
        /// Обработчик нажатия на любую из цифр 
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void num_Click(object o, EventArgs e)
        {
            num = int.Parse((o as Button).Text);
            numInput();
        }
        /// <summary>
        /// Изменение текущёго числа в зависимости от пользовательсного ввода
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void numInput()
        {
            if (p == 0)
            {
                this.x = this.x * 10 + num;
            }
            else
            {
                for (int i = 0; i < p; i++)
                {
                    num /= 10;
                }
                p++;
                x += num;
            }
            disp.Text = this.x.ToString();
        }
        /// <summary>
        /// Обработчик нажатия на +, -, * или /
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void oper_Click(object o, EventArgs e)
        {
            if (x != 0)
            {
                result = x;
                x = 0;
            }
            p = 0;
        }
        /// <summary>
        /// Обработчик нажатия на +
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void plus_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.AntiqueWhite;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            op = 0;
        }
        /// <summary>
        /// Обработчик нажатия на -
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void minus_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.AntiqueWhite;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            op = 1;
        }
        /// <summary>
        /// Обработчик нажатия на *
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void mul_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.AntiqueWhite;
            div.BackColor = Color.White;
            op = 2;
        }
        /// <summary>
        /// Обработчик нажатия на /
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void div_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.AntiqueWhite;
            op = 3;
        }
        /// <summary>
        /// Обработчик нажатия на .
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void point_Click(object o, EventArgs e)
        {
            p = 1;
            disp.Text=x+",";
        }
        /// <summary>
        /// Обработчик нажатия на сброс
        /// </summary>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void ce_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            result = 0;
            x = 0;
            p = 0;
            disp.Text = "0";
        }
        /// <summary>
        /// Обработчик нажатия на =
        /// </summary>
        ///<remarks>
        /// Выполняет арифметическое действие, а результат сохраняет в буфере обмена
        /// </remarks>
        /// <param name="o">объект</param>
        /// <param name="e">событие</param>
        void res_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            switch (op)
            {
                case 0:
                    result += x;
                    break;
                case 1:
                    result -= x;
                    break;
                case 2:
                    result *= x;
                    break;
                case 3:
                    result /= x;
                    break;
            }
         //   result = (float)Math.Round(result, 5);
            disp.Text = this.result.ToString();
            Clipboard.SetText(result.ToString());
            x = 0;
            p = 0;
        }
    }
}
