# BooksReadingManager

Um projeto construído em .NET seguindo os princípios da **Clean Architecture** para gerenciamento de leituras de livros. Este repositório oferece uma API robusta para cadastro, consulta e gerenciamento de livros, com autenticação e boas práticas de separação de responsabilidades.

---

## Sumário

- [Visão Geral da Arquitetura](#visão-geral-da-arquitetura-clean-architecture)
- [Descrição das Principais Classes](#descrição-das-principais-classes)
- [Como Executar Localmente (Visual Studio)](#como-executar-localmente-no-visual-studio)
- [Execução via Docker](#execução-via-docker)
- [Detalhes Técnicos Importantes](#detalhes-técnicos-importantes)

---

## Visão Geral da Arquitetura (Clean Architecture)

O projeto está organizado em camadas, respeitando a separação de responsabilidades e facilitando testes, manutenção e evolução:

- **Domain**: Entidades de negócio e enums. Não depende de nenhuma outra camada.
- **Application**: Interfaces, DTOs, serviços e lógica de aplicação.
- **Infrastructure**: Infraestrutura de persistência (implementações de banco, acesso externo, etc.).
- **API**: Apresentação (controllers), autenticação, validação e endpoints.

O fluxo de dependências é sempre do externo para o interno, ou seja, a API depende da Application, que depende da Domain (mas não o contrário).

---

## Descrição das Principais Classes

### API

- **Controllers/Base/MainController.cs**
  - Base para todos os controllers. Centraliza resposta customizada, notificação de erros e validação de modelos.
  - Métodos importantes: `CustomResponse`, `NotificarErro`, `OperacaoValida`.

- **Controllers/BooksController.cs**
  - Controlador principal para manipular livros (CRUD).
  - Exige autenticação (`[Authorize]`), utiliza serviços da camada Application e faz mapeamento com AutoMapper.
  - Endpoints: `GetAllBooks`, `GetOneBook`, `CreateBook`, `UpdateBook`, `Delete`.

- **Controllers/AuthController.cs**
  - Controlador para registro e login de usuários.
  - Utiliza serviços de autenticação da camada Application.

### Application

- **DTOs/BookDto.cs & DTOs/CreateBookDto.cs**
  - Objetos de transferência de dados para entrada e saída de informações de livros.

- **Mappings/BookProfile.cs**
  - Configuração do AutoMapper para conversão entre entidades e DTOs.

- **Interfaces/IBookService.cs**
  - Contrato dos serviços de livro: obter todos, obter por id, adicionar, atualizar, deletar.

- **Services/Notificador.cs**
  - Implementação de notificações para manipulação de feedbacks e erros.

### Domain

- **Entities/Book.cs**
  - Entidade central com propriedades como: `Id`, `Title`, `Author`, `Genre`, `Publisher`, `PageCount`, `PublishedDate`, `ISBN`, `Price`, `Format`, `Status`, `Notes`.

---

## Como Executar Localmente no Visual Studio

1. **Pré-requisitos:**
   - [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
   - Visual Studio 2022 ou superior (ou VS Code com extensão C#)
   - (Opcional) Docker Desktop para execução containerizada

2. **Passos:**
   - Clone o repositório:
     ```sh
     git clone https://github.com/IsabellyDiasLimaDev/BooksReadingManager.git
     ```
   - Abra a solução (`.sln`) no Visual Studio.
   - Configure o projeto `BookReadingManager.API` como o projeto de inicialização.
   - Configure as variáveis de ambiente e strings de conexão (ex: em `appsettings.json`).
   - Execute (F5) para rodar a API localmente.

3. **Testando a API:**
   - Use o Swagger (normalmente disponível em `/swagger` quando rodando local) para testar os endpoints.
   - Utilize ferramentas como Postman ou Insomnia para testes de integração.

---

## Execução via Docker

O projeto já possui um `Dockerfile` pronto para build e execução:

```sh
# No diretório raiz do projeto:
docker build -t booksreadingmanager-api -f BookReadingManager.API/Dockerfile .
docker run -p 8080:8080 booksreadingmanager-api
```
- A API estará disponível em `http://localhost:8080`.

---

## Detalhes Técnicos Importantes

- **Autenticação:** Implementada por meio do controller `AuthController` e serviço `IAuthService`.
- **Validações:** Uso de DataAnnotations nas entidades e validação de ModelState nos controllers.
- **Notificações:** Centralizadas pela interface e serviço `INotificador` e `Notificador`.
- **Padronização de Respostas:** Todos os endpoints respondem via `CustomResponse`, padronizando erros e dados de sucesso.
- **Automapper:** Conversão entre entidades e DTOs, facilitando manutenção e evolução dos contratos.
- **Separação de Camadas:** Cada projeto tem uma responsabilidade clara (Domain, Application, Infrastructure, API).

---

## Estrutura de Pastas (Resumo)

```
BookReadingManager.Domain/         # Entidades e enums de domínio
BookReadingManager.Application/    # Serviços, DTOs, interfaces, mapeamentos
BookReadingManager.Infrastructure/ # Implementações de infraestrutura
BookReadingManager.API/            # Controllers, autenticação, apresentação, Dockerfile
```

---

## Contribuições & Dúvidas

Sinta-se à vontade para abrir issues ou pull requests! Para dúvidas técnicas, consulte este README e o código/documentação interna das classes.

---
