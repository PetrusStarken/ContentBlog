(function (angular) {
  'use strict';

  angular.module('app').factory('authService', AuthenticateService);

  AuthenticateService.$inject = ['$http', 'serviceUrl'];

  function AuthenticateService($http, serviceUrl) {
    var service = {
      login: Login
    };

    return service;

    function Login(user) {
      var credentials = btoa(user.username + ':' + user.password);
      $http.defaults.headers.common.Authorization = 'Basic ' + credentials;
      return $http.post(serviceUrl.auth);
    }
  }
})(angular);
