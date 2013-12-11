clc = require '../lib/color'
text = \
"""

    
        #{clc.title 'USO:'}
          
            #{clc.topics '$ jake help[<tarefa>]'}


        #{clc.title 'DESCRIÇÃO:'}

            Exibe instruções de uso da ferramenta, lista quais são as tarefas
            disponíveis apresentando uma pequena descrição de cada tarefa. 
            Caso uma tarefa seja passada como parâmetro, apresenta informações 
            detalhadas da tarefa em questão.

            A exibição detalhada de uma tarefa, identifica quais são os parâmentros
            possíveis de serem utilizados.Além disso, exemplos são fornecidos afim
            de demonstrar sua aplicabilidade.


        #{clc.title 'PARÂMETROS:'}

            #{clc.topics '<tarefa> (opcional)'}
                Nome da tarefa que se pretende obter informações mais detalhadas.


        #{clc.title 'EXEMPLOS:'}

            Acesso ao menu de ajuda:

                #{clc.example '$ jake help'}
            
            Acesso a informações detalhadas de uma tarefa:

                #{clc.example '$ jake help[bump]'}


"""
exports.text = text