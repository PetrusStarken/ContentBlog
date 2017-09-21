(function (angular) {
  'use strict';

  angular.module('app').component('aboutUs', {
    templateUrl: 'app/components/about-us/about-us.html',
    controller: AboutUsController
  });

  AboutUsController.$inject = ['conversionModalService'];

  function AboutUsController(conversionModalService) {
    var vm = this;
    vm.openConversionModal = conversionModalService.open;
  }
})(angular);
