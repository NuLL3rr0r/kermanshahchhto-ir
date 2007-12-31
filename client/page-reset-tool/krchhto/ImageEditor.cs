using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace krchhto
{
    public partial class frmImageEditor : Form
    {
        #region Global Variables & Properties


        #endregion

        public frmImageEditor()
        {
            InitializeComponent();

            cmbFormats.Items.AddRange(new string[] { ".jpg", ".png", ".gif" });
            cmbFormats.SelectedIndex = 0;
        }

        #region Form Operations

        private void frmImageEditor_Load(object sender, EventArgs e)
        {

        }

        private void frmImageEditor_Shown(object sender, EventArgs e)
        {
            btnBrowseSource.Focus();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //this.Close();
            this.Dispose();
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            fbd.ShowNewFolderButton = false;
            DialogResult res = fbd.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                txtPathSource.Enabled = true;
                txtPathSource.Text = fbd.SelectedPath + (fbd.SelectedPath.EndsWith("\\") ? string.Empty : "\\");

                gbxTarget.Enabled = true;
            }
        }

        private void btnBrowseTarget_Click(object sender, EventArgs e)
        {
            fbd.ShowNewFolderButton = true;
            DialogResult res = fbd.ShowDialog(this);

            if (res == DialogResult.OK)
            {
                string path = fbd.SelectedPath + (fbd.SelectedPath.EndsWith("\\") ? string.Empty : "\\");

                if (!path.Contains(txtPathSource.Text))
                {
                    txtPathTarget.Text = path;
                    txtPathTarget.Enabled = true;

                    gbxOptions.Enabled = true;
                    btnConvert.Enabled = true;
                }
                else
                {
                    MessageBox.Show("لطفا پوشه ای را در خارج از مسیر مبدا انتخاب نمائید", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                    btnBrowseTarget_Click(sender, e);
                }
            }
        }

        private void chkChangeSize_CheckedChanged(object sender, EventArgs e)
        {
            nudHeight.Enabled = chkChangeSize.Checked;
            nudWidth.Enabled = chkChangeSize.Checked;
            rdbPercent.Enabled = chkChangeSize.Checked;
            rdbPixel.Enabled = chkChangeSize.Checked;
        }

        private void rdbPixel_CheckedChanged(object sender, EventArgs e)
        {
            nudWidth.Minimum = 32;
            nudWidth.Maximum = 4096;
            nudWidth.Increment = 8;
            nudWidth.Value = 800;
            nudHeight.Minimum = 32;
            nudHeight.Maximum = 4096;
            nudHeight.Increment = 8;
            nudHeight.Value = 600;
        }

        private void rdbPercent_CheckedChanged(object sender, EventArgs e)
        {
            nudWidth.Minimum = 1;
            nudWidth.Maximum = 1000;
            nudWidth.Increment = 5;
            nudWidth.Value = 100;
            nudHeight.Minimum = 1;
            nudHeight.Maximum = 1000;
            nudHeight.Increment = 5;
            nudHeight.Value = 100;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertPhotos();
        }

        private void nudWidth_Enter(object sender, EventArgs e)
        {
            nudWidth.Select(0, nudWidth.Value.ToString().Length);
        }

        private void nudHeight_Enter(object sender, EventArgs e)
        {
            nudHeight.Select(0, nudHeight.Value.ToString().Length);
        }

        #endregion

        #region Convert Images

        private bool InitializePaths()
        {
            try
            {
                bool hasError = false;
                string errMessage = string.Empty;

                if (!Directory.Exists(txtPathSource.Text))
                {
                    hasError = true;
                    errMessage = "پوشه مبدا وجود ندارد";
                }
                else if (!Directory.Exists(txtPathTarget.Text))
                {
                    hasError = true;
                    errMessage = "پوشه مقصد وجود ندارد";
                }
                else if (Directory.GetFiles(txtPathSource.Text).Length <= 0)
                {
                    hasError = true;
                    errMessage = "در پوشه مبدا هیچگونه فایلی یافت نشد";
                }

                if (hasError)
                {
                    MessageBox.Show(errMessage, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                    return false;
                }

                if (Directory.GetFiles(txtPathTarget.Text).Length > 0 || Directory.GetDirectories(txtPathTarget.Text).Length > 0)
                {
                    DialogResult res = MessageBox.Show("در پوشه مقصد فایل ها و یا پوشه هائی وجود دارد\nدر صورت تداخل نام اطلاعات شما رو نویسی می شوند\n\nآیا مایل به ادامه عملیات می باشید", Base.msgTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (res == DialogResult.OK)
                        return true;
                    else
                        return false;
                }

                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                return false;
            }
            finally
            {
            }
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
                case ".gif":
                    format = ImageFormat.Gif;
                    break;
                default:
                    format = ImageFormat.Jpeg;
                    break;
            }

            return format;
        }

        private byte[] ConvertImage(byte[] buffer, ImageFormat format)
        {
            int w = -1;
            int h = -1;

            MemoryStream msOriginal = new MemoryStream(buffer);
            Image imageOriginal = new Bitmap(msOriginal);

            if (chkChangeSize.Checked && rdbPixel.Checked)
            {
                w = (int)nudWidth.Value;
                h = (int)nudHeight.Value;
            }
            else if (chkChangeSize.Checked && rdbPercent.Checked)
            {
                w = (imageOriginal.Width * (int)nudWidth.Value) / 100;
                h = (imageOriginal.Height * (int)nudHeight.Value) / 100;
            }
            else if (!chkChangeSize.Checked)
            {
                w = imageOriginal.Width;
                h = imageOriginal.Height;
            }

            Image imageConverted = imageOriginal.GetThumbnailImage(w, h, null, new IntPtr());
            MemoryStream msConverted = new MemoryStream();

            imageConverted.Save(msConverted, format);

            buffer = msConverted.ToArray();

            msOriginal.Dispose();
            msConverted.Dispose();
            imageOriginal.Dispose();
            imageConverted.Dispose();

            msOriginal = null;
            msConverted = null;
            imageOriginal = null;
            imageConverted = null;

            return buffer;
        }

        private void ConvertPhotos()
        {
            if (!InitializePaths())
                return;

            try
            {
                Base.Loading(this, true);

                string[] files = Directory.GetFiles(txtPathSource.Text);

                bool hasValidFormat = false;
                string[] vExt = { ".png", ".jpg", ".jpeg", ".jpe", ".gif", ".tif", ".tiff", ".bmp", ".dib", ".rle", ".ico", ".wnf", ".emf" };
                string validExt = string.Join(", ", (vExt));
                
                int fileSize = -1;

                byte[] buffer = { };
                ImageFormat format = GetImageFormat(cmbFormats.Text);

                foreach (string f in files)
                {
                    string ext = f.Substring(f.LastIndexOf(".")).ToLower().Trim();
                    if (validExt.Contains(ext))
                    {
                        using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read, FileShare.Read, 8))
                        {
                            fileSize = (int)new FileInfo(f).Length;
                            buffer = new byte[fileSize];
                            fs.Read(buffer, 0, fileSize);
                            fs.Close();
                        }

                        buffer = ConvertImage(buffer, format);

                        using (FileStream fs = new FileStream(f.Replace(ext, cmbFormats.Text).Replace(txtPathSource.Text, txtPathTarget.Text), FileMode.Create, FileAccess.Write, FileShare.None, 8))
                        {
                            fs.Write(buffer, 0, buffer.Length);
                            fs.Close();
                        }

                        Array.Resize(ref buffer, 0);

                        hasValidFormat = true;
                    }
                }

                if (hasValidFormat)
                {
                    Base.RunExplorer(txtPathTarget.Text);
                }
                else
                    MessageBox.Show("فایلی با فرمت معتبر در پوشه مبدا جهت تبدیل یافت نشد", Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Base.msgTitle, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            finally
            {
                Base.Loading(this, false);
            }
        }

        #endregion
    }
}
