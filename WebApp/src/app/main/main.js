(function (angular) {
  'use strict';

  angular.module('app').component('main', {
    templateUrl: 'app/main/main.html',
    controller: MainController
  });

  MainController.$inject = [];

  /* @ngInject */
  function MainController() {
    var vm = this;
    vm.posts = [
      {
        Title: 'Título',
        Author: 'João Batista',
        Date: new Date(),
        Resume: 'Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja d',
        ImageSource: 'http://www.joesheftelgallery.com/joe-sheftel-at-nada-new-york/attachment/219/'
      },
      {
        Title: 'Título',
        Author: 'João Batista',
        Date: new Date(),
        Resume: 'Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja d',
        ImageSource: 'http://www.joesheftelgallery.com/joe-sheftel-at-nada-new-york/attachment/219/'
      },
      {
        Title: 'Título',
        Author: 'João Batista',
        Date: new Date(),
        Resume: 'Lorem Ipsum é simplesmente uma simulação de texto da indústria tipográfica e de impressos, e vem sendo utilizado desde o século XVI, quando um impressor desconhecido pegou uma bandeja d',
        ImageSource: 'http://www.joesheftelgallery.com/joe-sheftel-at-nada-new-york/attachment/219/'
      }
    ];
  }
})(angular);
