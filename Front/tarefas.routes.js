import './'

angular.module('tarefas').config(function($routeProvider) {
    $routeProvider
      .when('/', {
        // templateUrl: 'index.html'
        template : "<h1>Main</h1><p>Click on the links to change this content</p>"
      })
      .when('/tarefas', {
        templateUrl: 'components/tarefas/tarefasComponents.html'
        // template : "<h1>Banana1</h1><p>Bananas contain around 75% water.</p>"
      })
      .when('/sobre', {
        // templateUrl: 'templates/sobre.html'
        template : "<h1>Banana2</h1><p>Bananas contain around 75% water.</p>"
      })
      .when('/contato', {
        // templateUrl: 'templates/contato.html'
        template : "<h1>Tomato</h1><p>Tomatoes contain around 95% water.</p>"
      })
      .when('/adicionarTarefas', {
        // templateUrl: 'templates/contato.html'
        templateUrl : 'components/tarefas/adicionaTarefas/adicionaTarefas.html'
      })
      .when('/relatorios', {
        // template : "<h1>Banana2</h1><p>Bananas contain around 75% water.</p>"
        templateUrl : 'components/relatorios/relatorios.html'
      })
      .when('/login', {
        // template : "<h1>Banana2</h1><p>Bananas contain around 75% water.</p>"
        templateUrl : 'components/login/login.html'
      })
      .otherwise({
        redirectTo: '/'
      });
  });
  