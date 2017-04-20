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
    public partial class frmLTF : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmLTF()
        {
            InitializeComponent();
        }

        private void frmLTF_Load(object sender, EventArgs e)
        {
            if(TaxMng == null)
            {
                taxMng = new TaxManager();
            }
            
            //load object
            textBox1.Text = Utils.MoneyFormat(taxMng.LtfInvest.ToString());

            setStatus_LTFinvest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmInsurance frm = new frmInsurance();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save ob
            taxMng.LtfInvest = Utils.convertDouble(textBox1.Text);

            // Next form
            this.Hide();

            frmRMF frm = new frmRMF();
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

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = Utils.MoneyFormat(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taxMng.IsLTFinvest = true;
            setStatus_LTFinvest();        }

        private void button2_Click(object sender, EventArgs e)
        {
            taxMng.IsLTFinvest = false;
            setStatus_LTFinvest();
        }

        private void setStatus_LTFinvest()
        {
            if(taxMng.IsLTFinvest)
            {
                groupBox1.Enabled = true;
                button1.BackColor = Color.Orange;
                button2.BackColor = SystemColors.Control;
                textBox1.Focus();
            }
            else
            {
                groupBox1.Enabled = false;
                button1.BackColor = SystemColors.Control;
                button2.BackColor = Color.Orange;
                textBox1.Text = "";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
