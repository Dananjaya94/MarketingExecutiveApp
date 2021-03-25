 <%@ Page Language="C#" AutoEventWireup="true" CodeFile="specialprompvisit.aspx.cs" Inherits="AllIslandPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Plan Data Entry</title>
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
            $("#TextBoxvisitdate").datepicker();
        });


    </script>



</head>
<body>
<form id="form1" runat="server">
<div class="container" style="padding-left:5%;background-color:#f9c95d;">

    <!--customer details-->   
    <div class="form-group">

    <asp:Label ID="LabelMsg" Visible="true" runat="server" style="padding-left:10px;padding-right:10px;" Text="" Font-Bold="true" ForeColor="White"></asp:Label>
        </br>


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <label for="email">ME Code</label>
        <asp:TextBox ID="txtmecode"   class="form-control" Width="60%" runat="server" ReadOnly="true"></asp:TextBox></br>
     
        <label for="email">Branch Code</label>
        <asp:TextBox ID="txtbranchcode"   class="form-control" Width="60%" runat="server" ReadOnly="true"></asp:TextBox></br>
        
     <label for="email">Visit Date</label>
        <asp:TextBox ID="TextBoxvisitdate"   class="form-control" Width="60%" runat="server"></asp:TextBox></br>

           
         

              <label for="email">Visit Type</label>
        <asp:DropDownList ID="DropDownListvisittype" AppendDataBoundItems="true" class="form-control" Width="20%" runat="server">
        
            
        </asp:DropDownList></br>

                      <label for="email">Location</label>
        <asp:TextBox ID="TextBoxlocation" placeholder="enter location" class="form-control" Width="40%" runat="server"></asp:TextBox><br />
        
       
        </br>
         <%--             <label for="email">Month</label>
        <asp:TextBox ID="TextBoxmonth" placeholder="enter month" class="form-control" Width="60%" runat="server"></asp:TextBox></br>--%>

              <label for="email">Remark</label>
        <asp:TextBox ID="TextBoxremark"  class="form-control" Width="60%" runat="server"></asp:TextBox></br>
                    
    <div class="form-group">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" class="btn btn-primary" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonClear" runat="server" Text="Clear" class="btn btn-success" OnClick="ButtonClear_Click" />
        <asp:Button ID="ButtonBack" runat="server" Text="Back" class="btn btn-danger" OnClick="ButtonBack_Click"/>
    </div> 

</div>
<script type="text/javascript" src="assets/jss/jquery.min.js"></script>
    <script src="assets/jss/jquery-ui.js"></script>
  
       
      </script>
  </form>
</body>
</html>
