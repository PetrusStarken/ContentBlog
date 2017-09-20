(function (angular) {
  'use strict';

  angular.module('app').component('blog', {
    templateUrl: 'app/components/blog/blog.html',
    controller: BlogController
  });

  BlogController.$inject = ['articleService'];

  function BlogController(articleService) {
    var vm = this;
    var filter = '$orderby=Date desc';
    articleService.getAll(filter).then(function (res) {
      vm.articles = res.data;
    });
  }
})(angular);
