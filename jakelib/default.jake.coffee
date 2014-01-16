clc = require './lib/color'
require '../jakelib/lib/options'

nUnitOutputFile = global.options.nUnit.outputFile
solutionFile = global.solutionFile
testProjects = global.testProjects || []
projects = global.projects

require 'shelljs/global'
njake = require '../tools/njake/njake.js'
Table = require 'cli-table'
utils = require '../jakelib/lib/utils'
documentation = require './lib/documentation'

msbuild = njake.msbuild
nunit = njake.nunit
nuget = njake.nuget

documentation.set 'build', 'Compila a solução definida na configuração \'solutionFile\''
task 'build', ['restore'], async: true, ->
    console.log "\n #{clc.message '--> Compilando '+'\"'+solutionFile+'\"'}"
    msbuild {
        file: solutionFile
        targets: ['Clean', 'Build']
        }, -> complete(console.log "\n #{clc.sucess '--> \"'+solutionFile+'\" foi compilado com sucesso.'}")

directory 'test-output'

documentation.set 'test', 'Executa os testes automatizados'
task 'test', ['build', 'test-output'], async: true, ->
    if testProjects.length is 0 then utils.invalidValue 'testProjects'

    console.log "\n #{clc.message "--> Executando testes"}"
    nunit {
        assemblies: testProjects.map (testProject) -> testProject.assembly
        xml: nUnitOutputFile
        }, -> complete(console.log "\n #{clc.sucess '--> Testes executados com sucesso.'}")

# NJake defaults
msbuild.setDefaults
    properties:
        configuration: 'Release'
        warningLevel: 1
    processor: 'x86'
    version: 'net4.0'
    _parameters: ['/verbosity:minimal']

nunit.setDefaults
    _exe: 'tools/nunit/nunit-console-x86.exe'

documentation.set 'projects', 'Lista os projetos configurados em Jakefile'
task 'projects',  ->
    table = new Table({head:['alias','name','id']})

    for key, value of projects
        if value.name is undefined then value.name = 'não definido'
        if value.id is undefined then value.id = 'não definido'
        table.push([key, value.name, value.id])

    console.log(table.toString())

documentation.set 'update', 'Atualiza a versão do VTEX Jake Bootstrapper'
task 'update', async: true, ->
    packageJSON = require '../package.json'
    if packageJSON._from?
        jake.exec "npm install #{packageJSON._from}", {interactive:true}, -> complete()
    else
        console.log "#{clc.error 'O arquivo package.json não foi encontrado.'}"
        complete()

documentation.set 'restore', 'Restaura todos os pacotes usados pelos projetos da solução'
task 'restore', async: true, ->
    if not solutionFile then utils.invalidValue 'solutionFile'

    nuget.restore {
        solutionFile: solutionFile
    }

documentation.set 'clean', 'Remove arquivos dos diretórios \'obj\' e \'bin\''
task 'clean', ->
    path = solutionFile.replace /\/([\w\s.]+).sln$/, ''
    listBinObj = findBinObjDirectory path
    cleanDirectory listBinObj

documentation.set 'version', 'Mostra a última versão do VTEX Jake Bootstrapper'
task 'version', ->
    packageJSON = require '../package.json'
    console.log "#{clc.sucess '--> VTEX Jake Bootstrapper v'+packageJSON.version}"

# Auxiliary functions
findBinObjDirectory = (path) ->
    list = ls '-R', path
    if list.length is 0
        fail "#{clc.error 'O diretório \''+path+'\' não foi encontrado.'}"

    listBinDir = find('.').filter((list) -> /bin$/.exec list)
    listObjDir = find('.').filter((list) -> /obj$/.exec list)
    listBinObj = listBinDir.concat listObjDir
    return listBinObj

cleanDirectory = (listBinObj) ->
    console.log fail "#{clc.message '--> Limpando diretórios \'bin\' e \'obj\'.\n'}"
    for dir in listBinObj
        if (test '-d', dir)
            rm '-rf', dir+'/*'
        else
            console.log fail "#{clc.error '--> Erro ao remover os arquivos.\n'}"

    console.log "\n#{clc.sucess '--> Arquivos removidos com sucesso.'}\n"
