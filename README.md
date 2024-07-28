
# Cálculo do CDB 🧮

Aplicação criada para realizar o cálculo do CDB após informado o valor do investimento e o prazo. 

A aplicação retorna o valor bruto e o valor líquido do investimento.
## Rodando localmente (Visual Studio)

Abra o terminal e clone o projeto

```bash
  git clone https://github.com/camillalima/CalculoCdb.git
```

Navegue até o diretório do projeto front

```bash
  cd CalculoCdb\b3.calculocdb.client
```

Instale as dependências

```bash
  npm install
```

### Abra a solution no Visual Studio

Para executar mais de um projeto no visual studio, faça os seguintes passos:

* Menu Projetos > Configurar projetos de inicialização
* Marque a opção "Vários projetos de inicialização" 
* Marque os projetos "B3.CalculoCdb.Api" e "b3.calculocdb.client" para Iniciar.



## Executar testes unitários e relatório de cobertura - API

Abra o terminal e navegue até o diretório do projeto de teste

```bash
  cd .\B3.CalculoCdb.Tests\
```

Execute o comando
```bash
  dotnet test /p:CollectCoverage=true
```


## Tecnologias

- Visual Studio 2022
- ASP.NET Core 8
- Swagger
- Angular
- Node.Js




