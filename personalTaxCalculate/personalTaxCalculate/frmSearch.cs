using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personalTaxCalculate
{
    public partial class frmSearch : Form
    {
        private TaxManager taxMng;
        private SqlDataAdapter SDA;

        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmSearch()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 5)
            {
                // get personal id
                DataTable dt = new DataTable();
                SDA = taxMng.Search(textBox1.Text);
                SDA.Fill(dt);

                // show on data grid
                dataGridView1.DataSource = dt;

            }
            else
            {
                MessageBox.Show("กรุณากรอก เลขบัตรประจำตัวประชาชน มากกว่า 5 หลัก ค่ะ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
            
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain();
            frm.TaxMng = taxMng;

            frm.Show();
        }

        private void btnSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckEnter(sender,e);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            
        }

        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox1.Text.Length > 5)
                {
                    // get personal id
                    DataTable dt = new DataTable();
                    SDA = taxMng.Search(textBox1.Text);
                    SDA.Fill(dt);

                    // show on data grid
                    dataGridView1.DataSource = dt;

                }
                else
                {
                    MessageBox.Show("กรุณากรอก เลขบัตรประจำตัวประชาชน มากกว่า 5 หลัก ค่ะ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
