<%@ Page Language="C#" AutoEventWireup="true" CodeFile="debitOut.aspx.cs" Inherits="quotation" %>

<!DOCTYPE html>
<html>
<head runat="server">
<%--<meta name="viewport" content="width=device-width, initial-scale=1">--%>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no, minimal-ui">
    <script src="assets/mypages/jquery.min.js"></script>
    <link rel="stylesheet" href="assets/mypages/bootstrap.min.css">
    <link rel="stylesheet" href="assets/mypages/bootstrap-theme.css">
    <link rel="stylesheet" href="assets/mypages/jquery-ui.css">
    <script src="assets/mypages/bootstrap.min.js"></script>  
      <script src="assets/mypages/bootstrap.min.js"></script>
<style>
body {font-family: Arial, Helvetica, sans-serif;}

.inputStyle {
    width: 100%;
    padding: 12px;
    border: 1px solid #ccc;
    border-radius: 4px;
    box-sizing: border-box;
    margin-top: 6px;
    margin-bottom: 16px;
    resize: vertical;
}

.buttonStyle {
    background-color: #4CAF50;
    color: white;
    padding: 12px 20px;
    border: none;
    border-radius: 4px;
    cursor: pointer;
}

input[type=submit]:hover {
    background-color: #45a049;
}

.container {
    border-radius: 5px;
    background-color: #f2f2f2;
    padding: 20px;
}
</style>
<link rel="stylesheet" href="assets/css/StyleSheet.css">

<script language="javascript">
    //This script is for desable the enter key events
    function test() {
        if (window.event.keyCode == 13) {
            window.event.cancelBubble = true;
            window.event.returnValue = false;
        }
    }
  </script>
         <!-- Core CSS - Include with every page -->
   <link rel="stylesheet" href="assets/csss/jquery-ui.css">
    <script>
        $(function () {
            $("#txtfromdate").datepicker();
        });
        $(function () {
            $("#txttodate").datepicker();
        });
  </script>

<%--  <script language="javascript" type="text/javascript">

      function PrintPage() {
          var divToPrint = document.getElementById('<%= pnlGridView.ClientID %>');
          var htmlToPrint = divToPrint.outerHTML;
          newWin = window.open("");
          newWin.document.write(htmlToPrint);
          newWin.print();
          newWin.close();


          //        var printContent = document.getElementById('<%= pnlGridView.ClientID %>');
          //        var printWindow = window.open("All Records", "Print Panel", 'left=50000,top=50000,width=0,height=0');
          //        printWindow.document.write(printContent.innerHTML);
          //        printWindow.document.close();
          //        printWindow.focus();
          //        printWindow.print();
      }
    </script>--%>
    <script language="javascript" type="text/javascript">

       //function Comma(Num) { //function to add commas to textboxes

       //    Num += '';

       //    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');

       //    Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');

       //    x = Num.split('.');

       //    x1 = x[0];

       //    x2 = x.length > 1 ? '.' + x[1] : '';

       //   var rgx = /(\d+)(\d{3})/;

       //    while (rgx.test(x1))

       //        x1 = x1.replace(rgx, '$1' + ',' + '$2');

       //    return x1 + x2;

       //}

       function isNumberKey(evt) {

           var charCode = (evt.which) ? evt.which : evt.keyCode;

           if (charCode > 31 && (charCode < 48 || charCode > 57))

               return false;

           return true;

       }


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

<h3>Debit Outstanding List</h3>
   

   <div class="container-fluid">
    <form id="form1" runat="server" class="d-sm-inline">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> 
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
        <ContentTemplate>--%>

        <div class="row" style="padding-bottom:5px">
            <div class="col-md-12">
<asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-warning" OnClick="btnback_Click"/>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
          <!-- General Information -->
          <div class="card shadow mb-4">
            <div class="card-header">
                <div class="row">
                   <%-- <div class="col-md-1"><asp:Label ID="Label1" runat="server" Text="From :"></asp:Label></div>
                    <div class="col-md-2"><asp:TextBox ID="txtFrom" runat="server" type="Date" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-1"><asp:Label ID="Label2" runat="server" Text="To :"></asp:Label></div>
                    <div class="col-md-2"><asp:TextBox ID="txtTo" runat="server"  type="Date" class="form-control form-control-sm"></asp:TextBox></div>
                    <div class="col-md-2"></div>--%>
                </div>
            </div>
            <div class="card-body">
                  <div class="table-responsive mb-4">
                     <asp:GridView ID="grid1" runat="server"  class="table table-bordered" width="100%" cellspacing="0"
                                                                    AlternatingRowStyle-CssClass="table-sm table-bordered"
                                                                    EmptyDataRowStyle-CssClass="table-sm table-bordered"
                                                                    PagerStyle-CssClass="table-sm table-bordered"
                                                                    RowStyle-CssClass="table-sm table-bordered"
                                                                    SelectedRowStyle-CssClass="table-sm table-bordered"
                                                                    RowStyle-ForeColor="#44496f"
                                                                    HeaderStyle-ForeColor="#44496f" ></asp:GridView>
                  </div>
                  <div class="text-right"></div>
                              
                </div>
          </div>
            </div>
        </div>
          <asp:TextBox ID="TextBoxmecode" type="hidden" runat="server"></asp:TextBox>
       <asp:TextBox ID="TextBoxbranch" type="hidden" runat="server"></asp:TextBox>
<%--            </ContentTemplate>
        </asp:UpdatePanel>--%>
        </form>
        </div>
   
</body>
</html>

