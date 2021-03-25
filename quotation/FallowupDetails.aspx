<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FallowupDetails.aspx.cs" Inherits="AllIslandPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fallowup Details</title>
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
            $("#TextBoxvisitDate").datepicker();
        });
        $(function () {
            $("#TextBoxnxtFallowdate").datepicker();
        });

        $(function () {
            $("#TextBoxaddbusclosdate").datepicker();
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

            <label for="email">Visit Date </label>
        <asp:TextBox ID="TextBoxvisitDate"  placeholder="enter date" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
     
        <label for="email">Next Fallowup Date</label>
        <asp:TextBox ID="TextBoxnxtFallowdate"  placeholder="enter date" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
 
              <label for="email">Business closed</label>
        <asp:DropDownList ID="DropDownListbus" AppendDataBoundItems="true" class="form-control" Width="20%" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select   --</asp:ListItem>
            <asp:ListItem Value="Y">Yes</asp:ListItem>
            <asp:ListItem Value="N">No</asp:ListItem>
            
        </asp:DropDownList></br>

                      <label for="email">Policy No</label>
        <asp:TextBox ID="TextBoxpolno" placeholder="enter policy no" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
                      <label for="email">Business closed date</label>
        <asp:TextBox ID="TextBoxaddbusclosdate" placeholder="enter business closed date" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
                     

        <label for="email">Remarks</label>
        <asp:TextBox ID="txtremarks" placeholder="enter remark" class="form-control" Width="60%" runat="server" TextMode="MultiLine"></asp:TextBox></br>
        
        <asp:TextBox ID="TextBoxbranch" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
     
        <asp:TextBox ID="TextBoxVisitNo" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>

        <%-- <label for="email">Referance No </label>
        <asp:TextBox ID="TextBoxRefNo" placeholder="enter Reference number"  MaxLength="10" class="form-control" Width="40%" runat="server">
        </asp:TextBox>
        </br>--%>

        

    <%--            <label for="email"> Prospect Type</label>
        <asp:DropDownList ID="cmbprostype" AppendDataBoundItems="true" class="form-control" Width="100%" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select Prospect Type --</asp:ListItem>
            <asp:ListItem Value="LR">LOSS RENEWALS</asp:ListItem>
            <asp:ListItem Value="QL">QUOTATION LOSS</asp:ListItem>
            <asp:ListItem Value="PR">PROSPECT</asp:ListItem>
        </asp:DropDownList></br>--%>

            <!--buttons-->
<%--    <div class="form-group">
        <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="gender" Text="Loss Renewals" style="padding-right: 20px;" />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="gender" Text="Quotation Loss" style="padding-right: 20px;"/>
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="gender" Text="Prospect"/>
    </div> --%>


    <!--buttons-->
    <div class="form-group">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" class="btn btn-primary" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonClear" runat="server" Text="Clear" class="btn btn-success" OnClick="ButtonClear_Click" />
        <asp:Button ID="ButtonBack" runat="server" Text="Back" class="btn btn-danger" OnClick="ButtonBack_Click"/>
    </div> 

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
