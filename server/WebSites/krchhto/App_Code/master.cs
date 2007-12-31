using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Net.Mail;

/// <summary>
/// Summary description for master
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class master : System.Web.Services.WebService
{
    #region Global Variables

    private bool isDaysLeft;

    private string msgPageExpired = "<p style=\"direction: ltr;\">&nbsp;&nbsp;&nbsp;Permission has expired!!!</p>";

    private string siteMap = string.Empty;
    private bool isMenuULOpened = false;

    private bool isGoogle = false;
    private string langGoogle = "fa";

    #endregion

    public master ()
    {
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

        Management wsrv = new Management();
        isDaysLeft = wsrv.IsDaysLeft();

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Counter

    private void AddViewCount(string pg, string tbl)
    {
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

            cnn.Open();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            ocb.QuotePrefix = "[";
            ocb.QuoteSuffix = "]";
            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["fullpath"].ToString().Trim() == pg.Trim())
                {
                    dr.BeginEdit();

                    int count = dr["viewcount"].ToString().Trim() != string.Empty ? Convert.ToInt32(dr["viewcount"]) : 0;
                    dr["viewcount"] = ++count;

                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                    }
                    else
                    {
                        ds.RejectChanges();
                    }
                }
            }

            cnn.Close();

            ds.Dispose();
            ocb.Dispose();
            oda.Dispose();
            cnn.Dispose();
            dt.Dispose();

            ds = null;
            ocb = null;
            oda = null;
            dr = null;
            dt = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }
    }

    private void AddViewCountGallery(string wch)
    {
        string id = wch.Substring(wch.IndexOf("\\") + 1);
        string tbl = wch.Substring(0, wch.IndexOf("\\"));

        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

            cnn.Open();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            ocb.QuotePrefix = "[";
            ocb.QuoteSuffix = "]";
            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["id"].ToString().Trim() == id.Trim())
                {
                    dr.BeginEdit();

                    int count = dr["viewcount"].ToString().Trim() != string.Empty ? Convert.ToInt32(dr["viewcount"]) : 0;
                    dr["viewcount"] = ++count;

                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                    }
                    else
                    {
                        ds.RejectChanges();
                    }
                }
            }

            cnn.Close();

            ds.Dispose();
            ocb.Dispose();
            oda.Dispose();
            cnn.Dispose();
            dt.Dispose();

            ds = null;
            ocb = null;
            oda = null;
            dr = null;
            dt = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }
    }

    #endregion

    #region Calendar & Events

    private string ReadEvent(string tbl)
    {
        string msg = string.Empty;

        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            string date = string.Empty;
            DateTime dt = DateTime.Now;
            string m = string.Empty;
            string d = string.Empty;

            switch (tbl)
            {
                case "calendarfa":
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    m = pc.GetMonth(dt).ToString();
                    d = pc.GetDayOfMonth(dt).ToString();
                    if (m.Length == 1)
                        m = "0" + m;
                    if (d.Length == 1)
                        d = "0" + d;
                    date = String.Format("{0}{1}", m, d);
                    break;
                case "calendaren":
                    m = dt.Month.ToString();
                    d = dt.Date.ToString();
                    if (m.Length == 1)
                        m = "0" + m;
                    if (d.Length == 1)
                        d = "0" + d;
                    date = String.Format("{0}{1}", m, d);
                    break;
                case "calendarar":
                    System.Globalization.HijriCalendar hc = new System.Globalization.HijriCalendar();
                    m = hc.GetMonth(dt).ToString();
                    d = hc.GetDayOfMonth(dt).ToString();
                    if (m.Length == 1)
                        m = "0" + m;
                    if (d.Length == 1)
                        d = "0" + d;
                    date = String.Format("{0}{1}", m, d);
                    break;
                default:
                    break;
            }

            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string title = string.Empty;
            string body = string.Empty;

            bool found = false;
            while (drr.Read())
            {
                if (drr["month"].ToString().Trim() + drr["day"].ToString().Trim() == date)
                {
                    found = true;
                    title = EncDec.Decrypt(drr["title"].ToString(), Base.hashKey).Trim();
                    body = EncDec.Decrypt(drr["body"].ToString(), Base.hashKey).Trim();
                    break;
                }
            }

            if (found)
                msg = string.Format("<h3>{0}</h3>{1}<br />", title, body).Replace("\n", "<br />");

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return msg;
    }

    #endregion

    #region Fetch Pages

    private string GenSrcURLFetchPage(string value, string tbl)
    {
        string lang = string.Empty;
        string urlWord = string.Empty;
        
        switch (tbl)
        {
            case "pagesfa":
                lang = "fa";
                urlWord = "آدرس مستقیم این صفحه";
                break;
            case "pagesen":
                lang = "en";
                urlWord = "Direct URL of the page";
                break;
            case "pagesar":
                lang = "ar";
                urlWord = "العنوان مباشرة من صفحة";
                break;
            default:
                break;
        }

        string url = "<div id=\"dvURLSourceTop\"><a href=\"{0}\" title=\"{2}\">{1}</a></div>";

        if (value == "صفحه اصلی" || value == "Home Page" || value == "الصفحه الرئيسية")
            //url = string.Format(url, string.Format("./?lang={0}", lang), value, urlWord);
            url = string.Empty;
        else if (value == "سایت های مرتبط" || value == "Links" || value == "صلات")
            url = string.Format(url, string.Format("./?lang={0}&req={1}", lang, "links"), value, urlWord);
        else if (value == "درباره ی ما" || value == "About us" || value == "من نحن")
            url = string.Format(url, string.Format("./?lang={0}&req={1}", lang, "aboutus"), value, urlWord);
        else
            url = GenerateSourceURL(value.Substring(value.IndexOf("\\") + 1).Replace("\\", " > "), urlWord, "fetchpage", "page", value.Replace("\\", "/"), lang);

        return url;
    }

    private string GenSrcURLFetchNewsFromSearch(string title, string value, string tbl)
    {
        string lang = string.Empty;
        string urlWord = string.Empty;
        string newsTitle = string.Empty;

        switch (tbl)
        {
            case "newsfa":
                lang = "fa";
                urlWord = "آدرس مستقیم این صفحه";
                newsTitle = "اخبار";
                break;
            case "newsen":
                lang = "en";
                urlWord = "Direct URL of the page";
                newsTitle = "News";
                break;
            case "newsar":
                lang = "ar";
                urlWord = "العنوان مباشرة من صفحة";
                newsTitle = "أخبار";
                break;
            default:
                break;
        }

        return GenerateSourceURL(newsTitle + " > " + title, urlWord, "fetchnews", "news", value, lang);
    }

    private string GenSrcURLContactUSForm(string tbl)
    {
        string lang = string.Empty;
        string urlWord = string.Empty;
        string cfTitle = string.Empty;

        switch (tbl)
        {
            case "contactlistfa":
                lang = "fa";
                urlWord = "آدرس مستقیم این صفحه";
                cfTitle = "تماس با ما";
                break;
            case "contactlisten":
                lang = "en";
                urlWord = "Direct URL of the page";
                cfTitle = "Contact us";
                break;
            case "contactlistar":
                lang = "ar";
                urlWord = "العنوان مباشرة من صفحة";
                cfTitle = "اتصل بنا";
                break;
            default:
                break;
        }

        string url = "<div id=\"dvURLSourceTop\"><a href=\"{0}\" title=\"{2}\">{1}</a></div>";
        return string.Format(url, string.Format("./?lang={0}&req=contactus", lang), cfTitle, urlWord);
    }

    private string GenSrcURLFetchGallery(string wch)
    {
        string lang = string.Empty;
        string urlWord = string.Empty;
        string galTitle = string.Empty;

        int pos = wch.IndexOf("\\");
        string title = wch.Substring(pos + 1);
        string tbl = wch.Substring(0, pos);

        switch (tbl)
        {
            case "galleryfa":
                lang = "fa";
                urlWord = "آدرس مستقیم این صفحه";
                galTitle = "گالری";
                break;
            case "galleryen":
                lang = "en";
                urlWord = "Direct URL of the page";
                galTitle = "Gallery";
                break;
            case "galleryar":
                lang = "ar";
                urlWord = "العنوان مباشرة من صفحة";
                galTitle = "معرض";
                break;
            default:
                break;
        }

        return GenerateSourceURL(galTitle + " > " + title, urlWord, "fetchgallery", "gallery", wch.Replace("\\", "/"), lang);
    }

    private string GenSrcURLSiteMap(string tbl)
    {
        string lang = string.Empty;
        string urlWord = string.Empty;
        string smTitle = string.Empty;

        switch (tbl)
        {
            case "pagesfa":
                lang = "fa";
                urlWord = "آدرس مستقیم این صفحه";
                smTitle = "نقشه سایت";
                break;
            case "pagesen":
                lang = "en";
                urlWord = "Direct URL of the page";
                smTitle = "Site Map";
                break;
            case "pagesar":
                lang = "ar";
                urlWord = "العنوان مباشرة من صفحة";
                smTitle = "خريطه الموقع";
                break;
            default:
                break;
        }

        string url = "<div id=\"dvURLSourceTop\"><a href=\"{0}\" title=\"{2}\">{1}</a></div>";
        return string.Format(url, string.Format("./?lang={0}&req=sitemap", lang), smTitle, urlWord);
    }

    private string GenerateSourceURL(string title, string urlWord, string req, string var, string value, string lang)
    {
        string url = "<div id=\"dvURLSourceTop\"><a href=\"{0}\" title=\"{2}\">{1}</a></div>";

        url = string.Format(url, Base.GenerateURL(req, var, value, lang), title, urlWord);

        return url;
    }

    [WebMethod]
    public string FetchPage(string pg, string tbl)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        string sqlStr = "SELECT * FROM " + tbl;

        string pageContent = string.Empty;

        pg = pg.Replace("/", "\\").Trim();

        string lang = string.Empty;
        string urlWord = string.Empty;
        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string parent = string.Empty;

            //bool found = false;


            switch (tbl)
            {
                case "pagesfa":
                    lang = "fa";
                    urlWord = "آدرس";
                    break;
                case "pagesen":
                    lang = "en";
                    urlWord = "URL";
                    break;
                case "pagesar":
                    lang = "ar";
                    urlWord = "العنوان";
                    break;
                default:
                    break;
            }

            while (drr.Read())
            {
                if (drr["fullpath"].ToString().Trim() == pg)
                {
                    pageContent = GenSrcURLFetchPage(pg, tbl);
                    pageContent += EncDec.Decrypt(drr["body"].ToString(), Base.hashKey);
                    parent = drr["parent"].ToString().Trim();
                    //found = true;
                    break;
                }
            }

            /*if (!found)
                return "{Invalid Request!!!}";*/

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;

            if (parent != "nav")
                AddViewCount(pg, tbl);

            switch (pg)
            {
                case "صفحه اصلی":
                    pageContent = ReadEvent("calendarfa") + pageContent;
                    break;
                case "Home Page":
                    pageContent = ReadEvent("calendaren") + pageContent;
                    break;
                case "الصفحه الرئيسية":
                    pageContent = ReadEvent("calendarar") + pageContent;
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            pageContent = ex.Message;
        }
        finally
        {
            sqlStr = null;
            tbl = null;
        }

        return pageContent;
    }

    #endregion

    #region Search in Pages & News

    private string FilterTags(string str)
    {
        int pos1 = -1;
        int pos2 = 0;

        while (true)
        {
            pos1 = str.IndexOf("<");
            if (pos1 != -1)
            {
                pos2 = str.IndexOf(">");
                str = str.Remove(pos1, pos2 - pos1 + 1);
            }
            else
                break;
        }

        return str;
    }

    private string Find(string[] keywords, string tbl)
    {
        string noRoot = string.Empty;
        switch (tbl)
        {
            case "pagesfa":
                noRoot = "منوهاي وب سايت\\";
                break;
            case "pagesen":
                noRoot = "Website Menus\\";
                break;
            case "pagesar":
                noRoot = "الموقع الالكتروني قوائم\\";
                break;
            default:
                break;
        }

        string result = string.Empty;
        string notFound = "Not Found!!!";

        string sqlStr = "SELECT * FROM " + tbl;

        OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        try
        {
            oda.Fill(ds, tbl);

            bool found = false;

            while (drr.Read())
            {
                string srch = FilterTags(EncDec.Decrypt(drr["body"].ToString(), Base.hashKey));

                foreach (string kw in keywords)
                {
                    int posSrch = srch.IndexOf(kw);

                    if (posSrch != -1)
                    {
                        string header = drr["fullpath"].ToString().Trim().Replace(noRoot, string.Empty).Replace("\\", " > ");
                        result += String.Format("<a href=\"#top\" onclick=\"fetchPage('{0}');\">{1}</a><br /><br />", drr["fullpath"].ToString().Trim().Replace("\\", "/"), header);
                        found = true;
                        break;
                    }
                }
            }
            result = found ? result : notFound;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        finally
        {
            sqlStr = null;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }


        return result;
    }

    private string FindNews(string[] keywords, string tbl)
    {
        string newsTitle = string.Empty;
        string archiveTitle = string.Empty;

        switch (tbl)
        {
            case "newsfa":
                newsTitle = "اخبار وب سايت";
                archiveTitle = "آرشیو";
                break;
            case "newsen":
                newsTitle = "Website News";
                archiveTitle = "Archive";
                break;
            case "newsar":
                newsTitle = "أخبار الموقع";
                archiveTitle = "ارشيف";
                break;
            default:
                break;
        }

        string result = string.Empty;
        string notFound = "Not Found!!!";

        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY id DESC";

        OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        try
        {
            oda.Fill(ds, tbl);

            bool found = false;

            while (drr.Read())
            {
                string srchHeader = EncDec.Decrypt(drr["header"].ToString(), Base.hashKey).Trim();
                string srch = FilterTags(EncDec.Decrypt(drr["body"].ToString(), Base.hashKey)).Trim();
                bool wasArchived = Convert.ToBoolean(drr["archived"]);

                foreach (string kw in keywords)
                {
                    int posSrch = srch.IndexOf(kw) + srchHeader.IndexOf(kw);

                    if (posSrch > -1)
                    {
                        string header = newsTitle + " > " + (wasArchived ? archiveTitle + " > " : string.Empty) + string.Format("({0}): ", Base.FormatDateToOriginal(drr["date"].ToString().Trim())) + srchHeader + "...";
                        result += String.Format("<a href=\"#top\" onclick=\"fetchNewsFromSearch('{0}');\">{1}</a><br /><br />", drr["id"].ToString().Trim(), header);
                        found = true;
                        break;
                    }
                }
            }
            result = found ? result : notFound;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        finally
        {
            sqlStr = null;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }


        return result;
    }

    [WebMethod]
    public string FetchNewsFromSearch(int id, string tbl)
    {
        string result = string.Empty;

        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY id DESC";

        OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
        OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
        OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
        cnn.Open();
        OleDbDataReader drr = cmd.ExecuteReader();

        DataSet ds = new DataSet();

        try
        {
            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (Convert.ToInt32(drr["id"]) == id)
                {
                    string header = EncDec.Decrypt(drr["header"].ToString(), Base.hashKey).Trim();
                    string body = EncDec.Decrypt(drr["body"].ToString(), Base.hashKey).Trim();
                    string date = Base.FormatDateToOriginal(drr["date"].ToString().Trim());
                    string image = drr["pic"].ToString().Trim();
                    if (image != string.Empty)
                        image = string.Format("<img src=\"showpics.aspx?id={0}&t=n\" class=\"pic\" />", image);
                    //result = string.Format("<br /><b>{0}</b><hr /><br />{1}", header, body);
                    result = GenSrcURLFetchNewsFromSearch(header, id.ToString(), tbl);
                    result += string.Format("<div class=\"dvNewsFromSearch\"<br /><b>{0}</b><div class=\"dvNewsFromSearchDate\">{2}</div>{3}{1}</div>", header, body, date, image);

                    break;
                }
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
        finally
        {
            sqlStr = null;
            tbl = null;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }

        return result;
    }
    
    [WebMethod]
    public string Find(string keywords, string tbl, string tblNews)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        keywords = keywords.Trim();

        string result = string.Empty;

        string[] kws = keywords.Split(' ');

        string start = "<div class=\"dvSearchResult\"><h5>{0}</h5>";
        string stop = "</div>";
        string msgNotFound = string.Empty;
        string notFound = "Not Found!!!";

        switch (tbl)
        {
            case "pagesfa":
                start = string.Format(start, "نتايج جستجو");
                msgNotFound = "عبارت مورد نظر يافت نشد";
                break;
            case "pagesen":
                start = string.Format(start, "Search Results");
                msgNotFound = "Your search phrase did not match any pages";
                break;
            case "pagesar":
                start = string.Format(start, "نتائج البحث");
                msgNotFound = "عبارة البحث لا يطابق اي صفحة";
                break;
            default:
                break;
        }

        msgNotFound += "&hellip;";

        if (keywords != string.Empty)
        {
            result = Find(kws, tbl);

            string resNews = FindNews(kws, tblNews);

            if (result != notFound)
                result += resNews != notFound ? resNews : string.Empty;
            else
                result = resNews;

            if (result == notFound)
                result = msgNotFound;
        }
        else
            result = msgNotFound;

        return start + result + stop;
    }

    #endregion

    #region Contact Form & Send Message

    [WebMethod]
    public string ContactUSForm(string tbl)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        string cList = string.Empty;

        try
        {
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);

            cnn.Open();

            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            OleDbDataReader drr = cmd.ExecuteReader();

            string start = "<center>" +
                                "<div class=\"dvContactForm\">" +
                                    "<table border=\"0\" align=\"center\" width=\"100%\">" +
                                        "<tr>" +
                                            "<td style=\"text-align: center;\" colspan=\"2\">" +
                                                "<h6>{0}</h6>" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td width=\"30%\">" +
                                                "{1}" +
                                            "</td>" +
                                            "<td width=\"70%\">" +
                                                "<select id=\"cmbWMail\" onChange=\"setFormStatus('dvStatusContactForm', document.getElementById('cmbWMail').value != '' ? true : false, 'reset');\" class=\"comboBox\" style=\"width: 100%;\"><option value=\"\">{2}</option>";
            string stop = "</select>" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>" +
                                                "{0}" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type=\"text\" class=\"textBox\" id=\"txtName\" style=\"width: 98%;\" disabled=\"disabled\" />" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>" +
                                                "{1}" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type=\"text\" class=\"textBox\" id=\"txtEmail\" style=\"text-align: left; width: 98%;\" disabled=\"disabled\" />" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>" +
                                                "{2}" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type=\"text\" class=\"textBox\" id=\"txtURL\" style=\"text-align: left; width: 98%;\" disabled=\"disabled\" />" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>" +
                                                "{3}" +
                                            "</td>" +
                                            "<td>" +
                                                "<input type=\"text\" class=\"textBox\" id=\"txtMsgSbjct\" style=\"width: 98%;\" disabled=\"disabled\" />" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td valign=\"top\">" +
                                                "{4}" +
                                            "</td>" +
                                            "<td>" +
                                                "<textarea class=\"textArea\" id=\"txtMsgBdy\" style=\"width: 98%\" disabled=\"disabled\"></textarea>" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td colspan=\"2\">" +
                                                "<div id=\"dvStatusContactForm\"></div>" +
                                            "</td>" +
                                        "</tr>" +
                                        "<tr>" +
                                            "<td>" +
                                            "</td>" +
                                            "<td style=\"text-align:center\">" +
                                                "<input type=\"button\" value=\"{5}\" class=\"button\" disabled=\"disabled\" onclick=\"sendMessage();\" id=\"btnSend\" style=\"width: 47%;\" />" +
                                                "&nbsp;&nbsp;&nbsp;" +
                                                "<input type=\"reset\" value=\"{6}\" class=\"button\" disabled=\"disabled\" onclick=\"clearForm('dvStatusContactForm', true);\" id=\"btnClear\" style=\"width: 47%;\" />" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</div>" +
                            "</center>";

            switch (tbl)
            {
                case "contactlistfa":
                    start = string.Format(start, "شما مي توانيد پيام خود را در قسمت زير وارد نمائيد:", "تماس با", ".:: تماس با... ::.");
                    stop = string.Format(stop, "نام فرستنده:", "آدرس ايميل:", "صفحه ي وب:", "موضوع پيام:", "متن پيام", "ارسال", "پيام جديد");
                    break;
                case "contactlisten":
                    start = string.Format(start, "Please enter your message:", "Contact with", ".:: Contact with... ::.");
                    stop = string.Format(stop, "Your name:", "Email:", "Website:", "Subject:", "Body", "Send", "Clear");
                    break;
                case "contactlistar":
                    start = string.Format(start, "الرجاء ادخال رسالتك", "الاتصال مع", ".:: الاتصال مع... ::.");
                    stop = string.Format(stop, "اسمك:", "البريد الالكتروني:", "موقع ويب:", "موضوع:", "جسم", "يرسل", "واضح");
                    break;
                default:
                    break;
            }

            while (drr.Read())
            {
                string mail = EncDec.Decrypt(drr["mailbox"].ToString(), Base.hashKey);
                string name = EncDec.Decrypt(drr["rname"].ToString(), Base.hashKey);

                cList += String.Format("<option value=\"{0}\">{1}</option>", mail, name);
            }

            cList = GenSrcURLContactUSForm(tbl) + start + cList + stop;

            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            cnn = null;

            sqlStr = null;
            tbl = null;
            start = null;
            stop = null;
        }
        catch (Exception e)
        {
            return e.Message;
        }
        finally
        {
        }

        return cList;
    }

    private string SendMail(string from, string to, string subject, string body)
    {
        string msg = String.Empty;

        try
        {
            using (MailMessage message = new MailMessage(from, to, subject, body))
            {
                message.BodyEncoding = Encoding.UTF8;
                message.SubjectEncoding = Encoding.UTF8;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.High;
                SmtpClient smtp = new SmtpClient(Base.mailServer);
                //smtp.UseDefaultCredentials = true;
                smtp.Credentials = new System.Net.NetworkCredential(Base.mailServerUser, Base.mailServerPw);
                smtp.Port = Base.mailServerPort;
                smtp.Send(message);
                msg = "sent";
            }
        }
        catch (FormatException ex)
        {
            msg = ex.Message;
        }
        catch (SmtpException ex)
        {
            msg = ex.Message;
        }
        catch (Exception ex)
        {
            msg = ex.Message;
        }
        finally
        {
        }

        return msg;
    }

    [WebMethod]
    public string SendMessage(string to, string sender, string from, string url, string subject, string body)
    {
        string msg = String.Empty;

        to = to.Trim();
        sender = sender.Trim();
        from = from.Trim();
        url = url.Trim();
        subject = subject.Trim();
        body = body.Trim();

        StringBuilder sb = new StringBuilder();
        sb.Append("<center><div style=\"position: relative; width: 89%; direction: rtl; text-align: justify; font-family:Tahoma; font-size: 14px; line-height: 33px;\">");
        sb.Append("<p>");
        sb.Append("<h6 style=\"color: #0000FF; font-size: 11px;\">");
        sb.Append("مشخصات فرستنده پيغام");
        sb.Append("</h6>");
        sb.Append("نام فرستنده:&nbsp;&nbsp;&nbsp;");
        sb.Append(sender);
        sb.Append("<br />");
        sb.Append("آدرس ايميل:&nbsp;&nbsp;&nbsp;");
        sb.Append(from);
        sb.Append("<br />");
        sb.Append("وب سايت:&nbsp;&nbsp;&nbsp;");
        sb.Append(url);
        sb.Append("<br />");
        sb.Append("</p>");
        sb.Append("<br />");
        sb.Append("<p>");
        sb.Append("<h6 style=\"color: #0000FF; font-size: 11px;\">");
        sb.Append("موضوع پيام");
        sb.Append("</h6>");
        sb.Append(subject);
        sb.Append("</p>");
        sb.Append("<br />");
        sb.Append("<p>");
        sb.Append("<h6 style=\"color: #0000FF; font-size: 11px;\">");
        sb.Append("متن  پيام");
        sb.Append("</h6>");
        sb.Append(body);
        sb.Append("</p>");
        sb.Append("<br />");
        sb.Append("</div></center>");

        body = sb.ToString();
        subject = "user of taqebostan.ir - " + subject.Trim();

        return SendMail(from, to, subject, body);
    }

    #endregion

    #region News

    [WebMethod]
    public string FetchNews(string tbl)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        tbl = tbl.Trim();

        string sqlStr = "SELECT * FROM " + tbl;

        string news = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string continueWord = string.Empty;

            switch (tbl)
            {
                case "newsfa":
                    continueWord = "ادامه";
                    break;
                case "newsen":
                    continueWord = "Continue";
                    break;
                case "newsar":
                    continueWord = "تواصل";
                    break;
                default:
                    break;
            }

            string temp = "<a name=\"{0}\"></a>" +
                          "<li><div id=\"{3}prn\">" +
                          "<h5 class=\"title\">" +
                          "<a href=\"{6}\">" +
                          "{1}" +
                          "</a>" +
                          "</h5>" +
                          "<p class=\"meta\">" +
                          "<small class=\"date\">{2}</small>" +
                          "</p>" +
                          "<p>" +
                          "<div id=\"{3}\" class=\"newsbody\">" +
                          "{4}" +
                          "{5}" +
                          "<break>" +
                          (!isGoogle ? "<a href=\"#{0}\" onclick=\"fetchNewsBody('{6}', '{3}');\">&nbsp;" + continueWord + "&hellip;</a>" : "<a href=\"{6}\">&nbsp;" + continueWord + "&hellip;</a>") +
                          "</break>" +
                          "</div>" +
                          "</p>" +
                          "</div></li>";

            string tempImage = "<img src=\"showpics.aspx?id={0}&t=n\" class=\"pic\" />";

            string id = string.Empty;

            string anchor = string.Empty;
            string title = string.Empty;
            string date = string.Empty;
            string div = string.Empty;
            string image = string.Empty;
            string lead = string.Empty;

            string hStart = "<div id=\"dvNewsInner\"><ul>";
            string hStop = "</ul></div>";

            int posLead = -1;

            while (drr.Read())
            {
                if (!Convert.ToBoolean(drr["archived"]))
                {
                    id = drr["id"].ToString().Trim();
                    title = EncDec.Decrypt(drr["header"].ToString(), Base.hashKey);

                    lead = EncDec.Decrypt(drr["body"].ToString(), Base.hashKey);
                    posLead = lead.IndexOf("<br />");
                    if (posLead == -1)
                        posLead = lead.Length;
                    lead = lead.Substring(0, posLead);

                    date = drr["date"].ToString().Trim();
                    switch (tbl)
                    {
                        case "newsfa":
                            date = Base.FormatNumsToPersian(date);
                            break;
                        case "newsen":
                            break;
                        case "newsar":
                            date = Base.FormatNumsToArabic(date);
                            break;
                        default:
                            break;
                    }

                    date = Base.FormatDateToOriginal(date);

                    image = drr["pic"].ToString().Trim();
                    if (image != string.Empty)
                        image = string.Format(tempImage, image);

                    anchor = "news_" + id;
                    div = "dv_" + id;

                    if (!isGoogle)
                        news = string.Format(temp, anchor, title, date, div, image, lead, id).Replace("href=\"" + id, "href=\"javascript:;") + news;
                    else
                        news = string.Format(temp, anchor, title, date, div, image, lead, Base.GenerateURL("fetchnews", "news", id, langGoogle)) + news;
                }
            }

            news = news != string.Empty ? FetchNewsArchiveYears(tbl) + hStart + news + hStop : "-------------";

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            news = ex.Message;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return news;
    }

    public string FetchNewsGoogle(string tbl, bool isGoogle, string langGoogle)
    {
        this.isGoogle = isGoogle;
        this.langGoogle = langGoogle;
        return FetchNews(tbl);
    }

    [WebMethod]
    public string FetchNewsBody(string tbl, string id)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        tbl = tbl.Trim();
        id = id.Trim();

        string sqlStr = "SELECT * FROM " + tbl;

        string body = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            int posLead = -1;

            while (drr.Read())
            {
                if (drr["id"].ToString().Trim() == id)
                {
                    body = EncDec.Decrypt(drr["body"].ToString(), Base.hashKey);
                    posLead = body.IndexOf("<br />");
                    if (posLead != -1)
                    {
                        posLead += 6;
                        body = body.Substring(posLead);
                    }

                    break;
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            body = ex.Message;
        }
        finally
        {
            sqlStr = null;
        }

        string lang = string.Empty;

        switch (tbl)
        {
            case "newsfa":
                lang = "fa";
                break;
            case "newsen":
                lang = "en";
                break;
            case "newsar":
                lang = "ar";
                break;
            default:
                break;
        }

        string url = "<div id=\"dvURLSourceNews{1}\">{0}</div>";

        body += string.Format(url, Base.GenerateURL("fetchnews", "news", id, lang), id);

        return body;
    }

    public string FetchNewsArchiveYears(string tbl)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        tbl = tbl.Trim();

        string sqlStr = "SELECT * FROM " + tbl;

        string archive = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string yearWord = string.Empty;
            string monthWord = string.Empty;

            switch (tbl)
            {
                case "newsfa":
                    yearWord = ".:: اخبار روز ::.";
                    monthWord = ".:: ماه ::.";
                    break;
                case "newsen":
                    yearWord = ".:: News of the Day ::.";
                    monthWord = ".:: Month ::.";
                    break;
                case "newsar":
                    yearWord = ".:: اخبار اليوم ::.";
                    monthWord = ".:: الشهر ::.";
                    break;
                default:
                    break;
            }

            string start = "<form name=\"frmNewsArchive\" id=\"frmNewsArchive\"><select name=\"archiveYears\" onChange=\"setNewsArchiveMonths(this.value);\" class=\"comboBoxNews\"><option value=\"\">" + yearWord + "</option>";
            string stop = "</select>&nbsp;&nbsp;&nbsp;<select name=\"archiveMonths\" onChange=\"showNewsArchive(this.value);\" class=\"comboBoxNews\"><option value=\"\">" + monthWord + "</option></select></form>";
            string newsYear;

            while (drr.Read())
            {
                if (Convert.ToBoolean(drr["archived"]))
                {
                    newsYear = drr["date"].ToString().Trim().Substring(0, 4);
                    if (archive.IndexOf(newsYear) == -1)
                    {
                        string formatedYear = string.Empty;

                        switch (tbl)
                        {
                            case "newsfa":
                                archive += "<option value=\"" + newsYear + "\">آرشیو " + Base.FormatNumsToPersian(newsYear) + "</option>";
                                break;
                            case "newsen":
                                archive += "<option value=\"" + newsYear + "\">" + newsYear + "'s Archive</option>";
                                break;
                            case "newsar":
                                archive += "<option value=\"" + newsYear + "\">" + Base.FormatNumsToArabic(newsYear) + "<option>";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (archive != string.Empty)
                archive = start + archive + stop;

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            archive = ex.Message;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return archive;
    }

    [WebMethod]
    public string FetchNewsArchiveMonths(string tbl, string wYear)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        tbl = tbl.Trim();

        string sqlStr = "SELECT * FROM " + tbl;

        string archive = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string newsMonth = string.Empty;
            string month;

            while (drr.Read())
            {
                if (Convert.ToBoolean(drr["archived"]) && drr["date"].ToString().Trim().Substring(0, 4) == wYear)
                {
                    month = drr["date"].ToString().Trim().Substring(4, 2);
                    switch (tbl)
                    {
                        case "newsfa":
                            newsMonth = Base.FormatMonthsToPersianNames(month);
                            break;
                        case "newsen":
                            newsMonth = Base.FormatMonthsToEnglishNames(month);
                            break;
                        case "newsar":
                            newsMonth = Base.FormatMonthsToArabicNames(month);
                            break;
                        default:
                            break;
                    }
                    if (archive.IndexOf(newsMonth) == -1)
                    {
                        newsMonth += "-" + month;
                        archive += newsMonth + "#";
                    }
                }
            }

            if (archive != string.Empty)
                archive = archive.Substring(0, archive.Length - 1);

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            archive = ex.Message;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return archive;
    }

    [WebMethod]
    public string FetchNewsArchive(string tbl, string wYear, string wMonth)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        tbl = tbl.Trim();
        wYear = wYear.Trim();
        wMonth = wMonth.Trim();
        
        string sqlStr = "SELECT * FROM " + tbl;

        string news = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            string continueWord = string.Empty;

            switch (tbl)
            {
                case "newsfa":
                    continueWord = "ادامه";
                    break;
                case "newsen":
                    continueWord = "Continue";
                    break;
                case "newsar":
                    continueWord = "تواصل";
                    break;
                default:
                    break;
            }

            string temp = "<a name=\"{0}\"></a>" +
                          "<li><div id=\"{3}prn\">" +
                          "<h5 class=\"title\">" +
                          "<a href=\"javascript:;\">" +
                          "{1}" +
                          "</a>" +
                          "</h5>" +
                          "<p class=\"meta\">" +
                          "<small class=\"date\">{2}</small>" +
                          "</p>" +
                          "<p>" +
                          "<div id=\"{3}\" class=\"newsbody\">" +
                          "{4}" +
                          "{5}" +
                          "<break>" +
                          "<a href=\"#{0}\" onclick=\"fetchNewsBody('{6}', '{3}');\">&nbsp;" + continueWord + "&hellip;</a>" +
                          "</break>" +
                          "</div>" +
                          "</p>" +
                          "</div></li>";

            string tempImage = "<img src=\"showpics.aspx?id={0}&t=n\" class=\"pic\" />";

            string id = string.Empty;

            string anchor = string.Empty;
            string title = string.Empty;
            string date = string.Empty;
            string div = string.Empty;
            string image = string.Empty;
            string lead = string.Empty;

            string hStart = "<ul>";
            string hStop = "</ul>";

            int posLead = -1;

            while (drr.Read())
            {
                string dt = drr["date"].ToString().Trim();
                if (Convert.ToBoolean(drr["archived"]) && dt.Substring(0, 4) == wYear && dt.Substring(4, 2) == wMonth)
                {
                    id = drr["id"].ToString().Trim();
                    title = EncDec.Decrypt(drr["header"].ToString(), Base.hashKey);

                    lead = EncDec.Decrypt(drr["body"].ToString(), Base.hashKey);
                    posLead = lead.IndexOf("<br />");
                    if (posLead == -1)
                        posLead = lead.Length;
                    lead = lead.Substring(0, posLead);

                    date = drr["date"].ToString().Trim();
                    switch (tbl)
                    {
                        case "newsfa":
                            date = Base.FormatNumsToPersian(date);
                            break;
                        case "newsen":
                            break;
                        case "newsar":
                            date = Base.FormatNumsToArabic(date);
                            break;
                        default:
                            break;
                    }

                    date = Base.FormatDateToOriginal(date);

                    image = drr["pic"].ToString().Trim();
                    if (image != string.Empty)
                        image = string.Format(tempImage, image);

                    anchor = "news_" + id;
                    div = "dv_" + id;

                    news = string.Format(temp, anchor, title, date, div, image, lead, id) + news;
                }
            }

            news = news != string.Empty ? hStart + news + hStop : "-------------";

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch (Exception ex)
        {
            news = ex.Message;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return news;
    }

    #endregion

    #region Gallery

    [WebMethod]
    public string FetchGallery(string wch)
    {
        if (!isDaysLeft)
            return msgPageExpired;

        string tbl = "pics";
        string sqlStr = "SELECT * FROM " + tbl;

        wch = wch.Trim().Replace("/", "\\");

        string galleryContent = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["location"].ToString().Trim() == wch.Trim())
                {
                    galleryContent += String.Format("<a href=\"showpics.aspx?id={0}&t=\" rel=\"thumbnail\" title=\"{1}\"><img src=\"showpics.aspx?id={0}&t=t\" class=\"thumbs\" /></a>", drr["id"], wch.Trim().Substring(wch.Trim().IndexOf("\\") + 1));
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;

            string start = "<center><div class=\"dvGallery\">";
            string stop = "</div></center>";

            galleryContent = GenSrcURLFetchGallery(wch) + start + galleryContent + stop;

            AddViewCountGallery(wch);
        }
        catch (Exception ex)
        {
            galleryContent = ex.Message;
        }
        finally
        {
            sqlStr = null;
            tbl = null;
        }

        return galleryContent;
    }

    #endregion

    #region Generate SiteMap

    public void GetNodesFromTable(System.Web.UI.WebControls.TreeNode node, DataTable dt)
    {
        System.Web.UI.WebControls.TreeNodeCollection nodes = node.ChildNodes;
        DataRow dr;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dr = dt.Rows[i];
            string name = dr["pg"].ToString().Trim();

            if (dr["parent"].ToString().Trim() == node.Text && dr["fullpath"].ToString().Trim().Replace("\\", "/") == node.ValuePath + "/" + name)
            {
                System.Web.UI.WebControls.TreeNode tn = new System.Web.UI.WebControls.TreeNode();
                tn.Text = name;
                tn.Value = name;
                nodes.Add(tn);

                GetNodesFromTable(tn, dt);
            }
        }
    }

    private void GetMenusFromNodes(System.Web.UI.WebControls.TreeNode node, string lang, bool hasChild, string[] lastChild)
    {
        System.Web.UI.WebControls.TreeNodeCollection nodes = node.ChildNodes;

        foreach (System.Web.UI.WebControls.TreeNode n in nodes)
        {
            string name = n.Value;
            string path = n.ValuePath;

            if (n.Parent.Text != "root")
            {
                int len = lastChild.Length;

                if (n.ChildNodes.Count > 0)
                {
                    Array.Resize(ref lastChild, len + 1);
                    lastChild[len] = n.ChildNodes[n.ChildNodes.Count - 1].ValuePath;

                    siteMap += string.Format("<li>{0}<ul>", name);

                    GetMenusFromNodes(n, lang, hasChild, lastChild);
                }
                else
                {
                    if (!isGoogle)
                        siteMap += string.Format("<li><a href=\"javascript:;\" onclick=\"fetchPage('{1}');\">{0}</a></li>", name, path);
                    else
                        siteMap += string.Format("<li><a href=\"{1}\">{0}</a></li>", name, Base.GenerateURL("fetchpage", "page", path, langGoogle));
                }

                if (len > 0)
                {
                    for (int i = 0; i < lastChild.Length; i++)
                    {
                        if (lastChild[i] == n.ValuePath)
                        {
                            siteMap += "</ul></li>";
                        }
                    }
                }

            }
            else
            {
                if (hasChild)
                {
                    siteMap += "</ul></li>";
                    isMenuULOpened = false;
                    hasChild = false;
                }
                if (n.ChildNodes.Count > 0)
                {
                    siteMap += string.Format("<li>{0}<ul>", name);
                    isMenuULOpened = true;
                    hasChild = true;

                    GetMenusFromNodes(n, lang, hasChild, lastChild);
                }
                else if (!hasChild)
                {
                    siteMap += string.Format("<li>{0}<ul></ul></li>", name);
                    isMenuULOpened = false;
                }
            }
        }
    }

    private string GetGalleryMenues(string tbl, DataTable dt)
    {
        string msg = string.Empty;

        if (dt.Rows.Count > 0)
        {
            string title = string.Empty;

            switch (tbl)
            {
                case "galleryfa":
                    title = "گالری";
                    break;
                case "galleryen":
                    title = "Galleries";
                    break;
                case "galleryar":
                    title = "معارض";
                    break;
                default:
                    break;
            }

            msg = string.Format("<li>{0}<ul>", title);

            if (!isGoogle)
                for (int i = 0; i < dt.Rows.Count; i++)
                    msg += string.Format("<li><a href=\"javascript:;\" onclick=\"fetchGallery('{1}');\">{0}</a></li>", dt.Rows[i][0].ToString().Trim(), tbl + "/" + dt.Rows[i][0].ToString().Trim());
            else
                for (int i = 0; i < dt.Rows.Count; i++)
                    msg += string.Format("<li><a href=\"{1}\">{0}</a></li>", dt.Rows[i][0].ToString().Trim(), Base.GenerateURL("fetchgallery", "gallery", tbl + "/" + dt.Rows[i][0].ToString().Trim(), langGoogle));

            msg += "</ul></li>";
        }

        return msg;
    }

    public DataSet NodesAllTrees()
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(NodesAll("pagesfa"));
        ds.Tables.Add(NodesAll("pagesen"));
        ds.Tables.Add(NodesAll("pagesar"));

        return ds;
    }
    
    public DataTable NodesAll(string tbl)
    {
        DataTable dt = new DataTable();

        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY zindex, fullpath ASC";

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

            cnn.Open();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl].Copy();
            //dt.Columns.Remove("id");
            dt.Columns.Remove("body");
            dt.Columns.Remove("viewcount");

            DataRow dr;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr["parent"].ToString() == "nav")
                    dr.Delete();
            }
            dt.AcceptChanges();

            cnn.Close();

            oda.Dispose();
            cnn.Dispose();
            ds.Dispose();

            oda = null;
            ds = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return dt;
    }

    public DataSet GalleryDefAllTables()
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(GalleryDefAll("galleryfa"));
        ds.Tables.Add(GalleryDefAll("galleryen"));
        ds.Tables.Add(GalleryDefAll("galleryar"));

        return ds;
    }

    public DataTable GalleryDefAll(string tbl)
    {
        DataTable dt = new DataTable();

        tbl = tbl.Trim();

        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY id ASC";

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

            cnn.Open();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl].Copy();

            dt.Columns.Remove("viewcount");

            dt.AcceptChanges();

            cnn.Close();

            oda.Dispose();
            cnn.Dispose();
            ds.Dispose();

            oda = null;
            ds = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return dt;
    }

    public DataSet NewsAllTables()
    {
        DataSet ds = new DataSet();

        ds.Tables.Add(NewsAll("newsfa"));
        ds.Tables.Add(NewsAll("newsen"));
        ds.Tables.Add(NewsAll("newsar"));

        return ds;
    }

    public DataTable NewsAll(string tbl)
    {
        DataTable dt = new DataTable();

        tbl = tbl.Trim();

        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

            cnn.Open();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl].Copy();

            dt.Columns.Remove("header");
            dt.Columns.Remove("body");
            dt.Columns.Remove("archived");
            dt.Columns.Remove("date");
            dt.Columns.Remove("pic");

            dt.AcceptChanges();

            cnn.Close();

            oda.Dispose();
            cnn.Dispose();
            ds.Dispose();

            oda = null;
            ds = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return dt;
    }

    [WebMethod]
    public string SiteMap(string tbl)
    {
        string mnuTitle = string.Empty;
        string gallery = string.Empty;

        string expandStr = string.Empty;
        string collapseStr = string.Empty;

        switch (tbl)
        {
            case "pagesfa":
                mnuTitle = Base.rootTitleFa;
                gallery = "galleryfa";
                expandStr = "<img src=\"smopen.fa.gif\" title=\"گشودن تمامی\" />";
                collapseStr = "<img src=\"smclosed.fa.gif\" title=\"بستن تمامی\" />";
                break;
            case "pagesen":
                mnuTitle = Base.rootTitleEn;
                gallery = "galleryen";
                expandStr = "<img src=\"smopen.gif\" title=\"Expand All\" />";
                collapseStr = "<img src=\"smclosed.gif\" title=\"Collapse All\" />";
                break;
            case "pagesar":
                mnuTitle = Base.rootTitleAr;
                gallery = "galleryar";
                expandStr = "<img src=\"smopen.fa.gif\" title=\"توسيع الكل\" />";
                collapseStr = "<img src=\"smclosed.fa.gif\" title=\"انهيار جميع\" />";
                break;
            default:
                break;
        }

        DataTable dt = NodesAll(tbl);

        System.Web.UI.WebControls.TreeView trv = new System.Web.UI.WebControls.TreeView();
        System.Web.UI.WebControls.TreeNode root = new System.Web.UI.WebControls.TreeNode();

        root.Text = "root";
        root.Value = mnuTitle;
        trv.Nodes.Add(root);

        siteMap = GenSrcURLSiteMap(tbl) + string.Format("<div class=\"dvSiteMap\">" +
                  "<center>" +
                  "<a href=\"javascript:;\" onclick=\"ddtreemenu.flatten('siteMapTree', 'contact');\">{0}</a>" +
                  "&nbsp;&nbsp;&nbsp;" +
                  "<a href=\"javascript:;\" onclick=\"ddtreemenu.flatten('siteMapTree', 'expand');\">{1}</a>" +
                  "</center>" +
                  "<ul id=\"siteMapTree\" class=\"treeview\">", collapseStr, expandStr);

        GetNodesFromTable(trv.Nodes[0], dt);

        GetMenusFromNodes(trv.Nodes[0], tbl, false, new string[] { });

        if (isMenuULOpened)
        {
            siteMap += "</ul></li>";
            isMenuULOpened = false;
        }

        dt = GalleryDefAll(gallery);
        siteMap += GetGalleryMenues(gallery, dt);

        siteMap += "</ul></div>";

        return siteMap;
    }

    public string SiteMapGoogle(string tbl, bool isGoogle, string langGoogle)
    {
        this.isGoogle = isGoogle;
        this.langGoogle = langGoogle;
        return SiteMap(tbl);
    }

    #endregion

    #region Website Title

    public string GetWTitle(string lang)
    {
        string title = string.Empty;

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == "title" + lang)
                {
                    title = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return title;
    }

    #endregion

    #region Scroll Text

    public string GetScrText(string lang)
    {
        string title = string.Empty;

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == "scr" + lang)
                {
                    title = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return title.Replace("{SEPARATOR}", "<script language=\"javascript\">spacerScrText(33);</script>").Trim();
    }

    #endregion

    #region Watermark

    public bool WatermarkStatusGet()
    {
        bool watermark = true;

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == "copyright")
                {
                    watermark = drr["val"].ToString().Trim() != "None" ? true : false;
                    break;
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return watermark;
    }

    #endregion

    #region Special Right Click

    public bool SpecRightClickGet()
    {
        bool rightclick = true;

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == "rightclick")
                {
                    rightclick = drr["val"].ToString().Trim() != "norm" ? true : false;
                    break;
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return rightclick;
    }

    #endregion

    #region Website Logo

    public byte[] LogoDownload(string lang)
    {
        byte[] logo = { };

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        lang = "logo" + lang.Trim();

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == lang)
                {
                    logo = Convert.FromBase64String(drr["val"].ToString());
                    break;
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }


        return logo;
    }

    #endregion

    #region Layout

    public string LayoutRead()
    {
        string layout = string.Empty;

        string tbl = "preferencesweb";
        string sqlStr = "SELECT * FROM " + tbl;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["tag"].ToString().Trim() == "layout")
                {
                    layout = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                    break;
                }
            }

            drr.Close();
            cnn.Close();

            cmd.Dispose();
            drr.Dispose();
            ds.Dispose();
            oda.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            ds = null;
            oda = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }


        return layout;
    }

    #endregion

    #region GoogleWarn

    private DataTable GetGoogleList()
    {
        DataTable dt = new DataTable();

        string tbl = "google";
        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY id ASC";

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

            cnn.Open();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            dt = ds.Tables[tbl].Copy();

            dt.Columns.Remove("id");

            for (int i = 0; i < dt.Rows.Count; i++)
                dt.Rows[i][0] = EncDec.Decrypt(dt.Rows[i][0].ToString(), Base.hashKey);

            dt.AcceptChanges();

            cnn.Close();

            oda.Dispose();
            cnn.Dispose();
            ds.Dispose();

            oda = null;
            ds = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return dt;
    }

    public void SendGoogleWarn(string url, string client)
    {
        System.DateTime dt = System.DateTime.Now;
        string date = dt.ToString();

        string to = string.Empty;
        string from = "\"Googlebot Listener\" <gbot@kermanshahchhto.ir>";
        string subject = "kermanshahchhto.ir :: Googlebot Deteced";
        StringBuilder sb = new StringBuilder();
        sb.Append("<br /><br /><br /><strong>Page Crawled By Googlebot</strong>");
        sb.Append("<br /><blockquote>{0}</blockquote>");
        sb.Append("<br /><br /><strong>By Google Server At</strong>");
        sb.Append("<br /><blockquote>{1}</blockquote>");
        sb.Append("<br /><br /><strong>Crawl Date</strong>");
        sb.Append("<br /><blockquote>{2}</blockquote>");
        string body = String.Format(sb.ToString(), url.Trim(), client, date);

        DataTable dtGoogle = GetGoogleList();

        for (int i = 0; i < dtGoogle.Rows.Count; i++)
        {
            to = dtGoogle.Rows[i][0].ToString();
            SendMail(from, to, subject, body);
        }
    }

    #endregion
}