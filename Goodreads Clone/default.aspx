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
        <asp:GridView ID="allBooksGV" runat="server" CssClass="all-books-table"></asp:GridView>
    </div>
</asp:Content>
