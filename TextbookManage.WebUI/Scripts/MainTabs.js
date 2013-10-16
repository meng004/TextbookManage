
$(function () {


    $('.rtLI a').click(function () {
        var tabTitle = $(this).text();
        var url = $(this).attr("href");
        addTab(tabTitle, url);
        return false;
    });
    $('.rpItem a').click(function () {
        var tabTitle = $(this).text();
        var url = $(this).attr("href");
        if (url != '#') {
            addTab(tabTitle, url);
            return false;
        }
        else
            return true;
    });
    BindMenuEvent();
})

function BindTabEvent() {
    /*双击关闭TAB选项卡*/
    $('.tabs-inner').has('span.tabs-closable')
    .dblclick(function () {
        var subtitle = $(this).children("span").text();
        $('#tabs').tabs('close', subtitle);
    })
    .bind('contextmenu', function (e) {
        var subtitle = $(this).children("span").text();
        $('#tabs').tabs('select', subtitle);
        $('#mm').menu('show', { left: e.pageX, top: e.pageY });
        $('#mm').data("currtab", subtitle);
        return false;
    });
}
//绑定右键菜单事件
function BindMenuEvent() {
    //关闭当前
    $('#mm-tabclose').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('#tabs').tabs('close', currtab_title);
    })
    //全部关闭
    $('#mm-tabcloseall').click(function () {
        $('.tabs-inner').has('span.tabs-closable').each(function (i, n) {
            $('#tabs').tabs('close', $(n).text());
        });
    });
    //关闭除当前之外的TAB
    $('#mm-tabcloseother').click(function () {
        var currtab_title = $('#mm').data("currtab");
        $('.tabs-inner').has('span.tabs-closable').each(function (i, n) {
            var t = $(n).text();
            if (t != currtab_title)
                $('#tabs').tabs('close', t);
        });
    });
    //关闭当前右侧的TAB
    $('#mm-tabcloseright').click(function () {
        var nextall = $('.tabs-selected').nextAll();
        if (nextall.length == 0) {
            alert('后边没有啦~~');
            return false;
        }
        nextall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            $('#tabs').tabs('close', t);
        });
        return false;
    });
    //关闭当前左侧的TAB
    $('#mm-tabcloseleft').click(function () {
        var prevall = $('.tabs-selected').prevAll();
        if (prevall.length == 0) {
            alert('到头了，前边没有啦~~');
            return false;
        }
        prevall.each(function (i, n) {
            var t = $('a:eq(0) span', $(n)).text();
            if ($('#tabs').tabs('getTab', t).panel('options').closable) {
                $('#tabs').tabs('close', t);
            }
        });
        return false;
    });
}

function addTab(subtitle, url) {
    if (!$('#tabs').tabs('exists', subtitle)) {
        $('#tabs').tabs('add', {
            title: subtitle,
            content: createFrame(url),
            closable: true,
            width: $('#mainPanle').width() - 5,
            height: $('#mainPanle').height() - 5
        });
        BindTabEvent();
    }
    else {
        $('#tabs').tabs('select', subtitle);
    }
}
function createFrame(url) {
    var s = '<iframe name="mainFrame"   src="' + url + '" style="width:100%;height:100%;border:0px"></iframe>';
    return s;
}
function ChangePassWord(sender, args) {
    var tabTitle = "修改登录密码";
    var url = "StudentChangePassWord.aspx";
    addTab(tabTitle, url);
    args.set_cancel(true);
}


