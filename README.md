<div align="center">
<h1>Inova Estoque – Sistema web para o controle do estoque de Alimentos Escolares</h1>
</div>
<div align="center">
  <img src="https://github.com/Raphaelfreitas2334/InovaEstoque1/blob/InovaEstoque-V3.12.0/wwwroot/imagens/logo_InovaEstoque.png" alt="Logo do Projeto" width="600">
</div>

## Índice
- Descrição
- Funcionalidades
- Tecnologias Utilizadas
- Instalação
- Como Usar
- Documentação
- Integrantes
- Contribuição
- Licença
- Agradecimentos

## Descrição
<div align="justify">
  <p>
    O trabalho discute a criação de um sistema web chamado Inova Estoque para controlar o estoque de alimentos em escolas,
    com o objetivo de reduzir o desperdício e melhorar a gestão de recursos. Destaca a importância dos sistemas de informação
    para a eficiência dos processos empresariais e apresenta dados alarmantes sobre o desperdício de alimentos no mundo e no Brasil.
    O sistema permite monitorar entradas e saídas de alimentos, identificar produtos próximos da data de vencimento e evitar desperdícios.
    O trabalho detalha as tecnologias usadas, os requisitos do sistema, o projeto e os resultados obtidos, concluindo que o Inova Estoque
    é uma ferramenta eficaz para melhorar o controle de estoque e a gestão de recursos nas escolas. As considerações finais abordam as lições
    aprendidas e oportunidades de melhoria futura.
    </p>
</div>

## Funcionalidades
- Monitoramento de entradas e saídas de alimentos
- Identificação de produtos próximos da data de vencimento
- Relatório de Alimentos
- Relatorios de Alimentos Vencendo
- Relatorios de Alimentos Acabanco

## Tecnologias Utilizadas
- ASP.NET Core MVC 5
- Visual Studio Code 2022
- Bootstrap 5
- HTML 5
- CSS 3
- JavaScript 5
- jQuery validation e data table
- JSON
- GitHub
- SQL Server Management Studio
- Fluent API

<div align="center">
  <img src="https://github.com/Raphaelfreitas2334/InovaEstoque1/blob/InovaEstoque-V3.12.0/wwwroot/imagens/cozinheira.png" alt="Logo do Projeto" width="600">
</div>

## Instalação - Git
Para rodar o projeto localmente, siga os passos abaixo:

1. Clone o repositório:
    ```bash
    gh repo clone Raphaelfreitas2334/InovaEstoque1
    ```
2. Navegue até o diretório do projeto:
    ```bash
    cd inova-estoque
    ```
3. Instale as dependências:
    ```bash
    npm install
    ```
## Instalação - Direto no Visual Studio 2022
Para rodar o projeto localmente, siga os passos abaixo:

1. Abra o Visual Studio 2022:
    ```bash
    Após abrir o visual clique em clonar repositorio
    ```
2. Adicione o local do repositorio:
    ```bash
    https://github.com/Raphaelfreitas2334/InovaEstoque1.git
    ```
3. Clique em clonar:
    ```bash
    após o carragemento do projeto ele já esta quase pronto para rodar,
    pois tera que configurar a string de conexção com o BD, no caso esse
    projeto esta usando o SQL Server Management Studio 19.
    ```
## Configuração do DB - SQL Server Management Studio
apartir desse ponto presumimos que você já tenha o QL Server Management Studio (SSMS)
instalado na sua maquina:

1. caso não tenha o SQL Server Management Studio (SSMS):
    ```bash
    siga os passo a passo desse videio
    https://www.youtube.com/watch?v=LxtLqS-9KYo
    ```
1. navegue ate a aba de gerenciamento de soluções:
    ```bash
    dentro de Gerenciamento de soluções, navegue até "appsettings.json"
    PS: se o gerenciamento de soluções não estiver aparecendo,
    ele pode ser encontrado na aba superior em "exibir", ate o momento dia 18/07/2024
    ele e o terceiro botão de cima para baixo, ou use o atalho "Ctrl+Alt+L". 
    ```
3. Dentro de "appsettings.json" atualize essa linha:
    ```bash
    "DataBase": "Server=DESKTOP-HO7UDGJ\\SQLEXPRESS;Database=DB_Teste12;Integrated Security=True;"
    "DataBase": "Server=" Nome do seu servidor/PC ";Database=" Nome do BD ";Integrated Security=True;"
    ```
4. agora ache na parte superior o botão ferramentas
   ```bash
   dentro de ferramentas navegue ate Gerenciador de pacotes NulGet
   dentro de Gerenciador de pacotes NulGet va até Console de Gerenciador de Pacotes
   ````
5. agora dentro de Console de Gerenciador de Pacotes:
   ```bash
   tera uma teg "PM>"
   nessa teg escreva: Add-Migration "o nome da tabela que você criar" Context BancoContex
   quando carregar tudo certo ira aparecer a mensagem "DONE",
   após isso escreva: Update-Database Context BancoContext
   quando carregar tudo certo ira aparecer a mensagem "DONE",
   ````
5. agora e só iniciar o sistema:
   ```bash
    após isso é só iniciar o sistema usando a tecla F5, ou no menu superior no botão do play
    selecione ISLL Express e clique para iniciar no sinbolo do Play ou F5
   ````
   
## Como Usar
Descreva aqui como usar o sistema, com exemplos de comandos e prints de tela.

## Documentação
A documentação completa do projeto pode ser encontrada aqui.

## Integrantes
- **Nome do Integrante 1** - GitHub
- **Nome do Integrante 2** - GitHub
- **Nome do Integrante 3** - GitHub

## Contribuição
Para contribuir com o projeto, siga os passos abaixo:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/nome-da-feature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Faça o push para a branch (`git push origin feature/nome-da-feature`)
5. Abra um Pull Request

## Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.

## Agradecimentos
Agradecemos a todos que contribuíram para o desenvolvimento deste projeto, especialmente nossos orientadores e colegas de classe.

---

<div align="center">
  <a href="https://github.com/Raphaelfreitas2334/InovaEstoque1/blob/InovaEstoque-V3.12.0/wwwroot/imagens/Gravando%202024-05-29%20212418.mp4">
    <img src="https://github.com/seu-usuario/seu-repositorio/raw/main/assets/preview-image.png" alt="Clique para assistir o vídeo" width="100" height="100">
  </a>
</div>
