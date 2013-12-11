clc = require '../lib/color'
text = \ 
"""


         #{clc.title 'USO:'}

            #{clc.topics '$ jake nuget:pack[<nomedoprojeto>] [<listadeprojetos>]'}


        #{clc.title 'DESCRIÇÃO:'}

            Cria o pacote do projeto passado como parâmentro,o projeto deve previamente
            ter sido previamente compilado.

            É possível passar um projeto específico ou uma lista de projetos que se
            deseja empacotar. 

            Lembrando que a versão do pacote, deve ser gerada antes da tarefa de publicação,
            caso não existam pacotes relacionados ao parâmentros, o VTEX Jake Bootstrapper 
            irá tentar gerar os pacotes correspondentes.

            Caso não sejam passados parâmetros o projeto default será publicado.
            
            A configuração de um projeto no Jakefile permite dois tipos de abstração.
            É possível compor vários projetos em um único projeto,desta forma, quando o
            'meta-projeto' for chamado irá executar todos os projetos que possui.

            Por outro lado, o projeto pode ser configurado de maneira simples como um projeto 
            específico, sem correlações com outros projetos.

            Se o usuário quiser realizar backup dos pacotes gerados anteriormente, é necessário
            que a opção \'oldPackages\' como \'true\' seja configurada através do namespace \'options\'
            no Jakefile. Por default os pacotes antigos são deletados.


        #{clc.title 'PARÂMETROS:'}

            #{clc.topics '<nomedoprojeto> (opcional)'}
                Nome do projeto a ser empacotado.

            #{clc.topics '<listadeprojetos> (opcional)'}
                Lista de projetos a serem empacotados.


        #{clc.title 'EXEMPLOS:'}

            Cria pacote do projeto \'default\':

                #{clc.example '$ jake nuget:pack'}

            Cria pacote de um projeto específico:

                #{clc.example '$ jake nuget:publish[nome-do-projeto]'}

            Cria pacotes dos projetos listados:

               #{clc.example '$ jake nuget:publish[nome-do-projeto,nome-do-projetoN]'}

  
"""
exports.text = text