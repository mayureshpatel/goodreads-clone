using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
         * Validates the form when the submit button is clicked. Each input should have values inside
         * of it. The ISBN should be a 13 digit number, the page count should be a number, and the
         * author names and genre names should be comma separated values.
         */
        protected bool ValidateInput()
        {
            // Set the Text values of all literals to empty strings
            SetErrorLiteralText("");

            // Flag to test if the input is valid (cannot be set back to true)
            bool validFlag = true;

            // Validates the book name input (cannot be empty)
            if(bookNameTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book name
                bookNameLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red


                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green

            }

            // Validates the book isbn input (must be a 13 digit number)
            Regex isbnPattern = new Regex(@"^\d{13}$");
            if(!isbnPattern.IsMatch(bookISBNTextBox.Text))
            {
                // Set the error literal associated with the book isbn
                bookISBNLiteral.Text = "<small class='error-small'>must be a 13 digit number</small>";

                // Add a css class to the textbox that will change the border to red

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green

            }

            // Validates the page count input (cannot be blank)
            if(bookPageCountTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book page count
                bookPageCountLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green

            }

            // Validates the authors name input (cannot be blank and must be comma separated)
            if (Regex.Matches(bookAuthorsTextBox.Text, @"\w[^,]+").Count == 0 || bookAuthorsTextBox.Text.Length == 0)
            {
                // Set error literal associated with the author names
                bookAuthorsLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to green

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green

            }

            // Validates the genre names input (cannot be blank and must be comma separated)
            if (Regex.Matches(bookGenresTextBox.Text, @"\w[^,]+").Count == 0 || bookGenresTextBox.Text.Length == 0)
            {
                // Set error literal associated with the author names
                bookGenresLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green

            }

            // Validates the book summary input (cannot be blank)
            if (bookSummaryTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book summary
                bookSummaryLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
            }

            // Return the valid flag's value
            return validFlag;
        }

        /**
         * Sets the Text values of all error literals to a given text
         * @param text the text to set the literal Text value to
         */
        protected void SetErrorLiteralText(String text)
        {
            bookNameLiteral.Text = text;
            bookISBNLiteral.Text = text;
            bookPageCountLiteral.Text = text;
            bookAuthorsLiteral.Text = text;
            bookGenresLiteral.Text = text;
            bookSummaryLiteral.Text = text;
        }
    }
}