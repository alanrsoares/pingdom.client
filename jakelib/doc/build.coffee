clc = require '../lib/color'
text = \
"""
    

    #{clc.title 'USO:'}

        #{clc.topics '$ jake build'}


    #{clc.title 'DESCRIÇÃO:'}

        Compila a solução previamente configurada no arquivo Jakefile através 
        da configuração \'solutionFile\', que representa o caminho para o
        diretório da solução do projeto.

        Não são necessários parâmetros para executar a tarefa, basta apenas que o 
        campo \'solutionFile\' tenha sido configurado, o resultado da compilação pode
        ser avaliado na pasta \'/bin\' do projeto.

    
    #{clc.title 'PARÂMETROS:'}

        #{clc.topics 'n/a'} 
 

    #{clc.title 'EXEMPLOS:'}

        Compila a solução configurada:

            #{clc.example '$ jake build'}


"""
exports.text = text
