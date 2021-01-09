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
        <asp:SqlDataSource ID="readingListSDS" runat="server"
            ConnectionString="<%$ ConnectionStrings:ReadingDBConnectionString %>"
            SelectCommand="SELECT * FROM [ReadingList]">
        </asp:SqlDataSource>
        <asp:Label ID="selectReadingListLabel" runat="server" Text="Select a List:"></asp:Label>
        <asp:DropDownList ID="readingListDDL" runat="server"
            AppendDataBoundItems="True"
            DataSourceID="readingListSDS"
            DataTextField="ReadingListName"
            DataValueField="ReadingListID">
            <asp:ListItem Selected="True" Text="--Select One--" Value="-1"></asp:ListItem>
            <asp:ListItem Text="New List" Value="0"></asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="newReadingListTextBox" runat="server"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server" Text="Show List" />
    </div>

    <!-- Table to show the selected data -->
    <div class="rl-list-content">
        <h2 class="rl-list-name" runat="server"></h2>
        <asp:SqlDataSource ID="readingListBooksSDS" runat="server"></asp:SqlDataSource>
        <asp:GridView ID="readingListDefaultGV" runat="server" Visible="true"></asp:GridView>
        <asp:GridView ID="readingListSelectedGV" runat="server"
            AutoGenerateColumns="false"
            Visible="false">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID" ItemStyle-CssClass="col-hidden" HeaderStyle-CssClass="col-hidden" />
                <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Authors" HeaderText="Authors" SortExpression="Authors" />
                <asp:BoundField DataField="Genres" HeaderText="Genres" SortExpression="Genres" />
                <asp:BoundField DataField="Summary" HeaderText="Summary" SortExpression="Summary" ItemStyle-CssClass="col-hidden" HeaderStyle-CssClass="col-hidden" />
                <asp:BoundField DataField="PageCount" HeaderText="PageCount" SortExpression="PageCount" ItemStyle-CssClass="col-hidden" HeaderStyle-CssClass="col-hidden" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
