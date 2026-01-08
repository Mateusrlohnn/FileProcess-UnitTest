# FileProcess - Validação de arquivos e Testes Unitários (C#)

Este é um pequeno projeto em C# que demonstra a implementação
de um método para verificar a existência de arquivos no sistema,
junto com um conjunto completo de testes automatizados usando MSTest.

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

FileProcess-UnitTests/
├── MyTest/ ← Código de produção
│ └── FileProcess.cs
├── MyClassesTest/ ← Projeto de testes
│ ├── FileProcessTest.cs
│ ├── app.config
│ └── FileToDeploy.txt ← Usado com DeploymentItem no teste
├── FileProcess.sln ← Solução .NET
└── README.md
