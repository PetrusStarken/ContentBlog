(function (angular) {
  'use strict';

  angular.module('app').component('articleDetails', {
    templateUrl: 'app/article-details/article-details.html',
    controller: ArticleDetailsController
  });

  ArticleDetailsController.$inject = ['articleService'];

  /* @ngInject */
  function ArticleDetailsController(articleService) {

  }
})(angular);
