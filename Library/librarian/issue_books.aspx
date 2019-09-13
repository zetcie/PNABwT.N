<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="issue_books.aspx.cs" Inherits="Library.librarian.issue_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Issue Books</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">

                        <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Select Index</label>
                                <asp:DropDownList ID="index" runat="server" class="form-control"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books ISBN</label>
                                <asp:DropDownList ID="isbn" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="isbn_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <asp:Image ID="i1" runat="server" Height="150" Width="150"></asp:Image><br />
                                <asp:Label ID="booksname" runat="server"></asp:Label><br />
                                <asp:Label ID="instock" runat="server"></asp:Label><br />

                            </div>
                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Issue Books" OnClick="b1_Click"></asp:Button>
                            </div>
                            
                        </form>
                    </div>
                </div>

            </div>
        </div>
        <!-- .card -->

    </div>
    <!--/.col-->
</asp:Content>
