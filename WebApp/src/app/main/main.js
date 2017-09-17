(function (angular) {
  'use strict';

  angular.module('app').component('main', {
    templateUrl: 'app/main/main.html',
    controller: MainController
  });

  MainController.$inject = [];

  /* @ngInject */
  function MainController() {
    var vm = this;
    vm.lead = {Nome: 'Pedro'};
  }
})(angular);
