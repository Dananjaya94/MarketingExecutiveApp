<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managersprospectinfo.aspx.cs" Inherits="managers_prospect_info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
  <meta name="description" content=""/>
  <meta name="author" content=""/>
<%--    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">--%>
      <title>Me</title>

      <!-- Custom fonts for this template-->
      <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
      <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet"/>

      <!-- Custom styles for this template-->
      <link href="vendor/css/sb-admin-2.min.css" rel="stylesheet"/>

    <link href="assets/css/notify_styles.css" rel="stylesheet" />
   
    <link href="assets/css/jquery.dataTables.min.css" rel="stylesheet" />

    <script src="assets/js/jquery.min.js"></script>

    <script src="assets/js/jquery.bpopup.min.js"></script>

  
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="vendor/js/sb-admin-2.min.js"></script>
  
    <script src="assets/js/jquery.dataTables.min.js"></script>

    <%--<script src="assets/js/jquery.3.4.1.js"></script>--%>

    <script type = "text/javascript">
        function LoadData() {

            $.ajax({
                type: "GET",
                url: "managersprospectinfo.aspx/populateprospectdetail",
                contentType: "application/json",
                beforeSend: function () {

                    $("#wait").css("display", "block");
                    $("#btnSerach").prop('disabled', true);
                },

                success: function (data) {
                    $("#wait").css("display", "none");
                    $("#btnSerach").prop('disabled', false);

                    var dataSet = [];

                    $.each(data, function (index, value) {
                        var tempArray = new Array;
                        for (var o in value) {
                            console.log(value[o]);
                            tempArray.push(value[o]);
                        }
                        dataSet.push(tempArray);

                        console.log(tempArray);
                    })

                    console.log(dataSet[0]);


                        console.log("Datatable started");
                        $('#prospctdetails').DataTable({
                            data: dataSet[0],
                            columns: [

                                { title: "Branch Code" },
                                //{ title: "ME Code" },
                                //{ title: "ME Name" },
                                //{ title: "Commercial Insurance" },
                                //{ title: "Insured" },
                                //{ title: "Renewal Date" },
                                //{ title: "Product Code" },
                                //{ title: "Current Insurer" },
                                //{ title: "Occupation" },
                                //{ title: "Current Premium" },
                                //{ title: "Premium" },
                                //{ title: "Remarks" },

                            ]
                        });

                        console.log("Datatable finished");


                },
                error: function (jqXHR, exception) {

                    console.log(exception);
                }
            });


        }

</script>


<%--    </asp:Content>--%>
</head>
<body id="page-top" onload="LoadData();">

    <!-- Page Wrapper -->
    <div id="wrapper">

        <!-- Content Wrapper -->
        <div id="content-wrapper" class="d-flex flex-column">

            <!-- Main Content -->
            <div id="content">
                <!-- Topbar -->
        <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">


      <a class="sidebar-brand d-flex align-items-center justify-content-center"  href="managermenu.aspx">
        <div class="sidebar-brand-icon rotate-n-15">
          <i class="fas fa-file-alt" style="font-size:40px;">Back</i>
          
        </div>
        <div class="sidebar-brand-text mx-3"  style="font-size:20px;"><b> </b></div><%--<sup>~</sup>--%>
      </a>
        <div class="topbar-divider d-none d-sm-block"></div>

          <!-- Sidebar Toggle (Topbar) -->
          <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
             
            <i class="fa fa-bars"></i>
          </button>

          <!-- Topbar Search -->
          <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
      <%--      <div class="input-group">
              <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
              <div class="input-group-append">
                <button class="btn btn-primary" type="button">
                  <i class="fas fa-search fa-sm"></i>
                </button>
              </div>
            </div>--%>
<span><i id="inotify" class="fas fa-inbox" style="font-size:40px;"></i></span>
          </form>

          <!-- Topbar Navbar -->
          <ul class="navbar-nav ml-auto">


            <div class="topbar-divider d-none d-sm-block"></div>

            <!-- Nav Item - User Information -->
            <li class="nav-item dropdown no-arrow">
          <%-- <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                <span class="mr-2 d-none d-lg-inline text-gray-600 small"><asp:Label ID="lblusername" runat="server" Text=""></asp:Label></span>
                <img class="img-profile rounded-circle" src="user.png">
           
              </a>--%>
              <!-- Dropdown - User Information -->
              <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
<%--                <a class="dropdown-item" href="#">
                  <i class="fas fa-user fa-sm fa-fw mr-2 text-gray-400"></i>
                  Profile
                </a>
                <a class="dropdown-item" href="#">
                  <i class="fas fa-cogs fa-sm fa-fw mr-2 text-gray-400"></i>
                  Settings
                </a>
                <a class="dropdown-item" href="#">
                  <i class="fas fa-list fa-sm fa-fw mr-2 text-gray-400"></i>
                  Activity Log
                </a>
                <div class="dropdown-divider"></div>--%>
                <a class="dropdown-item" href="acc_login.aspx" data-toggle="modal" data-target="#logoutModal">
                  <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                  Logout
                </a>
              </div>
            </li>

          </ul>

        </nav>
        <!-- End of Topbar -->
                
                <!-- Begin Page Content -->
                <div class="container-fluid" style="padding-top:15px; padding-bottom:40px">

                </div>
                <!-- End Page Content -->

                <form runat="server">
                    <div class="row">
                        <div class="col-md-2"></div>
                        <div class="col-md-8" style="align-items:center">
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                            
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

                                    <tr>
                                        <td style="padding: 5px;">
                                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>

                                        <td style="padding: 5px;">
                                            <asp:DropDownList ID="DropDownListbranch" AppendDataBoundItems="true" runat="server" class="form-select" Width="286px"></asp:DropDownList>
                                    </tr>
                                    <tr>
                                        <td style="padding: 5px;">
                                            <asp:Label ID="Label4" runat="server" Text="ME"></asp:Label></td>

                                        <td style="padding: 5px;">
                                            <asp:DropDownList ID="DropDownListme" AppendDataBoundItems="true" runat="server" class="form-select" Width="286px"></asp:DropDownList>
                                    </tr>

                                </table>

                                <table align="center">


                                    <tr>

                                        <td style="padding: 5px;">

                                            <asp:Button ID="btngetMe" runat="server" Text=" View "
                                                class="btn btn-warning" OnClick="btngetMe_Click" />
                                        </td>

                                        <td style="padding: 5px;">

                                            <asp:Button ID="Buttonback" runat="server" Text="Back"
                                                class="btn btn-dark" OnClick="Buttonback_Click" />
                                        </td>



                                    </tr>



                                </table>
                            

                        </asp:Panel>
                        </div>
                        <div class="col-md-2"></div>
                    </div>

                    <asp:TextBox ID="TextBoxmecode"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>
                    <asp:TextBox ID="TextBoximei"  type="hidden"   class="form-control" Width="40%" runat="server"></asp:TextBox>

                </form>

                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        
                        <%--<form runat ="server">
                            <asp:GridView ID="prospectgrid" runat ="server">                   
                
                               <Columns>
                                   <asp:BoundField DataField="BRANCH CODE" HeaderText="BRANCH CODE" SortExpression="BRANCH CODE" />
                                   <asp:BoundField DataField="ME CODE" HeaderText="ME CODE" SortExpression="ME CODE" />
                                   <asp:BoundField DataField="ME NAME" HeaderText="ME NAME" SortExpression="ME NAME" />
                                   <asp:BoundField DataField="INSURED" HeaderText="INSURED" SortExpression="INSURED" />
                                   <asp:BoundField DataField="RENEWAL DATE" HeaderText="RENEWAL DATE" SortExpression="RENEWAL DATE" />
                                   <asp:BoundField DataField="PRODUCT CODE" HeaderText="PRODUCT CODE" SortExpression="PRODUCT CODE" />
                                   <asp:BoundField DataField="CURRENT INSURER" HeaderText="CURRENT INSURER" SortExpression="CURRENT INSURER" />
                                   <asp:BoundField DataField="OCCUPATION" HeaderText="OCCUPATION" SortExpression="OCCUPATION" />
                                   <asp:BoundField DataField="CURRENT PREMIUM" HeaderText="CURRENT PREMIUM" SortExpression="CURRENT PREMIUM" />
                                   <asp:BoundField DataField="PREMIUM" HeaderText="PREMIUM" SortExpression="PREMIUM" />
                                   <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" SortExpression="REMARKS" />
                               </Columns>

                           </asp:GridView>

                            
                        </form>--%>
                        
                        <table id ="prospctdetails"></table>

                    </div>
                    <div class ="col-md-2"></div>
                </div>
            </div>
            <!-- End of Main Content -->

            <!-- Footer -->
            <footer class="sticky-footer bg-white">
                <div class="container my-auto">
                    <div class="copyright text-center my-auto">
                        <span>Copyright &copy; Ceylinco IT (R&D) </span>
                    </div>
                </div>
            </footer>
      <!-- End of Footer -->

        </div>
        <!-- End of Content Wrapper -->


        

    <!-- Page Wrapper -->
    </div>

    <!-- Bootstrap core JavaScript-->
<%--  <script src="vendor/jquery/jquery.min.js"></script>--%>

    
    


  
    <%--<script type='text/javascript'>  
        function GetProspectInfo() {
            PageMethods.Name(Success, Failure);
        }

        function Success(result) {
            alert(result);
        }

        function Failure(error) {
            alert(error);
        }
        </script>--%>
 
    <script>
        
    </script>

   <script>

       //(function ($) {

       //    $('element_to_pop_up').bPopup();
       //})(jQuery);


       //$("#inotify").click(function () {
             

       //    $('#my-toast-location').toaste({
       //        type: 'success',
       //        header: 'Toastee',
       //        message: 'Got Butter?',
       //        color: 'yellow',
       //        background: '#FFBB00',
       //        width: 100,
       //        height: 200,
       //        fadeout: 500
       //    });

       //});

       //$.ajax({
       //    type: "GET",

       //    url: "managersprospectinfo.aspx/PopulateProspectDetail",
       //    contentType: "application/json",
       //    beforeSend: function () {
       //    },

       //    success: function (data) {



       //        console.log(data);

       //        $.each(data, function (index, value) {

       //            var outcolls = [];
       //            var outrowsss = [];

       //            var tempArray = new Array;
       //            console.log(value);
       //            for (var o in value.metaData) {
       //                outcolls.push(value.metaData[o]);
       //            }

       //            for (var i in value.rows) {
       //                outrowsss.push(value.rows[i]);
       //            }
       //            console.log(outrowsss);

       //            $('#prospctdetails').DataTable({

       //                data: outrowsss,

       //                columns: [

       //                    { title: "Branch Code" },
       //                    { title: "ME Code" },
       //                    { title: "ME Name" },
       //                    { title: "Commercial Insurance" },
       //                    { title: "Insured" },
       //                    { title: "Renewal Date" },
       //                    { title: "Product Code" },
       //                    { title: "Current Insurer" },
       //                    { title: "Occupation" },
       //                    { title: "Current Premium" },
       //                    { title: "Premium" },
       //                    { title: "Remarks" },

       //                ]

       //            });

       //        })
       //    },

       //    error: function (jqXHR, exception) {

       //    }

       //});


       




   </script>



</body>
</html>
