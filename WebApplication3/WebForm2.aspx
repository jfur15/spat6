﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication3.WebForm2" %>

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
			background: url( http://i.imgur.com/98NRuUJ.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;

            color:black;
		}

        hr{
            border:solid 5px black;
            color:darkred;
        }
        .btn{
            margin-top:2%;
        }

        .form-group{
            outline: solid 2px black;
        }

  </style>
</head> 
<body>
    <form runat="server">       
        <div class="container-fluid">

            <div class="row">

                <div class="col-lg-2">
                    <br />
                </div>

                <div class="col-lg-8">
                    
                    <div id="textboxdiv" runat="server" class="form-group" style="margin-top:20%">
                    <h2">Article URLs</h2>
                    <asp:TextBox class="form-control" runat="server" placeholder="URL"></asp:TextBox>
                        
                    <asp:TextBox class="form-control" runat="server" placeholder="URL"></asp:TextBox>

                    </div>
                    <asp:Button runat="server" OnClick="submitbutton_click" class="btn btn-default" text="Submit"/>
                    <asp:Button  runat="server" OnClick="clearbutton_click" class="btn btn-default" text="Clear"/>
                </div>
                <div class="col-lg-2">
                    <br />
                </div>


            </div>

        </div>
    </form>
</body>
</html>
