(function (angular) {
  'use strict';

  angular.module('app').component('aboutUs', {
    templateUrl: 'app/components/about-us/about-us.html',
    controller: AboutUsController
  });

  AboutUsController.$inject = ['$uibModal'];

  function AboutUsController($uibModal) {
    var vm = this;
    vm.openConversionModal = OpenConversionModal;

    function OpenConversionModal() {
      $uibModal.open({
        templateUrl: 'conversion-form-modal.html',
        size: 'md'
      });
    }
  }
})(angular);
