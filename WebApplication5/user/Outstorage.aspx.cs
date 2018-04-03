using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication5.user
{
    public partial class Outstorage : System.Web.UI.Page
    {
        static String userName = "张三";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] != null)
                userName = Session["name"].ToString();

            Databind();
        }

        protected void addOutstorage_Click(object sender, EventArgs e)
        {
            Response.Redirect("addOutstorage.aspx");
        }

        public static List<ClassLibrary1.Outstorage> getXmlData()
        {
            String xmlPath = Util.filePath + "Outstorage.xml";
            var xdoc = XDocument.Load(xmlPath);
            var query = (from item in xdoc.Descendants("Outstorage")
                         where item.Element("applicant").Value == userName
                         select new ClassLibrary1.Outstorage()
                         {
                             serial = item.Element("serial").Value,
                             isbn = item.Element("isbn").Value,
                             date = item.Element("date").Value,
                             num = item.Element("num").Value,
                             applicant = item.Element("applicant").Value,
                             status = item.Element("status").Value,
                         }).ToList();
            return query;
        }

        public void Databind()
        {
            var query = getXmlData();

            GridView1.DataSource = query;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Databind();
        }
    }
}