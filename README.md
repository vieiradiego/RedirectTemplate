# RedirectTemplate

API REST para geração de URLs de redirecionamento baseadas em informações de produtos lidas de QR codes.

## 📋 Sobre o Projeto

O **RedirectTemplate** é uma aplicação ASP.NET Core que recebe códigos de produtos escaneados de QR codes e gera URLs de redirecionamento dinâmicas. O sistema consulta informações de produtos, marcas, países e URLs base para construir URLs personalizadas com todos os dados relevantes do produto.

## 🛠️ Tecnologias

- **ASP.NET Core 8.0** - Framework web
- **Entity Framework Core 8** - ORM
- **MySQL** - Banco de dados principal (via Pomelo.EntityFrameworkCore.MySql)
- **MongoDB** - Banco de dados alternativo
- **Swagger/OpenAPI** - Documentação da API
- **API Versioning** - Versionamento de endpoints (via Asp.Versioning)

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```
Controllers → Services → Business → Repository → Database
```

### Camadas

- **Controllers**: Recebem requisições HTTP e retornam respostas
- **Services**: Orquestram a lógica de negócio
- **Business**: Contêm as regras de negócio
- **Repository**: Abstraem o acesso aos dados (MySQL/MongoDB)
- **Data/Models**: Modelos de dados e contextos de banco

## 📊 Modelos de Dados

### Product (Produto)
- `Company`: Código da empresa
- `Serie`: Série do produto
- `ComercialName`: Nome comercial
- `Brand`: Código da marca
- `SapIdClient`: ID do cliente no SAP
- `SapClientAlpha_2Code`: Código do país (ISO Alpha-2)

### Brand (Marca)
- `Code`: Código da marca
- `Description`: Nome da marca

### Country (País)
- `Name`: Nome do país
- `Alpha_2Code`: Código ISO de 2 letras
- `Alpha_3Code`: Código ISO de 3 letras
- `NumericCode`: Código numérico
- `Latitude` / `Longitude`: Coordenadas geográficas

### Url
- `Company`: Código da empresa
- `Url`: URL base para redirecionamento

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- MySQL Server
- (Opcional) MongoDB Server

### Configuração

1. **Clone o repositório**
   ```bash
   git clone <repository-url>
   cd RedirectTemplate
   ```

2. **Configure a connection string**
   
   Edite o arquivo `appsettings.json`:
   ```json
   {
     "connectionStrings": {
       "MySQL": "Server=localhost;DataBase=redirecttemplate;Uid=root;Pwd=root"
     }
   }
   ```

3. **Restaure as dependências**
   ```bash
   dotnet restore
   ```

4. **Execute as migrations**
   ```bash
   dotnet ef database update
   ```

5. **Execute a aplicação**
   ```bash
   dotnet run
   ```

6. **Acesse a documentação Swagger**
   ```
   https://localhost:5001/swagger
   ```

## 📝 API Endpoints

### `GET /v1/Product`

Gera URL de redirecionamento baseada em código de empresa e série do produto.

**Parâmetros:**
- `code` (string, obrigatório) - Código da empresa
- `rack` (string, obrigatório) - Série do produto

**Exemplo de Requisição:**
```http
GET /v1/Product?code=2010&rack=ABCDE123456789ABC12
```

**Resposta:**
```http
HTTP/1.1 301 Moved Permanently
Location: https://qrcode.autoexperts.parts/product/?company=2010&serie=ABCDE123456789ABC12&brand=Fras-le&product=PD/60&country=BR
```

**Códigos de Status:**
- `301 Permanent Redirect` - Redirecionamento bem-sucedido
- `400 Bad Request` - Parâmetros inválidos ou ausentes

## 🔄 Fluxo de Execução

1. Cliente faz requisição com `code` (empresa) e `rack` (série)
2. Sistema busca o produto pela empresa e série
3. Sistema busca a marca associada ao produto
4. Sistema busca o país pelo código Alpha-2
5. Sistema busca a URL base pela empresa
6. Sistema monta a URL final com todos os parâmetros
7. Retorna redirecionamento HTTP 301

## 🗄️ Banco de Dados

### Seed Data

O projeto inclui dados iniciais para desenvolvimento:

- **13 Marcas**: Bestbrake, Controil, Durbloc, Ferodo, Fras-le, Lonaflex, Midland Friction, Randon, Stop, StradaR, Randon Veículos, Fremax
- **5 Produtos** de exemplo
- **3 Países**: Afghanistan, Albania, Brazil
- **5 URLs base** para diferentes empresas

### Migrations

Para criar uma nova migration:
```bash
dotnet ef migrations add NomeDaMigration
```

Para aplicar migrations:
```bash
dotnet ef database update
```

## 📦 Estrutura do Projeto

```
RedirectTemplate/
├── Application/          # Filtros e configurações customizadas
├── Business/            # Lógica de negócio
│   └── Interface/       # Interfaces dos Business
├── Controllers/         # Controllers da API
├── Data/               # Modelos e contextos
│   ├── Context/        # DbContext (MySQL/MongoDB)
│   ├── Map/            # Mapeamento EF Core
│   └── Model/          # Modelos de dados
├── Migrations/         # Migrations do EF Core
├── Repository/         # Camada de acesso a dados
│   ├── Interface/      # Interfaces dos Repositories
│   ├── MongoDB/        # Implementação MongoDB
│   └── MySQL/          # Implementação MySQL
├── Service/            # Camada de serviços
│   └── Interface/      # Interfaces dos Services
├── Properties/         # Configurações de execução
├── Program.cs          # Ponto de entrada e configuração
└── appsettings.json    # Configurações
```

## 🔧 Configurações

### appsettings.json

```json
{
  "connectionStrings": {
    "MySQL": "Server=localhost;DataBase=redirecttemplate;Uid=root;Pwd=root"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## 🎯 Funcionalidades

- ✅ Redirecionamento dinâmico de URLs baseado em QR codes
- ✅ Suporte a múltiplos bancos de dados (MySQL/MongoDB)
- ✅ Versionamento de API
- ✅ Documentação automática com Swagger
- ✅ Seed data para desenvolvimento
- ✅ Migrations automáticas
- ✅ Arquitetura em camadas
- ✅ Padrão Repository

## 📚 Padrões de Design

- **Repository Pattern** - Abstração de acesso a dados
- **Dependency Injection** - Injeção de dependências nativa do ASP.NET Core
- **Layered Architecture** - Separação clara de responsabilidades
- **Generic Repository** - Repositório base genérico para reutilização
- **Strategy Pattern** - Múltiplas implementações de repositórios

## 🧪 Testes

Para executar os testes (se disponíveis):
```bash
dotnet test
```

## 📄 Licença

Este projeto está sob a licença [MIT](LICENSE).

## 👥 Contribuindo

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📞 Contato

Para dúvidas ou sugestões, entre em contato através das issues do projeto.

---

Desenvolvido com ❤️ usando ASP.NET Core
