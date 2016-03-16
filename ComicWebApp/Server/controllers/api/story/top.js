var express = require('express')
  , router = express.Router()
  data = require('../../../models/stories')


router.get('/', function(req, res) {
	data.random(function(err, data) {
		res.json( data);	
	})
})
router.route('/:id')
.get(function(req, res){
	res.json({id:req.params.id})

});

module.exports = router