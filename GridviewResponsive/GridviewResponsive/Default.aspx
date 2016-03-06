<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridviewResponsive.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Ordre ikke levert</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="Content/bootstrap.cosmo.min.css" rel="stylesheet" />
    <link href="Content/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
             </asp:ScriptManager>
             <asp:Timer ID="Timer1" runat="server" Interval="5000" OnTick="Timer1_Tick">
             </asp:Timer>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">  </asp:UpdatePanel>
             <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
                  AutoGenerateColumns="False" DataKeyNames="Varenr"  BorderColor="Tan" BorderWidth="1px" 
                 CellPadding="2" ForeColor="Black" GridLines="None" style="font-size:18pt;" Width="100%" HorizontalAlign="Center" OnRowDataBound="GridView1_RowDataBound" >
              <Columns>
                                            <asp:BoundField DataField="Varenr" HeaderText="Ordrenr" ReadOnly="True" SortExpression="Varenr" >
                                                    <ItemStyle Width="40px"  HorizontalAlign="Center"></ItemStyle>
                                             </asp:BoundField>
                                            <asp:BoundField DataField="Varenavn" HeaderText="Varenavn" SortExpression="Varenavn" >
                   <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                  </asp:BoundField>
                                            <asp:BoundField DataField="Ansvarlig" HeaderText="Ansvarlig" SortExpression="Ansvarlig" >
                   <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                  </asp:BoundField>
                                            <asp:BoundField DataField="Kunde" HeaderText="Kunde" SortExpression="Kunde" >
                   <ItemStyle HorizontalAlign="Center" ></ItemStyle>
                  </asp:BoundField>
                                            <asp:BoundField DataField="ForventetLevering" HeaderText="ForventetLevering" SortExpression="ForventetLevering" DataFormatString="{0:dd/MM/yyyy}"  >
                                                  <ItemStyle Width="50px"  HorizontalAlign="Center"></ItemStyle>
                  </asp:BoundField>
             </Columns>   
                  <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <FooterStyle BackColor="Tan" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <SortedAscendingCellStyle BackColor="#FAFAE7" />
                <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                <SortedDescendingCellStyle BackColor="#E1DB9C" />
                <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
       
            
        <!--  <div id="mainContainer" class="container" >
            <div class="shadowBox">
                <div class="page-container">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-12 ">
                                <div class="table-responsive" > 
                                      <asp:GridView ID="grdCustomer" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" DataKeyNames="Varenr" EmptyDataText="There are no data records to display.">
                                        <Columns>
                                            <asp:BoundField DataField="Varenr" HeaderText="Varenr" ReadOnly="True" SortExpression="Varenr" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                                            <asp:BoundField DataField="Varenavn" HeaderText="Varenavn" SortExpression="Varenavn" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                                            <asp:BoundField DataField="Ansvarlig" HeaderText="Ansvarlig" SortExpression="Ansvarlig" ItemStyle-CssClass="visible-lg" HeaderStyle-CssClass="visible-lg" />
                                            <asp:BoundField DataField="Kunde" HeaderText="Kunde" SortExpression="Kunde" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                                            <asp:BoundField DataField="Bestillinsdato" HeaderText="Bestillinsdato" SortExpression="Bestillinsdato" ItemStyle-CssClass="visible-md" HeaderStyle-CssClass="visible-md" />
                                            <asp:BoundField DataField="ForventetLevering" HeaderText="ForventetLevering" SortExpression="ForventetLevering" ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                                            <asp:BoundField DataField="Levertdato" HeaderText="Levertdato" SortExpression="Levertdato" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                                         </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        !-->
    </form>
</body>
</html>
