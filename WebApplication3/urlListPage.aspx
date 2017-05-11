<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="urlListPage.aspx.cs" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<head>
  <title>Research Assistant</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://bootswatch.com/united/bootstrap.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.0/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
  <style>
      		body {
			background: url( write.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
           
            color:black;
		}

        hr{
            
        }
        .btn{
            margin-top:2%;
        }

        .input-group{
            padding: 10%;
             background-color: rgba(225,225,225, 0.4);
        }

  </style>
<link rel="icon" href="logomini.png">
</head> 
<body>
    <form runat="server">       
        <div class="container-fluid">

            <div class="row">

                <div class="col-lg-2">
                    <br />
                </div>

                <div class="col-lg-8">
                    
                    <div id="divTextbox" runat="server" class="input-group" style="margin-top:20%">
                    <h2">Article URLs</h2>
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                        <asp:Textbox runat="server" CssClass="form-control" placeholder="URL" />
                    </div>
                    <asp:Button runat="server" OnClick="submitbutton_Click" class="btn btn-default" text="Submit"/>
                    <asp:Button runat="server" OnClick=" buttonPreload_Click" class="btn btn-default" text="Preload"/>
                    <asp:Button  runat="server" OnClick="clearbutton_click" class="btn btn-default" text="Clear All"/>

                </div>
                <div class="col-lg-2">
                    <br />
                </div>


            </div>

        </div>
    </form>
</body>
</html>
