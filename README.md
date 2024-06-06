# PetView - Clínica Veterinária - A3 

> Este é um projeto de aplicação em C#, que consiste em um sistema de controle de agendamento e atendimento veterinário com cadastro de tutor, desenvolvido com Windows Forms. O objetivo desta aplicação é fornecer uma interface para realizar um CRUD, com testes unitários.

## Funcionalidades

A aplicação oferece as seguintes funcionalidades:

- **Criar uma tarefa (cadastrar uma tarefa):**
  - Título
  - Descrição
  - Responsável
  - Prioridade (baixa, média e alta)
  - Deadline (data)

- **Listagem de tarefas por:**
  - Número
  - Título/Descrição
  - Responsável
  - Situação (Em andamento/Concluído)

## Tecnologias Utilizadas

- Linguagem C#
- Windows Forms
- Design Patterns: Method Factory, Builder e Singleton
- Arquitetura MVC (Model, View, Controller)
- SLQ Server / SQL Server Management Studio
- JPA com Hibernate
- xUnit (Testes Unitários)

## Instruções para Execução Local

### Pré-requisitos

- Visual Studio 2022 IDE.
- SLQ Server / SQL Server Management Studio instalado e configurado.

### Passos

1. Clone este repositório em sua máquina local.
2. Abra o Visual Studio 2022 e importe o projeto selecionando a opção: _“Abrir um projeto ou uma solução...”_  Arquivo: PetView.sln. 
3. Configure o banco de dados - Link útil para configurar (<https://www.youtube.com/watch?v=Lc3yclqM8rQ&t=66s&ab_channel=NerddosDados>).
4. Clique em ***"Propriedades" do projeto PetView >> Configurações >> Valor"***  , e clique nos "..." três pontos para realizar a conexão com o banco de dados.
5. Quando tudo estiver configurado, basta executar o **Program.cs** na raiz do projeto.

### Observações

Certifique-se de que você tenha configurado corretamente conforme as instruções anteriores.

Agora você está pronto para executar o projeto de gerenciamento de atendimento, de uma clínica veterinária, com SQL Server localmente!