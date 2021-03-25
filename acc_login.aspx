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
        <h1>Me Application</h1>
    </div>
   
       <div class="container">
 <p style="font-size:large;color:red">
    ඇන්ඩ්‍රොයිඩ් 10 හි නව යාවත්කාලීනයක් ඇති අතර එහි ප්‍රතිපලයක් ලෙස නව "Me Application" මෙම URL වෙතින් බාගත කළ හැකිය.<br /> <a href="http://www.ceyins.lk/mob/ceylincome.apk" style="color:blue">http://www.ceyins.lk/mob/ceylincome.apk</a>.<br />ඔබ ස්ථාපනය කර ලොග් වූ පසු නව "Me Application" වෙත
   <br /> නව යොමු අංකයක් නිපදවනු ඇති අතර, ඔබට මෙම අංකය ඔබගේ නව Imei අංකය ලෙස භාවිතා කළ හැකිය.
</p>
 <br />
<p style="font-size:large;color:red">Android 10 has a new update, and as a result the new "Me Application" can be downloaded from the URL.<br /><a href="http://www.ceyins.lk/mob/ceylincome.apk" style="color:blue">http://www.ceyins.lk/mob/ceylincome.apk</a><br /> After you have installed and logged into the new "Me Application" 
  <br />  a new reference number will produced, and you can use this number as your new Imei number. </p>
<br />
<p style="font-size:large;color:red">அண்ட்ராய்டு 10 ஒரு புதிய புதுப்பிப்பைக் கொண்டுள்ளது, இதன் விளைவாக புதிய "மீ அப்ளிகேஷன்" ஐ 
    URL இலிருந்து பதிவிறக்கம் செய்யலாம்.<br /> <a href="http://www.ceyins.lk/mob/ceylincome.apk" style="color:blue">http://www.ceyins.lk/mob/ceylincome.apk</a>.<br />நீங்கள் நிறுவியதும் புதிய "மீ அப்ளிகேஷனில்"
   <<br />  உள்நுழைந்ததும் ஒரு புதிய குறிப்பு எண் தயாரிக்கப்படும், மேலும் இந்த எண்ணை உங்கள் புதிய Imei எண்ணாகப் பயன்படுத்தலாம்.</p>
       </div>
   <%-- <div class="container">
    <label for="uname">
        <asp:Label ID="LabelErr" runat="server" Text="" ForeColor="Red"></asp:Label>
        </label></br>

      <label for="uname"><b>EPF NO</b></label>
        <asp:TextBox ID="TextBoxUsername" runat="server" placeholder="Enter EPF No" required></asp:TextBox>

<%--      <label for="psw"><b>Infoins Password</b></label>
      <asp:TextBox ID="TextBoxPassword" runat="server" type="password" placeholder="Enter Password" required></asp:TextBox>
        --%>
        <%--<asp:Button ID="ButtonLogin" runat="server" Text="Continue" OnClick="ButtonLogin_Click"/>
      <label>--%>
         <%-- <asp:CheckBox ID="rememberme"  checked="true" name="rememberme" runat="server" />
  <asp:CheckBox ID="CheckBoxremember" runat="server" />
          Remember me
      </label>
    </div>--%>

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
