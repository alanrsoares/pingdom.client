clc = require '../lib/color'
text = \
"""


    #{clc.title 'USO:'}

        #{clc.topics '$ jake update'}


    #{clc.title 'DESCRIÇÃO:'}

        Atualiza a ferramenta VTEX Jake Bootstrapper para sua versão mais recente.


    #{clc.title 'PARÂMETROS:'}

        #{clc.topics 'n/a'}


    #{clc.title 'EXEMPLOS:'}

        Atualiza a versão do VTEX Jake Bootstrapper:

             #{clc.example '$ jake update'}

 
"""
exports.text = text