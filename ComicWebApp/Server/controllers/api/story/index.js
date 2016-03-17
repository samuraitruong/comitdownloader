var express = require('express')
  , router = express.Router()

router.use('/top', require('./top'))
router.use('/top10', require('./top10'))
router.use('/toptoday', require('./toptoday'))
router.use('/latest', require('./latest'))
router.use('/updated', require('./updated'))
router.use('/genres', require('./genres'))
router.use('/genre', require('./genre'))
router.use('/list', require('./list'))

router.get('/', function(req, res) {
 	res.json( {'Top':'top'});
})

router.route('/detail/:storyName')
.get(function(req, res){
	stories.storyInfo(req.params.storyName,function(err, data) {
		res.json(data)
	})
	

});

router.route('/detail/:storyName/:chapName')
.get(function(req, res){
	stories.chapInfo(req.params.storyName, req.params.chapName,function(err, data) {
		res.json(data)
	})
	

});


module.exports = router