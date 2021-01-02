using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goodreads_Clone.Pages.admin
{
    public partial class add_book : System.Web.UI.Page
    {
        // Instance Variable to hold the connection string
        protected String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReadingDBConnectionString"].ConnectionString;

        /**
         * Code to run when the page is loaded upon landing on the page or postback
         */
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        /**
         * Code to run when the submit button is clicked
         */
        protected void newBookSubmitButton_Click(object sender, EventArgs e)
        {
            // Once the submit button is clicked, the input will be validated. If the validation succeeds, then we will
            // try to insert the data into the database
            if(ValidateInput())
            {

            }
        }

        /**
         * 
         */
        protected bool ValidateInput()
        {
            
        }
    }
}