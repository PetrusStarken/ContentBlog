(function (angular) {
  'use strict';

  angular.module('app').factory('leadService', LeadService);

  LeadService.$inject = ['$http', 'serviceUrl'];

  function LeadService($http, serviceUrl) {
    var service = {
      add: Add
    };

    return service;

    function Add(lead) {
      return $http.post(serviceUrl.lead, lead);
    }
  }
})(angular);
