<%@ Page Title="GoodReads | Add New Book"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="add-book.aspx.cs"
    Inherits="Goodreads_Clone.Pages.admin.add_book" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PageHead" runat="server">
    <link href="../../Styles/Pages_Styles/add-book.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="MainContentHeader" runat="server">
    <h1>Add Book</h1>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- FORM TO ADD A NEW BOOK -->
    <form class="add-book-form" runat="server">
        <div class="form-section book-isbn-page-section">
            <div class="form-item">
                <asp:Label ID="bookNameLabel" runat="server" AssociatedControlID="bookNameTextBox" Text="Name:"></asp:Label>
                <asp:TextBox ID="bookNameTextBox" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-item">
                <asp:Label ID="bookISBNLabel" runat="server" AssociatedControlID="bookISBNTextBox" Text="ISBN:"></asp:Label>
                <asp:TextBox ID="bookISBNTextBox" runat="server" placeholder="ISBN-13"></asp:TextBox>
            </div>
            
            <div class="form-item">
                <asp:Label ID="bookPageCountLabel" runat="server" AssociatedControlID="bookPageCountTextBox" Text="Page Count:"></asp:Label>
                <asp:TextBox ID="bookPageCountTextBox" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="form-section author-genre-section">
            <div class="form-item">
                <asp:Label ID="bookAuthorsLabel" runat="server" AssociatedControlID="bookAuthorsTextBox" Text="Author(s):"></asp:Label>
                <asp:TextBox ID="bookAuthorsTextBox" runat="server" placeholder="Comma Separated Names"></asp:TextBox>
            </div>
            
            <div class="form-item">
                <asp:Label ID="bookGenresLabel" runat="server" AssociatedControlID="bookGenresTextBox" Text="Genre(s):"></asp:Label>
                <asp:TextBox ID="bookGenresTextBox" runat="server" placeholder="Comma Separated Genres"></asp:TextBox>
            </div>
            
        </div>

        <div class="form-section summary-section">
            <div class="form-item">
                <asp:Label ID="bookSummaryLabel" runat="server" AssociatedControlID="bookSummaryTextBox" Text="Summary:"></asp:Label>
                <asp:TextBox ID="bookSummaryTextBox" runat="server" TextMode="MultiLine" Rows="10" placeholder="Max 2,000 Characters"></asp:TextBox>
            </div>
        </div>

        <div class="form-section submit-section">
            <div class="form-item">
                <asp:Button ID="newBookSubmitButton" runat="server" Text="Add New Book" />
            </div>
        </div>
    </form>
</asp:Content>
