using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using ClassLibrary1;

namespace WebApplication5.welcome
{
    public partial class WebForm3 : System.Web.UI.Page
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

        public static List<User> getXmlData()
        {
            String xmlPath = Util.filePath + "User.xml";
            var xdoc = XDocument.Load(xmlPath);
            var query = (from item in xdoc.Descendants("user")
                         where item.Element("name").Value.Contains(keyword)
                         select new User()
                         {
                             name = item.Element("name").Value,
                             password = item.Element("password").Value,
                             gender = item.Element("gender").Value,
                             phone = item.Element("phone").Value,
                             birthday = item.Element("birthday").Value,
                             id = item.Element("id").Value,

                         }).ToList();
            return query;
        }

        public void Databind()
        {
            var query = getXmlData();
            gv_xml.DataSource = query;
            gv_xml.DataBind();
        }

        protected void gv_xml_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_xml.EditIndex = -1;
            Databind();
        }

        protected void gv_xml_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_xml.EditIndex = e.NewEditIndex;
            ori = ((Label)gv_xml.Rows[e.NewEditIndex].Cells[0].FindControl("Label0")).Text;
            Databind();
        }

        protected void gv_xml_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string Xmlpath = String.Format(Util.filePath + "User.xml");

            ori = ((Label)this.gv_xml.Rows[e.RowIndex].FindControl("Label0")).Text;

            DataSet ds = new DataSet();
            ds.ReadXml(Xmlpath);
            DataRow dr = null;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                if ((String)d["id"] == ori)
                {
                    dr = d;
                    break;
                }
            }
            dr.Delete();
            ds.WriteXml(Xmlpath);

            Databind();
        }

        protected void gv_xml_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_xml.PageIndex = e.NewPageIndex;
            Databind();
        }

        protected void gv_xml_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string Xmlpath = String.Format(Util.filePath + "User.xml");
            GridViewRow row = gv_xml.Rows[e.RowIndex]; //获得当前行

            int numCell = row.Cells.Count;  //共几列单元格(包含Edit和Delete 2列) 
            int currentRow = row.DataItemIndex; //对应DataSet对应的行索引 

            DataSet ds = new DataSet();
            ds.ReadXml(Xmlpath);
            DataRow dr = null;
            foreach (DataRow d in ds.Tables[0].Rows)
            {
                if ((String)d["id"] == ori)
                {
                    dr = d;
                    break;
                }
            }

            String id = ((TextBox)row.Cells[0].FindControl("Txtbox0")).Text;
            String phone = ((TextBox)row.Cells[3].FindControl("Txtbox3")).Text;

            if (id!=(String)dr["id"] && Util.isUserExist(id))
            {
                Response.Write("<script   language='javascript'>alert('id已存在');</script>");
                return;
            }

            if (!Regex.IsMatch(phone, @"1\d{10}"))
            {
                Response.Write("<script   language='javascript'>alert('手机号格式错误');</script>");
                return;
            }


            string[] str = null;  //此数组定义表的列名 
            str = new string[]{ "id", "name", "gender", "phone",
                             "birthday", "password"};
            int j = 0;

            TextBox myTextBox = null;
            for (int i = 0; i < 6; i++)
            {
                if (i == 4)
                {
                    HtmlInputGenericControl h = row.Cells[i].FindControl("dateText") as HtmlInputGenericControl;
                    if(h.Value!="")
                    dr[str[j]] = h.Value;
                }
                else if (i == 2)
                {
                    DropDownList ddl = row.Cells[i].FindControl("ddl") as DropDownList;
                    dr[str[j]] = ddl.SelectedItem.Text;
                }
                else
                {
                    myTextBox = row.Cells[i].FindControl("Txtbox" + i) as TextBox;
                    dr[str[j]] = myTextBox.Text;
                }

                j++;
            }
            ds.WriteXml(Xmlpath);
            gv_xml.EditIndex = -1;
            Databind();
        }

        protected void addUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("addUser.aspx");
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