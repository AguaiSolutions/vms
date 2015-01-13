<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BirthDay.ascx.cs" Inherits="Vacation_management_system.Web.Common.BirthDay" %>


<div id="data" style=" padding-bottom: 20px;">
<asp:DataList ID="dtlist" runat="server" RepeatColumns="5" CellPadding="5">
<ItemTemplate>
<asp:Image ID="Image1"  ImageUrl='<%# Bind("image_url") %>' runat="server" style="padding-right:10px" Width="100px" Height="70px"/>
<br />
  <asp:Label ID="lblName"  Text='<%# Bind("name") %>' runat="server"></asp:Label>
    <br />
 <asp:Label ID="lbldob" Text='<%# Bind("dob") %>'  runat="server"></asp:Label>
</ItemTemplate>
<FooterTemplate>
<asp:Label Visible='<%# dtlist.Items.Count==0 %>'  runat="server" ID="Label1" ForeColor="Red" Text="No Records found"></asp:Label>
</FooterTemplate>
<ItemStyle  HorizontalAlign="Center"
VerticalAlign="Bottom" />
</asp:DataList>
</div><div>

</div>