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
      .state('home', {
        url: '/',
        component: 'home'
      })
      .state('about-us', {
        url: '/sobre',
        component: 'aboutUs'
      })
      .state('blog', {
        url: '/blog',
        component: 'blog'
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
