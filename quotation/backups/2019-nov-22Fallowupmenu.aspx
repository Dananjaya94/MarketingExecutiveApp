<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fallowupmenu.aspx.cs" Inherits="AllIslandPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
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
            $("#TextBoxfrom").datepicker();
        });

        $(function () {
            $("#TextBoxTo").datepicker();
        });
        
  </script>





</head>
<body>
<form id="form1" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;
;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Fallowup Update</h1>
    <!--customer details-->   
    <div class="form-group">
  
        <div class="row">
            <div class="col-lg-12">
<div class="panel-body" style="padding-bottom: 0px;">
    <div class="col-sm-6" >

<table align="center">

    <tr>

<td style="padding: 5px;"><asp:Label ID="Label2" runat="server" Text="From"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="TextBoxfrom"  runat="server" class="form-control"  Width="286px" ></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label1" runat="server" Text="To"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="TextBoxTo"  runat="server" class="form-control"  Width="286px"></asp:TextBox>

</td> 

    </tr>




    </table>
    </div>


    <div class="col-sm-4" >
        <table align="center">
            <tr >

<td style="padding: 5px;">

<asp:Button ID="btnLoadEmp" runat="server" Text=" View " 

class="form-control" Style="background-color:dodgerblue; color:black;font-weight:bold;padding-left:48px;padding-right:48px" OnClick="btnLoadEmp_Click"/> </td> 



</tr>



            </table>

        </div>

</div>
                </div>
            </div>

                    <div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" >
                            <asp:GridView ID="grid3" runat="server"  OnRowCommand="grid3_RowCommand"  CssClass="table table-striped table-bordered table-hover" AutoPostBack="true" AutoGenerateColumns="False"  ShowFooter="true">
                                        <Columns>
                   <asp:BoundField DataField="mev_seq_no" HeaderText="mev_seq_no"  />
                    <asp:BoundField DataField="INSURED" HeaderText="INSURED"  />
                    <asp:BoundField DataField="SUM_INSURED" HeaderText="SUM_INSURED"  />
                    <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT"  />
                    <asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE"  />
                    <asp:BoundField DataField="FOLLOWUP_DATE" HeaderText="FOLLOWUP_DATE"  />
                    <asp:BoundField DataField="VEHICLE_NO" HeaderText="VEHICLE_NO"  />
                    <asp:BoundField DataField="REMARKS" HeaderText="REMARKS"  />
                

            

                  <asp:TemplateField  HeaderText = "Visit">  
                <ItemTemplate>  
                     
                    <asp:LinkButton ID="btnViewdoc"   Text="visit" runat="server" CommandName="visit" CommandArgument="<%# Container.DataItemIndex %>"/>
                </ItemTemplate>  
            </asp:TemplateField>



             
            </Columns>
                            
                            </asp:GridView>
                            </asp:Panel>
                             </div>

                             <asp:TextBox ID="TextBoxbranch" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
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
