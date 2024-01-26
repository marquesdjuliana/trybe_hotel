**olá, olá!** Bem-vinda(o) ao repositório do projeto **Trybe Hotel**. 

Este projeto foi desenvolvido como parte do curso de Desenvolvimento C# da Trybe. 

## Sobre o Projeto

Neste projeto, desenvolvi uma aplicação ASP.NET Core responsável por gerenciar reservas de hotéis e interagir com uma API externa para obter informações geográficas.

## Funcionalidades Implementadas

1. Models e Banco de Dados:

Desenvolvi as models da aplicação de acordo com o Diagrama de Entidade-Relacionamento fornecido.
Utilizei migrations para criar o banco de dados SQL Server.

2. Endpoints para Cidades:

Criei endpoints para listar e cadastrar cidades (GET /city e POST /city).
Implementei o modelo RESTful para interação com as cidades.

3. Endpoints para Hotéis:

Desenvolvi endpoints para listar e cadastrar hotéis (GET /hotel e POST /hotel).
Garanti a relação entre cidades e hotéis, conforme o DER.

4. Endpoints para Quartos:

Criei endpoints para listar, cadastrar e deletar quartos (GET /room/:hotelId, POST /room e DELETE /room/:roomId).
Mantive a consistência nas relações entre hotéis e quartos.

5. Endpoints para Usuários:

Implementei endpoints para cadastrar usuários e realizar login (POST /user e POST /login).
Adicionei autorização de administrador nos endpoints de cadastro de hotéis e quartos.

6. Endpoints para Reservas:

Desenvolvi endpoints para cadastrar e listar reservas (POST /booking e GET /booking).
Adicionei autorização para garantir que apenas usuários autenticados possam fazer reservas.

7. Atributo "State" na Model "City":

Adicionei o atributo "State" à model "City" para representar o estado da cidade.
Realizei a refatoração necessária no banco de dados utilizando migrations.

8. Endpoint para Status da API Externa de Geolocalização:

Implementei o endpoint GET /geo/status para conferir o status da API externa de geolocalização.
Realizei requisições externas à API e retornei um objeto JSON conforme especificado.



## Habilidades Aplicadas

Durante a realização deste projeto, algumas habilidades foram exercitadas:

- Manipulação de arrays multidimensionais para armazenamento temporário de dados.
- Implementação de funções com validações e tratamento de exceções para garantir a integridade das operações financeiras.
- Separação de responsabilidades e construção de funcionalidades em ordem para facilitar a evolução do sistema.

## Instalação e Execução
Se deseja experimentar o projeto em sua máquina local, siga estas etapas:

1. Clone o repositório:
```sh
git clone git@github.com:marquesdjuliana/trybe_hotel.git
```
2. Entre na pasta do repositório e instale as dependências:
Entre na pasta:
```sh
cd src/ 
```
3. Execute o comando:
```sh
dotnet restore 
```

##  Banco de Dados:


1. Utilize o Docker Compose fornecido para subir um banco de dados SQL Server localmente.:
```sh
docker-compose up -d --build
```




Sinta-se à vontade para explorar este projeto, acompanhar meu crescimento e contribuir, se desejar. Se você tiver alguma sugestão, feedback ou quiser trocar conhecimentos, será um prazer conectar com você no LinkedIn!


## :construction: README em construção ! :construction: