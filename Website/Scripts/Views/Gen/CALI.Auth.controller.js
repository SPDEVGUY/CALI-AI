function CALIAuthController($window, $scope, $location, $jQuery) {
    //Inherit
    $window.dal.AuthProviderClass($jQuery, $window.dal, $scope);

    //Init
    $scope.StatusLabelType = "info";
    $scope.IsAuthenticated = false;
    $scope.IsWindowsAuth = false;
    $scope.ShowUserExists = false;
    $scope.ShowEmailExists = false;
    $scope.DisplayName = "Signed-In";
    if (CALIClientUsersViewModel) {
        $scope.UsersVm = new CALIClientUsersViewModel($jQuery, $window.dal);
        $scope.UsersVm.OnSelectByUser_CurrentSuccess = function (vm) {
            $scope.DisplayName = vm.CurrentItem.DisplayName;
            if (!$scope.$$phase) $scope.$apply();
        };
    }

    //Event handlers
    $scope.OnChangeSuccess = function () { $scope.ClosePannels(); };
    $scope.OnChangeError = function () {
        $scope.Status = "Unable to change password due to a server error.";
        $scope.StatusLabelType = "warning";
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnResetSuccess = function () { $scope.ClosePannels(); };
    $scope.OnResetError = function () {
        $scope.Status = "Unable to recover password due to a server error.";
        $scope.StatusLabelType = "warning";
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnCreateSuccess = function () { $scope.ShowLogin(); $scope.Authenticate(); };
    $scope.OnCreateError = function (reason) {
        if (reason == $scope.CREATE_FAIL_USERNAME_EXISTS) $scope.ShowUserExists = true;
        if (reason == $scope.CREATE_FAIL_EMAIL_EXISTS) $scope.ShowEmailExists = true;
        if (reason == $scope.CREATE_FAIL_EXCEPTION) $scope.Status = "A server exception occurred.";
        if (reason == $scope.CREATE_FAIL_CANTEMAIL) $scope.Status = "The server failed to email you a validation code.";
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnActivateSuccess = function () {
        $scope.SetToken($scope.UserToken);
        $window.location.href = $window.location.href.split('?')[0] + "#/auth/activated";
    };
    $scope.OnActivateError = function () {
        $scope.ShowReset();
        $scope.Status = "Unable to activate your account, please enter your user name to try again.";
        $scope.StatusLabelType = "warning";
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnAuthFail = function () {
        $scope.IsAuthenticated = false;
        $scope.StatusLabelType = "warning";
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnAuthSuccess = function () {
        $scope.ClosePannels();
        var existingPathContainsAuth = $location.path().indexOf('/auth') >= 0;
        if (!existingPathContainsAuth) $location.path('/auth');
        $scope.IsAuthenticated = true;
        $scope.IsWindowsAuth = $scope.UserToken == $scope.WINDOWS_Auth_CODE;
        if ($scope.UsersVm) $scope.UsersVm.SelectByUser_Current();
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnAuthCodeInvalid = function () {
        $scope.IsAuthenticated = false;
        $location.path('/anon');
        if (!$scope.$$phase) $scope.$apply();
    };
    $scope.OnStatusUpdate = function (text) {
        $scope.Status = text;
        $scope.StatusLabelType = "info";
        if (!$scope.$$phase) $scope.$apply();
    };

    //Functions
    $scope.ClosePannels = function () {
        $jQuery(".auth-View").slideUp();
        $scope.Status = "";
        $scope.StatusLabelType = "info";
    };

    $scope.ShowViewProfile = function () {
        $scope.ClosePannels();
        $jQuery('#auth-ProfileView').slideDown();
    };

    $scope.ShowEditProvile = function () {
        $scope.ClosePannels();
        $jQuery('#auth-ProfileEdit').slideDown();
    };

    $scope.ShowReset = function () {
        $scope.ClosePannels();
        $jQuery('#auth-Reset').slideDown();
    };

    $scope.ShowCreate = function () {
        $scope.ClosePannels();
        $scope.DisplayName = "";
        $scope.UserName = "";
        $scope.Password = "";
        $scope.PasswordConfirm = "";
        $scope.Email = "";
        $scope.EmailConfirm = "";
        $jQuery('#auth-Create').slideDown();
        $scope.$done();
    };
    $scope.ShowChangePassword = function () {
        $scope.ClosePannels();
        $scope.Password = "";
        $scope.PasswordConfirm = "";
        $jQuery('#auth-ChangePassword').slideDown();
    };

    $scope.ShowLogin = function () {
        $scope.ClosePannels();
        $scope.CheckForWindowsAuth();
        $jQuery('#auth-Login').slideDown();
    };

    //Intercept a reset
    var params = $location.search();
    if (params.ResetId) {
        if (params.ResetId == $scope.WINDOWS_Auth_CODE) return;
        if (params.ResetId == $scope.ANONYMOUS_Auth_CODE) return;

        $scope.UserToken = params.ResetId;
        $scope.SetToken($scope.UserToken);
        $scope.VerifyToken(function () {
            $scope.OnAuthSuccess();
            $scope.ShowChangePassword();
        }, function() {
            $window.alert('Unfortunately the reset link you clicked is not the current one, if you tried to login after requesting a password reset you will need to request another.  Please check your email for a newer link.');
        });
    } else {
        //Resume auth session
        $scope.ResumeSession();
        if ($scope.UserToken == $scope.ANONYMOUS_Auth_CODE) $scope.CheckForWindowsAuth();
    }
}