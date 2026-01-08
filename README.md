# FileProcess - Validação de arquivos e Testes Unitários (C#)

Este é um pequeno projeto em C# que demonstra a implementação
de um método para verificar a existência de arquivos no sistema,
junto com um conjunto completo de testes automatizados usando MSTest.

---

## 🚀 Como executar o projeto

1. Clone o repositório
2. Abra a solução MyClass.sln (ou MyClass.slnx) no Visual Studio.
3. Compile a solução.
4. Abra a janela Test Explorer.
5. Execute todos os testes.

---

## 📌 Objetivo do Projeto

O propósito principal é mostrar:

✅ Uso de **validação de entrada (ArgumentNullException)**  
✅ Testes positivos e negativos para existência de arquivo  
✅ Testes de exceção  
✅ Testes usando **DeploymentItem**  
✅ Uso de **TestInitialize** e **TestCleanup**  
✅ Boas práticas de organização de testes  

---

## 📁 Estrutura do Projeto

```
FileProcess-UnitTests/
├── MyTest/                 # Código de produção
│   └── FileProcess.cs
├── MyClassesTest/          # Projeto de testes
│   ├── FileProcessTest.cs
│   ├── app.config
│   └── FileToDeploy.txt    # Usado com DeploymentItem
├── FileProcess.sln         # Solução .NET
└── README.md
```
