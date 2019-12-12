<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="WebForm1.aspx.cs" Inherits="Employee_Database.WebForm1" EnableEventValidation="false"  %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <form id="form1">
    <div>




        <h1> Select the Employee to view the details</h1><br/>
        <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="abc">
          
        </asp:DropDownList><br/><br/>
        <%--  --%>

        
        



            </div>
       

       
       
        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList><br/><br/><br/><br/><br/>
        <asp:Label ID="Label1" runat="server" Text="Employee_name" Width="200"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br /><br /><br />
        
        <asp:Label ID="Label2" runat="server" Text="Employee_id" Width="200"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br/><br/><br/>

        <asp:Label ID="Label3" runat="server" Text="Employee_Address" Width="200"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br/><br/><br/>
        <asp:Label ID="Label4" runat="server" Text="Employee_Salary" Width="200"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br/><br/><br/><br/>

       <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="on_Add" /><br/><br/>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"   
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px">
      </asp:GridView>

        
    </form>

</asp:Content>








