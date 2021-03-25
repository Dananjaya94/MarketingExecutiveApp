<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report.aspx.cs" Inherits="report"%>

<!DOCTYPE html>
<html>
<head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">

<style>
body {font-family: Arial, Helvetica, sans-serif;}

.mydropdownlist1

{

color: #fff;
font-size: 15px;
padding: 5px 10px;
border-radius: 3px 3px;
background-color: #9b9b9b;
font-weight: bold;

}


.inputStyle {
    width: 100%;
    padding: 12px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    margin-top: 6px;
    margin-bottom: 16px;
    resize: vertical;
}

.buttonStyle {
    background-color: #4CAF50;
    color: white;
    padding: 12px 20px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

input[type=submit]:hover {
    background-color: #45a049;
}

.container {
    border-radius: 5px;
    background-color: #f2f2f2;
    padding: 20px;
}
</style>
<link rel="stylesheet" href="assets/css/StyleSheet.css">

<script language="javascript">
    //This script is for desable the enter key events
    function test() {
        if (window.event.keyCode == 13) {
            window.event.cancelBubble = true;
            window.event.returnValue = false;
        }
    }
  </script>

</head>
<body>
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<%--<h3>Quotation Form</h3>--%>

<div class="container" style="padding-top: 0px;">
   <form id="form1" runat="server">

   <div id="employeelistDiv" runat="server">

        <table width="100%" id="pnlGridView" runat="server" align="center" class="ContentTable">
        <tr>
            <td colspan="2" align="center">
                <h3 align="center" style="font-weight:bold">CEYLINCO GENERAL INSURANCE LTD</h3>
                <h3 align="center" style="font-weight:bold">Premium Indication</h3>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="style3">
                   
       <asp:Table ID="Table1" runat="server" class="w3-table-all" BorderStyle="Solid" GridLines="Both">
           <asp:TableRow>
               <asp:TableCell Width="50%">Name</asp:TableCell>
               <asp:TableCell Width="50%"><asp:Label ID="LabelName" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>

           <asp:TableRow>
               <asp:TableCell Width="50%">Vehicle No</asp:TableCell>
               <asp:TableCell Width="50%"><asp:Label ID="LabelVehicle" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Width="50%">Product</asp:TableCell>
               <asp:TableCell Width="50%"><asp:Label ID="LabelProduct" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>

           <asp:TableRow>
               <asp:TableCell Width="50%">Product Type</asp:TableCell>
               <asp:TableCell Width="50%"><asp:Label ID="LabelPType" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>

           <asp:TableRow>
               <asp:TableCell Width="50%">Sum Insured</asp:TableCell>
               <asp:TableCell Width="50%"><asp:Label ID="LabelSumInsured" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
       </asp:Table>
       <br/>

       <asp:GridView ID="GridViewDetails" runat="server" BackColor="White"  Width="100%" 
                    class="w3-table-all" BorderStyle="Solid" GridLines="Both"
            ShowFooter="true" OnRowDataBound="GridViewDetails_RowDataBound" 
                    onrowcreated="GridViewDetails_RowCreated">    
                         
      </asp:GridView>

              <br/>     
       <asp:Table ID="Table2" runat="server" class="w3-table-all" BorderStyle="Solid" GridLines="Both">
          <asp:TableRow>
               <asp:TableCell Width="50%">Admin Fee</asp:TableCell>
               <asp:TableCell  Width="50%" style="text-align:right"><asp:Label ID="LabelAdminFee" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell  Width="50%">Policy Fee</asp:TableCell>
               <asp:TableCell Width="50%" style="text-align:right"><asp:Label ID="LabelpolicyFee" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Width="50%">NBL</asp:TableCell>
               <asp:TableCell Width="50%" style="text-align:right"><asp:Label ID="LabelNBT" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
           <asp:TableRow>
               <asp:TableCell Width="50%">Vat</asp:TableCell>
               <asp:TableCell Width="50%" style="text-align:right"><asp:Label ID="LabelVat" runat="server" Text="" style="text-align:right"></asp:Label></asp:TableCell>
           </asp:TableRow>
       </asp:Table>

         <br/>
       <asp:Table ID="Table3" runat="server" class="w3-table-all" BorderStyle="Solid" GridLines="Both">
            <asp:TableRow>
                   <asp:TableCell Width="50%" BackColor="Control" Font-Bold="true" style="text-align:right;">Total</asp:TableCell>
                   <asp:TableCell Width="50%" BackColor="Control"  style="text-align:right;" Font-Bold="true"><asp:Label ID="LabelTotal" runat="server" Text=""  Font-Bold="true" style="text-align:right"></asp:Label></asp:TableCell>
            </asp:TableRow>
       </asp:Table>
        </td>
        </tr>      
    </table>   
    
                <p><b>* No Claim Bonus</b> deduction is subject to submission of valid proof documents.</p>
                <br/>
                
                <p>Please note that this is only a system generated premium indication and if you need a quotation with further details contact <asp:Label ID="lblsfname" runat="server" Text=""></asp:Label> on <asp:Label ID="lblsfmobile" runat="server" Text=""></asp:Label> or nearest branch of Ceylinco General Insurance LTD.</p>
    </div>
       <br /> 
       

        <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>
        <asp:Label ID="Label1" runat="server" style="font-weight:bold;" Text="Select Language" ></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="cmblanguage" runat="server"  width="300px"    CssClass="mydropdownlist1">
                                        <asp:ListItem Text="-Select- " Value="0" />
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Sinhala" Value="Sinhala" />
                                        <asp:ListItem Text="Tamil" Value="Tamil" />
                                       
                                    </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>

       <br />    <br />  

  <asp:Button ID="btnExport" runat="server" Text="Export" OnClick="btnExport_Click" Width="100%"  CssClass="buttonStyle"/>
   
  </form>
  </div>
</body>
</html>
