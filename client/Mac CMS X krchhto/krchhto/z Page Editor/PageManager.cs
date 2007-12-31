using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web.Services.Protocols;

namespace krchhto
{
    public partial class frmPageManager : Form
    {
        #region Global Variables & Properties

        private string _parent = "frmPageEditor";

        private krw.Management wsrv = new krw.Management();

        private TreeNode nodeServer = new TreeNode();
        private string nodeServerNew = string.Empty;
        private TreeNode nodeServerParent = new TreeNode();
        private string nodeServerLang = string.Empty;
        private int nodeServerZIndex = -1;
        private string nodeServerParentPath = string.Empty;
        private TreeNode nodeServerBeside = new TreeNode();

        private string errDuplicateNode = "صفحه اي با نام تعيين شده در سطح جاري قبلا ثبت شده است";
        private string errDuplicateNodeHeader = "صفحه تكراري";
        private string errOverflow = "حداکثر طول مجاز برای هر شاخه ۲۵۵ حرف می باشد";
        private string errOverflowHeader = "سرریز در ساختار درختی";
        private string errInvalidChar = "در نام گذاری از کاراکتر غیر مجاز استفاده نموده اید";
        private string errInvalidCharHeader = "تشخیص کاراکتر غیر مجاز";

        #endregion

        public frmPageManager()
        {
            InitializeComponent();

            SetRootNode(trvMenusPersian, Base.rootTitleFa);
            SetRootNode(trvMenusEnglish, Base.rootTitleEn);
            SetRootNode(trvMenusArabic, Base.rootTitleAr);

            wsrv.NodesAllTreesCompleted += new krw.NodesAllTreesCompletedEventHandler(NodesAllTreesCompleted);
            wsrv.NodesAddCompleted += new krw.NodesAddCompletedEventHandler(NodesAddCompleted);
            wsrv.NodesEditCompleted += new krw.NodesEditCompletedEventHandler(NodesEditCompleted);
            wsrv.NodesEraseCompleted += new krw.NodesEraseCompletedEventHandler(NodesEraseCompleted);
            wsrv.NodesChangeIndexCompleted += new krw.NodesChangeIndexCompletedEventHandler(NodesChangeIndexCompleted);
        }

        #region Setting Default Values

        private void SetRootNode(TreeView trv, string root)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Name = "root";
            rootNode.Text = root;
            trv.Nodes.Add(rootNode);
        }

        #endregion

        #region Correct Contex Menu

        private void CheckStatus(TreeView trv)
        {
            if (trv.SelectedNode.Name == "root")
            {
                if (trv == trvMenusPersian)
                {
                    mItemErasePersian.Enabled = false;
                    mItemRenamePersian.Enabled = false;
                    mItemMoveUpPersian.Enabled = false;
                    mItemMoveDownPersian.Enabled = false;
                    mItemCopyURLPersian.Enabled = false;
                }
                else if (trv == trvMenusEnglish)
                {
                    mItemEraseEnglish.Enabled = false;
                    mItemRenameEnglish.Enabled = false;
                    mItemMoveUpEnglish.Enabled = false;
                    mItemMoveDownEnglish.Enabled = false;
                    mItemCopyURLEnglish.Enabled = false;
                }
                else if (trv == trvMenusArabic)
                {
                    mItemEraseArabic.Enabled = false;
                    mItemRenameArabic.Enabled = false;
                    mItemMoveUpArabic.Enabled = false;
                    mItemMoveDownArabic.Enabled = false;
                    mItemCopyURLArabic.Enabled = false;
                }
            }
            else
            {
                if (trv == trvMenusPersian)
                {
                    mItemErasePersian.Enabled = true;
                    mItemRenamePersian.Enabled = true;
                    mItemCopyURLPersian.Enabled = trv.SelectedNode.Nodes.Count == 0 ? true : false;
                }
                else if (trv == trvMenusEnglish)
                {
                    mItemEraseEnglish.Enabled = true;
                    mItemRenameEnglish.Enabled = true;
                    mItemCopyURLEnglish.Enabled = true;
                    mItemCopyURLEnglish.Enabled = trv.SelectedNode.Nodes.Count == 0 ? true : false;
                }
                else if (trv == trvMenusArabic)
                {
                    mItemEraseArabic.Enabled = true;
                    mItemRenameArabic.Enabled = true;
                    mItemCopyURLArabic.Enabled = true;
                    mItemCopyURLArabic.Enabled = trv.SelectedNode.Nodes.Count == 0 ? true : false;
                }



                if (trv.SelectedNode.Index != 0)
                {
                    if (trv == trvMenusPersian)
                    {
                        mItemMoveUpPersian.Enabled = true;
                    }
                    else if (trv == trvMenusEnglish)
                    {
                        mItemMoveUpEnglish.Enabled = true;
                    }
                    else if (trv == trvMenusArabic)
                    {
                        mItemMoveUpArabic.Enabled = true;
                    }
                }
                else
                {
                    if (trv == trvMenusPersian)
                    {
                        mItemMoveUpPersian.Enabled = false;
                    }
                    else if (trv == trvMenusEnglish)
                    {
                        mItemMoveUpEnglish.Enabled = false;
                    }
                    else if (trv == trvMenusArabic)
                    {
                        mItemMoveUpArabic.Enabled = false;
                    }
                }

                if (trv.SelectedNode.Index + 1 != trv.SelectedNode.Parent.Nodes.Count)
                {
                    if (trv == trvMenusPersian)
                    {
                        mItemMoveDownPersian.Enabled = true;
                    }
                    else if (trv == trvMenusEnglish)
                    {
                        mItemMoveDownEnglish.Enabled = true;
                    }
                    else if (trv == trvMenusArabic)
                    {
                        mItemMoveDownArabic.Enabled = true;
                    }
                }
                else
                {
                    if (trv == trvMenusPersian)
                    {
                        mItemMoveDownPersian.Enabled = false;
                    }
                    else if (trv == trvMenusEnglish)
                    {
                        mItemMoveDownEnglish.Enabled = false;
                    }
                    else if (trv == trvMenusArabic)
                    {
                        mItemMoveDownArabic.Enabled = false;
                    }
                }
            }
        }


        private void ctxNodeManagerPersian_Opening(object sender, CancelEventArgs e)
        {
            CheckStatus(trvMenusPersian);
        }

        private void ctxNodeManagerEnglish_Opening(object sender, CancelEventArgs e)
        {
            CheckStatus(trvMenusEnglish);
        }

        private void ctxNodeManagerArabic_Opening(object sender, CancelEventArgs e)
        {
            CheckStatus(trvMenusArabic);
        }

        private void trvMenusPersian_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvMenusPersian.SelectedNode = e.Node;
            CheckStatus(trvMenusPersian);
        }

        private void trvMenusEnglish_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvMenusEnglish.SelectedNode = e.Node;
            CheckStatus(trvMenusEnglish);
        }

        private void trvMenusArabic_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            trvMenusArabic.SelectedNode = e.Node;
            CheckStatus(trvMenusArabic);
        }

        #endregion

        #region Add

        private void AddNode(TreeView trv, string lang)
        {
            using (frmTinyInputBox frm = new frmTinyInputBox())
            {
                frm.title = "افزودن صفحه";
                while (true)
                {
                    frm.ShowDialog(this);

                    if (frm.node != string.Empty)
                    {
                        TreeNode node = new TreeNode();
                        node.Name = frm.node;
                        node.Text = frm.node;

                        bool found = false;

                        if (frm.node.Contains("\\") || frm.node.Contains("/"))
                        {
                            MessageBox.Show(errInvalidChar, errInvalidCharHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            continue;
                        }

                        if ((trv.SelectedNode.FullPath + "\\" + node.Name).Length > 255)
                        {
                            MessageBox.Show(errOverflow, errOverflowHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            continue;
                        }

                        foreach (TreeNode tn in trv.SelectedNode.Nodes)
                        {
                            if (tn.Name == node.Name)
                            {
                                MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                found = true;
                                break;
                            }
                        }

                        if (found)
                            continue;

                        if ((trv.SelectedNode.FullPath + "\\" + node.Name).Length > 255)
                        {
                            MessageBox.Show(errOverflow, errOverflowHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                            continue;
                        }

                        nodeServer = node;
                        nodeServerParent = trv.SelectedNode;
                        nodeServerLang = lang;
                        nodeServerZIndex = trv.SelectedNode.Nodes.Count;
                        SendRequest("NodesAdd");
                        break;
                    }
                    else
                        break;
                }
            }
        }

        private void mItemInsertPersian_Click(object sender, EventArgs e)
        {
            AddNode(trvMenusPersian, "pagesfa");
        }

        private void mItemInsertEnglish_Click(object sender, EventArgs e)
        {
            AddNode(trvMenusEnglish, "pagesen");
        }

        private void mItemInsertArabic_Click(object sender, EventArgs e)
        {
            AddNode(trvMenusArabic, "pagesar");
        }

        #endregion

        #region Edit

        private void EditNode(TreeView trv, string lang)
        {
            if (trv.SelectedNode.Name != "root")
            {
                using (frmTinyInputBox frm = new frmTinyInputBox())
                {
                    frm.title = "ويرايش نام صفحه";
                    while (true)
                    {
                        frm.node = trv.SelectedNode.Text;
                        frm.ShowDialog(this);

                        if (frm.node != string.Empty)
                        {
                            DialogResult result = MessageBox.Show("آيا مايل به تغيير نام صفحه موردنظر مي باشيد", "ويرايش نام صفحه", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);

                            if (result == DialogResult.OK)
                            {
                                if (frm.node.Contains("\\") || frm.node.Contains("/"))
                                {
                                    MessageBox.Show(errInvalidChar, errInvalidCharHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                    continue;
                                }

                                bool found = false;

                                foreach (TreeNode tn in trv.SelectedNode.Parent.Nodes)
                                {
                                    if (tn.Name == frm.node && frm.node != trv.SelectedNode.Name)
                                    {
                                        MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                        found = true;
                                        break;
                                    }
                                }

                                if (found)
                                    continue;

                                if ((trv.SelectedNode.Parent.FullPath + "\\" + frm.node).Length > 255)
                                {
                                    MessageBox.Show(errOverflow, errOverflowHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                                    continue;
                                }

                                nodeServer = trv.SelectedNode;
                                nodeServerParent = trv.SelectedNode.Parent;
                                nodeServerLang = lang;
                                nodeServerNew = frm.node;
                                SendRequest("NodesEdit");
                            }

                            break;
                        }
                        else
                            break;
                    }
                }
            }
        }

        private void mItemRenamePersian_Click(object sender, EventArgs e)
        {
            EditNode(trvMenusPersian, "pagesfa");
        }

        private void mItemRenameEnglish_Click(object sender, EventArgs e)
        {
            EditNode(trvMenusEnglish, "pagesen");
        }

        private void mItemRenameArabic_Click(object sender, EventArgs e)
        {
            EditNode(trvMenusArabic, "pagesar");
        }

        #endregion

        #region Remove

        private void RemoveNode(TreeView trv, string lang)
        {
            if (trv.SelectedNode.Name != "root")
            {
                DialogResult result = MessageBox.Show("آيا مايل به حذف صفحه موردنظر با تمامي اطلاعات آن مي باشيد\n\nدقت نمائيد كه پس از حذف هيچگونه امكان بازگشتي وجود ندارد", "حذف صفحه", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                if (result == DialogResult.OK)
                {
                    nodeServer = trv.SelectedNode;
                    nodeServerParent = trv.SelectedNode.Parent;
                    nodeServerLang = lang;
                    SendRequest("NodesErase");
                }
            }
        }


        private void mItemErasePersian_Click(object sender, EventArgs e)
        {
            RemoveNode(trvMenusPersian, "pagesfa");
        }

        private void mItemEraseEnglish_Click(object sender, EventArgs e)
        {
            RemoveNode(trvMenusEnglish, "pagesen");
        }

        private void mItemEraseArabic_Click(object sender, EventArgs e)
        {
            RemoveNode(trvMenusArabic, "pagesar");
        }
        
        #endregion

        #region UP / Down

        private void MoveUpNode(TreeView trv, string lang)
        {
            if (trv.SelectedNode.Name != "root")
            {
                if (trv.SelectedNode.Index != 0)
                {
                    /*TreeNode parent = trv.SelectedNode.Parent;
                    TreeNode node = trv.SelectedNode;
                    parent.Nodes.Remove(node);
                    parent.Nodes.Insert(node.Index - 1, node);

                    trv.SelectedNode = node;*/

                    nodeServer = trv.SelectedNode;
                    nodeServerBeside = trv.SelectedNode.Parent.Nodes[trv.SelectedNode.Index - 1];
                    nodeServerLang = lang;

                    SendRequest("NodesChangeIndex");
                }
            }
        }

        private void MoveDownNode(TreeView trv, string lang)
        {
            if (trv.SelectedNode.Name != "root")
            {
                if (trv.SelectedNode.Index + 1 != trv.SelectedNode.Parent.Nodes.Count)
                {
                    /*TreeNode parent = trv.SelectedNode.Parent;
                    TreeNode node = trv.SelectedNode;
                    parent.Nodes.Remove(node);
                    parent.Nodes.Insert(node.Index + 1, node);

                    trv.SelectedNode = node;*/

                    nodeServer = trv.SelectedNode;
                    nodeServerBeside = trv.SelectedNode.Parent.Nodes[trv.SelectedNode.Index + 1];
                    nodeServerLang = lang;

                    SendRequest("NodesChangeIndex");
                }
            }
        }

        private void mItemMoveUpPersian_Click(object sender, EventArgs e)
        {
            MoveUpNode(trvMenusPersian, "pagesfa");
        }

        private void mItemMoveUpEnglish_Click(object sender, EventArgs e)
        {
            MoveUpNode(trvMenusEnglish, "pagesen");
        }

        private void mItemMoveUpArabic_Click(object sender, EventArgs e)
        {
            MoveUpNode(trvMenusArabic, "pagesar");
        }

        private void mItemMoveDownPersian_Click(object sender, EventArgs e)
        {
            MoveDownNode(trvMenusPersian, "pagesfa");
        }

        private void mItemMoveDownEnglish_Click(object sender, EventArgs e)
        {
            MoveDownNode(trvMenusEnglish, "pagesen");
        }

        private void mItemMoveDownArabic_Click(object sender, EventArgs e)
        {
            MoveDownNode(trvMenusArabic, "pagesar");
        }

        #endregion

        #region Copy URL

        private void CopyURL(TreeView trv, string lang)
        {
            Base.CopyURL("fetchpage", "page", trv.SelectedNode.FullPath.Replace("\\", "/"), lang);
        }

        private void mItemCopyURLPersian_Click(object sender, EventArgs e)
        {
            CopyURL(trvMenusPersian, "fa");
        }

        private void mItemCopyURLEnglish_Click(object sender, EventArgs e)
        {
            CopyURL(trvMenusEnglish, "en");
        }

        private void mItemCopyURLArabic_Click(object sender, EventArgs e)
        {
            CopyURL(trvMenusArabic, "ar");
        }

        #endregion

        #region Form Operations

        private void frmPageManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Base.CloseDialog(_parent);
        }

        private void frmPageManager_Load(object sender, EventArgs e)
        {
            Base.InitializeDialog(_parent, this);
        }

        private void frmPageManager_Shown(object sender, EventArgs e)
        {
            SendRequest("NodesAllTrees");
        }

        private void DoExit()
        {
            frmMain frm = new frmMain();
            frm.DoExit();
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
                    case "NodesAdd":
                        wsrv.NodesAddAsync(nodeServer.Name, nodeServerParent.Name, nodeServerParent.FullPath + "\\" + nodeServer.Name, nodeServerZIndex, nodeServerLang, Base.legal);
                        break;
                    case "NodesEdit":
                        wsrv.NodesEditAsync(nodeServer.Name, nodeServerNew, nodeServer.FullPath, nodeServerParent.FullPath + "\\" + nodeServerNew, nodeServerLang, Base.legal);
                        break;
                    case "NodesErase":
                        wsrv.NodesEraseAsync(nodeServer.FullPath, nodeServerParent.FullPath, nodeServerLang, Base.legal);
                        break;
                    case "NodesChangeIndex":
                        wsrv.NodesChangeIndexAsync(nodeServer.FullPath, nodeServerBeside.Index, nodeServerBeside.FullPath, nodeServer.Index, nodeServerLang, Base.legal);
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

        #endregion

        #region AsyncCalls Response

        private void NodesAllTreesCompleted(Object sender, krw.NodesAllTreesCompletedEventArgs Completed)
        {
            try
            {
                DataSet ds = Completed.Result;

                SetNodes(trvMenusPersian.Nodes["root"], ds.Tables["pagesfa"]);
                SetNodes(trvMenusEnglish.Nodes["root"], ds.Tables["pagesen"]);
                SetNodes(trvMenusArabic.Nodes["root"], ds.Tables["pagesar"]);

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

        private void NodesAddCompleted(Object sender, krw.NodesAddCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Added":
                        nodeServerParent.Nodes.Add(nodeServer);
                        nodeServerParent.ExpandAll();
                        Base.Loading(this, false);
                        break;
                    case "Already Exist":
                        MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NodesAdd", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NodesAdd", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NodesAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NodesAdd", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NodesEditCompleted(Object sender, krw.NodesEditCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Updated":
                        nodeServer.Text = nodeServerNew;
                        nodeServer.Name = nodeServerNew;

                        nodeServer.ExpandAll();

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("صفحه ای با نام موردنظر جهت ویرایش یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case "Duplicate Error":
                        MessageBox.Show(errDuplicateNode, errDuplicateNodeHeader, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NodesEdit", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NodesEdit", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NodesEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NodesEdit", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NodesEraseCompleted(Object sender, krw.NodesEraseCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "Erased":
                        nodeServer.Remove();
                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("صفحه ای با نام موردنظر جهت حذف یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NodesErase", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NodesErase", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NodesErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NodesErase", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        private void NodesChangeIndexCompleted(Object sender, krw.NodesChangeIndexCompletedEventArgs Completed)
        {
            try
            {
                string result = Completed.Result;
                switch (result)
                {
                    case "ReIndexed":
                        TreeView trv = new TreeView();

                        switch (nodeServerLang)
                        {
                            case "pagesfa":
                                trv = trvMenusPersian;
                                break;
                            case "pagesen":
                                trv = trvMenusEnglish;
                                break;
                            case "pagesar":
                                trv = trvMenusArabic;
                                break;
                            default:
                                break;
                        }

                        int index = nodeServerBeside.Index;

                        TreeNode parent = trv.SelectedNode.Parent;
                        TreeNode node = trv.SelectedNode;
                        parent.Nodes.Remove(node);
                        parent.Nodes.Insert(index, node);
                        trv.SelectedNode = node;

                        Base.Loading(this, false);
                        break;
                    case "Not Found":
                        MessageBox.Show("صفحه ای با نام موردنظر جهت تغییر موقعیت یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        Base.Loading(this, false);
                        break;
                    case Base.srvMsgDSReject:
                        TryRequest("NodesChangeIndex", Base.errDSReject);
                        break;
                    case Base.srvMsgInvalidLegal:
                        MessageBox.Show(Base.errPrefix + result, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DoExit();
                        break;
                    default:
                        TryRequest("NodesChangeIndex", result);
                        break;
                }
            }
            catch (SoapException ex)
            {
                TryRequest("NodesChangeIndex", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                TryRequest("NodesChangeIndex", ex.Message + "\n\n" + ex.InnerException.Message);
            }
            finally
            {
            }
        }

        #endregion

        #region Nodes

        private void GetNodes(TreeNode node, DataTable dt)
        {
            TreeNodeCollection nodes = node.Nodes;
            DataRow dr;

            foreach (TreeNode n in nodes)
            {
                dr = dt.NewRow();
                dr["pg"] = n.Name;
                dr["parent"] = n.Parent.Name;
                dr["fullpath"] = n.FullPath;
                dt.Rows.Add(dr);
                GetNodes(n, dt);
            }
        }

        private void SetNodes(TreeNode node, DataTable dt)
        {
            TreeNodeCollection nodes = node.Nodes;
            DataRow dr;

            dt.DefaultView.Sort = "[fullpath] asc";

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
                    node.ExpandAll();
                    SetNodes(tn, dt);
                }
            }
        }
        
        #endregion
    }
}