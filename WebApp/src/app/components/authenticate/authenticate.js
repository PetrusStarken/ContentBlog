(function (angular) {
  'use strict';

  angular.module('app').component('authenticate', {
    templateUrl: 'app/components/authenticate/authenticate.html',
    controller: AuthenticateController
  });

  AuthenticateController.$inject = ['authService'];

  /* @ngInject */
  function AuthenticateController(authService) {
    var vm = this;
    vm.user = { };
    vm.login = Login;

    function Login(user) {
      authService.login(user).then(function () {
      });
    }
  }
})(angular);
