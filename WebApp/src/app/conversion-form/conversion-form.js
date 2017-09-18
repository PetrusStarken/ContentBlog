(function (angular) {
  'use strict';

  angular.module('app').component('cdConversionForm', {
    templateUrl: 'app/conversion-form/conversion-form.html',
    controller: ConversionFormController,
    bindings: {
      formClass: '@'
    }
  });

  ConversionFormController.$inject = ['$scope', 'leadService'];

  /* @NgInject */
  function ConversionFormController($scope, leadService) {
    var vm = this;
    vm.lead = {};
    vm.showLabel = ShowLabel;
    vm.cadastrar = Cadastrar;

    function Cadastrar(lead) {
      leadService.add(lead).then(function (res) {
        
      });
    }

    function ShowLabel(formClass) {
      return formClass !== 'form-inline';
    }
  }
})(angular);
