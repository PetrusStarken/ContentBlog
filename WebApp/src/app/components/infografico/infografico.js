(function (angular) {
  'use strict';

  angular.module('app').component('infografico', {
    templateUrl: 'app/components/infografico/infografico.html',
    controller: InfograficoController
  });

  InfograficoController.$inject = ['articleService'];

  function InfograficoController(articleService) {
    var vm = this;

    function getBlogPosts() {
      var filter = '$orderby=Date&$top=3';
      articleService.getAll(filter).then(function (res) {
        vm.articles = res.data;
      });
    }

    getBlogPosts();
  }
})(angular);

