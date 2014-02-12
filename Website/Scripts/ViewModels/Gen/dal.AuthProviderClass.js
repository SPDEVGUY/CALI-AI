/// <reference path="dal.js"/>
//Requires dal.js
if (window.dal === undefined) alert('Developer error.  dal.AuthProviderClass.js requires dal.js');

//Creates:
//  window.dal.auth

window.dal.AuthProviderClass = function ($, dal, $scope) {
    ///<summary>The AuthProviderClass provides the means to interact with the /Auth/ service.</summary>

    var _ = $scope || {};

    //Constants
    _.WINDOWS_Auth_CODE = '_';
    _.ANONYMOUS_Auth_CODE = 'ANON';
    _.Auth_FAILED_RESPONSE = 'NO Auth';
    _.Auth_COOKIE = 'ServiceAuthToken';
    _.QS_USERTOKEN_KEY = 'Token'; //eg. url.html?Token={guid}
    _.CREATE_FAIL_USERNAME_EXISTS = "FAIL_USERNAMEEXISTS";
    _.CREATE_FAIL_EMAIL_EXISTS = "FAIL_EMAILEXISTS";
    _.CREATE_FAIL_CANTEMAIL = "FAIL_CANTEMAIL";
    _.CREATE_FAIL_EXCEPTION = "FAIL_EXCEPTION";
    _.CREATE_SUCCESS = "SUCCESS";


    /////////////////////
    //Public vars
    /////////////////////
    _.UserName = '';
    _.Password = '';
    _.DisplayName = '';
    _.Email = '';
    _.UserToken = _.ANONYMOUS_Auth_CODE;
    _.SupportsWindowsAuth = false;

    /////////////////////
    //Private Fns
    /////////////////////

    function tryToResume() {
        ///<summary>If resuming still leaves it anonymous, tries windows.  Otherwise if there's a token to resume it tries that.</summary>

        _.FindTokenToResume();
        if (_.UserToken != _.ANONYMOUS_Auth_CODE) { //Anon: Try windows.
            verifyToken(_.UserToken, _.OnAuthSuccess,
                function () {
                    _.SetToken(_.ANONYMOUS_Auth_CODE); //Set invalid token to anon.
                    _.OnAuthCodeInvalid(); //Notify of failure.
                }
            );
        }
    }

    function tryExistingTokenOnly() {
        ///<summary>Attempts authentication validation if not using windows or anon.</summary>
        if (_.UserToken == _.WINDOWS_Auth_CODE) _.SetToken(_.ANONYMOUS_Auth_CODE);
        if (_.UserToken != _.ANONYMOUS_Auth_CODE) {
            verifyToken(_.UserToken, _.OnAuthSuccess, _.OnAuthCodeInvalid);
        } else _.OnAuthCodeInvalid();
    }

    function tryWindowsOnly() {
        ///<summary>Attempts authentication with windows auth.</summary>
        _.SetToken(_.WINDOWS_Auth_CODE);
        verifyToken(_.WINDOWS_Auth_CODE, _.OnAuthSuccess, _.OnAuthCodeInvalid);
    }
    
    function checkForWindowsAuth() {
        ///<summary>Tries the windows auth token to see if it can be used.</summary>
        verifyToken(_.WINDOWS_Auth_CODE, function() {
            _.SupportsWindowsAuth = true;
        }, function() {
            _.SupportsWindowsAuth = false;
        });
    }

    function verifyToken(code, success, fail) {
        ///<summary>Attempts to check authentication with the provided code.</summary>
        dal.Get(_, "/Auth/Check(" + code + ")",
            function (result) {
                if (result == true) { success(); } else { _.SetToken(_.ANONYMOUS_Auth_CODE); fail(); }
            }
        , _.OnError);
    }

    function activate() {
        ///<summary>Activates the current user token's account.</summary>
        dal.Get(_, "/Auth/Activate(" + _.UserToken + ")",
            function (result) {
                if (result == true) { _.OnActivateSuccess(); } else { _.OnActivateError(); }
            }
        , _.OnError);
    }

    function reset() {
        ///<summary>Requests a password reset using the current username.</summary>
        dal.Get(_, "/Auth/Reset(" + encodeURIComponent(_.UserName) + ")",
            function (result) {
                if (result == true) { _.OnResetSuccess(); } else { _.OnResetError(); }
            }
        , _.OnError);
    }

    function change() {
        ///<summary>Changes the authenticated user's password to the one specified.</summary>
        dal.Get(_, "/Auth/Change(" + _.UserToken + ',' + dal.Hash(_.Password) + ")",
            function (result) {
                if (result == true) { _.OnChangeSuccess(); } else { _.OnChangeError(); }
            }
        , _.OnError);
    }

    function create() {
        ///<summary>Creates the user using the provided options.</summary>
        dal.Get(_, "/Auth/Create("
            + encodeURIComponent(_.DisplayName) + ","
            + encodeURIComponent(_.Email) + ","
            + encodeURIComponent(_.UserName) + ","
            + dal.Hash(_.Password)
            + ")",
            function (result) {
                if (result == _.CREATE_SUCCESS) { _.OnCreateSuccess(); } else { _.OnCreateError(result); }
            }
        , _.OnError);
    }

    function authenticate() {
        ///<summary>Authenticates with the current username and password.</summary>
        var hashedPassword = dal.Hash(_.Password);
        _.OnStatusUpdate(dal.Strings.Auth_STATUS_STEP1);
        dal.Get(_,
            "/Auth/" + encodeURIComponent(_.UserName),
            function (authToken) {
                _.OnStatusUpdate(dal.Strings.Auth_STATUS_STEP2);
                var authTokenPwHash = dal.Hash(authToken + '' + hashedPassword);
                dal.Get(_,
                    "/Auth/" + encodeURIComponent(_.UserName) + "/" + encodeURIComponent(authTokenPwHash),
                    function (realAuthToken) {
                        if (realAuthToken == _.Auth_FAILED_RESPONSE) {
                            _.OnStatusUpdate(dal.Strings.Auth_STATUS_FAIL);
                            _.OnAuthFail();
                        } else {
                            _.OnStatusUpdate(dal.Strings.Auth_STATUS_SUCCESS);
                            _.SetToken(realAuthToken);
                            _.OnAuthSuccess();
                        }
                    }, _.OnError
                );
            },
            _.OnError);
    }


    /////////////////////
    //Public fns
    /////////////////////

    _.SetToken = function (value) {
        ///<summary>Sets the user token to value, stores in cookie.</summary>
        _.UserToken = value;
        $.cookie(this.Auth_COOKIE, value);
    };

    _.FindTokenToResume = function () {
        ///<summary>
        ///Resume a session from cookie, or from query string.
        ///This does not call validateToken.
        ///</summary>
        _.UserToken = $.cookie(_.Auth_COOKIE);
        if (!_.UserToken) _.UserToken = _.ANONYMOUS_Auth_CODE;
        if (_.UserToken == _.ANONYMOUS_Auth_CODE) {
            var queryStringToken = dal.QueryString(this.QS_USERTOKEN_KEY);
            if (queryStringToken != null) {
                _.UserToken = queryStringToken;
                _.Activate();
            }
        }
    };

    _.Authenticate = authenticate;
    _.ResumeSession = tryToResume;
    _.UseWindowsAuth = tryWindowsOnly;
    _.UseNonWindowsAuth = tryExistingTokenOnly;
    _.LogOut = function () {
        ///<summary>Sets the user token to anonymous, raises auth code invalid event.</summary>
        _.SetToken(_.ANONYMOUS_Auth_CODE);
        _.OnAuthCodeInvalid();
    };
    _.VerifyToken = function (onSuccess, onFail) {
        ///<summary>Verifies the current auth token, raises AuthSuccess or AuthCodeInvalid</summary>
        verifyToken(_.UserToken, onSuccess || _.OnAuthSuccess, onFail || _.OnAuthCodeInvalid);
    };
    _.Create = create;
    _.Activate = activate;
    _.Reset = reset;
    _.ChangePassword = change;
    _.CheckForWindowsAuth = checkForWindowsAuth;



    /////////////////////
    //Event fns
    /////////////////////
    _.OnAuthCodeInvalid = function () { alert('Authentication code is invalid.'); };
    _.OnAuthSuccess = function () { alert('Authentication code is valid / success.'); };
    _.OnAuthFail = function () { alert('Authentication failure.'); };
    _.OnStatusUpdate = function (text) { alert('Status Update - ' + text + '.'); };
    _.OnError = dal.ExceptionHandler;
    _.OnCreateError = function (reason) { alert('Create Account Error [' + reason + ']'); };
    _.OnCreateSuccess = function () { alert('Create Account Success'); _.Authenticate(); };
    _.OnActivateError = function () { alert('Activate Account Error'); };
    _.OnActivateSuccess = function () { alert('Activate Account Success'); _.ResumeSession(); };
    _.OnResetError = function () { alert('Reset Account Error'); };
    _.OnResetSuccess = function () { alert('Reset Account Success'); };
    _.OnChangeError = function () { alert('Change Password Error'); };
    _.OnChangeSuccess = function () { alert('Change Password Success'); };


    dal.auth = _;
    return _;
};