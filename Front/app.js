angular.module('tarefas', ["ngRoute"]);

angular.module('tarefas').controller('GetTarefas', async function($scope, $http, $location){
    $http.get('https://localhost:7230/api/Servico');
    var consultaApi = await fetch("https://localhost:7230/api/Servico");
    var consultaConvertida = await consultaApi.json();
    $scope.retornoTarefas = consultaConvertida;
    console.log(consultaConvertida);

    $scope.isActive = function(route) {
        return route === $location.path();
    };

    //funcao responsavel por formatar a data do evento
    $scope.formatarDataBr = function(data) {
        console.log(data);
        // var dataFormatada = new Date(data).toLocaleDateString('pt-BR');
        var dataObj = new Date(data);
        var options = {
            day: '2-digit',
            month: '2-digit',
            year: 'numeric',
            hour: '2-digit',
            minute: '2-digit'
        };
        var dataFormatada = new Intl.DateTimeFormat('pt-BR', options).format(dataObj);
        dataFormatada = dataFormatada.replace(',', '');
        return dataFormatada;
    };

    $scope.formataDescricao = function(data) {
        let palavraFormatada = data.slice(0, 30);
        return palavraFormatada + '....';
    }

    $scope.formataTarefaConcluida = function(data) {
        if(data == true){
            return "Sim";
        }
        return 'Nao';
    }

    $scope.setItemId = function(id) {
        console.log(id)
        $scope.itemId = id;
    };

    $scope.totalMinutos = function(minutos) {
        

        // if (!$scope.minutosTrabalhados) {
        //     $scope.minutosTrabalhados = 0;
        // }
        // $scope.minutosTrabalhados += minutos;
        // console.log($scope.minutosTrabalhados);
    };

    $scope.deletarServico = async function(id) {
        console.log(id)
        $scope.itemId = id;

        var retorno = await $http.delete('https://localhost:7230/api/Servico/'+id);
        // var consultaApi = await fetch("https://localhost:7230/api/Servico/"+id);
        var consultaConvertida = await retorno.data;

        if(consultaConvertida.message == 'Deletado'){
            alert("O servico #" + id +" foi deletado com Sucesso!");
        }

        // alert("deletado" + retorno.message);
        console.log(consultaConvertida);
        $scope.removerItem(id);

        document.querySelector("#fecharModal").click();
    };

    $scope.removerItem = function(id) {
        // Procura o índice do item com o ID igual
        var index = $scope.retornoTarefas.findIndex(function(item) {
          return item.id === id;
        });
        
        // Remove o item do array pelo índice encontrado
        if (index !== -1) {
          $scope.retornoTarefas.splice(index, 1);
          $scope.$apply();
        }
    };

});