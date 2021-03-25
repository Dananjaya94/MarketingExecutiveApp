﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomeSecond.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
<%--    <asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">--%>
      <title>Me</title>

      <!-- Custom fonts for this template-->
      <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
      <link href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet">

      <!-- Custom styles for this template-->
      <link href="vendor/css/sb-admin-2.min.css" rel="stylesheet">
<%--    </asp:Content>--%>
</head>
<body id="page-top">

  <!-- Page Wrapper -->
  <div id="wrapper">
      <!-- Sidebar - Brand -->

    <!-- Content Wrapper -->
    <div id="content-wrapper" class="d-flex flex-column">

      <!-- Main Content -->
      <div id="content">

        <!-- Topbar -->
        <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">


      <a class="sidebar-brand d-flex align-items-center justify-content-center"  href="">
        <div class="sidebar-brand-icon rotate-n-15">
          <i class="fas fa-file-alt" style="font-size:40px;"></i>
        </div>
        <div class="sidebar-brand-text mx-3"  style="font-size:20px;"><b> </b></div><%--<sup>~</sup>--%>
      </a>
        <div class="topbar-divider d-none d-sm-block"></div>

          <!-- Sidebar Toggle (Topbar) -->
          <button id="sidebarToggleTop" class="btn btn-link d-md-none rounded-circle mr-3">
            <i class="fa fa-bars"></i>
          </button>

<%--          <!-- Topbar Search -->
          <form class="d-none d-sm-inline-block form-inline mr-auto ml-md-3 my-2 my-md-0 mw-100 navbar-search">
            <div class="input-group">
              <input type="text" class="form-control bg-light border-0 small" placeholder="Search for..." aria-label="Search" aria-describedby="basic-addon2">
              <div class="input-group-append">
                <button class="btn btn-primary" type="button">
                  <i class="fas fa-search fa-sm"></i>
                </button>
              </div>
            </div>
          </form>--%>

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

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
         <%--   <h1 class="h3 mb-0 text-gray-800">Cards</h1>--%>
          </div>

<%--          <div class="row">

            <div class="col-lg-3"></div>
            <div class="col-lg-6">

              <!-- Default Card Example -->
              <div class="card mb-4">
                <div class="card-header">
                  Default Card Example
                </div>
                <div class="card-body">
                  This card uses Bootstrap's default styling with no utility classes added. Global styles are the only things modifying the look and feel of this default card example.
                </div>
              </div>
            </div>
            <div class="col-lg-3"></div>
          </div>--%>

            <div class="row" style="padding-bottom:25px">
                <div class="col-xl-4 col-md-6 mb-4">
                  
                </div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-4 col-md-6 mb-4">
                        <div class="card border-left-success shadow h-100 py-2">
                                        <a style="text-decoration:none" href="quotation.aspx">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <%--<div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Repair Details Entry Form</div>--%>
                          <div class="h6 mb-0 font-weight-bold text-primary text-uppercase mb-1">Quotation</div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-edit fa-2x text-gray-300"></i>
                        </div>
                      </div>
                    </div>
                                            </a>
                  </div>
                </div>
                <div class="col-xl-4 col-md-6 mb-4">
               
                </div>
            </div>

            <div class="row">
                <div class="col-xl-4 col-md-6 mb-4"></div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-4 col-md-6 mb-4">
                         <div class="card border-left-warning shadow h-100 py-2">
                                        <a style="text-decoration:none" href="MeMenu.aspx">
                    <div class="card-body" >
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <%--<div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Repair Details Entry Form</div>--%>
                          <div class="h6 mb-0 font-weight-bold text-primary text-uppercase mb-1">Me Performance</div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-edit fa-2x text-gray-300"></i>
                        </div>
                      </div>
                    </div>
                                            </a>
                  </div>
                </div>
                <div class="col-xl-4 col-md-6 mb-4"></div>
            </div>

        
            
            <div class="row">
                              <div class="col-xl-4 col-md-6 mb-4"></div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-4 col-md-6 mb-4">
                         <div class="card border-left-primary shadow h-100 py-2">
                                        <a style="text-decoration:none" href="DaillyCallMenu.aspx">
                    <div class="card-body" >
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <%--<div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Repair Details Entry Form</div>--%>
                          <div class="h6 mb-0 font-weight-bold text-primary text-uppercase mb-1">Daily call sheet</div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-edit fa-2x text-gray-300"></i>
                        </div>
                      </div>
                    </div>
                                            </a>
                  </div>
                </div>
                <div class="col-xl-4 col-md-6 mb-4"></div>
            </div>
                        <div class="row" style="padding-bottom:25px">
                <div class="col-xl-4 col-md-6 mb-4">
                  
                </div>
                <!-- Earnings (Monthly) Card Example -->
                <div class="col-xl-4 col-md-6 mb-4">
                        <div class="card border-left-danger shadow h-100 py-2">
                                        <a style="text-decoration:none" href="managermenu.aspx">
                    <div class="card-body">
                      <div class="row no-gutters align-items-center">
                        <div class="col mr-2">
                          <%--<div class="text-xs font-weight-bold text-primary text-uppercase mb-1">Repair Details Entry Form</div>--%>
                          <div class="h6 mb-0 font-weight-bold text-primary text-uppercase mb-1">Managers reports</div>
                        </div>
                        <div class="col-auto">
                          <i class="fas fa-edit fa-2x text-gray-300"></i>
                        </div>
                      </div>
                    </div>
                                            </a>
                  </div>
                </div>
                <div class="col-xl-4 col-md-6 mb-4">
               
                </div>
            </div>

          

        </div>
        <!-- /.container-fluid -->

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

  </div>
  <!-- End of Page Wrapper -->

  <!-- Scroll to Top Button-->
  <a class="scroll-to-top rounded" href="#page-top">
    <i class="fas fa-angle-up"></i>
  </a>

  <!-- Logout Modal-->
  <div class="modal fade" id="logoutModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">Ready to Leave?</h5>
          <button class="close" type="button" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">×</span>
          </button>
        </div>
        <div class="modal-body">Select "Logout" below if you are ready to end your current session.</div>
        <div class="modal-footer">
          <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
          <a class="btn btn-primary" href="login.aspx">Logout</a>
        </div>
      </div>
    </div>
  </div>

  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

  <!-- Custom scripts for all pages-->
  <script src="vendor/js/sb-admin-2.min.js"></script>
</body>
</html>
