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
    public partial class frmInterestHome : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmInterestHome()
        {
            InitializeComponent();
        }

        private void frmInterestHome_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            // button back 
            setStatus_haveInterrestt();
            textBox1.Text =Utils.MoneyFormat(taxMng.InterrestHome + "");



        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Hide();

            frmRMF frm = new frmRMF();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //save ob
            taxMng.InterrestHome = Utils.convertDouble(textBox1.Text);
            

            // Next form
            this.Hide();

            frmDonate frm = new frmDonate();
            frm.TaxMng = taxMng;
            frm.Show();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taxMng.IsHaveInterrset = true;
            setStatus_haveInterrestt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            taxMng.IsHaveInterrset = false;
            setStatus_haveInterrestt();

        }

        private void setStatus_haveInterrestt()
        {
            if (taxMng.IsHaveInterrset)
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
    }

}
