<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagerOpenBranchRen.aspx.cs" Inherits="quotation" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RENEWABLES
    </title>
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


<script type = "text/javascript">
    var GridId = "<%=grid1.ClientID %>";
    var ScrollHeight = 400;
    window.onload = function () {
        var grid = document.getElementById(GridId);
        var gridWidth = grid.offsetWidth;
        var gridHeight = grid.offsetHeight;
        var headerCellWidths = new Array();
        for (var i = 0; i < grid.getElementsByTagName("TH").length; i++) {
            headerCellWidths[i] = grid.getElementsByTagName("TH")[i].offsetWidth;
        }
        grid.parentNode.appendChild(document.createElement("div"));
        var parentDiv = grid.parentNode;

        var table = document.createElement("table");
        for (i = 0; i < grid.attributes.length; i++) {
            if (grid.attributes[i].specified && grid.attributes[i].name != "id") {
                table.setAttribute(grid.attributes[i].name, grid.attributes[i].value);
            }
        }

        table.style.cssText = grid.style.cssText;
        table.style.width = gridWidth + "px";
        /*******************************************************/
        table.style.margin = "0px";
        /*******************************************************/
        table.appendChild(document.createElement("tbody"));
        table.getElementsByTagName("tbody")[0].appendChild(grid.getElementsByTagName("TR")[0]);
        var cells = table.getElementsByTagName("TH");

        var gridRow = grid.getElementsByTagName("TR")[0];
        for (var i = 0; i < cells.length; i++) {
            var width;
            if (headerCellWidths[i] > gridRow.getElementsByTagName("TD")[i].offsetWidth) {
                width = headerCellWidths[i];
            }
            else {
                width = gridRow.getElementsByTagName("TD")[i].offsetWidth;
            }
            cells[i].style.width = parseInt(width - 3) + "px";
            gridRow.getElementsByTagName("TD")[i].style.width = parseInt(width - 3) + "px";
        }
        parentDiv.removeChild(grid);

        var dummyHeader = document.createElement("div");
        dummyHeader.appendChild(table);
        parentDiv.appendChild(dummyHeader);
        var scrollableDiv = document.createElement("div");
        if (parseInt(gridHeight) > ScrollHeight) {
            gridWidth = parseInt(gridWidth) + 17;
        }
        scrollableDiv.style.cssText = "overflow:auto;height:" + ScrollHeight + "px;width:" + gridWidth + "px";
        scrollableDiv.appendChild(grid);
        parentDiv.appendChild(scrollableDiv);
    }
</script>


</head>
<body>
    <form id="form1" runat="server">




        <div class="container" style="padding-left: 5%; background-color: #b4f9e3;">
            <h1 style="text-align: center; background-color: #000b19; color: #fff; font-weight: bolder; font-family: Calibri; letter-spacing: 7px; word-spacing: 15px;">RENEWABLES</h1>
            <%--    customer details   --%>
            <div class="form-group">

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
                    <div class="col-md-3"></div>
                    <div class="col-md-1">
                        <asp:Label ID="Label4" runat="server" Text="ME"></asp:Label></div>
                    <div class="col-md-5">
                        <asp:DropDownList ID="DropDownListme" AppendDataBoundItems="true"    runat="server" class="form-control"></asp:DropDownList>
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

                <div class="well" style="margin-top: 5px;">

                    <div class="row">
<%--                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both">--%>
                            <asp:GridView ID="grid1" runat="server" CssClass="table table-striped table-bordered table-hover"
                                AutoPostBack="true" AutoGenerateColumns="false" AlternatingRowStyle-BackColor="WhiteSmoke" FooterStyle-BackColor="WhiteSmoke"
                                ShowFooter="true" OnRowCommand="grid1_RowCommand">

                                <Columns>
                                    <asp:BoundField DataField="TYPE" HeaderText="TYPE" SortExpression="TYPE" />
                                    <asp:BoundField DataField="BRANCH" HeaderText="BRANCH" SortExpression="BRANCH" />
                                    <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" SortExpression="PRODUCT" />
                                    <asp:BoundField DataField="POLICY_NO" HeaderText="POLICY_NO" SortExpression="POLICY_NO" />
                                    <asp:BoundField DataField="ME_CODE" HeaderText="STME_CODEATUS" SortExpression="ME_CODE" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                                    <asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE" SortExpression="RENEWAL_DATE" />
                                    <asp:BoundField DataField="SUM_INSURED" HeaderText="SUM_INSURED" SortExpression="SUM_INSURED" />
                                    <asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM" SortExpression="PREMIUM" />
                                    <asp:BoundField DataField="INSURED" HeaderText="INSURED" SortExpression="INSURED" />
                                    <asp:BoundField DataField="RISK_NAME" HeaderText="RISK_NAME" SortExpression="RISK_NAME" />
                                    <asp:BoundField DataField="HP_NAME" HeaderText="HP_NAME" SortExpression="HP_NAME" />
                                    <asp:BoundField DataField="REN_REQUEST_SEND" HeaderText="REN_REQUEST_SEND" SortExpression="REN_REQUEST_SEND" />


                                    <%--                                        <asp:BoundField DataField="CONTACT_NO" HeaderText="CONTACT_NO" SortExpression="CONTACT_NO" />--%>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button Text="Renew Policy" runat="server" CommandName="renew" CommandArgument="<%# Container.DataItemIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
<%--                        </asp:Panel>--%>
                    </div>

                    <asp:TextBox ID="TextBoxbranch" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxmecode" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoximei" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                </div>
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

