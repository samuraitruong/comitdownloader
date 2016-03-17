var express = require('express')
  , router = express.Router()

router.use('/user', require('./user/index'))
router.use('/story', require('./story/index'))


router.get('/', function(req, res) {
 	res.json( {'API':'no enpoint'});
})

module.exports = router