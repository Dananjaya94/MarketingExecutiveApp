<%@ Page Language="C#" AutoEventWireup="true" CodeFile="acc_login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="assets/css/login.css">
<link rel="stylesheet" href="assets/css/w3-table-css.css">


</head>
<body>
<div id="id01" class="modal">
   <form id="form1" class="modal-content animate"  runat="server">
 
    <div class="imgcontainer">
      <%--<span onclick="cancelButtonLoad()" class="close" title="Close Modal">&times;</span>--%>
      <%--<img src="img_avatar2.png" alt="Avatar" class="avatar">--%>
        <h1>Premium Indicator</h1>
    </div>

    <div class="container">
    <label for="uname">
        <asp:Label ID="LabelErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </label></br>

      <label for="uname"><b>EPF NO</b></label>
        <asp:TextBox ID="TextBoxUsername" runat="server" placeholder="Enter EPF No" required></asp:TextBox>

<%--      <label for="psw"><b>Infoins Password</b></label>
      <asp:TextBox ID="TextBoxPassword" runat="server" type="password" placeholder="Enter Password" required></asp:TextBox>
        --%>
        <asp:Button ID="ButtonLogin" runat="server" Text="Continue" OnClick="ButtonLogin_Click"/>
      <label>
         <%-- <asp:CheckBox ID="rememberme"  checked="true" name="rememberme" runat="server" />
     --%><asp:CheckBox ID="CheckBoxremember" runat="server" />
          Remember me
      </label>
    </div>

<%--    <div class="container" style="background-color:#f1f1f1">
      <button id="cancel" type="button" onclick="cancelButtonLoad()" class="cancelbtn">Cancel</button>
    
    </div>--%>

        <asp:TextBox ID="TextBoxImei" type="hidden" runat="server"></asp:TextBox>
      
  </form>
</div>

<%--<script>
    // Get the modal
    var modal = document.getElementById('id01');

    function cancelButtonLoad() {
        var modal = document.getElementById('id01');
        modal.style.display = "none";
        location.href = "login.aspx";
    }
</script>--%>

<%--<script>
    //initial login button event this will show login panel
    function myFunction() {
        location.href = "login.aspx";
    }
</script>--%>
</body>
</html>
