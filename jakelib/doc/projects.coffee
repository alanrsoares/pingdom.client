clc = require '../lib/color'
text = \
"""

    
      #{clc.title 'USO:'}
        
          #{clc.topics '$ jake projects'}


      #{clc.title 'DESCRIÇÃO:'}

          Lista todos os projetos configurados no Jakefile, os projetos
          são apresentados em uma tabela com as seguintes colunas:
          \'alias\', \'name\'' e \'id\' do projeto.


      #{clc.title 'PARÂMETROS:'}

         #{clc.topics 'n/a'}


      #{clc.title 'EXEMPLOS:'}

          Lista todos os projetos:

              #{clc.example '$ jake projects'}


"""
exports.text = text