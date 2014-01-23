# Esse arquivo define as configurações usadas nos arquivos de build em ./jakelib

global.options = 
	git:
	   tagPrefix: 'client'
	   commitMessage: 'Generates NuGet for'
	   allowInBumpCommit: ['CHANGELOG*.md','*.nuspec']

# A solução a ser compilada
global.solutionFile = 'src/Pingdom.Client.sln'

# Caminho para o arquivo de resultados gerado pelo NUnit
global.nUnitOutputFile = 'test-output/Pingdom.Client.xml'

# Projetos de teste
global.testProjects = []
#[
# {name: 'Pingdom.Client.Tests'}
#]

# Define caminho dos assemblies dos projetos de testes
for testProject in global.testProjects
    testProject.assembly = "src/#{testProject.name}/bin/Release/#{testProject.name}.dll"

# Projetos a terem pacotes NuGet gerados
global.projects =
    default:
        name: 'Pingdom.Client'
        id: 'Pingdom.Client'

# Define caminhos para Nuspec e Assembly Info de cada projeto
for key, project of global.projects
    project.assemblyInfo = "src/#{project.name}/Properties/AssemblyInfo.cs"
    project.nuspec = "src/#{project.name}/#{project.id}.nuspec"