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
    public partial class frmChildrenParentsCripple : Form
    {

        private TaxManager taxMng;
        internal TaxManager TaxMng { get => taxMng; set => taxMng = value; }

        public frmChildrenParentsCripple()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmChildrenParentsCripple_Load(object sender, EventArgs e)
        {
            if(TaxMng == null)
            {
                taxMng = new TaxManager();
            }

            comboBox1.SelectedIndex = taxMng.QtyChildenNonStudy;
            comboBox2.SelectedIndex = taxMng.QtyChildenForeignStudy;
            comboBox3.SelectedIndex = taxMng.QtyChildenDomesticStudy;
            comboBox6.SelectedIndex = taxMng.QtyCripple;

            setStatus_Childen();
            setStatus_Cripple();
            setStatus_Parent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRelationStatus frm = new frmRelationStatus();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // vaidate 
            if ( validateChildren() == false )
            {
                MessageBox.Show("สามารถหักลดหย่อย บุตร ได้ไม่เกิน 3 คน", "กรุณาตรวจสอบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ; 
            }


            //next form
            this.Hide();

            frmSocialInsurance frm = new frmSocialInsurance();
            frm.TaxMng = taxMng;
            frm.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // tax manager
            taxMng.IsParentChecked = !taxMng.IsParentChecked;
            setStatus_Parent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            taxMng.IsChildenChecked = !taxMng.IsChildenChecked;
            setStatus_Childen();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            taxMng.IsCrippleChecked = !taxMng.IsCrippleChecked;
            setStatus_Cripple();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taxMng.IsParentDadChecked = !taxMng.IsParentDadChecked ;
            setStatus_Parent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            taxMng.IsParentMomChecked = !taxMng.IsParentMomChecked ;
            setStatus_Parent();
        }


        private void setStatus_Childen()
        {
            groupBox2.Enabled = taxMng.IsChildenChecked;
            if (taxMng.IsChildenChecked)
            {
                pictureBox2.BorderStyle = BorderStyle.FixedSingle;
                pictureBox2.BackColor = Color.Green;

                taxMng.QtyChildenNonStudy = Convert.ToInt32(comboBox1.Text);
                taxMng.QtyChildenDomesticStudy = Convert.ToInt32(comboBox2.Text);
                taxMng.QtyChildenForeignStudy = Convert.ToInt32(comboBox3.Text);
            }
            else
            {
                pictureBox2.BorderStyle = BorderStyle.None;
                pictureBox2.BackColor = SystemColors.Control;

                taxMng.QtyChildenNonStudy = 0;
                taxMng.QtyChildenDomesticStudy = 0;
                taxMng.QtyChildenForeignStudy = 0;
            }
        }

        private void setStatus_Cripple()
        {
            groupBox3.Enabled = taxMng.IsCrippleChecked;
                
            if (taxMng.IsCrippleChecked)
            {
                pictureBox3.BorderStyle = BorderStyle.FixedSingle;
                pictureBox3.BackColor = Color.Green;
                taxMng.QtyCripple = Convert.ToInt32(comboBox6.Text);
            }
            else
            {
                pictureBox3.BorderStyle = BorderStyle.None;
                pictureBox3.BackColor = SystemColors.Control;
                taxMng.QtyCripple = 0;
            }
        }


        private void setStatus_Parent()
        {
            taxMng.IsParentDadChecked &= taxMng.IsParentChecked;
            taxMng.IsParentMomChecked &= taxMng.IsParentChecked;            

            if (taxMng.IsParentDadChecked)
            {
                button1.BackColor = Color.Orange;
            }
            else
            {
                button1.BackColor = SystemColors.Control;
            }

            if (taxMng.IsParentMomChecked)
            {
                button2.BackColor = Color.Orange;
            }
            else
            {
                button2.BackColor = SystemColors.Control;
            }



            // this choice
            groupBox1.Enabled = taxMng.IsParentChecked;
            if (taxMng.IsParentChecked)
            {
                pictureBox1.BorderStyle = BorderStyle.FixedSingle;
                pictureBox1.BackColor = Color.Green;
            }
            else
            {
                pictureBox1.BorderStyle = BorderStyle.None;
                pictureBox1.BackColor = SystemColors.Control;
            }

            
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            taxMng.QtyCripple = Convert.ToInt32(comboBox6.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            taxMng.QtyChildenNonStudy = Convert.ToInt32(comboBox1.Text);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            taxMng.QtyChildenDomesticStudy = Convert.ToInt32(comboBox2.Text);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            taxMng.QtyChildenForeignStudy = Convert.ToInt32(comboBox3.Text);
        }

        private bool validateChildren()
        {
            if ((taxMng.QtyChildenNonStudy + taxMng.QtyChildenForeignStudy + taxMng.QtyChildenDomesticStudy) > 3)
            {
                return false;
            }           
            
            return true;
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ค่าเลี้ยงดูพ่อแม่ คนละ 30,000 บาท ถ้าพ่อแม่อายุมากกว่า 60 ปี และมีรายได้ทั้งปีไม่เกิน 30,000 บาท จะมีสิทธิหักลดหย่อนค่าเลี้ยงดูได้คนละ 30,000 บาท ", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ค่าลดหย่อนค่าอุปการะเลี้ยงดูคนพิการหรือคนทุพพลภาพจำนวน 60,000 บาท", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ค่าลดหย่อนบุตรและการศึกษาบุตรจำนวน 15,000 บาท" +
                "สามารถนำมาหักลดหย่อนได้ คนละ 15,000 บาท " +
                "และหักได้สูงสุดไม่เกิน 3 คน (นับเฉพาะทีมีชีวิต)" +
                "บุตรที่กำลังศึกษาภายในประเทศ โดยจะได้รับค่าลดหย่อนเพิ่มเติมอีกคนละ 2,000 บาท", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
