using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace personalTaxCalculate
{
    class Utils
    {
        public static string MoneyFormat(string input)
        {
            if (input != "")
                return string.Format("{0:#,##0.00}", double.Parse(input));
            return null;
        }


        public static void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

   
        public static Boolean VerifyPeopleID(String PID)
        {
            string digit = null;
            //ตรวจสอบว่าทุก ๆ ตัวอักษรเป็นตัวเลข
            if (PID.ToCharArray().All(c => char.IsNumber(c)) == false)
                return false;
            //ตรวจสอบว่าข้อมูลมีทั้งหมด 13 ตัวอักษร
            if (PID.Trim().Length != 13)
                return false;
            int sumValue = 0;
            for (int i = 0; i < PID.Length - 1; i++)
                sumValue += int.Parse(PID[i].ToString()) * (13 - i);
            int v = 11 - (sumValue % 11);

            if (v.ToString().Length == 2)
            {
                digit = v.ToString().Substring(1, 1);
            }
            else
            {
                digit = v.ToString();
            }
            return PID[12].ToString() == digit;
        }

        public static double convertDouble(string text)
        {
            if (text == "")
                return 0;
            return Convert.ToDouble(text);
        }

    }
}
