using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personalTaxCalculate
{
    class TaxManager
    {
        public const string UNKNOW = "N/A";
        // frm Form1
        private string personalID = "";
        private string firstName = "";
        private string lastName = "";
        private DateTime birthDate = DateTime.Now;

        // frm salary
        private double personalSalary = 0;

        // frm frmProvidentFund
        private bool isProvidentFund = false;
        private string providentFund = "";

        // frm ChildrenParentCripple
        private bool isParentChecked = false;
        private bool isChildenChecked = false;
        private bool isCrippleChecked = false;
        private bool isParentDadChecked = false;
        private bool isParentMomChecked = false;
        private Int32 qtyCripple = 0;
        private Int32 qtyChildenNonStudy = 0;
        private Int32 qtyChildenDomesticStudy = 0;
        private Int32 qtyChildenForeignStudy = 0;

        //frm relationStatus
        private bool isSingleChecked = false;
        private bool isMarryChecked = false;
        private bool isDivorceChecked = false;
        private bool isMarryIncome = false;

        //frm Insurance
        private bool isInsuanceGeneral = false;
        private bool isInsurancPension = false;
        private bool isInsuranceParents = false;
        private double insuranceGeneral = 0.0;
        private double insurancePension = 0.0;
        private double insuranceParents = 0.0;

        //frm socialInsurance
        private double socialInsurance = 0.0;

        //frm LTF
        private bool isLTFinvest = false;
        private double ltfInvest = 0.0;

        //frm RFT
        private bool isRfd1 = false;
        private bool isRfd2 = false;
        private bool isRfd3 = false;
        private bool isRfd4 = false;
        private double rfd1 = 0;
        private double rfd2 = 0;
        private double rfd3 = 0;
        private double rfd4 = 0;

        //frm interrestHome
        private bool isHaveInterrset = false;
        private double interrestHome = 0;

        //frmDonate
        private bool isDonate = false;
        private bool isDonateGeneral = false;
        private bool isDonateEducation = false;
        private bool isDonateFlood = false;
        private double donateGeneral = 0;
        private double donateEducation = 0;
        private double donateFlood = 0;

        // init Cal
        private double netIncome = 0;
        private double taxRate = 0.5;
        private double taxMoneyRate = 0;
        private double taxRateFix = 0;

        // helpers
        public string PersonalID { get => personalID; set => personalID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public double PersonalSalary { get => PersonalSalary1; set => PersonalSalary1 = value; }
        public bool IsProvidentFund { get => isProvidentFund; set => isProvidentFund = value; }
        public string ProvidentFund { get => providentFund; set => providentFund = value; }
        public bool IsParentChecked { get => isParentChecked; set => isParentChecked = value; }
        public bool IsChildenChecked { get => isChildenChecked; set => isChildenChecked = value; }
        public bool IsCrippleChecked { get => isCrippleChecked; set => isCrippleChecked = value; }
        public bool IsParentDadChecked { get => isParentDadChecked; set => isParentDadChecked = value; }
        public bool IsParentMomChecked { get => isParentMomChecked; set => isParentMomChecked = value; }
        public int QtyCripple { get => qtyCripple; set => qtyCripple = value; }
        public int QtyChildenNonStudy { get => qtyChildenNonStudy; set => qtyChildenNonStudy = value; }
        public int QtyChildenDomesticStudy { get => qtyChildenDomesticStudy; set => qtyChildenDomesticStudy = value; }
        public int QtyChildenForeignStudy { get => qtyChildenForeignStudy; set => qtyChildenForeignStudy = value; }
        public bool IsSingleChecked { get => isSingleChecked; set => isSingleChecked = value; }
        public bool IsMarryChecked { get => isMarryChecked; set => isMarryChecked = value; }
        public bool IsDivorceChecked { get => isDivorceChecked; set => isDivorceChecked = value; }
        public bool IsMarryIncome { get => isMarryIncome; set => isMarryIncome = value; }
        public bool IsInsuanceGeneral { get => isInsuanceGeneral; set => isInsuanceGeneral = value; }
        public bool IsInsurancPension { get => isInsurancPension; set => isInsurancPension = value; }
        public bool IsInsuranceParents { get => isInsuranceParents; set => isInsuranceParents = value; }
        public double InsuranceGeneral { get => insuranceGeneral; set => insuranceGeneral = value; }
        public double InsurancePension { get => insurancePension; set => insurancePension = value; }
        public double InsuranceParents { get => insuranceParents; set => insuranceParents = value; }
        public double SocialInsurance { get => socialInsurance; set => socialInsurance = value; }
        public bool IsLTFinvest { get => isLTFinvest; set => isLTFinvest = value; }
        public double LtfInvest { get => ltfInvest; set => ltfInvest = value; }
        public double Rfd1 { get => rfd1; set => rfd1 = value; }
        public double Rfd2 { get => rfd2; set => rfd2 = value; }
        public double Rfd3 { get => rfd3; set => rfd3 = value; }
        public double Rfd4 { get => rfd4; set => rfd4 = value; }
        public bool IsHaveInterrset { get => isHaveInterrset; set => isHaveInterrset = value; }
        public double InterrestHome { get => interrestHome; set => interrestHome = value; }
        public bool IsDonate { get => isDonate; set => isDonate = value; }
        public double DonateGeneral { get => donateGeneral; set => donateGeneral = value; }
        public double DonateEducation { get => donateEducation; set => donateEducation = value; }
        public double DonateFlood { get => donateFlood; set => donateFlood = value; }
        public bool IsRfd1 { get => isRfd1; set => isRfd1 = value; }
        public bool IsRfd2 { get => isRfd2; set => isRfd2 = value; }
        public bool IsRfd3 { get => isRfd3; set => isRfd3 = value; }
        public bool IsRfd4 { get => isRfd4; set => isRfd4 = value; }
        public bool IsDonateFlood { get => isDonateFlood; set => isDonateFlood = value; }
        public bool IsDonateEducation { get => isDonateEducation; set => isDonateEducation = value; }
        public bool IsDonateGeneral { get => isDonateGeneral; set => isDonateGeneral = value; }
        public double PersonalSalary1 { get => personalSalary; set => personalSalary = value; }


        // calulator
        private void calTaxRate()
        {
            // net Income 
            // check range
            if (netIncome <= 150000)                                  // 1
            {
                taxRate = 0;
                taxMoneyRate = 150000;
                taxRateFix = 0;
            }
            else if (netIncome >= 150001 && netIncome <= 300000)       // 2
            {
                taxRate = 0.5;
                taxMoneyRate = 150000;
                taxRateFix = 0;

            }
            else if (netIncome >= 300001 && netIncome <= 500000)        // 3
            {
                taxMoneyRate = 300000;
                taxRate = 0.1;
                taxRateFix = 7500;

            }
            else if (netIncome >= 500001 && netIncome <= 750000)        // 4
            {
                taxMoneyRate = 27500;
                taxRate = 0.15;
                taxRateFix = 65000;
            }
            else if (netIncome >= 750001 && netIncome <= 1000000)        // 5
            {
                taxMoneyRate = 750000;
                taxRate = 0.2;
                taxRateFix = 65000;
            }
            else if (netIncome >= 1000001 && netIncome <= 2000000)        // 6
            {
                taxMoneyRate = 1000000;
                taxRate = 0.25;
                taxRateFix = 115000;
            }
            else if (netIncome >= 2000001 && netIncome <= 5000000)        // 7
            {
                taxMoneyRate = 2000000;
                taxRate = 0.30;
                taxRateFix = 365000;
            }
            else if (netIncome >= 5000001)                                 // 8
            {
                taxMoneyRate = 5000000;
                taxRate = 0.35;
                taxRateFix = 1265000;
            }
            else
            {
                taxRate = 0;
            }

        }


        private void calNetIncomePersonal()
        {
            // เเงินได้สุทธิ
        }

        private void calExemsionPersonal()
        {
            // ค่าลดหย่อน
        }

        private void calPayPersonal()
        {
            // ค่าใช้จ่าย
        }

        private void calTaxPersonal()
        {
            //เงินได้ - ค่าใช้จ่าย - ค่าลดหย่อน = เงินได้สุทธิ


            // [ เงินได้สุทธิ - taxMoney ] * taxRate = ?
        }


        // 1. ค่าลดหย่อนส่วนตัว	฿30,000 ?
        public double getExemsionPersonal()
        {
            return 30000;
        }


        // 2. ค่าลดหย่อนคู่สมรส คนละ ฿30,000 และกฎหมายอนุญาตให้มีได้เพียง 1 คน
        public double getExemsionRelation()
        {
            // สมรส ไม่มีรายได้
            if (IsMarryChecked && isMarryIncome)
            {
                return 30000;
            }
            else
            {
                return 0;
            }

        }

        //3. ค่าลดหย่อนบุตร คนละ ฿30,000
        public double getExemsionChilden()
        {
            double sum = 0;
            if (isChildenChecked)
            {
                // over 3
                //if ((QtyChildenNonStudy + qtyChildenForeignStudy + qtyChildenDomesticStudy) > 3)
                //{
                //    return 0;
                //}

                sum += (QtyChildenNonStudy * 15000);
                sum += (qtyChildenForeignStudy * 17000);
                sum += (qtyChildenDomesticStudy * 15000);
            }

            return sum;

        }

        //4. ค่าลดหย่อนบิดามารดา คนละ ฿30,000
        public double getExemsionParent()
        {
            double sum = 0;
            if( isParentChecked )
            {
                if (IsParentDadChecked)
                    sum += 30000;

                if (IsParentMomChecked)
                    sum += 30000;                
            }

            return sum;
        }
        //5. ค่าลดหย่อนผู้พิการหรือทุพพลภาพ คนละ ฿60,000
        public double getExemsionCripple()
        {
            double sum = 0;
            if (IsCrippleChecked)
            {
                sum += (QtyCripple * 60000);

                if(sum > 60000)
                {
                    sum = 60000;
                }
            }

            return sum;
        }

        //6. ประกันสังคม ตามที่จ่ายจริงสูงสุดไม่เกิน 9,000 บาท
        public double getExemsionSocialInsurance()
        {
            double sum = SocialInsurance;
            if(SocialInsurance > 9000)
            {
                sum = 9000;
            }
            return sum;
        }

        //7. เบี้ยประกันชีวิต มี 2 ประเภท คือ
        //– ประกันชีวิต(แบบทั่วไป) ลดหย่อนได้สูงสุดไม่เกิน 100,000 บาท
        //– ประกันชีวิต(แบบบำนาญ) ลดหย่อนได้ 15% ของเงินได้ สูงสุดไม่เกิน 200,000 บาท
        public double getExemsionInsurance()
        {
            double sum = 0;
            double netIncome_15 = PersonalSalary1 * 0.15;
            double tmpInsurancePension = InsurancePension;
            double tmpInsuranceParents = InsuranceParents;
            double tmpInsuranceGeneral = InsuranceGeneral;
            

            // เบี้ยประกันชีวิตทั่วไป
            if (IsInsuanceGeneral)
            {
                   
                if(tmpInsuranceGeneral > 100000 )
                {
                    sum += 100000;
                }
                else
                {
                    sum += tmpInsuranceGeneral;
                }
            }

            // เบี้ยประกันชีวิตแบบบำนาญ
            if (IsInsurancPension)
            {
                // not over 15% 's income
                if (tmpInsurancePension >= netIncome_15)
                {
                    tmpInsurancePension = netIncome_15;
                }

                // not over 2000000
                if (tmpInsurancePension >= 200000)
                {
                    tmpInsurancePension = 200000;
                }

                sum += tmpInsurancePension;
            }

            // เบี้ยประกันสุขภาพ บิดามารดา
            if (IsInsuranceParents)
            {
                // not over 2000000
                if ( tmpInsuranceParents >= 15000 )
                {
                    tmpInsuranceParents = 15000;
                }

                sum += tmpInsuranceParents;
            }


            return sum;
        }


        // 8. กองทุนรวมหุ้นระยะยาว (LTF) เป็นกองทุนรวมอีกประเภทหนึ่งที่จัดตั้งขึ้นมาเพื่อส่งเสริมการลงทุนในระยะยาว โดยเน้นลงทุนในตลาดหุ้นเป็นหลัก ลดหย่อนได้ 15% ของเงินได้ที่ต้องเสียภาษี จำนวนสูงสุดไม่เกิน 500,000 บาท 
        // โดยกองทุนรวม LTF นั้นมีเงื่อนไขเพิ่มเติม คือ ต้องถือหน่วยลงทุนไว้ไม่น้อยกว่า 7 ปีปฎิทินด้วยครับ สำหรับการซื้อตั้งแต่วันที่ 1 มกราคม 2559 – 31 ธันวาคม 2562
        public double getExemsionLTF()
        {
            double netIncome_15 = PersonalSalary1 * 0.15;
            double tmpLtfInvest = LtfInvest;

            //  ลดหย่อนได้ 15% ของเงินได้ที่ต้องเสียภาษี 
            if (tmpLtfInvest >= netIncome_15 )
            {
                tmpLtfInvest = netIncome_15;
            }

            // จำนวนสูงสุดไม่เกิน 500,000 บาท 
            if (tmpLtfInvest >= 500000)
            {
                tmpLtfInvest = 500000;
            }

            return tmpLtfInvest;
        }

        // 9.กองทุนรวมเพื่อการเลี้ยงชีพ (RMF) เป็นกองทุนรวมประเภทหนึ่งที่ลงทุนไว้ในสินทรัพย์หลากหลายประเภท ซึ่งมีวัตถุประสงค์ไว้ใช้ในการวางแผนเกษียณของเราครับ นำมาลดหย่อนได้ 15% ของเงินได้ที่ต้องเสียภาษี จำนวนสูงสุดไม่เกิน 500,000 บาท โดยกองทุนรวมเพื่อการเลี้ยงชีพ หรือ RMF มีเงื่อนไขเพิ่มเติมตามนี้ครับ
        
        public double getExemsionRMF()
        {
            double sum = 0;
            if (IsRfd1)
            {
                sum += Rfd1;
            }

            if (IsRfd2)
            {
                sum += Rfd2;
            }

            if (IsRfd3)
            {
                sum += Rfd3;
            }

            if (IsRfd4)
            {
                sum += Rfd4;
            }


            if( sum > 500000)
            {
                sum = 500000;
            }

            return sum;

        }

        //10.ลดหย่อนดอกเบี้ยที่อยู่อาศัย
    
        public double getExensionInterestHome()
        {
            if(InterrestHome > 100000)
            {
                InterrestHome = 100000;
            }
            else
            {
                InterrestHome = InterrestHome;
            }
            return InterrestHome;
        }

        //11. ลดหย่อนเงินบริจาค
        public double getExemsionDonate()
        {
            double sum =0;
            double totalIncome;
            double totalIncome_10percent;
            totalIncome = PersonalSalary - (getExemsionPersonal() + getExemsionRelation() + getExemsionChilden() + getExemsionParent() + getExemsionCripple() + getExemsionSocialInsurance() + getExemsionInsurance() + getExemsionLTF() + getExemsionRMF() + getExensionInterestHome());
            totalIncome_10percent = totalIncome * 0.10;
            if (DonateGeneral> totalIncome_10percent)
            {
                sum += totalIncome_10percent;
            }else
            {
                sum += DonateGeneral;
            }

            if(DonateEducation > totalIncome_10percent)
            {
                sum += totalIncome_10percent * 2;
            }else
            {
                sum += DonateEducation * 2;
            }

            return sum;

        }


            public string getRelationStatus()
        {
            if(isSingleChecked)
            {
                return "โสด";
            }

            if (isMarryChecked)
            {
                return "สมรส";
            }

            if (isDivorceChecked)
            {
                return "หย่า / หม้าย";
            }

            return UNKNOW;
            
        }

       
    }
}
