
### Estratégias de Herança no Entity Framework Core 7

1.  **Table Per Hierarchy (TPH):**
    -   Todos os tipos derivados compartilham uma única tabela no banco de dados.
    -   Uma coluna de discriminação é usada para distinguir entre os diferentes tipos na hierarquia.
2.  **Table Per Type (TPT):**
    -   Cada tipo na hierarquia possui sua própria tabela no banco de dados.
    -   As tabelas são conectadas por meio de relacionamentos de chave estrangeira.
3.  **Table Per Concrete Type (TPC):**
    -   Cada tipo concreto (derivado) na hierarquia possui sua própria tabela no banco de dados.
    -   Não há uma tabela para a classe base os dados da classe base são repetidos nas tabelas dos tipos derivados.

### Quando utilizar **Table Per Hierarchy (TPH):** ?

A escolha de quando usar a estratégia **Table Per Hierarchy (TPH)** no Entity Framework Core depende das necessidades específicas do seu modelo de dados e da forma como deseja representar a herança no banco de dados. Aqui estão alguns cenários em que o TPH pode ser uma escolha apropriada:

1.  **Herança Simples:**
    -   Use TPH quando a hierarquia de herança é simples, e todos os tipos derivados compartilham a maioria dos mesmos
    atributos. Isso é comum quando você tem uma classe base com algumas propriedades comuns e tipos derivados que
    adicionam propriedades específicas.

2.  **Menos Tabelas no Banco de Dados:**
    -   Se você preferir minimizar o número de tabelas no banco de dados, o TPH pode ser apropriado. Ele usa uma única
    tabela para armazenar todos os tipos na hierarquia, evitando a criação de várias tabelas.

3.  **Consultas Simples:**
    -   Quando você geralmente realiza consultas que envolvem todos os tipos na hierarquia juntos, o TPH pode simplificar
    suas consultas, pois todos os dados estão em uma tabela.

4.  **Discriminador de Tipo Útil:**
    -   Se o uso de um discriminador de tipo (uma coluna que indica o tipo de cada registro) for aceitável e útil para distinguir
    entre os tipos na hierarquia, o TPH é uma escolha apropriada.

5.  **Desempenho:**
    -   Em alguns casos, o TPH pode oferecer melhor desempenho em comparação com outras estratégias de herança, pois
    requer menos joins em consultas que envolvem a hierarquia.

### Quando utilizar **Table Per Type (TPT):** ?

A estratégia **Table Per Type (TPT)** no Entity Framework Core é apropriada em certos cenários onde a hierarquia de herança é melhor representada por tabelas separadas para cada tipo derivado. Aqui estão alguns cenários em que o TPT pode ser uma escolha adequada:

1.  **Modelagem de Dados Complexa:**
    -   Use TPT quando a hierarquia de herança é complexa e os tipos derivados têm muitas propriedades exclusivas,
    resultando em tabelas distintas para cada tipo. Cada tabela terá suas próprias colunas, permitindo uma modelagem
    mais detalhada.

2.  **Relacionamentos Fortes:**
    -   Se os tipos derivados têm relacionamentos fortes com outras entidades no modelo, TPT pode ser mais apropriado.
    -   Cada tipo derivado pode ter suas próprias tabelas relacionadas, proporcionando maior flexibilidade.

3.  **Consultas Específicas:**
    -   Quando as consultas normalmente envolvem apenas um tipo derivado, TPT pode ser benéfico. Cada tabela terá uma
        estrutura independente, facilitando consultas específicas a um tipo sem a necessidade de joins complexos.

4.  **Melhor Normalização:**
    -   Em casos em que a normalização do banco de dados é uma prioridade e você deseja evitar a repetição de colunas
    para tipos base, o TPT pode ser uma escolha mais adequada do que TPH (Table Per Hierarchy).

5.  **Performance Específica:**
    -   Dependendo dos padrões de acesso aos dados, TPT pode oferecer melhor desempenho em algumas consultas
    específicas em comparação com outras estratégias de herança.

### Quando utilizar Table Per Concrete Type (TPC): ?

A estratégia T**able Per Concrete Type (TPC)** no Entity Framework Core é apropriada em cenários específicos onde cada tipo concreto (derivado) na hierarquia de herança tem sua própria tabela no banco de dados. Aqui estão alguns cenários em que o TPC pode ser uma escolha adequada:

1.  **Independência Total:**
    -   Use TPC quando cada tipo derivado na hierarquia tem sua própria tabela e não compartilha uma tabela comum com a
    classe base. Isso proporciona independência total entre os tipos concretos.

2.  **Evitar Joins em Consultas:**
    -   Se você deseja evitar joins em consultas e acessar diretamente os dados relacionados a um tipo específico sem a
    necessidade de referenciar outras tabelas, o TPC pode ser benéfico.

3.  **Modelagem de Dados Denormalizada:**
    -   Em situações em que a normalização do banco de dados não é uma prioridade e você pode aceitar a redundância de
    dados entre as tabelas, o TPC pode ser uma escolha adequada.

4.  **Tipos Concretos Distintos:**
    -   Quando os tipos concretos na hierarquia têm estruturas de dados significativamente diferentes e não compartilham
    muitas propriedades, TPC pode ser mais apropriado do que **TPH (Table Per Hierarchy)** ou **TPT (Table Per Type)**.

5.  **Performance Específica:**
    -   Dependendo das consultas frequentes no seu aplicativo, o TPC pode oferecer melhor desempenho em comparação
    com outras estratégias de herança, pois evita joins e permite acesso direto aos dados de um tipo específico.

> É crucial avaliar cuidadosamente os prós e contras de cada estratégia
> e escolher aquela que melhor atenda aos requisitos do seu domínio de
> dados e ao desempenho desejado.