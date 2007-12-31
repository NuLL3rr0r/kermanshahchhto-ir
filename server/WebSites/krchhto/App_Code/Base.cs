using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;

/// <summary>
/// Summary description for Base
/// </summary>
public static class Base
{
    #region Variables & Properties

    public static string fileDb = @"oracledb\master.oracle";
    public static string picsDb = @"oracledb\pics.oracle";

    public static string dBpw = "p9th7DB153cJmY7VuseV";

    public static string hashKey = "n875pSw4CRR";
    public static string urlHashKey = "§";

    public static string path;
    public static string pathLUF = "downloads";
    public static string pathFLV = "movies";

    public static string cnnStr;
    public static string cnnStrPics;

    public static string rootTitleFa = "منوهاي وب سايت";
    public static string rootTitleEn = "Website Menus";
    public static string rootTitleAr = "الموقع الالكتروني قوائم";

    public static string mailServer = "webmail.kermanshahchhto.ir";
    public static string mailServerUser = "admin@kermanshahchhto.ir";
    public static string mailServerPw = "smtpserver";
    public static int mailServerPort = 25;

    #endregion

    static Base()
    {
        System.Web.Services.WebService ws = new System.Web.Services.WebService();

        path = ws.Server.MapPath("~");
        path += path.EndsWith(Path.DirectorySeparatorChar.ToString()) ? string.Empty : Path.DirectorySeparatorChar.ToString();

        pathLUF = path + pathLUF + Path.DirectorySeparatorChar.ToString();
        pathFLV = path + pathFLV + Path.DirectorySeparatorChar.ToString();

        fileDb = String.Concat(path, fileDb);
        picsDb = String.Concat(path, picsDb);

        cnnStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", fileDb, dBpw);
        cnnStrPics = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};", picsDb, dBpw);
    }

    #region Date Conversations & Formatting

    public static string GetPersianDate()
    {
        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();

        DateTime dt = DateTime.Now;

        string y = pc.GetYear(dt).ToString();
        string m = pc.GetMonth(dt).ToString();
        string d = pc.GetDayOfMonth(dt).ToString();

        if (m.Length != 2)
            m = "0" + m;
        if (d.Length != 2)
            d = "0" + d;

        //{0} = Year
        //{1} = Month
        //{2} = Day
        return String.Format("{0}/{1}/{2}", y, m, d);
    }

    public static string GetGregorianDate()
    {
        DateTime dt = DateTime.Now;

        //{0} = Year
        //{1} = Month
        //{2} = Day
        string y = dt.Year.ToString();
        string m = dt.Month.ToString();
        string d = dt.Day.ToString();

        if (m.Length != 2)
            m = "0" + m;
        if (d.Length != 2)
            d = "0" + d;

        return String.Format("{0}/{1}/{2}", y, m, d);
    }

    public static string GetHijriDate()
    {
        System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();

        DateTime dt = DateTime.Now;

        string y = hc.GetYear(dt).ToString();
        string m = hc.GetMonth(dt).ToString();
        string d = hc.GetDayOfMonth(dt).ToString();

        if (m.Length != 2)
            m = "0" + m;
        if (d.Length != 2)
            d = "0" + d;

        //{0} = Year
        //{1} = Month
        //{2} = Day
        return String.Format("{0}/{1}/{2}", y, m, d);
    }

    public static string FormatDateToOriginal(string str)
    {
        return string.Format("{0}/{1}/{2}", str.Substring(0, 4), str.Substring(4, 2), str.Substring(6, 2));
    }

    public static string FormatDateToRaw(string str)
    {
        return str.Substring(0, 4) + str.Substring(5, 2) + str.Substring(8, 2);
    }

    public static string FormatMonthsToPersianNames(string num)
    {
        string name = string.Empty;
        switch (num)
        {
            case "01":
                name = "فروردین";
                break;
            case "02":
                name = "اردیبهشت";
                break;
            case "03":
                name = "خرداد";
                break;
            case "04":
                name = "تیر";
                break;
            case "05":
                name = "مرداد";
                break;
            case "06":
                name = "شهریور";
                break;
            case "07":
                name = "مهر";
                break;
            case "08":
                name = "آبان";
                break;
            case "09":
                name = "آذر";
                break;
            case "10":
                name = "دی";
                break;
            case "11":
                name = "بهمن";
                break;
            case "12":
                name = "اسفند";
                break;
            default:
                break;
        }
        return name;
    }

    public static string FormatMonthsToEnglishNames(string num)
    {
        string name = string.Empty;
        switch (num)
        {
            case "01":
                name = "January";
                break;
            case "02":
                name = "February";
                break;
            case "03":
                name = "March";
                break;
            case "04":
                name = "April";
                break;
            case "05":
                name = "May";
                break;
            case "06":
                name = "June";
                break;
            case "07":
                name = "July";
                break;
            case "08":
                name = "August";
                break;
            case "09":
                name = "September";
                break;
            case "10":
                name = "October";
                break;
            case "11":
                name = "November";
                break;
            case "12":
                name = "December";
                break;
            default:
                break;
        }
        return name;
    }

    public static string FormatMonthsToArabicNames(string num)
    {
        string name = string.Empty;
/*        switch (num)
        {
            case "01":
                name = "يناير";
                break;
            case "02":
                name = "فبراير";
                break;
            case "03":
                name = "مارس";
                break;
            case "04":
                name = "ابريل";
                break;
            case "05":
                name = "مايو";
                break;
            case "06":
                name = "يونيو";
                break;
            case "07":
                name = "يوليو";
                break;
            case "08":
                name = "اغسطس";
                break;
            case "09":
                name = "سبتمبر";
                break;
            case "10":
                name = "اكتوبر";
                break;
            case "11":
                name = "نوفمبر";
                break;
            case "12":
                name = "ديسمبر";
                break;
            default:
                break;
        }*/
        switch (num)
        {
            case "01":
                name = "محرم";
                break;
            case "02":
                name = "صفر";
                break;
            case "03":
                name = "ربيع الأول";
                break;
            case "04":
                name = "ربيع الثاني";
                break;
            case "05":
                name = "جمادى الأولى";
                break;
            case "06":
                name = "جمادى الثانية";
                break;
            case "07":
                name = "رجب";
                break;
            case "08":
                name = "شعبان";
                break;
            case "09":
                name = "رمضان";
                break;
            case "10":
                name = "شوال";
                break;
            case "11":
                name = "ذو القعدة";
                break;
            case "12":
                name = "ذو الحجة";
                break;
            default:
                break;
        }
        return name;
    }

    #endregion

    #region Localizations

    public static string FormatNumsToArabic(string strNum)
    {
        int len = strNum.Length;
        string strOut = String.Empty;
        string num;
        for (int i = 0; i < len; i++)
        {
            num = strNum.Substring(i, 1);
            switch (num)
            {
                case "0":
                    strOut += "\u0660";
                    break;
                case "1":
                    strOut += "\u0661";
                    break;
                case "2":
                    strOut += "\u0662";
                    break;
                case "3":
                    strOut += "\u0663";
                    break;
                case "4":
                    strOut += "\u0664";
                    break;
                case "5":
                    strOut += "\u0665";
                    break;
                case "6":
                    strOut += "\u0666";
                    break;
                case "7":
                    strOut += "\u0667";
                    break;
                case "8":
                    strOut += "\u0668";
                    break;
                case "9":
                    strOut += "\u0669";
                    break;
                default:
                    break;
            }
        }
        return strOut;
    }

    public static string FormatNumsToPersian(string strNum)
    {
        int len = strNum.Length;
        string strOut = String.Empty;
        string num;
        for (int i = 0; i < len; i++)
        {
            num = strNum.Substring(i, 1);
            switch (num)
            {
                case "0":
                    strOut += "\u06F0";
                    break;
                case "1":
                    strOut += "\u06F1";
                    break;
                case "2":
                    strOut += "\u06F2";
                    break;
                case "3":
                    strOut += "\u06F3";
                    break;
                case "4":
                    strOut += "\u06F4";
                    break;
                case "5":
                    strOut += "\u06F5";
                    break;
                case "6":
                    strOut += "\u06F6";
                    break;
                case "7":
                    strOut += "\u06F7";
                    break;
                case "8":
                    strOut += "\u06F8";
                    break;
                case "9":
                    strOut += "\u06F9";
                    break;
                default:
                    break;
            }
        }
        return strOut;
    }

    #endregion

    #region Generate URL

    public static string GenerateURL(string req, string var, string value, string lang)
    {
        return string.Format("./?lang={0}&req={1}&{2}={3}", lang, req, var, EncDec.Encrypt(value, Base.urlHashKey).Replace("+", "%2B").Replace("/", "%2F").Replace("=", "%3D"));
    }

    #endregion
}
