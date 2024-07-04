<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobProfile.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageJobProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Job Profile Name :</td>
            <td><asp:TextBox ID="txtjobprofileName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" BackColor="Red" ForeColor="White" OnClick="btnsubmit_Click" /> </td>
        </tr>
        <tr>
            <td></td>
            <td><asp:GridView ID="grdJobProfile" runat="server" AutoGenerateColumns="false"  OnRowCommand="grdJobProfile_RowCommand">
                <Columns>
                <asp:TemplateField HeaderText="Job Profile Id">
                    <ItemTemplate>
                        <%#Eval("jpid") %>
                    </ItemTemplate>
                </asp:TemplateField>
                     <asp:TemplateField HeaderText="Job Profile Name">
                         <ItemTemplate>
                              <%#Eval("jpname") %>
                         </ItemTemplate>
                         </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="dlt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("jpid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("jpid") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView></td>
        </tr>
    </table>
</asp:Content>
