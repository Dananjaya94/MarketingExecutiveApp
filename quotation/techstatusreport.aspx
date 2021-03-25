<%@ Page Language="C#" AutoEventWireup="true" CodeFile="techstatusreport.aspx.cs" Inherits="techstatusreport" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dailly call sheet</title>
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
       body {
           background-color: #fefff4;
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
<form id="form2" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;
;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Task Status</h1>
    <!--customer details-->   
    <div class="form-group">
  
<%--<div class="well" style="margin-top: 5px;" >

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
            </div>--%>

        <div class="row">
            <div class="col-lg-2">
                        <asp:Button ID="Buttonback"  runat="server" Text="Back" 
                             
class="form-control" Style="background-color:forestgreen; color:black;font-weight:bold" Width="100px" OnClick="Buttonback_Click"/>
            </div>
            <div class="col-lg-10"></div>
           </div>



                    <div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" >
                           <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" width="100%" CssClass="table table-striped table-bordered table-hover" AutoPostBack="true"  
                                ShowFooter="true" OnRowCommand="grid1_RowCommand">
                   
                                <Columns>
                                     <asp:BoundField DataField="Trs_ref_no" HeaderText="REF_NO" SortExpression="Trs_ref_no"/>
                                     <asp:BoundField DataField="trs_policy_no" HeaderText="POLICY_NO" SortExpression="trs_policy_no"/>
                                     <asp:BoundField DataField="request_type" HeaderText="REQUESTED_TYPE" SortExpression="request_type"/>
                                     <asp:BoundField DataField="TRS_USER_COMT" HeaderText="USER_COMMENT" SortExpression="TRS_USER_COMT"/>
                                     <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" SortExpression="PRODUCT"/>
                                     <asp:BoundField DataField="TRS_BRN_CODE" HeaderText="BRANCH" SortExpression="TRS_BRN_CODE" />
                                     <asp:BoundField DataField="TRS_ME_CODE" HeaderText="ME" SortExpression="TRS_ME_CODE"/>
                                     <asp:BoundField DataField="REQUEST_DATE" HeaderText="REQUEST_DATE" SortExpression="REQUEST_DATE"/>
                                     <asp:BoundField DataField="ASSIGNED_DATE" HeaderText="ASSIGNED_DATE" SortExpression="ASSIGNED_DATE"/>
                                     <asp:BoundField DataField="PROCESS_START_DATE" HeaderText="PROCESS_START_DATE" SortExpression="PROCESS_START_DATE"/>
                                     <asp:BoundField DataField="COMPLETED_DATE" HeaderText="COMPLETED_DATE" SortExpression="COMPLETED_DATE"/>
                                     <asp:BoundField DataField="ASSIGNED_USER" HeaderText="ASSIGNED_USER" SortExpression="ASSIGNED_USER"/>
                                     <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="CUSTOMER_NAME" SortExpression="CUSTOMER_NAME"/>
                                     <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS"/>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton Text="View Details" runat="server" CommandName="Details" CommandArgument="<%# Container.DataItemIndex %>" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton Text="View Document" runat="server" CommandName="Document" CommandArgument="<%# Container.DataItemIndex %>" />
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


