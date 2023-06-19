# Planos de Testes de Software

Apresente os cenários de testes utilizados na realização dos testes da sua aplicação. Escolha cenários de testes que demonstrem os requisitos sendo satisfeitos.

Enumere quais cenários de testes foram selecionados para teste. Neste tópico o grupo deve detalhar quais funcionalidades avaliadas, o grupo de usuários que foi escolhido para participar do teste e as ferramentas utilizadas.

## CASOS DE TESTES: 

| **CASO DE TESTE**| **CT- 01 – LOGIN DE ACESSO EXCLUSIVO DO ADMINISTRADOR**|
|---|----|
|REQUISITOS ASSOCIADOS |RF-009: Permitir acesso exclusivo à área de administrador |
|OBJETIVO DO TESTE | Permitir apenas aos administrados/responsável da empresa acessar todas as avaliações/*feedbacks*, *dashboard*, contatos e e-mails. |
|PASSOS | 1) Acessar a página de *login* administrador <br/>2) Inserir os dados para *login* (e-mail e senha) <br/>3) Clicar em entrar. <br/> |
|CRITÉRIO DE ÊXITO| O *login* deve ser realizado com sucesso, apresentando uma mensagem na tela "*Login* realizado com successo", quando os dados inseridos estiverem os corretos. Para os casos dos dados incorretos, é preciso apresentar o erro de login com a seguinte frase "Usuário ou senha incorretos". |
|RESULTADOS OBTIDOS | As tentativas de login foram realizadas com sucesso, assim como as tentativas em que foram inseridas senha ou usuário incorretos. O registro dos testes estão nos *prints* em evidências de testes de *software* nº 1.|

| **CASO DE TESTE**| **CT- 02 – REALIZAR AVALIAÇÕES/*FEEDBACKS*** E PERMITIR REGISTRO RECLAMAÇÕES |
|---|----|
|REQUISITOS ASSOCIADOS |RF-002: Permitir avaliações/*feedback* <br/>RF-007: Permitir registro de reclamações|
|OBJETIVO DO TESTE | Verificar se o cliente consegue realizar as avaliações/*feedbacks* e registrar reclamações sem erros. |
|PASSOS | 1) Acessar a página de avaliações/*feedback* <br/> 2) Clicar em um número em escala de 0 a 10, para avaliar o atendimento <br/> 3) Clicar em qual tipo de avaliação deseja fazer, escolhendo entre elogio, sugestão, denúncia e reclamação. <br/> 4) Preencher as informações pessoais, caso desejar, e enviar a avaliação/*feedback*. |
|CRITÉRIO DE ÊXITO| Após realizar a avaliação/*feedback*, deve ser apresentado ao cliente a mensagem “Muito obrigado pelo seu *feedback*!” e a avaliação/*feedback* deve ser registrada em *feedbacks* e no *dashboard*. |
|RESULTADOS OBTIDOS | Todos os *feedbacks* foram registrados com sucesso. O registro do teste está no vídeo em Evidências de testes de *software* nº 2.|

| **CASO DE TESTE**| **CT- 03 – ACESSAR DADOS E ADICIONAR CLIENTE MANUALMENTE**|
|---|----|
|REQUISITOS ASSOCIADOS | RF-001: Permitir cadastro de clientes<br/>RF-006: Permitir encontrar dados necessários de contato dos clientes<br/>RF-009: Permitir acesso exclusivo à área de administrador |
|OBJETIVO DO TESTE | Acessar dados dos clientes cadastrados e adicionar novo cliente manualmente. |
|PASSOS | 1) Após realizar o *login* de administrador, o usuário deve ir até contatos para acessar os dados dos clientes já adicionados. <br/> 2) Para adicionar novo cliente, o usuário deve clicar em adicionar novo contato. <br/> 3) Preencher as informações dos cliente (nome, e-mail, telefone, redes sociais, observações) e marcar se o cliente é ativo ou não. <br/> 4) Clicar em Adicionar. Após isso, o usuário será redirecionado para a página de contatos. |
|CRITÉRIO DE ÊXITO| A lista de contato deve ser exibida na página de contatos, assim como o contato adicionado.|
|RESULTADOS OBTIDOS | O cliente teste foi adicionado com sucesso. O registro do teste está no vídeo em Evidências de testes de *software* nº 3.|

| **CASO DE TESTE**| **CT- 04 – EDITAR DADOS DE CLIENTE CADASTRADO MANUALMENTE**|
|---|----|
|REQUISITOS ASSOCIADOS |RF-001: Permitir cadastro de clientes<br/>RF-006: Permitir encontrar dados necessários de contato dos clientes<br/>RF-009: Permitir acesso exclusivo à área de administrador|
|OBJETIVO DO TESTE | Editar dados dos clientes cadastrados. |
|PASSOS | 1) Após realizar o *login* de administrador, o usuário deve ir até contatos para acessar os dados dos clientes. <br/> 2) Para editar os dados de um cliente, o usuário deve clicar em editar no contato da lista. <br/> 3) Editar as informações que deseja alterar. <br/> 4) Clicar em alterar. Após isso, o usuário será redirecionado para a página de contatos. |
|CRITÉRIO DE ÊXITO| As alterações devem ser salvas e aparecer na lista de contato.|
|RESULTADOS OBTIDOS | A alteração do cliente teste foi realizada com sucesso. O registro do teste está no vídeo em Evidências de testes de *software* nº 3.|

| **CASO DE TESTE**| **CT- 05 – EXCLUIR DADOS DE CLIENTE CADASTRADO MANUALMENTE**|
|---|----|
|REQUISITOS ASSOCIADOS | RF-006: Permitir encontrar dados necessários de contato dos clientes. |
|OBJETIVO DO TESTE | Excluir dados dos clientes cadastrados. |
|PASSOS | 1) Após realizar o *login* de administrador, o usuário deve ir até contatos para acessar os dados dos clientes. <br/> 2) Para excluir os dados de um cliente, o usuário deve clicar em excluir no contato da lista. <br/> 3) Clicar em confirmar exclusão. Caso não deseje excluir o contato, o usuário deve apenas cancelar a exclusão. <br/> |
|CRITÉRIO DE ÊXITO| As alterações devem ser salvas e aparecer na lista de contato.|
|RESULTADOS OBTIDOS | O contato teste 2 foi excluído com sucesso. O registro do teste está no vídeo em Evidências de testes de *software* nº 3.|

| **CASO DE TESTE**| **CT- 06 – ENVIO DE E-MAIL PARA CLIENTE**|
|---|----|
|REQUISITOS ASSOCIADOS | RF-003: Permitir envio de e-mails |
|OBJETIVO DO TESTE | Enviar e-mail para os clientes. |
|PASSOS | 1) Após realizar o *login* de administrador, o usuário deve ir até e-mail para acessar a página de envio de e-mails. <br/> 2) Preencher os dados para o envio do e-mail. <br/> 3) Clicar em enviar mensagem. <br/> |
|CRITÉRIO DE ÊXITO| E e-mail deve ser enviado com sucesso. |
|RESULTADOS OBTIDOS | O e-mail teste 1 foi excluído com sucesso. O registro do teste está no vídeo em Evidências de testes de *software* nº 4.|

| **CASO DE TESTE**     | CT- 07 – PESQUISAR AVALIAÇÕES/*FEEDBACKS* PELA CLASSIFICAÇÃO E EMITIR RELATÓRIO PDF |
| --------------------- | ------------------------------------------------------------ |
| REQUISITOS ASSOCIADOS | RF-009: Permitir acesso exclusivo à área de administrador <br/>RF-005: Permitir classificar *feedbacks*<br/>RF-008: Permitir emitir relatório das avaliações/*feedbacks* |
| OBJETIVO DO TESTE     | Pesquisar as avalições/*feedbacks* pela classificação e emitir relatório em formato PDF. |
| PASSOS                | 1) Após realizar o *login* de administrador, o usuário deve ir até Consultar Feedbacks para acessar todos os registros feitos pelos clientes. <br/> 2) Pesquisar e classificar pelos tipos de avaliações/*feedbacks* realizados pelos clientes. <br/> 3) Emitir relatório em formato PDF das avaliações/*feedbacks*. |
| CRITÉRIO DE ÊXITO     | Na aba Consultar Feedbacks deve ser possível acessar todos os registros feitos pelos clientes e ser possível filtrá-los de acordo com a classificação. Também, ser possível emitir relatório das avaliações/*feedbacks* em formato PDF. |
| RESULTADOS OBTIDOS    | Foi possível acessar todos os registros, filtrá-los e emitir o relatório em formato PDF. |



# Evidências de Testes de Software

Inicialmente foi proposto que, ao clicar em um dos botões de: Elogio, Denúncia, Reclamação ou Sugestão. Será aberto um formulário de cadastro de informações de clientes do estabelecimento. Resultado:

![Cadastro hiden](https://user-images.githubusercontent.com/83302547/232344924-7249ef4e-c1a6-4767-9c34-b1bc2d1bd165.PNG)

## Evidência nº: 01 - Login do Administrador

Tela de *login* do administrador criada e está funcional.

## Tela + tentativa com senha incorreta:

![Login Incorreto](https://user-images.githubusercontent.com/83302547/232344974-cc729e7f-d312-4dc7-bb68-1ce45223f794.PNG)

## Tela + tentativa com senha correta:

![Login correto](https://user-images.githubusercontent.com/83302547/232344994-341833d8-196f-45f4-b40f-3bff2ffcf9e4.PNG)

*Login* realizado com sucesso.

## Responsividade:

Veja que todas as telas estão responsivas para dispositivos móveis:

![Responsividade login](https://user-images.githubusercontent.com/83302547/232345022-6c6c1ea0-2cde-4290-a7cd-600150957c99.PNG)

![responsividade](https://user-images.githubusercontent.com/83302547/232345028-46e446c8-b871-4872-bccd-9306e667ac6f.PNG)


## Evidência nº: 02 - Feedback + Dashboard:

No vídeo abaixo, foram feitos os testes de feedback. Foi realizado o *login* do administrador e visualizado o *dashboard* com filtro para o dia 14/05/2023, que tinha os seguintes dados:
- Elogios: 5
- Sugestões: 2
- Reclamações: 2 
- Denúncias: 3
- Média: 5,21

Após a conferencia das informações no *dashboard*, retornamos a pagina *Home* e iniciamos os *feedbacks*. Foram realizados 4 *feedbacks*, das seguintes formas:
- 1º *feedback*: denúncia - nota: 0,00. Dados preenchidos, enviado e o *feedback* foi salvo com sucesso.
- 2º *feedback*: elogio - nota: 10,00. Dados preenchidos, enviado e o *feedback* foi salvo com sucesso.
- 3º *feedback*: denúncia - nota: 00,00. Apenas os dados de Nome, telefone e e-mail. Por não preencher o campo "Conte sua experiência" o retorno foi "Favor preencher todos os campos corretamente", conforme o esperado. Após o preenchimento o *feedback* foi salvo com sucesso.
- 4º *feedback*: sugestão - nota: 5,00. Dados preenchidos, enviado e o *feedback* foi salvo com sucesso.

Após os testes, houve o retorno a página de *Dashboard* e os dados apresentados no filtro para o dia 14/05/2023, foram:
- Elogios: 6
- Sugestões: 3
- Reclamações: 3 
- Denúncias: 4
- Média: 5,00

Assim, todos os dados foram registrados com sucesso.

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/assets/59442859/7125db9f-102d-4b08-bed8-81f4001ff59e

## Evidência nº: 03 - CRUD dados dos clientes:

No vídeo abaixo é registrado o processo de criar, editar e excluir os contatos do sistema.

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/assets/59442859/2f4bdaff-5a66-4ac9-8e93-40d3a0c41678

## Evidência nº: 04 - Envio de e-mail para os clientes:

No vídeo abaixo é registrado o processo para envio de e-mail para os clientes por meio do sistema.

https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2023-1-e5-proj-ext-t1-SRC/assets/59442859/98978649-b6ff-464a-9545-3a9def25afbf

## Evidência nº: 05 - Emitir relatório PDF:

No vídeo abaixo é registrado o processo para pesquisar as avalições/*feedbacks* pela classificação e emitir relatório em formato PDF.



