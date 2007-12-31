using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Data.OleDb;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


public partial class showpics : System.Web.UI.Page
{
    private void WriteResponse(string fileName, byte[] buffer, string contentType)
    {
        Response.Clear();
        Response.AddHeader("Content-disposition", "attachment; filename=" + fileName);
        Response.ContentType = contentType;
        Response.BinaryWrite(buffer);
        Response.End();
        Response.Flush();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string id = Request.QueryString["id"];
            string t = Request.QueryString["t"];

            if (id == string.Empty)
                return;

            switch (id)
            {
                case "logofa":
                    WriteResponse(string.Format("logo{0}.jpg", "fa"), (new master()).LogoDownload("fa"), "image / jpeg");
                    return;
                case "logoen":
                    WriteResponse(string.Format("logo{0}.jpg", "en"), (new master()).LogoDownload("en"), "image / jpeg");
                    return;
                case "logoar":
                    WriteResponse(string.Format("logo{0}.jpg", "ar"), (new master()).LogoDownload("ar"), "image / jpeg");
                    return;
                default:
                    break;
            }

            string tbl = "pics";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, tbl);

            while (drr.Read())
            {
                if (drr["id"].ToString().Trim() == id.Trim())
                {
                    string ext = GetTrueExt(drr["ext"].ToString().ToLower().Trim());
                    string cType = GetMIME(ext);

                    byte[] buffer = { };
                    string fileName = string.Empty;
                    switch (t.Trim())
                    {
                        case "":
                            if ((new master()).WatermarkStatusGet())
                            {
                                buffer = GenWatermark(Convert.FromBase64String(drr["data"].ToString()), GetImageFormat(ext));
                            }
                            else
                            {
                                buffer = Convert.FromBase64String(drr["data"].ToString());
                            }
                            fileName = id + ext;
                            break;
                        case "t":
                            buffer = GenThumb(Convert.FromBase64String(drr["data"].ToString()), GetImageFormat(ext), "t");
                            fileName = id + "t" + ext;
                            break;
                        case "n":
                            buffer = GenThumb(Convert.FromBase64String(drr["data"].ToString()), GetImageFormat(ext), "n");
                            fileName = id + "n" + ext;
                            break;
                        default:
                            break;
                    }
                    WriteResponse(fileName, buffer, cType);
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
        }
    }

    private string GetTrueExt(string ext)
    {
        // u can join array the search in string
        string[] vExt = { ".png", ".jpg", ".jpeg", ".jpe", ".gif", ".tif", ".tiff", ".bmp", ".dib", ".rle", ".ico", ".wnf", ".emf" };
        bool isValid = false;

        foreach (string e in vExt)
        {
            if (e == ext)
            {
                isValid = true;
                break;
            }
        }

        if (!isValid)
            ext = ".jpg";

        return ext;
    }

    private string GetMIME(string ext)
    {
        string cType = string.Empty;

        switch (ext)
        {
            case ".png":
                cType = "image/png";
                break;
            case ".jpg":
                cType = "image/jpeg";
                break;
            case ".jpeg":
                cType = "image/jpeg";
                break;
            case ".jpe":
                cType = "image/jpeg";
                break;
            case ".gif":
                cType = "image/gif";
                break;
            case ".tif":
                cType = "image/tiff";
                break;
            case ".tiff":
                cType = "image/tiff";
                break;
            case ".bmp":
                cType = "image/bmp";
                break;
            case ".dib":
                cType = "image/bmp";
                break;
            case ".rle":
                cType = "image/bmp";
                break;
            case ".ico":
                cType = "image/x-icon";
                break;
            case ".wmf":
                cType = "application/x-msmetafile";
                break;
            case ".ewmf":
                cType = "application/x-emf";
                break;
            default:
                cType = "image/jpeg";
                break;
        }

        return cType;
    }


    private ImageFormat GetImageFormat(string ext)
    {
        ImageFormat format;

        switch (ext)
        {
            case ".png":
                format = ImageFormat.Png;
                break;
            case ".jpg":
                format = ImageFormat.Jpeg;
                break;
            case ".jpeg":
                format = ImageFormat.Jpeg;
                break;
            case ".jpe":
                format = ImageFormat.Jpeg;
                break;
            case ".gif":
                format = ImageFormat.Gif;
                break;
            case ".tif":
                format = ImageFormat.Tiff;
                break;
            case ".tiff":
                format = ImageFormat.Tiff;
                break;
            case ".bmp":
                format = ImageFormat.Bmp;
                break;
            case ".dib":
                format = ImageFormat.Bmp;
                break;
            case ".rle":
                format = ImageFormat.Bmp;
                break;
            case ".ico":
                format = ImageFormat.Icon;
                break;
            case ".wmf":
                format = ImageFormat.Wmf;
                break;
            case ".emf":
                format = ImageFormat.Emf;
                break;
            default:
                format = ImageFormat.Jpeg;
                break;
        }

        return format;
    }

    private byte[] GenThumb(byte[] buffer, ImageFormat format, string type)
    {
        MemoryStream iMS = new MemoryStream(buffer);
        System.Drawing.Image img = new Bitmap(iMS);

        int h = -1;

        switch (type)
        {
            case "n":
                h = img.Height / (img.Width / 128);
                break;
            case "t":
                h = 96;
                break;
            default:
                break;
        }

        System.Drawing.Image thumb = img.GetThumbnailImage(128, h, null, new IntPtr());

        MemoryStream tMS = new MemoryStream();
        thumb.Save(tMS, format);

        //Array.Resize(ref buffer, 0);

        return tMS.ToArray();
    }

    private byte[] GenWatermark(byte[] buffer, ImageFormat format)
    {
        string Copyright = "Copyright © kermanshahchhto.ir";

        MemoryStream pMS = new MemoryStream(buffer);
        System.Drawing.Image imgPhoto = new System.Drawing.Bitmap(pMS);

        int phWidth = imgPhoto.Width;
        int phHeight = imgPhoto.Height;

        Bitmap bmPhoto = new Bitmap(phWidth, phHeight, imgPhoto.PixelFormat);

        //bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
        bmPhoto.SetResolution(72, 72);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);

        grPhoto.SmoothingMode = SmoothingMode.AntiAlias;

        grPhoto.DrawImage(
            imgPhoto,
            new Rectangle(0, 0, phWidth, phHeight),
            0,
            0,
            phWidth,
            phHeight,
            GraphicsUnit.Pixel);

        int[] sizes = new int[] { 16, 14, 12, 10, 8, 6, 4 };

        Font crFont = null;
        SizeF crSize = new SizeF();

        for (int i = 0; i < 7; i++)
        {
            //crFont = new Font("arial", sizes[i], FontStyle.Bold);
            crFont = new Font("Verdana", sizes[i], FontStyle.Bold);
            crSize = grPhoto.MeasureString(Copyright, crFont);

            if ((ushort)crSize.Width < (ushort)phWidth)
                break;
        }

        int yPixlesFromBottom = (int)(phHeight * .05);

        float yPosFromBottom = ((phHeight - yPixlesFromBottom) - (crSize.Height / 2));

        float xCenterOfImg = (phWidth / 2);

        StringFormat StrFormat = new StringFormat();
        StrFormat.Alignment = StringAlignment.Center;

        SolidBrush semiTransBrush2 = new SolidBrush(Color.FromArgb(153, 0, 0, 0));

        grPhoto.DrawString(Copyright,
            crFont,
            semiTransBrush2,
            new PointF(xCenterOfImg + 1, yPosFromBottom + 1),
            StrFormat);

        SolidBrush semiTransBrush = new SolidBrush(Color.FromArgb(153, 255, 255, 255));

        grPhoto.DrawString(Copyright,
            crFont,
            semiTransBrush,
            new PointF(xCenterOfImg, yPosFromBottom),
            StrFormat);

        Bitmap bmWatermark = new Bitmap(bmPhoto);
        bmWatermark.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

        imgPhoto = bmWatermark;

        grPhoto.Dispose();

        MemoryStream wMS = new MemoryStream();
        imgPhoto.Save(wMS, format);

        imgPhoto.Dispose();

        Array.Resize(ref buffer, 0);

        buffer = wMS.ToArray();

        return buffer;
    }
}
