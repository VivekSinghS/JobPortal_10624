<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCities.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageCities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

                <table>
                <tr>
              <td>Countries Name :</td>
             <td><asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                </tr>
          
              <tr>
            <td>States Name :</td>
             <td><asp:DropDownList ID="ddlstatesName" runat="server"></asp:DropDownList></td>
         </tr>
            <tr>
                <td>City Name :</td>
                <td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
            </tr>
           <tr>
        <td></td>
        <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" BackColor="Red" ForeColor="White" OnClick="btnsubmit_Click" /> </td>
        </tr>
         <tr>
        <td></td>
        <td><asp:GridView ID="grdCity" runat="server" AutoGenerateColumns="false"  OnRowCommand="grdCity_RowCommand">
            <Columns>
            <asp:TemplateField HeaderText="Countrty Id">
                <ItemTemplate>
                    <%#Eval("cid") %>
                </ItemTemplate>
            </asp:TemplateField>
                <asp:TemplateField HeaderText="State Id">
                    <ItemTemplate>
                        <%#Eval("stid") %>
                    </ItemTemplate>
                </asp:TemplateField>
               <%-- <asp:TemplateField>
                    <ItemTemplate>
                       
                    </ItemTemplate>
                </asp:TemplateField>--%>
                 <asp:TemplateField HeaderText="City Name">
                     <ItemTemplate>
                          <%#Eval("cityname") %>
                     </ItemTemplate>
                     </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="dlt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("cityid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="edt" BackColor="Red" ForeColor="White" Height="25px" Width="70px" CommandArgument='<%#Eval("cityid") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView></td>
    </tr>
</table>
</asp:Content>
