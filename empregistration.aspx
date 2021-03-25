<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empregistration.aspx.cs" Inherits="empregistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="assets/mypages/jquery.min.js"></script>
    <link rel="stylesheet" href="assets/mypages/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mypages/bootstrap-theme.css">
    <link rel="stylesheet" href="assets/mypages/jquery-ui.css">
    <script src="assets/mypages/bootstrap.min.js"></script>
    <link rel="stylesheet" href="assets/csss/jquery-ui.css">

</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="padding-left: 5%; background-color: #b4f9e3;">
            <h1 style="text-align: center; background-color: #000b19; color: #fff; font-weight: bolder; font-family: Calibri; letter-spacing: 7px; word-spacing: 15px;">Employee Registration</h1>
            <!--customer details-->
            <div class="form-group">

                <div class="well" style="margin-top: 5px;">
                    <div class="row">
                        <asp:Panel ID="Panel1" runat="server" ><%--ScrollBars="Both"--%>
                            <div class="col-lg-6">
                                <table align="center">
                                    <tr>
                                        <td style="padding: 5px;">
                                            <asp:Label ID="Label2" runat="server" Text="NIC"></asp:Label></td>
                                        <td style="padding: 5px;">
                                            <asp:TextBox ID="txtsearchNIC" runat="server" class="form-control" Width="286px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>

                            <div class="col-lg-6">
                                <table align="center">
                                    <tr>
                                        <td style="padding: 5px;">
                                            <asp:Button ID="btngetMe" runat="server" Text=" View "
                                                class="form-control" Style="background-color: dodgerblue; color: black; font-weight: bold; padding-left: 48px; padding-right: 48px" OnClick="btngetMe_Click" />
                                        </td>
                                        <td style="padding: 5px;">
                                            <asp:Button ID="Buttonback" runat="server" Text="Back"
                                                class="form-control" Style="background-color: forestgreen; color: black; font-weight: bold; padding-left: 48px; padding-right: 48px" OnClick="Buttonback_Click" />
                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="well" style="margin-top: 5px;">
                    <div class="row">
                        <asp:Panel ID="Panel2" runat="server" ><%--ScrollBars="Both"--%>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-3">
                                    <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label></div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox></div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-3">
                                    <asp:Label ID="Label3" runat="server" Text="NIC"></asp:Label></div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtnic" runat="server" class="form-control"></asp:TextBox></div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-3">
                                    <asp:Label ID="Label4" runat="server" Text="Attached Branch"></asp:Label></div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtatachdbranch" runat="server" class="form-control"></asp:TextBox></div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-3">
                                    <asp:Label ID="Label5" runat="server" Text="Employee No"></asp:Label></div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtempno" runat="server" class="form-control"></asp:TextBox></div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-2"></div>
                                <div class="col-lg-3">
                                    <asp:Label ID="Label6" runat="server" Text="EPF No"></asp:Label></div>
                                <div class="col-lg-5">
                                    <asp:TextBox ID="txtepfno" runat="server" class="form-control"></asp:TextBox></div>
                                <div class="col-lg-2"></div>
                            </div>
                            <div class="row" style="padding-bottom: 5px">
                                <div class="col-lg-5"></div>
                                <div class="col-lg-5">
                                    <asp:Button ID="btnconfirm" runat="server" Text=" Confirm " OnClick="btnconfirm_popmodel_click"
                                        class="form-control" Style="background-color: lightseagreen; color: black; font-weight: bold; padding-left: 48px; padding-right: 48px" />
                                </div>
                                <div class="col-lg-2"></div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>

                    <asp:TextBox ID="TextBoxbranch"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxmecode"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>

                <!-- Modal -->
                <div>
                    <div class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        &times;</button>
                                    <h4 class="modal-title">Employee Registration</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row" style="width: 100%; padding-bottom: 5px;">
                                        <div class="col-md-12">
                                            <div class="row" style="padding-bottom: 5px;">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label7" runat="server" Text="Name : "></asp:Label>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="lblname" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-bottom: 5px;">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label8" runat="server" Text="NIC : "></asp:Label>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="lblnic" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-bottom: 5px;">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label9" runat="server" Text="Attached Branch : "></asp:Label>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="lblbranch" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-bottom: 5px;">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label10" runat="server" Text="Employee No : "></asp:Label>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="lblempno" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row" style="padding-bottom: 5px;">
                                                <div class="col-md-4">
                                                    <asp:Label ID="Label11" runat="server" Text="EPF No"></asp:Label>
                                                </div>
                                                <div class="col-md-8">
                                                    <asp:TextBox ID="lblepfno" runat="server" class="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <%--                         <asp:Button ID="Button1" runat="server" Text="java"  CssClass="btn btn-info" OnClick="Button1_Click" />--%>
                                    <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="btn btn-info" OnClick="Save_Click" />
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

            </div>
        </div>
    </form>
    
    <script type="text/javascript" src="assets/jss/jquery-ui.js"></script>

</body>
</html>
