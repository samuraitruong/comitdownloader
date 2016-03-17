var express = require('express')
  , router = express.Router()
  stories = require('../../../models/stories')


router.post('/', function(req, res) {
	res.json({'response':true})
})

module.exports = router