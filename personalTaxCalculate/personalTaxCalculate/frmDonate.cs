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
    public partial class frmDonate : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmDonate()
        {
            InitializeComponent();
        }

        private void frmDonate_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            groupBox1.Enabled = taxMng.IsDonate;            
            textBox1.Text = Utils.MoneyFormat(taxMng.DonateGeneral.ToString());
            textBox2.Text = Utils.MoneyFormat(taxMng.DonateEducation.ToString());
            textBox3.Text = Utils.MoneyFormat(taxMng.DonateFlood.ToString());
            checkBox1.Checked = taxMng.IsDonateGeneral;
            checkBox2.Checked = taxMng.IsDonateEducation;
            checkBox3.Checked = taxMng.IsDonateFlood;

            setStatus_donate();
            setStatus_DonateEducation();
            setStatus_DonateGeneral();
            setStatus_DonateFlood();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmInterestHome frm = new frmInterestHome();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taxMng.IsDonate = true;
            setStatus_donate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            taxMng.IsDonate = false;
            setStatus_donate();
            
        }

        private void setStatus_donate()
        {
            if (taxMng.IsDonate)
            {
                groupBox1.Enabled = taxMng.IsDonate;
                button1.BackColor = Color.Orange;
                button2.BackColor = SystemColors.Control;
            }
            else
            {
                groupBox1.Enabled = taxMng.IsDonate;
                button1.BackColor = SystemColors.Control;
                button2.BackColor = Color.Orange;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                checkBox1.Checked &= taxMng.IsDonate;
                checkBox2.Checked &= taxMng.IsDonate;
                checkBox3.Checked &= taxMng.IsDonate;
            }

        }

        private void setStatus_DonateGeneral() {
            if (taxMng.IsDonateGeneral)
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
        private void setStatus_DonateEducation() {
            if (taxMng.IsDonateEducation)
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
        private void setStatus_DonateFlood() {
            if (taxMng.IsDonateFlood)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsDonateGeneral = checkBox1.Checked;
            setStatus_DonateGeneral();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsDonateEducation = checkBox2.Checked;
            setStatus_DonateEducation();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            taxMng.IsDonateFlood = checkBox3.Checked;
            setStatus_DonateFlood();
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            // save obj
            taxMng.DonateGeneral = Utils.convertDouble(textBox1.Text);
            taxMng.DonateEducation = Utils.convertDouble(textBox2.Text);
            taxMng.DonateFlood = Utils.convertDouble(textBox3.Text);

            this.Hide();

            frmSumary frm = new frmSumary();
            frm.TaxMng = taxMng;
            frm.Show();
        }
    }
}
