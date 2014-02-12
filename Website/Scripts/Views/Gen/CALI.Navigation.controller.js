function CALINavigationController($scope, $window) {

    //init
    $scope.Title = "CALI";

    $scope.Items = [
        { Text: 'Home', Url: '#/', Icon: 'home', Css:"active", AuthOnly:false },
        { Text: 'Help', Url: '#/help', Icon: 'info-sign', Css: "", AuthOnly: false },
        { Text: 'Auth Only', Url: '#/auth', Icon: 'star', Css: "", AuthOnly: true }
    ];

    $scope.IsAuthenticated = function () {
        if ($window.dal.auth === undefined) return false;
        return $window.dal.auth.IsAuthenticated;
    };
}