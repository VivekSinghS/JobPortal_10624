<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekerModule/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeeker_Registration.aspx.cs" Inherits="JobPortal_10624.JobSeekerModule.JobSeeker_Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
         <tr>
         <td>Name :</td>
        <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
        <td>JobProfile :</td>
        <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
         </tr>
            <tr>
            <td>Job Exp :</td>
          <td><asp:DropDownList ID="ddlExp" runat="server"></asp:DropDownList></td>
       </tr>
       <tr>
      <td>Qualification :</td>
     <td><asp:DropDownList ID="ddlQualification" runat="server"></asp:DropDownList></td>
     </tr>
        <tr>
        <td>Country :</td>
    <td><asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>State :</td>
    <td><asp:DropDownList ID="ddlstate" runat="server" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
   </tr>
   <tr>
    <td>City :</td>
    <td><asp:DropDownList ID="ddlcity" runat="server"></asp:DropDownList></td>
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
     <td>Image Upload :</td>
     <td><asp:FileUpload ID="fuImage" runat="server" /></td>
    </tr>
    <tr>
     <td>Resume Upload :</td>
     <td><asp:FileUpload ID="fuResume" runat="server" /></td>
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
