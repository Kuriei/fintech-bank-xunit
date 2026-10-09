# fintech-bank-xunit
# FintechBank — Testes Unitários com xUnit

## 1. Visão Geral

O **FintechBank** é um projeto desenvolvido em C# com .NET 10, proposto na disciplina de Gestão e Qualidade de Software. O objetivo é implementar regras de negócio de uma aplicação bancária e verificar seu funcionamento por meio de testes unitários utilizando o framework xUnit.

O projeto contempla regras relacionadas à manutenção de contas correntes, realização de saques, cálculo de parcelas de empréstimos e aprovação de crédito.

## 2. Tecnologias Utilizadas

- **Linguagem:** C#
- **Framework:** .NET 10
- **Testes unitários:** xUnit
- **Versionamento:** Git e GitHub
- **Licença:** MIT

## 3. Funcionalidades

### 3.1. ContaCorrenteService

A classe `ContaCorrenteService` contém as regras de negócio relacionadas às contas correntes.

**Cálculo da taxa de manutenção**

O método `CalcularTaxaManutencao(decimal saldo, bool clienteEspecial)` determina a taxa de manutenção de acordo com o saldo e a categoria do cliente.

| Condição | Taxa |
|---|---:|
| Saldo maior ou igual a R$ 5.000,00 | R$ 0,00 |
| Cliente especial | R$ 0,00 |
| Saldo entre R$ 1.000,00 e R$ 4.999,99, não especial | R$ 12,50 |
| Saldo inferior a R$ 1.000,00, não especial | R$ 25,00 |

**Validação de saques**

O método `PodeRealizarSaque(decimal saldo, decimal limiteChequeEspecial, decimal valorSaque)` verifica se o saque pode ser realizado considerando o saldo disponível e o limite do cheque especial.

O saque é permitido quando o valor solicitado é menor ou igual à soma do saldo com o limite do cheque especial.

### 3.2. EmprestimoService

A classe `EmprestimoService` contém as regras de negócio relacionadas aos empréstimos.

**Cálculo do valor da parcela**

O método `CalcularValorParcela(decimal valorTotal, int parcelas, int scoreCredito)` calcula o valor de cada parcela considerando o valor do empréstimo, a quantidade de parcelas e o score de crédito do cliente.

| Score de crédito | Juros totais |
|---|---:|
| Maior ou igual a 700 | 5% |
| Entre 500 e 699 | 12% |
| Inferior a 500 | 20% |

O valor total com juros é dividido pela quantidade de parcelas para obter o valor de cada parcela.

**Aprovação de empréstimos**

O método `AprovarEmprestimo(decimal rendaMensal, decimal valorParcela)` verifica se o valor da parcela compromete, no máximo, 30% da renda mensal do cliente.

O empréstimo é aprovado quando o valor da parcela é menor ou igual a esse limite.

## 4. Estrutura do Projeto

```text
fintech-bank-xunit/
├── .gitignore
├── LICENSE
├── README.md
└── fintech/
    ├── FintechBank.slnx
    ├── FintechBank.App/
    │   ├── FintechBank.App.csproj
    │   ├── Program.cs
    │   ├── ContaCorrenteService.cs
    │   └── EmprestimoService.cs
    └── FintechBank.Tests/
        ├── FintechBank.Tests.csproj
        ├── UnitTest1.cs
        ├── ContaCorrenteServiceTests.cs
        └── EmprestimoServiceTests.cs
```

*Observação: os arquivos de teste específicos devem ser criados caso ainda não existam no repositório.*

## 5. Requisitos

Para trabalhar com o projeto, é necessário ter instalado:

- .NET SDK 10.0 ou superior compatível com o projeto.
- Git, para clonar o repositório.

Para conferir a versão instalada do .NET, execute:

```bash
dotnet --version
```

## 6. Como Clonar e Executar o Projeto

### Passo 1 — Clonar o repositório

No terminal, execute o comando abaixo, substituindo `SEU-USUARIO` pelo nome de usuário do GitHub responsável pelo repositório.

```bash
git clone https://github.com/SEU-USUARIO/fintech-bank-xunit.git
```

### Passo 2 — Acessar a pasta da solução

```bash
cd fintech-bank-xunit/fintech
```

### Passo 3 — Restaurar as dependências

```bash
dotnet restore FintechBank.slnx
```

### Passo 4 — Compilar a solução

```bash
dotnet build FintechBank.slnx
```

## 7. Testes Unitários com xUnit

Os testes unitários têm como objetivo verificar se as regras de negócio funcionam conforme os requisitos definidos.

O projeto utiliza o xUnit, framework que permite organizar e executar testes automatizados em C#.

### 7.1. Testes parametrizados com [Theory] e [InlineData]

O atributo `[Theory]` permite executar um mesmo método de teste com diferentes conjuntos de dados.

O atributo `[InlineData]` fornece os valores utilizados em cada execução, permitindo verificar diferentes cenários sem precisar criar um método separado para cada caso.

### 7.2. Cenários de teste previstos

**ContaCorrenteServiceTests**

- Verificar a isenção da taxa para clientes com saldo elevado.
- Verificar a isenção da taxa para clientes especiais.
- Verificar a taxa de manutenção para saldos intermediários.
- Verificar a taxa de manutenção para saldos baixos.
- Verificar saques dentro do saldo e limite disponíveis.
- Verificar saques que excedem o saldo e o limite disponíveis.

**EmprestimoServiceTests**

- Verificar o cálculo das parcelas para score de crédito alto.
- Verificar o cálculo das parcelas para score de crédito intermediário.
- Verificar o cálculo das parcelas para score de crédito baixo.
- Verificar a aprovação de empréstimos quando a parcela compromete exatamente 30% da renda.
- Verificar a recusa de empréstimos quando a parcela ultrapassa 30% da renda.

### 7.3. Executar os testes

Na pasta `fintech`, execute:

```bash
dotnet test FintechBank.slnx
```

O comando compila os projetos necessários e executa os testes automatizados encontrados na solução.

O resultado esperado é a aprovação de todos os testes implementados, sem falhas.

## 8. Objetivos de Qualidade

O projeto busca demonstrar a aplicação de práticas de qualidade de software, incluindo:

- Separação das regras de negócio em classes de serviço.
- Organização do código em projetos distintos para aplicação e testes.
- Validação de diferentes cenários por meio de testes parametrizados.
- Identificação de erros antes da entrega do software.
- Utilização do GitHub para versionamento e documentação.

## 9. Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo `LICENSE` para obter os termos completos.

## 10. Desenvolvedores

- **Cauã Parreiras Vieira** — RA: 32516918
- **Maria Luísa do Carmo Cardoso** — RA: 325116932
- **Yasmin Aparecida Souza de Paula** — RA: 32612974

---

Projeto acadêmico desenvolvido para a disciplina de Gestão e Qualidade de Software.
