<%@ Page Title="" Language="C#" MasterPageFile="~/JobRecruiterModule/JobRecruiter.Master" AutoEventWireup="true" CodeBehind="JobRecruiter_JobPostList.aspx.cs" Inherits="JobPortal_10624.JobRecruiterModule.JobRecruiter_JobPostList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
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
                  Rs. <%#Eval("jpsminsalary") %> - Rs. <%#Eval("jpsmaxsalary") %>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <%#Eval("jpscomment") %>
                        </ItemTemplate>
                      </asp:TemplateField>
                      <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                           <%#Eval("jpsinserted_date") %>
                                 </ItemTemplate>
                                </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status">
                                 <ItemTemplate>
                                  <%#Eval("jpsstatus") %>
                                         </ItemTemplate>
                                    </asp:TemplateField>
                                  <asp:TemplateField>
                                      <ItemTemplate>
                                 <asp:Button ID="btndelete" runat="server" Text='<%#Eval("jpsstatus").ToString()=="0" ? "Active" : "InActive" %>' BackColor="Red" ForeColor="Wheat" CommandName="Dlt" CommandArgument='<%#Eval("jpsid") %>' />
                                    </ItemTemplate>
                                       </asp:TemplateField>

                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="Edt" CommandArgument='<%#Eval("jpsid") %>' />
                                  </ItemTemplate>
                              </asp:TemplateField>

                    </Columns>
                </asp:GridView></td>
        </tr>
    </table>
</asp:Content>
