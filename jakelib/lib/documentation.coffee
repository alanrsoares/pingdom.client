exports.set = (taskName, description) ->
	documentFile = require '../doc/'+taskName+'.coffee'
	desc description.concat documentFile.text