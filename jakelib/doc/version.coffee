clc = require '../lib/color'
text = \
"""


    #{clc.title 'USO:'}

        #{clc.topics '$ jake version'}


    #{clc.title 'DESCRIÇÃO:'}

        Mostra a versão mais recente do VTEX Jake Bootstrapper.


    #{clc.title 'PARÂMETROS:'}

        #{clc.topics 'n/a'}


    #{clc.title 'EXEMPLOS:'}

       Mostra a versão do VTEX Jake Bootstrapper:

             #{clc.example '$ jake version'}

 
"""
exports.text = text