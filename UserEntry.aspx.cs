using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CakeTest
{
    public partial class UserEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                var user = new User();
                

                var errors = ValidateFields(user);

                var serializer = new JavaScriptSerializer();

                if (errors.Count > 0)
                {
                    Response.Clear();
                    Response.Write(serializer.Serialize(errors));
                    Response.End();
                }
                else
                {
                    Session.Add("UserData", serializer.Serialize(user));
                }
            }
        }

        private List<string> ValidateFields(User user)
        {
            var errors = new List<string>();
            user.FirstName = Request.Form["FirstName"];
            user.LastName = Request.Form["LastName"];
            user.Sex = Request.Form["Sex"];
            user.Phone = Request.Form["Phone"];
            user.StreetAddress = Request.Form["StreetAddress"];
            user.City = Request.Form["City"];
            user.State = Request.Form["State"];
            int zip;
            if (int.TryParse(Request.Form["Zip"], out zip))
            {
                user.Zip = zip;
            }
            else
            {
                errors.Add("Zip code should be numeric");
            }           
            
            if (String.IsNullOrWhiteSpace(user.FirstName)) errors.Add("First name must be populated.");
            if (String.IsNullOrWhiteSpace(user.LastName)) errors.Add("Last name must be populated.");
            if (String.IsNullOrWhiteSpace(user.Sex)) errors.Add("Sex must be populated.");
            if (String.IsNullOrWhiteSpace(user.Phone)) errors.Add("Phone must be populated.");
            if (String.IsNullOrWhiteSpace(user.StreetAddress)) errors.Add("Street Address must be populated.");
            if (String.IsNullOrWhiteSpace(user.City)) errors.Add("City must be populated.");
            if (String.IsNullOrWhiteSpace(user.State)) errors.Add("State must be populated.");
            
            return errors;
        }
    }
}