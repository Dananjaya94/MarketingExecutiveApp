<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="true" CodeFile="DailyCallSheet.aspx.cs" Inherits="quotation" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dailly call sheet</title>
    <meta charset="utf-8">


    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="assets/mypages/jquery.min.js"></script>
    <link rel="stylesheet" href="assets/mypages/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mypages/bootstrap-theme.css">
    <link rel="stylesheet" href="assets/mypages/jquery-ui.css">
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

        ul{

            z-index:111111111 !important;
            position:absolute !important;
            /*left:4% !important;
            top:25% !important;*/

        }

        .Hide { display:none; }

    </style>
    <link rel="stylesheet" href="assets/csss/jquery-ui.css">
    <script>
        $(function () {
            $("#txtfromdate").datepicker();
        });
        $(function () {
            $("#txttodate").datepicker();
        });
        $(function () {
            $("#txtvistdate").datepicker();
        });
        $(function () {
            $("#txtrenewaldate").datepicker();
        });

        $(function () {
            $("#txtfollowup").datepicker(); 
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
                    $("[id$=lblcity]").val(i.item.val7);
                    $("[id$=TextBoxlandno]").val(i.item.val8);
                    $("[id$=TextBoxmobileno]").val(i.item.val9);
                    return false
                },
                minLength: 1
            });
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

        <link rel="stylesheet" href="assets/csss/jquery-ui.css"/>

</head>
<body>
    <form id="form1" runat="server">




        <div class="container" style="padding-left: 3%; background-color: #b4f9e3;">
            <h1 style="text-align: center; background-color: #000b19; color: #fff; font-weight: bolder; font-family: Calibri; letter-spacing: 7px; word-spacing: 15px;">Dailly Call Sheet</h1>
            <!--customer details-->
            <div class="form-group">

                <div class="well" style="margin-top: 5px;">

                    <div class="row">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                            <div class="col-sm-6">

                                <table align="center">

                                    <tr>

                                        <td style="padding: 5px;">
                                            <asp:Label ID="Label2" runat="server" Text="From"></asp:Label></td>

                                        <td style="padding: 5px;">
                                            <asp:TextBox ID="txtfromdate" runat="server" class="form-control" Width="286px"></asp:TextBox>

                                        </td>


                                    </tr>
                                    <tr>
                                        <td style="padding: 5px;">
                                            <asp:Label ID="Label1" runat="server" Text="To"></asp:Label></td>

                                        <td style="padding: 5px;">
                                            <asp:TextBox ID="txttodate" runat="server" class="form-control" Width="286px"></asp:TextBox>

                                        </td>

                                    </tr>




                                </table>
                            </div>


                            <div class="col-sm-4">
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

<%--                <div class="well" style="margin-top: 5px;">--%>



                    <div class="row">
<%--                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both">--%>
 <%--                          <asp:GridView ID="grid1" runat="server"  CssClass="table table-striped table-bordered table-hover" AutoPostBack="true"   ShowFooter="true">
                   
                </asp:GridView>--%>
                        <div class="w3-responsive">


                            <asp:GridView ID="grid1" runat="server" class="table table-striped table-bordered table-hover" AutoGenerateColumns="false" ShowFooter="false"
                                AlternatingRowStyle-BackColor="WhiteSmoke"
                                Font-Size="Smaller">

                                <Columns>


                                    <asp:TemplateField ItemStyle-Width="30px" HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Update" CssClass="btn-sm btn-info" OnClick="Display"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="VISIT_DATE" HeaderText="VISIT_DATE" />
                                    <asp:BoundField DataField="NO" HeaderText="NO" />
                                    <asp:BoundField DataField="INSURED" HeaderText="INSURED" />
                                    <asp:BoundField DataField="MOBILE_NO" HeaderText="MOBILE_NO" />
                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" />
                                    <asp:BoundField DataField="OCCUPATION" HeaderText="OCCUPATION" />
                                    <asp:BoundField DataField="PRESENT_INSURED" HeaderText="PRESENT_INSURED" />
                                    <asp:BoundField DataField="SUM_INSURED" HeaderText="SUM_INSURED" />
                                    <asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM" />
                                    <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" />
                                    <asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE" />
                                    <asp:BoundField DataField="FOLLOWUP_DATE" HeaderText="FOLLOWUP_DATE" />
                                    <asp:BoundField DataField="RISK_NAME" HeaderText="RISK_NAME" />
                                    <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                    <asp:BoundField DataField="BUSINESS_CLOSED" HeaderText="BUSINESS_CLOSED" />
                                    <asp:BoundField DataField="CLOSED_DATE" HeaderText="CLOSED_DATE" />
                                    <asp:BoundField DataField="POLICY_NO" HeaderText="POLICY_NO" />


                                    <asp:BoundField DataField="mev_mep_seq_no" HeaderText="SEQ_NO">
                                        <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="pol_type" HeaderText="POL_TYPE" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="mec_cus_title" HeaderText="TITLE" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mec_cus_first_name" HeaderText="FIRST_NAME" >
                                        <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mec_cus_last_name" HeaderText="LAST_NAME" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mec_cus_adr_no" HeaderText="ADR_NO" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mec_cus_adr_str" HeaderText="ADR_STREET" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mec_cus_adr_CITY" HeaderText="ADR_CITY" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUS_TEL" HeaderText="TELEPHONE" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CUS_MOB" HeaderText="MOBILE" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="mev_cur_insurer_code" HeaderText="INSURE_CODE" >
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cuscode" HeaderText="CUS_CODE">
                                    <ItemStyle CssClass="Hide" />
                                        <HeaderStyle CssClass="Hide" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                            </div>
<%--                        </asp:Panel>--%>
                   </div>

                    <!-- Modal -->
    <div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Update Daily Call Sheet</h4>
                    </div>
                    <div class="modal-body">
                                        <div class="row" style="width: 100%; padding-bottom:5px; ">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label3" runat="server" Text="Visit Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtvistdate"  runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                  </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label4" runat="server" Text="Occupation"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtoccupation" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtcontact"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />    --%>                                                                                                           
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label19" runat="server" Text="Policy Type"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:DropDownList ID="DropDownListpoltype" runat="server" class="form-control form-control-sm" AppendDataBoundItems="True"  ></asp:DropDownList>                                                    
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label13" runat="server" Text="Present Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:DropDownList ID="DropDownListinsurer" runat="server"  class="form-control" AppendDataBoundItems="True" style="border-style:solid" ></asp:DropDownList>
                                                        <%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtcontact"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /> --%>                                                                                                             
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;">
                                            <div class="col-md-6">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label10" runat="server" Text="Sum Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtsum" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemail"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" />  --%> 
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label14" runat="server" Text="Premium"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpremium" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtemail"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /> --%>  
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label16" runat="server" Text="Risk Name"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtriskname" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-6">
                                                <div class="row">
<%--                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>--%>
                                                </div>
                                            </div>

                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label17" runat="server" Text="Business Closed"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
<%--                    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>
        <asp:DropDownList ID="DropDownListbusinesscl" runat="server" class="form-control"  ><%--AutoPostBack="true"  OnSelectedIndexChanged="DropDownListbusinesscl_SelectedIndexChanged"--%>

            <asp:ListItem Value="">Select Item</asp:ListItem>
            <asp:ListItem Value="Y" Text="Yes"></asp:ListItem>
            <asp:ListItem Value="N" Text="No"></asp:ListItem>
        </asp:DropDownList> 
<%--                        </ContentTemplate>
                            </asp:UpdatePanel>--%>
                                                    </div>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="row" style="width: 100%; padding-bottom:5px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label15" runat="server" Text="Renewal Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtrenewaldate"  runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                         <asp:Label ID="Label9" runat="server" Text="Follow Up Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtfollowup"  runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        

                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label18" runat="server" Text="Policy No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpolicyno" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label6" runat="server" Text="Title"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:DropDownList ID="DropDownListtitle" AppendDataBoundItems="true" class="form-control" runat="server" style="border-style:solid"></asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label7" runat="server" Text="First Name"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
<asp:TextBox ID="TextBoxfname" style="border-style:solid" placeholder="enter first name" class="form-control"  runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label8" runat="server" Text="Last Name"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:TextBox ID="TextBoxlname" placeholder="enter last name" class="form-control"  runat="server" style="border-style:solid"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label12" runat="server" Text="Address Line 1 No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
<asp:TextBox ID="TextBoxadd1" placeholder="enter address1" class="form-control"  runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label20" runat="server" Text="Address Line 2 street"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:TextBox ID="TextBoxadd2" placeholder="enter address2" class="form-control"  runat="server" style="border-style:solid"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;"">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label21" runat="server" Text="City"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
<asp:TextBox ID="TextBoxcity" placeholder="enter city name" class="form-control"  runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label22" runat="server" Text="Contact No(land)"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:TextBox ID="TextBoxlandno" placeholder="enter Contact" class="form-control"  runat="server" style="border-style:solid"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row" style="width: 100%;  padding-bottom:5px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label23" runat="server" Text="Mobile No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
        <asp:TextBox ID="TextBoxmobileno" placeholder="enter Contact"  class="form-control"  runat="server" style="border-style:solid"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-md-4">
<%--                                                        <asp:Label ID="Label20" runat="server" Text="Policy No"></asp:Label>--%>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtmevseq" type="hidden" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:TextBox ID="txtpoltype" type="hidden" runat="server" class="form-control form-control-sm"></asp:TextBox>--%>
<%--                                                        <asp:TextBox ID="txtriskname" type="hidden" runat="server" class="form-control form-control-sm"></asp:TextBox>--%>                                                       
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                    </div>
                    <div class="modal-footer">
<%--                         <asp:Button ID="Button1" runat="server" Text="java"  CssClass="btn btn-info" OnClick="Button1_Click" />--%>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-info" />
                        <button type="button" class="btn btn-info" data-dismiss="modal">
                            Close</button>
                    </div>
                </div>
            </div>
            <script type='text/javascript'>
                function openModal() {
                    $('[id*=myModal]').modal('show');

                    //$("#Label18").show();
                    //$("#txtpolicyno").show();
                    //$("#Label9").show();
                    //$("#txtfollowup").show();
                    //$("#Label15").show();
                    //$("#txtrenewaldate").show();

                    if ($("#DropDownListbusinesscl").val() == "Y") {
                        $("#Label18").show();
                        $("#txtpolicyno").show();
                        $("#Label9").hide();
                        $("#txtfollowup").hide();
                        $("#Label15").hide();
                        $("#txtrenewaldate").hide();

                    } else if ($("#DropDownListbusinesscl").val() == "N") {
                        $("#Label9").show();
                        $("#txtfollowup").show();
                        $("#Label15").show();
                        $("#txtrenewaldate").show();
                        $("#Label18").hide();
                        $("#txtpolicyno").hide();
                    }
                    else {
                        $("#Label18").hide();
                        $("#txtpolicyno").hide();
                        $("#Label9").hide();
                        $("#txtfollowup").hide();
                        $("#Label15").hide();
                        $("#txtrenewaldate").hide();
                    }
                } 
            </script>
        </div>
    </div>


                    <asp:TextBox ID="lblcity" placeholder="ME"  type="hidden"  class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxbranch"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoxmecode"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtclosedate"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtoccupationcode"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HiddenField1" runat="server"/>
                    <asp:TextBox ID="txtcuscode"  type="hidden" class="form-control" Width="40%" runat="server"></asp:TextBox>
<%--                </div>--%>


            </div>
<%--            <script type="text/javascript" src="assets/jss/jquery.min.js"></script>--%>
            <script type="text/javascript" src="assets/jss/jquery-ui.js"></script>

<%--        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
<%--    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>--%>
<%--    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />--%>


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
            </div>
    </form>

    <script type="text/javascript">

        $(function aaaa() {
            $("#DropDownListbusinesscl").change(function () {
                if ($(this).val() == "Y") {
                    $("#Label18").show();
                    $("#txtpolicyno").show();
                    $("#Label9").hide();
                    $("#txtfollowup").hide();
                    $("#Label15").hide();
                    $("#txtrenewaldate").hide();

                } else if ($("#DropDownListbusinesscl").val() == "N") {

                    $("#Label18").hide();
                    $("#txtpolicyno").hide();
                    $("#Label9").show();
                    $("#txtfollowup").show();
                    $("#Label15").show();
                    $("#txtrenewaldate").show();
                }

                else {
                    $("#Label18").hide();
                    $("#txtpolicyno").hide();
                    $("#Label9").hide();
                    $("#txtfollowup").hide();
                    $("#Label15").hide();
                    $("#txtrenewaldate").hide();
                }
                $("#HiddenField1").val($(this).val());
            });
            $("#HiddenField1").val('NOTCHANGE');
        });

        //$(function showhide() {
        //        if ($("#DropDownListbusinesscl").val() == "Y") {
        //            $("#Label18").show();
        //            $("#txtpolicyno").show();
        //            $("#Label9").hide();
        //            $("#txtfollowup").hide();
        //            $("#Label15").hide();
        //            $("#txtrenewaldate").hide();

        //        } else if ($(this).val() == "N") {

        //            $("#Label18").hide();
        //            $("#txtpolicyno").hide();
        //            $("#Label9").show();
        //            $("#txtfollowup").show();
        //            $("#Label15").show();
        //            $("#txtrenewaldate").show();
        //        }

        //        else {
        //            $("#Label18").hide();
        //            $("#txtpolicyno").hide();
        //            $("#Label9").hide();
        //            $("#txtfollowup").hide();
        //            $("#Label15").hide();
        //            $("#txtrenewaldate").hide();
        //        }
        //});


                           $("#<%=txtoccupation.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/service.asmx/GetOccupation") %>',
                        data: JSON.stringify({ 'occupation': request.term }),
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
                    $("[id$=txtoccupation]").val(i.item.val);
                    $("[id$=txtoccupationcode]").val(i.item.val);                    
                },
                minLength: 1
         });
    </script>
</body>
</html>

