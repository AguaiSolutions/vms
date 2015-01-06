<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BirthDay.ascx.cs" Inherits="Vacation_management_system.Web.Common.BirthDay" %>
<div>
<asp:DataList ID="dtlist" runat="server" RepeatColumns="5" CellPadding="5">
<ItemTemplate>
<asp:Image ID="Image1" runat="server"  Width="100px" Height="70px"/>
    <%--<asp:Image ID="Image2"  ImageUrl='<%# Bind("image", "~/Web/Images/{0}") %>' runat="server"  Width="100px" Height="70px"/>--%>
<br />
  <asp:Label ID="lblName"  Text='<%# Bind("name") %>' runat="server"></asp:Label>
    <br />
 <asp:Label ID="lbldob" Text='<%# Bind("dob") %>'  runat="server"></asp:Label>
</ItemTemplate>
<ItemStyle  HorizontalAlign="Center"
VerticalAlign="Bottom" />
</asp:DataList>
</div><div>

</div>