(function (angular) {
  'use strict';

  angular.module('app').component('articleDetails', {
    templateUrl: 'app/components/article-details/article-details.html',
    controller: ArticleDetailsController
  });

  ArticleDetailsController.$inject = ['articleService', '$stateParams'];

  /* @ngInject */
  function ArticleDetailsController(articleService, $stateParams) {
    var vm = this;
    var urlTitle = $stateParams.url;

    articleService.getByTitle(urlTitle).then(function (res) {
      vm.article = res.data;
    });
  }
})(angular);
