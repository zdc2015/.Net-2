using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary1;

namespace WebApplication5
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            
            
        }


        protected void userId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            String name = this.userId.Text;
            String password = this.password.Text;
            if (name.Equals("admin") && password.Equals("0000"))
            {
                Server.Execute("welcome/welcome.aspx", true);//第二个参数为false时，WebForm2.aspx中不能获得TextBox1的内容 
            }
            else if (Util.Login(name, password))
            {
                //this.TextBox2.Text =Request ["TextBox1"].ToString (); 
                Session["name"] = name;
                Response.Redirect("user\\userWelcome.aspx");
            }
            else
            {
                Response.Write("<script   language='javascript'>alert('用户名或密码错误');</script>");
            }
        }
    }
}