<%@ Page Language="C#" AutoEventWireup="true" CodeFile="salesReport.aspx.cs" Inherits="quotation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Plan</title>
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

       .ui-datepicker-calendar {display: none;}​
     
   </style>
       <link rel="stylesheet" href="assets/csss/jquery-ui.css">
          <script>
    
           
            $(function () {
                $('#TextBoxyear').datepicker({
                    changeMonth: true,
                    changeYear: true,
                    showButtonPanel: true,
                    dateFormat: 'MM yy',
                    onClose: function (dateText, inst) {
                        var month = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
                        var year = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
                        $(this).datepicker('setDate', new Date(year, month, 1));
                    }
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


</head>
<body>
<form id="form1" runat="server">

 


<div class="container" style="padding-left:5%;background-color:#b4f9e3;">
    <h1 style="text-align:center;background-color:#000b19;color:#fff;font-weight:bolder;font-family:Calibri;letter-spacing:7px;word-spacing:15px;">Sales Plan</h1>
    <!--customer details-->   
    <div class="form-group">
  
<div class="well" style="margin-top: 5px;" >

                         <div class="row">
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" >
    <div class="col-sm-6" >

<table align="center">

    <tr>

<td style="padding: 5px;"><asp:Label ID="Label2" runat="server" Text="From"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="TextBoxyear"  runat="server" class="form-control"  Width="286px" ></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label1" runat="server" Text="Motor/Non Motor"></asp:Label></td>

<td style="padding: 5px;">
    <asp:DropDownList ID="DropDownListtype" AppendDataBoundItems="true" class="form-control" Width="286px" runat="server">
            <asp:ListItem Value="0" Selected="True">-- Select   --</asp:ListItem>
            <asp:ListItem Value="M">Motor</asp:ListItem>
            <asp:ListItem Value="N">Non Motor</asp:ListItem>
            
        </asp:DropDownList>

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

                         <div class="row">
                        <asp:Panel ID="Panel2" runat="server" Height="269px" ScrollBars="Both" >
                           <div class="col-sm-6" >

<table align="center">

    <tr>

<td style="padding: 5px;"><asp:Label ID="Label3" runat="server" Text="Me Code"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="TextBoxmecode"  runat="server" class="form-control"  ReadOnly="true" ></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label4" runat="server" Text="Me Name"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxmename"  runat="server" class="form-control"   ReadOnly="true" ></asp:TextBox>

</td> 

    </tr>

        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label5" runat="server" Text="Type"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxtype"  runat="server" class="form-control"   ReadOnly="true"></asp:TextBox>

</td> 

    </tr>
        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label6" runat="server" Text="Year"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxviewyear"  runat="server" class="form-control"    ReadOnly="true"></asp:TextBox>

</td> 

    </tr>
        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label7" runat="server" Text="Month"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxmonth"  runat="server" class="form-control"   ReadOnly="true"></asp:TextBox>

</td> 

    </tr>

    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label13" runat="server" Text="Growth"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxgrowth"  runat="server" class="form-control"  ReadOnly="true"></asp:TextBox>

</td> 

    </tr>


    </table>
    </div>


    <div class="col-sm-4" >
        <table align="center">
            <tr>

<td style="padding: 5px;"><asp:Label ID="Label8" runat="server" Text="New Plan"></asp:Label></td>

<td style="padding: 5px;"><asp:TextBox ID="TextBoxnewplan"  runat="server" class="form-control"  Width="286px" ReadOnly="true"></asp:TextBox>

</td> 


</tr>
    <tr>
 <td style="padding: 5px;"><asp:Label ID="Label9" runat="server" Text="Renewal Plan"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxrenewalplan"  runat="server" class="form-control"  Width="286px" ReadOnly="true"></asp:TextBox>

</td> 

    </tr>

        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label10" runat="server" Text="Total"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxtotal"  runat="server" class="form-control"  Width="286px" ReadOnly="true" ></asp:TextBox>

</td> 

    </tr>
        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label11" runat="server" Text="Last Year"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxlastyear"  runat="server" class="form-control"  Width="286px" ReadOnly="true"></asp:TextBox>

</td> 

    </tr>
        <tr>
 <td style="padding: 5px;"><asp:Label ID="Label12" runat="server" Text="Achievement"></asp:Label></td>

<td style="padding: 5px;">
 <asp:TextBox ID="TextBoxachievement"  runat="server" class="form-control"  Width="286px" ReadOnly="true" ></asp:TextBox>

</td> 

    </tr>
        

            </table>

        </div>
                            </asp:Panel>
                             </div>
                          <div class="well" style="margin-top: 5px;" >

                         <div class="row">
<%--                        <asp:Panel ID="Panel3" runat="server" Height="400px" ScrollBars="Both" >--%>
                               <asp:GridView ID="grid1" runat="server"    CssClass="table table-striped table-bordered table-hover" AutoPostBack="true"
                                   AlternatingRowStyle-BackColor="WhiteSmoke"  >
                                        
                            
                            </asp:GridView>
<%--                            </asp:Panel>--%>
                             </div>
                              </div>
                             <asp:TextBox ID="TextBoxbranch" placeholder="enter Address" type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
       
                    </div>

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

