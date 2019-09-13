<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="edit_books.aspx.cs" Inherits="Library.librarian.edit_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">Update Books</strong>
            </div>
            <div class="card-body">
                <!-- Credit Card -->
                <div id="pay-invoice">
                    <div class="card-body">

                        <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">

                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Title</label>
                                <asp:TextBox ID="bookstitle" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Image</label><br />
                                <asp:Label ID="booksimage" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="f1" runat="server" class="form-control"></asp:FileUpload>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books PDF</label><br />
                                <asp:Label ID="bookspdf" runat="server" Text=""></asp:Label>
                                <asp:FileUpload ID="f2" runat="server" class="form-control"></asp:FileUpload>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Author Name</label>
                                <asp:TextBox ID="authorname" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Isbn</label>
                                <asp:TextBox ID="isbn" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="" class="control-label mb-1">Books Qty</label>
                                <asp:TextBox ID="qty" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div>
                                <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Update Books" OnClick="b1_Click"></asp:Button>
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
