using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyServerApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        DataTable dtCountries = new DataTable();
        DBAccess objectDBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Sum(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public string Countries()
        {
            dtCountries.Columns.Add("Country Name");
            dtCountries.Columns.Add("Continent");

            dtCountries.Rows.Add("TUN", "Africa");
            dtCountries.Rows.Add("ALG", "Africa");
            dtCountries.Rows.Add("MAR", "Africa");
            dtCountries.Rows.Add("LIB", "Africa");
            dtCountries.Rows.Add("MOR", "Africa");
            dtCountries.Rows.Add("QAT", "Asia");
            dtCountries.Rows.Add("IRA", "Asia");
            dtCountries.Rows.Add("KWA", "Asia");
            dtCountries.Rows.Add("GER", "Europe");
            dtCountries.Rows.Add("ESP", "Europe");
            return JsonConvert.SerializeObject(dtCountries);
        }

        [WebMethod]
        public string dataTableForUsers(string id)
        {
            string query = "Select * From Users Where ID = '" + id + "'";
            objectDBAccess.readDatathroughAdapter(query, dtUsers);
            string result = JsonConvert.SerializeObject(dtUsers);
            return result;
        }
    }
}
