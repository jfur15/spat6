<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" href="https://bootswatch.com/united/bootstrap.css"/>
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body style="height: 515px">
    <form id="form1" runat="server">
    <div>
    
        <div style="float: left; width: 374px; height: 498px;">
            <asp:Button ID="submitButton" runat="server" Height="23px" Text="Submit" Width="305px" OnClick="submitButton_Click" />
            <asp:Button ID="buttonPreload" runat="server" Text="Preload" OnClick="buttonPreload_Click" />
            <br />
            <div id="divTextbox" style="height: 460px; width: 389px" runat="server">
                <asp:TextBox ID="TextBox1" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox2" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox3" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox4" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox5" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox6" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox7" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox8" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox9" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox10" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox11" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox12" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox13" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox14" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox15" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox16" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox17" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox18" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox19" runat="server" Width="360px"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBox20" runat="server" Width="360px"></asp:TextBox>
            </div>
            <br />
        </div>
        <div style="float: right; width: 516px; height: 470px;">
            <asp:Button ID="buttonClear" class="btn btn-danger" runat="server" Text="Clear" />
            <br />
            <asp:TextBox ID="textBoxFinal" runat="server" Height="100%" Width="100%" TextMode="MultiLine"></asp:TextBox>
        </div>
    
    </div>
    </form>
</body>
</html>
