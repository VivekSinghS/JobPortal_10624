<%@ Page Title="" Language="C#" MasterPageFile="~/AdminModule/Admin.Master" AutoEventWireup="true" CodeBehind="ManageJobRecruiter.aspx.cs" Inherits="JobPortal_10624.AdminModule.ManageJobRecruiter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td></td>
            <td><asp:GridView ID="grdmanageJobRecruiter" runat="server" AutoGenerateColumns="false" OnRowCommand="grdmanageJobRecruiter_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <%#Eval("jrId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Name">
                        <ItemTemplate>
                            <%#Eval("jrname") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Company Type">
                        <ItemTemplate>
                            <%#Eval("ctname") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email ID">
                        <ItemTemplate>
                            <%#Eval("jremail") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <%#Eval("jrpassword") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Person">
                        <ItemTemplate>
                            <%#Eval("jrcontactperson") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText ="Contact Number">
                      <ItemTemplate>
                       <%#Eval("jrcontactnumber") %>
                         </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comment">
                         <ItemTemplate>
                      <%#Eval("jrcomment") %>
                           </ItemTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField HeaderText="Inserted Date">
                            <ItemTemplate>
                        <%#Eval("jrinserted_date") %>
                             </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                        <%#Eval("jrstatus") %>
                              </ItemTemplate>
                              </asp:TemplateField>
                          <asp:TemplateField>
                              <ItemTemplate>
                                  <asp:Button ID="btnDelete" runat="server" Text='<%#Eval("jrstatus").ToString() == "0" ? "Active" : "InActive" %>' BackColor="Red" ForeColor="White" CommandName="dlt" CommandArgument='<%#Eval("jrid") %>' />
                              </ItemTemplate>
                          </asp:TemplateField>
                </Columns>
                </asp:GridView></td>
        </tr>
    </table>
</asp:Content>
