<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
<link rel="stylesheet" href="assets/css/login_me.css">
<link rel="stylesheet" href="assets/css/w3-table-css.css">

</head>
<body>

<div id="myDIV">
    <h1>CEYLINCO GENERAL INSURANCE LTD</h1>
    <h2>QUOTATION SYSTEM LOGIN</h2>
    </br></br>
    <button id="show"  style="width:auto;" onclick="myFunction()">Login</button>
</div>

<div id="id01" class="modal">
   <form id="form1" class="modal-content animate"  runat="server">
 
    <div class="imgcontainer">
      <span onclick="cancelButtonLoad()" class="close" title="Close Modal">&times;</span>
      <%--<img src="img_avatar2.png" alt="Avatar" class="avatar">--%>
        <h1>LOGIN</h1>
    </div>

    <div class="container">
          <label for="uname"><b>Type</b></label>
          <div class="type" style="margin-top:7px;">
        <asp:RadioButton ID="rbUW" runat="server" GroupName="type" Text="Underwriter" style="padding-right:50px;" OnClick="findselected()"/>
        <asp:RadioButton ID="rbME" runat="server" GroupName="type" Text="ME"  OnClick="findselected()"/>
        </div>

    <label for="uname">
        <asp:Label ID="LabelErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </label></br>

<%--      <label for="uname" id="epf"><b>EPF No</b></label>--%>
        <asp:Label ID="epf" runat="server" Text="EPF No"></asp:Label>
        <asp:TextBox ID="TextBoxUsername" runat="server" placeholder="Enter EPF No" required></asp:TextBox>

      <label for="psw"><b>Password</b></label>
      <asp:TextBox ID="TextBoxPassword" runat="server" type="password" placeholder="Enter Password" required></asp:TextBox>
        
        <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click"/>
      <label>
        <input type="checkbox" checked="checked" name="remember"> Remember me
      </label>
    </div>

    <div class="container" style="background-color:#f1f1f1">
      <button id="cancel" type="button" onclick="cancelButtonLoad()" class="cancelbtn">Cancel</button>
      <%--<span class="psw">Create <a href="acc_login.aspx" id="createAcc">Account</a></span>--%>
      <span class="psw" id="psww">Create <a href="acc_login.aspx" id="A1">Account</a></span>
    </div>
  </form>
</div>


 <script >
     function findselected() {
       //  alert("dgffhghghjhjkjkhjkkgkgh");
         if (document.getElementById('rbUW').checked == 1) {
             //alert("dgffhghghjhjkjkhjkkgkgh");
             document.getElementById('<%= epf.ClientID %>').innerHTML = 'User Name';

             document.getElementById('psww').style.visibility = "visible";
         }
         else if (document.getElementById('rbME').checked == 1) {

              // alert("aaaaaaaaaaaaaaaaaaaaaaa");
             document.getElementById('<%= epf.ClientID %>').innerHTML = 'EPF No';

             document.getElementById('psww').style.visibility = "hidden";

         }
     }


</script>



<script>
    // Get the modal
    var modal = document.getElementById('id01');

    // When the user clicks anywhere outside of the modal, close it and open the initial div
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
            var x = document.getElementById("myDIV");
            x.style.display = "block";
        }
    }

    function cancelButtonLoad() {
        var modal = document.getElementById('id01');
        modal.style.display = "none";
        var x = document.getElementById("myDIV");
        x.style.display = "block";
    }
</script>

<script>
    //initial login button event this will show login panel
    function myFunction() {
        var x = document.getElementById("myDIV");
        if (x.style.display === "none") {
            x.style.display = "block";
        } else {
            x.style.display = "none";
            document.getElementById('id01').style.display = 'block';
        }
    }
</script>

</body>
</html>
