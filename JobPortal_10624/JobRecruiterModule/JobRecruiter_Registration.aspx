<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_Registration.aspx.cs" Inherits="JobPortal_10624.JobRecruiterModule.JobRecruiter_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
         <tr>
         <td>Company Name  :</td>
        <td><asp:TextBox ID="txtcompanyName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td> Company Type:</td>
        <td><asp:DropDownList ID="ddlcompanytype" runat="server"></asp:DropDownList></td>
         </tr>
           
       
       <tr>
      <td>Email :</td>
      <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
      </tr>
     <tr>
     <td>Password :</td>
     <td><asp:TextBox ID="txtpassword" runat="server"></asp:TextBox></td>
     </tr>
      <tr>
       <td>Contact Person  :</td>
      <td><asp:TextBox ID="txtcontactperson" runat="server"></asp:TextBox></td>
     </tr>
      <tr>
      <td>Contact Number  :</td>
      <td><asp:TextBox ID="txtcontactno" runat="server" TextMode="Phone"></asp:TextBox></td>
    </tr>
     <tr>
        <td>Comment :</td>
        <td><asp:TextBox ID="txtcomment" runat="server"></asp:TextBox></td>
     </tr>
     <tr>
        <td></td>
       <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" BackColor="Red" ForeColor="White"  OnClick="btnSubmit_Click"/></td>
      </tr>
     </table>
</asp:Content>
