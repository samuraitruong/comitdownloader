var express = require('express')
  , router = express.Router()
  stories = require('../../../models/stories')


router.get('/', function(req, res) {
	stories.randoms(30,function(err, data ) {
		res.json( data);	
	})
})


module.exports = router