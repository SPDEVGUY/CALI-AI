//Requires:
//  json2.js
//  md5.js
//  util/jquery.js

window.dal = (function ($, md5, window, json) {
    var _ = {};

    _.window = window;
    _.Hash = md5;
    _.ExceptionHandler = window.HandleException || function (xhr, ajaxOptions, thrownError) { window.alert(thrownError); };
    _.ServiceBaseUrl = ''; //Set this to the url where services are, if on a diff domain or sub domain.
    _.LastAction = '';
    _.LastDataSent = '';
    _.JSON = json;
    
    _.Get = function(context, url, onSuccess, onFail) {
        _.LastAction = 'GET ' + url;
        _.LastDataSent = '';
        
        $.ajax({
            type: "GET",
            url: url,
            dataType: "json",
            data: {},
            cache: false,
            contentType: "application/json; charset=utf-8",
            context: context,
            success: onSuccess,
            error: onFail
        });
    };
    _.QueryString = function(name) {
        if (window.location.search == '') return null;
        var qs = window.location.search.substring(1);
        var items = qs.split("&");
        for (var i = 0; i < items.length; i++) {
            var item = items[i].split("=");
            if (item[0] == name) {
                return item[1];
            }
        }
        return null;
    };

    _.FormatString = function(str) {
        for (var i = 1; i < arguments.length; i++) {
            str = str.replace('{' + (i - 1) + '}', arguments[i]);
        }
        return str;
    };

    _.doGet = function(viewModel, schema, table, query, onSuccess, onFail) {
        var userToken = "ANON";
        if (_.auth) userToken = _.auth.UserToken;
        var url = _.ServiceBaseUrl + "/" + schema + "/" + table + "/" + userToken + "/" + query;

        _.Get(viewModel, url, onSuccess, onFail);
    };
    _.doPost = function(viewModel, schema, table, query, data, onSuccess, onFail) {
        var userToken = "ANON";
        if (_.auth) userToken = _.auth.UserToken;
        var url = _.ServiceBaseUrl + "/" + schema + "/" + table + "/" + userToken + "/" + query;
        var dataStr = _.JSON.stringify(data);
        _.LastAction = 'POST ' + url;
        _.LastDataSent = dataStr;

        $.ajax({
            type: "POST",
            url: url,
            dataType: "json",
            data: dataStr,
            context: viewModel,
            cache: false,
            contentType: "application/json; charset=utf-8",
            success: onSuccess,
            error: onFail
        });
    };
    _.doNonQueryPost = function (viewModel, schema, table, query, data, onSuccess, onFail) {
        var userToken = "ANON";
        if (_.auth) userToken = _.auth.UserToken;
        var url = _.ServiceBaseUrl + "/" + schema + "/" + table + "/" + userToken + "/" + query;
        var dataStr = _.JSON.stringify(data);
        _.LastAction = 'POST ' + url;
        _.LastDataSent = dataStr;

        $.ajax({
            type: "POST",
            url: url,
            data: dataStr,
            context: viewModel,
            cache: false,
            contentType: "application/json; charset=utf-8",
            success: onSuccess,
            error: onFail
        });
    };

    _.Strings = {
        Auth_STATUS_STEP1:'Authenticating...',
        Auth_STATUS_STEP2:'Authenticating......',
        Auth_STATUS_SUCCESS:'Successfully logged in!',
        Auth_STATUS_FAIL:'Failed to login.',
    };
    


    return _;
})(jQuery, hex_md5, window, JSON);