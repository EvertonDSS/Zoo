# 🦁 Gerenciamento de Animais do Zoológico

Este projeto é uma aplicação web para gerenciar animais e seus cuidados em um zoológico. Ele é composto por uma API REST desenvolvida em .NET 8.0 e um frontend em Angular.

---

## 🚀 Como Rodar o Projeto

### 🔧 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Node.js e npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- SQL Server

### 🗂️ Configuração do Backend (.NET)

1. **Clone o repositório e entre na pasta do projeto:**
   ```bash
   git clone https://github.com/EvertonDSS/Zoo.git
   cd zoo/back
   ```

2. **Configure a connection string no `appsettings.json` em back/GerenciamentoZoo.Api:**
   ```json
   "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=gerenciador-zoo;User Id=<usuario>;Password=<senha>;TrustServerCertificate=true;Encrypt=True"
   }
   ```
   > 🔁 Altere para os dados corretos do seu SQL Server local ou remoto.

3. **Rode as migrations:**
   ```bash
   dotnet ef database update --project GerenciamentoZoo.Infra --startup-project GerenciamentoZoo.API
   ```

4. **Rode a API:**
   ```bash
   dotnet run --project GerenciamentoZoo.API
   ```

### 🖥️ Configuração do Frontend (Angular)

1. **Entre na pasta do frontend:**
   ```bash
   cd zoo/gerenciamento-zoo
   ```

2. **Instale as dependências:**
   ```bash
   npm install
   ```

3. **Rode o frontend:**
   ```bash
   ng serve
   ```

4. Acesse no navegador: `http://localhost:4200`

---

## ✅ Funcionalidades Implementadas

- Listar, Cadastrar, Editar e Remover **Animais** e **Cuidados**
- Cadastro de Animal com:
  - Nome, descrição, data de nascimento, espécie, habitat e país de origem
- Cadastro de Cuidado com:
  - Nome, descrição, frequência (diária, semanal, mensal etc.)
- Associação de vários cuidados a um mesmo animal
- Consumo da API REST no frontend
- Implementação completa de métodos GET, POST, PUT e DELETE
- Validações na API para consistência dos dados

---

## 🌟 Funcionalidades Extras

- Modelagem de banco com **relacionamento muitos-para-muitos** entre Animais e Cuidados
- Uso do **SQL Server** com entidades relacionadas e mapeamento por Entity Framework Core



---

## 📌 Observações

- Ainda faltam algumas validações no frontend
- Falta de apresentação de mensagens de erros no front, apesar de estar corretamente retornando da api

# Maiores Dificuldades
- A utilização de uma implementação um pouco diferente do formato que normalmente estruturo meus projetos no back, com melhor separação entre as camadas
- Pouca familiriade prática com o Angular o que ocasionou em erros de utilização de Enum e exibição de mensagens
- Falta de tempo para finalização completa do front, com maior estruturação do back
