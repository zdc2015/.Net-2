using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ClassLibrary1;
namespace WebApplication5.welcome
{
    public partial class GoodsForm : System.Web.UI.Page
    {
        static String keyword = "";
        static String ori = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Databind();
            }
        }

        public void initType()
        { 
            DropDownList ddl = (DropDownList)GridView1.FindControl("typeList");
            ddl.DataSource = Util.goodsType;
            ddl.DataBind();
        }

        public static List<Goods> getXmlData()
        {
            String xmlPath = Util.filePath + "Goods.xml";
            var xdoc = XDocument.Load(xmlPath);
            List<Goods> query;
            if (keyword=="")
                query = (from item in xdoc.Descendants("goods")
                             select new Goods()
                             {
                                 name = item.Element("name").Value,
                                 isbn = item.Element("isbn").Value,
                                 type = item.Element("type").Value,
                                 specifications = item.Element("specifications").Value,
                                 model = item.Element("model").Value,
                                 picture = item.Element("picture").Value,
                                 origin = item.Element("origin").Value,
                                 num = Convert.ToInt32(item.Element("num").Value),

                             }).ToList();
            else
                query = (from item in xdoc.Descendants("goods")
                             where item.Element("name").Value.Contains(keyword)
                             select new Goods()
                             {
                                 name = item.Element("name").Value,
                                 isbn = item.Element("isbn").Value,
                                 type = item.Element("type").Value,
                                 specifications = item.Element("specifications").Value,
                                 model = item.Element("model").Value,
                                 picture = item.Element("picture").Value,
                                 origin = item.Element("origin").Value,
                                 num = Convert.ToInt32(item.Element("num").Value),

                             }).ToList();
            return query;
        }

        public void Databind()
        {
            var query = getXmlData();
            
            GridView1.DataSource = query;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Label tb = ((Label)GridView1.Rows[e.NewEditIndex].FindControl("Label1"));
            ori = tb.Text;
            Databind();
        }

        protected void GridView1_RowCancelingEdit(object sende, EventArgs e)
        {
            GridView1.EditIndex = -1;
            Databind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Xmlpath = String.Format(Util.filePath + "Goods.xml");

            GridViewRow row = this.GridView1.Rows[e.RowIndex];

            int curr = row.RowIndex;
            DataSet ds = new DataSet();
            ds.ReadXml(Xmlpath);

            DataRow dr = ds.Tables[0].Rows[curr];
            dr.Delete();
            ds.WriteXml(Xmlpath);

            Databind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            String[] strs = new String[10];

            string Xmlpath = String.Format(Util.filePath + "Goods.xml");
            DataSet ds = new DataSet();
            ds.ReadXml(Xmlpath);
            DataRow dr = null;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                if ((String)d["isbn"] == ori)
                {
                    dr = d;
                    break;
                }
            }
            
            for (int i = 1; i <= 7; i++)
            {
                if (i == 6) continue;
                if (i == 3)
                {
                    DropDownList ddl = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl");
                    strs[i] = ddl.SelectedItem.Text;
                    continue;
                }
                strs[i] = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox"+i)).Text;
            }

            int a = 0;
            try
            {
                a = Convert.ToInt32(strs[7]);
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('请正确输入数量');</script>");
                return;
            }

            if (strs[1]!=(String)dr["isbn"] && Util.isGoodsExist(strs[1]))
            {
                Response.Write("<script language='javascript'>alert('物品编号已存在，请正确编号');</script>");
                return;
            }

            string[] str = new string[]{ "isbn", "name", "type", "specifications",
                             "model", "picture","num"};

            for (int i = 1; i <=7; i++)
            {
                if (i == 6) continue;
                dr[str[i - 1]] = strs[i];
            }

            ds.WriteXml(Xmlpath);

            GridView1.EditIndex = -1;
            Databind();
        }

        protected void addGoods_Click(object sender, EventArgs e)
        {
            Response.Redirect("addGoods.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Databind();
        }

        protected void view_all_Click(object sender, EventArgs e)
        {
            keyword = "";
            Databind();
        }

        protected void view_part_Click(object sender, EventArgs e)
        {
            keyword = this.key.Text;
            Databind();
        }
    }
}