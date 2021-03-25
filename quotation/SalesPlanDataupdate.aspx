<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalesPlanDataupdate.aspx.cs" Inherits="AllIslandPromotion" %>

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

       .ui-datepicker-calendar {display: none;}​
     
   </style>
       <link rel="stylesheet" href="assets/csss/jquery-ui.css">
          <script>
              

              $(function () {
                  $('#TextBoxyear').datepicker({
                      changeMonth: true,
                      changeYear: true,
                      showButtonPanel: true,
                      dateFormat: 'MM yy',
                      onClose: function (dateText, inst) {
                        var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                          var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                          $(this).datepicker('setDate', new Date(year,month,1));
                      }
                  });


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

            <label for="email">ME Code</label>
        <asp:TextBox ID="txtmecode"   class="form-control" Width="60%" runat="server" ReadOnly="true"></asp:TextBox></br>
     
        <label for="email">Branch Code</label>
        <asp:TextBox ID="txtbranchcode"   class="form-control" Width="60%" runat="server" ReadOnly="true"></asp:TextBox></br>
        
    

           
         

              <label for="email">Motor/Non Motor</label>
        <asp:DropDownList ID="DropDownListtype" AppendDataBoundItems="true" class="form-control" Width="20%" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select   --</asp:ListItem>
            <asp:ListItem Value="M">Motor</asp:ListItem>
            <asp:ListItem Value="N">Non Motor</asp:ListItem>
            
        </asp:DropDownList></br>

                      <label for="email">Year</label>
        <asp:TextBox ID="TextBoxyear" placeholder="enter year" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
 
          <asp:Button ID="Buttonview" runat="server" Text="View" Width="20%"  class="btn btn-primary"  style="padding-left:10px" OnClick="Buttonview_Click" />
          
            <br />

              <label for="email">Last Year Amount</label>
        <asp:TextBox ID="TextBoxlastyearcost" placeholder="enter last year" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
                     
                   <label for="email">New Plan</label>
        <asp:TextBox ID="TextBoxnewplan" placeholder="enter new plan" class="form-control" Width="60%" runat="server"></asp:TextBox></br>

                   <label for="email">Renewal Plan</label>
        <asp:TextBox ID="TextBoxrenewalplan" placeholder="enter renewal plan" class="form-control" Width="60%" runat="server"></asp:TextBox></br>

          <asp:UpdatePanel runat="server"><ContentTemplate>
            <label for="email">Total :</label>
        <asp:label ID="txttotal" Width="60%" runat="server" style="display:inline-block;width: 50%;font-size: large;font-weight: bold;" ></asp:label></br>
        </ContentTemplate></asp:UpdatePanel>
      
        
       
     
       

        

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
        <asp:Button ID="ButtonSave" runat="server" Text="Update" class="btn btn-primary" OnClick="ButtonSave_Click" />
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

    <script>

                     $(document).ready(function(){ 
                  $("#<%=TextBoxrenewalplan.ClientID %>").keyup(function () {

                      var newplan = $("#<%=TextBoxnewplan.ClientID %>").val();
                      var reneplan = $("#<%=TextBoxrenewalplan.ClientID %>").val();

                      var tot = parseInt(newplan) + parseInt(reneplan);
                      $("#<%=txttotal.ClientID %>").text(tot);

                  });

                     });


        
               $(document).ready(function(){ 
                  $("#<%=TextBoxnewplan.ClientID %>").keyup(function () {

                      var newplan = $("#<%=TextBoxnewplan.ClientID %>").val();
                      var reneplan = $("#<%=TextBoxrenewalplan.ClientID %>").val();

                      var tot = parseInt(newplan) + parseInt(reneplan);
                      $("#<%=txttotal.ClientID %>").text(tot);

                  });
              });
    </script>
  </form>
</body>
</html>
