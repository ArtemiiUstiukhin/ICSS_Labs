<%@ Page Title="ShowStudents" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ShowStudents.aspx.cs" Inherits="ShowStudents" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <label>Курс:</label>
        <asp:DropDownList id="Courses" 
                              runat="server" 
                              AutoPostBack="True"/> 
        </div>
         <asp:table ID="CourseTable" runat="server">
             <asp:TableHeaderRow>
                 <asp:TableCell Text="First Name"/>
                 <asp:TableCell Text="Last Name"/>
                 <asp:TableCell Text="Remove Student"/>
             </asp:TableHeaderRow>
         </asp:table>        
    </div>
</asp:Content>
