(function (angular) {
  'use strict';

  angular.module('app').config(routesConfig);

  /** @ngInject */
  function routesConfig($stateProvider, $urlRouterProvider, $locationProvider) {
    $locationProvider.html5Mode(true).hashPrefix('!');
    $urlRouterProvider.otherwise('/');

    $stateProvider
      .state('home', {
        url: '/',
        component: 'blog'
      })
      .state('about-us', {
        url: '/quem-somos',
        component: 'aboutUs'
      })
      .state('blog', {
        url: '/blog',
        component: 'blog'
      })
      .state('infografico', {
        url: '/infografico',
        component: 'infografico'
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
