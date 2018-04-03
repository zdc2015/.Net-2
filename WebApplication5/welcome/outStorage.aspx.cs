using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication5.welcome
{
    public partial class outStorage : System.Web.UI.Page
    {
        public class T : ClassLibrary1.Outstorage
        {
            public int storage { get; set; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                Databind();
        }

        public static List<T> getXmlData()
        {
            String xmlPath = Util.filePath + "Outstorage.xml";
            var xdoc = XDocument.Load(xmlPath);
            var query = (from item in xdoc.Descendants("Outstorage")
                         where item.Element("status").Value =="申请"
                         select new T()
                         {
                             serial = item.Element("serial").Value,
                             isbn = item.Element("isbn").Value,
                             date = item.Element("date").Value,
                             num = item.Element("num").Value,
                             applicant = item.Element("applicant").Value,
                             status = item.Element("status").Value,
                             storage = Util.getGoods(item.Element("isbn").Value).num,

                         }).ToList();
            return query;
        }

        public void Databind()
        {
            var query = getXmlData();

            GridView1.DataSource = query;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index]; //获得当前行

            String serial = ((Label)(row.FindControl("serial"))).Text;
            int num = Convert.ToInt32(((Label)row.FindControl("num")).Text);
            int storage = Convert.ToInt32(((Label)row.FindControl("storage")).Text);

            String reply;
            if (e.CommandName == "agree")
            {
                reply = "同意";
                if (num > storage)
                {
                    Response.Write("<script language='javascript'>alert('申请数量过多，无法批准');</script>");
                    return;
                }
            }
            else
            {
                reply = "拒绝";
            }
            Util.reply(serial, reply);
            Databind();
        }
    }
}