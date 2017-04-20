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
    public partial class frmSocialInsurance : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmSocialInsurance()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSocialInsurance_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            textBox1.Text = Utils.MoneyFormat(taxMng.SocialInsurance.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmChildrenParentsCripple frm = new frmChildrenParentsCripple();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            //save ob
            taxMng.SocialInsurance = Convert.ToDouble(textBox1.Text);

            // validate
            if (validateSocialInsurance() == false)
            {
                MessageBox.Show("สามารถหักลดหย่อย ได้ไม่เกิน 9,000 บาท", "กรุณาตรวจสอบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text ="";
                textBox1.Focus();
                return;
            }
            

            //next form
            this.Hide();

            frmInsurance frm = new frmInsurance();
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

        private bool validateSocialInsurance()
        {
            if( taxMng.SocialInsurance <= 9000 )
            {
                return true;
            }
            return false;
        }
    }
}
