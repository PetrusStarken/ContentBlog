(function (angular) {
  'use strict';

  angular.module('app').factory('conversionModalService', ConversionModalService);

  ConversionModalService.$inject = ['$uibModal'];

  function ConversionModalService($uibModal) {
    var service = {
      open: OpenConversionModal
    };

    return service;

    function OpenConversionModal() {
      $uibModal.open({
        template: '<cd-conversion-form></cd-conversion-form>',
        size: 'md'
      });
    }
  }
})(angular);
