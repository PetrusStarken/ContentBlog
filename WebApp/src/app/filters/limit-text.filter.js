(function (angular) {
  'use strcit';

  angular.module('app').filter('limitText', LimitTextFilter);

  function LimitTextFilter() {
    return function (text, limit) {
      var changedString = String(text).replace(/<[^>]+>/gm, '');

      return changedString.length > limit ? changedString.substr(0, limit - 1) + '...' : changedString;
    };
  }
})(angular);
