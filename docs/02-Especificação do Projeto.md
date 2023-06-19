# Especificações do Projeto

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto

## Arquitetura e Tecnologias

Através do solicitado/escopo, temos de comum acordo realizar a aplicação *WEB* (responsiva) através das tecnologias abaixo:

- HTML
- CSS
- C#
- API

## Project Model Canvas

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/blob/5fa46b192cf161a0ac094f23cedddac5160de9ac/docs/img/Project%20model%20canvas%20-%20Padaria.jpg)


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir cadastro de clientes   | MÉDIA |
|RF-002| Permitir avaliações/feedbacks   | MÉDIA |
|RF-003| Permitir envio de e-mails   | MÉDIA |
|RF-004| Permitir acesso a avaliações/*feedbacks* | MÉDIA |
|RF-005| Permitir classificar *feedbacks* | MÉDIA |
|RF-006| Permitir encontrar dados necessários de contato dos clientes  | MÉDIA |
|RF-007| Permitir registro de reclamações | MÉDIA |
|RF-008| Permitir emitir relatórios das avalições/*feedbacks* | MÉDIA |
|RF-009| Permitir acesso exclusivo à área de administrador | MÉDIA |

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve ser responsivo para rodar em um dispositivos móvel | MÉDIA |
|RNF-002| Deve processar requisições do usuário em no máximo 3s |  BAIXA |
|RNF-003| Deve ser compatível com Google Chrome e Microsoft Edge   | MÉDIA |
|NRF-004| Deve ter fácil acesso via *QR Code* | MÉDIA |



## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

| ID   | Restrição                                                    |
| ---- | ------------------------------------------------------------ |
| 01   | O projeto deverá ser entregue até o final do 1º/2023         |
| 02   | Não pode ser desenvolvido um módulo de *backend*             |
| 03   | O projeto deverá ter seu código versionado utilizando GitHub |


## Diagrama de Casos de Uso

O diagrama de casos de uso é o próximo passo após a elicitação de requisitos, que utiliza um modelo gráfico e uma tabela com as descrições sucintas dos casos de uso e dos atores. Ele contempla a fronteira do sistema e o detalhamento dos requisitos funcionais com a indicação dos atores, casos de uso e seus relacionamentos. 

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/blob/86bebc4a75099e42cb07575f44c88ab71cf3cfda/docs/img/Diagrama%20de%20caso%20de%20uso%20-%20novo.png)

## Modelo ER (Projeto Conceitual)

Modelo ER representando o escopo inicial do projeto

![image](https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/blob/b31970ee2f2c1cb0f8ee724aeeb415dfebc6fa59/docs/img/Modelo%20entidade%20relacionamento%20-%20novo.png)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.

