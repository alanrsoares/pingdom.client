clc = require '../lib/color'
fs = require 'fs'
{AssemblyInfo} = require '../lib/assemblyInfo'

exports.loadAssemblyInfo = (project) ->
    try
        data = cat project.assemblyInfo
        if data is null then throw new Error()
        return new AssemblyInfo(data, project.assemblyInfo)
    catch
        msg = 
        """
        #{clc.error ' O AssemblyInfo não foi encontrado. Verifique o Jakefile.\n
        Você pode ter esquecido de configurá-lo'}
        """
        console.log fail msg

exports.invalidValue = (name) ->
    fail "\n #{clc.error '--> O campo '+name+' não foi configurado. Verifique o Jakefile.'}"

exports.getProject = (name) ->
    project = projects[name]
    unless project
        msg =
        """
        #{clc.error 'O projeto \''+name+'\' não foi encontrado.\n
        Você pode ter esquecido de configurar o \'global.projects\' no Jakefile.\n'}.
        """
        fail msg
    
    project

exports.getVersion = (project) ->
    assemblyInfo = this.loadAssemblyInfo project
    return version = assemblyInfo.parseVersion()

exports.createDirectory = (dir) ->
    try
        if fs.statSync(dir).isDirectory() is false then fs.mkdir dir
    catch
        fs.mkdir dir