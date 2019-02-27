<h1 align="center">MJV MARKETPLACE REST API</h1>
<div align="center">
  <strong>processo seletivo</strong>
</div>
 
## Instalação

### Requisitos

Tudo que será necessário para executar este projeto é o docker instalado em sua maquina, ou visual-studio(com modulo para aspnet.core webapi) + mysql

Para instalar o [docker no windows](https://docs.docker.com/v17.12/docker-for-windows/install/#install-docker-for-windows-desktop-app). Ou no linux, debian [docker no linux](https://docs.docker.com/v17.12/install/linux/docker-ce/debian/).

## Como instalar

### Docker

Com o docker, execute os seguintes comandos na raiz do projeto **Marketplace-API-Docker**:
- Abra o terminal na raiz do projeto, e execute o seguinte comando : `docker-compose up -d --build`
- O banco de dados deve ter sido criado automaticamente no conteiner criado, conecte-se ao mesmo utilizando um sgbd de sua preferencia e execute o script **INSERIR LINK PARA SCRIPT AQUI** que irá criar as tabelas e cadastrar alguns dados.
- Executando o seguinte comando, `docker ps -a`, deverá ver a seguinte saída:

```
CONTAINER ID        IMAGE                    COMMAND                  CREATED             STATUS              PORTS                    NAMES
b3e40287500e        jeltor/marketplace-api   "dotnet MarketplaceA…"   6 seconds ago       Up 4 seconds        0.0.0.0:5000->80/tcp     marketplace-api_marketplaceapi_1
3d9f994a8989        jeltor/mvj-mysql         "docker-entrypoint.s…"   8 seconds ago       Up 5 seconds        0.0.0.0:3306->3306/tcp   marketplace-api_db_1
```

- Onde na porta localhost:5000 estará rodando a aplicação e em localhost:3306 o banco de dados. Ao ir a tela inicial da aplicação, verá o swagger em execução, onde terá uma documentação básica dos end-points, podendo utilizar os exemplos fornecidos pelo mesmo para teste utilizando o postman. **ABAIXO MAIS DETALHES SOBRE COMO EXECUTAR OS PRIMEIROS TESTES COM A APLICAÇÃO**.

### Executar através do visual studio

- No visual studio vá até carregar nova solução, e execute a da pasta **Marketplace-API-Clean**. E através da `ide` ao clickar em iniciar com `IISExpress` a api estará rodando em `http://localhost:3000/swagger/index.html` .

- Também será necessário criar a base de dados, certifique-se de estar rodando um servidor mysql em sua máquina, e execute o seguinte script no `terminal mysql` ou em um `sgbd` : **INSERIR LINK PARA SCRIPT SQL AQUI**.

- Como as configurações do mysql podem variar de maquina para maquina, será necessário de configurar a URL de conexão. Para isso, vá até a raiz do projeto, entre na pasta `Marketplace-API`, e então localize o arquivo `appsettings.json`, lá você encontrará o seguinte trecho:

```
 "MySqlConnection": {
    "MySqlConnectionString": "Server=localhost;DataBase=mjv_marketplace;Uid=root;Pwd=root"
  },
```
Configure o Uid com o login de seu usuário mysql, e Pwd com a senha, e caso necessário, mude Server com a url em que está rodando seu servidor mysql. Como o banco de dados será criado com a execução do script, não será necessário alterar seu nome. Com isso o projeto irá rodar normalmente, e ficará apto para testes.

## Oque foi feito

Dentre oque foi proposto, oque está marcado com OK, foi feito:

- `Gerenciamento de lojas` -OK
- `Gerenciamento de produtos` -OK
- `Pesquisa a partir de uma palavra` -OK

Detalhes:

- `Avaliação 5 estrelas da loja no resultado da pesquisa` -
- `Exibir produtos relacionados` -OK

Bom ter:

- `Testes automatizados / unitários` -
- `Autenticação a aplicação / JWT` -OK
- `Annotations` -OK
- `Design Pattern` -OK
- `Live Demo` -IN PROGRESS

## Explicação de alguns end-points:
```
curl -X GET "http://servidor:porta/api/v1/products/Search/ProductName/Geladeira" -H "accept: application/json"
```
ou
```
http://servidor:porta/api/v1/products/Search/ProductName/Geladeira
```
- Este end-point, atende a funcionalidade de pesquisa, onde, a mesma espera por 2 parametros, sendo o primeiro o `Attribute`, no exemplo acima foi utilizado o ProductName, porém pode-se usar: Description, Category, Price, Quantity, store_id (id da loja), e o `term` onde é inserido a palavra chave para qualquer um dos attributes acima, no exemplo foi utilizado geladeira. Está consulta poderá trazer duas coleções de dados, sendo a primeira a coleção de produtos encontrados pelo termo pesquisado (pode ser mais de um, dependendo do resultado do like), e também produtos relacionados (Onde é feito o match pela categoria, do primeiro produto da coleção 1). Como no exemplo:
```
{
    "produtos": [
        {
            "Código": 1,
            "Nome do Produto": "GTX 1080 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "gtx1080.com/imagem",
            "Preço": 1000,
            "Quantidade em estoque": 100,
            "Loja": "Pichau informatica"
        }
    ],
    "produtos_Relacionados": [
        {
            "Código": 1,
            "Nome do Produto": "GTX 1050 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "gtx1080.com/imagem",
            "Preço": 1000,
            "Quantidade em estoque": 100,
            "Loja": "Pichau informatica"
        }
    ]
}
```
*Resultado meramente ilustrativo*

Já o gerenciamento de lojas e produtos, são os end-points comuns dos principais verbos http, para ambos possui-se get, getbyId, getByTerm (endpoint mencionado acima [Funciona também para loja, porém sem o relacionados]), post, put e delete. Como por exemplo:

- Get products
```
curl -X GET "http://servidor:porta/api/v1/products" -H "accept: application/json"

http://porta:servidor/api/v1/products
```


- Post products
```
curl -X POST "http://servidor:porta/api/v1/products" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{ \"Código\": 0, \"Nome do Produto\": \"string\", \" Descrição\": \"string\", \"Categoria\": \"string\", \"Imagem\": \"string\", \"Preço\": 0, \"Quantidade em estoque\": 0, \"Loja\": \"string\"}"

http://servidor:porta/api/v1/products
Body:
{
  "Código": 0,
  "Nome do Produto": "string",
  " Descrição": "string",
  "Categoria": "string",
  "Imagem": "string",
  "Preço": 0,
  "Quantidade em estoque": 0,
  "Loja": "string"
}

```

Todas as rotas e exemplos são exibidas no swagger.

## Guia básico para como testar

Antes de realizar qualquer requisição com o servidor, será necessário efetuar o login para receber o token de autenticação, para isso, realize um post para a rota `https://servidor:porta/api/v1/login` com o seguinte body em `raw / type JSON(application/json)` :

```
{
  "id": 0,
  "login": "admin",
  "accessKey": "123"
}
```

E terá uma resposta parecida com isto: 

```
{
  {
    "authenticated": true,
    "created": "2019-02-26 22:02:12",
    "expiration": "2019-02-26 22:22:12",
     "acessToken": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6WyJhZG1pbiIsImFkbWluIl0sImp0aSI6IjY3NWE5YWZiZTI5NTRlYTE4NTQ3ODEwOTVlNDMxZjgyIiwibmJmIjoxNTUxMjI5MzMyLCJleHAiOjE1NTEyMzA1MzIsImlhdCI6MTU1MTIyOTMzMiwiaXNzIjoiRXhlbXBsZUlzc3VlciIsImF1ZCI6IkV4ZW1wbGVBdWRpZW5jZSJ9.rgkm8LSfiTq6A9pKmYMxLWE8LkM0c6cZjCLu1awgUl3Hp7JVJl5fV2bH3yaaT4KN21r0q8b80xbU3-2w2IIJEfMNZaY0R3cIA2xFFcK8voJv3qDaEfsY239L6RsG4EnTHmpVnDy85vxc4oSr5teUc2vUtmWG28CvUIXhnSTkBMPrPZEOqsgKydfy1ltCZHpRf2ls43RsUaQkGWyGS2U7pAhP3nluoQGmqiz5ppZZMm4xc1V69sjPJ4F2rBbghaMVRxxkcG8g4AvmbVJugvvru81Bhs5sF1eZ5sjVIRuCGD3F_cO_iQtrJmbc-sT6_5LIZLjdzwZl8pQw3YBv7AO9jA",
    "message": "OK"
}
}
```

- Onde o conteúdo de `acessToken` será a chave necessária para autenticar as outras requisições. No postman, este `acessToken` deverá ser utilizado da seguinte forma :

**Imagem aqui de como inserir o Bearer token no header da requisição**
