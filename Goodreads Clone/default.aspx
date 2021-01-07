<%@ Page Title="GoodReads | Home"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="default.aspx.cs"
    Inherits="Goodreads_Clone._default" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PageHead" runat="server"></asp:Content>

<asp:Content ID="MainContentHeader" ContentPlaceHolderID="MainContentHeader" runat="server">
    <h1>My Books</h1>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Show all the books in the database -->
    <div class="table-container">
        <asp:GridView ID="allBooksGV" runat="server"
            CssClass="all-books-table">
        </asp:GridView>
    </div>

    <!-- Hidden p tag to get the selected row ISBN value to use in the modal -->
    <p id="SelectedISBN" visible="false" runat="server">Here's some text</p>
    <p id="SelectedTitle" visible="false" runat="server"></p>
    <p id="SelectedAuthors" visible="false" runat="server"></p>
    <p id="SelectedGenres" visible="false" runat="server"></p>

    <!-- Modal for Adding a Book to a Reading List -->
    <div class="modal">
        <asp:SqlDataSource ID="ModalSDS" runat="server"></asp:SqlDataSource>
        <div class="modal-header">
            <div class="mh-label-header">
                <small>Title:</small>
                <h1>Outliers: The Story of Success</h1>
            </div>
            <input type="button" class="close-button" value="&times;" />
        </div>
        <hr />

        <div class="modal-content">
            <div class="mc-book-meta">
                <div class="smc-isbn">
                    <small>ISBN-13:</small>
                    <h5>9780316017923</h5>
                </div>
                <div class="smc-pagecount">
                    <small>Page Count:</small>
                    <h5>309 Pages</h5>
                </div>
            </div>

            <div class="mc-author">
                <small>Author(s):</small>
                <h3>Malcolm Gladwell</h3>
            </div>
            <div class="mc-genre">
                <small>Genre(s):</small>
                <h3>Non Fiction, Psychology, Business</h3>
            </div>
            
            <div class="mc-summary">
                <small>Summary:</small>
                <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam id mauris finibus, sagittis
                    est et, pellentesque libero. Morbi at nisi molestie, vulputate erat fringilla, porta eros. Morbi
                    nec nibh pulvinar nisi ultricies pellentesque non eu lacus. Sed auctor iaculis turpis, sed
                    ultrices metus maximus ut. Donec congue accumsan malesuada. Etiam eu ultricies tortor, in dictum
                    odio. Phasellus et rutrum sapien, eu molestie leo. Sed in nisi augue. Vestibulum euismod pretium
                    risus, sed rutrum enim. Sed accumsan, leo vel commodo hendrerit, eros magna sollicitudin odio, eu
                    semper urna sem eu neque. Aenean sagittis, ipsum id pharetra ornare, leo nisi porttitor lectus,
                    vestibulum mollis nisi arcu a purus. Ut mattis vel dui eu elementum. Pellentesque et lectus ornare,
                    porta enim a, tempus augue. Sed interdum nisi a suscipit iaculis. Praesent vitae rutrum odio, non
                    vestibulum mauris. Nunc in magna velit. Donec porttitor magna sem, et auctor leo suscipit ullamcorper.
                    Nulla facilisi. Vestibulum fauc
                </p>
            </div>
            
        </div>

        <div class="modal-footer">
            <asp:SqlDataSource ID="readingListsSDS" runat="server"
                ConnectionString="<%$ ConnectionStrings:ReadingDBConnectionString %>"
                SelectCommand="SELECT * FROM [ReadingList]">
            </asp:SqlDataSource>
            <div class="mf-selectbutton">
                <asp:DropDownList ID="readingListsDDL" runat="server"
                    DataSourceID="readingListsSDS"
                    DataTextField="ReadingListName"
                    DataValueField="ReadingListID">
                </asp:DropDownList>

                <input id="AddToListButton" type="button" value="Add to List" />
            </div>
        </div>
    </div>
</asp:Content>
