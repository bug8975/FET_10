using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor_HCCS.Common
{
    public class Percentage
    {

        public static float GetPerc(string Name, int pointNum, string gears)
        {
            int axisw = 0;
            string sql = "select fet from info where name = '" + Name + "'";
            DataTable dt = SQLiteHelper.ExecuteDataTable(sql, null);
            if (dt.Rows.Count == 0)
                return 0;

            string flag = dt.Rows[0].ItemArray[0].ToString();

            #region 300A
            if ("F".Equals(flag))
            {
                if (gears.Equals("100"))
                {
                    axisw = 908;
                    if(pointNum >=110)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 110) * 0.8));
                        axisw = 908 - ceil;
                    }
                }
                else if (gears.Equals("200"))
                {
                    axisw = 910;
                    if (pointNum >= 40)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 40) * 0.0));
                        axisw = 915 - ceil;
                    }
                    if (pointNum >= 210)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.0));
                        axisw = 913 - ceil;
                    }
                }
                else
                {
                    axisw = 916;
                    if (pointNum <= 20)
                        axisw = 916;
                    if (pointNum > 30)
                        axisw = 920;
                }
            }
            #endregion

            #region 400A
            if ("G".Equals(flag))
            {
                if (gears.Equals("200"))
                {
                    axisw = 910;
                }
                else if (gears.Equals("300"))
                {
                    axisw = 915;
                    if (pointNum >= 30)
                        axisw = 917;
                }
                else
                {
                    if (pointNum == 10)
                        axisw = 912;
                    if (pointNum == 11)
                        axisw = 908;
                    if (pointNum == 12)
                        axisw = 901;
                    if (pointNum == 13)
                        axisw = 894;
                    if (pointNum >= 14)
                        axisw = 894;
                    if (pointNum >= 70)
                        axisw = 896;
                }                
            }
            #endregion

            #region 500A
            if ("H".Equals(flag))
            {
                if (gears.Equals("200"))
                {
                    axisw = 910;
                }
                else if (gears.Equals("400"))
                {
                    axisw = 910;
                    if (pointNum == 12)
                        axisw = 900;
                    if (pointNum > 12)
                        axisw = 890;
                    if (pointNum >= 30)
                        axisw = 892;
                }
                else
                {
                    axisw = 912;
                    if (pointNum == 11)
                        axisw = 905;
                    if (pointNum == 12)
                        axisw = 898;
                    if (pointNum == 13)
                        axisw = 890;
                    if (pointNum == 14)
                        axisw = 884;
                    if (pointNum == 15)
                        axisw = 877;
                    if (pointNum == 16)
                        axisw = 870;
                    if (pointNum == 17)
                        axisw = 868;
                    if (pointNum > 17)
                    {
                        axisw = 870;
                    }
                    if (pointNum > 40)
                    {
                        axisw = 873;
                    }
                }
                
            }
            #endregion

            #region 600A
            if ("I".Equals(flag))
            {
                if (gears.Equals("200"))
                {
                    axisw = 910;
                }
                else if (gears.Equals("400"))
                {
                    axisw = 910;
                    if (pointNum == 12)
                        axisw = 900;
                    if (pointNum > 12)
                        axisw = 890;
                }
                else
                {
                    axisw = 911;
                    if (pointNum == 11)
                        axisw = 905;
                    if (pointNum == 12)
                        axisw = 898;
                    if (pointNum == 13)
                        axisw = 891;
                    if (pointNum == 14)
                        axisw = 883;
                    if (pointNum == 15)
                        axisw = 877;
                    if (pointNum == 16)
                        axisw = 870;
                    if (pointNum == 17)
                        axisw = 863;
                    if (pointNum == 18)
                        axisw = 855;
                    if (pointNum >= 19)
                        axisw = 849;
                    if (pointNum >= 30 && pointNum < 60)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 30) * 0.00));
                        axisw = 850 + ceil;
                    }
                    if (pointNum >= 60)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                        axisw = 853 + ceil;
                    }
                    if (pointNum >= 250 && pointNum < 260)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 250) * 0.50));
                        axisw = 853 - ceil;
                    }
                    if (pointNum >= 260)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                        axisw = 850 + ceil;
                    }
                }
                
            }
            #endregion

            #region 800A
            if ("J".Equals(flag))
            {
                 if (gears.Equals("200"))
                {
                    axisw = 910;
                }
                 else if (gears.Equals("400"))
                 {
                     axisw = 910;
                     if (pointNum == 12)
                         axisw = 900;
                     if (pointNum > 12)
                         axisw = 890;
                 }
                 else
                 {
                     axisw = 911;
                     if (pointNum == 11)
                         axisw = 905;
                     if (pointNum == 12)
                         axisw = 898;
                     if (pointNum == 13)
                         axisw = 891;
                     if (pointNum == 14)
                         axisw = 883;
                     if (pointNum == 15)
                         axisw = 877;
                     if (pointNum == 16)
                         axisw = 870;
                     if (pointNum == 17)
                         axisw = 863;
                     if (pointNum == 18)
                         axisw = 855;
                     if (pointNum == 19)
                         axisw = 849;
                     if (pointNum == 20)
                         axisw = 842;
                     if (pointNum == 21)
                         axisw = 836;
                     if (pointNum == 22)
                         axisw = 829;
                     if (pointNum == 23)
                         axisw = 823;
                     if (pointNum == 24)
                         axisw = 815;
                     if (pointNum == 25)
                         axisw = 812;
                     if (pointNum >= 26)
                         axisw = 862;
                     if (pointNum >= 70)
                         axisw = 863;
                     if (pointNum >= 230 && pointNum < 240)
                         axisw = 859;
                     if (pointNum >= 240)
                         axisw = 863;
                 }
            }
            #endregion

            #region 1000A
            if ("K".Equals(flag))
            {
                if (gears.Equals("300"))
                {
                    axisw = 918;
                }
                else if (gears.Equals("600"))
                {
                    axisw = 913;
                    if (pointNum == 11)
                    {
                        axisw = 905;
                    }
                    if (pointNum == 12)
                    {
                        axisw = 900;
                    }
                    if (pointNum >= 13)
                    {
                        axisw = 890;
                    }
                    if (pointNum >= 14)
                    {
                        axisw = 885;
                    }
                    if (pointNum >= 15)
                    {
                        axisw = 875;
                    }
                    if (pointNum >= 17)
                    {
                        axisw = 860;
                    }
                    if (pointNum >= 19)
                    {
                        axisw = 850;
                    }
                    if (pointNum >= 20 && pointNum < 30)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 20) * 0.0));
                        axisw = 891 - ceil;
                    }
                    if (pointNum >= 30)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 20) * 0.0));
                        axisw = 938 - ceil;
                    }
                }
                else
                {
                    axisw = 911;
                    if (pointNum == 11)
                        axisw = 905;
                    if (pointNum == 12)
                        axisw = 898;
                    if (pointNum == 13)
                        axisw = 891;
                    if (pointNum == 14)
                        axisw = 883;
                    if (pointNum == 15)
                        axisw = 877;
                    if (pointNum == 16)
                        axisw = 870;
                    if (pointNum == 17)
                        axisw = 863;
                    if (pointNum == 18)
                        axisw = 855;
                    if (pointNum == 19)
                        axisw = 849;
                    if (pointNum >= 20 && pointNum < 30)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 20) * 5.0));
                        axisw = 887 - ceil;
                    }
                    if (pointNum >= 30 && pointNum <35)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 30) * 1.4));
                        axisw = 906 - ceil;
                    }
                    if (pointNum >= 35 && pointNum < 190)
                    {
                        axisw = 903;
                    }
                    if (pointNum >= 190)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 200) * 0.18));
                        axisw = 898 + ceil;
                    }
                    if (pointNum >= 190 && pointNum < 230)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 200) * 0.18));
                        axisw = 898 + ceil;
                    }
                    if (pointNum >= 230)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 200) * 0.00));
                        axisw = 900;
                    }
                    //if (pointNum == 21)
                    //    axisw = 836;
                    //if (pointNum == 22)
                    //    axisw = 829;
                    //if (pointNum == 23)
                    //    axisw = 823;
                    //if (pointNum == 24)
                    //    axisw = 815;
                    //if (pointNum == 25)
                    //    axisw = 812;
                    //if (pointNum == 26)
                    //    axisw = 803;
                    //if (pointNum == 27)
                    //    axisw = 797;
                    //if (pointNum >= 28)
                    //    axisw = 792;
                    //if (pointNum == 29)
                    //    axisw = 785;
                    //if (pointNum == 30)
                    //    axisw = 778;
                    //if (pointNum == 31)
                    //    axisw = 775;
                    //if (pointNum == 32)
                    //    axisw = 773;
                    //if (pointNum >= 33)
                    //    axisw = 773;
                }
                
            }
            #endregion

            #region 1200A
            if ("L".Equals(flag))
            {
                if (gears.Equals("300"))
                {
                    axisw = 918;
                }
                else if (gears.Equals("600"))
                {
                    axisw = 913;
                    if (pointNum == 11)
                    {
                        axisw = 905;
                    }
                    if (pointNum == 12)
                    {
                        axisw = 900;
                    }
                    if (pointNum >= 13)
                    {
                        axisw = 890;
                    }
                    if (pointNum >= 14)
                    {
                        axisw = 885;
                    }
                    if (pointNum >= 15)
                    {
                        axisw = 875;
                    }
                    if (pointNum >= 17)
                    {
                        axisw = 860;
                    }
                    if (pointNum >= 19)
                    {
                        axisw = 850;
                    }
                }
                else
                {
                    axisw = 911;
                    if (pointNum == 11)
                        axisw = 905;
                    if (pointNum == 12)
                        axisw = 898;
                    if (pointNum == 13)
                        axisw = 891;
                    if (pointNum == 14)
                        axisw = 883;
                    if (pointNum >= 15 && pointNum < 30)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 15) * 5.2));
                        axisw = 914 - ceil;
                    }
                    if (pointNum >= 30)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 30) * 2.1));
                        axisw = 906 - ceil;
                    }
                    if (pointNum >= 40)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 40) * 0.0));
                        axisw = 886 - ceil;
                    }
                    if (pointNum >= 140)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 118) * 0.0));
                        axisw = 883 - ceil;
                    }
                    if (pointNum >= 190)
                    {
                        int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 190) * 0.0));
                        axisw = 887 - ceil;
                    }
                    //if (pointNum == 16)
                    //    axisw = 870;
                    //if (pointNum == 17)
                    //    axisw = 863;
                    //if (pointNum == 18)
                    //    axisw = 855;
                    //if (pointNum == 19)
                    //    axisw = 849;
                    //if (pointNum == 20)
                    //    axisw = 842;
                    //if (pointNum == 21)
                    //    axisw = 836;
                    //if (pointNum == 22)
                    //    axisw = 829;
                    //if (pointNum == 23)
                    //    axisw = 823;
                    //if (pointNum == 24)
                    //    axisw = 815;
                    //if (pointNum == 25)
                    //    axisw = 812;
                    //if (pointNum == 26)
                    //    axisw = 803;
                    //if (pointNum == 27)
                    //    axisw = 797;
                    //if (pointNum >= 28)
                    //    axisw = 792;
                    //if (pointNum == 29)
                    //    axisw = 785;
                    //if (pointNum == 30)
                    //    axisw = 778;
                    //if (pointNum == 31)
                    //    axisw = 775;
                    //if (pointNum == 32)
                    //    axisw = 770;
                    //if (pointNum >= 33)
                    //    axisw = 765;
                    //if (pointNum == 34)
                    //    axisw = 759;
                    //if (pointNum == 35)
                    //    axisw = 754;
                    //if (pointNum == 36)
                    //    axisw = 747;
                    //if (pointNum >= 37)
                    //    axisw = 742;
                    //if (pointNum == 38)
                    //    axisw = 739;
                    //if (pointNum == 39)
                    //    axisw = 739;
                    //if (pointNum >= 40)
                    //    axisw = 739;
                }
                
            }
            #endregion

            #region 2000A
            if ("S".Equals(flag))
            {
                axisw = 928;
                if(pointNum >= 10 && pointNum <= 15)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 7.00));
                    axisw = 928 - ceil;
                }
                if (pointNum > 15 && pointNum <= 20)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 15) * 5.00));
                    axisw = 893 - ceil;
                }
                if (pointNum > 20 && pointNum <= 30)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 21) * 6.80));
                    axisw = 868 - ceil;
                }
                if (pointNum > 30 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 30) * 2.90));
                    axisw = 879 - ceil;
                }
                if (pointNum > 60 && pointNum <= 230)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 61) * 0.0));
                    axisw = 868 - ceil;
                }
                if (pointNum > 230)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 230) * 0.02));
                    axisw = 868 - ceil;
                }
                
            }
            #endregion

            #region 3000A
            if ("R".Equals(flag))
            {
                axisw = 928;
                if (pointNum >= 10 & pointNum <= 15)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 7.0));
                    axisw = 928 - ceil;
                }
                if (pointNum >= 15 & pointNum <= 20)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 15) * 5.0));
                    axisw = 893 - ceil;
                }
                if (pointNum >= 21)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 21) * 3.0));
                    axisw = 919 - ceil;
                }
                if (pointNum >= 26)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 26) * 3.5));
                    axisw = 904 - ceil;
                }
                if (pointNum >= 31)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 31) * 2.0));
                    axisw = 939 - ceil;
                }
                if (pointNum >= 45)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 45) * 1.5));
                    axisw = 913 - ceil;
                }
                if (pointNum >= 50)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 2.0));
                    axisw = 906 - ceil;
                }
                if (pointNum >= 61)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 1.0));
                    axisw = 940 - ceil;
                }
                if (pointNum >= 90)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 90) * 0.33));
                    axisw = 914 - ceil;
                }
                if (pointNum >= 110)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 110) * 0.00));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region EX30
            //EX30
            if ("M".Equals(flag))
            {
                axisw = 920;//
                if (pointNum >= 32)
                {
                    axisw = 910;
                }
                if (pointNum >= 36)
                {
                    axisw = 900;
                }
                if (pointNum >= 41)
                {
                    axisw = 890;
                }
                if (pointNum >= 46 && pointNum < 50)
                {
                    axisw = 877;
                }
                if (pointNum >= 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.3));
                    axisw = 944 - ceil;
                }
                if (pointNum > 60 && pointNum <= 70)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.15));
                    axisw = 944 - ceil;
                }
                if (pointNum > 70 && pointNum <= 80)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.0));
                    axisw = 944 - ceil;
                }
                if (pointNum > 80 && pointNum <= 110)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.0));
                    axisw = 944 - ceil;
                }
                if (pointNum > 110 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.95));
                    axisw = 944 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.6));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210 && pointNum <= 300)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.35));
                    axisw = 906 - ceil;
                }
            }
            #endregion

            #region EX50
            //EX50
            if ("N".Equals(flag))
            {
                axisw = 915;//
                if (pointNum >= 18)
                    axisw = 920;
                if (pointNum >= 36)
                    axisw = 922;
                if (pointNum >= 52)
                    axisw = 919;
                if (pointNum >= 54)
                    axisw = 916;
                if (pointNum >= 57)
                    axisw = 912;
                if (pointNum >= 59)
                    axisw = 908;
                if (pointNum >= 62)
                    axisw = 908 - (pointNum - 59);
                if (pointNum >= 67)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 2.0));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 73)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 1.00));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 98)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 0.90));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 120)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 0.90));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.70));
                    axisw = 903 - ceil;
                }
                if (pointNum >= 180)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 903 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.60));
                    axisw = 908 - ceil;
                }
                if (pointNum >= 250)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region EX60
            //EX60
            if ("O".Equals(flag))
            {
                axisw = 900;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.2));
                    axisw = 900 + ceil;
                }
                if (pointNum >= 50 && pointNum <=60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.0));
                    axisw = 935 + ceil;
                }
                if (pointNum > 60 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 1.00));
                    axisw = 935 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region EX80
            //EX80
            if ("P".Equals(flag))
            {
                axisw = 868;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.35));
                    axisw = 868 + ceil;
                }
                if (pointNum > 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 51) * 0.50));
                    axisw = 910 + ceil;
                }
                if (pointNum > 60 && pointNum <= 75)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                    axisw = 914 - ceil;
                }
                if (pointNum > 75 && pointNum <= 110)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 75) * 0.75));
                    axisw = 914 - ceil;
                }
                if (pointNum > 110 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 110) * 0.90));
                    axisw = 888 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region EX100
            //EX100
            if ("Q".Equals(flag))
            {
                axisw = 901;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.35));
                    axisw = 901 + ceil;
                }
                if (pointNum > 30 && pointNum < 50)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.10));
                    axisw = 901 + ceil;
                }
                if (pointNum >= 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.00));
                    axisw = 895 + ceil;
                }
                if (pointNum > 60 && pointNum <= 75)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                    axisw = 895 - ceil;
                }
                if (pointNum > 75 && pointNum <= 100)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 75) * 0.00));
                    axisw = 895 - ceil;
                }
                if (pointNum > 100 && pointNum <= 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 100) * 0.80));
                    axisw = 895 - ceil;
                }
                if (pointNum >= 140 && pointNum < 160)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.45));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 160 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region CT30
            //CT30
            if ("T".Equals(flag))
            {
                axisw = 920;//
                if (pointNum >= 32)
                {
                    axisw = 910;
                }
                if (pointNum >= 36)
                {
                    axisw = 900;
                }
                if (pointNum >= 41)
                {
                    axisw = 890;
                }
                if (pointNum >= 46 && pointNum < 50)
                {
                    axisw = 877;
                }
                if (pointNum >= 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.3));
                    axisw = 944 - ceil;
                }
                if (pointNum > 60 && pointNum <= 70)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.15));
                    axisw = 944 - ceil;
                }
                if (pointNum > 70 && pointNum <= 80)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.0));
                    axisw = 944 - ceil;
                }
                if (pointNum > 80 && pointNum <= 110)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 1.0));
                    axisw = 944 - ceil;
                }
                if (pointNum > 110 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.95));
                    axisw = 944 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.6));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210 && pointNum <= 300)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.35));
                    axisw = 906 - ceil;
                }
            }
            #endregion

            #region CT50
            //CT50
            if ("U".Equals(flag))
            {
                axisw = 915;//
                if (pointNum >= 18)
                    axisw = 920;
                if (pointNum >= 36)
                    axisw = 922;
                if (pointNum >= 52)
                    axisw = 919;
                if (pointNum >= 54)
                    axisw = 916;
                if (pointNum >= 57)
                    axisw = 912;
                if (pointNum >= 59)
                    axisw = 908;
                if (pointNum >= 62)
                    axisw = 908 - (pointNum - 59);
                if (pointNum >= 67)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 2.0));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 73)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 1.00));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 98)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 0.90));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 120)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 67) * 0.90));
                    axisw = 927 - ceil;
                }
                if (pointNum >= 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.70));
                    axisw = 903 - ceil;
                }
                if (pointNum >= 180)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 903 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.60));
                    axisw = 908 - ceil;
                }
                if (pointNum >= 250)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region CT60
            //CT60
            if ("V".Equals(flag))
            {
                axisw = 900;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.2));
                    axisw = 900 + ceil;
                }
                if (pointNum >= 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.0));
                    axisw = 935 + ceil;
                }
                if (pointNum > 60 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 1.00));
                    axisw = 935 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region CT80
            //CT80
            if ("W".Equals(flag))
            {
                axisw = 868;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.35));
                    axisw = 868 + ceil;
                }
                if (pointNum > 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 51) * 0.50));
                    axisw = 910 + ceil;
                }
                if (pointNum > 60 && pointNum <= 75)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                    axisw = 914 - ceil;
                }
                if (pointNum > 75 && pointNum <= 110)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 75) * 0.75));
                    axisw = 914 - ceil;
                }
                if (pointNum > 110 && pointNum < 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 110) * 0.90));
                    axisw = 888 - ceil;
                }
                if (pointNum >= 140 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            #region CT100
            //CT100
            if ("X".Equals(flag))
            {
                axisw = 901;//
                if (pointNum >= 10)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.35));
                    axisw = 901 + ceil;
                }
                if (pointNum > 30 && pointNum < 50)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 10) * 0.10));
                    axisw = 901 + ceil;
                }
                if (pointNum >= 50 && pointNum <= 60)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 50) * 0.00));
                    axisw = 895 + ceil;
                }
                if (pointNum > 60 && pointNum <= 75)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 60) * 0.00));
                    axisw = 895 - ceil;
                }
                if (pointNum > 75 && pointNum <= 100)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 75) * 0.00));
                    axisw = 895 - ceil;
                }
                if (pointNum > 100 && pointNum <= 140)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 100) * 0.80));
                    axisw = 895 - ceil;
                }
                if (pointNum >= 140 && pointNum < 160)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.45));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 160 && pointNum < 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 140) * 0.60));
                    axisw = 902 - ceil;
                }
                if (pointNum >= 210)
                {
                    int ceil = Convert.ToInt32(Math.Ceiling((pointNum - 210) * 0.40));
                    axisw = 908 - ceil;
                }
            }
            #endregion

            return axisw * 0.001f;
        }
    }
}
