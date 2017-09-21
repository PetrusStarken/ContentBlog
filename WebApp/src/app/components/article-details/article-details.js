(function (angular) {
  'use strict';

  angular.module('app').component('articleDetails', {
    templateUrl: 'app/components/article-details/article-details.html',
    controller: ArticleDetailsController
  });

  ArticleDetailsController.$inject = ['articleService', '$stateParams', 'conversionModalService'];

  /* @ngInject */
  function ArticleDetailsController(articleService, $stateParams, conversionModalService) {
    var vm = this;
    var urlTitle = $stateParams.url;

    vm.openConversionModal = conversionModalService.open;

    articleService.getByTitle(urlTitle).then(function (res) {
      vm.article = res.data;
    });
  }
})(angular);
