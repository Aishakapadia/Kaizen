using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UFS_Application.App_class;
using UFS_Application.BAL;
using UFS_Application.DAL;

namespace UFS_Application.Forms.UserControl
{
    public partial class UCUserManagement : System.Web.UI.UserControl
    {
        public string message = "";
        public string heading = "";
        public string type = "";
        public string returnMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                formLoad();
            }


        }
        public void formLoad()
        {
            fillAccountType();
            fillAllRegions();
            fillGrid();
            controlClear();
            txtUserName.Enabled = true;

        }
        public void FormStatus()
        {

        }
        public void controlClear()
        {
            lblUserId.Text = "";
            //lblUserSTatus.Text = " (New)";
            txtEmail.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            ddlAccountTyps.SelectedIndex = 0;
            ddlRegion.SelectedIndex = 0;
            chbActive.Checked = false;
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;
            btnAdd.Visible = true;
        }
        public void fillGrid()
        {
            gvUserMgmt.DataSource = new UserRepository().GetAllUsers();
            gvUserMgmt.DataBind();
        }
        public void fillAccountType()
        {
            new MiscellaneousOperation().fillAccountType(ref ddlAccountTyps);
        }
        public void fillAllRegions()
        {
            new MiscellaneousOperation().fillAllRegions(ref ddlRegion);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            bool result = new UserRepository().AddUser(formToObject(), ref returnMessage);
            if(result)
            {
                heading = "User Added";
                message = returnMessage;
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                formLoad();
            }
            else
            {
                heading = "User Added";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            formLoad();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            bool result = new UserRepository().UpdateUser(formToObject(), ref returnMessage);
            if (result)
            {
                heading = "User updated";
                message = returnMessage;
                type = "success";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);
                formLoad();
            }
            else
            {
                heading = "User updated";
                message = returnMessage;
                type = "error";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "SwalMessage('" + heading + "','" + message + "','" + type + "')", true);


            }
        }

        protected void gvUserMgmt_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToUpper() == MisOp.GridCommand.GRIDEDIT.ToString())
            {
                var UserMgmtObj = GetUserById(Convert.ToInt32(e.CommandArgument.ToString()));
                if (UserMgmtObj != null)
                {
                    ObjectToForm(UserMgmtObj);
                    btnUpdate.Visible = true;
                    btnCancel.Visible = true;
                    btnAdd.Visible = false;
                    txtUserName.Enabled = false; 
                }
            }
        }

        public void ObjectToForm(User user)
        {
            lblUserId.Text = user.UserId.ToString();
            txtEmail.Text = user.EmailAddress;
            txtFirstName.Text = user.FirstName;
            txtLastName.Text = user.LastName;
            txtUserName.Text = user.UserName;
            ddlRegion.SelectedValue = user.RegionId.ToString();
            ddlAccountTyps.SelectedValue = user.AccountTypeId.ToString();
            chbActive.Checked = user.IsActive;
        }
        public User formToObject()
        {
            User user = new DAL.User();
            if (lblUserId.Text != "")
            {
                user.UserId = Convert.ToInt32(lblUserId.Text);
                user.LastModifiedDate = DateTime.Now;
            }
            user.EmailAddress = txtEmail.Text;
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.UserName = txtUserName.Text;
            user.RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            user.AccountTypeId = Convert.ToInt32(ddlAccountTyps.SelectedValue);
            user.CreatedDate = DateTime.Now;
            user.IsActive = chbActive.Checked;
            return user;

        }
        public User GetUserById(int userid)
        {
            return new UserRepository().GetUserByUserId(userid);
        }
    }
}