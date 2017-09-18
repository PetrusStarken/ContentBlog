(function (angular) {
  'use strict';

  angular
    .module('app')
    .config(routesConfig);

  /** @ngInject */
  function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');
    $urlRouterProvider.otherwise('/');

    $stateProvider
      .state('app', {
        url: '/',
        component: 'home'
      })
      .state('article', {
        url: '/blog/:url',
        component: 'articleDetails'
      })
      .state('auth', {
        url: '/auth',
        component: 'authenticate'
      });
  }
})(angular);
