using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_MK1
{
    public partial class CalculatorMk1 : Form
    {
        
        public CalculatorMk1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) 
            {
                textBox1.Text = "0";
            }
        }

        //Right Side  and numbers     
        private void buttonZero_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + "1";
            }
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + "4";
            }
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + "5";
            }
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + "6";
            }
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + "7";
            }
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + "8";
            }
        }
        private void buttonNine_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + "9";
            }
        }
        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.EndsWith(".")) { return; }
            else { textBox1.Text = textBox1.Text + "."; }
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = " ";
        }

        // Operations
        private void buttonSignChange_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            { return; } 
            else
            {
                string expression = textBox1.Text;
                string[] numbers = expression.Split(new char[] {'+','-','*','/'}, StringSplitOptions.RemoveEmptyEntries);
               

                if (numbers.Length == 1) 
                {
                    if (expression.StartsWith("-"))
                    {
                        textBox1.Text = expression.Substring(1);
                    }
                    else
                    {
                        textBox1.Text = '-' + expression;
                    }
                }
                else
                {
                    string rightmostnumbers = numbers.Last();
                    int lastindex = expression.LastIndexOf(rightmostnumbers);
                    if (lastindex > 0 && expression[lastindex - 1] == '-')
                    {
                        textBox1.Text = expression.Substring(0, lastindex - 1) + '+' + rightmostnumbers;
                    }
                    else if (lastindex > 0 && expression[lastindex - 1] == '+')
                    {
                        textBox1.Text = expression.Substring(0, lastindex - 1) + '-' + rightmostnumbers;
                    } 
                    else
                    {
                        textBox1.Text = expression.Substring(0, lastindex) + '-' + rightmostnumbers;
                    }
                }
            }          
        }

        private void buttonAddition_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else if ("+-*/".Contains(textBox1.Text.Last()))
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text + "+";
            }
        }
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else if ("+-*/".Contains(textBox1.Text.Last()))
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text + "-";
            }
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0";
            }
            else if ("+-*/".Contains(textBox1.Text.Last()))
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text + "*";
            }
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "0";
            }
            else if ("+-*/".Contains(textBox1.Text.Last()))
            {
                return;
            }
            else
            {
                textBox1.Text = textBox1.Text + "/";
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }

        }

        private void buttonResult_Click(object sender, EventArgs e)
        {
            try
            {
                string expression = textBox1.Text;
                textBox2.Text = expression + "=";
                DataTable table = new DataTable();
                var result = table.Compute(expression, string.Empty);

                if (result.ToString() == "∞" || result.ToString() == "-∞")
                {
                    MessageBox.Show("You can't divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "0";
                    textBox2.Text = "";
                    return;
                }
                textBox1.Text = $"{result}";
            }
            catch (Exception ex) 
            {
                textBox1.Text = "0";
                MessageBox.Show("ERROR");
            }
        }
    }
}
