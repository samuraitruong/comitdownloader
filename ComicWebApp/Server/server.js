var express = require('express')
  , app = express()
  , bodyParser = require('body-parser')
  , port = process.env.PORT || 3000

app.set('views', __dirname + '/views')
app.engine('jade', require('jade').__express)
app.set('view engine', 'jade')

//app.use(express.static(__dirname + '/public'))
app.use(express.static('E:\\COMICDOWNLOADER\\comitdownloader\\ComicWebApp\\wwwroot'))
app.use(bodyParser.json())
app.use(bodyParser.urlencoded({extended: true}))
app.use(require('./controllers'))

app.listen(port, function() {
	console.log('static file from :../wwwroot')
  console.log('Listening on port ' + port)
})