<%@ Page Title="EnrollStudent" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="EnrollStudent.aspx.cs" Inherits="EnrollStudent" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
            <h1>Зарегистрироваться на курс</h1>
            <p></p>
        </div>
        <div>
            <label>Ваша фамилия:</label><asp:TextBox ID="LastName" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator id="nameRegex" runat="server" ControlToValidate="LastName" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ErrorMessage="Фамилия введена неверно!" />
        </div>
        <div>
            <label>Ваша имя:</label><asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator id="RegularExpressionValidator1" runat="server" ControlToValidate="FirstName" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ErrorMessage="Имя введено неверно!" />
        </div>
        <div>
            <label>Ваш балл:</label><asp:TextBox ID="Grade" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator id="RegularExpressionValidator2" runat="server" ControlToValidate="Grade" ValidationExpression="^[0-9'.\s]{1,4}$" ErrorMessage="Балл введен неверно!" />
        </div>
        <div>
            <label>Курс:</label>
            <asp:DropDownList id="Courses" 
                              runat="server" 
                              AutoPostBack="False"/> 
            
        </div>
        <div>
            <button type="submit">Записаться</button>
        </div>
</asp:Content>
