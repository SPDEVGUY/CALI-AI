angular.module('CALI', ['ngRoute']).
    factory('$jQuery', function ($window) { return $window.jQuery; }).
    config(function ($routeProvider) {
        $routeProvider.
            when('/auth', { templateUrl: '/Scripts/Views/Gen/App.Auth.Welcome.html' }).
            otherwise({ templateUrl: '/scripts/views/Gen/App.Anon.Welcome.html' });
    })
    .filter('jsonDate', function () {
        return function (input) {
            // Exit if the value isn't defined
            if (angular.isUndefined(input) || input == null) return null;
            
            return new Date(parseInt(input.substr(6)));
        };
    })
    .filter('jsonDateUtc', function () {
        return function (input) {
            // Exit if the value isn't defined
            if (angular.isUndefined(input) || input == null) return null;
            debugger;
            var utcShift = new Date();
            utcShift = utcShift.getTimezoneOffset() * 60 * 1000;
            return new Date(parseInt(input.substr(6)) - utcShift);
        };
    }).directive("ngMatches", function () {
        //Add directive for ng-matches="otherModelName"
        //Example: 
        //   <input type="password" ng-matches="ConfirmPassword" ng-model="Password"/>
        //   <input type="password" ng-matches="Password" ng-model="ConfirmPassword"/>
        return function (scope, elem, attrs, ctrl) {
            var otherInput = elem.inheritedData("$formController")[attrs.ngMatches];

            if (otherInput) {
                ctrl.$parsers.push(function (value) {
                    if (value === otherInput.$viewValue) {
                        ctrl.$setValidity("matches", true);
                        return value;
                    }
                    ctrl.$setValidity("matches", false);
                });

                otherInput.$parsers.push(function (value) {
                    ctrl.$setValidity("matches", value === ctrl.$viewValue);
                    return value;
                });
            } else {
                var missingControlName = attrs.ngMatches;
                var form = elem.inheritedData("$formController");
                debugger; //Use the above variables to determine your missing reference. Remember: ng-matches=input.Name 
            }
        };
    });
;



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