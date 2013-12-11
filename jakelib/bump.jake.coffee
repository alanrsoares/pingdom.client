clc = require './lib/color'
require '../jakelib/lib/options'
require 'shelljs/global'

gitTagPrefix = global.options.git.tagPrefix
commitMessage = global.options.git.commitMessage
projects = global.projects

utils = require '../jakelib/lib/utils'
semVer = require '../jakelib/lib/semVer'
documentation = require './lib/documentation'
minimatch = require 'minimatch'
path = require 'path'
{AssemblyInfo} = require '../jakelib/lib/assemblyInfo'


documentation.set 'bump', 'Atualiza a versão do AssemblyInfo de um projeto'
task 'bump', async: true, (increment, name) ->
    ifWorkingDirectoryIsClean()
    preRelease = getPreReleaseFromCli()
    name = resolveProjectName increment, name, preRelease

    version = bumpVersion increment, name, preRelease
    tag = getTag name, version

    projectIdentifier = getProjectIdentifier name
    console.log "#{clc.message '--> Atualizando versão do \''+projectIdentifier+'\''}"
    console.log "#{clc.note 'Versão gerada:' + tag}"
    console.log "\n#{clc.message '--> Consolidando alteração de versão no git'}"
    exec "git commit --all -m\"#{''+commitMessage+' '+projectIdentifier+''}\"", (code) ->
        unless code is 0
            fail 'O commit falhou'

        jake.exec ["git tag #{tag} -f"], ->
            complete(console.log "\n #{clc.sucess '--> Nova versão gerada com sucesso.'}")

# Auxiliary functions
bumpVersion = (increment, name, preRelease) ->
    project = utils.getProject name
    version = getNextVersion project, increment, preRelease
    return version

getNextVersion = (project, increment, preRelease) ->
    assemblyInfo = utils.loadAssemblyInfo project

    if preRelease? and (semVer.isPreReleaseValid preRelease) is true
        if (semVer.isIncrementValid increment) is false
            assemblyInfo.setPreRelease preRelease
            return assemblyInfo.parseVersion().ToString()

    validatePreRelease preRelease
    return assemblyInfo.getNextVersion increment, preRelease

getTag = (project, version) ->  
    if !!gitTagPrefix
        if project is "default" then newVersion = "#{gitTagPrefix}-v#{version}"
        else newVersion = "#{gitTagPrefix}-#{project}-v#{version}"
    else
        if project is "default" then newVersion = "v#{version}"
        else newVersion = "#{project}-v#{version}"

    newVersion

getProjectIdentifier = (name) ->
    project = utils.getProject name
    if project.name isnt undefined and project.name isnt '' then return project.name
    else
        if project.id isnt undefined and project.id isnt '' then return project.id
        else
            utils.invalidValue '\'name\' ou \'id\' do projeto \''+name+'\''

ifWorkingDirectoryIsClean = ->
    result = exec('git status -s', {silent:true}).output
    result = result.split '\n'

    if result.length is 0 then return

    for item in result
        item = item.match /[A-Z?]+ "?.*?([^"\/]+)"?$/
        if item isnt null
            if (ifAllowInBumpCommit item[1]) is false then fail \
            """
            #{clc.error 'Você possui mudanças locais não resolvidas.\n
            Certifique-se que o working directory esteja vazio.\n'}
            """

ifAllowInBumpCommit = (item) ->
    allow = options.git.allowInBumpCommit
    for allowItem in allow
        regex = getRegex allowItem
        if (regex.test item) is true then return true

    return false

getRegex = (allowItem) ->
    regex = minimatch.makeRe allowItem
    if regex is false
        fail \
        """
        #{clc.error 'O wildcard \''+allowItem+'\' é
         inválido em git.allowInBumpCommit.'}
        """
    return regex

validatePreRelease = (preRelease) ->
    if (semVer.isPreReleaseValid preRelease) is false
        msg =
        """
        #{clc.error 'O valor \''+preRelease+'\' para o prerelease é inválido.
         Verifique as regras em \'semver.org\''}
        """
        fail msg

resolveProjectName = (increment, name, preRelease) ->
    ifParamsNotUndefined increment, name, preRelease

    if (semVer.isIncrementValid increment) isnt true
        if (projects[increment]) isnt undefined
            name = increment
        else
            name = undefined

    if increment is undefined and name is undefined
        if preRelease? then name = 'default'
    
    if (semVer.isIncrementValid increment) is true and name is undefined
        name = 'default'

    return name

ifParamsNotUndefined = (increment, name, preRelease) ->
    if increment is undefined and name is undefined and preRelease is undefined
        fail \
        """
        #{clc.error '--> O projeto não pode ser incrementado.\n
        Você pode ter esquecido de passar algum parâmetro.\n
        Consulte jake help[bump]'}\n
        """

getPreReleaseFromCli = ->
    if process.env.prerelease? then return process.env.prerelease
    if process.env.pre? then return process.env.pre