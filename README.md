# MJV-MARKETPLACE-API

## Instalação

### Requisitos

Tudo que será necessário para executar este projeto é o docker instalado em sua maquina, ou visual-studio(com modulo para aspnet.core webapi) + mysql

Para instalar o [docker no windows](https://docs.docker.com/v17.12/docker-for-windows/install/#install-docker-for-windows-desktop-app). Ou no linux, debian [docker no linux](https://docs.docker.com/v17.12/install/linux/docker-ce/debian/).

## Como instalar

### Docker

Com o docker, execute os seguintes comandos na raiz do projeto:


### Executar através do visual studio

Abra o visual studio...

## Oque foi feito

Dentre oque foi proposto, oque está marcado com OK, foi feito:

- `Atividade 1` -OK
- `Atividade 2`
- `Atividade 3` -OK
- `Atividade 4`

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

Onde o conteúdo de `acessToken` será a chave necessária para autenticar as outras requisições
