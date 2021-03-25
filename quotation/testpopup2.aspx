<%@ Page Language="C#" AutoEventWireup="true" CodeFile="testpopup2.aspx.cs" Inherits="testpopup2" %>


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
<form id="form1" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Dailly Call Sheet</h1>
    <!--customer details-->   
    <div class="form-group">
  
<div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" >
    <div class="col-sm-6" >

<table align="center">

    <tr>

<td style="padding: 5px;"><asp:Label ID="Label2" runat="server" Text="From"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="txtfromdate"  runat="server" class="form-control"  Width="286px" ></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label1" runat="server" Text="To"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="txttodate"  runat="server" class="form-control"  Width="286px"></asp:TextBox>

</td> 

    </tr>




    </table>
    </div>


    <div class="col-sm-4" >
        <table align="center">
            <tr >

<td style="padding: 5px;">

<asp:Button ID="btngetMe"  runat="server" Text=" View " 

class="form-control" Style="background-color:dodgerblue; color:black;font-weight:bold;padding-left:48px;padding-right:48px" OnClick="btngetMe_Click"/> </td> 

<td style="padding: 5px;">

<asp:Button ID="Buttonback"  runat="server" Text="Back" 

class="form-control" Style="background-color:forestgreen; color:black;font-weight:bold;padding-left:48px;padding-right:48px" OnClick="Buttonback_Click"/> </td> 

</tr>
            </table>
        </div>
</asp:Panel>
                </div>
            </div>

                    <div class="well" style="margin-top: 5px;" >
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>--%>


                         <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" >
                           <asp:GridView ID="grid1" runat="server"  CssClass="table table-striped table-bordered table-hover"  DataKeyNames="POLICY_NO"   ShowFooter="true">
                               <Columns>
<%--<asp:TemplateField HeaderText="">--%>
<%--<ItemTemplate>--%>
<%--<asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%# string.Format("~/dailycallsheetupdate.aspx?Id={0}&datefrom={1}&dateto={2}",HttpUtility.UrlEncode(Eval("sec_no").ToString()),txtfromdate.Text,txttodate.Text) %>' Text="Update" />--%><%--Text='<%# Eval("sec_no") %>'--%>
<%--<asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" NavigateUrl='<%# "~/dailycallsheetupdate.aspx?RowIndex=" + Container.DataItemIndex %>' Text="Update" />--%>
<%--<asp:LinkButton ID="lnkDetails" runat="server"  Text="Update1" PostBackUrl='<%# "~/dailycallsheetupdate.aspx?RowIndex=" + Container.DataItemIndex %>' ></asp:LinkButton>--%>
<%--</ItemTemplate>--%>
<%--</asp:TemplateField>--%>


<asp:TemplateField ItemStyle-Width = "30px" HeaderText = "">
   <ItemTemplate>
       <%--<asp:LinkButton ID="lnkEdit" runat="server" Text = "Edit" OnClick = "Edit"></asp:LinkButton>--%>
<%--    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" OnClientClick="return false;" >--%>
<%--<asp:button ID="btninsert" runat="server" text="Edit" CssClass="btn btn-sm btn-primary"  data-target="#exampleModalLong" />--%> <%--data-toggle="modal"--%><%-- OnClick="Edit"--%>
       <asp:LinkButton ID="lnkBtnEdit" runat="server" Text="Pay Now" CssClass="btn btn-info"
                            OnClick="Display"></asp:LinkButton>
   </ItemTemplate>
</asp:TemplateField>

<asp:BoundField DataField="VISIT_DATE" HeaderText="VISIT_DATE"  />
<asp:BoundField DataField="NO" HeaderText="NO"  />
<asp:BoundField DataField="INSURED" HeaderText="INSURED"  />
<asp:BoundField DataField="MOBILE_NO" HeaderText="MOBILE_NO"  />
<asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS"  />
<asp:BoundField DataField="OCCUPATION" HeaderText="OCCUPATION"  />
<asp:BoundField DataField="PRESENT_INSURED" HeaderText="PRESENT_INSURED"  />
<asp:BoundField DataField="SUM_INSURED" HeaderText="SUM_INSURED"  />
<asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM"  />
<asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT"  />
<asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE"  />
<asp:BoundField DataField="FOLLOWUP_DATE" HeaderText="FOLLOWUP_DATE"  />
<asp:BoundField DataField="RISK_NAME" HeaderText="RISK_NAME"  />
<asp:BoundField DataField="REMARKS" HeaderText="REMARKS"  />
<asp:BoundField DataField="BUSINESS_CLOSED" HeaderText="BUSINESS_CLOSED"  />
<asp:BoundField DataField="CLOSED_DATE" HeaderText="CLOSED_DATE"  />
<asp:BoundField DataField="POLICY_NO" HeaderText="POLICY_NO"  />
                                   </Columns>
                </asp:GridView>
                            </asp:Panel>


                             </div>
    <div>
        <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog">
                <!-- Modal content-->
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            &times;</button>
                        <h4 class="modal-title">
                            Student Fee Details</h4>
                    </div>
                    <div class="modal-body">
                         <div class="row">
                            <div class="col-lg-6">
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label3" runat="server" Text="Visit Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtvistdate" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                  </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
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
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
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
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label8" runat="server" Text="Product"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtproduct" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label9" runat="server" Text="Follow Up Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtfollowup" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label12" runat="server" Text="Close Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtcloasedate" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                            <div class="col-lg-6">
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label6" runat="server" Text="Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtinsured" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                  </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcusname"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /> --%>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label13" runat="server" Text="Present Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpresentinsured" runat="server" class="form-control form-control-sm"></asp:TextBox>
<%--                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtcontact"
                                                        ForeColor="Red" Display = "Dynamic" ErrorMessage = "Required" /> --%>                                                                                                             
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
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
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label15" runat="server" Text="Renewal Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtrenewaldate" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
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
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label17" runat="server" Text="Business Closed"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtbusinessclosed" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label18" runat="server" Text="Policy No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpolicyno" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                             </div>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnSave" runat="server" Text="Pay" OnClick="btnSave_Click" CssClass="btn btn-info" />
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
<!-- Modal -->
<%--<div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true" >
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">

                         <div class="row">
                            <div class="col-lg-6">
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label3" runat="server" Text="Visit Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtvistdate" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                  </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label5" runat="server" Text="Mobile No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtmobile" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label4" runat="server" Text="Occupation"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtoccupation" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                                                                           
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label10" runat="server" Text="Sum Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtsum" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label8" runat="server" Text="Product"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtproduct" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label9" runat="server" Text="Follow Up Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtfollowup" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label11" runat="server" Text="Remarks"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtremarks" TextMode="MultiLine" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label12" runat="server" Text="Close Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtcloasedate" type="date" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                            <div class="col-lg-6">
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label6" runat="server" Text="Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtinsured" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                  </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtaddress" runat="server" class="form-control form-control-sm" TextMode="MultiLine"></asp:TextBox>                                                      
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label13" runat="server" Text="Present Insured"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpresentinsured" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                                                                            
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row mb-2">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label14" runat="server" Text="Premium"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpremium" runat="server" class="form-control form-control-sm"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label15" runat="server" Text="Renewal Date"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtrenewaldate" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
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
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label17" runat="server" Text="Business Closed"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtbusinessclosed" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label18" runat="server" Text="Policy No"></asp:Label>
                                                    </div>
                                                    <div class="col-md-8">
                                                        <asp:TextBox ID="txtpolicyno" runat="server" class="form-control form-control-sm"></asp:TextBox>                                                        
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </div>
                             </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
<!--        <button id="btnSave" type="button" class="btn btn-primary">Save changes</button>-->
          <asp:button ID="btnSave" runat="server" text="Save" CssClass="btn btn-sm btn-primary" />

      </div>

<asp:LinkButton ID="lnkFake" runat="server"></asp:LinkButton>
<!--<cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false" 
PopupControlID="exampleModalLong" TargetControlID = "lnkFake"
BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>-->

    </div>
  </div>
</div>--%>

<%--    </ContentTemplate>--%>
<%--<Triggers>
<asp:AsyncPostBackTrigger ControlID = "grid1" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers>--%>
<%--    </asp:UpdatePanel>--%>

                             <asp:TextBox ID="TextBoxbranch" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
                    </div>


</div>
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
<%--<script type="text/javascript" src="assets/jss/jquery.min.js"></script>--%>
<%--    <script src="assets/jss/jquery-ui.js"></script--%>>
  
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


