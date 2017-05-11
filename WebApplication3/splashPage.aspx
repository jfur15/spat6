<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="splashPage.aspx.cs" Inherits="WebApplication3.WebForm3" %>

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
			background: url(write.jpg)  no-repeat center center fixed; 
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
                    <div style="text-align: center; margin-top:25%">
                    <img src="logo.png" style="width:50%"/>
                         <br /> 
                        <br /> 
                        <hr  width="5%" />
                         <br />
                    <h4 style="padding-left:5%;padding-right:5%;"> 
                        The objectively superior way to consume the mainstream media's lies.  <br /> <br />
                        You give us the links, we do the rest. 
                        Inform yourself using our scientifically sound methods. Insert catchy slogan here.
                        Information wants to be free. <br />   <br />
                        
</h4>
                        <hr  width="5%" />
                    <a href="urlListPage.aspx" class="btn btn-primary btn-md" runat="server">Plans start at $99/yr </a>
                         <a href="urlListPage.aspx" class="btn btn-primary btn-md" runat="server">Get started free </a>    
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
