# Projeto - Lista Telefônica

# Objetivo
Criar um crud de cadastro de telefone.

# IMPORTANTE
Necessita do docker para rodar. Pois o banco de dados é um container postgres e o container do pgadmin acessa ele no seguinte endereço:

```
http://localhost:16543/
```

# Conceitos
Esta aplicação utliza conceitos de DDD e CQRS.

# Boas práticas
Foi implementado o padrão Notification para retornar mensagens de notificação de erro e SOLID.

# Docker
Foi dockerizado a API. 
Acesse a raiz da solution e execute o comando:

```
docker-compose up --build -d
```

# Angular 
Acesse a pasta ListaTelefonica.Presentations\angular e execute o seguinte comando:

```
ng serve
```

# PgAdmin
Dados de acesso:

- *User ID*=admin
- *Password*=admin 
- *Server*=postgres
- *Port*=5432
- *Database*=lista-telefonica
- *Url* = http://localhost:16543/

### Swagger Api
http://localhost:5005/

### Angular
http://localhost:4200/ 

# TODO
- [ ] Testes
- [ ] Remover telefones sem remover a pessoa
- [ ] Log
- [ ] Dockerizar o portal

