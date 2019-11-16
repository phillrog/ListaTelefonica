# Projeto - Lista Telefônica

# IMPORTANTE
### Docker
Necessita do docker para rodar. Pois o banco de dados é um container postgres e o container do pgadmin acessa ele no seguinte endereço:

### Migrations
É necessário setar a api como projeto principal e executar o seguinte comando no console do Package-Manager do VS:

```
Update-Database
```

Sem isso o banco não é criado e a aplicação também não funcionara.


# Objetivo
Criar um simples crud de cadastro de telefone.

```
http://localhost:16543/
```

# Conceitos
Esta aplicação utliza conceitos básico de DDD e CQRS.

# Boas práticas
Foi implementado o padrão **Notification** para retornar mensagens de notificação de erro, um pouco de **SOLID** para garantir qualidade de progração. **Migrations** para uma base consistente. **Mediatr** para pipeline de comandos. E por último mas não menos importante **FLuentValidation** para agilizar o processo de validação na api.

# Docker
Foi dockerizado a API. 
Acesse a raiz da solution e execute o comando para subir os containers da aplicação:

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

- **User ID**=admin
- **Password**=admin 
- **Server**=postgres
- **Port**=5432
- **Database**=lista-telefonica
- **Url** = http://localhost:16543/

### Swagger Api
http://localhost:5005/

### Angular
http://localhost:4200/ 

# Resultado

- ![Principal](https://github.com/phillrog/lista-telefonica/blob/master/img/principal.png)

- ![Principal](https://github.com/phillrog/lista-telefonica/blob/master/img/cadastro.png)

- ![Principal](https://github.com/phillrog/lista-telefonica/blob/master/img/editar.png)

# TODO

- [ ] Log
- [ ] Dockerizar o portal

