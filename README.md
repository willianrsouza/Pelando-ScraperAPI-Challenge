
## Endpoints: 

![App Screenshot](https://i.ibb.co/y8L8c3v/Controllers.png)
## Funcionalidades da Aplicação

- Consultar e Armazenar dados de um determinado produto exposto online, utilizando o Scraping (Raspagem de Dados).
- Obter um produto por 'Id'. 
- Obter uma lista dos dados armazenados.
- Obter uma empresa cadastrada por 'Id'.

- Obter empresas cadastradas, disponiveis para consulta. 


## Padrões de Projeto Aplicados

- Mediator (MediatorR) - Redirecionamento de Requisições.
- Factory Method - Uma fabrica responsavel pela criação de um produto de acordo com seu contexto. 
- Injeção de Dependencia (Inversão de Controle) - Responsavel por individualizar a responsabilidade das classes.
- CQRS - Segregação de Responsabilidade de Comando e Consulta  - Utilizei pensando em consumo de possiveis contextos futuros de banco. 

## Tecnologias | Bibliotecas Utilizadas

- ASP .NET 7 (Ultima versão lançada pela Microsoft)
- Swagger(Utilizado para documentar, realizei o versionamento dos Endpoints)
- Dapper - Micro-ORM (Utilizado pela praticidade e controle das consultas)
- MySql (Utilizado pela praticidade e gratuidade do serviço)
- Automapper (Utilizado visando a aplicação do Clean Code)


## Arquitetura Utilizada:

![App Screenshot](https://five.agency/wp-content/uploads/2016/11/Graph-2.png)


## Rodando Localmente

Clone o projeto

```bash
  git clone https://github.com/willianrsouza/IGotUScraperAPI.git
```

Entre no diretório do projeto

```bash
  cd IGotUScraperAPI
```

Compile o Projeto e suas Dependências

```bash
  dotnet build
```

Inicie o projeto

```bash
  dotnet run
```

