(function (angular) {
  'use strict';

  angular.module('app').component('cdPostPreview', {
    templateUrl: 'app/post-preview/postPreview.js',
    controller: PostPreviewController,
    bindings: {
      post: '='
    }
  });

  PostPreviewController.$inject = [];

  function PostPreviewController() {

  }
})(angular);
