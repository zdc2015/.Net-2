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
    public partial class GoodsForm : System.Web.UI.Page
    {
        static String keyword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Databind();
            }
        }

        public static List<Goods> getXmlData(String key)
        {
            String xmlPath = Util.filePath + "Goods.xml";
            var xdoc = XDocument.Load(xmlPath);
            List<Goods> query ;
            if (key=="")
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
                         where item.Element("name").Value == key
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
            var query = getXmlData(keyword);

            GridView1.DataSource = query;
            GridView1.DataBind();
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