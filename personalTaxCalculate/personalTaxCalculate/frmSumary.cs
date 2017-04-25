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

        private void picPerson_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1. ค่าลดหย่อนส่วนตัวจำนวน 30,000 บาท คือ ค่าลดหย่อนสำหรับคนมีเงินได้ทุกคนที่ยื่นแบบแสดงรายการ แค่เพียงเรายื่นแบบแสดงรายการก็สามารถใช้สิทธิค่าลดหย่อนนี้ได้เลย", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picRelation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2. ค่าลดหย่อนคู่สมรสจำนวน 30,000 บาท คือ ค่าลดหย่อนของคู่สมรส (ตามกฎหมาย) กรณีที่คู่สมรส (สามีหรือภรรยา) ที่จดทะเบียนสมรสถูกต้องตามกฎหมายและไม่มีเงินได้", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picChliden_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3. ค่าลดหย่อนบุตรและการศึกษาบุตรจำนวน 15,000 บาท โดยคำว่า “บุตร” หมายถึง บุตรโดยกฎหมายหรือบุตรบุญธรรม สามารถนำมาหักลดหย่อนได้ คนละ 15,000 บาท และหักได้สูงสุดไม่เกิน 3 คน (นับเฉพาะทีมีชีวิต)" +
                "บุตรที่กำลังศึกษาภายในประเทศ โดยจะได้รับค่าลดหย่อนเพิ่มเติมอีกคนละ 2,000 บาท", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picParents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("4. ค่าเลี้ยงดูพ่อแม่ คนละ 30,000 บาท ถ้าพ่อแม่อายุมากกว่า 60 ปี และมีรายได้ทั้งปีไม่เกิน 30,000 บาท จะมีสิทธิหักลดหย่อนค่าเลี้ยงดูได้คนละ 30,000 บาท ", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picCripple_Click(object sender, EventArgs e)
        {
            MessageBox.Show("5. ค่าลดหย่อนค่าอุปการะเลี้ยงดูคนพิการหรือคนทุพพลภาพจำนวน 60,000 บาท " +
                "ถ้าหากเราเป็นผู้ดูแลคนพิการตามกฎหมายว่าด้วยการส่งเสริมและพัฒนาคุณภาพชีวิตคนพิการ หรือคนทุพพลภาพที่มีใบรับรองแพทย์ เราสามารถนำมาหักลดหย่อนได้คนละ 60,000 บาท " +
                "โดยมีเงื่อนไขว่าคนพิการหรือคนทุพพลภาพที่นำมาลดหย่อนนั้นต้องมีรายได้ไม่เกิน 30,000 บาทต่อปีด้วย", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picSocialInsurance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("6. ประกันสังคม ตามที่จ่ายจริงสูงสุดไม่เกิน 9,000 บาท", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picInsurance_Click(object sender, EventArgs e)
        {
            MessageBox.Show("7. เบี้ยประกันชีวิต " +
                "– ประกันชีวิต(แบบทั่วไป) ลดหย่อนได้สูงสุดไม่เกิน 100, 000 บาท" +
                "– ประกันชีวิต(แบบบำนาญ) ลดหย่อนได้ 15 % ของเงินได้ สูงสุดไม่เกิน 200, 000 บาท" +
                "- เบี้ยประกันสุขภาพพ่อแม่จำนวน 15,000 บาท ซึ่งสามารถใช้สิทธิได้ในกรณีที่พ่อแม่มีรายได้ไม่เกิน 30,000 บาทต่อปี สามารถนำค่าเบี้ยประกันสุขภาพมาลดหย่อนได้สูงสุดถึง 15,000 บาท ", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picLTF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("8. กองทุนรวมหุ้นระยะยาว (LTF) ลดหย่อนได้ 15% ของเงินได้ที่ต้องเสียภาษี จำนวนสูงสุดไม่เกิน 500,000 บาท " +
                "โดยกองทุนรวม LTF นั้นมีเงื่อนไขเพิ่มเติม คือ ต้องถือหน่วยลงทุนไว้ไม่น้อยกว่า 7 ปีปฎิทิน " +
                "สำหรับการซื้อตั้งแต่วันที่ 1 มกราคม 2559 – 31 ธันวาคม 2562 ", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picRMF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("9. กองทุนรวมเพื่อการเลี้ยงชีพ (RMF) นำมาลดหย่อนได้ 15% ของเงินได้ที่ต้องเสียภาษี " +
                "เงินสมทบ กบข. กองทุนสำรองเลี้ยงชีพ และ กองทุนสงเคราะห์ครูโรงเรียนเอกชน สามารถนำมาลดหย่อนได้ตามจำนวนที่จ่ายจริง " +
                "โดยทั้งหมดนี้รวมกันมีจำนวนสูงสุดไม่เกิน 500,000 ", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picInterestHome_Click(object sender, EventArgs e)
        {
            MessageBox.Show("10. ดอกเบี้ยเงินกู้ยืมเพื่อที่อยู่อาศัย สามารถนำมาลดหย่อนได้ตามจำนวนที่จ่ายจริง แต่สูงสุดไม่เกิน 100,000 บาท", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void picDonate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("11. เงินบริจาคเพื่อสนับสนุนการศึกษาและกีฬา สามารถหักลดหย่อนได้ 2 เท่าของเงินที่ได้จ่ายไป แต่ต้องไม่เกินร้อยละ 10 ของเงินได้พึงประเมินหลังจากหักค่าใช้จ่ายและค่าลดหย่อนอื่น" +
                "เงินบริจาคทั่วไป สามารถหักลดหย่อนได้ตามที่จ่ายจริงแต่ไม่เกินร้อยละ 10 ของเงินได้พึงประเมิน", "เงื่อนไขในการลดหย่อน", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
