//////////////////////////////////////////////////////////////////////
//Do not modify this file. Make a copy and reference it instead.	//
//////////////////////////////////////////////////////////////////////

/// <reference path="dal.js"/>
/// <reference path="ViewModelBase.js"/>

//Requires dal.js
if (window.dal === undefined) alert('Developer error.  Client.Users.viewmodel.js requires dal.js');
//Requires ViewModelBase.js
if (window.dal.ViewModelBaseClass === undefined) alert('Developer error.  Client.Users.ViewModelClass.js requires dal.ViewModelBaseClass.js');

//Makes:
//  window.dal.CALI_Client_Users_ViewModelClass;

function CALIClientUsersViewModel($, dal, $scope) {
    var _ = $scope || {};
    dal.ViewModelBaseClass(dal, _, "Client", "Users");

    
    _.NewItem = function () {
        this._IsNewItem = true;
		this.UserId=null;
		this.DisplayName="";

    };
    
	_.OnSelectByUser_CurrentSuccess = _.OnSuccess;
	_.OnSelectByUser_CurrentFail = _.OnFail;
	_.SelectByUser_Current = function () {

        _.LoadItems("SelectByUser_Current()",
			{
			}
			, _.OnSelectByUser_CurrentSuccess, _.OnSelectByUser_CurrentFail);
    };
	_.OnSelectByUser_UpdateProfileSuccess = _.OnSuccess;
	_.OnSelectByUser_UpdateProfileFail = _.OnFail;
	_.SelectByUser_UpdateProfile = function (fldDisplayName, fldEmail) {
		if(fldDisplayName===undefined && !(_.CurrentItem.DisplayName===undefined)) fldDisplayName = _.CurrentItem.DisplayName;
		if(fldEmail===undefined && !(_.CurrentItem.Email===undefined)) fldEmail = _.CurrentItem.Email;

        _.LoadItems("SelectByUser_UpdateProfile()",
			{
				'DisplayName' : fldDisplayName,
				'Email' : fldEmail
			}
			, _.OnSelectByUser_UpdateProfileSuccess, _.OnSelectByUser_UpdateProfileFail);
    };
	_.OnExistsSuccess = function (viewModel, result) { };
	_.OnExistsFail = _.OnFail;
	_.Exists = function (fldUserId) {
		if(fldUserId===undefined && !(_.CurrentItem.UserId===undefined)) fldUserId = _.CurrentItem.UserId;

		var methodCall = dal.FormatString (
			"Exists({0})"
				,fldUserId
			); 

        _.GetBool(methodCall, _.OnExistsSuccess, _.OnExistsFail);
    };
	_.OnSearchSuccess = _.OnSuccess;
	_.OnSearchFail = _.OnFail;
	_.Search = function (fldDisplayName) {
		if(fldDisplayName===undefined && !(_.CurrentItem.DisplayName===undefined)) fldDisplayName = _.CurrentItem.DisplayName;

        _.LoadItems("Search()",
			{
				'DisplayName' : fldDisplayName
			}
			, _.OnSearchSuccess, _.OnSearchFail);
    };


    return _;
};