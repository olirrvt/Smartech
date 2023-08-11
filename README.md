# SmartecAPI - API de E-Commerce desenvolvida em ASP.NET Core 🚀

A **SmartecAPI** é uma API de E-Commerce desenvolvida como parte de um teste técnico. Ela permite a gestão de produtos, promoções e carrinhos de compras. A API foi desenvolvida utilizando o framework ASP.NET Core, Entity Framework e SQL Server. Além disso, ela é documentada com Swagger para facilitar a compreensão e o consumo dos endpoints.

## Decisões Técnicas e Arquiteturais

A arquitetura escolhida para o projeto é o padrão **MVC (Model-View-Controller)**, que separa a aplicação em camadas distintas, promovendo a organização e a manutenção do código. O Entity Framework foi utilizado com o método **DB First** para mapear a estrutura do banco de dados existente. Para garantir uma boa organização do trabalho, foi utilizado o método de gerenciamento de projeto **Kanban**.

## Frameworks e Bibliotecas

- **ASP.NET Core**: Utilizado como framework base para a construção da API devido à sua escalabilidade, flexibilidade e suporte multiplataforma.
- **Entity Framework Core**: Utilizado para a camada de acesso a dados, permitindo a abstração do banco de dados e a execução de operações CRUD de maneira eficiente.
- **Swagger**: Utilizado para a documentação automática da API, permitindo uma melhor compreensão dos endpoints e facilitando a integração com outras aplicações.
- **Microsoft SQL Server**: Utilizado como banco de dados para armazenamento dos dados da aplicação.

## Compilação e Execução do Projeto

1. Clone o repositório do projeto: `git clone <URL_DO_REPOSITORIO>`
2. Abra a solução no Visual Studio ou Visual Studio Code.
3. Certifique-se de que a string de conexão com o banco de dados esteja configurada corretamente no arquivo `appsettings.json`.
4. Compile o projeto.
5. Execute o projeto. A API estará disponível em `https://localhost:7132`.

## Práticas de Desenvolvimento

Durante o desenvolvimento da API, foram adotadas as seguintes práticas:

- **Separação de Responsabilidades**: A arquitetura MVC foi seguida para separar as responsabilidades da aplicação em Model, View e Controller.
- **Tratamento de Erros**: Os endpoints da API retornam códigos HTTP apropriados para indicar o sucesso ou falha das operações.
- **Validações**: Foram utilizadas validações de modelos e tratamento de erros para garantir a integridade dos dados.
- **Documentação**: A documentação dos endpoints foi automatizada com o Swagger para facilitar o entendimento e uso da API.

## Notas Adicionais

A SmartecAPI foi desenvolvida como parte de um teste técnico para demonstrar as habilidades em desenvolvimento de APIs em ASP.NET Core. Ela apresenta um conjunto básico de funcionalidades de um e-commerce, incluindo gestão de produtos, promoções e carrinhos de compras. É importante ressaltar que, para um ambiente de produção, seriam necessárias mais considerações em termos de segurança, escalabilidade e otimização de desempenho. Este projeto serve como uma prova de conceito funcional e pode ser expandido conforme as necessidades reais do negócio.

---

Este README fornece uma visão geral da API **SmartecAPI** e das decisões tomadas durante o desenvolvimento. Para mais detalhes sobre os endpoints, modelos e outras funcionalidades, consulte a documentação gerada pelo Swagger ao executar o projeto.
