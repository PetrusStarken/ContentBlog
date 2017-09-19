(function (angular) {
  'use strict';

  angular.module('app').filter('trustHtml', TrustHtml);

  TrustHtml.$inject = ['$sce'];

  function TrustHtml($sce) {
    return function (html) {
      return $sce.trustAsHtml(html);
    };
  }
})(angular);
