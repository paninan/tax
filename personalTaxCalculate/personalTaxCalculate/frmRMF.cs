using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personalTaxCalculate
{
    public partial class frmRMF : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmRMF()
        {
            InitializeComponent();
        }

        private void frmRMF_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            textBox1.Text = Utils.MoneyFormat(taxMng.Rfd1.ToString());
            textBox2.Text = Utils.MoneyFormat(taxMng.Rfd2.ToString());
            textBox3.Text = Utils.MoneyFormat(taxMng.Rfd3.ToString());
            textBox4.Text = Utils.MoneyFormat(taxMng.Rfd4.ToString());

            checkBox1.Checked = taxMng.IsRfd1;
            checkBox2.Checked = taxMng.IsRfd2;
            checkBox3.Checked = taxMng.IsRfd3;
            checkBox4.Checked = taxMng.IsRfd4;
            
            setStatus_FundsRMF();
            setStatus_FundsProvident();
            setStatus_FundsGovernmenPension();
            setStatus_FundsTeacher();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // back
            this.Hide();

            frmLTF frm = new frmLTF();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            // save ob
            taxMng.Rfd1 = Convert.ToDouble(textBox1.Text);
            taxMng.Rfd2 = Convert.ToDouble(textBox2.Text);
            taxMng.Rfd3 = Convert.ToDouble(textBox3.Text);
            taxMng.Rfd4 = Convert.ToDouble(textBox4.Text);


            // Next form
            this.Hide();

            frmInterestHome frm = new frmInterestHome();
            frm.TaxMng = taxMng;
            frm.Show();
        }


        

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = Utils.MoneyFormat(textBox1.Text);

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = Utils.MoneyFormat(textBox2.Text);

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Text = Utils.MoneyFormat(textBox3.Text);

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.Text = Utils.MoneyFormat(textBox4.Text);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsRfd1 = checkBox1.Checked;
            setStatus_FundsRMF();  
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsRfd2 = checkBox2.Checked;
            setStatus_FundsGovernmenPension();            
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsRfd3 = checkBox3.Checked;
            setStatus_FundsProvident();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsRfd4 = checkBox4.Checked;
            setStatus_FundsTeacher();
        }

        private void setStatus_FundsRMF()
        {
            if (taxMng.IsRfd1)
            {
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";

            }

        }

        private void setStatus_FundsGovernmenPension()
        {
            if (taxMng.IsRfd2)
            {
                textBox2.Enabled = true;
                textBox2.Focus();

            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";

            }

        }

        private void setStatus_FundsProvident()
        {
            if (taxMng.IsRfd3)
            {
                textBox3.Enabled = true;
                textBox3.Focus();

            }
            else
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";

            }
        }
        private void setStatus_FundsTeacher()
        {
            if (taxMng.IsRfd4)
            {
                textBox4.Enabled = true;
                textBox4.Focus();

            }
            else
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";

            }

        }
    }
}
