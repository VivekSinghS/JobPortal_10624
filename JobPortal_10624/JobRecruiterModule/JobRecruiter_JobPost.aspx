<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_JobPost.aspx.cs" Inherits="JobPortal_10624.JobRecruiterModule.JobRecruiter_JobPost" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>JobProfile :</td>
            <td><asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList></td>
        </tr> 
        <tr>
            <td>Preferd Gender</td>
            <td>
                <asp:RadioButtonList ID="rblGender" RepeatColumns="3" runat="server">
                    <asp:ListItem Text="Male" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Female" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Both" Value="3"></asp:ListItem>
                </asp:RadioButtonList> 
            </td>
        </tr>
         <tr>
            <td>Minimum Job Exp :</td>
            <td><asp:DropDownList ID="ddlMinExp" runat="server">
                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                </asp:DropDownList></td>
        </tr>
         <tr>
             <td>Maximum Job Exp :</td>
             <td><asp:DropDownList ID="ddlMaxExp" runat="server">
                 <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                 <asp:ListItem Text="1" Value="1"></asp:ListItem>
                 <asp:ListItem Text="2" Value="2"></asp:ListItem>
                 <asp:ListItem Text="3" Value="3"></asp:ListItem>
                 <asp:ListItem Text="4" Value="4"></asp:ListItem>
                 <asp:ListItem Text="5" Value="5"></asp:ListItem>
                 <asp:ListItem Text="6" Value="6"></asp:ListItem>
                 <asp:ListItem Text="7" Value="7"></asp:ListItem>
                 <asp:ListItem Text="8" Value="8"></asp:ListItem>
                 </asp:DropDownList></td>
        </tr>
        <tr>
             <td>Minimum Salary Offer :</td>
             <td><asp:TextBox ID="txtminSalary" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
              <td>Maximum Salary Offer :</td>
              <td><asp:TextBox ID="txtmaxSalary" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
               <td>Comment :</td>
               <td><asp:TextBox ID="txtComment" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnjobpost" runat="server" Text="Job Post" BackColor="Red" ForeColor="White" OnClick="btnjobpost_Click"/></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label></td>
        </tr>
    </table>

</asp:Content>
