/// <reference path="dal.js"/>
//Requires dal.js
if (window.dal === undefined) alert('Developer error.  dal.ViewModelBaseClass.js requires dal.js');

/*

ViewModelBase
- CurrentItem:{}
- Items:[]
- CurrentIndex:int
- OnDataBind :fn(vm) {} - Called when interface should data bind
- setCurrentIndex(index) - sets current index, and updates bindings
- NextItem() - sets current item to next item from items array, databinds
- PrevItem() - sets current item to prev item from items array, databinds
- OnSuccess :fn(vm) {} - Called after successful call. (the default success handler)
- OnFail :fn(xhr, ajaxOptions, thrownError)  {call window.HandleError} - Called after an error (the default error handler)
- LoadItems(methodCall, onSuccess, onFail) - Calls the method, loads items into items array
- LoadItem(methodCall, onSuccess, onFail) - Calls the method, sets current item, sets items to new array of one item
- Get(id) - Gets one item based on typical rest format Get item
- SelectAll() - Selects all items based on typical rest format get collection

usage:
function SchemaTableName() { 
    var _ = {};
    dal.ViewModelBaseClass(dal, _,'schema','table'); 
//Your code here
}

*/

window.dal.ViewModelBaseClass = function (dal, _, schemaName, tableName) {
    _.CurrentItem = {};
    _.Items = [];
    _.ListItems = [];
    _.CurrentIndex = -1;
    _.TableName = tableName;
    _.SchemaName = schemaName;
    _.IsLoading = false;
    
    _.OnDataBindItem = function (viewModel) { };
    _.OnDataBindItems = function (viewModel) { };
    _.OnDataBindList = function (viewModel) { };
    _.OnSuccess = function (viewModel) { };
    _.OnFail = dal.ExceptionHandler;
    _.OnGetSuccess = _.OnSuccess;
    _.OnGetFail = _.OnFail;
    _.OnSelectAllSuccess = _.OnSuccess;
    _.OnSelectAllFail = _.OnFail;

    _.MoveIndex = function (index) {
        if (_.Items != null && _.Items.length > 0) {
            _.CurrentIndex = index;
            if (_.CurrentIndex >= _.Items.length) _.CurrentIndex = _.Items.length - 1;
            if (_.CurrentIndex <= 0) _.CurrentIndex = 0;
            _.CurrentItem = _.Items[_.CurrentIndex];
        } else {
            _.CurrentItem = null;
            _.CurrentIndex = -1;
        }
        _.OnDataBindItem(_);
    };
    _.NextItem = function () {
        if (_.Items != null && _.Items.length > 0) {
            _.CurrentIndex++;
            if (_.CurrentIndex >= _.Items.length) _.CurrentIndex = _.Items.length - 1;
            _.CurrentItem = _.Items[_.CurrentIndex];
        } else {
            _.CurrentItem = null;
            _.CurrentIndex = -1;
        }
        _.OnDataBindItem(_);
    };
    _.PreviousItem = function () {
        if (_.Items != null && _.Items.length > 0) {
            _.CurrentIndex--;
            if (_.CurrentIndex <= 0) _.CurrentIndex = 0;
            _.CurrentItem = _.Items[CurrentIndex];
        } else {
            _.CurrentItem = null;
            _.CurrentIndex = -1;
        }
        _.OnDataBindItem(_);
    };


    _.LoadItems = function (methodCall, px, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doPost(_, _.SchemaName, _.TableName, methodCall, px,
            function(result) {
                _.Items = result;
                _.CurrentItem = {};
                _.CurrentIndex = -1;
                if (_.Items != null && _.Items.length > 0) {
                    _.CurrentItem = _.Items[0];
                    _.CurrentIndex = 0;
                }

                _.OnDataBindItems(_);
                _.OnDataBindItem(_);
                _.IsLoading = false;
                onSuccess(_);
            }, function (xhr, ajaxOptions, thrownError) {
                _.IsLoading = false;
                onFail(xhr, ajaxOptions, thrownError);
            });
    };

    _.GetItems = function (methodCall, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doGet(_, _.SchemaName, _.TableName, methodCall,
            function(result) {
                _.Items = result;
                _.CurrentItem = {};
                _.CurrentIndex = -1;
                if (_.Items != null && _.Items.length > 0) {
                    _.CurrentItem = _.Items[0];
                    _.CurrentIndex = 0;
                }

                _.OnDataBindItems(_);
                _.OnDataBindItem(_);
                _.IsLoading = false;
                onSuccess(_);
            }, function (xhr, ajaxOptions, thrownError) {
                _.IsLoading = false;
                onFail(xhr, ajaxOptions, thrownError);
            });
    };
    _.LoadList = function (methodCall, px, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doPost(_, _.SchemaName, _.TableName, methodCall, px,
            function(result) {
                _.ListItems = result;
                _.OnDataBindList(_);
                _.IsLoading = false;
                onSuccess(_);
            }, function (xhr, ajaxOptions, thrownError) {
                _.IsLoading = false;
                onFail(xhr, ajaxOptions, thrownError);
            });
    };
    _.LoadItem = function (methodCall, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doGet(_, _.SchemaName, _.TableName, methodCall,
			function (result) {
			    if (result != null) {
			        _.Items = [result];
			        _.CurrentItem = result;
			        _.CurrentIndex = 0;
			    } else {
			        _.Items = [];
			        _.CurrentItem = {};
			        _.CurrentIndex = -1;
			    }

			    _.OnDataBindItem(_);
			    _.IsLoading = false;
			    onSuccess(_);
			}, function (xhr, ajaxOptions, thrownError) {
			    _.IsLoading = false;
			    onFail(xhr, ajaxOptions, thrownError);
			});
    };

    _.PostItem = function (methodCall, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doPost(_, _.SchemaName, _.TableName, methodCall, CurrentItem,
            function(result) {
                if (_.Items != null && _.CurrentIndex >= 0) {
                    if (_.Items[_.CurrentIndex] == _.CurrentItem) {
                        _.Items[_.CurrentIndex] = result;
                        _.OnDataBindItems(_);
                    }
                }
                _.CurrentItem = result;
                _.OnDataBindItem(_);
                _.IsLoading = false;
                onSuccess(_);
            }, function (xhr, ajaxOptions, thrownError) {
                _.IsLoading = false;
                onFail(xhr, ajaxOptions, thrownError);
            });
    };

    _.NonQuery = function (methodCall, px, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doNonQueryPost(_, _.SchemaName, _.TableName, methodCall, px,
			function () {
			    _.IsLoading = false;
			    onSuccess(_);
			}, function (xhr, ajaxOptions, thrownError) {
			    _.IsLoading = false;
			    onFail(xhr, ajaxOptions, thrownError);
			});
    };

    _.GetBool = function (methodCall, onSuccess, onFail) {
        _.IsLoading = true;
        dal.doGet(_, _.SchemaName, _.TableName, methodCall,
            function (result) {
                _.IsLoading = false;
                onSuccess(_, result);
            }, function (xhr, ajaxOptions, thrownError) {
                _.IsLoading = false;
                onFail(xhr, ajaxOptions, thrownError);
            });
    };

    _.Get = function (id) { _.LoadItem(id.toString(), _.OnGetSuccess, _.OnGetFail); };
    _.SelectAll = function () { _.GetItems("", _.OnSelectAllSuccess, _.OnSelectAllFail); };
};