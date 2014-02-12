function CALIClientUsersController($window, $scope, $location, $jQuery) {
    //Inherit ViewModel
    $scope.vm = new CALIClientUsersViewModel($jQuery, $window.dal);

    $scope.ErrorMessage = null;
    $scope.ShowList = true;
    $scope.ShowMatrix = false;
    $scope.ShowDetail = false;
    $scope.ShowInput = false;
    $scope.CanInsert = $scope.vm.Insert || $scope.vm.InsertByUser;
    $scope.CanEdit = $scope.vm.Update || $scope.vm.UpdateByUser;
    $scope.CanDelete = $scope.vm.Delete || $scope.vm.DeleteByUser;

    //Events
    $scope.$done = function () { if (!$scope.$$phase) $scope.$apply(); };
    $scope.vm.OnSelectAllFail = function() {
        $scope.ErrorMessage = "Failed to select all.";
        $scope.$done();
    };
    $scope.vm.OnSelectAllSuccess = $scope.$done;
    $scope.vm.OnGetFail = function() {
        $scope.ErrorMessage = "Failed to select all.";
        $scope.$done();
    };
    $scope.vm.OnGetSuccess = function () {
        $scope.ShowDetailView();
        $scope.$done();
    };

    //Fns
    $scope.ShowMatrixView = function () {
        $scope.ShowMatrix = true;
        $scope.ShowList = false;
        $scope.ShowDetail = false;
        $scope.ShowInput = false;
    };
    $scope.ShowInputView = function () {
        $scope.ShowMatrix = false;
        $scope.ShowList = false;
        $scope.ShowDetail = false;
        $scope.ShowInput = true;
    };
    $scope.ShowDetailView = function () {
        $scope.ShowMatrix = false;
        $scope.ShowList = false;
        $scope.ShowDetail = true;
        $scope.ShowInput = false;
    };
    $scope.ShowListView = function () {
        $scope.ShowMatrix = false;
        $scope.ShowList = true;
        $scope.ShowInput = false;
        $scope.ShowDetail = false;
    };
    $scope.DeleteCurrentItem = function () {
        if ($window.confirm('Are you sure you want to delete this item?')) {
            $scope.vm.CurrentItem._IsDeleted = true;
            ($scope.vm.DeleteByUser || $scope.vm.Delete)();
        }
    };
    $scope.ShowAddView = function () {
        $scope.vm.CurrentItem = new $scope.vm.NewItem();
        $scope.ShowInputView();
    };
    $scope.SaveChanges = function () {
        if ($scope.vm.CurrentItem._IsNewItem == true) {
            ($scope.vm.InsertByUser || $scope.vm.Insert)();
        } else {
            ($scope.vm.UpdateByUser || $scope.vm.Update)();
        }
    };
    $scope.CancelInput = function () {
        if ($scope.vm.CurrentItem._IsNewItem == true) {
            $scope.ShowListView();
        } else {
            $scope.ShowDetaiView();
        }
    };

    //Initialize
    $scope.vm.SelectAll();
}