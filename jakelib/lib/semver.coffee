	class Version
		constructor: (version, preRelease) ->
			@version = version
			@preRelease = preRelease

		next: (increment) ->
			this.version[increment]++
			if increment is 'major' then this.version.minor = this.version.patch = 0
			if increment is 'minor' then this.version.patch = 0

			return new Version this.version, this.preRelease

		ToString: ->
			if !!this.preRelease or this.preRelease is undefined
				return "#{this.version.major}.#{this.version.minor}.#{this.version.patch}-#{this.preRelease}"

			return "#{this.version.major}.#{this.version.minor}.#{this.version.patch}"

	exports.getVersion = (version, preRelease) ->
		return new Version(version, preRelease)

	exports.isVersionValid = (version) ->
		regex = /^([1-9]\d*|0)$/
		for key, value of version
			match = regex.exec value
			if match is null then return false

		return true

	exports.isIncrementValid = (increment) ->
	    if increment not in ['major', 'minor', 'patch']
	    	return false

	    return true

	exports.isPreReleaseValid = (preRelease) ->
		if preRelease is '' then return true
		regex = /^([A-Za-z1-9]\w*|0)$/
		match = regex.exec preRelease
		if match is null then return false

		return true