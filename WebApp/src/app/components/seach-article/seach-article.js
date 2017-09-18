(function (angular) {
  'use strict';

  angular.module('app').component('searchArticle', {
    templateUrl: 'app/components/search-article/seach-article.html',
    controller: SearchArticleController
  });

  SearchArticleController.$inject = [];

  function SearchArticleController() {
  }
})(angular);
