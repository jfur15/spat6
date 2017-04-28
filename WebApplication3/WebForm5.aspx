<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication3.WebForm2" %>

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
			background: url( http://i.imgur.com/trTp8Hx.jpg) no-repeat center center fixed; 
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
		}


      .jumbotron{
                margin-top:25%;
              -webkit-border-radius: 10px;
                -moz-border-radius: 10px;
                border-radius: 10px;
                border: 3px solid black;
                background-color: rgba(255,255,255, 0.7);
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

                <div class="col-lg-8 ">
                    <div class="jumbotron">
                    <h1>Research Assistant</h1>
                        <hr />
                    <p>The objectively superior way to consume the mainstream media's lies. Inform yourself and others using our scientifically sound methods. You give us the links, we do the rest. 
                       <br /><br />
                        <i>Because information wants to be free.</i></p>
                        <hr />
                    <asp:Button  class="btn btn-primary btn-lg" runat="server" text="  Plans start at $99/yr  "/>
                    <asp:Button  class="btn btn-primary btn-lg" runat="server" text="Get started now"/>
                     </div>
                    </div>
                </div>
                   <div class="col-lg-2">
                       <br />
                </div>

            </div>
    </form>
</body>
</html>
