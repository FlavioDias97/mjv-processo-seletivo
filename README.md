<h1 align="center">MJV MARKETPLACE REST API</h1>
<div align="center">
  <strong>processo seletivo</strong>
</div>
 
## Instalação

### Requisitos

Tudo que será necessário para executar este projeto é o docker instalado em sua máquina, ou visual-studio(com modulo para aspnet.core webapi) + mysql

Para instalar o [docker no windows](https://docs.docker.com/v17.12/docker-for-windows/install/#install-docker-for-windows-desktop-app). Ou no linux, debian [docker no linux](https://docs.docker.com/v17.12/install/linux/docker-ce/debian/).

## Como instalar

### Docker

Com o docker, execute os seguintes comandos na raiz do projeto **Marketplace-API-Docker**:[Aqui](https://github.com/FlavioDias97/mjv-processo-seletivo/tree/master/Marketplace-API-Docker).
- Abra o terminal na raiz do projeto, e execute o seguinte comando : `docker-compose up -d --build`
- O banco de dados deve ter sido criado automaticamente no container criado, conecte-se ao mesmo utilizando um sgbd de sua preferência e execute o script [DATABASE CREATE SCRIPT](https://github.com/FlavioDias97/mjv-processo-seletivo/blob/master/Contents/Banco%20de%20dados/Backup.sql). que irá criar as tabelas e cadastrar alguns dados.
- Executando o seguinte comando, `docker ps -a`, deverá ver a seguinte saída:

```
CONTAINER ID        IMAGE                    COMMAND                  CREATED             STATUS              PORTS                    NAMES
b3e40287500e        jeltor/marketplace-api   "dotnet MarketplaceA…"   6 seconds ago       Up 4 seconds        0.0.0.0:5000->80/tcp     marketplace-api_marketplaceapi_1
3d9f994a8989        jeltor/mvj-mysql         "docker-entrypoint.s…"   8 seconds ago       Up 5 seconds        0.0.0.0:3306->3306/tcp   marketplace-api_db_1
```

- Onde na porta localhost:5000 estará rodando a aplicação e em localhost:3306 o banco de dados. Ao ir na tela inicial da aplicação, verá o swagger em execução, onde terá uma documentação básica dos end-points, podendo utilizar os exemplos fornecidos pelo mesmo para teste utilizando o postman. **ABAIXO MAIS DETALHES SOBRE COMO EXECUTAR OS PRIMEIROS TESTES COM A APLICAÇÃO**.

<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/docker-compose1.png">
</p>

<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/docker-compose%20final.png">
</p>

<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/docker-ps-a.png">
</p>

### Executar através do visual studio

- No visual studio vá até carregar nova solução, e execute a da pasta **Marketplace-API-Clean**:[Aqui](https://github.com/FlavioDias97/mjv-processo-seletivo/tree/master/Marketplace-API%20-Clean).
E através da `ide` ao clicar em iniciar com `IISExpress` a api estará rodando em `http://localhost:3000/swagger/index.html` .

- Também será necessário criar a base de dados, certifique-se de estar rodando um servidor mysql em sua máquina, e execute o seguinte script no `terminal mysql` ou em um `sgbd` : [DATABASE CREATE SCRIPT](https://github.com/FlavioDias97/mjv-processo-seletivo/blob/master/Contents/Banco%20de%20dados/Backup.sql)..

- Como as configurações do mysql podem variar de máquina para máquina, será necessário configurar a URL de conexão. Para isso, vá até a raiz do projeto, entre na pasta `Marketplace-API`, e então localize o arquivo `appsettings.json`, lá você encontrará o seguinte trecho:

```
 "MySqlConnection": {
    "MySqlConnectionString": "Server=localhost;DataBase=mjv_marketplace;Uid=root;Pwd=root"
  },
```
Configure o Uid com o login de seu usuário mysql, e Pwd com a senha, e caso necessário, mude o Server com a url em que está rodando seu servidor mysql. Como o banco de dados será criado com a execução do script, não será necessário alterar seu nome. Com isso o projeto irá rodar normalmente, e ficará apto para testes.

## O que foi feito

Dentre o que foi proposto, o que está marcado com OK, foi feito:

- `Gerenciamento de lojas` -OK
- `Gerenciamento de produtos` -OK
- `Pesquisa a partir de uma palavra` -OK

Detalhes:

- `Avaliação 5 estrelas da loja no resultado da pesquisa` - ? Este ponto não ficou claro.
- `Exibir produtos relacionados` -OK

Bom ter:

- `Testes automatizados / unitários` -
- `Autenticação a aplicação / JWT` -OK
- `Annotations` -OK
- `Design Pattern` -OK
- `Live Demo` - 

## Explicação de alguns end-points:
```
curl -X GET "http://servidor:porta/api/v1/products/Search/ProductName/Geladeira" -H "accept: application/json"
```
ou
```
http://servidor:porta/api/v1/products/Search/ProductName/Geladeira
```
- Este end-point, atende a funcionalidade de pesquisa, onde, a mesma espera por 2 parâmetros, sendo o primeiro o `Attribute`, no exemplo acima foi utilizado o ProductName, porém pode-se usar: Description, Category, Price, Quantity, store_id (id da loja), e o `term` onde é inserido a palavra chave para qualquer um dos attributes acima, no exemplo foi utilizado geladeira. Esta consulta poderá trazer duas coleções de dados, sendo a primeira a coleção de produtos encontrados pelo termo pesquisado (pode ser mais de um, dependendo do resultado do like), e também produtos relacionados (Onde é feito o match pela categoria, do primeiro produto da coleção 1). Como no exemplo:
```
{
    "produtos": [
        {
            "Código": 1,
            "Nome do Produto": "GTX 1080 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "https://www.evga.com/articles/01092/images/header/ultimate.png",
            "Preço": 3000,
            "Quantidade em estoque": 100,
            "Loja": "Pichau Informática"
        },
        {
            "Código": 2,
            "Nome do Produto": "RTX 2080 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "https://bit.ly/2BQOQaA",
            "Preço": 5000,
            "Quantidade em estoque": 20,
            "Loja": "Pichau Informática"
        }
    ],
    "produtos_Relacionados": [
        {
            "Código": 1,
            "Nome do Produto": "GTX 1080 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "https://www.evga.com/articles/01092/images/header/ultimate.png",
            "Preço": 3000,
            "Quantidade em estoque": 100,
            "Loja": "Pichau Informática"
        },
        {
            "Código": 2,
            "Nome do Produto": "RTX 2080 TI",
            " Descrição": "Placa de video",
            "Categoria": "Hardware",
            "Imagem": "https://bit.ly/2BQOQaA",
            "Preço": 5000,
            "Quantidade em estoque": 20,
            "Loja": "Pichau Informática"
        },
        {
            "Código": 3,
            "Nome do Produto": "GTX 1050 2GB",
            " Descrição": "Placa de video low end",
            "Categoria": "Hardware",
            "Imagem": "https://bit.ly/2tFjMq0",
            "Preço": 460,
            "Quantidade em estoque": 500,
            "Loja": "1"
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

Todas as rotas e exemplos são exibidas no swagger:


<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/swagger.png?token=AYq4whmP-P-wR90MkJCm9JDQ61lNFi3wks5cdjHtwA%3D%3D">
</p>

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

<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/imagem1token.png?token=AYq4wlIfKPTAyRiolOAzUXKIa1Y3JcSZks5cdjGSwA%3D%3D">
</p>

<p align="center">
  <img alt="sergey" src="https://raw.githubusercontent.com/FlavioDias97/mjv-processo-seletivo/master/Contents/Imagens/imagem2token.png?token=AYq4wuA6awN2Lfk_DkuzfARcHboRvf9sks5cdjHRwA%3D%3D">
</p>


### Tecnologias utilizadas

<p align="center">
  <img alt="sergey" src="https://i.imgur.com/zrttCqA.jpg">
</p>
