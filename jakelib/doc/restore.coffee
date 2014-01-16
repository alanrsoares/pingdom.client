clc = require '../lib/color'
text = \
"""
    

    #{clc.title 'USO:'}

        #{clc.topics '$ jake restore'}


    #{clc.title 'DESCRIÇÃO:'}

        Restaura todos os pacotes usados pelos projetos da solução.

        Não são necessários parâmetros para executar a tarefa, basta apenas que o 
        campo \'solutionFile\' tenha sido configurado no Jakefile.

    
    #{clc.title 'PARÂMETROS:'}

        #{clc.topics 'n/a'} 
 

    #{clc.title 'EXEMPLOS:'}

        Compila a solução configurada:

            #{clc.example '$ jake restore'}


"""
exports.text = text
