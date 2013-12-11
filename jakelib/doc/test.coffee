clc = require '../lib/color'
text = \
"""

    
        #{clc.title 'USO:'}
          
            #{clc.topics '$ jake test'}


        #{clc.title 'DESCRIÇÃO:'}

            Executa todos os testes previamente configurados no arquivo Jakefile
            através da configuração \'testProjects\', responsável por identificar quais são os projetos
            de testes que deverão ser executados.

            Para imprimir os resultados dos testes em um arquivo, é preciso configurar o campo \'outputFile\' 
            pelo namespace \'options\' no Jakefile.

            Não são necessários parâmetros para executar a tarefa, basta apenas que o campo \'testProjects\'
            tenha sido configurado.


        #{clc.title 'PARÂMETROS:'}

           #{clc.topics 'n/a'}


        #{clc.title 'EXEMPLOS:'}

            Testa projetos configurados:

                 #{clc.example '$ jake test'}


"""
exports.text = text