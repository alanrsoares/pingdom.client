clc = require '../lib/color'
text = \
"""


        #{clc.title 'USO:'}

            #{clc.topics '$ jake clean'}


        #{clc.title 'DESCRIÇÃO:'}

            Remove arquivos dos diretórios 'obj'e 'bin' do projeto.


        #{clc.title 'PARÂMETROS:'}

            #{clc.topics 'n/a'}


        #{clc.title 'EXEMPLOS:'}
            Remove arquivos do diretórios 'bin' e 'obj' do projeto default:

                #{clc.example '$ jake clean'}

    
"""
exports.text = text