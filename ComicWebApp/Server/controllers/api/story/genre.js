var express = require('express')
  , router = express.Router()
  stories = require('../../../models/stories')


router.get('/', function(req, res) {
	stories.genres(function(err, data ) {
		res.json(data);	
	})
})
router.route('/:genre/:page')
.get(function(req, res){
	stories.genreStories(req.params.genre, req.params.page, function(err, data) {
		res.json(data)
	})
	

});


module.exports = router