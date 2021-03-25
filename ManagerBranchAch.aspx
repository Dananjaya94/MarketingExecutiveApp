<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerBranchAch.aspx.cs" Inherits="quotation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BRANCH ACHIEVEMENT </title>
    <meta charset="utf-8">
   
  <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="assets/mypages/jquery.min.js"></script>
    <link rel="stylesheet" href="assets/mypages/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mypages/bootstrap-theme.css">
    <link rel="stylesheet" href="assets/mypages/jquery-ui.css">
    <script src="assets/mypages/bootstrap.min.js"></script>  
      <script src="assets/mypages/bootstrap.min.js"></script>
       <script type="text/javascript">
    function Validate(e) {
        var keyCode = e.keyCode || e.which;
        var lblError = document.getElementById("lblError");
        lblError.innerHTML = "";
 
        //Regex for Valid Characters i.e. Numbers.
        var regex = /^[0-9]+$/;
 
        //Validate TextBox value against the Regex.
        var isValid = regex.test(String.fromCharCode(keyCode));
        if (!isValid) {
            lblError.innerHTML = "Only Numbers allowed.";
        }
 
        return isValid;
    }
</script>
   <style type="text/css">
       body
       {
           background-color:#fefff4;
           }
     
   </style>
       <link rel="stylesheet" href="assets/csss/jquery-ui.css">
          <script>
        $(function () {
            $("#txtfromdate").datepicker();
        });
        $(function () {
            $("#txttodate").datepicker();
        });

    
        
  </script>





</head>
<body>
<form id="form1" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;
;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">BRANCH ACHIEVEMENT </h1>
    <!--customer details-->   
    <div class="form-group">
  
<div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" >
    <div class="col-sm-6" >

<table align="center">

    <tr>

<td style="padding: 5px;"><asp:Label ID="Label2" runat="server" Text="From"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="txtfromdate"  runat="server" class="form-control"  Width="286px" ></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label1" runat="server" Text="To"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="txttodate"  runat="server" class="form-control"  Width="286px"></asp:TextBox>

</td> 

    </tr>



    </table>
    </div>


    <div class="col-sm-4" >
        <table align="center">

       
            <tr >

<td style="padding: 5px;">

<asp:Button ID="btngetMe"  runat="server" Text=" View " 

class="form-control" Style="background-color:dodgerblue; color:black;font-weight:bold;padding-left:48px;padding-right:48px" OnClick="btngetMe_Click"/> </td> 

<td style="padding: 5px;">

<asp:Button ID="Buttonback"  runat="server" Text="Back" 

class="form-control" Style="background-color:forestgreen; color:black;font-weight:bold;padding-left:48px;padding-right:48px" OnClick="Buttonback_Click"/> </td> 



</tr>



            </table>

        </div>

</asp:Panel>
                </div>
            </div>

                    <div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" >
                           <asp:GridView ID="grid1" runat="server"  CssClass="table table-striped table-bordered table-hover" AutoPostBack="true"   ShowFooter="true">
                   
                </asp:GridView>
                            </asp:Panel>
                             </div>

         <asp:TextBox ID="TextBoxbranch" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
                         <asp:TextBox ID="TextBoximei"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
                    </div

</div>
<script type="text/javascript" src="assets/jss/jquery.min.js"></script>
    <script src="assets/jss/jquery-ui.js"></script>
  
 <%--      <script>
           $(function () {
               $("#TextBoxFallowUpDate").datepicker({
                   dateFormat: "dd-MM-yy"
               });

           });
           $(function () {
               $("#TextBoxredate").datepicker({
                   dateFormat: "dd-MM-yy"
               });

           });
      </script>--%>
  </form>
</body>
</html>

