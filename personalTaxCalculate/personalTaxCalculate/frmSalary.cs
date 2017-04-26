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
    public partial class frmSalary : Form
    {
        private TaxManager taxMng;
        //internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        internal TaxManager TaxMng
        {
            get { return taxMng; }
            set { taxMng = value; }
        }

        public frmSalary()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.TaxMng = taxMng;
            frm.Show();
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            double tmp = Utils.convertDouble(textBox1.Text);
            if (tmp <= 0)
            {
                MessageBox.Show("กรุณากรอก เงินได้ของคุณ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else
            {
                taxMng.PersonalSalary = Convert.ToDouble( textBox1.Text);

                this.Hide();

                frmRelationStatus frm = new frmRelationStatus();
                frm.TaxMng = taxMng;
                frm.Show();
            }
           
            
        }

        private void frmSalary_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            textBox1.Text = Utils.MoneyFormat(Convert.ToString(taxMng.PersonalSalary)); 
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = Utils.MoneyFormat(textBox1.Text);
        }
    }
}
