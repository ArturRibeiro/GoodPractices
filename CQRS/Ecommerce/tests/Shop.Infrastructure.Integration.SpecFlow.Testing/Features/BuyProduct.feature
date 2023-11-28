Feature: Compra de Produto

#    Scenario: usuário comprando alguns produtos
#        Given existe alguns produtos com nome e preço
#        And o usuário tem um carrinho de compras vazio
#        When o usuário adiciona alguns produtos ao carrinho
#        And o usuário realiza o checkout
#        Then a ordem do usuário deve conter os mesmos Produtos e a mesma quantidade selecionadas
#        And o estoque do produto deve ser reduzido de acordo com a quantidade selecionada pelo usuário

    Scenario: Usuário realiza uma compra bem-sucedida
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        Then a ordem do usuário deve conter os mesmos Produtos e a mesma quantidade selecionadas
        And o status da ordem deve ser "Pending"
        And o estoque do produto deve ser reduzido de acordo com a quantidade selecionada pelo usuário

    Scenario: Usuário realiza um pagamento pendente
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        And o status da ordem é alterado para "AwaitingPayment"
        Then o status da ordem deve ser "AwaitingPayment"

    Scenario: Usuário realiza o pagamento e aguarda envio
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        And o usuário realiza o pagamento
        And o status da ordem é alterado para "AwaitingShipment"
        Then o status da ordem deve ser "AwaitingShipment"

    Scenario: Usuário recebe o envio
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        And o usuário realiza o pagamento
        And o status da ordem é alterado para "Shipped"
        Then o status da ordem deve ser "Shipped"

    Scenario: Usuário cancela o pedido
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        And o usuário realiza o pagamento
        And o usuário cancela o pedido
        Then o status da ordem deve ser "Cancelled"
        And o estoque do produto deve ser aumentado em 2 unidades

    Scenario: Usuário marca o pedido como concluído
        Given existe alguns produtos com nome e preço
        And o usuário tem um carrinho de compras vazio
        When o usuário adiciona alguns produtos ao carrinho
        And o usuário realiza o checkout
        And o usuário realiza o pagamento
        And o pedido é enviado
        And o usuário marca o pedido como concluído
        Then o status da ordem deve ser "Completed"