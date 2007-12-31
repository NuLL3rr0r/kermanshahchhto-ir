using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

/// <summary>
/// Summary description for Management
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Management : System.Web.Services.WebService
{

    #region Global Variables

    private string srvMsgErr = "err:";
    private string srvMsgSuccess = "res:";
    //private int srvMsgLen = 4;
    private string tLegal;
    private bool isDaysLeft;

    private string errInvalidLegal = "Illegal Access...";

    private string[] pgImages = { };

    #endregion

    public Management()
    {
        Server.ScriptTimeout = 2147483647;

        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;

        tLegal = FillLegal();
        isDaysLeft = IsDaysLeft();

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    #region Security

    public string FillLegal()
    {
        string tbl = "admin";
        string sqlStr = "SELECT * FROM " + tbl;
        string legal = string.Empty;

        try
        {
            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            cnn.Open();
            OleDbDataReader drr = cmd.ExecuteReader();

            DataSet ds = new DataSet();

            oda.Fill(ds, "admin");

            while (drr.Read())
            {
                legal = EncDec.Decrypt(drr["legal"].ToString(), Base.hashKey);
                break;
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
            legal = errInvalidLegal;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return legal;
    }

    public bool IsDaysLeft()
    {
        bool result = false;
        string tbl = "admin";
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
                if (EncDec.Decrypt(drr["daysleft"].ToString(), Base.hashKey) != "0")
                    result = true;
                else
                    result = false;
                break;
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
            result = false;
        }
        finally
        {
            tbl = null;
            sqlStr = null;
        }

        return result;
    }

    [WebMethod]
    public string MasterSetLegal(string oldLegal, string newLegal)
    {
        string msg = string.Empty;

        if (tLegal == oldLegal.Trim())
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.Rows[0];
                dr.BeginEdit();
                dr["legal"] = EncDec.Encrypt(newLegal.Trim(), Base.hashKey);
                dr.EndEdit();

                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Legal Changed!";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string MasterSetDaysLeft(string count, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim())
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables["admin"];
                dr = dt.Rows[0];
                dr.BeginEdit();
                dr["daysleft"] = EncDec.Encrypt(count.Trim(), Base.hashKey);
                dr.EndEdit();

                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Days Count Was Set!";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string MasterFileUpload(byte[] buffer, string name, string legal)
    {
        string msg;
        int size = buffer.Length;
        if (tLegal == legal.Trim())
        {
            try
            {
                string fileName = name;
                string filePath = Base.path + fileName;
                bool fileExists = File.Exists(filePath);
                if (fileExists)
                {
                    File.Delete(filePath);
                }
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    fs.Write(buffer, 0, size);
                    fs.Close();
                }

                msg = "Uploaded!";
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    [WebMethod]
    public byte[] MasterFileDownload(string name, string legal)
    {
        byte[] contents = new byte[] { };
        if (tLegal == legal.Trim())
        {
            try
            {
                string fileName = name;
                string filePath = Base.path + fileName;
                bool fileExists = File.Exists(filePath);
                if (fileExists)
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open))
                    {
                        int fileSize = (int)new FileInfo(filePath).Length;
                        byte[] buffer = new byte[fileSize];
                        fs.Read(buffer, 0, fileSize);
                        fs.Close();
                        return buffer;
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        return contents;
    }

    [WebMethod]
    public bool MasterFileDownloadIsFound(string name, string legal)
    {
        bool state = false;
        if (tLegal == legal.Trim())
        {
            try
            {
                string fileName = name;
                string filePath = Base.path + fileName;
                bool fileExists = File.Exists(filePath);
                if (fileExists)
                {
                    state = true;
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        return state;
    }

    #endregion

    #region Administratives

    [WebMethod]
    public string AdminPwSet(string pw, string npw, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "admin";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                while (drr.Read())
                {
                    string tPw = EncDec.Decrypt(drr["pw"].ToString(), Base.hashKey);
                    if (tPw == pw.Trim())
                        msg = "OK";
                    else
                        msg = "invalid";
                    break;
                }

                if (msg == "OK")
                {
                    dt = ds.Tables[tbl];
                    dr = dt.Rows[0];
                    dr.BeginEdit();
                    dr["pw"] = EncDec.Encrypt(npw.Trim(), Base.hashKey);
                    dr.EndEdit();

                    oda.UpdateCommand = ocb.GetUpdateCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                    }
                    else
                    {
                        ds.RejectChanges();
                        msg = "Rejected";
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string AdminPwGet(string legal)
    {
        string msg = string.Empty;

        //if (tLegal == legal.Trim() && ChkMyAds() && isDaysLeft)
        if (tLegal == legal.Trim() && isDaysLeft)
        {
            CleanAndRepair(tLegal);

            string tbl = "admin";
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
                    string tPw = EncDec.Decrypt(drr["pw"].ToString(), Base.hashKey);
                    msg = srvMsgSuccess + tPw;
                    break;
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
                msg = srvMsgErr + ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = srvMsgErr + errInvalidLegal;

        return msg;
    }

    #endregion

    #region DB Tools

    private bool CleanTable(string tbl)
    {
        bool success = true;

        try
        {
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

            cnn.Open();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            oda.Fill(ds, tbl);
            dt = ds.Tables[tbl];

            foreach (DataRow dr in dt.Rows)
                dr.Delete();

            oda.DeleteCommand = ocb.GetDeleteCommand();

            if (oda.Update(ds, tbl) == 1)
                ds.AcceptChanges();
            else
                ds.RejectChanges();

            cnn.Close();

            dt.Dispose();
            ds.Dispose();
            ocb.Dispose();
            oda.Dispose();
            cnn.Dispose();

            dt = null;
            ds = null;
            ocb = null;
            oda = null;
            cnn = null;

            sqlStr = null;
        }
        catch
        {
            success = false;
        }
        finally
        {
        }

        return success;
    }

    public void CompactJetDB(string connectionString, string mdwFilename)
    {
        try
        {
            string tmpFile = Base.path + @"oracledb\\tmp.pak";

            object[] oParams;
            object objJRO = Activator.CreateInstance(Type.GetTypeFromProgID("JRO.JetEngine"));
            oParams = new object[] { connectionString, String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1};Jet OLEDB:Engine Type=5", tmpFile, Base.dBpw) };
            objJRO.GetType().InvokeMember("CompactDatabase", System.Reflection.BindingFlags.InvokeMethod, null, objJRO, oParams);

            System.IO.File.Delete(mdwFilename);
            System.IO.File.Move(tmpFile, mdwFilename);

            System.Runtime.InteropServices.Marshal.ReleaseComObject(objJRO);
            objJRO = null;
        }
        catch
        {
        }
        finally
        {
        }
    }

    [WebMethod]
    public bool CleanAndRepair(string legal)
    {
        CompactJetDB(Base.cnnStr, Base.fileDb);
        CompactJetDB(Base.cnnStrPics, Base.picsDb);

        return true;
    }

    #endregion

    #region Utilities

    private string NameGen()
    {
        Random rnd = new Random();
        String key = String.Empty;
        int min = -1, max = -1;

        for (int i = 0; i < 33; i++)
        {
            switch (rnd.Next(2))
            {
                case 0:
                    min = 48;
                    max = 58;
                    break;
                case 1:
                    min = 97;
                    max = 123;
                    break;
                default:
                    break;
            }
            key = String.Concat(key, Convert.ToChar(rnd.Next(min, max)));
        }

        return key;
    }

    #endregion

    #region Preferences

    [WebMethod]
    public DataTable PreferencesGet(string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferences";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];

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
        }

        return dt;
    }

    [WebMethod]
    public string PreferencesSet(string tag, string val, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tag = tag.Trim();
            val = val.Trim();

            string tbl = "preferences";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == tag)
                    {
                        dr.BeginEdit();
                        dr["val"] = val;
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }
                        
                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }

        return msg;
    }

    #endregion

    #region Node Manager

    [WebMethod]
    public DataSet NodesAllTrees(string legal)
    {
        DataSet ds = new DataSet();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            ds.Tables.Add(NodesAll("pagesfa", legal));
            ds.Tables.Add(NodesAll("pagesen", legal));
            ds.Tables.Add(NodesAll("pagesar", legal));
        }

        return ds;
    }

    [WebMethod]
    public DataTable NodesAll(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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
        }

        return dt;
    }

    [WebMethod]
    public string NodesAdd(string node, string parent, string fullPath, int zIndex, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            node = node.Trim();
            parent = parent.Trim();
            fullPath = fullPath.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;

                while (drr.Read())
                {
                    if (drr["fullpath"].ToString().Trim() == fullPath)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dt = ds.Tables[tbl];
                    dr = dt.NewRow();

                    dr["pg"] = node.Trim();
                    dr["parent"] = parent.Trim();
                    dr["fullpath"] = fullPath.Trim();
                    dr["zindex"] = zIndex;
                    dr["body"] = EncDec.Encrypt("&nbsp;", Base.hashKey);
                    if (parent != "root")
                        dr["viewcount"] = 0;
                    else
                        dr["viewcount"] = -1;

                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        msg = "Added";
                    }
                    else
                    {
                        ds.RejectChanges();
                        msg = "Rejected";
                    }
                }
                else
                    msg = "Already Exist";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                dt.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string NodesEdit(string node, string newNode, string fullPath, string newFullPath, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            node = node.Trim();
            newNode = newNode.Trim();
            fullPath = fullPath.Trim();
            newFullPath = newFullPath.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;
                bool duplicate = false;

                while (drr.Read())
                {
                    if (drr["fullpath"].ToString().Trim() == fullPath)
                        found = true;
                    else if (drr["fullpath"].ToString().Trim() == newFullPath)
                        duplicate = true;
                }

                if (found && !duplicate)
                {
                    dt = ds.Tables[tbl];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];
                        if (dr["fullpath"].ToString().Trim() != fullPath)
                        {
                            if (dr["parent"].ToString().Trim() == node && dr["fullpath"].ToString().Trim() == fullPath + "\\" + dr["pg"].ToString().Trim())
                            {
                                dr.BeginEdit();

                                dr["parent"] = newNode;
                                dr["fullpath"] = newFullPath + "\\" + dr["pg"].ToString().Trim();

                                dr.EndEdit();

                                oda.UpdateCommand = ocb.GetUpdateCommand();

                                if (oda.Update(ds, tbl) == 1)
                                {
                                    ds.AcceptChanges();
                                    msg = "Updated";
                                }
                                else
                                {
                                    ds.RejectChanges();
                                    msg = "Rejected";
                                    return msg;
                                }
                            }
                            else if (dr["fullpath"].ToString().Trim().Contains(fullPath))
                            {
                                dr.BeginEdit();

                                dr["fullpath"] = dr["fullpath"].ToString().Trim().Replace(fullPath, newFullPath);

                                dr.EndEdit();

                                oda.UpdateCommand = ocb.GetUpdateCommand();

                                if (oda.Update(ds, tbl) == 1)
                                {
                                    ds.AcceptChanges();
                                    msg = "Updated";
                                }
                                else
                                {
                                    ds.RejectChanges();
                                    msg = "Rejected";
                                    return msg;
                                }
                            }
                        }
                        else
                        {
                            dr.BeginEdit();

                            dr["pg"] = newNode;
                            dr["fullpath"] = newFullPath;

                            dr.EndEdit();

                            oda.UpdateCommand = ocb.GetUpdateCommand();

                            if (oda.Update(ds, tbl) == 1)
                            {
                                ds.AcceptChanges();
                                msg = "Updated";
                            }
                            else
                            {
                                ds.RejectChanges();
                                msg = "Rejected";
                                return msg;
                            }
                        }
                    }

                    string msgImages = ReNewPageImages(fullPath, newFullPath);

                    if (msgImages != "ReNewed")
                        return msgImages;
                }
                else if (duplicate)
                    msg = "Duplicate Error";
                else
                    msg = "Not Found";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string NodesErase(string fullPath, string parentPath, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            fullPath = fullPath.Trim();
            parentPath = parentPath.Trim();
            tbl = tbl.Trim();

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

                bool found = false;

                dt = ds.Tables[tbl];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if ((dr["fullpath"].ToString().Trim() + "\\").Contains(fullPath + "\\"))
                    {
                        found = true;

                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            msg = CleanPageImages(fullPath);

                            if (msg != "Cleaned")
                                return msg;

                            ds.AcceptChanges();
                            msg = "Erased";
                            i--;
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }
                    }
                }

                if (!found)
                    msg = "Not Found";

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;

                NodesReSort(parentPath, tbl);
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    private void NodesReSort(string parentPath, string tbl)
    {
        string sqlStr = "SELECT * FROM " + tbl + " ORDER BY fullpath ASC";

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
            int zIndex = -1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];

                if (dr["fullpath"].ToString().Trim() ==  string.Concat(parentPath, "\\", dr["pg"].ToString().Trim()))
                {
                    dr.BeginEdit();
                    dr["zindex"] = ++zIndex;
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
            dt.Dispose();
            ocb.Dispose();
            oda.Dispose();
            cnn.Dispose();

            ds = null;
            ocb = null;
            oda = null;
            dr = null;
            dt = null;
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
    }

    [WebMethod]
    public string NodesChangeIndex(string fullPath, int newIndex, string besidePath, int oldIndex, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            fullPath = fullPath.Trim();
            besidePath = besidePath.Trim();
            tbl = tbl.Trim();

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

                bool found = false;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if (dr["fullpath"].ToString().Trim() == fullPath)
                    {
                        dr.BeginEdit();
                        dr["zindex"] = newIndex;
                        dr.EndEdit();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "ReIndexed";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            return msg;
                        }

                        found = true;
                        continue;
                    }
                    if (dr["fullpath"].ToString().Trim() == besidePath)
                    {
                        dr.BeginEdit();
                        dr["zindex"] = oldIndex;
                        dr.EndEdit();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "ReIndexed";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            return msg;
                        }

                        continue;
                    }
                }

                if (!found)
                    msg = "Not Found";

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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Webiste Pages

    [WebMethod]
    public byte[] ServerPageGet(string fullPath, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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
                    if (drr["fullpath"].ToString().Trim() == fullPath.Trim())
                    {
                        msg = srvMsgSuccess + EncDec.Decrypt(drr["body"].ToString(), Base.hashKey);
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
                msg = srvMsgErr + ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = srvMsgErr + errInvalidLegal;

        return Zipper.Compress(msg);
    }

    [WebMethod]
    public string ServerPageSet(string fullPath, byte[] zipContents, byte[][] buffer, string[] ext, string[] ph, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string sqlStr = "SELECT * FROM " + tbl;

            string contents = Zipper.DecompressToStrng(zipContents).Trim();

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);

                int id = -1;

                while (drr.Read())
                {
                    ++id;

                    if (drr["fullpath"].ToString().Trim() == fullPath.Trim())
                    {
                        dt = ds.Tables[tbl];
                        dr = dt.Rows[id];

                        string oldContetns = string.Empty;
                        string fileName = string.Empty;
                        string src = "src=\"";
                        string show = "showpics.aspx?t=&id=";

                        oldContetns = EncDec.Decrypt(drr["body"].ToString().Trim(), Base.hashKey);

                        int pos1 = -1;
                        int pos2 = 0;

                        string[] removed = { };

                        while (true)
                        {
                            pos1 = oldContetns.IndexOf(src, pos2) + src.Length;

                            if (pos1 != src.Length - 1)
                            {
                                pos2 = oldContetns.IndexOf("\"", pos1);
                                fileName = oldContetns.Substring(pos1, pos2 - pos1);

                                if (fileName.IndexOf(show) != -1)
                                {
                                    fileName = fileName.Substring(show.Length);

                                    if (contents.IndexOf(fileName) == -1)
                                    {
                                        bool duplicated = false;

                                        foreach (string f in removed)
                                        {
                                            if (f == fileName)
                                                duplicated = true;
                                        }
                                        if (!duplicated)
                                        {
                                            int len = removed.Length;
                                            Array.Resize(ref removed, len + 1);
                                            removed[len] = fileName;
                                            duplicated = false;
                                        }
                                    }
                                }
                            }
                            else
                                break;
                        }

                        if (removed.Length > 0)
                        {
                            msg = RemoveImages(removed);

                            if (msg != "Removed")
                                return msg;
                        }

                        if (ph.Length > 0)
                        {
                            msg = CatchImages(fullPath, buffer, ext, true);

                            if (msg != "Created")
                                return msg;

                            for (int i = 0; i < ph.Length; i++)
                            {
                                contents = contents.Replace(ph[i], show + pgImages[i]);
                            }
                        }


                        //flvObject Section

                        pos1 = -1;
                        pos2 = 0;
                        Array.Resize(ref removed, 0);

                        if (oldContetns.ToLower().Contains("<div"))
                        {
                            int p1 = -1;
                            int p2 = -1;

                            fileName = string.Empty;

                            while (true)
                            {
                                pos1 = oldContetns.ToLower().IndexOf("<div", pos2);
                                if (pos1 == -1)
                                    break;
                                pos2 = oldContetns.ToLower().IndexOf("</div>", pos1) + "</div>".Length;
                                if (pos2 == -1)
                                    break;

                                string swf = oldContetns.Substring(pos1, pos2 - pos1);

                                if (swf.Contains(".flv"))
                                {
                                    p1 = swf.IndexOf("id=\"") + "id=\"".Length;
                                    p2 = swf.IndexOf("\"", p1);

                                    fileName = swf.Substring(p1, p2 - p1);

                                    if (!contents.Contains(fileName))
                                    {
                                        bool duplicated = false;

                                        foreach (string f in removed)
                                        {
                                            if (f == fileName)
                                                duplicated = true;
                                        }
                                        if (!duplicated)
                                        {
                                            int len = removed.Length;
                                            Array.Resize(ref removed, len + 1);
                                            removed[len] = fileName;
                                            duplicated = false;
                                        }
                                    }
                                }
                            }
                        }

                        if (removed.Length > 0)
                        {
                            msg = RemoveFLV(removed);

                            if (msg != "Removed")
                                return msg;
                        }

                        //end flvObject Section

                        dr.BeginEdit();

                        dr["body"] = EncDec.Encrypt(contents.Trim(), Base.hashKey);

                        dr.EndEdit();


                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            msg = "Saved";
                            ds.AcceptChanges();
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
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
                msg = ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Image DB Working

    private string CatchImages(string target, byte[][] buffer, string[] ext, bool retFileNames)
    {
        string msg = string.Empty;

        try
        {
            string tbl = "pics";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
            OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
            OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

            cnn.Open();

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr;

            ocb.QuotePrefix = "[";
            ocb.QuoteSuffix = "]";
            oda.Fill(ds, tbl);

            string[] fileName = { };

            dt = ds.Tables[tbl];

            foreach (string e in ext)
            {
                while (true)
                {
                    string name = NameGen();
                    bool found = false;

                    foreach (string f in fileName)
                    {
                        if (f == name)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dr = dt.Rows[i];

                            if (dr["id"].ToString() == name)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        int len = fileName.Length;
                        Array.Resize(ref fileName, len + 1);
                        fileName[len] = name;
                        break;
                    }
                }
            }

            for (int i = 0; i < ext.Length; i++)
            {
                dr = dt.NewRow();

                dr["id"] = fileName[i];
                dr["ext"] = ext[i].ToLower().Trim();
                dr["data"] = Convert.ToBase64String(buffer[i]);
                dr["location"] = target.Trim();

                dt.Rows.Add(dr);

                oda.InsertCommand = ocb.GetInsertCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Created";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                    break;
                }
            }

            if (msg == "Created" && retFileNames)
            {
                Array.Resize(ref pgImages, 0);

                pgImages = fileName;

                //msg = "Created";
            }

            cnn.Close();

            ds.Dispose();
            dt.Dispose();
            ocb.Dispose();
            oda.Dispose();
            cnn.Dispose();

            ds = null;
            ocb = null;
            oda = null;
            dr = null;
            dt = null;
            cnn = null;
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

    private string RemoveImages(string[] ids)
    {
        string msg = string.Empty;

        try
        {
            while (true)
            {
                string tbl = "pics";
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
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

                foreach (string id in ids)
                {
                    bool found = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (dr["id"].ToString().Trim() == id.Trim())
                        {
                            found = true;

                            dr.Delete();
                        }
                    }

                    if (found)
                    {
                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();

                            msg = "Removed";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }
                    }
                    else
                    {
                        msg = "Image Not Found And Cannot Be Removed...";
                        break;
                    }
                }

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;

                break;
            }
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

    private string CleanPageImages(string fullPath)
    {
        string msg = "Cleaned";

        try
        {
            while (true)
            {
                string tbl = "pics";
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
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

                    if ((dr["location"].ToString().Trim()).Contains(fullPath))
                    {
                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "Cleaned";
                            i--;
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }
                    }
                }

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;

                break;
            }
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

    private string ReNewPageImages(string fullPath, string newFullPath)
    {
        string msg = "ReNewed";

        try
        {
            while (true)
            {
                string tbl = "pics";
                string sqlStr = "SELECT * FROM " + tbl;

                OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);
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

                    if ((dr["location"].ToString().Trim()).Contains(fullPath))
                    {
                        dr.BeginEdit();
                        dr["location"] = dr["location"].ToString().Trim().Replace(fullPath, newFullPath);
                        dr.EndEdit();

                        oda.UpdateCommand= ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "ReNewed";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }
                    }
                }

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;

                break;
            }
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

    #endregion

    #region Gallery DB Working

    [WebMethod]
    public string GalleryCatchChanges(string target, byte[][] buffer, string[] ext, string[] erasedList, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            try
            {
                if (erasedList.Length > 0)
                    msg = RemoveImages(erasedList);
                else
                    msg = "Removed";

                if (msg != "Removed")
                    return msg;

                if (buffer.Length > 0)
                    msg = CatchImages(target, buffer, ext, false);
                else
                    msg = "Created";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string[] GalleryImagesList(string target, string legal)
    {
        string[] list = { };

        try
        {
            string tbl = "pics";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);

            cnn.Open();

            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            OleDbDataReader drr = cmd.ExecuteReader();

            while (drr.Read())
            {
                if (drr["location"].ToString().Trim() == target.ToString().Trim())
                {
                    int len = list.Length;
                    Array.Resize(ref list, len + 1);
                    list[len] = drr["id"].ToString().Trim() + drr["ext"].ToString().Trim();
                }
            }

            cnn.Close();
            drr.Close();

            cmd.Dispose();
            drr.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
        }

        return list;
    }

    [WebMethod(BufferResponse = false)]
    public byte[][] GalleryImagesData(string target, string legal)
    {
        byte[][] buffer = { };

        try
        {
            string tbl = "pics";
            string sqlStr = "SELECT * FROM " + tbl;

            OleDbConnection cnn = new OleDbConnection(Base.cnnStrPics);

            cnn.Open();

            OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
            OleDbDataReader drr = cmd.ExecuteReader();

            while (drr.Read())
            {
                if (drr["location"].ToString().Trim() == target.ToString().Trim())
                {
                    int len = buffer.Length;
                    Array.Resize(ref buffer, len + 1);

                    MemoryStream iMS = new MemoryStream(Convert.FromBase64String(drr["data"].ToString()));
                    Image img = new Bitmap(iMS);

                    Image thumb = img.GetThumbnailImage(128, 96, null, new IntPtr());

                    MemoryStream tMS = new MemoryStream();
                    thumb.Save(tMS, ImageFormat.Jpeg);

                    buffer[len] = tMS.ToArray();
                }
            }

            cnn.Close();
            drr.Close();

            cmd.Dispose();
            drr.Dispose();
            cnn.Dispose();

            cmd = null;
            drr = null;
            cnn = null;
        }
        catch
        {
        }
        finally
        {
        }

        return buffer;
    }

    #endregion

    #region Contact List

    [WebMethod]
    public DataTable ContactList(string tbl, string legal)
    {
        DataTable dt = new DataTable(tbl);

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();


                DataSet ds = new DataSet();

                DataRow dr;

                dt.Columns.Add("mailbox", Type.GetType("System.String"));
                dt.Columns.Add("rname", Type.GetType("System.String"));

                while (drr.Read())
                {
                    dr = dt.NewRow();

                    dr["mailbox"] = EncDec.Decrypt(drr["mailbox"].ToString(), Base.hashKey);
                    dr["rname"] = EncDec.Decrypt(drr["rname"].ToString(), Base.hashKey);

                    dt.Rows.Add(dr);
                }

                dt.AcceptChanges();

                tbl = null;
                sqlStr = null;

                cnn.Close();
                drr.Close();
                cmd.Clone();

                drr.Dispose();
                cmd.Dispose();
                cnn.Dispose();
                ds.Dispose();

                dr = null;
                ds = null;
                drr = null;
                cmd = null;
                cnn = null;
            }
            catch
            {
            }
            finally
            {
            }
        }

        return dt;
    }

    [WebMethod]
    public string ContactListCatchChanges(string tbl, DataTable dtList, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            try
            {
                string sqlStr = "SELECT * FROM " + tbl;

                if (!CleanTable(tbl))
                {
                    return "Can't Clean Table";
                }

                DataRow drList;

                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);
                dt = ds.Tables[tbl];

                if (dtList.Rows.Count > 0)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        dr = dt.NewRow();
                        drList = dtList.Rows[i];

                        dr["mailbox"] = EncDec.Encrypt(drList[0].ToString().Trim(), Base.hashKey);
                        dr["rname"] = EncDec.Encrypt(drList[1].ToString().Trim(), Base.hashKey);

                        dt.Rows.Add(dr);

                        oda.InsertCommand = ocb.GetInsertCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "Catched";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }
                    }
                }
                else
                    msg = "Catched";

                cnn.Close();

                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                dr = null;
                dt = null;
                ds = null;
                ocb = null;
                oda = null;
                cnn = null;

                tbl = null;
                sqlStr = null;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    #endregion

    #region News Section

    [WebMethod]
    public DataTable NewsAll(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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

                dt.Columns.Remove("body");
                dt.Columns.Remove("pic");

                DataRow dr;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    dr.BeginEdit();

                    dr["date"] = Base.FormatDateToOriginal(dr["date"].ToString().Trim());
                    dr["header"] = EncDec.Decrypt(dr["header"].ToString(), Base.hashKey);
                    
                    dr.EndEdit();
                    dr.AcceptChanges();
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
        }

        return dt;
    }

    [WebMethod]
    public string NewsAdd(string tbl, string title, byte[] zipContents, byte[] buffer, string ext, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tbl = tbl.Trim();
            title = title.Trim();
            string body = Zipper.DecompressToStrng(zipContents).Trim();
            ext = ext.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                dr = dt.NewRow();
                int id = dt.Rows.Count + 1;

                if (buffer.Length > 0)
                {
                    //msg = CatchImages("{" + tbl + "}/{" + id + "}", new byte[][] { buffer }, new string[] { ext }, true);
                    msg = CatchImages(tbl , new byte[][] { buffer }, new string[] { ext }, true);
                    if (msg != "Created")
                        return msg;

                    dr["pic"] = pgImages[0];
                }

                dr["id"] = id;
                dr["header"] = EncDec.Encrypt(title.Trim(), Base.hashKey);
                dr["body"] = EncDec.Encrypt(body.Trim(), Base.hashKey);
                dr["archived"] = false;

                string date = string.Empty;

                if (tbl == "newsfa")
                    date = Base.GetPersianDate();
                else if (tbl == "newsen")
                    date = Base.GetGregorianDate();
                else if (tbl == "newsar")
                    date = Base.GetHijriDate();

                dr["date"] = Base.FormatDateToRaw(date);

                dt.Rows.Add(dr);

                oda.InsertCommand = ocb.GetInsertCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Added";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                }

                cnn.Close();
                drr.Close();

                ds.Dispose();
                dt.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string NewsSetArchive(string tbl, int wh, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

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
                    if (Convert.ToInt32(dr["id"]) == wh)
                    {
                        dr.BeginEdit();
                        dr["archived"] = !Convert.ToBoolean(dr["archived"]);
                        dr.EndEdit();
                        break;
                    }
                }
                oda.UpdateCommand = ocb.GetUpdateCommand();

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Updated";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                }

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string NewsErase(string tbl, int wh, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            tbl = tbl.Trim();

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

                bool found = false;
                bool isDeleted = false;

                dt = ds.Tables[tbl];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if (isDeleted)
                    {
                        dr.BeginEdit();
                        dr["id"] = i + 1;
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "Erased";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }
                    }
                    else if (Convert.ToInt32(dr["id"]) == wh)
                    {
                        found = true;

                        if (dr["pic"].ToString().Trim() != string.Empty)
                        {
                            msg = RemoveImages(new string[] { dr["pic"].ToString().Trim() });
                            if (msg != "Removed")
                                return msg;
                        }

                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "Erased";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                            break;
                        }

                        dt = ds.Tables[tbl];

                        isDeleted = true;
                        --i;
                    }
                }

                if (!found)
                    msg = "Not Found";

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public byte[] NewsEditGet(string tbl, int wh, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            tbl = tbl.Trim();
            
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (Convert.ToInt32(dr["id"]) == wh)
                    {
                        msg = srvMsgSuccess + EncDec.Decrypt(dr["body"].ToString(), Base.hashKey);
                        break;
                    }
                }

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                msg = srvMsgErr + ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = srvMsgErr + errInvalidLegal;

        return Zipper.Compress(msg);
    }

    [WebMethod]
    public string NewsEditGetImageName(string tbl, int wh, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && IsDaysLeft())
        {
            tbl = tbl.Trim();
            
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                cnn.Open();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    if (Convert.ToInt32(dr["id"]) == wh)
                    {
                        msg = srvMsgSuccess + dr["pic"].ToString().Trim();
                        break;
                    }
                }

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                oda = null;
                dr = null;
                dt = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                msg = srvMsgErr + ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = srvMsgErr + errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string NewsEditSet(string tbl, int wh, string title, byte[] zipContents, string imageMode, byte[] buffer, string ext, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tbl = tbl.Trim();
            title = title.Trim();
            string body = Zipper.DecompressToStrng(zipContents).Trim();
            ext = ext.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

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
                    if (Convert.ToInt32(dr["id"]) == wh)
                    {
                        dr.BeginEdit();
                        dr["header"] = EncDec.Encrypt(title.Trim(), Base.hashKey);
                        dr["body"] = EncDec.Encrypt(body.Trim(), Base.hashKey);

                        switch (imageMode)
                        {
                            case "old":
                                break;
                            case "clean":
                                if (dr["pic"].ToString().Trim() != string.Empty)
                                {
                                    msg = RemoveImages(new string[] { dr["pic"].ToString().Trim() });
                                    if (msg != "Removed")
                                        return msg;
                                    dr["pic"] = string.Empty;
                                }
                                break;
                            case "new":
                                if (dr["pic"].ToString().Trim() != string.Empty)
                                {
                                    msg = RemoveImages(new string[] { dr["pic"].ToString().Trim() });
                                    if (msg != "Removed")
                                        return msg;
                                    dr["pic"] = string.Empty;
                                }
                                //msg = CatchImages("{" + tbl + "}/{" + wh + "}", new byte[][] { buffer }, new string[] { ext }, true);
                                msg = CatchImages(tbl , new byte[][] { buffer }, new string[] { ext }, true);
                                if (msg != "Created")
                                    return msg;
                                dr["pic"] = pgImages[0];
                                break;
                            default:
                                break;
                        }

                        dr.EndEdit();
                        break;
                    }
                }

                if (oda.Update(ds, tbl) == 1)
                {
                    ds.AcceptChanges();
                    msg = "Updated";
                }
                else
                {
                    ds.RejectChanges();
                    msg = "Rejected";
                }

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Gallery Definitions

    [WebMethod]
    public DataSet GalleryDefAllTables(string legal)
    {
        DataSet ds = new DataSet();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            ds.Tables.Add(GalleryDefAll("galleryfa", legal));
            ds.Tables.Add(GalleryDefAll("galleryen", legal));
            ds.Tables.Add(GalleryDefAll("galleryar", legal));
        }

        return ds;
    }

    [WebMethod]
    public DataTable GalleryDefAll(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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
        }

        return dt;
    }

    [WebMethod]
    public string GalleryDefAdd(string id, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            id = id.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;

                while (drr.Read())
                {
                    if (drr["id"].ToString().Trim() == id)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dt = ds.Tables[tbl];
                    dr = dt.NewRow();

                    dr["id"] = id;
                    dr["viewcount"] = 0;

                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        msg = "Added";
                    }
                    else
                    {
                        ds.RejectChanges();
                        msg = "Rejected";
                    }
                }
                else
                    msg = "Already Exist";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                dt.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string GalleryDefEdit(string id, string newID, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            id = id.Trim();
            newID = newID.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;
                bool duplicate = false;

                while (drr.Read())
                {
                    if (drr["id"].ToString().Trim() == id)
                        found = true;
                    else if (drr["id"].ToString().Trim() == newID)
                        duplicate = true;
                }

                if (found && !duplicate)
                {
                    dt = ds.Tables[tbl];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (dr["id"].ToString().Trim() == id)
                        {
                            dr.BeginEdit();

                            dr["id"] = newID;

                            dr.EndEdit();

                            oda.UpdateCommand = ocb.GetUpdateCommand();

                            if (oda.Update(ds, tbl) == 1)
                            {
                                msg = ReNewPageImages(tbl + "\\" + id, tbl + "\\" + newID);

                                if (msg != "ReNewed")
                                    return msg;

                                ds.AcceptChanges();
                                msg = "Updated";
                            }
                            else
                            {
                                ds.RejectChanges();
                                msg = "Rejected";
                            }

                            break;
                        }
                    }
                }
                else if (duplicate)
                    msg = "Duplicate Error";
                else
                    msg = "Not Found";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string GalleryDefErase(string id, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            id = id.Trim();
            tbl = tbl.Trim();

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

                bool found = false;

                dt = ds.Tables[tbl];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if (dr["id"].ToString().Trim() == id)
                    {
                        found = true;
                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            msg = CleanPageImages(tbl + "\\" + id);

                            if (msg != "Cleaned")
                                return msg;

                            ds.AcceptChanges();
                            msg = "Erased";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                if (!found)
                    msg = "Not Found";

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Server Filing / FileManager

    [WebMethod]
    public string FileUpload(byte[][] buffer, string[] files, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim())
        {
            try
            {
                if (files.Length > 0)
                {
                    if (!Directory.Exists(Base.pathLUF))
                        Directory.CreateDirectory(Base.pathLUF);

                    string filePath = string.Empty;
                    bool fileExists = false;

                    for (int i = 0; i < files.Length; i++)
                    {
                        filePath = Base.pathLUF + files[i];
                        fileExists = File.Exists(filePath);
                        if (fileExists)
                        {
                            File.Delete(filePath);
                        }
                        using (FileStream fs = new FileStream(filePath, FileMode.Create))
                        {
                            fs.Write(buffer[i], 0, buffer[i].Length);
                            fs.Close();
                        }
                    }

                    msg = "Uploaded!";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    [WebMethod]
    public byte[][] FileDownload(string[] files, string legal)
    {
        byte[][] contents = { };

        if (tLegal == legal.Trim())
        {
            try
            {
                if (files.Length > 0)
                {
                    string filePath = string.Empty;
                    bool fileExists = false;

                    for (int i = 0; i < files.Length; i++)
                    {
                        filePath = Base.pathLUF + files[i];
                        fileExists = File.Exists(filePath);
                        if (fileExists)
                        {
                            int fileSize = (int)new FileInfo(filePath).Length;
                            byte[] buffer = new byte[fileSize];

                            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                            {
                                fs.Read(buffer, 0, fileSize);
                                fs.Close();
                            }

                            Array.Resize(ref contents, i + 1);
                            contents[i] = buffer;
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        return contents;
    }

    [WebMethod]
    public bool FileIsFoundOnServer(string fileName, string legal)
    {
        bool state = false;

        if (tLegal == legal.Trim())
        {
            try
            {
                string filePath = Base.pathLUF + fileName;
                bool fileExists = File.Exists(filePath);
                if (fileExists)
                {
                    state = true;
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        return state;
    }

    [WebMethod]
    public string FileRename(string fileName, string newFileName, string legal)
    {
        string msg;

        if (tLegal == legal.Trim())
        {
            try
            {
                string filePath = Base.pathLUF + fileName;

                if (FileIsFoundOnServer(fileName, legal))
                {
                    File.Move(filePath, Base.pathLUF + newFileName);
                    msg = "Renamed!";
                }
                else
                {
                    msg = "Not Found";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    [WebMethod]
    public string FileErase(string[] files, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim())
        {
            try
            {
                for (int i = 0; i < files.Length; i++)
                {
                    string filePath = Base.pathLUF + files[i];

                    if (FileIsFoundOnServer(files[i], legal))
                    {
                        File.Delete(filePath);
                        msg = "Erased!";
                    }
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    private string GetFileSizeWithUnit(string filePath)
    {
        long size = new FileInfo(filePath).Length;

        string unit = string.Empty;
        string strSize = string.Empty;

        if (size < 1024)
        {
            unit = "B";
            strSize = size.ToString();
        }
        else if (size < 1048576)
        {
            unit = "KB";
            strSize = ((float)size / 1024).ToString();
        }
        else if (size < 1073741824)
        {
            unit = "MB";
            strSize = ((float)size / 1048576).ToString();
        }
        else if (size < 1099511627776)
        {
            unit = "GB";
            strSize = ((float)size / 1073741824).ToString();
        }
        else if (size < 1125899906842624)
        {
            unit = "TB";
            strSize = ((float)size / 1099511627776).ToString();
        }

        try
        {
            int point = strSize.IndexOf(".");
            if (point > -1)
                strSize = strSize.Substring(0, point + 3);
        }
        catch
        {
        }

        return string.Format("{0} {1}", strSize, unit);
    }

    [WebMethod]
    public string[][] FilesListServer(string legal)
    {
        string[][] filesInfo = { };

        if (tLegal == legal.Trim())
        {
            try
            {
                string[] filesList = Directory.GetFiles(Base.pathLUF);
                
                Array.Resize(ref filesInfo, filesList.Length);

                for (int i = 0; i < filesList.Length; i++)
                {
                    filesInfo[i] = new string[] { filesList[i].Substring(filesList[i].LastIndexOf(Path.DirectorySeparatorChar.ToString()) + 1), GetFileSizeWithUnit(filesList[i]) };
                }
            }
            catch
            {
            }
            finally
            {
            }
        }

        return filesInfo;
    }

    #endregion

    #region Reports
    
    [WebMethod]
    public DataTable ReportsPagesViewCount(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string sqlStr = "SELECT * FROM " + tbl + " ORDER BY zindex, fullpath ASC";

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                DataTable dtRaw = ds.Tables[tbl].Copy();

                dt.Columns.Add("pg", Type.GetType("System.String"));
                dt.Columns.Add("viewcount", Type.GetType("System.Int32"));

                dt.TableName = dtRaw.TableName;

                DataRow drRaw;
                DataRow dr;

                for (int i = 0; i < dtRaw.Rows.Count; i++)
                {
                    drRaw = dtRaw.Rows[i];
                    if (drRaw["parent"].ToString().Trim() == "root")
                    {
                        dr = dt.NewRow();
                        dr["pg"] = drRaw["pg"].ToString().Trim();
                        dr["viewcount"] = 0;
                        dt.Rows.Add(dr);

                        drRaw.Delete();
                        continue;
                    }
                    if (drRaw["parent"].ToString().Trim() == "nav")
                    {
                        drRaw.Delete();
                        continue;
                    }
                }

                dtRaw.AcceptChanges();
                dt.AcceptChanges();

                string wh = string.Empty;
                string rootTitle = string.Empty;

                switch (tbl)
                {
                    case "pagesfa":
                        rootTitle = Base.rootTitleFa;
                        break;
                    case "pagesen":
                        rootTitle = Base.rootTitleEn;
                        break;
                    case "pagesar":
                        rootTitle = Base.rootTitleAr;
                        break;
                    default:
                        break;
                }

                int count = -1;
                int countr = -1;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];
                    wh = dr["pg"].ToString().Trim();

                    for (int j = 0; j < dtRaw.Rows.Count; j++)
                    {
                        drRaw = dtRaw.Rows[j];
                        if (drRaw["fullpath"].ToString().Trim().Contains(rootTitle + "\\" + wh + "\\"))
                        {
                            try
                            {
                                count = dr["viewcount"].ToString().Trim() != string.Empty ? Convert.ToInt32(dr["viewcount"]) : 0;
                            }
                            catch
                            {
                                count = 0;
                            }
                            try
                            {
                                countr = drRaw["viewcount"].ToString().Trim() != string.Empty ? Convert.ToInt32(drRaw["viewcount"]) : 0;
                            }
                            catch
                            {
                                countr = 0;
                            }
                            dr.BeginEdit();
                            dr["viewcount"] = count + countr;
                            dr.EndEdit();
                            dr.AcceptChanges();
                        }
                    }
                }

                dt.AcceptChanges();

                cnn.Close();

                ds.Dispose();
                dtRaw.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                oda = null;
                dr = null;
                drRaw = null;
                dtRaw = null;
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
        }

        return dt;
    }

    [WebMethod]
    public DataTable ReportsGalleriesViewCount(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string sqlStr = "SELECT * FROM " + tbl + " ORDER BY id ASC";

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl].Copy();

                cnn.Close();

                ds.Dispose();
                oda.Dispose();
                cnn.Dispose();

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
        }

        return dt;
    }

    #endregion

    #region Insert/Remove FLV Movies

    [WebMethod]
    public string FLVUpload(byte[] buffer, string file, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim())
        {
            try
            {
                if (file.Length > 0)
                {
                    if (!Directory.Exists(Base.pathFLV))
                        Directory.CreateDirectory(Base.pathFLV);

                    string filePath = string.Empty;
                    string fileNewName = string.Empty;

                    filePath = Base.pathFLV + file;
                    if (File.Exists(filePath))
                    {
                        while (true)
                        {
                            fileNewName = NameGen();
                            filePath = Base.pathFLV + fileNewName;
                            if (!File.Exists(filePath))
                            {
                                break;
                            }
                        }
                    }

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(buffer, 0, buffer.Length);
                        fs.Close();
                    }

                    msg = "Uploaded!" + fileNewName;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            finally
            {
            }
        }
        else
            msg = "illegal";

        return msg;
    }

    private string RemoveFLV(string[] ids)
    {
        string msg = string.Empty;

        try
        {
            while (true)
            {
                bool found = false;

                foreach (string id in ids)
                {

                    found = File.Exists(Base.pathFLV + id);

                    if (found)
                    {
                        File.Delete(Base.pathFLV + id);
                        msg = "Removed";
                    }
                    else
                    {
                        msg = "Image Not Found And Cannot Be Removed...";
                        break;
                    }
                }
                break;
            }
        }
        catch (IOException ex)
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

    #endregion

    #region Calendar

    [WebMethod]
    public DataTable CalendarAll(string tbl, string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl + " ORDER BY month, day ASC";

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);

                cnn.Open();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                dt = ds.Tables[tbl].Copy();

                dt.Columns.Remove("body");
                dt.Columns.Remove("id");

                DataRow dr;

                string month = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    dr.BeginEdit();

                    dr["title"] = EncDec.Decrypt(dr["title"].ToString(), Base.hashKey).Trim();

                    switch (tbl)
                    {
                        case "calendarfa":
                            month = Base.FormatMonthsToPersianNames(dr["month"].ToString().Trim());
                            break;
                        case "calendaren":
                            month = Base.FormatMonthsToEnglishNames(dr["month"].ToString().Trim());
                            break;
                        case "calendarar":
                            month = Base.FormatMonthsToArabicNames(dr["month"].ToString().Trim());
                            break;
                        default:
                            break;
                    }

                    dr["month"] = month;

                    dr.EndEdit();
                    dr.AcceptChanges();
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
        }

        return dt;
    }

    [WebMethod]
    public string CalendarAdd(string month, string day, string title, string body, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            month = month.Trim();
            day = day.Trim();
            title = title.Trim();
            body = body.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;

                while (drr.Read())
                {
                    if (EncDec.Decrypt(drr["title"].ToString().Trim(), Base.hashKey) == title)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dt = ds.Tables[tbl];
                    dr = dt.NewRow();

                    dr["month"] = month;
                    dr["day"] = day;
                    dr["title"] = EncDec.Encrypt(title, Base.hashKey);
                    dr["body"] = EncDec.Encrypt(body, Base.hashKey);

                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        msg = "Added";
                    }
                    else
                    {
                        ds.RejectChanges();
                        msg = "Rejected";
                    }
                }
                else
                    msg = "Already Exist";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                dt.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string CalendarGetBody(string title, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            title = title.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                bool found = false;

                while (drr.Read())
                {
                    if (EncDec.Decrypt(drr["title"].ToString().Trim(), Base.hashKey).Trim() == title)
                    {
                        msg = srvMsgSuccess + EncDec.Decrypt(drr["body"].ToString().Trim(), Base.hashKey).Trim();
                        found = true;
                        break;
                    }
                }

                if (!found)
                    msg = srvMsgErr + "Not Found";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                cmd = null;
                drr = null;
                cnn = null;
            }
            catch (Exception ex)
            {
                msg = srvMsgErr + ex.Message;
            }
            finally
            {
                tbl = null;
                sqlStr = null;
            }
        }
        else
            msg = srvMsgErr + errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string CalendarEdit(string month, string day, string title, string newTitle, string body, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            month = month.Trim();
            day = day.Trim();
            title = title.Trim();
            newTitle = newTitle.Trim();
            body = body.Trim();
            tbl = tbl.Trim();

            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;
                bool duplicate = false;

                bool isTitleChanged = title == newTitle ? false : true;

                while (drr.Read())
                {
                    if (EncDec.Decrypt(drr["title"].ToString(), Base.hashKey).Trim() == title)
                        found = true;
                    else if (EncDec.Decrypt(drr["title"].ToString().Trim(), Base.hashKey) == newTitle && isTitleChanged)
                        duplicate = true;

                    if (found && !isTitleChanged)
                    {
                        duplicate = false;
                        break;
                    }
                }

                if (found && !duplicate)
                {
                    dt = ds.Tables[tbl];

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (EncDec.Decrypt(dr["title"].ToString(), Base.hashKey).Trim() == title)
                        {
                            dr.BeginEdit();

                            dr["month"] = month;
                            dr["day"] = day;
                            if (isTitleChanged)
                                dr["title"] = EncDec.Encrypt(newTitle, Base.hashKey);
                            dr["body"] = EncDec.Encrypt(body, Base.hashKey);

                            dr.EndEdit();

                            oda.UpdateCommand = ocb.GetUpdateCommand();

                            if (oda.Update(ds, tbl) == 1)
                            {
                                ds.AcceptChanges();
                                msg = "Updated";
                            }
                            else
                            {
                                ds.RejectChanges();
                                msg = "Rejected";
                            }

                            break;
                        }
                    }
                }
                else if (duplicate)
                    msg = "Duplicate Error";
                else
                    msg = "Not Found";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string CalendarErase(string title, string tbl, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            title = title.Trim();
            tbl = tbl.Trim();

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

                bool found = false;

                dt = ds.Tables[tbl];

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if (EncDec.Decrypt(dr["title"].ToString(), Base.hashKey).Trim() == title)
                    {
                        found = true;
                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "Erased";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                if (!found)
                    msg = "Not Found";

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Watermark

    [WebMethod]
    public bool WatermarkStatusGet(string legal)
    {
        bool watermark = true;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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
        }

        return watermark;
    }

    [WebMethod]
    public string WatermarkStatusSet(bool watermark, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == "copyright")
                    {
                        dr.BeginEdit();
                        dr["val"] = watermark ? "Watermark" : "None";
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }

    #endregion

    #region Special Right Click

    [WebMethod]
    public bool SpecRightClickGet(string legal)
    {
        bool rightclick = true;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
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
        }

        return rightclick;
    }

    [WebMethod]
    public string SpecRightClickSet(bool rightclick, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == "rightclick")
                    {
                        dr.BeginEdit();
                        dr["val"] = rightclick ? "spec" : "norm";
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }

    #endregion

    #region Scroll Text

    [WebMethod]
    public DataTable ScrollTextGet(string legal)
    {
        DataTable dtTitles = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                dtTitles.TableName = "ScrText";
                dtTitles.Columns.Add("Lang", Type.GetType("System.String"));
                dtTitles.Columns.Add("Text", Type.GetType("System.String"));

                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                int count = 0;
                DataRow dr;

                while (drr.Read())
                {
                    if (drr["tag"].ToString().Trim() == "scrfa")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "فارسی";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (drr["tag"].ToString().Trim() == "scren")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "English";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (drr["tag"].ToString().Trim() == "scrar")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "العربية";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (count == 3)
                        break;
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
                dr = null;
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

        return dtTitles;
    }

    [WebMethod]
    public string ScrollTextChange(string tag, string val, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tag = tag.Trim();
            val = val.Trim();

            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            switch (tag)
            {
                case "فارسی":
                    tag = "scrfa";
                    break;
                case "English":
                    tag = "scren";
                    break;
                case "العربية":
                    tag = "scrar";
                    break;
                default:
                    msg = "Rejected";
                    break;
            }

            if (msg == "Rejected")
                return msg;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == tag)
                    {
                        dr.BeginEdit();
                        dr["val"] = EncDec.Encrypt(val, Base.hashKey);
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }
    
    #endregion

    #region Website Logo

    [WebMethod]
    public string LogoUpload(string lang, byte[] logo, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            lang = "logo" + lang.Trim();

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == lang)
                    {
                        dr.BeginEdit();
                        dr["val"] = Convert.ToBase64String(logo);
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }

    [WebMethod]
    public byte[] LogoDownload(string legal)
    {
        byte[] logo = { };

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            //lang = "logo" + lang.Trim();

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
                    if (drr["tag"].ToString().Trim() == "logoraw")
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
        }

        return logo;
    }

    #endregion

    #region Website Title

    [WebMethod]
    public DataTable WebsiteTitlesGet(string legal)
    {
        DataTable dtTitles = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                dtTitles.TableName = "WTitles";
                dtTitles.Columns.Add("بخش", Type.GetType("System.String"));
                dtTitles.Columns.Add("عنوان", Type.GetType("System.String"));

                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();

                oda.Fill(ds, tbl);

                int count = 0;
                DataRow dr;

                while (drr.Read())
                {
                    if (drr["tag"].ToString().Trim() == "titlefa")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "فارسی";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (drr["tag"].ToString().Trim() == "titleen")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "English";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (drr["tag"].ToString().Trim() == "titlear")
                    {
                        dr = dtTitles.NewRow();
                        dr[0] = "العربية";
                        dr[1] = EncDec.Decrypt(drr["val"].ToString().Trim(), Base.hashKey);
                        dtTitles.Rows.Add(dr);
                        dtTitles.AcceptChanges();
                        count++;
                        continue;
                    }
                    if (count == 3)
                        break;
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
                dr = null;
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

        return dtTitles;
    }

    [WebMethod]
    public string WebsiteTitlesChange(string tag, string val, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            tag = tag.Trim();
            val = val.Trim();

            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            switch (tag)
            {
                case "فارسی":
                    tag = "titlefa";
                    break;
                case "English":
                    tag = "titleen";
                    break;
                case "العربية":
                    tag = "titlear";
                    break;
                default:
                    msg = "Rejected";
                    break;
            }

            if (msg == "Rejected")
                return msg;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == tag)
                    {
                        dr.BeginEdit();
                        dr["val"] = EncDec.Encrypt(val, Base.hashKey);
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }

    #endregion

    #region Googling

    [WebMethod]
    public DataTable GoogleAll(string legal)
    {
        DataTable dt = new DataTable();

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            string tbl = "google";
            string sqlStr = "SELECT * FROM " + tbl + " ORDER BY mailbox ASC";

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
                    dt.Rows[i]["mailbox"] = EncDec.Decrypt(dt.Rows[i]["mailbox"].ToString(), Base.hashKey);

                dt.AcceptChanges();
                dt.Columns["mailBox"].ColumnName = "آدرس ایمیل";
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
        }

        return dt;
    }

    [WebMethod]
    public string GoogleAdd(string mailbox, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            mailbox = mailbox.Trim();

            string tbl = "google";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;

                mailbox = EncDec.Encrypt(mailbox, Base.hashKey);

                while (drr.Read())
                {
                    if (drr["mailbox"].ToString().Trim() == mailbox)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    dt = ds.Tables[tbl];
                    dr = dt.NewRow();

                    dr["mailbox"] = mailbox;

                    dt.Rows.Add(dr);

                    oda.InsertCommand = ocb.GetInsertCommand();

                    if (oda.Update(ds, tbl) == 1)
                    {
                        ds.AcceptChanges();
                        msg = "Added";
                    }
                    else
                    {
                        ds.RejectChanges();
                        msg = "Rejected";
                    }
                }
                else
                    msg = "Already Exist";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                dt.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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

        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string GoogleEdit(string mailbox, string newMailbox, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            mailbox = mailbox.Trim();
            newMailbox = newMailbox.Trim();

            string tbl = "google";
            string sqlStr = "SELECT * FROM " + tbl;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);

                cnn.Open();

                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                OleDbDataReader drr = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataRow dr;

                ocb.QuotePrefix = "[";
                ocb.QuoteSuffix = "]";
                oda.Fill(ds, tbl);

                bool found = false;
                bool duplicate = false;

                mailbox = EncDec.Encrypt(mailbox, Base.hashKey);
                newMailbox = EncDec.Encrypt(newMailbox, Base.hashKey);

                while (drr.Read())
                {
                    if (drr["mailbox"].ToString().Trim() == mailbox)
                        found = true;
                    else if (drr["mailbox"].ToString().Trim() == newMailbox)
                        duplicate = true;
                }

                if (found && !duplicate)
                {
                    dt = ds.Tables[tbl];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dr = dt.Rows[i];

                        if (dr["mailbox"].ToString().Trim() == mailbox)
                        {
                            dr.BeginEdit();

                            dr["mailbox"] = newMailbox;

                            dr.EndEdit();

                            oda.UpdateCommand = ocb.GetUpdateCommand();

                            if (oda.Update(ds, tbl) == 1)
                            {
                                msg = ReNewPageImages(tbl + "\\" + mailbox, tbl + "\\" + newMailbox);

                                if (msg != "ReNewed")
                                    return msg;

                                ds.AcceptChanges();
                                msg = "Updated";
                            }
                            else
                            {
                                ds.RejectChanges();
                                msg = "Rejected";
                            }

                            break;
                        }
                    }
                }
                else if (duplicate)
                    msg = "Duplicate Error";
                else
                    msg = "Not Found";

                cnn.Close();
                drr.Close();

                ds.Dispose();
                cmd.Dispose();
                drr.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
                cmd = null;
                drr = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    [WebMethod]
    public string GoogleErase(string mailbox, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            mailbox = mailbox.Trim();

            string tbl = "google";
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

                bool found = false;

                dt = ds.Tables[tbl];

                mailbox = EncDec.Encrypt(mailbox, Base.hashKey);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    if (dr["mailbox"].ToString().Trim() == mailbox)
                    {
                        found = true;
                        dr.Delete();

                        oda.DeleteCommand = ocb.GetDeleteCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            msg = CleanPageImages(tbl + "\\" + mailbox);

                            if (msg != "Cleaned")
                                return msg;

                            ds.AcceptChanges();
                            msg = "Erased";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                if (!found)
                    msg = "Not Found";

                cnn.Close();

                ds.Dispose();
                dt.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();

                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }
        else
            msg = errInvalidLegal;

        return msg;
    }

    #endregion

    #region Layout

    [WebMethod]
    public string LayoutWrite(string layout, string legal)
    {
        string msg = string.Empty;

        if (tLegal == legal.Trim() && isDaysLeft)
        {
            layout = layout.Trim();

            string tbl = "preferencesweb";
            string sqlStr = "SELECT * FROM " + tbl;

            if (msg == "Rejected")
                return msg;

            try
            {
                OleDbConnection cnn = new OleDbConnection(Base.cnnStr);
                OleDbDataAdapter oda = new OleDbDataAdapter(sqlStr, cnn);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                OleDbCommand cmd = new OleDbCommand(sqlStr, cnn);
                cnn.Open();
                OleDbDataReader drr = cmd.ExecuteReader();

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

                    if (dr["tag"].ToString().Trim() == "layout")
                    {
                        dr.BeginEdit();
                        dr["val"] = EncDec.Encrypt(layout, Base.hashKey);
                        dr.EndEdit();

                        oda.UpdateCommand = ocb.GetUpdateCommand();

                        if (oda.Update(ds, tbl) == 1)
                        {
                            ds.AcceptChanges();
                            msg = "OK";
                        }
                        else
                        {
                            ds.RejectChanges();
                            msg = "Rejected";
                        }

                        break;
                    }
                }

                drr.Close();
                cnn.Close();

                cmd.Dispose();
                drr.Dispose();
                ds.Dispose();
                ocb.Dispose();
                oda.Dispose();
                cnn.Dispose();
                dt.Dispose();

                cmd = null;
                drr = null;
                ds = null;
                ocb = null;
                oda = null;
                dr = null;
                dt = null;
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
        }

        return msg;
    }

    #endregion
}

