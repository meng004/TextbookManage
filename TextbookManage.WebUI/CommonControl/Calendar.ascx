<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Calendar.ascx.cs" Inherits="USCTAMis.WebPage.CommonControl.Calendar" %>
<utm:utmisgrid id="wg_Calendar" runat="server" width="295px" height="220px" skinid="Calendar" onitemdatabound="wg_Calendar_ItemDataBound" onbeforedatabind="wg_Calendar_BeforeDataBind" clientsettings-scrolling-scrollheight="300px">
    <MasterTableView>
        <Columns>
            <telerik:GridBoundColumn DataField="Week"  UniqueName="Week" ItemStyle-BackColor="#ECF4FF" HeaderText="周"   />
            <telerik:GridBoundColumn DataField="Sunday" UniqueName="Sunday" ItemStyle-ForeColor="Red" HeaderText="日" />
            <telerik:GridBoundColumn DataField="Monday" UniqueName="Monday" HeaderText="一"  />
            <telerik:GridBoundColumn DataField="Tuesday" UniqueName="Tuesday" HeaderText="二"   />
            <telerik:GridBoundColumn DataField="Wednesday" UniqueName="Wednesday" HeaderText="三"   />
            <telerik:GridBoundColumn DataField="Thursday" UniqueName="Thursday" HeaderText="四"   />
            <telerik:GridBoundColumn DataField="Friday" UniqueName="Friday" HeaderText="五"   />
            <telerik:GridBoundColumn DataField="Saturday" UniqueName="Saturday" ItemStyle-ForeColor="Red" HeaderText="六"  />
        </Columns>
    </MasterTableView>
</utm:utmisgrid>
