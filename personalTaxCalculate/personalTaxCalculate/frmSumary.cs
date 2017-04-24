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
    public partial class frmSumary : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }
        public frmSumary()
        {
            InitializeComponent();
        }

        private void frmSumary_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }
            
            lblPersonalID.Text = taxMng.PersonalID;
            lblFirstName.Text = taxMng.FirstName;
            lblLastName.Text = taxMng.LastName;
            lblBirthDate.Text = taxMng.BirthDate.ToLongDateString();
            lblRelationStatus.Text = taxMng.getRelationStatus();

            lblPersonalSalary.Text = Utils.MoneyFormat(Convert.ToString(taxMng.PersonalSalary));

            //1.
            lblExemsionPersonal.Text = Utils.MoneyFormat(taxMng.getExemsionPersonal().ToString());
            //2.
            lblExemsionRelationStatus.Text = Utils.MoneyFormat(taxMng.getExemsionRelation().ToString());
            //3.
            lblExemsionChilden.Text = Utils.MoneyFormat(taxMng.getExemsionChilden().ToString());
            //4.
            lblExemsionParent.Text = Utils.MoneyFormat(taxMng.getExemsionParent().ToString());
            //5.
            lblExemsionCripple.Text = Utils.MoneyFormat(taxMng.getExemsionCripple().ToString());
            //6.
            lblExemsionSocailInsurance.Text = Utils.MoneyFormat(taxMng.getExemsionSocialInsurance().ToString());
            //7.
            lblExemsionInsurance.Text = Utils.MoneyFormat(taxMng.getExemsionInsurance().ToString());
            //8.
            lblExemsionLTF.Text = Utils.MoneyFormat(taxMng.getExemsionLTF().ToString());
            //9.
            lblExemsionRMF.Text = Utils.MoneyFormat(taxMng.getExemsionRMF().ToString());
            //10.
            lblExemsionInterrestHome.Text = Utils.MoneyFormat(taxMng.getExensionInterestHome().ToString());
            //11.
            lblExemsionDonate.Text = Utils.MoneyFormat(taxMng.getExemsionDonate().ToString());


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDonate frm = new frmDonate();
            frm.TaxMng = taxMng;
            frm.Show();

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmReport frm = new frmReport();
            frm.TaxMng = taxMng;
            frm.Show();

        }
    }
}
