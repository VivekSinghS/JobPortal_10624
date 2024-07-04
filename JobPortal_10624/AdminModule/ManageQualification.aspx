<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageQualification.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageQualification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table>
     <tr>
         <td>Qualification Name :</td>
         <td><asp:TextBox ID="txtqualificationName" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
         <td></td>
         <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" BackColor="Red" ForeColor="White" OnClick="btnsubmit_Click" /> </td>
     </tr>
     <tr>
         <td></td>
         <td><asp:GridView ID="grdQualification" runat="server" AutoGenerateColumns="false"  OnRowCommand="grdQualification_RowCommand">
             <Columns>
             <asp:TemplateField HeaderText="Qualification Id">
                 <ItemTemplate>
                     <%#Eval("qid") %>
                 </ItemTemplate>
             </asp:TemplateField>
                  <asp:TemplateField HeaderText="Qualification Name">
                      <ItemTemplate>
                           <%#Eval("qname") %>
                      </ItemTemplate>
                      </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="dlt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("qid") %>' />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("qid") %>' />
                     </ItemTemplate>
                 </asp:TemplateField>
                 </Columns>
             </asp:GridView></td>
     </tr>
 </table>
</asp:Content>
