<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDetailsTest.aspx.cs" Inherits="AllIslandPromotion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Details</title>
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
       body
       {
           background-color:#fefff4;
           }
     
   </style>
       <link rel="stylesheet" href="assets/csss/jquery-ui.css">
          <script>
        $(function () {
            $("#TextBoxvisitDate").datepicker();
        });
        $(function () {
            $("#TextBoxredate").datepicker();
        });

        $(function () {
            $("#TextBoxfalldate").datepicker();
        });
        
  </script>



    <script type="text/javascript">
        $(function () {
            $("#<%=TextBoxcity.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/service.asmx/GetCity") %>',
                        data: JSON.stringify({ 'prefix': request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[0],
                                    val1: item.split('-')[1]


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
                    $("[id$=TextBoxcity]").val(i.item.val);
                    $("[id$=lblcity]").val(i.item.label);
                    return false;


                },
                minLength: 1
            });


            $("#<%=TextBoxfname.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/service.asmx/GetListofNames") %>',
                        data: JSON.stringify({ 'mec_cus_me': $("#<%=TextBoxmecode.ClientID %>").val(), 'firstname': $("#TextBoxfname").val() }),
                        // data: JSON.stringify({ 'mec_cus_me': $("#TextBoxmecode").val(), 'firstname': $("#TextBoxfname").val() }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[1],
                                    val: item.split('-')[0],
                                    val2: item.split('-')[2],
                                    val3: item.split('-')[3],
                                    val4: item.split('-')[4],
                                    val5: item.split('-')[5],
                                    val6: item.split('-')[6],
                                    val7: item.split('-')[7],
                                    val8: item.split('-')[8],
                                    val9: item.split('-')[9]



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

                    $("#spfirstname").text(i.item.label);
                    $("[id$=TextBoxfname]").val(i.item.val);
                    $("[id$=TextBoxCusCode]").val(i.item.val2);
                    $("[id$=DropDownListtitle]").val(i.item.val3);
                    $("[id$=TextBoxlname]").val(i.item.val4);
                    $("[id$=TextBoxadd1]").val(i.item.val5);
                    $("[id$=TextBoxadd2]").val(i.item.val6);
                    $("[id$=TextBoxcity]").val(i.item.val7);
                    $("[id$=TextBoxlandno]").val(i.item.val8);
                    $("[id$=TextBoxmobileno]").val(i.item.val9);
                    return false;



                },
                minLength: 1
            });



        });


       
    </script>

</head>
<body>
<form id="form1" runat="server">
<div class="container" style="padding-left:5%;background-color:#b0f5d9;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Customer Details</h1>
    <!--customer details-->   
    <div class="form-group">

    <asp:Label ID="LabelMsg" Visible="true" runat="server" style="padding-left:10px;padding-right:10px;" Text="" Font-Bold="true" ForeColor="White"></asp:Label>
        </br>


<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="txtlan" runat="server" /> 
        <asp:HiddenField ID="txtlon" runat="server" />
<%--<asp:TextBox ID="" class="form-control" Width="40%" runat="server" ></asp:TextBox>
<asp:TextBox ID="" class="form-control" Width="40%" runat="server" ></asp:TextBox>--%>
            <label for="email" > Date * </label>
        <asp:TextBox ID="TextBoxvisitDate"  placeholder="enter date" class="form-control" Width="40%" runat="server" ></asp:TextBox></br>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate> 
        <label for="email">Title *</label>
        <asp:DropDownList ID="DropDownListtitle" AppendDataBoundItems="true" class="form-control" Width="40%" runat="server" style="border-style:solid">
        
        </asp:DropDownList></br>

            <div class ="row">
              
                <div class ="col-lg-4">
                  <label for="email">First Name *</label>   <asp:TextBox ID="TextBoxfname" style="border-style:solid" placeholder="enter first name" class="form-control"  runat="server"></asp:TextBox>
                </div>
         
                <div class="col-lg-3" style="margin-top: 32px;">
 <span id="spfirstname"></span>

                </div>
           
            </div>
         

              <label for="email">Last Name *</label>
        <asp:TextBox ID="TextBoxlname" placeholder="enter last name" class="form-control" Width="60%" runat="server" style="border-style:solid"></asp:TextBox></br>

                      <label for="email">Address Line 1 No *</label>
        <asp:TextBox ID="TextBoxadd1" placeholder="enter address1" class="form-control" Width="60%" runat="server" style="border-style:solid"></asp:TextBox></br>
                      <label for="email">Address Line 2 street</label>
        <asp:TextBox ID="TextBoxadd2" placeholder="enter address2" class="form-control" Width="60%" runat="server"></asp:TextBox></br>

             <div class ="row">
                  <div class ="col-lg-4">
                      <label for="email">City *</label>
             <asp:TextBox ID="TextBoxcity" placeholder="enter city name" class="form-control" Width="60%" runat="server"></asp:TextBox>
                      </div>
            <div class="col-lg-3" style="margin-top: 32px;">
 <asp:Label runat="server" ID="lblcity" type="hidden" ></asp:Label>

                </div>
                </div>          <br />

                              <label for="email">Contact No(land)</label>
        <asp:TextBox ID="TextBoxlandno" placeholder="enter Contact" class="form-control" Width="60%" runat="server"></asp:TextBox></br>
                              <label for="email">Mobile No *</label>
        <asp:TextBox ID="TextBoxmobileno" placeholder="enter Contact" class="form-control" Width="60%" runat="server" style="border-style:solid"></asp:TextBox></br>



                <label for="email">Business Occupations *</label>
        <asp:DropDownList ID="cmbbisocu" runat="server"   Width="40%"
                                                class="form-control" AppendDataBoundItems="True"  style="border-style:solid" ></asp:DropDownList></br>

                   <label for="email">Leasing Company</label>
       <asp:TextBox ID="TextBoxleasing" placeholder="enter leasing company" class="form-control" Width="60%" runat="server"></asp:TextBox></br>

        <label for="email">Vehicle No/Risk Name</label>
        <asp:TextBox ID="TextBoxvehicleno" placeholder="enter vehicle no" class="form-control" Width="60%" runat="server"></asp:TextBox></br>

     
                <label for="email">Present Insurer *</label>
        <asp:DropDownList ID="DropDownListinsurer" runat="server"   Width="40%"
                                                class="form-control" AppendDataBoundItems="True" style="border-style:solid" ></asp:DropDownList></br>

        <label for="email">Sum Insured *</label>
        <asp:TextBox ID="txtsuminsured" placeholder="enter sum insured" class="form-control"  Width="40%" onkeypress="return Validate(event);"  runat="server"></asp:TextBox></br>

        <label for="email">Current Premium *</label>
        <asp:TextBox ID="txtcurrpremium" placeholder="enter current premium" class="form-control" Width="40%" onkeypress="return Validate(event);" style="border-style:solid"  runat="server"></asp:TextBox></br>


        
                <label for="email">Policy Type *</label>
        <asp:DropDownList ID="DropDownListpoltype" runat="server"   Width="40%"
          style="border-style:solid" class="form-control" AppendDataBoundItems="True"  ></asp:DropDownList></br>
<span id="lblError" style="color: red"></span>

             <label for="email">Business Closed</label>
        <asp:DropDownList ID="DropDownListbusinesscl" runat="server"   Width="40%"
          style="border-style:solid" class="form-control"   >

            <asp:ListItem Value="">Select Item</asp:ListItem>
            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
            <asp:ListItem Value="N" Text="No"></asp:ListItem>
        </asp:DropDownList></br>

    </ContentTemplate>
        </asp:UpdatePanel>
          <label for="email"  style="display:none" id="lblpolno">policy No</label>
        <asp:TextBox ID="TextBoxpolno" placeholder="enter renewal date"    class="form-control" Width="60%" runat="server" style="display:none">
        </asp:TextBox></br>
          <label for="email" id="labelredate">Renewal Date </label>
        <asp:TextBox ID="TextBoxredate" placeholder="enter renewal date"    class="form-control" Width="60%" runat="server">
        </asp:TextBox></br>

           <label for="email"  style="display:none" id="lblfollowup">Followup Date *</label>
        <asp:TextBox ID="TextBoxfalldate" placeholder="enter followup date"  style="display:none"  class="form-control" Width="60%" runat="server" >
        </asp:TextBox></br>
       
        


    <%--    <label for="email"> ME</label>
        <asp:DropDownList ID="DropDownListServiceME" AppendDataBoundItems="true" class="form-control" Width="40%" runat="server">
        </asp:DropDownList></br>--%>

        <label for="email">Remarks</label>
        <asp:TextBox ID="txtremarks" placeholder="enter remark" class="form-control" Width="60%" runat="server" TextMode="MultiLine"></asp:TextBox></br>
         <asp:TextBox ID="TextBoxMe" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxbranch" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxCusCode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxVisitNo" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxleasingcode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>

        <%-- <label for="email">Referance No </label>
        <asp:TextBox ID="TextBoxRefNo" placeholder="enter Reference number"  MaxLength="10" class="form-control" Width="40%" runat="server">
        </asp:TextBox>
        </br>--%>

        

    <%--            <label for="email"> Prospect Type</label>
        <asp:DropDownList ID="cmbprostype" AppendDataBoundItems="true" class="form-control" Width="100%" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select Prospect Type --</asp:ListItem>
            <asp:ListItem Value="LR">LOSS RENEWALS</asp:ListItem>
            <asp:ListItem Value="QL">QUOTATION LOSS</asp:ListItem>
            <asp:ListItem Value="PR">PROSPECT</asp:ListItem>
        </asp:DropDownList></br>--%>

            <!--buttons-->
<%--    <div class="form-group">
        <asp:RadioButton ID="RadioButton1" runat="server"  GroupName="gender" Text="Loss Renewals" style="padding-right: 20px;" />
        <asp:RadioButton ID="RadioButton2" runat="server"  GroupName="gender" Text="Quotation Loss" style="padding-right: 20px;"/>
        <asp:RadioButton ID="RadioButton3" runat="server"  GroupName="gender" Text="Prospect"/>
    </div> --%>


    <!--buttons-->
    <div class="form-group">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" class="btn btn-primary" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonClear" runat="server" Text="Clear" class="btn btn-success" OnClick="ButtonClear_Click1" />
        <asp:Button ID="ButtonBack" runat="server" Text="Back" class="btn btn-danger" OnClick="ButtonBack_Click1" />
    </div> 

</div>
<script type="text/javascript" src="assets/jss/jquery.min.js"></script>
    <script src="assets/jss/jquery-ui.js"></script>
  
      <script>

         $("#<%=TextBoxleasing.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/service.asmx/GetleasingCompany") %>',
                        data: JSON.stringify({ 'leasingname': request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                   
                              
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
                    $("[id$=TextBoxleasing]").val(i.item.val);
                    $("[id$=TextBoxleasingcode]").val(i.item.label);
                    
                    
                  
                },
                minLength: 1
         });

          $(function () {
              $("#DropDownListbusinesscl").change(function () {
                  if ($(this).val() == "Y") {
                      $("#lblpolno").show();
                      $("#TextBoxpolno").show();
                      $("#lblfollowup").hide();
                      $("#TextBoxfalldate").hide();
                      $("#labelredate").hide();
                      $("#TextBoxredate").hide();

                  } else if ($(this).val() == "N") {

                      $("#lblpolno").hide();
                      $("#TextBoxpolno").hide();
                      $("#lblfollowup").show();
                      $("#TextBoxfalldate").show();
                      $("#labelredate").show();
                      $("#TextBoxredate").show();
                  }

                  else {
                      $("#lblpolno").hide();
                      $("#TextBoxpolno").hide();
                      $("#lblfollowup").hide();
                      $("#TextBoxfalldate").hide();
                  }
              });
          });
       

      </script>
  </form>
</body>
</html>
