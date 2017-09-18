(function (angular) {
  'use strict';

  angular.module('app').component('searchArticle', {
    templateUrl: 'app/search-article/seach-article.html',
    controller: SearchArticleController
  });

  SearchArticleController.$inject = ['articleService'];

  function SearchArticleController(articleService) {
    
  }
})(angular);
