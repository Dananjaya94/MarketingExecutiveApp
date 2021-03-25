<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllIslandPromotion.aspx.cs" Inherits="AllIslandPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prospective Update</title>
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
            $("#TextBoxFallowUpDate").datepicker();
        });
       
  </script>
</head>
<body>
<form id="form1" runat="server">
<div class="container" style="padding-left:5%;background-color:#d6e6f9;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Prospective Update</h1>
    <!--customer details-->   
    <div class="form-group">

    <asp:Label ID="LabelMsg" Visible="true" runat="server" style="padding-left:10px;padding-right:10px;" Text="" Font-Bold="true" ForeColor="White"></asp:Label>
        </br>
        <label for="email">Customer ID </label></br>
        <asp:Label ID="LabelCustomerId" class="form-control" Width="40%" runat="server" Text=""></asp:Label></br></br>

       <%-- <label for="email">Event</label>
       <asp:TextBox ID="DropDownListEvent" Text="" class="form-control"  Width="100%" runat="server"></asp:TextBox></br>--%>

<%--        <label for="email">Customer Title </label>
        <asp:DropDownList ID="DropDownListTitle" class="form-control" Width="100%" runat="server">
        </asp:DropDownList></br>--%>

<%--        <label for="email">Customer Type</label>
        <asp:DropDownList ID="DropDownListType" class="form-control" Width="40%" runat="server">
        <asp:ListItem Value="">-- Select Type --</asp:ListItem>
        <asp:ListItem Value="Individual">Individual</asp:ListItem>
                              <asp:ListItem Value="Cooperate">Cooperate</asp:ListItem>
     
        </asp:DropDownList></br>--%>

                    <!--buttons-->
    <div class="form-group"  style="padding-left: 100px;" >
            <asp:RadioButton ID="rbmotor" runat="server"  GroupName="gender" Text="   Motor" style="padding-right: 20px;" OnCheckedChanged="rbmotor_CheckedChanged" AutoPostBack="True" />
            <asp:RadioButton ID="rbnonmotor" runat="server"  GroupName="gender" Text="   Non Motor" style="padding-right: 20px;" OnCheckedChanged="rbnonmotor_CheckedChanged" AutoPostBack="True"/>

    </div> 

<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> --%>
        <label for="email">Class</label>
        <asp:DropDownList ID="cmbClass" runat="server" Width="100%"
                                                class="form-control" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="cmbClass_SelectedIndexChanged"></asp:DropDownList></br>

                <label for="email">cmbProduct</label>
        <asp:DropDownList ID="cmbProduct" runat="server"   Width="100%"
                                                class="form-control" AppendDataBoundItems="True" AutoPostBack="True" ></asp:DropDownList></br>
<%--</ContentTemplate>
        </asp:UpdatePanel>--%>


        <label for="email">Customer Name</label>
        <asp:TextBox ID="TextBoxCustomerName" placeholder="enter customer name" class="form-control" Width="100%" runat="server"></asp:TextBox></br>

      <%--<label for="email">Vehicle No</label>--%><asp:Label ID="lblVehi" for="email" runat="server" Text="Vehicle No" AutoPostBack="True"  Font-Bold="true"></asp:Label>
        <asp:TextBox ID="TextBoxVehNo" placeholder="enter vehicle No" class="form-control" Width="40%" runat="server"></asp:TextBox></br>

        <label for="email">Sum Insured</label>
        <asp:TextBox ID="txtsuminsured" placeholder="enter sum insured" class="form-control"  Width="40%" onkeypress="return Validate(event);"  runat="server"></asp:TextBox></br>

        <label for="email">Current Premium</label>
        <asp:TextBox ID="txtcurrpremium" placeholder="enter current premium" class="form-control" Width="40%" onkeypress="return Validate(event);"  runat="server"></asp:TextBox></br>
<span id="lblError" style="color: red"></span>
        
      <%-- <label for="email">Customer Business Reg No</label>
       <asp:TextBox ID="TextBoxCusReNo" placeholder="enter customer Bussiness Reg No " class="form-control"  Width="40%" runat="server"></asp:TextBox></br>
  

        <label for="email">Address No </label>
        <asp:TextBox ID="TextBoxAddressNo" placeholder="enter address no"  class="form-control" Width="40%" runat="server"></asp:TextBox></br>
        --%>
        <label for="email">Renewal Date </label>
        <asp:TextBox ID="TextBoxFallowUpDate"  placeholder="enter renewal date" class="form-control" Width="40%" runat="server"></asp:TextBox></br>
        
      <%--  <label for="email">Address-City</label>
        <asp:DropDownList ID="DropDownListCity" class="form-control" Width="40%" runat="server">
        </asp:DropDownList></br>--%>
       
        <label for="email">Mobile Number </label>
        <asp:TextBox ID="TextBoxMobile" placeholder="enter mobile number" onkeypress="return Validate(event);"  MaxLength="10" class="form-control" Width="40%" runat="server">
        </asp:TextBox></br>


          <label for="email">Address </label>
        <asp:TextBox ID="TextBoxAddress" placeholder="enter Address"    class="form-control" Width="40%" runat="server">
        </asp:TextBox></br>
       
        


    <%--    <label for="email"> ME</label>
        <asp:DropDownList ID="DropDownListServiceME" AppendDataBoundItems="true" class="form-control" Width="40%" runat="server">
        </asp:DropDownList></br>--%>

        <label for="email">Remarks</label>
        <asp:TextBox ID="txtremarks" placeholder="enter current premium" class="form-control" Width="40%" runat="server"></asp:TextBox></br>
         <asp:TextBox ID="TextBoxMe" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>

        <%-- <label for="email">Referance No </label>
        <asp:TextBox ID="TextBoxRefNo" placeholder="enter Reference number"  MaxLength="10" class="form-control" Width="40%" runat="server">
        </asp:TextBox>
        </br>--%>

                <label for="email"> Prospect Type</label>
        <asp:DropDownList ID="cmbprostype" AppendDataBoundItems="true" class="form-control" Width="100%" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select Prospect Type --</asp:ListItem>
            <asp:ListItem Value="LR">LOSS RENEWALS</asp:ListItem>
            <asp:ListItem Value="QL">QUOTATION LOSS</asp:ListItem>
            <asp:ListItem Value="PR">PROSPECT</asp:ListItem>
        </asp:DropDownList></br>

            <!--buttons-->
<%--    <div class="form-group">
        <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="gender" Text="Loss Renewals" style="padding-right: 20px;" />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="gender" Text="Quotation Loss" style="padding-right: 20px;"/>
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="gender" Text="Prospect"/>
    </div> --%>


    <!--buttons-->
    <div class="form-group">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" class="btn btn-primary" onclick="ButtonSave_Click"/>
        <asp:Button ID="ButtonClear" runat="server" Text="Clear" class="btn btn-success" OnClick="ButtonClear_Click" />
        <asp:Button ID="ButtonBack" runat="server" Text="Back" class="btn btn-danger" onclick="ButtonBack_Click"/>
    </div> 

</div>
<script type="text/javascript" src="assets/jss/jquery.min.js"></script>
    <script src="assets/jss/jquery-ui.js"></script>
  
       <script>
           $(function () {
               $("#TextBoxFallowUpDate").datepicker({
                   dateFormat: "dd-MM-yy"
               });

           });
           $(function () {
               $("#TextBoxRenDateCIC").datepicker({
                   dateFormat: "dd-MM-yy"
               });

           });
      </script>
  </form>
</body>
</html>
