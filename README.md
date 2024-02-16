# WebAPICleanArchitecture
Web API con Net 8 basado en Clean Arcquitecture

El proyecto esta configurado para poder ejecutarlo desde visual studio con docker compose usando el profile enterprice.solution.services.webapi y carga la base de datos con postgreSQL 16 

Se puede probar hacindo una peticion tipo post al endpoint Users/Authenticate por ejemplo:

https://localhost:59134/api/v1/Users/Authenticate 

Mandando un json al body, por ejemplo:

{
  "userId": 0,
  "firstName": "string",
  "lastName": "string",
  "userName": "juanpimentel",
  "password": "1234",
  "token": "string"
}

Generate a new secret:

node -e "console.log(require('crypto').randomBytes(32).toString('hex'))"
