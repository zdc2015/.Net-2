using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibrary1
{
    public class Util
    {
        public static String filePath = "D:\\homework2\\data\\";
        public static String[] goodsType = { "纸张", "文具", "刀具", "单据", "礼品", "其它" };


        public static Boolean Login(String name, String password)
        {
       
            XElement xe = load("User.xml");
            User user = new User();
            var item = (from ele in xe.Elements("user")
                        where ele.Element("name").Value.Equals(name) 
                        where ele.Element("password").Value.Equals(password)
                        select ele).SingleOrDefault();
            if (item == null)
            {
                return false;
            }
            return true;
        }

        public static List<User> getAllUser()
        {
            List<User> list = new List<User>();
            XElement xe = load("User.xml");
            foreach(var item in xe.Descendants())
            {
                User user = new User();
                user.name = item.Element("name").Value;
                user.password = item.Element("password").Value;
                list.Add(user);
            }
            return list;
        }

        public static XElement load(String name)
        {
            String path = String.Format("{0}{1}",filePath,name);
            Console.WriteLine("打开文件{0}", path);
            return XElement.Load(path);
        }

        public static bool isUserExist(string id)
        {
            DataSet ds = new DataSet();
            String path = Util.filePath + "User.xml";
            ds.ReadXml(path);
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                if ((string)dr["id"] == id) return true; 
            }
            return false;
        }

        public static Goods getGoods(String isbn)
        {
            Goods g = null;
            DataSet ds = new DataSet();
            String path = Util.filePath + "Goods.xml";
            ds.ReadXml(path);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((string)dr["isbn"] == isbn)
                {
                    g = new Goods
                    {
                        isbn = dr["isbn"].ToString(),
                        model = dr["model"].ToString(),
                        name = dr["name"].ToString(),
                        specifications = dr["specifications"].ToString(),
                        type = dr["type"].ToString(),
                        num = Convert.ToInt32(dr["num"].ToString()),
                        origin = dr["origin"].ToString(),
                        picture = dr["picture"].ToString(),

                    };
                    return g;
                }
            }
            return null;
        }

        public static String getTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }


           public static bool isGoodsExist(string isbn)
        {
            DataSet ds = new DataSet();
            String path = Util.filePath + "Goods.xml";
            ds.ReadXml(path);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if ((string)dr["isbn"] == isbn) return true;
            }
            return false;
        }

        public static Boolean addGoods(String isbn, String quantity)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Util.filePath + "Goods.xml");
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                if ((String)row["isbn"] == isbn)
                {
                    row["num"] = "" + (Convert.ToInt32(quantity) + Convert.ToInt32((String)row["num"]));
                    ds.WriteXml(Util.filePath + "Goods.xml");
                    return true;
                }
            }
            return false;
        }

        public static void reply(String serial, String reply)
        {
            DataSet ds = new DataSet();
            String isbn = null;
            int quantity = 0;
            Boolean flag = false;
            ds.ReadXml(Util.filePath + "Outstorage.xml");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if ((String)row["serial"] == serial)
                {
                    row["status"] = reply;
                    isbn = row["isbn"].ToString();
                    quantity =  Convert.ToInt32(row["num"].ToString());
                    ds.WriteXml(Util.filePath + "Outstorage.xml");
                    flag = true;
                    break;
                }
            }

            if (reply == "同意" && flag)
            {
                DataSet dss = new DataSet();
                dss.ReadXml(Util.filePath + "Goods.xml");
                foreach (DataRow row in dss.Tables[0].Rows)
                {
                    if ((String)row["isbn"] == isbn)
                    {
                        row["num"] = "" + (Convert.ToInt32((String)row["num"]) - quantity);
                        dss.WriteXml(Util.filePath + "Goods.xml");
                        return;
                    }
                }
            }
        }
    }

    public class User
    {

        public String name { get; set; }
        public String password { get; set; }
        public String gender { get; set; }
        public String id { get; set; }
        public String birthday { get; set; }
        public String phone { get; set; }

        public User() { }

        public User(String name, String password,String gender, String id, String birthday, String phone)
        {
            this.name = name;
            this.password = password;
            this.gender = gender;
            this.id = id;
            this.birthday = birthday;
            this.phone = phone;
        }

        public void save()
        {
            DataSet ds = new DataSet();
            String path = Util.filePath + "User.xml";
            ds.ReadXml(path);
            DataRow row = ds.Tables[0].NewRow();
            row["name"] = name;
            row["password"] = password;
            row["gender"] = gender;
            row["id"] = id;
            row["birthday"] = birthday;
            row["phone"] = phone;
            row["name"] = name;
            ds.Tables[0].Rows.Add(row);
            ds.WriteXml(Util.filePath + "User.xml");
        }
    }

    public class Goods
    {
        public String isbn { get; set; }
        public String name { get; set; }
        public String type { get; set; }
        public String origin { get; set; }
        public String specifications { get; set; }
        public String model { get; set; }
        public String picture { get; set; }
        public int num { get; set; }

        public void save()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Util.filePath + "Goods.xml");

            if (ds.Tables.Count == 0)
            {
                DataTable dt = new DataTable("goods");

                DataColumn dc = new DataColumn("name");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("isbn");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("type");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("origin");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("model");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("specifications");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("picture");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("num");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                ds.Tables.Add(dt);
            }

            DataRow row = ds.Tables[0].NewRow();
            row["isbn"] = this.isbn;
            row["name"] = this.name;
            row["type"] = this.type;
            row["origin"] = this.origin;
            row["specifications"] = specifications;
            row["model"] = model;
            row["picture"] = picture;
            row["num"] = num;
            ds.Tables[0].Rows.Add(row);
            ds.WriteXml(Util.filePath + "Goods.xml");
        }
    }

    public class Instorage
    {
        public String serial { get; set; }
        public String isbn { get; set; }
        public String purchase { get; set; }
        public String num { get; set; }
        public String price { get; set; }
        public String totPrice { get; set; }
        public void save()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Util.filePath + "Instorage.xml");
            
            if (ds.Tables.Count == 0)
            {
                DataTable dt = new DataTable("Instorage");

                DataColumn dc = new DataColumn("serial");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("isbn");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("num");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("purchase");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("price");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                dc = new DataColumn("totPrice");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                ds.Tables.Add(dt);
            }
            DataRow row = ds.Tables[0].NewRow();
            row["serial"] = this.serial;
            row["isbn"] = this.isbn;
            row["purchase"] = this.purchase;
            row["num"] = this.num;
            row["price"] = price;
            row["totPrice"] = totPrice;
            ds.Tables[0].Rows.Add(row);
            ds.WriteXml(Util.filePath + "Instorage.xml");
        }
    }

    public class Outstorage
    {
        public String serial { get; set; }
        public String date { get; set; }
        public String isbn { get; set; }
        public String applicant { get; set; }
        public String num { get; set; }
        public String status { get; set; }

        public void save()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Util.filePath + "Outstorage.xml");

            if (ds.Tables.Count == 0)
            {
                DataTable dt = new DataTable("Outstorage");

                DataColumn dc = new DataColumn("serial");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("isbn");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("num");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("date");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("applicant");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);

                dc = new DataColumn("status");
                dc.ColumnMapping = MappingType.Element;
                dt.Columns.Add(dc);
                ds.Tables.Add(dt);
            }

            DataRow row = ds.Tables[0].NewRow();
            row["isbn"] = this.isbn;
            row["applicant"] = this.applicant;
            row["serial"] = this.serial;
            row["date"] = this.date;
            row["num"] = this.num;
            row["status"] = this.status;
            ds.Tables[0].Rows.Add(row);
            ds.WriteXml(Util.filePath + "Outstorage.xml");
        }
    }

}
