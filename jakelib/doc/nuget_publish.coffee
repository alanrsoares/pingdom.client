clc = require '../lib/color'
text = \ 
"""


       #{clc.title 'USO:'}

            #{clc.topics '$ jake nuget:publish[<nomedoprojeto>] [<listadeprojetos>]'}


        #{clc.title 'DESCRIÇÃO:'}

            Publica o pacote do projeto no MyGet da VTEX, o projeto deve previamente
            ter sido compilado e empacotado.

            É possível passar um projeto específico ou uma lista de projetos que se
            deseja publicar.

            Caso não sejam passados parâmentros o projeto default será publicado.
            A configuração de um projeto no Jakefile permite dois tipos de abstração.

            É possível compor vários projetos em um único projeto,desta forma, quando o
            'meta-projeto' for chamado irá executar todos os projetos que possui.

            Por outro lado, o projeto pode ser configurado de maneira simples como um 
            projeto específico, sem correlações com outros projetos.


        #{clc.title 'PARÂMETROS:'}

            #{clc.topics '<nomedoprojeto> (opcional)'}
                Nome do projeto a ser publicado.

            #{clc.topics '<listadeprojetos> (opcional)'}
                Lista de projetos a serem publicados.


        #{clc.title 'EXEMPLOS:'}

            Publica pacote do projeto \'default\':

                #{clc.example '$ jake nuget:publish'}

            Publica pacote de um projeto específico:

                #{clc.example '$ jake nuget:publish[nome-do-projeto]'}

            Publica pacotes dos projetos listados:

                #{clc.example '$ jake nuget:publish[nome-do-projeto,nome-do-projetoN]'}
  

"""
exports.text = text