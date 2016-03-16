var express = require('express')
  , router = express.Router()

router.use('/story', require('./story/index'))

router.get('/', function(req, res) {
 	res.json( {'Story':123});
})

module.exports = router