(function (angular) {
  'use strict';

  angular.module('app').factory('articleService', ArticleService);

  ArticleService.$inject = ['$http', 'serviceUrl'];

  function ArticleService($http, serviceUrl) {
    var service = {
      add: Add,
      edit: Edit,
      get: Get,
      getByTitle: GetByTitle,
      getAll: GetAll
    };

    return service;

    function Add(article) {
      return $http.post(serviceUrl.article, article);
    }

    function Edit(id, article) {
      return $http.put(serviceUrl.article + '/' + id, article);
    }

    function Get(id) {
      var params = {id: id};
      return $http.get(serviceUrl.article, {params: params});
    }

    function GetByTitle(urlTitle) {
      var params = {urlTitle: urlTitle};
      return $http.get(serviceUrl.article, {params: params});
    }

    function GetAll(filter) {
      if (!filter) {
        return $http.get(serviceUrl.article);
      }
      return $http.get(serviceUrl.article + '?' + filter);
    }
  }
})(angular);
