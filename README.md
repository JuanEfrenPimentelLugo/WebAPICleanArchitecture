# WebAPICleanArchitecture
Web API con Net 8 basado en Clean Arcquitecture

El proyecto esta configurado para poder ejecutarlo desde visual studio con docker compose usando el profile enterprice.solution.services.webapi y carga la base de datos con postgreSQL 16 

Generate a new secret:

node -e "console.log(require('crypto').randomBytes(32).toString('hex'))"
