var express = require('express')
  , router = express.Router()
  stories = require('../../../models/stories')


router.get('/', function(req, res) {
	stories.genres(function(err, data ) {
		console.log('restrning data')
		console.log(data)
		res.json(data);	
	})
})
router.route('/:genre')
.get(function(req, res){
	res.json({genre:decodeURIComponent(req.params.genre)})

});


module.exports = router