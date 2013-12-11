clc = require '../lib/color'
text = \
"""
  

    #{clc.title 'USO:'}

        #{clc.topics '$ jake bump[<incremento>,<nomedoprojeto>] prerelease=<preRelease>'}


    #{clc.title 'DESCRIÇÃO:'}

        Atualiza a versão do AssemblyInfo de um projeto, fazendo commit das
        alterações e aplicando a tag da versão no git. 

        É possível inserir o valor de prerelease na versão, bem como removê-lo. 

        O número de versão respeita as regras sugeridas pelo Semantic Versioning,portanto,
        é necessário que o usuário esteja atento aos padrões apresentados em semver.org.

        Enquanto o working directory possuir modificações locais não resolvidas, a tarefa não
        será executada. O usuário pode específicar quais arquivos podem ser commitados com a
        tag configurando o campo \'options.git.allowInBumpCommit\' no Jakefile.


    #{clc.title 'PARÂMETROS:'}

        #{clc.topics '<incremento> (opcional)'}
            Campo que deve ser incrementado no número de versão MAJOR.MINOR.PATCH
            do projeto, obedecendo as regras sugeridas pelo Semantic Versioning.
            Caso seja o único valor passado como parâmetro, o projeto \'default\'
            será incrementado.

        #{clc.topics '<nomedoprojeto> (opcional)'}
            Nome do projeto que se pretende incrementar o número de versão, os projetos
            devem ser configurados previamente no Jakefile.

        #{clc.topics '<preRelease> (opcional)'}
            Valor da prerelease que será adicionada a versão. Caso o valor seja vazio e a 
            versão atual já tenha uma prerelease, a prerelease será removida.


    #{clc.title 'EXEMPLOS:'}

        Incrementa a versão do projeto \'default\' configurado no Jakefile:
             
             #{clc.example '$ jake bump[major]'}
             #{clc.example '$ jake bump[minor]'}
             #{clc.example '$ jake bump[patch]'}

        Incrementa a versão de um projeto configurado no Jakefile:

             #{clc.example '$ jake bump[minor,nome-do-projeto]'}

        Incrementa a versão do projeto \'default\' configurado no Jakefile,
        acrescentando um prerelease a versão:

             #{clc.example '$ jake bump[major] prerelease=gama'}
             #{clc.example '$ jake bump[minor] prerelease=beta'}
             #{clc.example '$ jake bump[patch] prerelease=alfa'}

        Incrementa a versão de um projeto configurado no Jakefile, 
        acrescentando um prerelease a versão:

             #{clc.example '$ jake bump[minor,nome-do-projeto] prerelease=beta'}

        Insere o valor da prerelease na versão atual do projeto \'default\' sem incrementar valores:

             #{clc.example '$ jake bump prerelease=beta'}

        Insere o valor da prerelease na versão atual de um projeto sem incrementar valores:

             #{clc.example  '$ jake bump[nome-do-projeto] prerelease=beta'}

        Retira o valor da prerelease na versão atual sem incrementar valores:

             #{clc.example '$ jake bump prerelease='}


"""
exports.text = text