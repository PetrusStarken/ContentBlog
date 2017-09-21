(function (angular) {
  'use strict';

  angular.module('app').directive('cdDynamicHtml', DynamicHtmlDirective);

  DynamicHtmlDirective.$inject = ['$compile'];

  function DynamicHtmlDirective($compile) {
    return {
      restrict: 'A',
      replace: true,
      link: function (scope, ele, attrs) {
        scope.$watch(attrs.cdDynamicHtml, function (html) {
          ele.html(html);
          $compile(ele.contents())(scope);
        });
      }
    };
  }
})(angular);
