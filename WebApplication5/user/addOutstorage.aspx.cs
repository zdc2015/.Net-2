using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.user
{
    public partial class addOutstorage : System.Web.UI.Page
    {
        public String userName = "张三";


        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["name"] != null)
                userName = Session["name"].ToString();

        }

        protected void init()
        {
            isbn.Text = "";
            quantity.Text = "";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String isbn = this.isbn.Text;
            String date = this.outdate.Value;
            String quantity = this.quantity.Text;

            if(isbn=="" || date == "" || quantity=="")
            {
                tip.Text = "输入栏不能有空";
                return;
            }

            if (!Util.isGoodsExist(isbn))
            {
                tip.Text = "物品编号不存在";
                return;
            }

            int a = 0;
            try
            {
                a = Convert.ToInt32(quantity);
            }
            catch
            {
                tip.Text = "请输入正确的数字";
                return;
            }

            if (!Util.isGoodsExist(isbn))
            {
                tip.Text = "物品编号不存在";
                return;
            }

            Goods g = Util.getGoods(isbn);
            if(a > g.num)
            {
                tip.Text = "申请数量多于库存量！";
                return;
            }

            ClassLibrary1.Outstorage ou = new ClassLibrary1.Outstorage
            {
                applicant = userName,
                isbn = isbn,
                date = date,
                num = quantity,
                serial = Util.getTimeStamp(),
                status = "申请",
            };

            ou.save();
            tip.Text = "申请成功，可以继续申请";
            init();
        }


        protected void userId_TextChanged(object sender, EventArgs e)
        {
            String isbn = this.isbn.Text;
            if (!Util.isGoodsExist(isbn))
            {
                tip.Text = "物品编号不存在";
            }
            else
            {
                tip.Text = "";
            }
        }


        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Outstorage.aspx");
        }
    }
}