<%@ Page Language="C#" AutoEventWireup="true" CodeFile="policywisecusdetails.aspx.cs" Inherits="policywisecusdetails" %>

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
            <h1 style="text-align: center; background-color: #000b19; color: #fff; font-weight: bolder; font-family: Calibri; letter-spacing: 7px; word-spacing: 15px;">Customer's  All Policy Details</h1>
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
                                            <asp:Button ID="btncuspolicy" runat="server" Text=" View "
                                                class="form-control" Style="background-color: dodgerblue; color: black; font-weight: bold; padding-left: 48px; padding-right: 48px" OnClick="btncuspolicy_Click" />
                                        </td>
                                        <td style="padding: 5px;">
                                            <asp:Button ID="Buttonback" runat="server" Text="Back"
                                                class="form-control" Style="background-color: forestgreen; color: black; font-weight: bold; padding-left: 48px; padding-right: 48px" OnClick="Buttonback_Click"/>
                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="well" style="margin-top: 5px;">
                    <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both">
 <%--                          <asp:GridView ID="grid1" runat="server"  CssClass="table table-striped table-bordered table-hover" AutoPostBack="true"   ShowFooter="true">
                   
                </asp:GridView>--%>


                        <asp:GridView ID="grid1" runat="server" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="true" ShowFooter="true"
                                Font-Size="Smaller">
                                </asp:GridView>
                            </asp:Panel>
                    </div>
                </div>

                    <asp:TextBox ID="TextBoxbranch"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxmecode"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>


            </div>
        </div>
    </form>
    
    <script type="text/javascript" src="assets/jss/jquery-ui.js"></script>

</body>
</html>

