(function (angular) {
  'use strict';

  angular.module('app').component('cdConversionForm', {
    templateUrl: 'app/directives/conversion-form/conversion-form.html',
    controller: ConversionFormController,
    bindings: {
      formClass: '@',
      formTitle: '@',
      fileUrl: '@',
      formType: '@',
      conversionMessage: '@',
      buttomMessage: '@'
    }
  });

  ConversionFormController.$inject = ['$scope', 'leadService'];

  /* @NgInject */
  function ConversionFormController($scope, leadService) {
    var vm = this;
    vm.lead = {};
    vm.showLabel = ShowLabel;
    vm.cadastrar = Cadastrar;
    vm.$onInit = OnInit;

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

    function OnInit() {
      vm.fileName = getFileName(vm.fileUrl);
    }

    function getFileName(fileUrl) {
      if (!fileUrl) {
        return;
      }
      var arrPathFile = fileUrl.split('/');
      return arrPathFile[arrPathFile.length - 1];
    }
  }
})(angular);
