var express = require('express'),
    router = express.Router(),
    users = require('../../../models/users');


router.use('/check', require('./check'))

router.get('/', function(req, res) {
 	res.json( {'user':'OK'});
})
router.post('/', function(req, res) {
	users.create(req.body, function(err, data) {
		res.json(data);
	});
})

router.post('/login', function(req, res) {
	
	users.login(req.body, function(err, data) {
			if(err) {
				res.status(400);
				res.send( {error: 'wrong username or password, please try again!!!'});		
			}
			else{
				res.json(data);
			}
	});		

})
module.exports = router