<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dailycallsheetupdate.aspx.cs" Inherits="dailycallsheetupdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="assets/mypages/jquery.min.js"></script>

        <link href="vendor/css/sb-admin-2.min.css" rel="stylesheet">

</head>
<body>
    <form id="form1" runat="server">
        <!-- Page Wrapper -->
        <div id="wrapper">
            <!-- Sidebar - Brand -->

            <!-- Content Wrapper -->
            <div id="content-wrapper" class="d-flex flex-column">

                <!-- Main Content -->
                <div id="content">

                    <!-- Topbar -->
                    <nav class="navbar navbar-expand navbar-light bg-white topbar mb-4 static-top shadow">


                        <a class="sidebar-brand d-flex align-items-center justify-content-center" href="home.aspx">
                            <div class="sidebar-brand-icon rotate-n-15">
                                <i class="fas fa-file-alt" style="font-size: 40px;"></i>
                            </div>
                            <div class="sidebar-brand-text mx-3" style="font-size: 20px;"><b>Daily Call Sheet Update</b></div>
                            <%--<sup>~</sup>--%>
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

<%--                        <!-- Topbar Navbar -->
                        <ul class="navbar-nav ml-auto">


                            <div class="topbar-divider d-none d-sm-block"></div>

                            <!-- Nav Item - User Information -->
                            <li class="nav-item dropdown no-arrow">
                                <a class="nav-link dropdown-toggle" href="#" id="userDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <span class="mr-2 d-none d-lg-inline text-gray-600 small">
                                        <asp:Label ID="lblusername" runat="server" Text=""></asp:Label></span>
                                    <img class="img-profile rounded-circle" src="img/user.png">
                                </a>
                                <!-- Dropdown - User Information -->
                                <div class="dropdown-menu dropdown-menu-right shadow animated--grow-in" aria-labelledby="userDropdown">
                                    <a class="dropdown-item" href="login.aspx" data-toggle="modal" data-target="#logoutModal">
                                        <i class="fas fa-sign-out-alt fa-sm fa-fw mr-2 text-gray-400"></i>
                                        Logout
                                    </a>
                                </div>
                            </li>
                        </ul>--%>

                    </nav>
                    <!-- End of Topbar -->

                    <!-- Begin Page Content -->
                    <div class="container-fluid" style="padding-top: 15px; padding-bottom: 40px">

                        <!-- Page Heading -->
                        <div class="d-sm-flex align-items-center justify-content-between mb-1">
                            <%--   <h1 class="h3 mb-0 text-gray-800">Cards</h1>--%>
                        </div>


                        <div class="row">
                            <div class="col-lg-1"></div>
                            <div class="col-lg-10">
                                <!-- Default Card Example -->
                                <div class="card mb-2">
                                    <div class="card-body">
                         <div class="row">
                            <div class="col-lg-6">
                                        <div class="row mb-2" style="width: 100%">
                                            <div class="col-md-12">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <asp:Label ID="Label1" runat="server" Text="Visit Date"></asp:Label>
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
                                                        <asp:Label ID="Label2" runat="server" Text="Occupation"></asp:Label>
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
                                                        <asp:Label ID="Label3" runat="server" Text="Insured"></asp:Label>
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
                                                        <asp:Label ID="Label4" runat="server" Text="Address"></asp:Label>
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
                                                        <asp:Label ID="Label6" runat="server" Text="Present Insured"></asp:Label>
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
                                                        <asp:Label ID="Label7" runat="server" Text="Premium"></asp:Label>
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
                                                        <asp:Label ID="Label13" runat="server" Text="Renewal Date"></asp:Label>
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
                                                        <asp:Label ID="Label14" runat="server" Text="Risk Name"></asp:Label>
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
                                                        <asp:Label ID="Label15" runat="server" Text="Business Closed"></asp:Label>
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
                                                        <asp:Label ID="Label16" runat="server" Text="Policy No"></asp:Label>
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
                                </div>
                            </div>
                            <div class="col-lg-1"></div>
                        </div>

                        <div class="row">
                            <div class="col-lg-3"></div>
                            <div class="col-lg-6">
                                <!-- Default Card Example -->
                                <div class="card mb-4">
                                    <div class="card-body">
                                        <asp:Button ID="btnView" runat="server" Text="Send Request" class="btn-sm btn-primary" Width="100%" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                        </div>

                    </div>
                    <!-- /.container-fluid -->

                </div>
                <!-- End of Main Content -->

                <!-- Footer -->
                <footer class="sticky-footer bg-white">
                    <div class="container my-auto">
                        <div class="copyright text-center my-auto">
                            <span>Copyright &copy; Ceylinco IT 2020</span>
                        </div>
                    </div>
                </footer>
                <!-- End of Footer -->

            </div>
            <!-- End of Content Wrapper -->

        </div>
        <!-- End of Page Wrapper -->
    </form>

    <script type="text/javascript" src="assets/jss/jquery.min.js"></script>
    <script src="assets/jss/jquery-ui.js"></script>
</body>
</html>
