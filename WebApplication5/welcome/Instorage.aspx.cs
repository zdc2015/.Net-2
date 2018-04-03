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
    public partial class Instorage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Databind();
            }
        }

        public static List<ClassLibrary1.Instorage> getXmlData()
        {
            String xmlPath = Util.filePath + "Instorage.xml";
            var xdoc = XDocument.Load(xmlPath);
            var query = (from item in xdoc.Descendants("Instorage")
                         select new ClassLibrary1.Instorage()
                         {
                             serial = item.Element("serial").Value,
                             isbn = item.Element("isbn").Value,
                             purchase = item.Element("purchase").Value,
                             num = item.Element("num").Value,
                             price = item.Element("price").Value,
                             totPrice = item.Element("totPrice").Value,

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
            
        }

        protected void addInstorage_Click(object sender, EventArgs e)
        {
            Response.Redirect("addInstorage.aspx");
        }
    }
}