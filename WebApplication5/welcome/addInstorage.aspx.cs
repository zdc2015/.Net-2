using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.welcome
{
    public partial class addInstorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                init();
            }
            
        }

        protected void init()
        {
            this.isbn.Text = "";
            this.quantity.Text = "";
            this.price.Text = "";
            this.totPrice.Text = "";
        }

        protected void save_Click(object sender, EventArgs e)
        {
            String isbn = this.isbn.Text;
            String date = this.purchase_date.Value;
            String quantity = this.quantity.Text;
            String price = this.price.Text;
            tip.Text = " ";

            if (quantity == "" || isbn == "" || price == "")
            {
                tip.Text = "输入栏不能有空";
                this.isbn.Text = isbn;
                this.quantity.Text = quantity;
                this.price.Text = price;
                return;
            }

            if (!Util.isGoodsExist(isbn))
            {
                tip.Text = "物品编号不存在！！";
                return;
            }

            try
            {
                int a = Convert.ToInt32(quantity);
            }
            catch (Exception e0)
            {
                Response.Write("<script language='javascript'>alert('请正确输入数量');</script>");
                return;
            }

            try
            {
                double b = Convert.ToDouble(price);
            }
            catch (Exception e1)
            {
                Response.Write("<script language='javascript'>alert('请正确输入价格');</script>");
                return;
            }

            if(!Util.addGoods(isbn, quantity))
            {
                tip.Text = "入库失败！";
                return;
            }

            ClassLibrary1.Instorage g = new ClassLibrary1.Instorage
            {
                serial = getTimeStamp()+isbn,
                isbn = isbn,
                purchase = date,
                num = quantity,
                price = price,
                totPrice = totPrice.Text
            };
            g.save();
            tip.Text = "您已入库，可以继续入库";
            init();
        }

        protected String getTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instorage.aspx");
        }

        protected void price_TextChanged(object sender, EventArgs e)
        {
            int a;
            double b;
            try
            {
                a = Convert.ToInt32(quantity.Text);
            }
            catch (Exception e2)
            {
                return;
            }

            try
            {
                 b = Convert.ToDouble(price.Text);
            }
            catch (Exception e3)
            {
                return;
            }
            totPrice.Text = ""+(a*b);
        }

        protected void quantity_TextChanged(object sender, EventArgs e)
        {
            price_TextChanged(sender,e);
        }
    }
}