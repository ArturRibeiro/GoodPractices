O design pattern **SAGA** é uma abordagem para tratar a coordenação de transações distribuídas em sistemas de software. Ele é usado para manter a consistência dos dados em sistemas distribuídos, onde várias ações podem ocorrer em diferentes serviços ou componentes. Existem duas abordagens principais para implementar o padrão SAGA: **Coreografia** (Choreography) e **Orquestração** (Orchestration). Vou explicar a diferença entre essas duas abordagens:

**Coreografia (Choreography)**:  
Na coreografia, a coordenação das transações é descentralizada e distribuída entre os componentes que participam da transação. Em vez de ter um componente central que controla e coordena todas as etapas da transação, cada componente envolvido na transação é responsável por coordenar sua própria parte. Cada componente reage a eventos e interage com outros componentes para garantir a consistência da transação.

**Vantagens da Coreografia**:

**Desacoplamento**: Cada componente não precisa ter conhecimento direto dos outros. Eles apenas precisam saber como responder aos eventos.  
**Escalabilidade**: É mais fácil adicionar novos componentes ou modificar o comportamento de um componente existente sem afetar a orquestração central.

**Desvantagens da Coreografia**:

**Complexidade**: Em sistemas complexos, a lógica de coordenação pode se tornar difícil de entender e depurar, pois está espalhada por vários componentes.  
**Rastreamento**: O acompanhamento e monitoramento de transações pode ser mais complicado, já que a lógica de coordenação não está centralizada.

**Orquestração (Orchestration)**:  
Na orquestração, há um componente central, chamado orquestrador, que controla e coordena todas as etapas da transação. O orquestrador decide a ordem das operações, quando e como elas devem ser executadas, e monitora o progresso da transação.

**Diagrama de Sequência para Coreografia:**

![](https://33333.cdn.cke-cs.com/kSW7V9NHUXugvhoQeFaf/images/24735102703fab1279338430d6525c138ecf75d83d4610b4.png)

**Vantagens da Orquestração**:

**Clareza**: A lógica de coordenação está centralizada no orquestrador, tornando-a mais fácil de entender e manter.  
**Rastreamento**: O acompanhamento e monitoramento das transações podem ser mais diretos, pois todas as informações estão concentradas no orquestrador.

**Desvantagens da Orquestração**:

**Acoplamento**: Os componentes devem se comunicar diretamente com o orquestrador, o que pode criar acoplamento entre o orquestrador e os componentes.  
**Menos flexibilidade**: Modificar a lógica de coordenação pode ser mais complicado, pois qualquer mudança requer alterações no orquestrador central.

**Diagrama de Sequência para Orquestração:**

![](https://33333.cdn.cke-cs.com/kSW7V9NHUXugvhoQeFaf/images/618621ebce3f6f2e893f059df15bfcc185ccbee3e1354549.png)

A escolha entre **coreografia** e **orquestração** depende das necessidades e complexidade do sistema. A **coreografia** é frequentemente preferida em sistemas altamente distribuídos e desacoplados, enquanto a **orquestração** é mais adequada para casos em que a coordenação centralizada e o acompanhamento são mais importantes.

### Para esse exemplo vamos utilizar os seguinte frameworkes:

*   Rebus
*   Rebus.ServiceProvider
*   Rebus.RabbitMq
*   Rebus.Postgres

Aqui está como o Rebus pode ser usado no contexto do padrão Saga:

1.  **Envio de Mensagens**: O Rebus facilita o envio de mensagens assíncronas entre componentes distribuídos do sistema. Cada etapa da saga pode ser representada como uma mensagem, e o Rebus permite que você envie essas mensagens de forma confiável para os destinatários apropriados.
2.  **Processamento de Mensagens**: O Rebus fornece um mecanismo para processar as mensagens recebidas. Você pode configurar manipuladores de mensagens que serão acionados sempre que uma mensagem específica for recebida. Isso é útil para executar as operações associadas a cada etapa da saga.
3.  **Coordenação da Saga**: Você pode usar o Rebus para coordenar a lógica de coordenação da saga, como determinar quando avançar para a próxima etapa ou quando iniciar uma operação de compensação. O Rebus permite que você escreva código para tomar decisões com base no progresso da saga.
4.  **Resiliência e Confirmação**: O Rebus pode ser configurado para lidar com casos de falha e garantir que as mensagens sejam processadas de forma confiável. Isso é crucial no contexto do padrão Saga, onde a recuperação de falhas e a reversão de etapas são parte fundamental da implementação.
5.  **Rastreamento de Progresso**: O Rebus também pode ser usado para registrar e rastrear o progresso das mensagens dentro da saga, ajudando na tomada de decisões informadas sobre como proceder.

Para mais informações sobre Rebus consulte o [git](https://github.com/rebus-org/Rebus).
