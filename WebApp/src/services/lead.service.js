(function (angular) {
  'use strict';

  angular.module('app').factory('leadService', LeadService);

  LeadService.$inject = ['$http'];

  function LeadService($http) {
    var service = {
      cadastrar: Cadastrar
    };

    return service;

    function Cadastrar(lead) {
      return $http.post('http://localhost:61077/api/Lead', lead);
    }
  }
})(angular);
