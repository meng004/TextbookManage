//如果点击的是导出按钮则将AJAX禁用
function onRequestStart(sender, args) {
    if (args.get_eventTarget().indexOf("ExportToExcelButton") >= 0 ||
        args.get_eventTarget().indexOf("ExportToWordButton") >= 0 ||
        args.get_eventTarget().indexOf("ExportToPdfButton") >= 0 ||
        args.get_eventTarget().indexOf("ExportToCsvButton") >= 0) {
        args.set_enableAjax(false);
    }
}
/*获得打开的window，为通用的方式*/
function GetRadWindow() {
    var oWindow = null;
    if (window.radWindow)
        oWindow = window.radWindow; //Will work in Moz in all cases, including clasic dialog
    else if (window.frameElement.radWindow)
        oWindow = window.frameElement.radWindow; //IE (and Moz as well)
    return oWindow;
}
/*关闭窗口*/
function CloseWindow(sender, args) {
    if (false == confirm("您确认关闭此窗口吗?")) {
        args.set_cancel(true);
        return;
    }
    GetRadWindow().close();
    args.set_cancel(true);
    return;
}
/*刷新母体窗口，统一命名为refreshData*/
function FreshParentWindow(arg) {
    GetRadWindow().BrowserWindow.refreshData(arg);
    return false;
}
function FreshParentWindow() {
    GetRadWindow().BrowserWindow.refreshData();
    return false;
}
function ConfirmClicking(sender, args) {
    args.set_cancel(!window.confirm("您确认操作吗？"));
}
