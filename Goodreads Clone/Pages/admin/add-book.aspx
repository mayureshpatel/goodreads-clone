<%@ Page Title="GoodReads | Add New Book"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="add-book.aspx.cs"
    Inherits="Goodreads_Clone.Pages.admin.add_book" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PageHead" runat="server">

</asp:Content>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="MainContentHeader" runat="server">
    <h1>Add Book</h1>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- FORM TO ADD A NEW BOOK -->
    <form class="add-book-form" runat="server">
        <div class="form-section">
            <asp:Label ID="bookNameLabel" runat="server" AssociatedControlID="bookNameTextBox" Text="Name:"></asp:Label>
            <asp:TextBox ID="bookNameTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="bookISBNLabel" runat="server" AssociatedControlID="bookISBNTextBox" Text="ISBN:"></asp:Label>
            <asp:TextBox ID="bookISBNTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="bookPageCountLabel" runat="server" AssociatedControlID="bookPageCountTextBox" Text="Page Count:"></asp:Label>
            <asp:TextBox ID="bookPageCountTextBox" runat="server"></asp:TextBox>
        </div>

        <div class="form-section">
            <asp:Label ID="bookAuthorsLabel" runat="server" AssociatedControlID="bookAuthorsTextBox" Text="Author(s):"></asp:Label>
            <asp:TextBox ID="bookAuthorsTextBox" runat="server"></asp:TextBox>

            <asp:Label ID="bookGenresLabel" runat="server" AssociatedControlID="bookGenresTextBox" Text="Genre(s):"></asp:Label>
            <asp:TextBox ID="bookGenresTextBox" runat="server"></asp:TextBox>
        </div>

        <div class="form-section">
            <asp:Label ID="bookSummaryLabel" runat="server" AssociatedControlID="bookSummaryTextBox" Text="Summary:"></asp:Label>
            <asp:TextBox ID="bookSummaryTextBox" runat="server" TextMode="MultiLine" Columns="100" Rows="50"></asp:TextBox>
        </div>

        <div class="form-section">
            <asp:Button ID="newBookSubmitButton" runat="server" Text="Add New Book" />
        </div>
    </form>
</asp:Content>
