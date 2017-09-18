(function (angular) {
  'use strict';

  angular.module('app').component('cdInputValidation', {
    templateUrl: 'app/directives/input-validation/input-validation.html',
    bindings: {
      responsiveClass: '@',
      field: '=',
      model: '=',
      labelDescription: '@',
      fieldName: '@',
      placeholder: '@',
      required: '@',
      inputType: '@',
      onChange: '@',
      minLength: '@',
      maxLength: '@',
      validateName: '='
    }
  });
})(angular);
