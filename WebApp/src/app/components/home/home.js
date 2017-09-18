(function (angular) {
  'use strict';

  angular.module('app').component('home', {
    templateUrl: 'app/components/home/home.html',
    controller: HomeController
  });

  HomeController.$inject = ['articleService'];

  /* @ngInject */
  function HomeController(articleService) {
    var vm = this;
    articleService.getAll().then(function (res) {
      vm.articles = res.data;
    });
  }
})(angular);
