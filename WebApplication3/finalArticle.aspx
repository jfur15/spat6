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

  <script type="text/javascript">

      function selectText() {
          if (document.selection) {
              var range = document.body.createTextRange();
              range.moveToElementText(document.getElementById("finalTextBox"));
              range.select();
          } else if (window.getSelection) {
              var range = document.createRange();
              range.selectNode(document.getElementById("finalTextBox"));
              window.getSelection().addRange(range);
          }
          
      }
  </script>

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
            border:solid 1px darkred;
        }
        .btn{
            margin-top:2%;
        }

        #finalTextBox{
            height:100%;
        }

        .navbar { min-height:50px; height: 50px; }
        .row{margin-top: 50px;}
        .col-lg-2{margin-top: 50px;}
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
        .dropdown-menu > li{
            margin-left:2%; 
            margin-right:2%;
        }
        
        .affix > .btn{
            vertical-align:bottom;
        }
  </style>
<link rel="icon" href="logomini.png">
</head> 
<body>
    <form runat="server"> 
        <nav class="navbar navbar-default  navbar-fixed-top">


            <button style="margin:0.5% 1% 0% 1%" type="button" data-toggle="dropdown"  class="btn btn-primary navbar-btn dropdown-toggle "><span class="glyphicon glyphicon-option-horizontal"></span></button> 
            <ul class="dropdown-menu">
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Article 1" /></li>
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Article 2" /></li>
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Article 3" /></li>
                <li role="separator" class="divider"></li>
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Edit inputs" /></li>
                <a href="urlListPage.aspx" class ="btn btn-primary btn-block" role="button">Create new article</a>
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Download article" /></li>
                <li><asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Select all" onClientClick="selectText(); return false"/></li>

            </ul>

            <div class="navbar-brand navbar-right">
                <img alt="Research Assistant" src="logomini.png">
            </div>
 
        </nav>   
        <div class="container-fluid">
            <div class="row">
                
                <div class="col-lg-2 affix">
                    
                    <button class="btn btn-primary btn-block">Trump kicks puppies</button>
                    <button class="btn btn-primary btn-block">Trump chokes kittens</button>
                    <button class="btn btn-primary btn-block">Trump closes schools</button>
                    <hr />
                    <button class="btn btn-primary btn-block">Edit article inputs</button>
                    <asp:Button runat="server" CssClass="btn btn-primary btn-block" onclick="btnDownloadArticle" Text="Download article" />
                    <asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Select all" onClientClick="selectText(); return false"/>
                    
                    <a href="urlListPage.aspx" class ="btn btn-primary btn-block" role="button" onclick="return confirm('Are you sure you want to destroy this article?');">Create new article</a>

                </div>
            </div>

            <div class="row">

                <div class="col-lg-2">

                    <br />
                </div>

                <div style="font-size:large;" class="col-lg-8" id="finalDiv" runat="server">
                </div>

                <div class="col-lg-2">

                    <br />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
