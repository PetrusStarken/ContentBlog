(function (angular) {
  'use strict';

  angular.module('app').factory('editHttpInterceptors', EditHttpInterceptors);
  angular.module('app').config(ConfigHttpInterceptors);

  EditHttpInterceptors.$inject = ['$q', '$rootScope'];
  ConfigHttpInterceptors.$inject = ['$httpProvider'];

  function ConfigHttpInterceptors($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.interceptors.push('editHttpInterceptors');
    delete $httpProvider.defaults.headers.post['Content-type'];
  }

  function EditHttpInterceptors($q, $rootScope) {
    return {
      request: function (config) {
        $rootScope.showLoader = true;
        return config || $q.when(config);
      },
      response: function (response) {
        $rootScope.showLoader = false;
        return response || $q.when(response);
      },
      responseError: function (response) {
        $rootScope.showLoader = false;
        return $q.reject(response);
      }
    };
  }
})(angular);
