<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mevisitdetails.aspx.cs" Inherits="quotation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ME Visit details</title>
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
            $("#txtfromdate").datepicker();
        });
        $(function () {
            $("#txttodate").datepicker();
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


</head>
<body>
<form id="form1" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;
;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">ME Visit details</h1>
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

     <tr>
      <td style="padding: 5px;"><asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
               
                <td style="padding: 5px;"><asp:DropDownList ID="DropDownListbranch" AppendDataBoundItems="true"  runat="server" class="form-control"  Width="286px"></asp:DropDownList></td>
            </tr>
 <tr>
  <td style="padding: 5px;"><asp:Label ID="Label4" runat="server" Text="ME"></asp:Label></td>
           
                <td style="padding: 5px;"><asp:DropDownList ID="DropDownListme" AppendDataBoundItems="true"    runat="server" class="form-control"  Width="286px"></asp:DropDownList>
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

                         <div class="row">
<%--                        <asp:Panel ID="Panel2" runat="server" Height="400px" ScrollBars="Both" >--%>
                           <asp:GridView ID="grid1" runat="server" AutoGenerateColumns="false" Font-Size="Smaller"  CssClass="table table-striped table-bordered table-hover" AutoPostBack="true" 
                               AlternatingRowStyle-BackColor="WhiteSmoke" FooterStyle-BackColor="WhiteSmoke"  ShowFooter="true" OnRowCommand="grid1_RowCommand" OnSelectedIndexChanged="grid1_SelectedIndexChanged">                   
                
                               <Columns>

                                   <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button Text="Check" runat="server" CommandName="check" CommandArgument="<%# Container.DataItemIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="BRANCH" HeaderText="BRANCH" SortExpression="BRANCH" />
                                <asp:BoundField DataField="ME" HeaderText="ME" SortExpression="ME" />
                                <asp:BoundField DataField="CATEGORY" HeaderText="CATEGORY" SortExpression="CATEGORY" />
                                <asp:BoundField DataField="CLA_CODE" HeaderText="CLA_CODE" SortExpression="CLA_CODE" />
                                <asp:BoundField DataField="POLICY_PRODUCT" HeaderText="POLICY_PRODUCT" SortExpression="POLICY_PRODUCT" />
                                <asp:BoundField DataField="VISIT_DATE" HeaderText="VISIT_DATE" SortExpression="VISIT_DATE" />
                                   <asp:BoundField DataField="NO" HeaderText="NO" SortExpression="NO" />
                                   <asp:BoundField DataField="INSURED" HeaderText="INSURED" SortExpression="INSURED" />
                                   <asp:BoundField DataField="OCCUPATION" HeaderText="OCCUPATION" SortExpression="OCCUPATION" />
                                   <asp:BoundField DataField="PRESENT_INSURED" HeaderText="PRESENT_INSURED" SortExpression="PRESENT_INSURED" />
                                   <asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM" SortExpression="PREMIUM" />
                                   <asp:BoundField DataField="PRODUCT" HeaderText="PRODUCT" SortExpression="PRODUCT" />
                                   <asp:BoundField DataField="RENEWAL_DATE" HeaderText="RENEWAL_DATE" SortExpression="RENEWAL_DATE" />
                                   <asp:BoundField DataField="FOLLOWUP_DATE" HeaderText="FOLLOWUP_DATE" SortExpression="FOLLOWUP_DATE" />
                                   <asp:BoundField DataField="VEHICLE_NO" HeaderText="VEHICLE_NO" SortExpression="VEHICLE_NO" />
                                   <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
                                   <asp:BoundField DataField="BUSINESS_CLOSED" HeaderText="BUSINESS_CLOSED" SortExpression="BUSINESS_CLOSED" />
                                   <asp:BoundField DataField="BUSINESS_CLOSED_DATE" HeaderText="BUSINESS_CLOSED_DATE" SortExpression="BUSINESS_CLOSED_DATE" />
                                   <asp:BoundField DataField="SYSTEM_POLICY_NO" HeaderText="SYSTEM_POLICY_NO" SortExpression="SYSTEM_POLICY_NO" />

                            </Columns>

                           </asp:GridView>
<%--                            </asp:Panel>--%>
                             </div>

         <asp:TextBox ID="TextBoxbranch" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoxmecode"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
        <asp:TextBox ID="TextBoximei"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
                    </div

</div>
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

