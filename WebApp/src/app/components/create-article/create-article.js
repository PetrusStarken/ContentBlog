(function (angular) {
  'use strict';

  angular.module('app').component('createArticle', {
    templateUrl: 'app/components/create-details/create-article.html',
    controller: CreateArticleController
  });

  CreateArticleController.$inject = [];

  /* @ngInject */
  function CreateArticleController() {

  }
})(angular);
