using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Outlay
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Current = this;
            this.Text = "Personal Outlay";
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUnpUser();
        }
        public static void SignUnpUser()
        {
            frmSignup CreateUserFRM = new frmSignup();
            var form = Application.OpenForms.OfType<frmSignup>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                CreateUserFRM.MdiParent = frmMain.Current;
                CreateUserFRM.Text = "Create User";
                CreateUserFRM.Show();
            }
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            ForceLogin();
        }
        public static void ForceLogin()
        {
            //force login
            if (DBConnection.CheckuserLogin == "N")
            {
                frmLogin loginFrom = new frmLogin();
                loginFrom.MdiParent = frmMain.Current;
                loginFrom.Text = "Login";
                loginFrom.Show();
                // menuStrip.Visible = false;
            }
            //Enabled menu strinp
            //if (DBConnection.CheckuserLogin == "N")
            //{
            //    menuStrip.Visible = false;
            //}
            //else
            //{
            //    menuStrip.Visible = true;
            //}
        }
        private void costTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCostType frmCost = new frmCostType();
            var form = Application.OpenForms.OfType<frmCostType>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmCost.MdiParent = this;
                frmCost.Text = "Cost Types";
                frmCost.Show();
            }
        }

        private void incomeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIncomeType frmIncome = new frmIncomeType();
            var form = Application.OpenForms.OfType<frmIncomeType>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmIncome.MdiParent = this;
                frmIncome.Text = "Income Types";
                frmIncome.Show();
            }
        }

        private void outlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOutlay frmOutlay = new frmOutlay();
            var form = Application.OpenForms.OfType<frmOutlay>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmOutlay.MdiParent = this;
                frmOutlay.Text = "Outlay + " + DBConnection.LoginUserName;
                frmOutlay.Show();
            }
        }

        private void dashBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashOpen();
        }

        public static  void DashOpen()
        {
            frmDashboard frmDashboar = new frmDashboard();
            var form = Application.OpenForms.OfType<frmDashboard>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
                
            }
            else
            {
                frmDashboar.MdiParent = frmMain.Current;
                frmDashboar.Text = "Dashboard + " + DBConnection.LoginUserName;
                frmDashboar.Show();
            }
            return;
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass frmChangePas = new frmChangePass();
            var form = Application.OpenForms.OfType<frmChangePass>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmChangePas.MdiParent = this;
                frmChangePas.Text = "Change Password";
                frmChangePas.Show();
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logoutToolStripMenuItem.Text == "Login")
            {
                frmLogin frmLogin = new frmLogin();
                var form = Application.OpenForms.OfType<frmLogin>().FirstOrDefault();
                if (form != null)
                {
                    form.Activate();
                }
                else
                {
                    frmLogin.MdiParent = this;
                    frmLogin.Text = "Login";
                    frmLogin.Show();
                }
            }
            else
            {
                CloseAllToolStripMenuItem_Click(null, new EventArgs());
                DBConnection.CheckuserLogin = "Y";
                DBConnection.LoginUserID = null;
                DBConnection.LoginUserName = null;
                logoutToolStripMenuItem.Text = "Login";
            }
        }
        //expose this text as public Change Login and logout text from another thread      
        public static frmMain Current;
        public string LoginLogoutText
        {
            get { return logoutToolStripMenuItem.Text; }
            set { logoutToolStripMenuItem.Text = value; }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAboutBox frmAbout = new frmAboutBox();
            var form = Application.OpenForms.OfType<frmAboutBox>().FirstOrDefault();
            if (form != null)
            {
                form.Activate();
            }
            else
            {
                frmAbout.MdiParent = this;
                frmAbout.Text = "About us";
                frmAbout.Show();
            }
        }
    }
}
