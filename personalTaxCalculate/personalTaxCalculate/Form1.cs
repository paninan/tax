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
    public partial class Form1 : Form
    {

        Boolean IsChangeDateTimePiker = false;
        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public Form1()
        {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //  validate field
            if (textBox1.Text == "")
            {
                MessageBox.Show("กรุณากรอก เลขบัตรประจำตัวประชาชน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else if (Utils.VerifyPeopleID(textBox1.Text) == false)
            {
                MessageBox.Show("กรุณาตรวจสอบ เลขบัตรประจำตัวประชาชน", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("กรุณากรอก ชื่อ ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning); textBox1.Focus();
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("กรุณากรอก นามสกุล ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
            }
            else if (!IsChangeDateTimePiker)
            {
                MessageBox.Show("กรุณาเลือก วันเดือนปีเกิด ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicker1.Focus();
            }            
            else
            {
                // 
                // TaxManager taxMng = new TaxManager();
                taxMng.PersonalID = textBox1.Text;
                taxMng.FirstName = textBox2.Text;
                taxMng.LastName = textBox3.Text;
                taxMng.BirthDate = dateTimePicker1.Value;

                this.Hide();

                frmSalary frm = new frmSalary();
                frm.TaxMng = taxMng;
                frm.Show();
            }


     
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            textBox1.Text = taxMng.PersonalID;
            textBox2.Text = taxMng.FirstName;
            textBox3.Text = taxMng.LastName;
            dateTimePicker1.Value = taxMng.BirthDate;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Utils.ClearAllText(this);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            IsChangeDateTimePiker = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain();
            frm.TaxMng = taxMng;

            frm.Show();
        }
    }
}
