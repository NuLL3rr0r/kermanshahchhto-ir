using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;
using System.IO;

namespace krchhto
{
    public partial class frmPageEditor : Form
    {
        #region Global Variables & Properties

        private krw.Management wsrv = new krw.Management();
        
        private bool hasChanges = false;

        string wPage = string.Empty;
        string lang = string.Empty;

        string wList = string.Empty;

        private DataTable cList = new DataTable();

        #endregion

        public frmPageEditor()
        {
            InitializeComponent();

            wsrv.NodesAllTreesCompleted += new krw.NodesAllTreesCompletedEventHandler(NodesAllTreesCompleted);
            wsrv.ServerPageGetCompleted += new krw.ServerPageGetCompletedEventHandler(ServerPageGetCompleted);
            wsrv.ServerPageSetCompleted += new krw.ServerPageSetCompletedEventHandler(ServerPageSetCompleted);
            wsrv.ContactListCompleted += new krw.ContactListCompletedEventHandler(ContactListCompleted);
            wsrv.ContactListCatchChangesCompleted += new krw.ContactListCatchChangesCompletedEventHandler(ContactListCatchChangesCompleted);
        }

        #region Safe Exit

        private void EndSession()
        {
            this.Dispose();
        }

        private void Terminate()
        {
            if (CanTerminate())
            {
                EndSession();
            }
        }

        private void Terminate(FormClosingEventArgs e)
        {
            if (!CanTerminate())
                e.Cancel = true;
            else
                EndSession();
        }

        private bool CanTerminate()
        {
            bool can = true;

            if (hasChanges)
            {
                if (MessageBox.Show(Base.warCancelChangesThenExit, Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    can = false;
                }
            }

            return can;
        }

        private bool StayForChanges()
        {
            if (hasChanges)
            {
                if (MessageBox.Show(Base.warCancelChanges, Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign) == DialogResult.Cancel)
                {
                    return true;
                }
                else
                {
                    hasChanges = false;
                }
            }

            return false;
        }

        #endregion

        #region Form Operations

        private void frmPageEditor_Load(object sender, EventArgs e)
        {
            SetEditorMnuState(false);
        }

        private void frmPageEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Terminate(e);
        }

        private void frmPageEditor_Shown(object sender, EventArgs e)
        {
            RegenMenues();
        }

        private void DoExit()
        {
            frmMain frm = new frmMain();
            frm.DoExit();
        }

        private void frmPageEditor_EnabledChanged(object sender, EventArgs e)
        {
            if (Base.regenPageEditorMenues)
            {
                if (this.Enabled)
                {
                    RegenMenues();
                }
            }
        }

        #endregion

        #region Page Editor Section

        private void mItemPagesManagement_Click(object sender, EventArgs e)
        {
            Base.OpenDialogPageEditor(this, new frmPageManager(), true);
        }

        private void editor_Tick()
        {
            mItemUndo.Enabled = editor.CanUndo();
            mItemRedo.Enabled = editor.CanRedo();
            mItemCut.Enabled = editor.CanCut();
            mItemCopy.Enabled = editor.CanCopy();
            mItemPaste.Enabled = editor.CanPaste();
            if (editor.CanUndo())
                hasChanges = true;
            else
                hasChanges = false;
        }

        public void SetEditorMnuState(bool state)
        {
            mItemClose.Enabled = state;
            mItemSave.Enabled = state;
            mItemPrint.Enabled = state;
            mItemEdit.Enabled = state;
            mItemView.Enabled = state;
            mItemInsert.Enabled = state;
            editor.Enabled2 = state;
            mItemPagesManagement.Enabled = !state;
        }

        private void DocClose()
        {
            editor.Document.Write(string.Empty);
            editor.DocumentText = null;
            editor.Tick += null;
            SetEditorMnuState(false);
        }

        private void mItemSave_Click(object sender, EventArgs e)
        {
            SendRequest("ServerPageSet");
        }

        private void mItemClose_Click(object sender, EventArgs e)
        {
            if (!StayForChanges())
            {
                DocClose();
            }
        }

        private void mItemPrint_Click(object sender, EventArgs e)
        {
            editor.Print();
        }

        private void mItemExit_Click(object sender, EventArgs e)
        {
            Terminate();
        }

        private void mItemUndo_Click(object sender, EventArgs e)
        {
            editor.Undo();
        }

        private void mItemRedo_Click(object sender, EventArgs e)
        {
            editor.Redo();
        }

        private void mItemCut_Click(object sender, EventArgs e)
        {
            editor.Cut();
        }

        private void mItemCopy_Click(object sender, EventArgs e)
        {
            editor.Copy();
        }

        private void mItemPaste_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void mItemSelectAll_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void mItemFind_Click(object sender, EventArgs e)
        {
            using (SearchDialog dlg = new SearchDialog(editor))
            {
                dlg.ShowDialog(this);
            }
        }

        private void mItemTextView_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyText);
        }

        private void mItemHtmlView_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, editor.BodyHtml);
        }

        private void mItemInsertBreak_Click(object sender, EventArgs e)
        {
            editor.InsertBreak();
        }

        private void mItemInsertHTML_Click(object sender, EventArgs e)
        {
            using (TextInsertForm form = new TextInsertForm(editor.BodyHtml))
            {
                form.ShowDialog(this);
                if (form.Accepted)
                {
                    editor.BodyHtml = form.HTML;
                }
            }
        }

        private void mItemInsertParagraph_Click(object sender, EventArgs e)
        {
            editor.InsertParagraph();
        }

        private void ServerPageGet(object sender, EventArgs e)
        {

            if (!StayForChanges())
            {
                DocClose();

                ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
                string tag = (string)mnu.Tag;
                int pos = tag.IndexOf("==>");
                lang = tag.Substring(0, pos);
                wPage = tag.Substring(pos + 3);
                string start = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"fa\" xml:lang=\"fa\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title></title></head><style type=\"text/css\">html, body {direction: rtl; text-align: justify; font-family: Tahoma; line-height: 33px;}</style><body>";
                string stop = "</body></html>";
                editor.Document.Write(string.Empty);
                editor.DocumentText = start + "" + stop;
                editor.Tick += new Editor.TickDelegate(editor_Tick);
                SetEditorMnuState(true);
                mItemSave.Enabled = true;

                return;
            }
        }

        private void GetContactList(object sender, EventArgs e)
        {
            if (!StayForChanges())
            {
                DocClose();

                ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
                wList = (string)mnu.Tag;

                SendRequest("ContactList");
            }
        }

        private void RootMessage(object sender, EventArgs e)
        {
            MessageBox.Show("کاربر گرامی منوهای اصلی قادر به نگهداری اطلاعات نمی باشند\n\nلطفا برای آن زیر منو ایجاد نمائید", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        #endregion

        #region AsyncCalls

        private void TryRequest(string req, string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Base.errServer);
            sb.Append("\n\n\n");
            sb.Append(err);
            DialogResult result = MessageBox.Show(sb.ToString(), Base.errServerHeader, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            switch (result)
            {
                case DialogResult.Retry:
                    SendRequest(req);
                    break;
                case DialogResult.Cancel:
                    if (req == "ContactListCatchChanges")
                    {
                        using (frmContactList frm = new frmContactList())
                        {
                            frm.cList = cList;
                            cList = new DataTable();
                            frm.retryMode = true;
                            frm.ShowDialog(this);

                            if (frm.hasChanged)
                            {
                                cList = frm.cList;
                                SendRequest("ContactListCatchChanges");
                            }
                            else
                                Base.Loading(this, false);
                        }
                        return;
                    }
                    Base.Loading(this, false);
                    break;
                default:
                    break;
            }
        }

        private void SendRequest(string req)
        {
            try
            {
                switch (req)
                {
                    case "NodesAllTrees":
                        wsrv.NodesAllTreesAsync(Base.legal);
                        break;
                    case "ServerPageGet":
                        wsrv.ServerPageGetAsync(wPage, lang, Base.legal);
                        break;
                    case "ServerPageSet":
                        if (!SendRequestServerPageSet())
                            return;
                        break;
                    case "ContactList":
                        wsrv.ContactListAsync(wList, Base.legal);
                        break;
                    case "ContactListCatchChanges":
                        wsrv.ContactListCatchChangesAsync(wList, cList, Base.legal);
                        break;
                    default:
                        break;
                }
                Base.Loading(this, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
            }
            finally
            {
            }
        }

        private bool SendRequestServerPageSet()
        {
            try
            {
                string pg = editor.BodyHtml.Trim();
                string[] edImages = { };
                string[] ext = { };
                byte[][] buffer = { };
                string[] ph = { };

                string src = "src=\"";
                string edFilePath = string.Empty;

                int pos1 = -1;
                int pos2 = 0;

                //flvObject Section

                string flvobjectStart = "flvobject_";
                string flvObectStop = "_flvobject";

                if (pg.ToLower().Contains(flvobjectStart))
                {

                    int p1 = -1;
                    int p2 = -1;

                    string flvObjectId = string.Empty;

                    while (true)
                    {
                        pos1 = pg.ToLower().IndexOf("<object");
                        if (pos1 == -1)
                            break;
                        pos2 = pg.ToLower().IndexOf("</object>", pos1) + "</object>".Length;
                        if (pos2 == -1)
                            break;

                        string swf = pg.Substring(pos1, pos2 - pos1);

                        p1 = swf.IndexOf(flvobjectStart) + flvobjectStart.Length;
                        p2 = swf.IndexOf(flvObectStop);
                        if (p1 > -1 && p2 > -1 && p2 > p1)
                        {
                            flvObjectId = swf.Substring(p1, p2 - p1);
                            pg = pg.Remove(pos1, pos2 - pos1);
                            pg = pg.Insert(pos1, string.Format(Base.flvObjectDiv, flvObjectId));
                        }
                    }
                }

                //end flvObject Section

                pos1 = -1;
                pos2 = 0;

                while (true)
                {
                    if (pos2 > pg.Length)
                        break;

                    pos1 = pg.ToLower().IndexOf(src, pos2) + src.Length;

                    if (pos1 != src.Length - 1)
                    {
                        pos2 = pg.ToLower().IndexOf("\"", pos1);
                        edFilePath = pg.Substring(pos1, pos2 - pos1);

                        pos2 = pos1 + 1;

                        if (edFilePath.IndexOf(Base.url) == -1)
                        {
                            if (edFilePath.IndexOf("http://") != -1)
                                continue;

                            if (edFilePath.Substring(0, 1) != "{")
                            {
                                int len = ph.Length;
                                Array.Resize(ref ph, len + 1);
                                Array.Resize(ref ext, len + 1);
                                Array.Resize(ref buffer, len + 1);

                                using (FileStream fs = new FileStream(edFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                                {
                                    int edFileSize = (int)new FileInfo(edFilePath).Length;
                                    ext[len] = edFilePath.Substring(edFilePath.LastIndexOf(".")).ToLower().Trim();
                                    buffer[len] = new byte[edFileSize];
                                    fs.Read(buffer[len], 0, edFileSize);
                                    fs.Close();
                                    ph[len] = String.Format("{{PlaceHolder/{0}}}", len);
                                }

                                pg = pg.Replace(edFilePath, String.Format("{{PlaceHolder/{0}}}", len));
                            }
                        }
                        else
                        {
                            pg = pg.Remove(pos1, Base.url.Length);
                        }
                    }
                    else
                        break;
                }

                pg = pg.Replace("about:blank", "");
                pg = pg.Replace("##", "#");
                pg = pg.Replace("&amp;", "&");


                wsrv.ServerPageSetAsync(wPage, Zipper.Compress(pg), buffer, ext, ph, lang, Base.legal);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
                return false;
            }
            finally
            {
            }
        }

        #endregion

        #region AsyncCalls Response

        private void NodesAllTreesCompleted(Object sender, krw.NodesAllTreesCompletedEventArgs Completed)
        {
            try
            {
                DataSet ds = Completed.Result;

                RegenMenu(mItemOpenPersian, ds.Tables["pagesfa"], Base.rootTitleFa);
                RegenMenu(mItemOpenEnglish, ds.Tables["pagesen"], Base.rootTitleEn);
                RegenMenu(mItemOpenArabic, ds.Tables["pagesar"], Base.rootTitleAr);

                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("NodesAllTrees", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NodesAllTrees", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ServerPageGetCompleted(Object sender, krw.ServerPageGetCompletedEventArgs Completed)
        {
            try
            {
                string result = Zipper.DecompressToStrng(Completed.Result);

                switch (result.Substring(0, Base.srvMsgLen))
                {
                    case Base.srvMsgSuccess:
                        result = result.Substring(Base.srvMsgLen);

                        int pos1 = -1;
                        int pos2 = 0;
                        string src = "src=\"";

                        while (true)
                        {
                            pos1 = result.IndexOf(src, pos2) + src.Length;
                            if (pos1 != src.Length - 1)
                            {
                                pos2 = result.IndexOf("\"", pos1);

                                if (result.IndexOf("http://", pos1, pos2 - pos1) != -1)
                                    continue;

                                result = result.Insert(pos1, Base.url);
                            }
                            else
                                break;
                        }

                        if (result == string.Empty)
                            result = "<p>&nbsp;</p>";


                        //flvObect Section

                        pos1 = -1;
                        pos2 = 0;
                        
                        if (result.ToLower().Contains("<div"))
                        {
                            int p1 = -1;
                            int p2 = -1;

                            string flvObjectId = string.Empty;

                            while (true)
                            {
                                pos1 = result.ToLower().IndexOf("<div");
                                if (pos1 == -1)
                                    break;
                                pos2 = result.ToLower().IndexOf("</div>", pos1) + "</div>".Length;
                                if (pos2 == -1)
                                    break;

                                string swf = result.Substring(pos1, pos2 - pos1);

                                if (swf.Contains(".flv"))
                                {
                                    p1 = swf.IndexOf("id=\"") + "id=\"".Length;
                                    p2 = swf.IndexOf("\"", p1);

                                    flvObjectId = swf.Substring(p1, p2 - p1);

                                    result = result.Remove(pos1, pos2 - pos1);
                                    result = result.Insert(pos1, string.Format(Base.flvObject, flvObjectId));
                                }
                            }
                        }
                        
                        //end flvObect Section


                        string start = "<!DOCTYPE html PUBLIC \" -//W3C//DTD XHTML 1.1//EN\" \"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" lang=\"fa\" xml:lang=\"fa\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /><title></title></head><style type=\"text/css\">html, body {direction: rtl; text-align: justify; font-family: Tahoma; line-height: 33px;}</style><body>";
                        string stop = "</body></html>";
                        editor.Document.Write(string.Empty);
                        editor.DocumentText = start + result + stop;
                        editor.Tick += new Editor.TickDelegate(editor_Tick);

                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgErr:
                        //An erorr ocurred
                        result = result.Substring(Base.srvMsgLen);
                        if (result == Base.srvMsgInvalidLegal)
                        {
                            MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            DoExit();
                        }
                        else
                        {
                            TryRequest("ServerPageGet", result);
                            return;
                        }
                        break;
                    default:
                        break;
                }
                SetEditorMnuState(true);
            }
            catch (SoapException ex)
            {
                TryRequest("ServerPageGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ServerPageGet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ServerPageSetCompleted(Object sender, krw.ServerPageSetCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;

                switch (result)
                {
                    case "Saved":
                        hasChanges = false;
                        DocClose();
                        MessageBox.Show("تغييرات با موفقيت اعمال شد", "ويرايشگر صفحات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        MessageBox.Show(Base.errPrefix + Base.errDSReject, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("ServerPageSet", result);
                        break;
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(Base.errPrefix + ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Base.Loading(this, false);
            }
            catch (SoapException ex)
            {
                TryRequest("ServerPageSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ServerPageSet", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ContactListCompleted(Object sender, krw.ContactListCompletedEventArgs Completed)
        {
            try
            {
                DataTable result = Completed.Result;

                using (frmContactList frm = new frmContactList())
                {
                    frm.cList = result;
                    frm.ShowDialog(this);

                    if (frm.hasChanged)
                    {
                        cList = frm.cList;
                        SendRequest("ContactListCatchChanges");
                    }
                    else
                        Base.Loading(this, false);
                }
            }
            catch (SoapException ex)
            {
                TryRequest("ContactList", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ContactList", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void ContactListCatchChangesCompleted(Object sender, krw.ContactListCatchChangesCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Catched":
                        MessageBox.Show("ليست تماس ها با موفقيت ذخيره شد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cList = new DataTable();
                        Base.Loading(this, false);
                        break;
                    case "Can't Clean Table":
                        TryRequest("ContactListCatchChanges", "در حال حاضر سرور قادر به ذخيره تغييرات مربوط به ليست تماس ها نمي باشد");
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("ContactListCatchChanges", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("ContactListCatchChanges", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("ContactListCatchChanges", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("ContactListCatchChanges", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion

        #region Draw Menues

        private void RegenMenues()
        {
            SendRequest("NodesAllTrees");
        }

        private void ClearMenues(ToolStripMenuItem menu)
        {
            for (int i = menu.DropDownItems.Count - 4; i > 0; i--)
                menu.DropDownItems.RemoveAt(i);
        }

        private void RegenMenu(ToolStripMenuItem menu, DataTable dt, string rootString)
        {
            ClearMenues(menu);
            TreeView trv = new TreeView();
            TreeNode root = new TreeNode(rootString);
            root.Name = "root";
            trv.Nodes.Add(root);
            DrawMenues(menu, trv.Nodes["root"], dt, 1);
            SetMenuEvents(menu, dt.TableName);
        }

        private void DrawMenues(ToolStripMenuItem mItem, TreeNode node, DataTable dt, int rootIndex)
        {
            TreeNodeCollection nodes = node.Nodes;
            DataRow dr;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                string name = dr["pg"].ToString().Trim();

                if (dr["parent"].ToString().Trim() == node.Name && dr["fullpath"].ToString().Trim() == node.FullPath + "\\" + name)
                {
                    TreeNode tn = new TreeNode();
                    tn.Name = name;
                    tn.Text = name;
                    nodes.Add(tn);

                    ToolStripMenuItem newItem = new ToolStripMenuItem(name);

                    if (dr["parent"].ToString().Trim() != "root")
                    {
                        mItem.DropDownItems.Add(newItem);
                        newItem.Tag = "{lang}==>" + dr["fullpath"].ToString().Trim();
                    }
                    else
                    {
                        mItem.DropDownItems.Insert(rootIndex, newItem);
                        ++rootIndex;
                        newItem.Tag = "root";
                    }

                    DrawMenues(newItem, tn, dt, rootIndex);
                }
            }
        }

        private void SetMenuEvents(ToolStripMenuItem mItem, string lang)
        {
            ToolStripItemCollection menues = mItem.DropDownItems;

            foreach (ToolStripMenuItem m in menues)
            {
                string tag = ((string)m.Tag);
                if (m.DropDownItems.Count < 1 && tag.Contains("{lang}"))
                {
                    m.Tag = tag.Replace("{lang}", lang);
                    m.Click += new System.EventHandler(this.ServerPageGet);
                }
                else if (m.DropDownItems.Count < 1 && tag.Contains("root"))
                {
                    m.Click += new System.EventHandler(this.RootMessage);
                }

                SetMenuEvents(m, lang);
            }
        }

        #endregion
    }
}
