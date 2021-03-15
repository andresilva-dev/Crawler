# Data Lawyer - Crawler

## Projeto
Este projeto consiste na criação de um crawler para obter as informações de do processo 0809979-67.2015.8.05.0080 no Tribunal de Justiça da Bahia, bem como, consumir uma Api responsável por fornecer as funções necessárias para manutenção (inserir, deletar, atualizar ou obter) das informações do processo.

## Execução
Para executar o projeto é necessária compilar a solução, acessar as propriedades da solução e indicar que serão iniciados múltiplos projetos, selecionar a opção Start para os projetos CrawlerTribunal (Console) e WebApi (Api) e clicar em aplicar.

Após esta etapa, basta executar a aplicação. Neste momento, uma tela de console será apresentada e a API também será iniciada. Desta forma, a aplicação console executará as tarefas na ordem apresentada abaixo:

- Obter as informações do processo através do crawler;
- Aguardar alguns segundos para garantir que a Api tenha sido inicializada;
- Enviar os dados do processo para inserção no banco através da Api;
- Consultar os dados do processo na base de dados através da Api;
- Consultar todos os processos persistidos através da Api;
- Excluir o processo número 0809979-67.2015.8.05.0080 do banco através da Api;

## Observações

* Para execução de testes adicionais a API poderá ser testada através do Postman ou Swagger. Para tanto, basta indicar que o processo WebApi será iniciado e dar o start na aplicação.


