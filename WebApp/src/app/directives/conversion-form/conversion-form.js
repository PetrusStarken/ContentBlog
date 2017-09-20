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

    function Cadastrar(lead) {
      vm.loading = true;
      leadService.add(lead).then(function () {
        vm.leadConverted = true;
        vm.loading = false;
        emptyForm();
      });

      function emptyForm() {
        delete vm.lead;
        $scope.conversionForm.leadNome.$setPristine();
        $scope.conversionForm.leadEmail.$setPristine();
      }
    }

    function ShowLabel(formClass) {
      return formClass !== 'form-inline';
    }
  }
})(angular);
