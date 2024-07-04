<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobSeeker.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageJobSeeker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table>
     <tr>
         <td></td>
         <td><asp:GridView ID="grdmanageJobSeeker" runat="server" AutoGenerateColumns="false" OnRowCommand="grdmanageJobSeeker_RowCommand">
             <Columns>
                 <asp:TemplateField HeaderText="Id">
                     <ItemTemplate>
                         <%#Eval("jsId") %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Name">
                     <ItemTemplate>
                         <%#Eval("jsname") %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="EmailID">
                     <ItemTemplate>
                         <%#Eval("jsemail") %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                      <%#Eval("jsPassword") %>
                         </ItemTemplate>
                        </asp:TemplateField>
                 <asp:TemplateField HeaderText="Job Profile">
                     <ItemTemplate>
                         <%#Eval("jpname") %> 
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Experiance">
                     <ItemTemplate>
                         <%#Eval("jename") %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Qualification">
                     <ItemTemplate>
                         <%#Eval("qName") %>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText ="JobSeeker Address">
                   <ItemTemplate>
                  <%#Eval("cityName") %> , <%#Eval("stName") %>  , <%#Eval("cName") %>   
                      </ItemTemplate>
                     </asp:TemplateField>
                 <asp:TemplateField HeaderText="Photo">
                      <ItemTemplate>
                        <%#Eval("jsPhoto") %>
                        </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText=" Resume ">
                             <ItemTemplate>
                         <%#Eval("jsResume") %>  
                            </ItemTemplate>
                          </asp:TemplateField>
                     <asp:TemplateField HeaderText=" Comments ">
                                <ItemTemplate>
                             <%#Eval("jscomment") %>  
                                 </ItemTemplate>
                              </asp:TemplateField>
                       <asp:TemplateField HeaderText="Inserted Date">
                         <ItemTemplate>
                     <%#Eval("jsinserted_date") %>
                          </ItemTemplate>
                             </asp:TemplateField>
                           <asp:TemplateField HeaderText="Status">
                             <ItemTemplate>
                     <%#Eval("jsstatus") %>
                           </ItemTemplate>
                           </asp:TemplateField>
                       <asp:TemplateField>
                           <ItemTemplate>
                               <asp:Button ID="btnDelete" runat="server" Text='<%#Eval("jsstatus").ToString()== "0" ? "Active" : "InActive" %>' BackColor="Red" ForeColor="White" CommandName="dlt" CommandArgument='<%#Eval("jsid") %>' />
                           </ItemTemplate>
                       </asp:TemplateField>
             </Columns>
             </asp:GridView></td>
     </tr>
 </table>
</asp:Content>
