### Proposito do pattern Adapter

O padrão de design Adapter é um padrão estrutural que permite que objetos com interfaces incompatíveis trabalhem juntos. Ele atua como uma ponte entre duas interfaces diferentes, permitindo que um objeto seja usado como se fosse outro. Isso é útil quando você tem duas classes ou componentes que desejam se comunicar, mas não podem diretamente devido a suas interfaces incompatíveis.

A finalidade principal do padrão Adapter é adaptar a interface de uma classe (ou objeto) para que ela seja compatível com a interface esperada pelo cliente sem modificar o código fonte da classe adaptada.

Aqui estão os principais componentes envolvidos no padrão Adapter:

1.  **Cliente**: É o código que deseja interagir com o objeto adaptado. O cliente espera uma interface específica que o objeto adaptado não fornece diretamente.
2.  **Alvo (Target)**: É a interface que o cliente espera. O cliente interage com o alvo, mas o objeto adaptado não a implementa diretamente.
3.  **Adaptador (Adapter)**: É a classe que atua como uma ponte entre o cliente e o objeto adaptado. Ele implementa a interface do alvo e mantém uma referência ao objeto adaptado. O adaptador traduz as chamadas do cliente para algo que o objeto adaptado possa entender e vice-versa.
4.  **Objeto Adaptado (Adaptee)**: É a classe ou objeto existente com uma interface incompatível que precisa ser adaptada para funcionar com o cliente.