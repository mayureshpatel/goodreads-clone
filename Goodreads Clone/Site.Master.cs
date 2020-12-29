using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Goodreads_Clone
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected String myConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReadingDBConnectionString"].ConnectionString;
        protected DataTable listsTable = new DataTable();
        protected DataTable genresTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                String selectListsCommand = "SELECT TOP(5) ReadingList.ReadingListName, COUNT(ReadingListAffiliations.FK_BookID) AS BookCount" +
                    " FROM ReadingList" +
                    " INNER JOIN ReadingListAffiliations ON ReadingList.ReadingListID = ReadingListAffiliations.FK_ReadingListID" +
                    " GROUP BY ReadingList.ReadingListName" +
                    " ORDER BY BookCount DESC";

                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand(selectListsCommand, myConnection))
                    {
                        SqlDataAdapter listsReader = new SqlDataAdapter(myCommand);

                        DataSet listsDS = new DataSet();
                        listsReader.Fill(listsDS);

                        listsTable = listsDS.Tables[0].Copy();

                        BrowseListItem01.InnerHtml = (String) listsTable.Rows[0]["ReadingListName"];
                        BrowseListItem02.InnerHtml = (String) listsTable.Rows[1]["ReadingListName"];
                        BrowseListItem03.InnerHtml = (String) listsTable.Rows[2]["ReadingListName"];
                        BrowseListItem04.InnerHtml = (String) listsTable.Rows[3]["ReadingListName"];
                        BrowseListItem05.InnerHtml = (String) listsTable.Rows[4]["ReadingListName"];
                    }
                }

                String selectGenresCommand = "SELECT Genre.GenreName, COUNT(GenreAffiliations.FK_BookID) AS BookCount" +
                    " FROM Genre" +
                    " INNER JOIN GenreAffiliations ON Genre.GenreID = GenreAffiliations.FK_GenreID" +
                    " GROUP BY Genre.GenreName HAVING(NOT (Genre.GenreName = 'Non Fiction')) AND(NOT(Genre.GenreName = 'Fiction'))" +
                    " ORDER BY BookCount DESC";

                using (SqlConnection myConnection = new SqlConnection(myConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand(selectGenresCommand, myConnection))
                    {
                        SqlDataAdapter listsReader = new SqlDataAdapter(myCommand);

                        DataSet listsDS = new DataSet();
                        listsReader.Fill(listsDS);

                        genresTable = listsDS.Tables[0].Copy();

                        BrowseGenreItem01.InnerHtml = (String)genresTable.Rows[0]["GenreName"];
                        BrowseGenreItem02.InnerHtml = (String)genresTable.Rows[1]["GenreName"];
                        BrowseGenreItem03.InnerHtml = (String)genresTable.Rows[2]["GenreName"];
                        BrowseGenreItem04.InnerHtml = (String)genresTable.Rows[3]["GenreName"];
                        BrowseGenreItem05.InnerHtml = (String)genresTable.Rows[4]["GenreName"];
                    }
                }
            }
        }
    }
}