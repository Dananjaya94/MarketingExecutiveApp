<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customerdocupload.aspx.cs" Inherits="customerdocupload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Doc Uoload</title>
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
</head>
<body>
    <form id="form2" runat="server">
        <div class="container" style="background-color: #b4f9e3;">
            <h1 style="text-align: center; background-color: #000b19; color: #fff; font-weight: bolder; font-family: Calibri; letter-spacing: 7px; word-spacing: 15px;">Customer Document</h1>
            <!--customer details-->
            <div class="form-group">
                            <asp:Button ID="Buttonback" runat="server" Text="Back"
                                                class="form-control" Style="background-color: forestgreen; color: black;  padding-left: 48px; padding-right: 48px" OnClick="Buttonback_Click" />
                <div class="well" style="margin-top: 5px;">

                    <div class="row">
                            <div class="col-sm-12">
                                <table align="center">
                                    <tr>
                                            <td style="padding: 5px;"><asp:Label ID="Label1" runat="server" Text="Policy Number"> </asp:Label></td>
                                             <td style="padding: 5px;">
                                                    <asp:TextBox ID="txtpolicyno" runat="server" Class="form-control"></asp:TextBox>
                                             </td>
                                     </tr>
                                </table>
                            </div>
                    </div>
                </div>

                <div class="well" style="margin-top: 5px;">

<%--                    <div class="row">
                            <div class="col-sm-12">
                                <table  style="width:100%" align="center">
                                    <tr style="width:100%">
                                            <td style="padding: 5px; width:20%"><asp:Label ID="Label2" runat="server" Text="Name"> </asp:Label></td>
                                             <td style="padding: 5px; width:80%;">
                                                    <asp:TextBox ID="txtname" runat="server" Class="form-control"></asp:TextBox>
                                             </td>
                                     </tr>
                                     <tr>
                                            <td style="padding: 5px;"><asp:Label ID="Label3" runat="server" Text="Phone"> </asp:Label></td>
                                             <td style="padding: 5px;">
                                                    <asp:TextBox ID="txtphone" runat="server" Class="form-control"></asp:TextBox>
                                             </td>
                                     </tr>
                                </table>
                            </div>
                    </div>--%>

                    <div class="row" style="padding-bottom:10px">
                        <div class="col-sm-4"><asp:Label ID="Label2" runat="server" Text="Name"> </asp:Label></div>
                        <div class="col-sm-8"><asp:TextBox ID="txtname" runat="server" ReadOnly="true" Class="form-control"></asp:TextBox></div>
                    </div>
                    <div class="row" style="padding-bottom:10px">
                        <div class="col-sm-4"><asp:Label ID="Label3" runat="server" Text="Phone"> </asp:Label></div>
                        <div class="col-sm-8"><asp:TextBox ID="txtphone" runat="server" Class="form-control"></asp:TextBox></div>
                    </div>
                    <div class="row" style="padding-bottom:10px">
                        <div class="col-sm-4"><asp:Label ID="Label4" runat="server" Text="Message"> </asp:Label></div>
                        <div class="col-sm-8"><asp:TextBox ID="txtmessage" Height="90px" runat="server" Class="form-control" TextMode="MultiLine"></asp:TextBox></div>
                    </div>
                    <div class="row" style="padding-bottom:10px">
                        <div class="col-sm-12">
                            <asp:Button ID="sendsms" runat="server" Width="100%" Text="Send SMS"
                                                    class="btn-sm btn-primary" OnClick="sendsms_Click" />
                        </div>
                    </div>

                    <asp:TextBox ID="TextBoxbranch" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxmecode" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoximei" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtbranch" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtname2" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtpolseq" type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>

                    <asp:TextBox ID="txtmsg1" type="hidden"  runat="server" Class="form-control" ></asp:TextBox>
                    <asp:TextBox ID="txtmsg2" type="hidden"  runat="server" Class="form-control" ></asp:TextBox>

                </div>
            </div>
        </div>

        <script src="auto_complete/jquery-1.10.0.min.js" type="text/javascript"></script>
        <script src="auto_complete/jquery-ui.min.js" type="text/javascript"></script>
        <link href="auto_complete/jquery-ui.css" rel="Stylesheet" type="text/css" />


        <script type="text/javascript">
            $(function () {

                //$("#txtname").prop('readonly', true);
                //$("#txtvehino").prop('readonly', true);

                //$("#txtsuminsured").prop('readonly', true);
                //$("#txtexprice").prop('readonly', true);
                //$("#txtexdate").prop('readonly', true);

                $("[id$=txtpolicyno]").autocomplete({
                    source: function (request, response) {
                        /////////////////////
                        var obj = {};
                        obj.pol = $.trim($("[id*=txtpolicyno]").val());
                        obj.me = $.trim($("[id*=TextBoxmecode]").val());
                        /////////////////////
                        $.ajax({
                            url: '<%=ResolveUrl("~/customerdocupload.aspx/GetCustomers") %>',
                            //data: "{ 'prefix': '" + request.term + "'}",
                            data: JSON.stringify(obj),
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            success: function (data) {


                                //   var object = data.d[0].split('-');

                                // var name = object[1];
                                // var address = object[2];
                                // $("txtaddress").val(data.d[0].split('-'))
                                response($.map(data.d, function (item) {
                                    return {
                                        label: item.split('-')[0],
                                        val: item.split('-')[1],                                        
                                        val1: item.split('-')[2],
                                        val2: item.split('-')[3],
                                        val3: item.split('-')[4],
                                        val4: item.split('-')[5],
                                        val5: item.split('-')[6]
                                    }
                                }))
                            },
                            error: function (response) {
                                alert(response.responseText);
                            },
                            failure: function (response) {
                                alert(response.responseText);
                            }
                        });
                    },
                    select: function (e, i) {
                        $("[id$=hfCustomerId]").val(i.item.val);
                    },
                    select: function (e, i) {
                        $("[id$=txtname]").val(i.item.val);
                        $("[id$=txtphone]").val(i.item.val1);
                        $("[id$=txtbranch]").val(i.item.val2);
                        $("[id$=txtmessage]").val(i.item.val3 + i.item.val4);
                        $("[id$=txtmsg1]").val(i.item.val3);
                        $("[id$=txtmsg2]").val(i.item.val4);
                        $("[id$=txtname2]").val(i.item.val);
                        $("[id$=txtpolseq]").val(i.item.val5);



                        //var dt = $("[id$=txtexdate]").val(i.item.val4).split('-');
                        //var dt = i.item.val4.split('/');
                        //var date = dt[2] + "-" + dt[1] + "-" + dt[0];
                        //$("[id$=txtexdate]").val(date);
                    },
                    //select: function (e, i) {
                    //    $("[id$=txtaddress]").val(i.item.val2);
                    //},
                    minLength: 1
                });
            });
        </script>

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


