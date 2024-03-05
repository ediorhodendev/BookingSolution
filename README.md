#Sistema de Reserva de Veículos
Este é um sistema de reserva de veículos com uma API RESTful, desenvolvido para listar, adicionar, atualizar e excluir reservas de veículos.

#Funcionalidades
Listar todos os registros de reserva de veículos
Listar um registro de reserva de veículo por ID
Adicionar uma nova reserva de veículo
Atualizar uma reserva de veículo existente
Excluir uma reserva de veículo existente
Estrutura do Projeto
O projeto está organizado em camadas para uma arquitetura mais modular:

API: Camada responsável pela exposição dos endpoints HTTP e pela comunicação com os clientes.
Application: Camada responsável pela lógica de negócios da aplicação, incluindo a manipulação dos dados recebidos pela API.
Domain: Camada responsável pela definição das entidades de domínio da aplicação.
Infrastructure: Camada responsável pela implementação dos detalhes técnicos, como acesso ao banco de dados e persistência.
Tests: Camada de testes unitários para garantir o correto funcionamento da aplicação.
#Tecnologias Utilizadas
.NET Core 3.1
Entity Framework Core (Banco de Dados em Memória)
xUnit (para testes unitários)
Swagger (para documentação da API)
#Instruções de Uso
Clone o repositório para o seu ambiente local.
Execute a aplicação utilizando o Visual Studio ou o comando dotnet run.
Acesse a documentação da API através do Swagger UI, normalmente disponível em http://localhost:{porta}/swagger.
Utilize os endpoints disponíveis para interagir com a API conforme necessário.
Instruções de Testes
Execute os testes unitários disponíveis na camada de testes utilizando o xUnit.
Observações
Ao iniciar a aplicação, 10 registros de reserva de veículos são criados automaticamente para fins de teste.
Certifique-se de ajustar o ambiente de execução (como porta do servidor) conforme necessário no arquivo de configuração.
Este sistema oferece uma solução básica para a gestão de reservas de veículos e pode ser estendido e personalizado conforme as necessidades específicas do projeto.
