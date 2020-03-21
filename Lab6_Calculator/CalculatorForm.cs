using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab6_Calculator
{
    public partial class CalculatorForm : Form
    {

        double x = 0d;
        double result = 0d;
        double num = 0d;
        byte op = 0;
        int p = 0;
        public CalculatorForm()
        {
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(num_KeyDown);
            
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
        void num_KeyDown(object o, KeyPressEventArgs e)
        {
            disp.Text = ")))";
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                num = int.Parse(e.KeyChar.ToString());
            }
            numInput();
        }

        void num_Click(object o, EventArgs e)
        {
            num = int.Parse((o as Button).Text);
            numInput();
        }
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
        void oper_Click(object o, EventArgs e)
        {
            if (x != 0)
            {
                result = x;
                x = 0;
            }            
            p = 0;
        }
        void plus_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.AntiqueWhite;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            op = 0;
        }
        void minus_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.AntiqueWhite;
            mul.BackColor = Color.White;
            div.BackColor = Color.White;
            op = 1;
        }
        void mul_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.AntiqueWhite;
            div.BackColor = Color.White;
            op = 2;
        }
        void div_Click(object o, EventArgs e)
        {
            plus.BackColor = Color.White;
            minus.BackColor = Color.White;
            mul.BackColor = Color.White;
            div.BackColor = Color.AntiqueWhite;
            op = 3;
        }
        void point_Click(object o, EventArgs e)
        {
            p = 1;
            disp.Text += ",";
        }
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
            disp.Text = this.result.ToString();
            x = 0;
            p = 0;
        }
    }
}
