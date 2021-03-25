<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_creation.aspx.cs" Inherits="user_creation" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="assets/css/usercreation.css">
<link rel="stylesheet" href="assets/css/w3-table-css.css">
</head>
<body>

<div id="id01" class="modal">
   <form id="form1" class="modal-content animate"  runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                </asp:ScriptManager>
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
    <div class="imgcontainer">
     
      <%--<img src="img_avatar2.png" alt="Avatar" class="avatar">--%>
        <h2>ME - USER CREATION PORTAL</h2>
    </div>

    <div class="container">

        <label for="uname">
        <b>EPF NO</b></label>
        <asp:TextBox ID="TextBoxEpfNo" runat="server" class="textBox" 
            placeholder="Enter EPF Number"></asp:TextBox>
        <asp:Button ID="ButtonFind" runat="server" OnClick="ButtonFind_Click" 
            Text="Find" />
        <asp:GridView ID="GridViewDetails" runat="server" AutoGenerateColumns="false" 
            Caption="Check ME Details..." class="w3-table-all">
            <Columns>
                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <%#Eval("full_name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NIC">
                    <ItemTemplate>
                        <%#Eval("sfc_nic_no")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <%#Eval("sfc_mobile1")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
     
        <asp:Button ID="ButtonSubmit" runat="server" CssClass="button" 
            onclick="ButtonSubmit_Click" Text="Submit" />
     <label for="uname">
        <asp:Label ID="LabelErr" runat="server" Font-Bold="true" Font-Size="18px" Text="" ForeColor="Red"></asp:Label>
        </label>

    </div>

    <div class="container" style="background-color:#f1f1f1">
      <asp:Button ID="cancelButton" runat="server" class="cancelbtn" Text="Cancel" 
            onclick="cancel_Click"/>
    </div>
  
   </ContentTemplate>
</asp:UpdatePanel>
  </form>
</div>
</body>
</html>
