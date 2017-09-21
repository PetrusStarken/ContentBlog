(function (angular) {
  'use strict';

  angular.module('app').component('cdConversionForm', {
    templateUrl: 'app/directives/conversion-form/conversion-form.html',
    controller: ConversionFormController,
    bindings: {
      formTitle: '@',
      fileUrl: '@',
      formType: '@',
      conversionMessage: '@',
      buttomMessage: '@'
    }
  });

  ConversionFormController.$inject = ['$scope', '$window', 'leadService'];

  /* @NgInject */
  function ConversionFormController($scope, $window, leadService) {
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
        if (vm.formType === 'download') {
          $window.open(vm.fileUrl);
        }
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
