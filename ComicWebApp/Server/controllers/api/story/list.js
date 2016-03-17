var express = require('express')
  , router = express.Router()
  stories = require('../../../models/stories')


router.get('/', function(req, res) {
	res.json({ok:true})
})
router.route('/:group/:page')
.get(function(req, res){
	//res.json({genre:req.params.genre})
	stories.all(req.params.group, req.params.page, function(err, data) {
		res.json(data);
	});
});


module.exports = router