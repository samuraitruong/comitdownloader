var express = require('express'),
    stories = require('../../../models/stories'),
    router = express.Router();

router.get('/', function(req, res) {
	stories.random(function(err, data) {
		res.json( data);	
	})
});

router.route('/:id')
.get(function(req, res){
	res.json({id:req.params.id})

});

module.exports = router