extend = require 'node.extend'
defaultOptions = require '../lib/default_options'

global.options = extend(true, {}, defaultOptions, global.options)