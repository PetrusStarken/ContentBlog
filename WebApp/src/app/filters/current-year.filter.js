(function (angular) {
  'use strict';

  angular.module('app').filter('currentYear', CurrentYearFilter);

  CurrentYearFilter.$inject = ['$filter'];

  function CurrentYearFilter($filter) {
    return function () {
      return $filter('date')(new Date(), 'yyyy');
    };
  }
})(angular);
