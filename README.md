
# IGotUScraper.API 

A aplicação 'IGotUScraper' é uma API WEB construida em três dias, em pequenos intervalos do meu trabalho. O objetivo da aplicação é a extração de dados de um produto em um respectivo site. O desafio foi proposto pela 'Pelando' como teste de avaliação. 


## 🚀 Sobre mim

Olá, meu nome é Willian! Tenho 22 anos. Sou graduado em Analise e Desenvolvimento de Sistemas.
Sou apaixonado por desenvolvimento de Software, Modelagem
3D e Artes Digitais.  


## Endpoints Disponiveis

![App Screenshot](https://i.ibb.co/y8L8c3v/Controllers.png)

- Foram criados endpoint's dos dois contextos relacionais do Banco de Dados. 

## Retorno da Funcionalidade Principal 

![App Screenshot](https://i.ibb.co/jJQR131/Response.png)

- Um exemplo do retorno de uma consulta na 'amaro'.



## Sites Utilizados Para a Extração de Dados (Até o momento)

- Amaro: https://amaro.com/
- Saraiva: https://www.saraiva.com.br/

## Funcionalidades da Aplicação

- Consultar e Armazenar dados de um determinado produto exposto online, utilizando o Scraping (Raspagem de Dados).
- Obter um produto por 'Id'. 
- Obter uma lista dos dados armazenados.
- Obter uma empresa cadastrada por 'Id'.

- Obter empresas cadastradas, disponiveis para consulta. 


## Padrões de Projeto Aplicados

- Mediator (MediatR) - Redirecionamento de Requisições.
- Factory Method - Uma fabrica responsavel pela criação de um produto de acordo com seu contexto. 
- Injeção de Dependencia (Inversão de Controle) - Responsavel por individualizar a responsabilidade das classes.
- CQRS - Segregação de Responsabilidade de Comando e Consulta  - Utilizei pensando em consumo de possiveis contextos futuros de banco. 

## Tecnologias | Bibliotecas Utilizadas

- ASP .NET Versão 7 (Ultima versão lançada pela Microsoft)
- Swagger(Utilizado para documentar, também foi realizado o versionamento dos Endpoints)
- Dapper - Micro-ORM (Utilizado pelo desempenho, praticidade e melhor controle das consultas)
- MySql (Utilizado pela praticidade e gratuidade do serviço)
- Automapper (Utilizado para a conversão de objetos, utilzado visando a aplicação do 'Clean Code' e responsabilidade de saida/entrada)
- Xunit, Moq (Implementação dos Testes Unitarios)


## Arquitetura Utilizada - Clean Architecture

![App Screenshot](https://five.agency/wp-content/uploads/2016/11/Graph-2.png)


- A implementação da 'Clean Architecture' foi uma escolha pessoal, pois além de gostar bastante dessa visão arquitetural e divisoria de responsabilidade, poderia colocar em prática novas visões adquiridas recentemente da mesma.  



## Testes Unitários

![App Screenshot](https://i.ibb.co/JHPFzQv/Testes.png)

- Os Testes Unitarios foram realizados utilizando a 'XUnit' & 'Moq'.
- Realizei os testes dos contextos: Controller, Application.

## Visão Geral do Banco de Dados

![App Screenshot](https://i.ibb.co/yR2vLtK/Database.png)

- Realização de um esquema simples, para projetar o relacionamento dos dados recuperados. 

## Visão dos Dados Salvos

![App Screenshot](https://i.ibb.co/BjL6Lnh/Banco-de-dados.png)

- Visão dos dados armazenados no Banco de Dados.  
- Você encontrara toda a estrutura dos dados no seguinte caminho: 'IGotUScraperAPI\IGotUScraperApi\IGotUScraperApi\Startup\Database\Scripts' assim podera replicar a estrutura criada. 
## Rodando Localmente

Clone o projeto:

```bash
  git clone https://github.com/willianrsouza/IGotUScraperAPI.git
```

Entre no diretório do projeto:

```bash
  cd IGotUScraperAPI
```

Compile o Projeto e suas Dependências:

```bash
  dotnet build
```

Importe a estrutura do banco de dados criada, para um Banco MySql. A estrutura estará disponivel no seguinte caminho da aplicação:

```bash
   'IGotUScraperAPI/IGotUScraperApi/IGotUScraperApi/Startup/Database/Scripts'
```

Altere as variaveis de conexão do banco de dados, acesse o arquivo abaixo:

```bash
  
    'IGotUScraperAPI/IGotUScraperApi/IGotUScraperApi/appsettings.json '
 
``` 

Altere a ConnectionStrings de acordo com as suas variveis:

```bash
 "ConnectionStrings": {
    "pelandodb": "Server=XXXXX;User=XXXX;Password='XXXX';Database=XXXXX"
   },
```


Inicie o projeto:

```bash
  dotnet run
```


## 🔗 Links

[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://openprocessing.org/user/356020/?view=sketches&o=4)

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/willianrsouza/)


