function GetSelectedText() {
    var txt = '';
    if (window.getSelection) {
        txt = window.getSelection().toString();
    }
    else if (document.getSelection) {
        txt = document.getSelection().toString();
    }
    else if (document.selection) {
        txt = document.selection.createRange().text;
    }
    else return;
    return txt;
}
/* Usage: var idInteger = Base62Decode('AbsjdDd') */
function Base62Decode(a, b, c, d) { for (b = c = 0; d = a.charCodeAt(c++); b = b * 62 + d - [, 48, 29, 87][d >> 5]); return b; }

/* Usage: var queryStringValue = Q('UserId',0); - returns UserId from query string, or 0 for default.  This is case sensitive. */
function Q(key, default_) {
    if (default_ == null) default_ = "";
    key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
    var qs = regex.exec(window.location.href);
    if (qs == null)
        return default_;
    else
        return qs[1];
}
function Query() {
    var ix = window.location.href.indexOf('?');
    if (ix < 1) return '';
    return window.location.href.substring(ix + 1);
}

//Converts value from a model to a date obj
function asDate(value) {
    return new Date(parseInt(value.substring(6, value.length - 2)));
}

//For use with number formatting
function addCommas(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

function HideViewsNear(toView) {
    $(toView).parent().find(".view").not(toView).hide();
}
function SwitchView(toView, dontAddToBackQue) {
    if (!dontAddToBackQue) AddBack(toView);
    HideViewsNear(toView);
    $(toView).find('.commandButtons').show();
    $(toView).find('.loading').hide();
    $(toView).fadeIn('slow');
}
function DeleteSelectedItems(container, vm) {
    var $container = $(container);
    for (var ix = 0; ix < vm.Items.length; ix++) {
        if (vm.Items[ix]._IsSelected) {
            vm.Items[ix]._IsSelected = false;
            vm.Items[ix]._IsDeleted = true;
            if (ix == vm.Items.length - 1) $container.find("HR:visible").last().fadeOut('fast');
        }
    }
    //If current item is last, remove last hr
    if (vm.CurrentIndex == vm.Items.length - 1 && vm.CurrentItem._IsDeleted == true) {
        $container.find("HR:visible").last().fadeOut('fast');
    }
    vm.Items[vm.CurrentIndex]._IsSelected = false;
    vm.Items[vm.CurrentIndex]._IsDeleted = true;
    vm.setCurrentIndex(-1);

    var floatingActions = $container.find(".floating-actions");
    floatingActions.hide();
    floatingActions.detach();
    floatingActions.appendTo($container);

    var selected = $container.find(".selected");
    selected.removeClass(".selected").slideUp('fast')
    selected.next("HR").fadeOut('fast');

}
function HideIf(test, obj) { if (test) return null; return $(obj); }
function SelectItem(rowObj, vm, index, multiSelect, toggle) {
    var rowContainer = $(rowObj).parent();
    var permissionCheck = eval(rowContainer.attr("data-permissions"));
    var floatingActions = rowContainer.find(".floating-actions");
    floatingActions.hide();
    floatingActions.detach();

    var isSelected = $(rowObj).hasClass("selected");
    if (!multiSelect) {
        rowContainer.children(".selectable").removeClass("selected");
        for (var ix = 0; ix < vm.Items.length; ix++) {
            vm.Items[ix]._IsSelected = false;
        }
    }

    if (isSelected && toggle) {
        floatingActions.appendTo(rowContainer);
        floatingActions.hide();

        vm.setCurrentIndex(-1);
        vm.Items[index]._IsSelected = false;

        $(rowObj).removeClass("selected");
    } else {
        $(rowObj).addClass("selected");

        $(rowObj).after(floatingActions);

        floatingActions.show();
        vm.Items[index]._IsSelected = true;
        vm.setCurrentIndex(index);

        //Check permissions?
        if (typeof permissionCheck == 'function') {
            floatingActions.find(".btn").hide();
            permissionCheck(vm, vm.Items[index]);
        }

        if (floatingActions.not(":hidden").length == 0) floatingActions.hide();
        else floatingActions.show();
    }
}

function UnselectAllInView(view, dontChangeIndex) {
    var rowContainer = view.viewRender.find(".listWrap");
    if (rowContainer.length == 0) rowContainer = view.viewRender;
    var floatingActions = rowContainer.find(".floating-actions");
    var vm = view.viewModel;

    floatingActions.hide();
    floatingActions.detach();
    floatingActions.appendTo(rowContainer);
    floatingActions.hide();

    rowContainer.children(".selectable").removeClass("selected");
    for (var ix = 0; ix < vm.Items.length; ix++) {
        vm.Items[ix]._IsSelected = false;
    }

    if (!dontChangeIndex) vm.setCurrentIndex(-1);
}
function ShowButtons(buttonIds) {
    $(buttonIds).fadeIn('fast');
}
function HideButtons(buttonIds) {
    $(buttonIds).fadeOut('fast');
}

function StartLoading(container) {
    if (container === undefined) container = $(document);
    $(container).find('.commandButtons').hide();
    $(container).find('.loading').fadeIn('fast');
    $(container).find('.largeLoading').fadeIn('fast');
}
function FinishLoading(container) {
    if (container === undefined) container = $(document);
    $(container).find('.commandButtons').fadeIn('fast');
    $(container).find('.loading').fadeOut('fast');
    $(container).find('.largeLoading').fadeOut('fast');
}

var backActions = [];
var backIndex = -1;

function NavBack() {
    GoBack(window.backIndex - 1);
}
function GoBack(index) {
    window.backIndex = index;
    var view = window.backActions[window.backIndex];

    $(view).find('.commandButtons').show();
    $(view).find('.loading').hide();

    SwitchView(view, true);
    UpdateBreadcrum();
    if (window.backIndex <= 0) $('#NavBackButton').fadeOut();
}
function AddBack(view) {
    if (window.backActions[backIndex] != view) {
        window.backActions[backIndex + 1] = view;
        window.backIndex++;
        if (window.backIndex >= 1) $('#NavBackButton').fadeIn();
        UpdateBreadcrum();
    }
}
function ClearBack() {
    window.backIndex = -1;
    window.backActions = [];
    $('#NavBackButton').fadeOut();
    UpdateBreadcrum();
}
function UpdateBreadcrum() {
    var crumDiv = $('.breadcrum');

    window.crumList = [];
    window.crumList[0] = { "title": crumDiv.attr('title'), "index": 0 };
    window.crumIndex = 0;

    window.crumIndex = 1;
    var i = 0;
    while (i <= window.backIndex) {
        var viewNames = window.backActions[i];

        window.crumTitle = '';

        $(viewNames).each(function () {
            var title = $(this).attr('title');
            if (title) {
                if (window.crumTitle != '') window.crumTitle += " / ";
                window.crumTitle += title;
            }
        });
        if (window.crumTitle != '') {

            window.crumList[window.crumIndex] =
                {
                    "title": window.crumTitle,
                    "index": i
                };
            window.crumIndex++;
        }
        i++;
    }

    i = 0;
    var html = '<ul class="nav nav-pills">';
    while (i < window.crumIndex) {
        var crum = window.crumList[i];
        var active = '';
        if (i == window.crumIndex - 1) active = ' class="active"'
        html +=
            '<li ' + active + '><a class="clickable" href="#" onclick="GoBack(' + crum.index + ');return false;">' + crum.title + '</a></li>';
        i++;
    }
    html += '</ul>';
    crumDiv.html(html);
}
function ListClear(list) {
    $(list).find("OPTION").remove();
}
function ListAdd(list, text, value, selected) {
    var item = $('<option/>').val(value).html(text);
    if (selected) item.attr('selected', 'selected');
    $(list).append(item);
    return item;
}

function ListBind(list, items, textField, valueField, overwrite) {
    $(list).each(function () {
        if (overwrite) ListClear($(this));
        var selectedValue = $(this).attr('autoselect');
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            var text = item[textField];
            var value = item[valueField];
            var listItem = ListAdd($(this), text, value, ((selectedValue || '').toString() == (value || '').toString()));
        }
    });
}



$(document).ready(OnViewBound);

function OnViewBound() {
    //Run these methods after a view is bound.
    $("[validation-decimal]").forceDecimal();
    $("[validation-integer]").forceInteger();
}

// forceDecimal() plug-in implementation
jQuery.fn.forceDecimal = function () {

    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.which || e.keyCode;

            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
            // numbers   
                         key >= 48 && key <= 57 ||
            // Numeric keypad
                         key >= 96 && key <= 105 ||
            // comma, period and minus, . on keypad
                        key == 190 || key == 188 || key == 109 || key == 110 ||
            // Backspace and Tab and Enter
                        key == 8 || key == 9 || key == 13 ||
            // Home and End
                        key == 35 || key == 36 ||
            // left and right arrows
                        key == 37 || key == 39 ||
            // Del and Ins
                        key == 46 || key == 45)
                return true;

            return false;
        });
    });
}
// forceInteger() plug-in implementation
jQuery.fn.forceInteger = function () {

    return this.each(function () {
        $(this).keydown(function (e) {
            var key = e.which || e.keyCode;

            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
            // numbers   
                         key >= 48 && key <= 57 ||
            // Numeric keypad
                         key >= 96 && key <= 105 ||
            // comma, period and minus, . on keypad
                        key == 190 || key == 188 || key == 109 || key == 110 ||
            // Backspace and Tab and Enter
                        key == 8 || key == 9 || key == 13 ||
            // Home and End
                        key == 35 || key == 36 ||
            // left and right arrows
                        key == 37 || key == 39 ||
            // Del and Ins
                        key == 46 || key == 45)
                return true;

            return false;
        });
    });
}