# MyHealth Management 🏥💊

## Descrição

O **MyHealth Management** é uma aplicação inovadora desenvolvida para facilitar a gestão integrada de farmácias, medicamentos e reservas. O sistema permite o registo e a gestão dos medicamentos disponíveis, acompanhamento de stock, gestão de funcionários, e a realização de reservas e vendas de forma organizada e segura.

---

## Funcionalidades Principais ✅

- **Gestão de Farmácias:** Registo, edição e administração de farmácias.
- **Gestão de Funcionários:** Associação de funcionários às farmácias, com categorias e permissões.
- **Gestão de Stock:** Adição, atualização e controlo de stock de medicamentos.
- **Reservas de Medicamentos:** Clientes podem fazer reservas de medicamentos disponíveis.
- **Gestão de Vendas:** Processamento e registo de vendas efetuadas.
- **Interface intuitiva:** Aplicação Windows Forms com MaterialSkin para uma experiência de utilizador agradável e moderna.
- **Dashboard com gráficos:** Visualização de estatísticas e indicadores através de gráficos dinâmicos (usando LiveCharts).
- **Sistema de definições:** Personalização da aplicação, incluindo tema claro/escuro, idioma, tamanho da fonte, notificações, entre outros.
- **Persistência de dados:** Base de dados relacional para armazenamento eficiente e seguro (exemplo: SQL Server com Entity Framework).
- **Suporte para perfis de utilizador:** Gestão de sessões e controlo de acesso.

---

## Tecnologias Utilizadas 🛠️

- **Backend & Data Access:** C# com Entity Framework para acesso e manipulação da base de dados.
- **Interface:** Windows Forms com a biblioteca [MaterialSkin](https://github.com/IgnaceMaes/MaterialSkin) para UI moderna.
- **Visualização de dados:** LiveCharts 2 (LiveChartsCore.SkiaSharpView.WinForms) para gráficos e dashboards.
- **Base de dados:** SQL Server (ou outro SGBD relacional compatível).
- **Outras ferramentas:** JSON para armazenamento das definições da aplicação.

---

## Estrutura do Projeto 📁

- **Forms:**
  - Dashboard/Home com gráficos de vendas e estatísticas.
  - Gestão de Vendas.
  - Gestão de Reservas.
  - Gestão de Stock e Medicamentos.
  - Gestão de Funcionários.
  - Configurações/Ajustes do sistema e interface.
  
- **Camada de Dados:**
  - Modelos representando as tabelas principais: Utilizador, Farmácia, Funcionário, Medicamento, Stock, Reserva, Venda.
  - Utilização do Entity Framework para comunicação com a base de dados.

- **Utilitários:**
  - Funções para carregar e guardar as definições do utilizador (JSON).
  - Funções para aplicar temas e gerir contas.

---

## Instalação e Configuração ⚙️

1. **Pré-requisitos:**
   - .NET Framework 4.8 (ou superior)
   - SQL Server (ou outro servidor de base de dados compatível)
   - Visual Studio 2022 (ou superior) com suporte a Windows Forms e Entity Framework

2. **Configuração da Base de Dados:**
   - Executar o script SQL disponibilizado na pasta `/scriptsdb` para criar a estrutura da base de dados.

3. **Execução da Aplicação:**
   - Abrir o projeto no Visual Studio.
   - Restaurar os pacotes NuGet.
   - Compilar e executar.

---

## Licença 🚫

Este projeto é exclusivamente para fins educativos e **não pode ser utilizado comercialmente ou distribuído sem autorização**.  
Contribuições são bem-vindas, mas deverão ser solicitadas previamente ao autor.

---

## Autor ✍️

**Vicente**  
Estudante do Curso de Programação de Sistemas Informáticos — Ano letivo 2024/2025  
Contacto: vicenteld.dev@gmail.com
