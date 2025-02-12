# Sistema de Gestão Acadêmica

Este projeto implementa um sistema de gestão acadêmica utilizando o padrão de projeto *Command*, permitindo operações CRUD (Create, Read, Update, Delete) para alunos e livros em uma secretaria e biblioteca acadêmica. A comunicação com o banco de dados é realizada através de MySQL.

## Tecnologias Utilizadas

- **C#**: Linguagem de programação utilizada para implementar o sistema.
- **MySQL**: Banco de dados utilizado para armazenar as informações dos alunos e livros.
- **Padrão de Projeto Command**: Usado para encapsular comandos que podem ser executados em diferentes contextos.

## Funcionalidades

O sistema possui as seguintes funcionalidades:

- **Gerenciar Alunos**:
  - **Inserir**: Cadastro de novos alunos.
  - **Atualizar**: Modificação de dados de um aluno.
  - **Excluir**: Remoção de um aluno.
  - **Consultar**: Consultar dados de um aluno.

- **Gerenciar Livros**:
  - **Inserir**: Cadastro de novos livros.
  - **Atualizar**: Modificação de dados de um livro.
  - **Excluir**: Remoção de um livro.
  - **Consultar**: Consultar dados de um livro.

## Estrutura do Código

- **Comandos**: Cada operação (inserir, atualizar, excluir, consultar) é representada por um comando separado, que implementa a interface `ICommand`.
- **Invoker**: A classe `CommandInvoker` é responsável por invocar e executar os comandos específicos.
- **Secretaria**: Responsável pela gestão dos alunos.
- **Biblioteca**: Responsável pela gestão dos livros.
- **Repositorio**: Classe responsável pela conexão com o banco de dados MySQL e execução dos scripts SQL.

## Como Executar o Projeto

1. **Pré-requisitos**:
   - Ter o .NET instalado em seu sistema.
   - Ter um servidor MySQL configurado e acessível.
   - Configurar a string de conexão no arquivo `Repositorio.cs` com os dados do seu banco de dados.

2. **Executando**:
   - Clone o repositório para sua máquina local.
   - Abra o projeto no Visual Studio ou no editor de sua preferência.
   - Compile e execute o projeto.

## Exemplo de Uso

Após rodar o sistema, o usuário pode interagir com o menu de opções para inserir, atualizar, excluir ou consultar informações sobre alunos e livros. O sistema vai solicitar as informações necessárias, como o nome do aluno ou ISBN do livro, e processará os comandos de acordo com a opção escolhida.
