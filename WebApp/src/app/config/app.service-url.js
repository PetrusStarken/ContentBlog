(function (angular) {
  'use strict';

  var webApiUrl = 'http://localhost:9000/';
  var config = {
    auth: webApiUrl + 'Api/Authenticate',
    lead: webApiUrl + 'Api/Lead/',
    article: webApiUrl + 'Api/Article/',
    articleCategory: webApiUrl + 'Api/ArticleCategory/'
  };
  angular.module('app').constant('serviceUrl', config);
})(angular);
