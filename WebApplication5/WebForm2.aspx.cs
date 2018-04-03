using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication5
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Databind();
        }

        public static List<User> getXmlData()
        {
            String xmlPath = Util.filePath + "User.xml";
            var xdoc = XDocument.Load(xmlPath);
            var query = (from item in xdoc.Descendants("user")
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

            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    }


}