<%@ Page Language="C#" AutoEventWireup="true" CodeFile="quotation.aspx.cs" Inherits="quotation" %>

<!DOCTYPE html>
<html>
<head runat="server">
<%--<meta name="viewport" content="width=device-width, initial-scale=1">--%>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, minimal-ui">

<style>
body {font-family: Arial, Helvetica, sans-serif;}

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


<%--  <script language="javascript" type="text/javascript">

      function PrintPage() {
          var divToPrint = document.getElementById('<%= pnlGridView.ClientID %>');
          var htmlToPrint = divToPrint.outerHTML;
          newWin = window.open("");
          newWin.document.write(htmlToPrint);
          newWin.print();
          newWin.close();


          //        var printContent = document.getElementById('<%= pnlGridView.ClientID %>');
          //        var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0');
          //        printWindow.document.write(printContent.innerHTML);
          //        printWindow.document.close();
          //        printWindow.focus();
          //        printWindow.print();
      }
    </script>--%>
    <script language="javascript" type="text/javascript">

       //function Comma(Num) { //function to add commas to textboxes

       //    Num += '';

       //    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');

       //    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');

       //    x = Num.split('.');

       //    x1 = x[0];

       //    x2 = x.length > 1 ? '.' + x[1] : '';

       //   var rgx = /(\d+)(\d{3})/;

       //    while (rgx.test(x1))

       //        x1 = x1.replace(rgx, '$1' + ',' + '$2');

       //    return x1 + x2;

       //}

       function isNumberKey(evt) {

           var charCode = (evt.which) ? evt.which : evt.keyCode;

           if (charCode > 31 && (charCode < 48 || charCode > 57))

               return false;

           return true;

       }


</script>




</head>
<body>

<h3>Quotation Form</h3>

<div class="container">
   <form id="form1" runat="server"><%--onkeypress="test();--%>
<%--          <table  id="pnlGridView" runat="server" >
              <tr><td>--%>
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <label>Customer Name</label>
    <asp:TextBox ID="TextBoxName" runat="server" CssClass="inputStyle" placeholder="Enter name.."></asp:TextBox>

    <label>Vehicle Number</label>
    <asp:TextBox ID="TextBoxVehicle" runat="server" CssClass="inputStyle" placeholder="Enter vehicle number.."></asp:TextBox>

    <label>Class</label>
    <asp:DropDownList ID="DropDownList1" runat="server" class="form-control" CssClass="inputStyle">
        <asp:ListItem Value="MC" Selected>MC</asp:ListItem>
    </asp:DropDownList>
    
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnCalRatio"> 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>
    <label>Product</label>
    <asp:DropDownList ID="cmbProduct" runat="server" class="form-control" CssClass="inputStyle" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbProduct_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList>
      

    <label>Product Type</label>
    <asp:DropDownList ID="cmbProductType" runat="server" class="form-control"   CssClass="inputStyle" AppendDataBoundItems="True" OnSelectedIndexChanged="cmbProductType_SelectedIndexChanged" AutoPostBack="true"  ></asp:DropDownList>

    <label>Sum Insured</label>
    <asp:TextBox ID="txtSumInsured" runat="server" CssClass="inputStyle" AutoPostBack="true" onkeypress="return isNumberKey(event)" ></asp:TextBox>

    <asp:Button ID="btnCalPeril" CssClass="buttonStyle" runat="server" Text="Calculate Peril" 
                onclick="btnCalPeril_Click"  />
            <br>
            <br>

            <div class="w3-responsive">
                <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="False" 
                    AutoPostBack="true" class="w3-table-all" ShowFooter="true">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <center>
                                    <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="true" checked="false" 
                                        OnCheckedChanged="chkHeader_OnCheckedChanged" />
                                </center>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:CheckBox ID="chkGrid" runat="server" AutoPostBack="true" 
                                        OnCheckedChanged="chkGrid_OnCheckedChanged" />
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="qtp_prl_code_desc" HeaderText="Perils" 
                            SortExpression="qtp_prl_code_desc" />

                        <%--gfhjghjjgjf--%>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <center>
                                    <asp:Label runat="server" Text="Ratio"></asp:Label>
                                </center>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <center>
                                    <asp:TextBox id="txtratio" runat="server" width="100%" type="number" maxlimit="4" Height="100%" ></asp:TextBox> <%--ontextchanged="txtratio_TextChanged"--%>
                                    <asp:DropDownList ID="ddlratio" runat="server"  width="100%" onselectedindexchanged="ddlratio_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select Ratio" Value="0" />
                                       <%-- <asp:ListItem Text="5" Value="5" />
                                        <asp:ListItem Text="10" Value="10" />
                                        <asp:ListItem Text="15" Value="15" />
                                        <asp:ListItem Text="20" Value="20" />
                                        <asp:ListItem Text="25" Value="25" />
                                        <asp:ListItem Text="30" Value="30" />
                                        <asp:ListItem Text="35" Value="35" />
                                        <asp:ListItem Text="40" Value="40" />
                                        <asp:ListItem Text="45" Value="45" />
                                        <asp:ListItem Text="50" Value="50" />
                                        <asp:ListItem Text="55" Value="55" />
                                        <asp:ListItem Text="60" Value="60" />
                                        <asp:ListItem Text="65" Value="65" />
                                        <asp:ListItem Text="70" Value="70" />--%>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlratioMR" runat="server"  width="100%" onselectedindexchanged="ddlratio_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="Select Ratio" Value="0" />
                                        <asp:ListItem Text="5" Value="5" />
                                        <asp:ListItem Text="7.5" Value="7.5" />
                                        <asp:ListItem Text="10" Value="10" />
                                        <asp:ListItem Text="12.5" Value="12.5" />
                                        <asp:ListItem Text="15" Value="15" />
                                        <asp:ListItem Text="17.5" Value="17.5" />
                                        <asp:ListItem Text="20" Value="20" />
                                    </asp:DropDownList>
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--gfhjghjjgjf--%>
                        <asp:BoundField DataField="Amount" DataFormatString="{0:N2}" 
                            HeaderStyle-HorizontalAlign="Right" HeaderText="Amount" 
                            ItemStyle-HorizontalAlign="Right" SortExpression="Amount" />

                        <asp:BoundField DataField="qtp_prl_code" HeaderText="Code"/>
                        <asp:BoundField DataField="qtp_user_para" HeaderText="Status"/>
                        <asp:BoundField DataField="qtp_rate" HeaderText="qtp_rate"/>
                    </Columns>
                </asp:GridView>
            </div>
            <br/>
                    <asp:Button ID="btnCalRatio" CssClass="buttonStyle" runat="server" Text="Calculate Ratio" OnClick="btnCalRatio_Click"/>
            <br /><br />
            <div class="w3-responsive">
                <asp:Table ID="Table1" runat="server" BorderStyle="Solid" class="w3-table-all" 
                    GridLines="Both">
                    <asp:TableRow>
                        <asp:TableCell>Policy Fee</asp:TableCell>
                        <asp:TableCell style="text-align:right"><asp:Label ID="Label2" runat="server" Text="Label" style="text-align:right"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Admin Fee</asp:TableCell>
                        <asp:TableCell style="text-align:right"><asp:Label ID="Label4" runat="server" Text="Label" style="text-align:right"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>NBL</asp:TableCell>
                        <asp:TableCell style="text-align:right"><asp:Label ID="Label3" runat="server" Text="Label" style="text-align:right"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>V.A.T</asp:TableCell>
                        <asp:TableCell style="text-align:right"><asp:Label ID="Label5" runat="server" Text="Label" style="text-align:right"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br>

            </div>

            <div class="w3-responsive">
                <asp:Table ID="tblTotal" runat="server" BorderStyle="Solid" class="w3-table-all" 
                    GridLines="Both">
                    <asp:TableRow>
                        <asp:TableCell  Font-Bold="true">Total</asp:TableCell>
                        <asp:TableCell style="text-align:right"  Font-Bold="true"><asp:Label ID="lblfinalTot" runat="server" Text="Label" style="text-align:right"  Font-Bold="true"></asp:Label></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br/>
                 <asp:Button ID="btnExportPDF" CssClass="buttonStyle" runat="server" Text="Export to PDF"   OnClientClick="PrintPage();" OnClick="btnExportPDF_Click" />  

            </div>

            <br/>

        </ContentTemplate>
   </asp:UpdatePanel>  
            </asp:Panel>
<%-- </td> </tr>
          </table>--%>
           <asp:TextBox ID="TextBoxUser" type="hidden"   runat="server"></asp:TextBox>
       <asp:TextBox ID="txtcheck"  type="hidden" runat="server" ></asp:TextBox>
  </form>
</div>
   
</body>
</html>
