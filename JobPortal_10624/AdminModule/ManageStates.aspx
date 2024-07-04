<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageStates.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageStates" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <table>
                <tr>
              <td>Countries Name :</td>
             <td><asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList></td>
                </tr>
         <tr>
    <tr>
        <td>States Name :</td>
        <td><asp:TextBox ID="txtstatesName" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" BackColor="Red" ForeColor="White" OnClick="btnsubmit_Click" /> </td>
    </tr>
    <tr>
        <td></td>
        <td><asp:GridView ID="grdStates" runat="server" AutoGenerateColumns="false"  OnRowCommand="grdStates_RowCommand">
            <Columns>
            <asp:TemplateField HeaderText="States Id">
                <ItemTemplate>
                    <%#Eval("stid") %>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="Country Name">
                    <ItemTemplate>
                        <%#Eval("cid") %>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="States Name">
                     <ItemTemplate>
                          <%#Eval("stname") %>
                     </ItemTemplate>
                     </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="dlt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("stid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("stid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView></td>
    </tr>
</table>
</asp:Content>
