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
    public partial class frmMain : Form
    {
        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            statusStrip1.Text = "Personal Tax Calulator";
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            
           
            


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.TaxMng = taxMng;

            frm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSearch frm = new frmSearch();
            frm.TaxMng = taxMng;

            frm.Show();

        }
    }
}
