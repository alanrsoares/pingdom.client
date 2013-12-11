semVer = require './semVer'
clc = require './color'

class AssemblyInfo
	constructor: (data, assemblyInfo) ->
		@data = data
		@assemblyInfo = assemblyInfo
		@version = undefined
		@preRelease = undefined

	getNextVersion: (increment, preRelease) ->
		if this.version is undefined
			this.version = this.parseVersion()

		if preRelease isnt undefined then this.version.preRelease = preRelease
		else
			this.version.preRelease = ''

		this.version = this.version.next increment
		this.setVersion this.version.ToString()
		return this.version.ToString()

	setVersion: (newVersion) ->
	    version = newVersion.split '-'
	    this.data = this.data.replace(this.getRegexVersion(),"Version(\"#{version[0]}\")")
	    this.data = this.data.replace(this.getRegexFileVersion(),"FileVersion(\"#{version[0]}\")")
	    this.data = this.data.replace(this.getRegexInformationalVersion(),"InformationalVersion(\"#{newVersion}\")")
	    
	    this.data.to this.assemblyInfo
	
	parseVersion: ->
	    this.isInformationalVersionExists()
	    match = this.getRegexInformationalVersion().exec(this.data)
	    isMatchNull match

	    version = 
	        major: match[1]
	        minor: match[2]
	        patch: match[3]

	    validateVersion version
	   	this.preRelease = match[4].replace '-',''
	    if this.preRelease isnt null and (semVer.isPreReleaseValid this.preRelease)
	        return semVer.getVersion version, this.preRelease
	    else
	    	return 	semVer.getVersion version

	setPreRelease: (preRelease) ->
		if (semVer.isPreReleaseValid preRelease)
			this.version = this.parseVersion()
			this.version.preRelease = preRelease
			this.setVersion this.version.ToString()

	getRegexVersion: ->
		return /Version\s*\("((\d+)\.(\d+)\.(\d+)|)"\)/g

	getRegexInformationalVersion: ->
		return /InformationalVersion\s*\("(\d+)\.(\d+)\.(\d+)(|(\-)[1-9A-Za-z]+[0-9A-Za-z]?)"\)/g

	getRegexFileVersion: ->
		return /FileVersion\\s*\("((\d+)\.(\d+)\.(\d+)|)"\)/g

	getRegexInformationalVersionTemplate: () ->
		return /InformationalVersion\s*\(".*"\)/g

	isInformationalVersionExists: () ->
		match = this.getRegexInformationalVersionTemplate().exec(this.data)
		if match is null then this.insertInformationalVersion()

	isMatchNull = (match) ->
		if match is null
			msg = \
			"""
			#{clc.error 'O \'AssemblyInformationalVersion\' 
			do \'AssemblyInfo\' é inválido.\n
			Você pode ter esquecido de configurá-lo.\n
			Para configurar:\n
			[assembly: AssemblyVersion("1.0.*")]\n
			[assembly: AssemblyFileVersion("1.0.*")]\n
			[assembly: AssemblyInformationalVersion("1.0.*-beta")]'}
			"""
			throw new Error msg

	insertInformationalVersion: () ->
		version = this.getRegexVersion().exec(this.data)
		this.data = this.data.concat "\n[assembly: AssemblyInformationalVersion(\"#{version[1]}\")]"
		this.data.to this.assemblyInfo

	validateVersion = (version) ->
		result = semVer.isVersionValid version
		if result isnt true
			msg = \
			"""
			#{clc.error 'O número de versão informado no \'AssemblyInfo\' é inválido.\n
			Os valores \'major\', \'minor\' e \'patch\' não podem:\n
			> ser números inteiros não negativos\n
			> possuir zeros a esquerda\n

			Para mais informações: \'semver.org\''}
			"""
			throw new Error msg

exports.AssemblyInfo = AssemblyInfo
