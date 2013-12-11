require '../jakelib/lib/options'
projects = global.projects
backupOldPackages = global.options.backupOldPackages
packParameters = global.options.nuGet.packParameters

require 'shelljs/global'
clc = require './lib/color'
utils = require '../jakelib/lib/utils'
documentation = require './lib/documentation'
fs = require('fs')
path = require('path')
njake = require '../tools/njake/njake.js'
nuget = njake.nuget

{AssemblyInfo} = require '../jakelib/lib/assemblyInfo'

# NJake defaults
nuget.setDefaults
    _exe: 'tools/nuget/NuGet.exe'
    verbose: false

namespace 'nuget', ->
    documentation.set 'nuget_publish', 'Publica o pacote NuGet no MyGet'
    task 'publish', ['build'], async: true, ->
        if arguments.length is 0
            releaseProject 'default', 'publish'
        else
            for projectName in arguments
               releaseProject projectName, 'publish'

    documentation.set 'nuget_pack', 'Cria o pacote NuGet'
    task 'pack',['build',  'nuget'], async: true, ->
        if arguments.length is 0
            releaseProject 'default', 'pack'
        else
            for projectName in arguments
                releaseProject projectName, 'pack'
        complete()

directory 'nuget'

# Auxiliary functions
releaseProject = (name, option) ->
    project = utils.getProject name
    version = utils.getVersion project
    if project.projects is undefined
        if option is 'pack' then pack project, version
        if option is 'publish' then publish project, version
    else
        releaseMetaProject project, name, option, version

releaseMetaProject = (project, name, option, version) ->
    for index, project of projects[name].projects
        if option is 'pack' then pack project, version
        if option is 'publish' then publish project, version

pack = (project, version, callback) ->
    ifParamsIsValid project
    utils.createDirectory 'nuget'
    if backupOldPackages is 'true' then movePreviousPackage project.id
    else
        deletePreviousPackage project.id
    
    nuget.pack {
        nuspec: project.nuspec
        version: version.ToString()
        outputDirectory: 'nuget'
        packParameters: packParameters
    }, callback
    console.log "\n #{clc.sucess '--> Pacote do projeto \''+project.id+'\' gerado com sucesso.'}\n"

publish = (project, version) ->
    pack project, version, ->
        packageFile = getLatestPackage project.id
        console.log "\n #{clc.message '--> Publicando pacote '+packageFile}"
        nuget.push {
            package: packageFile
            source: 'https://www.myget.org/F/vtexlab/'
        }, -> complete(console.log "\n #{clc.sucess '--> Pacote '+packageFile+' publicado com sucesso.'}")

getLatestPackage = (id) ->
    all = getPackages id
    unless all.length
        msg = \
        """
        #{clc.error 'O projeto \''+id+'\' não possui um pacote correspondente.\n'}
        """
        throw new Error msg

    all[all.length - 1].replace /\//g, '\\'

deletePreviousPackage = (id) ->
    all = getPackages id
    
    console.log "\n #{clc.message '--> Removendo pacotes antigos'}"
    for file in all
        if fs.statSync(file).isFile() then fs.unlinkSync(file)
  
    console.log "\n #{clc.sucess '--> Pacotes removidos com sucesso.'}"

movePreviousPackage = (id) ->
    all = getPackages id
    backupOldPackagesPath = "nuget/backup/"
    utils.createDirectory backupOldPackagesPath
    
    console.log "\n #{clc.message '--> Realizando backup dos pacotes antigos'}"
    for file in all
        fileName = path.basename file
        try 
            fs.renameSync(file, backupOldPackagesPath+fileName)
        catch error
            console.error error

    console.log "\n #{clc.message '--> Backup realizado com sucesso.'}"

getPackages = (id) ->
    regex = new RegExp "#{id}\\.\\d+\\.\\d+\\.\\d+(-\\w+)?\\.nupkg"
    all = ls('nuget/*.nupkg')
    files = []

    for file in all
        match = regex.test file
        if match isnt false then files.push file.toString()
          
    return files

ifParamsIsValid = (project) ->
    if project.nuspec is undefined or project.nuspec is ''
        utils.invalidValue 'nuspec'
    if project.id is undefined or project.id is ''
        utils.invalidValue 'id'