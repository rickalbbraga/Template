# Introdução

Este projeto tem por finalidade ser o template customizado de um projeto WebApi para a construção de nossas APIs. 

# Paradígmas Utilizados

Para a construção deste template, foi utilizado os seguintes padrões e pensamentos:

### CQS (Command Query Separation):

https://www.dotnetcurry.com/patterns-practices/1461/command-query-separation-cqs

### Domain Notification:

https://martinfowler.com/eaaDev/Notification.html

https://balta.io/blog/exception-vs-domain-notification

### Arquitetura Limpa:

https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html

### Domain Driven Design (Modelagem Tática)

https://www.eduardopires.net.br/2016/08/ddd-nao-e-arquitetura-em-camadas/

# Estrutura do Projeto

O projeto foi estruturado conforme imagem abaixo:

![Estrutura Projeto](docs/images/estrutura-projeto.png)

### As Camadas:

__API:__ 

É a camada de entrada em nossas APIs. É nela que estarão os endpoints para serem consumidos.
Esta camada é aquilo que no DDD é chamado de "Presentation" e no Clean Architecture de "Inteface Adapters". Esta camada pode ser qualquer coisa de aplicação (GRPC, MVC, Angular, SOAP, Mobile).

# Observações

Após baixar o template e definir o nome do projeto, devemos alterar alguns lugares do template para o nome que definimos do projeto. Segue os lugares que devemos alterar:

__AppSetting (Development, Homolog e Production) Elastic Configuration:__

![](docs/images/elastic-configuration.png)

__Alterar Nome SLN:__

![](docs/images/solution.png)

__Alterar Nome no Swagger:__

![](docs/images/swagger.png)




