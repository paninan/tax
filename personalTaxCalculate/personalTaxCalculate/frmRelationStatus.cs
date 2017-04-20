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
    public partial class frmRelationStatus : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmRelationStatus()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            taxMng.IsSingleChecked = !taxMng.IsSingleChecked;
            taxMng.IsMarryChecked = false;
            taxMng.IsDivorceChecked = false;

            setStatus_single();
            setStatus_marry();
            setStatus_divorce();
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {            
            taxMng.IsSingleChecked = false;
            taxMng.IsMarryChecked = !taxMng.IsMarryChecked;
            taxMng.IsDivorceChecked = false;

            setStatus_single();
            setStatus_marry();
            setStatus_marryIncome();
            setStatus_divorce();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
            taxMng.IsSingleChecked = false;
            taxMng.IsMarryChecked = false;
            taxMng.IsDivorceChecked = !taxMng.IsDivorceChecked;

            setStatus_single();
            setStatus_marry();
            setStatus_divorce();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmRelationStatus_Load(object sender, EventArgs e)
        {
            if(TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            setStatus_single();
            setStatus_marry();
            setStatus_divorce();
            
            if (TaxMng.IsMarryChecked) {
                setStatus_marryIncome();
            }
                
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            //next form
            this.Hide();

            frmChildrenParentsCripple frm = new frmChildrenParentsCripple();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSalary frm = new frmSalary();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void setStatus_single()
        {
            if(taxMng.IsSingleChecked)
            {
                // green
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BackColor = Color.Green;                
            }
            else
            {
                // non green
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox1.BackColor = SystemColors.Control;
            }

            
        }

        private void setStatus_marry()
        {
            if (taxMng.IsMarryChecked)
            {
                // green
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BackColor = Color.Green;
                groupBox1.Enabled = true;
            }
            else
            {
                // non green
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox2.BackColor = SystemColors.Control;
                groupBox1.Enabled = false;
                button1.BackColor = SystemColors.Control;
                button2.BackColor = SystemColors.Control;
            }
            
        }

        private void setStatus_divorce()
        {
            if (taxMng.IsDivorceChecked)
            {
                // green
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox3.BackColor = Color.Green;
            }
            else
            {
                // non green
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox3.BackColor = SystemColors.Control;
            }
            
        }

        private void setStatus_marryIncome()
        {
            if (taxMng.IsMarryIncome)
            {
                // green
                button1.BackColor = Color.Orange;
                button2.BackColor = SystemColors.Control;
            }
            else
            {
                // non green
                button1.BackColor = SystemColors.Control;
                button2.BackColor = Color.Orange;
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            taxMng.IsMarryIncome = true;
            setStatus_marryIncome();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            taxMng.IsMarryIncome = false;
            setStatus_marryIncome();

        }
    }
}
