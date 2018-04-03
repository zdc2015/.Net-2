using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5.welcome
{
    public partial class addGoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindType();
        }

        protected void typeddl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bindType()
        {
            typeddl.DataSource = Util.goodsType;
            typeddl.DataBind();
        }

        protected void Save()
        {
            String isbn = this.isbn.Text;
            String name = this.name.Text;
            String type = this.typeddl.Text;
            String model = this.model.Text;
            String num = this.num.Text;
            String origin = this.origin.Text;
            String imgUrl = null;
            String specifications = this.specifications.Text;
            tip.Text = " ";

            if(num=="" ||isbn=="" || name=="" || model=="" || origin=="" || specifications == "")
            {
                Response.Write("<script language='javascript'>alert('输入栏不能有空');</script>");
                return;
            }

            int a = 0;

            try
            {
                a = Convert.ToInt32(num);
            }
            catch (Exception e)
            {
                Response.Write("<script language='javascript'>alert('请正确输入数量');</script>");
                return;
            }

            if (!imgUpload.HasFile)
            {
                Response.Write("<script   language='javascript'>alert('您还未选择图片');</script>");
                return ;
            }
            else
            {
                String path = Server.MapPath("./../picture/"+imgUpload.FileName);
                try
                {
                    imgUpload.SaveAs(path);
                }
                catch (Exception)
                {

                    Response.Write("<script   language='javascript'>alert('图片上传失败，请换张图片或改名');</script>");
                    return;
                }

                imgUrl = ".\\..\\picture\\" + imgUpload.FileName;
                path = imgUrl;
            }

            Goods g = new Goods();
            g.isbn = isbn; g.num = a; g.model = model; g.name = name; g.origin = origin; g.specifications = specifications; g.picture = imgUrl;g.type = type;
            g.save();
            tip.Text = "您已添加成功，可以继续添加物品";
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect(".\\GoodsForm.aspx");
            //Response.Redirect(Server.MapPath("./GoodsForm.aspx"));
        }
    }
}