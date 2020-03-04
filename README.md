# Imagine Beyond

### Camadas necessárias (backend)

| Camadas   |      Ações      |
|----------|:-------------:|
| WebApi | Necessário implementar |
| Application | Finalizar CustomerAppService |
| Domain | Validar e-mail |
| Repository | Necessário implementar |
| Test | Necessário implementar |

### Regra de negócio

Será necessário criar uma API que permita realizar cadastro, edição, exclusão e visualização de um cliente, seguem abaixo os requisitos mínimos:

  - Campos mínimos:
    - Nome;
    - Sobrenome;
    - E-mail;
        -  Validar o e-mail
    - Data de nascimento;
    - Data de criação;
    - Data da última atualização;

### Requisitos necessários e comandos 

   - .NET Core 3.1 ou superior [Download](https://dotnet.microsoft.com/download);
   - Visual Studio 2019 Community ou Visual Studio Code [Download](https://visualstudio.microsoft.com/pt-br/)

-----------------------------------------------------------------------------------------------------------------

 - Visual Studio 2019 Community

Abra a solution src/ImagineBeyond.sln

 - Visual Studio Code
Abra o terminal de sua preferencia na pasta src/
  
  buildar o projeto
  ```sh
  $ dotnet build 
  ```
  Iniciar o projeto na porta localhost://5001 (terminal dentro da pasta src/ImagineBeyond.UI.Web)
  ```sh
  $ dotnet run 
  ```
  Rode seus testes (terminal dentro da pasta src/ImagineBeyond.Test)
  ```sh
  $ dotnet test 
  ```
    
Mais detalhe sobre, você encontra na documentação oficial da [Microsoft](https://docs.microsoft.com/pt-br/dotnet/core/tools/?tabs=netcore2x)
    
  
### Banco de dados (aceitos)

 - Banco de dados:
   - SQL Server;
   - Oracle;
   - MySQL;
   - MongoDB;

### Necessário

 - Injeção de dependência (DI)
 - WebApi (Back-end)
 - Utilização de ValueObject
 - Teste unitário
 - AutoMapper [Descrição](https://automapper.org/)

### Documentação

Será necessário criar markdown explicando como execultar o seu projeto em nossa máquina, como ser executado, porta que deve ser configurado e etc, seguiremos seu tutorial para rodar e testar sua aplicação. Inclua também nessa documentação bibliotecas utilizadas, versão dos framework utilizado e etc.

Para ajudar a criar um markdown recomendo ser utilizar [Dillinger](https://dillinger.io/)
