<%@ Page Title="" Language="C#" MasterPageFile="~/JobSeekerModule/JobSeeker.Master" AutoEventWireup="true" CodeBehind="JobSeeker_ApplyJobs.aspx.cs" Inherits="JobPortal_10624.JobSeekerModule.JobSeeker_ApplyJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <table>
        <tr>
            <td>
                <asp:DropDownList ID="ddljobprofile" runat="server"></asp:DropDownList>
                <asp:TextBox ID="txtsalary" runat="server"></asp:TextBox>
                <asp:Button ID="btnsearch" runat="server" Text="Search" OnClick="btnsearch_Click" />
            </td>
        </tr>

         <tr>
     <td></td>
     <td><asp:GridView ID="grdjobpostlist" runat="server" AutoGenerateColumns="false" OnRowCommand="grdjobpostlist_RowCommand">
         <Columns>
             <asp:TemplateField HeaderText="Job Post ID">
             <ItemTemplate>
                 <%#Eval("jpsid") %>
             </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText="Job Recruiter">
                <ItemTemplate>
               <%#Eval("jrname") %>
                 </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText="Job Profile">
                 <ItemTemplate>
               <%#Eval("jpname") %>
                 </ItemTemplate>
                </asp:TemplateField>
              <asp:TemplateField HeaderText="Gender">
                      <ItemTemplate>
                         <%#Eval("jpsgender").ToString()== "0" ? "male" : Eval("jpsgender").ToString()== "1" ? "female" : "Both" %>
                       </ItemTemplate>
                    </asp:TemplateField>
             <asp:TemplateField HeaderText="Required Exp.">
             <ItemTemplate>
               <%#Eval("jpsminexp") %> Year -  <%#Eval("jpsmaxexp") %> Year
                 </ItemTemplate>
              </asp:TemplateField>
             <asp:TemplateField HeaderText="Offerd Salary">
             <ItemTemplate>
              Rs.<%#Eval("jpsminsalary") %> - Rs.<%#Eval("jpsmaxsalary") %>
             </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Comments">
                 <ItemTemplate>
                     <%#Eval("jpscomment") %>
                 </ItemTemplate>
               </asp:TemplateField>
              <asp:TemplateField HeaderText="Comments">
                         <ItemTemplate>
                     <asp:Button ID="btnaply" runat="server" Text="Apply" CommandName="Apy"  CommandArgument= '<%#Eval("jpsid") %>'/>
                         </ItemTemplate>
                          </asp:TemplateField>
                         
                      </Columns>
                   </asp:GridView></td>
                         </tr>
                       </table>

</asp:Content>
