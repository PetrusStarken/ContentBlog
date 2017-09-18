(function (angular) {
  'use strict';

  angular.module('app').factory('articleCategoryService', ArticleCategoryService);

  ArticleCategoryService.$inject = ['$http', 'serviceUrl'];

  function ArticleCategoryService($http, serviceUrl) {
    var service = {
      add: Add,
      edit: Edit,
      get: Get,
      getAll: GetAll
    };

    return service;

    function Add(category) {
      return $http.post(serviceUrl.articleCategory, category);
    }

    function Edit(id, category) {
      return $http.put(serviceUrl.articleCategory + '/' + id, category);
    }

    function Get(id) {
      var params = {id: id};
      return $http.get(serviceUrl.articleCategory, {params: params});
    }

    function GetAll() {
      return $http.get(serviceUrl.articleCategory);
    }
  }
})(angular);
