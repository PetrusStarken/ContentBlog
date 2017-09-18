(function (angular) {
  'use strict';

  angular.module('app').filter('trustHtml', TrusHtml);

  TrusHtml.$inject = ['$sce'];

  function TrusHtml($sce) {
    return function (html) {
      return $sce.trustAsHtml(html);
    };
  }
})(angular);
