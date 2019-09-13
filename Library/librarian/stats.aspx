<%@ Page Title="" Language="C#" MasterPageFile="~/librarian/librarian.Master" AutoEventWireup="true" CodeBehind="stats.aspx.cs" Inherits="Library.librarian.stats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
        <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
        <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    <div class="breadcrumbs">
        <div class="col-sm-16">
            <div class="page-header float-left">
                <div class="page-title">
                    <h1>Statistics</h1>
                </div>
            </div>
            <br />
            <br />
            <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">
                <br />
                <div class="form-group">
                    <label for="" class="control-label mb-1">Date From</label>
                    <asp:TextBox ID="startdate" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="" class="control-label mb-1">Date To</label>
                    <asp:TextBox ID="stopdate" runat="server" class="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Show Issues" OnClick="b1_Click"></asp:Button>
                </div>
            </form>
        </div>
    </div>

    <div class="container-fluid" style="min-height: 500px; background-color: white">
        <br />
        <br />
        <asp:DataList ID="d1" runat="server">
            <HeaderTemplate>
                <table class="table" id="example">
                    <tr>
                        <th>Books Title</th>
                        <th>Books Author</th>
                        <th>Books Isbn</th>
                        <th>Books Issues No</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#Eval("books_title") %></td>
                    <td><%#Eval("books_author_name") %></td>
                    <td><%#Eval("books_isbn") %></td>
                    <td><%#Eval("books_issues_no") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:DataList>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#example').DataTable({
                "pagingType":"full_numbers"
            });
        });
    </script>
</asp:Content>
