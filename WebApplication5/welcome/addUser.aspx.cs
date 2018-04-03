using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.welcome
{
    public partial class addUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            init();
        }

        protected void init()
        {
            male.Checked = true;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String id = this.userId.Text;
            String name = this.name.Text;
            String phone = this.phone.Text;
            String date = this.user_date.Value;
            String password = this.password.Text;
            String gender = null;

            if (male.Checked)
            {
                gender = "男";
            }
            if(female.Checked)
            {
                gender = "女";
            }
            tip.Text = " \t ";

            if (id == "" || name == "" || phone == "" || date == "" || password == "" )
            {
                // Response.Write("<script language='javascript'>alert('输入栏不能有空');</script>");
                tip.Text = "输入栏不能有空(包括出生日期)";
                return;
            }

            if (Util.isUserExist(id))
            {
                tip.Text = "用户ID已存在";
                return;
            }
       
            if(!Regex.IsMatch(phone,@"1\d{10}")){
                tip.Text = "手机号格式错误";
                return;
            }

            User user = new User( name,  password,  gender,  id,  date, phone);
            user.save();
            tip.Text = "您已添加成功，可以继续添加用户";
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(".\\UserForm.aspx");
        }
    }
}