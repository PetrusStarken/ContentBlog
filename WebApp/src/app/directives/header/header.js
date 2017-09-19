(function (angular) {
  'use strict';

  angular.module('app').component('cdHeader', {
    templateUrl: 'app/directives/header/header.html',
    bindings: {
      pageTitle: '@',
      pageSubTitle: '@'
    }
  });
})(angular);
