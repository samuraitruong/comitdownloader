var express = require('express')
  , router = express.Router()

router.use('/top', require('./top'))
router.get('/', function(req, res) {
 	res.json( {'Top':'top'});
})

module.exports = router