<%@ Page Language="C#" AutoEventWireup="true" CodeFile="meReneNew.aspx.cs" Inherits="meReneNew"  EnableEventValidation="false" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <%--<meta name="viewport" content="width=device-width, initial-scale=1">--%>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, minimal-ui">
    <script src="assets/mypages/jquery.min.js"></script>
    <link rel="stylesheet" href="assets/mypages/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mypages/bootstrap-theme.css">
    <link rel="stylesheet" href="assets/mypages/jquery-ui.css">
    <script src="assets/mypages/bootstrap.min.js"></script>

    <style>
        body {
            font-family: Arial, Helvetica, sans-serif;
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
<%--    <link rel="stylesheet" href="assets/css/StyleSheet.css">--%>

    <script language="javascript">
        //This script is for desable the enter key events
        function test() {
            if (window.event.keyCode == 13) {
                window.event.cancelBubble = true;
                window.event.returnValue = false;
            }
        }
    </script>
    <!-- Core CSS - Include with every page -->
    <link rel="stylesheet" href="assets/csss/jquery-ui.css">
    <script>
        $(function () {
            $("#txtfromdate").datepicker();
        });
        $(function () {
            $("#txttodate").datepicker();
        });
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

    <h3>Renewable List</h3>

    <div class="container-fluid">
        <form id="form1" runat="server" class="d-sm-inline">
            <%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>--%>

            <div class="well-sm">
                <div class="row" style="padding-bottom:10px">
                    <div class="col-md-3"></div>
                    <div class="col-md-1">
                        <asp:Label ID="Label1" runat="server" Text="From"></asp:Label></div>
                    <div class="col-md-5"><asp:TextBox ID="txtfromdate" runat="server" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-3"></div>
                </div>
                <div class="row" style="padding-bottom:10px">
                    <div class="col-md-3"></div>
                    <div class="col-md-1">
                        <asp:Label ID="Label2" runat="server" Text="To"></asp:Label></div>
                    <div class="col-md-5"><asp:TextBox ID="txttodate" runat="server" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-3"></div>
                </div>
                <div class="row" style="padding-bottom:10px">
                    <div class="col-md-3"></div>
                    <div class="col-md-1">
                        <asp:Label ID="Label3" runat="server" Text="Category"></asp:Label></div>
                    <div class="col-md-5">
                        <asp:DropDownList ID="cmbcategory" runat="server" class="form-control form-control-sm">
                        <asp:ListItem Selected="True" Value="0">-- Select Category --</asp:ListItem>
                        <asp:ListItem Value="MC">Motor Comprehensive</asp:ListItem>
                        <asp:ListItem Value="M3">Motor Third Party</asp:ListItem>
                        <asp:ListItem Value="NM">Non Motor</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <div class="row" style="padding-bottom:10px">
                    <div class="col-md-4"></div>
                    <div class="col-md-3"><asp:Button ID="btnview" runat="server" Text="View" CssClass="btn btn-info" OnClick="btnview_Click" style="width:100%"/></div>
<%--                    <div class="col-md-1"></div>--%>
                    <div class="col-md-2"><asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-warning" style="width:100%" OnClick="btnback_Click"/></div>
                    <div class="col-md-3"></div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <!-- General Information -->
                    <div class="card shadow mb-4">
                        <div class="card-header">
                            <div class="row">
                                <%-- <div class="col-md-1"><asp:Label ID="Label1" runat="server" Text="From :"></asp:Label></div>
                    <div class="col-md-2"><asp:TextBox ID="txtFrom" runat="server" type="Date" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-1"><asp:Label ID="Label2" runat="server" Text="To :"></asp:Label></div>
                    <div class="col-md-2"><asp:TextBox ID="txtTo" runat="server"  type="Date" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-2"></div>--%>
                            </div>
                        </div>
                        <asp:Panel ID="Panel2" runat="server" Height="500px" ScrollBars="Both">
                            <%--                        <div class="card-body">
                            <div class="table-responsive mb-4">--%>
                            <asp:GridView ID="grid1" runat="server" class="table table-bordered" Width="100%" CellSpacing="0"
                                AlternatingRowStyle-CssClass="table-sm table-bordered"
                                EmptyDataRowStyle-CssClass="table-sm table-bordered"
                                PagerStyle-CssClass="table-sm table-bordered"
                                RowStyle-CssClass="table-sm table-bordered"
                                SelectedRowStyle-CssClass="table-sm table-bordered"
                                RowStyle-ForeColor="#44496f"
                                HeaderStyle-ForeColor="#44496f" AutoPostBack="true"
                                AutoGenerateColumns="false" OnRowCommand="grid1_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                                    <asp:BoundField DataField="BRANCH" HeaderText="BRANCH" SortExpression="BRANCH" />
                                    <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" SortExpression="PRODUCT" />
                                    <asp:BoundField DataField="POLICY_NO" HeaderText="POLICY_NO" SortExpression="POLICY_NO" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                                    <asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE" SortExpression="RENEWAL_DATE" />
                                    <asp:BoundField DataField="SUM_INSURED" HeaderText="SUM_INSURED" SortExpression="SUM_INSURED" />
<%--                                    <asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM" SortExpression="PREMIUM" />--%>
                                    <asp:BoundField DataField="INSURED" HeaderText="INSURED" SortExpression="INSURED" />
                                    <asp:BoundField DataField="RISK_NAME" HeaderText="RISK_NAME" SortExpression="RISK_NAME" />
<%--                                    <asp:BoundField DataField="HP_NAME" HeaderText="HP_NAME" SortExpression="HP_NAME" />--%>
                                    <asp:BoundField DataField="CONTACT_NO" HeaderText="CONTACT_NO" SortExpression="CONTACT_NO" />
                                    <asp:BoundField DataField="REN_REQUEST_SEND" HeaderText="REN_REQUEST_SEND" SortExpression="REN_REQUEST_SEND" />
<%--                                    <asp:BoundField DataField="rel_ren_premium" HeaderText="rel_ren_premium" SortExpression="rel_ren_premium" />--%>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                        <HeaderTemplate>CALL_CUSTOMER</HeaderTemplate>
                                        <ItemTemplate>
                                            <a href="https://wa.me/<%# Eval("CONTACT_NO") %>">
                                                <img src="whatsapp.png"></a>
                                            <%--                                                <asp:Button Text="Call Me" runat="server" CommandName="whatsapp" CommandArgument="<%# Container.DataItemIndex %>" />--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button Text="Renew Policy" runat="server" CommandName="renew" CommandArgument="<%# Container.DataItemIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Update" CssClass="btn-sm btn-info" OnClick="Display"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                            <%--                            </div>
                            <div class="text-right"></div>

                        </div>--%>
                        </asp:Panel>
                    </div>
                </div>
            </div>
                    <!-- Modal -->
    <div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Update Daily Call Sheet</h4>
                    </div>
                    <div class="modal-body">
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label99" runat="server" Text="Policy No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpolicyno" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                        <asp:TextBox ID="txtpolseq"  type="hidden"  runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;">
                                            <div class="col-md-12">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label10" runat="server" Text="Name"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtname" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />  --%> 
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label11" runat="server" Text="Cantact No."></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtcontact" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label20" runat="server" Text="Customer Feedback"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="cmbcusfeed" runat="server" class="form-control form-control-sm"></asp:DropDownList>                                                    
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label15" runat="server" Text="Remarks"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label18" runat="server" Text="Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtdate"  runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                    </div>
                    <div class="modal-footer">
<%--                         <asp:Button ID="Button1" runat="server" Text="java"  CssClass="btn btn-info" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-info" />
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
            <script type='text/javascript'>
                function openModal() {
                    $('[id*=myModal]').modal('show');
                } 
            </script>
        </div>
    </div>
            <asp:TextBox ID="TextBoxmecode" type="hidden" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxbranch" type="hidden" runat="server"></asp:TextBox>
            <%--            </ContentTemplate>
        </asp:UpdatePanel>--%>

            <script src="assets/jss/jquery-ui.js"></script>

        </form>
    </div>

</body>
</html>

