(function (angular) {
  'use strict';

  angular.module('app').component('aboutUs', {
    templateUrl: 'app/components/about-us/about-us.html',
    controller: AboutUsController
  });

  AboutUsController.$inject = [];

  function AboutUsController() {

  }
})(angular);
