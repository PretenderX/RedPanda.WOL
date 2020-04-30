<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RedPanda.WOL._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <asp:Label ID="Label2" runat="server" ForeColor="#0066FF" Text="在下方输入通电的物理网卡的MAC地址（例如：00-E0-4C-27-CC-64或00:E0:4C:27:CC:64），然后点击唤醒，等待一会尝试远程操作你的电脑。"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="MAC地址："></asp:Label>
        <asp:TextBox ID="macAddress" runat="server"></asp:TextBox>
        <asp:Button ID="btnWakeUp" runat="server" OnClick="btnWakeUp_Click" Text="唤醒" />
        <asp:Label ID="msgLabel" runat="server" ForeColor="#3399FF"></asp:Label>
    </div>

</asp:Content>
