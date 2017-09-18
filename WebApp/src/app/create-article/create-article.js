(function (angular) {
  'use strict';

  angular.module('app').component('createArticle', {
    templateUrl: 'app/create-details/create-article.html',
    controller: CreateArticleController
  });

  CreateArticleController.$inject = ['articleService'];

  /* @ngInject */
  function CreateArticleController(articleService) {

  }
})(angular);
