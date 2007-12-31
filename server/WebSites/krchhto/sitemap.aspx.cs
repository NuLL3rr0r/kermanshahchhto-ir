using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class sitemap : System.Web.UI.Page
{
    private string urlBase = "http://www.kermanshahchhto.ir/";
    //private string urlFormat = "<url><loc>{0}?lang={1}&amp;req={2}</loc></url>";
    //private string urlFullFormat = "<url><loc>{0}?lang={1}&amp;req={2}&amp;{3}={4}</loc></url>";
    private string lang = string.Empty;

    private string[] urlNavSet = {
                                     "sitemap",
                                     "links",
                                     "contactus",
                                     "aboutus",
                                 };

    private string urls = string.Empty;

    private master core = new master();

    public string GenerateURL(string req, string var, string value, string lang)
    {
        return string.Format("<url><loc>{0}?lang={1}&amp;req={2}&amp;{3}={4}</loc></url>", urlBase, lang, req, var, EncDec.Encrypt(value, Base.urlHashKey).Replace("+", "%2B").Replace("/", "%2F").Replace("=", "%3D"));
    }

    private string GetNavSet(string lang)
    {
        string urlset = string.Format("<url><loc>{0}?lang={1}</loc></url>", urlBase, lang);

        for (int i = 0; i < urlNavSet.Length; i++)
            urlset += string.Format("<url><loc>{0}?lang={1}&amp;req={2}</loc></url>", urlBase, lang, urlNavSet[i]);

        return urlset;
    }

    private void GetURLsFromNodes(TreeNode node, string lang, bool hasChild, string[] lastChild)
    {
        TreeNodeCollection nodes = node.ChildNodes;

        foreach (TreeNode n in nodes)
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

                    GetURLsFromNodes(n, lang, hasChild, lastChild);
                }
                else
                {
                    urls += GenerateURL("fetchpage", "page", path, this.lang);
                }

                if (len > 0)
                {
                    for (int i = 0; i < lastChild.Length; i++)
                    {
                        if (lastChild[i] == n.ValuePath)
                        {
                        }
                    }
                }

            }
            else
            {
                if (hasChild)
                {
                    hasChild = false;
                }
                if (n.ChildNodes.Count > 0)
                {
                    hasChild = true;

                    GetURLsFromNodes(n, lang, hasChild, lastChild);
                }
            }
        }
    }

    private string GetURLs(string lang, DataSet dsNodes, DataSet dsGalleries, DataSet dsNews)
    {
        urls = string.Empty;

        string tblNodes = "pages" + lang;
        string tblGalleries = "gallery" + lang;
        string tblNews = "news" + lang;

        this.lang = lang;

        string mnuTitle = string.Empty;

        switch (lang)
        {
            case "fa":
                mnuTitle = Base.rootTitleFa;
                break;
            case "en":
                mnuTitle = Base.rootTitleEn;
                break;
            case "ar":
                mnuTitle = Base.rootTitleAr;
                break;
            default:
                break;
        }

        TreeView trv = new TreeView();
        TreeNode root = new TreeNode();

        root.Text = "root";
        root.Value = mnuTitle;
        trv.Nodes.Add(root);

        core.GetNodesFromTable(trv.Nodes[0], dsNodes.Tables[tblNodes]);

        GetURLsFromNodes(trv.Nodes[0], tblNodes, false, new string[] { });

        for (int i = 0; i < dsGalleries.Tables[tblGalleries].Rows.Count; i++)
            urls += GenerateURL("fetchgallery", "gallery", tblGalleries + "/" + dsGalleries.Tables[tblGalleries].Rows[i][0].ToString().Trim(), this.lang);

        for (int i = 0; i < dsNews.Tables[tblNews].Rows.Count; i++)
            urls += GenerateURL("fetchnews", "news", dsNews.Tables[tblNews].Rows[i][0].ToString().Trim(), this.lang);

        return urls;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //urlBase = string.Format("http://{0}/", Request.ServerVariables["HTTP_HOST"]);

        DataSet dsNodes = core.NodesAllTrees();
        DataSet dsGalleries = core.GalleryDefAllTables();
        DataSet dsNews = core.NewsAllTables();

        string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                     "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">" +
                     "{0}" +
                     "</urlset>";

        string xmlTemp = string.Empty;

        xmlTemp += GetNavSet("fa") + GetURLs("fa", dsNodes, dsGalleries, dsNews);

        xmlTemp += GetNavSet("en") + GetURLs("en", dsNodes, dsGalleries, dsNews);

        xmlTemp += GetNavSet("ar") + GetURLs("ar", dsNodes, dsGalleries, dsNews);

        xml = string.Format(xml, xmlTemp);

        Response.Clear();
        Response.Charset = "utf-8";
        Response.ContentType = "text/xml";
        Response.Write(xml);
        Response.End();
        Response.Flush();
    }
}
