(function (angular) {
  'use strict';

  angular.module('app').component('cdArticlePreview', {
    templateUrl: 'app/directives/article-preview/article-preview.html',
    bindings: {
      article: '='
    }
  });
})(angular);
