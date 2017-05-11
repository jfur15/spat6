<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="finalArticle.aspx.cs" Inherits="WebApplication3.finalArticle" %>
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
            border:solid 5px black;
            color:darkred;
        }
        .btn{
            margin-top:2%;
        }

        .form-group{
            margin-top:2%;
        }
        .navbar { min-height:50px; height: 50px; }
        .navbar > .navbar-brand{
            padding: 0.25% 0% 0.25% 0%;
            margin-right:1%;
             object-fit:contain;
            height:100%;
        }
        .navbar > .navbar-brand > img{
            object-fit:contain;
            height:100%;
        }

        

  </style>
<link rel="icon" href="logomini.png">
</head> 
<body>
    <form runat="server"> 
        <nav class="navbar navbar-default  navbar-fixed-top">

            <button style="margin:0.5% 1% 0% 1%" type="button" class="btn btn-primary navbar-btn"><span class="glyphicon glyphicon-option-horizontal"></span></button>



            <div class="navbar-brand navbar-right">
                <img alt="Research Assistant" src="logomini.png">
            </div>
 
        </nav>   
        <div class="container-fluid">

            <div class="row">

                <div class="col-lg-2">
                    <br />
                </div>

                <div style="font-size:large;" class="col-lg-8 form-group" id="finalDiv" runat="server">
                 
                    </div>
                </div>
                   <div class="col-lg-2">

                       <br />
                </div>

            </div>
    </form>
</body>
</html>
