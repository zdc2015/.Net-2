using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.user
{
    public partial class titleForm : System.Web.UI.Page
    {
        public String user_name { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            user_name = "小明";
            if (Session["name"] != null)
                user_name = Session["name"].ToString();

            title.Text = "亲爱的" + user_name + ", 欢迎来到物品管理系统";
        }
    }
}