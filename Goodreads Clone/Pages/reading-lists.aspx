<%@ Page Title="GoodReads | My Reading Lists"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="reading-lists.aspx.cs"
    Inherits="Goodreads_Clone.Pages.reading_lists" %>

<asp:Content ID="PageHead" ContentPlaceHolderID="PageHead" runat="server">
    <link href="../Styles/Pages_Styles/reading-lists.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="MainContentHeader" runat="server">
    <h1>Reading Lists</h1>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Select a reading list to display -->
    <div class="rl-select-content">
        <asp:SqlDataSource ID="readingListSDS" runat="server"></asp:SqlDataSource>
        <asp:Label ID="selectReadingListLabel" runat="server" Text="Select a List"></asp:Label>
        <asp:DropDownList ID="readingListDDL" runat="server"></asp:DropDownList>
        <asp:TextBox ID="newReadingListTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server" Text="Show List" />
    </div>
    <div class="rl-list-content">
        <h2 class="rl-list-name" runat="server"></h2>
        <asp:GridView ID="readingListGV" runat="server"></asp:GridView>
    </div>

</asp:Content>
