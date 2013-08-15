using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

namespace CakeTest
{
    public partial class UserEntryResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var serializer = new JavaScriptSerializer();
            if (Session["UserData"] != null)
            {
                User user = (User)serializer.Deserialize(Session["UserData"].ToString(), typeof(User));
                if (user != null)
                {
                    FirstName.InnerText = user.FirstName;
                    LastName.InnerText = user.LastName;
                    Sex.InnerText = user.Sex;
                    Phone.InnerText = user.Phone;
                    StreetAddress.InnerText = user.Phone;
                    City.InnerText = user.City;
                    State.InnerText = user.State;
                    Zip.InnerText = user.Zip.ToString();
                }
            }
        }
    }
}