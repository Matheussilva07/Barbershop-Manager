## Sobre o projeto

Esta é uma **API RESTful** desenvolvida em C# com foco em uma **arquitetura de camadas** seguindo os princípios de **Domain-Driven Design (DDD)**. A API foi projetada para facilitar a criação, atualização, leitura e exclusão de dados em um banco de dados **MySQL**, utilizando uma abordagem moderna e modular para fácil manutenção e escalabilidade. A API emprega tecnologias e práticas robustas:

- Entity Framework Core para o mapeamento objeto-relacional, facilitando a manipulação de dados e abstraindo operações complexas do banco de dados.
- LINQ para consultas a objetos e simplificação de operações complexas de consulta.
- AutoMapper para conversão de objetos entre as camadas, garantindo que os dados sejam transportados e manipulados de forma consistente entre a camada de domínio e a camada de apresentação.
- FluentValidation para validação fluente, assegurando que os dados sejam validados antes de qualquer operação no banco de dados, reduzindo o risco de inconsistências.
- MySQL como banco de dados relacional, oferecendo alta performance e confiabilidade para armazenamento persistente dos dados da aplicação.
Essa estrutura modular em camadas é pensada para separar responsabilidades e permitir fácil manutenção e escalabilidade, sendo ideal para projetos de médio a grande porte.

### Features

- CRUD Completo: Endpoints para criação, leitura, atualização e exclusão de registros, permitindo operações completas sobre os dados.
- Validação Fluente: Validação robusta de dados de entrada com o FluentValidation, garantindo que apenas dados válidos sejam persistidos no banco.
- Mapper Automático: Conversão eficiente de objetos entre as camadas com AutoMapper, facilitando a transferência de dados entre o modelo de domínio e os objetos de - transferência de dados (DTOs).
- Consultas Otimizadas: Uso de LINQ para consultas dinâmicas, melhorando a performance e a simplicidade de consultas complexas.