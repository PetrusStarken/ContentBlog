(function (angular) {
  'use strict';

  angular.module('app').component('home', {
    templateUrl: 'app/components/home/home.html',
    controller: HomeController
  });

  HomeController.$inject = [];

  /* @ngInject */
  function HomeController() {

  }
})(angular);
