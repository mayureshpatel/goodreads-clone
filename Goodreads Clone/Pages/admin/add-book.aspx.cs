using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

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
                // Get the authors and genres input string and process them
                String[] authorsList = GenerateInputList(bookAuthorsTextBox.Text);
                String[] genresList = GenerateInputList(bookGenresTextBox.Text);

                // Lists to hold authors and geners that need to be added to the database
                List<String> addAuthorsList = new List<String>();
                List<String> addGenresList = new List<String>();

                // Populate the addAuthorsList by checking if the author already exists in the database,
                // if it doesn't exist, then add that author to the list
                for(int i = 0; i < authorsList.Length; i++)
                {
                    if(!IsInAuthorTable(authorsList[i]))
                    {
                        addAuthorsList.Add(authorsList[i]);
                    }
                }
            }
            else
            {
                newBookSubmitButton.Text = "woah there!";
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

            // Set the borders for all input boxes back to none
            InitInputBorders();

            // Flag to test if the input is valid (cannot be set back to true)
            bool validFlag = true;

            // Validates the book name input (cannot be empty)
            if(bookNameTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book name
                bookNameLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red
                bookNameTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookNameTextBox.Style.Add("border", "1px solid green");
            }

            // Validates the book isbn input (must be a 13 digit number)
            Regex isbnPattern = new Regex(@"^\d{13}$");
            if(!isbnPattern.IsMatch(bookISBNTextBox.Text))
            {
                // Set the error literal associated with the book isbn
                bookISBNLiteral.Text = "<small class='error-small'>must be a 13 digit number</small>";

                // Add a css class to the textbox that will change the border to red
                bookISBNTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookISBNTextBox.Style.Add("border", "1px solid green");
            }

            // Validates the page count input (cannot be blank)
            if(bookPageCountTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book page count
                bookPageCountLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red
                bookPageCountTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookPageCountTextBox.Style.Add("border", "1px solid green");
            }

            // Validates the authors name input (cannot be blank and must be comma separated)
            if (Regex.Matches(bookAuthorsTextBox.Text, @"\w[^,]+").Count == 0 || bookAuthorsTextBox.Text.Length == 0)
            {
                // Set error literal associated with the author names
                bookAuthorsLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to green
                bookAuthorsTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookAuthorsTextBox.Style.Add("border", "1px solid green");
            }

            // Validates the genre names input (cannot be blank and must be comma separated)
            if (Regex.Matches(bookGenresTextBox.Text, @"\w[^,]+").Count == 0 || bookGenresTextBox.Text.Length == 0)
            {
                // Set error literal associated with the author names
                bookGenresLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red
                bookGenresTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookGenresTextBox.Style.Add("border", "1px solid green");
            }

            // Validates the book summary input (cannot be blank)
            if (bookSummaryTextBox.Text.Length == 0)
            {
                // Set the error literal associated with the book summary
                bookSummaryLiteral.Text = "<small class='error-small'>cannot be blank</small>";

                // Add a css class to the textbox that will change the border to red
                bookSummaryTextBox.Style.Add("border", "1px solid red");

                // Set the valid flag to false
                validFlag = false;
            }
            else
            {
                // Add a css class to the textbox that will change the border to green
                bookSummaryTextBox.Style.Add("border", "1px solid green");
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

        /**
         * Resets the border property for all the input boxes
         */
        protected void InitInputBorders()
        {
            bookNameTextBox.Style.Remove("border");
            bookISBNTextBox.Style.Remove("border");
            bookPageCountTextBox.Style.Remove("border");
            bookAuthorsTextBox.Style.Remove("border");
            bookGenresTextBox.Style.Remove("border");
            bookSummaryTextBox.Style.Remove("border");
        }

        /**
         * Generates a list of strings form the input using the split method
         * @param input the input string
         * @return inputList an array of strings that represent the input values
         */
        protected String[] GenerateInputList(String input)
        {
            // Split the text input by commas
            String[] inputList = input.Split(',');

            // Process each element in the list
            for(int i = 0; i < inputList.Length; i++)
            {
                // Trim the leading and trailing whitespace
                inputList[i] = inputList[i].Trim();

                // Split the elements contents by spaces
                String[] inputListSplit = inputList[i].Split();

                // Capitalize each word in the input
                for(int j = 0; j < inputListSplit.Length; j++)
                {
                    inputListSplit[j] = inputListSplit[j].Trim().ToLower().Substring(0, 1).ToUpper() + inputListSplit[j].Trim().ToLower().Substring(1);
                }

                // Join the list back into one string
                inputList[i] = String.Join(" ", inputListSplit);
            }

            // Return an array of string after processing the strings
            return inputList;
        }

        /**
         * Checks if the given author is in the Author table
         * @param author the author name
         */
        protected bool IsInAuthorTable(String authorName)
        {
            // Construct the select command
            String authorSelectCommand = "SELECT AuthorName FROM Author WHERE AuthorName = @authorName";

            // Boolean flag to keep track whether the author was found in the table
            bool isInDB = false;

            // Initialize the sql connection
            using (SqlConnection myConnection = new SqlConnection(myConnectionString))
            {
                // Initialize the sql command
                using (SqlCommand myCommand = new SqlCommand(authorSelectCommand, myConnection))
                {
                    // Add the parameters
                    myCommand.Parameters.AddWithValue("authorName", author);

                    // Open the connection
                    myConnection.Open();

                    // Execute the command
                    String resultAuthor = (String)myCommand.ExecuteScalar();

                    // Close the connection
                    myConnection.Close();

                    // Set the boolean flag to true if the author was found in the table
                    if(resultAuthor != null)
                    {
                        isInDB = true;
                    }
                }
            }

            // Return the boolean flag
            return isInDB;
        }
    }
}