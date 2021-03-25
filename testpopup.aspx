<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpopup.aspx.cs" Inherits="testpopup" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<%--    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

<%--                <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />--%>

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="grdrepdata" runat="server" AutoPostBack="true">
                        <Columns>
                            <%--<asp:TemplateField HeaderText="">--%>
                            <%--<ItemTemplate>--%>
                            <%--<asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# string.Format("~/dailycallsheetupdate.aspx?Id={0}&datefrom={1}&dateto={2}",HttpUtility.UrlEncode(Eval("sec_no").ToString()),txtfromdate.Text,txttodate.Text) %>' Text="Update" />--%><%--Text='<%# Eval("sec_no") %>'--%>
                            <%--<asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "~/dailycallsheetupdate.aspx?RowIndex=" + Container.DataItemIndex %>' Text="Update" />--%>
                            <%--<asp:LinkButton ID="lnkDetails" runat="server"  Text="Update1" PostBackUrl='<%# "~/dailycallsheetupdate.aspx?RowIndex=" + Container.DataItemIndex %>' ></asp:LinkButton>--%>
                            <%--</ItemTemplate>--%>
                            <%--</asp:TemplateField>--%>

                            <asp:TemplateField ItemStyle-Width="30px" HeaderText="CustomerID">
                                <ItemTemplate>
<%--                                    <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="asst_rpr_serial_no" HeaderText="asst_rpr_serial_no" SortExpression="asst_rpr_serial_no" ItemStyle-Width="120px" />
                            <asp:BoundField DataField="FROM_DATE" HeaderText="FROM DATE" SortExpression="FROM_DATE" ItemStyle-Width="120px" />
                            <asp:BoundField DataField="TO_DATE" HeaderText="COMPLETE DATE" SortExpression="TO_DATE" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="120px" />
                            <asp:BoundField DataField="REPAIR_DESCRIPTION" HeaderText="REPAIR DESCRIPTION" SortExpression="REPAIR_DESCRIPTION" ItemStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="REPAIR_COST" HeaderText="REPAIR COST" SortExpression="REPAIR_COST" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N2}" />
                            <asp:BoundField DataField="REPAIR_PERSON" HeaderText="REPAIR PERSON" SortExpression="REPAIR_PERSON" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
