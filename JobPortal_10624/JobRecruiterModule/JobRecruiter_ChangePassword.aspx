<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_ChangePassword.aspx.cs" Inherits="JobPortal_10624.JobRecruiterModule.JobRecruiter_ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table>
     <tr>
         <td>Current Password</td>
        <td>  <asp:TextBox ID="txtcurrentpasword" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
          <td>New Password</td>
         <td><asp:TextBox ID="txtnewpasword" runat="server"></asp:TextBox></td>
     </tr>
         <tr>
          <td>Current Password</td>
         <td>  <asp:TextBox ID="txtconfirmpasword" runat="server"></asp:TextBox> </td>
     </tr>
     <tr>
         <td></td>
         <td><asp:Button ID="btnchangpasword" runat="server" Text="Change Password" OnClick="btnchangpasword_Click" /></td>
     </tr>
     <tr>
         <td></td>
         <td>
             <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
         </td>
     </tr>
 </table>

</asp:Content>
