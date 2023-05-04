

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/logo.png?raw=true)

# IGotUScraper.API 🚀

A aplicação 'IGotUScraper' é uma API WEB construida em três dias, em pequenos intervalos do meu trabalho. O objetivo da aplicação é a extração de dados de um produto em um respectivo site. O desafio foi proposto pela 'Pelando' como teste de avaliação. 


##  Sobre mim 

Olá, meu nome é Willian! Tenho 22 anos. Sou graduado em Analise e Desenvolvimento de Sistemas.
Sou apaixonado por desenvolvimento de Software, Modelagem
3D e Artes Digitais.  


## Endpoints Implementados

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/controllers.png?raw=true)

- Foram criados endpoint's dos dois contextos relacionais do Banco de Dados. 

## Retorno da Funcionalidade Principal 

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/response.png?raw=true)

- Exemplo de retorno de uma consulta realizada na www.amaro.com.


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
- CQRS - Segregação de Responsabilidade de Comando e Consulta 


## Tecnologias | Bibliotecas Utilizadas

- ASP .NET Versão 7 (Ultima versão lançada pela Microsoft)
- Swagger(Utilizado para documentar, também foi realizado o versionamento dos Endpoints)
- Dapper - Micro-ORM (Utilizado pelo desempenho, praticidade e melhor controle das consultas)
- MySql (Utilizado pela praticidade e gratuidade do serviço)
- Automapper (Utilizado para a conversão de objetos, utilzado visando a aplicação do 'Clean Code' e responsabilidade de saida/entrada)
- Xunit, Moq (Implementação dos Testes Unitarios)


## Arquitetura Utilizada | Clean Architecture

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/arquitetura.png?raw=true)


- Domain 

A camada de domínio representa as entidades e regras de negócio da aplicação, que são independentes de qualquer tecnologia ou framework. Aqui, podemos definir as classes de entidade e os serviços de negócio, podemos utilizar técnicas como DDD (Domain-Driven Design) para manter a lógica de negócio isolada do resto do sistema. 

- Infrastructure 

A camada de infraestrutura é responsável por implementar a lógica de acesso a dados e outras tecnologias especificas, como serviços de e-mail, cache, etc. Ela é a única camada que pode fazer referência a biblioteca externas e frameworks. Aqui, podemos criar classes que implementam interfaces definidas na camada de domínio, para que a logica de acesso a dados possa ser injetada nas classes de serviço de negócio. 

- Application 

A camada de aplicação é responsável por orquestrar a interação entre a camadas de Domínio  e Infraestrutura. Aqui, podemos utilizar um padrão como CQRS (Command Query   Segregation) para separar a lógica de leitura e escrita em diferentes bancos de dados, acessos a serviços externos, etc. 

Os benefícios de utilizar essa separação de camadas, é a facilidade de testar cada camada separadamente, a flexibilidade para mudar de tecnologia, implementação sem afetar a lógica de negócio e a escalabilidade da aplicação. 


- CQRS (Command Query Responsability Segregation)

Command (Persistencia)

O mesmo é responsável por receber solicitações de alteração de estado do sistema (inserção, atualização ou exclusão) e realizar as operações necessárias para atender a essas solicitações. Esse modelo é projetado para ser altamente consistente e transacional, garantindo que as operações sejam executadas com sucesso u que sejam revertidas caso ocorra algum erro. 

Query (Consulta)

O modelo de consulta é responsável por receber solicitações de leitura de informações do sistema (pesquisa, listagens ou detalhes) e retorna os dados solicitados. Esse modelo é projetado para ser altamente escalável e eficiente, permitindo que muitas solicitações sejam atendidas simultaneamente. 

Benefícios

- Permite que você otimize cada modelo para a tarefa especifica que está desempenhando. Exemplo: Otimizar modelos de consulta para consultas em cache e otimizar o modelo de comando para transações de banco de dados. 
  
- Escalonamento, como os modelos de comando e consultas são independentes um do outro, você pode escalá-los separadamente. 
  
  CQRS é um padrão arquitetural que separa a lógica de escrita e leitura em um sistema em modelos distintos. Essa separação traz várias vantagens, incluindo otimização de desempenho, escalabilidade e manutenibilidade do código.


## Testes Unitários

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/testes.png?raw=true)

- Os Testes Unitarios foram realizados utilizando a 'XUnit' & 'Moq'.
- Realizei os testes dos contextos: 'Controller', 'Application'.

## Visão Geral do Banco de Dados

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/bancodedados.png?raw=true)

- Realização de um esquema simples para projetar o relacionamento dos dados recuperados. 

## Visão dos Dados Salvos

![App Screenshot](https://github.com/willianrsouza/ImagesResource/blob/main/IGotUScraperAPI/dados.png?raw=true)

- Visão dos dados armazenados no Banco de Dados.  
- Você encontrara toda a estrutura dos dados no seguinte caminho: 'IGotUScraperAPI\IGotUScraperApi\IGotUScraperApi\Startup\Database\Scripts' assim podera replicar a estrutura criada. 

## Revisão de Engenharia 

- Aplicar o padrão "Notification", o padrão Notification é responsável por centralizar o tratamento de possíveis erros/exceções. Permitindo apenas a saída de logs da aplicação em casos de tratamento de erros, mensagem de exceção evitando a criação de exceção desnecessária.  Exemplos desse caso é a criação desnecessária de exceções de aplicação. 
  
- Evitar o tratamento de dados diretamente na Controller, essa validações após a implementação do Notification devem ser tratadas diretamente na camada de aplicação, delegando de forma correta as determinadas responsabilidades.
   
- Reforçar a necessidade de tratar regras de negocio na camada de domínio, evitando a duplicação desnecessária de código, criando domínios consistentes e evitando entidades anêmicas. 
  
-  Implementar testes unitários que quebram de diferentes formas o fluxo esperado, e implementação de testes unitários para as futuras adições do padrão Notification na camada de domínio. 
  
- 'EmpresaEntity', provavelmente se tornaria um "ValueObject",  pensando que flutuaria em diferentes contextos e tem grandes chances de ser uma entidade anêmica.
  
- Revisar a implementação do padrão Factory.
  
- Revisar a documentação do Swagger. 


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

Importe a estrutura do banco de dados criada, para um Banco MySql. A estrutura estará disponivel no seguinte caminho da aplicação

```bash
   'IGotUScraperAPI/IGotUScraperApi/IGotUScraperApi/Startup/Database/Scripts'
```

Altere as variaveis de conexão do banco de dados, acesse o arquivo abaixo

```bash
  
    'IGotUScraperAPI/IGotUScraperApi/IGotUScraperApi/appsettings.json '
 
``` 

Altere a ConnectionStrings de acordo com as suas variveis

```bash
 "ConnectionStrings": {
    "pelandodb": "Server=XXXXX;User=XXXX;Password='XXXX';Database=XXXXX"
   },
```


Inicie o projeto

```bash
  dotnet run
```


## 🔗 Links

[![portfolio](https://img.shields.io/badge/my_portfolio-000?style=for-the-badge&logo=ko-fi&logoColor=white)](https://openprocessing.org/user/356020/?view=sketches&o=4)

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/willianrsouza/)


