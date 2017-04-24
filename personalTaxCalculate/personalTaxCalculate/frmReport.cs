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
    public partial class frmReport : Form
    {
        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmReport()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            //btnNext.Enabled = false;


            // set image chart
            taxMng.CalNetTax();
            pictureBox1.Image = picTaxRate();            
            groupBox1.Text = "จ่ายภาษี Rate "+taxMng.TaxRate;
            textBox2.Text = Utils.MoneyFormat(taxMng.NetIncome.ToString());
            textBox3.Text = Utils.MoneyFormat(taxMng.Expense.ToString());
            textBox1.Text = Utils.MoneyFormat(taxMng.NetTax.ToString());
            textBox4.Text = Utils.MoneyFormat(taxMng.Exemsion.ToString());
        }

        private Bitmap picTaxRate()
        {

            if (taxMng.TaxRate == 0)                                     
            {
                return Properties.Resources.tax_stair01;
            }
            else if (taxMng.TaxRate == 0.05)                             
            {
                return Properties.Resources.tax_stair02;
            }
            else if (taxMng.TaxRate == 0.1)                                
            {
                return Properties.Resources.tax_stair03;
            }
            else if (taxMng.TaxRate == 0.15)
            {
                return Properties.Resources.tax_stair04;
            }
            else if (taxMng.TaxRate == 0.2)
            {
                return Properties.Resources.tax_stair05;
            }
            else if (taxMng.TaxRate == 0.25)
            {
                return Properties.Resources.tax_stair06;
            }
            else if (taxMng.TaxRate == 0.3)
            {
                return Properties.Resources.tax_stair07;
            }
            else if (taxMng.TaxRate >= 0.35)
            {
                return Properties.Resources.tax_stair08;
            }
            else
            {
                return Properties.Resources.tax_stair08;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSumary frmSum = new frmSumary();
            frmSum.Show();
            frmSum.TaxMng = taxMng;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // save 
            if (taxMng.save())
            {
                MessageBox.Show("บันทึก ข้อมูล เรียนร้อย ");
            }
        }
    }
}
