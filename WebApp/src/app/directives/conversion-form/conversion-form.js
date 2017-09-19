(function (angular) {
  'use strict';

  angular.module('app').component('cdConversionForm', {
    templateUrl: 'app/directives/conversion-form/conversion-form.html',
    controller: ConversionFormController,
    bindings: { }
  });

  ConversionFormController.$inject = ['$scope', 'leadService'];

  /* @NgInject */
  function ConversionFormController($scope, leadService) {
    var vm = this;
    vm.lead = {};
    vm.showLabel = ShowLabel;
    vm.cadastrar = Cadastrar;

    // $scope.$watch('lead.Nome', function (nome) {
    //   if (!nome) {
    //     return;
    //   }

    //   var parts = nome.split(' ');
    //   if (parts > 1) {
    //     return;
    //   }

    //   vm.conversionForm.Nome.$error.nomeCompleto = (parts < 2);
    // });

    function Cadastrar(lead) {
      vm.loading = true;
      leadService.add(lead).then(function () {
        vm.leadConverted = true;
        vm.loading = false;
      });
    }

    function ShowLabel(formClass) {
      return formClass !== 'form-inline';
    }
  }
})(angular);
