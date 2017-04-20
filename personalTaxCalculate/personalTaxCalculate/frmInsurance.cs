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
    public partial class frmInsurance : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmInsurance()
        {
            InitializeComponent();
        }

        private void frmInsurance_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }


            textBox1.Text = Utils.MoneyFormat(taxMng.InsuranceGeneral.ToString());
            textBox2.Text = Utils.MoneyFormat(taxMng.InsurancePension.ToString());
            textBox3.Text = Utils.MoneyFormat(taxMng.InsuranceParents.ToString());

            setStatus_general();
            setStatus_parents();
            setStatus_pension();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSocialInsurance frm = new frmSocialInsurance();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save ob 
            taxMng.InsuranceGeneral = Utils.convertDouble(textBox1.Text);
            taxMng.InsurancePension = Utils.convertDouble(textBox2.Text);
            taxMng.InsuranceParents = Utils.convertDouble(textBox3.Text);




            // Next form
            this.Hide();

            frmLTF frm = new frmLTF();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            taxMng.IsInsuanceGeneral = !taxMng.IsInsuanceGeneral;
            setStatus_general();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            taxMng.IsInsurancPension = !taxMng.IsInsurancPension;
            setStatus_pension();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            taxMng.IsInsuranceParents = !taxMng.IsInsuranceParents;
            setStatus_parents();
        }

        private void setStatus_general()
        {
            if (taxMng.IsInsuanceGeneral)
            {
                // green
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BackColor = Color.Green;

                textBox1.Enabled = true;
            }
            else
            {
                // non green
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox1.BackColor = SystemColors.Control;

                textBox1.Enabled = false;
                textBox1.Text = "";
            }
        }
        private void setStatus_pension()
        {
            if (taxMng.IsInsurancPension)
            {
                // green
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BackColor = Color.Green;

                textBox2.Enabled = true;
            }
            else
            {
                // non green
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox2.BackColor = SystemColors.Control;

                textBox2.Enabled = false;
                textBox2.Text = "";
            }
        }
        private void setStatus_parents()
        {
            if (taxMng.IsInsuranceParents)
            {
                // green
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox3.BackColor = Color.Green;

                textBox3.Enabled = true;
            }
            else
            {
                // non green
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox3.BackColor = SystemColors.Control;

                textBox3.Enabled = false;
                textBox3.Text = "";
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

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
