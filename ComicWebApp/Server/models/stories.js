var fs = require('fs'),stories
var data_root = 'E:\\uptruyen.com\\';

function readStories(cb) {
	if(stories == null) {
		fs.readFile(data_root +'stories.json',  function(err, data) {
				console.log('file length')
				console.log(data.length)

				stories = JSON.parse(data.toString('utf8').replace(/^\uFEFF/, ''))
				cb(err, stories)
			});
	}
	else{
		console.log('data already loade.....')
		cb(null, stories);
	}

}

function readStoryInfo(dataFile, callback) {
	console.log(dataFile)
	fs.readFile(data_root +dataFile, 
			function(err, data) {
				if(data) {
					var s = JSON.parse(data.toString('utf8').replace(/^\uFEFF/, ''))
					callback(err, s)
				}
				else{
					callback({err:1}, null)
				}
			});
}

// Write the callback function
function handleFile(err, data) {
    if (err) throw err
    stories = JSON.parse(data)
    // You can now play with your datas
}


//stories = require(data_root+'stories.json')

exports.random = function(cb) {
  readStories(function(err, data) {
  	var index = Math.round(data.length * Math.random());
  	var story = data[index];
  	readStoryInfo(story.JsonFileName, cb);
  })
  
}

exports.all = function(cb) {
  readStories(function(err, data) {
  	cb(null, data);	
  })
  
}

