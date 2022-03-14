<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InternsAppointmentManager.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <table style="width:100%">
        <tr>
            <td>
                <h1>Appointment Helper</h1>
            </td>
            <td style="text-align:right">
                <asp:Button ID="OpenAddPanel" runat="server" Text="Add New Appointment" OnClick="OpenAddPanel_Click" />
            </td>
        </tr>
    </table>
    
    <asp:Panel ID="AddNewPanel" runat="server" Visible="false">
        <table style="width:100%">
            <tr>
                <td style="width:315px">
                </td>
                <td>
                    First Name
                </td>
                <td>
                    Last Name 
                </td>
                <td>
                    Appointment Date Time
                </td>
                <td>
                    Appointment With Name
                </td>
                <td>
                    Appointment Reason
                </td>
            </tr>
            <tr>
                <td style="width:315px">
                    <asp:Button ID="CanceAddButton" runat="server" Text="Cancel" OnClick="CanceAddButton_Click" />
                    <asp:Button ID="SaveAddButton" runat="server" Text="Add Appointment" OnClick="SaveAddButton_Click" />
                </td>
                <td>
                    <asp:TextBox ID="FNameTxt" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="LNameTxt" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="ApptDateTxt" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="ApptWithTxt" runat="server"/>
                </td>
                <td>
                    <asp:TextBox ID="ApptReasonTxt" runat="server" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="ViewAppointmentsPanel" runat="server">
        <table style="width:100%">
            <tr>
                <td style="width:315px">
                </td>
                <td style="width:180px">
                    First Name
                </td>
                <td style="width:180px">
                    Last Name 
                </td>
                <td style="width:200px">
                    Appointment Date Time
                </td>
                <td style="width:200px">
                    Last Update Date Time
                </td>
                <td style="width:200px">
                    Appointment With Name
                </td>
                <td >
                    Appointment Reason
                </td>
            </tr>
        </table>
        <asp:DataList ID="AppointmentsDL" runat="server" Width="100%">
            <ItemTemplate>
                <table style="width:100%">
                    <tr>
                        <td style="width:315px">
                            <asp:Button ID="EditButton" runat="server" Text="Edit" OnClick="EditButton_Click" />
                            <asp:Label ID="indexLabel" runat="server" Text='<%# Container.ItemIndex %>' Visible="false" />
                        </td>
                        <td style="width:180px">
                            <asp:Label ID="FNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td style="width:180px">
                            <asp:Label ID="LNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:Label ID="ApptDateLabel" runat="server" Text='<%# Eval("AppointmentDateTime") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:Label ID="UpdateDateLabel" runat="server" Text='<%# Eval("UpdateDateTime") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:Label ID="ApptWithNameLabel" runat="server" Text='<%# Eval("AppointmentWithName") %>' />
                        </td>
                        <td>
                            <asp:Label ID="ApptReasonLabel" runat="server" Text='<%# Eval("AppointmentReason") %>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table style="width:100%">
                    <tr>
                        <td style="width:315px">
                            <asp:Button ID="DeleteButton" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
                            <asp:Button ID="SaveButton" runat="server" Text="Save" OnClick="SaveButton_Click" />
                            <asp:Label ID="indexLabel" runat="server" Text='<%# Container.ItemIndex %>' Visible="false" />
                        </td>
                        <td style="width:180px">
                            <asp:TextBox ID="FNameTextBox" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td style="width:180px">
                            <asp:TextBox ID="LNameTextBox" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:TextBox ID="ApptDateTextBox" runat="server" Text='<%# Eval("AppointmentDateTime") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:Label ID="UpdateDateTextBox" runat="server" Text='<%# Eval("UpdateDateTime") %>' />
                        </td>
                        <td style="width:200px">
                            <asp:TextBox ID="ApptWithTextBox" runat="server" Text='<%# Eval("AppointmentWithName") %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="ApptReasonTextBox" runat="server" Text='<%# Eval("AppointmentReason") %>' />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:DataList>
    </asp:Panel>
</asp:Content>
