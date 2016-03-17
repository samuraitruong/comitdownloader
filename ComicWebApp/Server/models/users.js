var fs = require('fs'),
	FileQueue = require('../helpers/filequeue/FileQueue'),// Export some model methods
	users =[],
	userFile = 'wwwroot/app_data/users.json';
function guid() {
  return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
    s4() + '-' + s4() + s4() + s4();
}

function s4() {
  return Math.floor((1 + Math.random()) * 0x10000)
    .toString(16)
    .substring(1);
}

function loadAllUsers(cb) {
	if(users.length == 0) {
		var fileContent = fs.readFileSync(userFile);
		console.log('fileread: ' + fileContent)
		users = JSON.parse(fileContent.toString('utf8').replace(/^\uFEFF/, ''));
	}
	cb(null,users);
}

exports.create = function (user, cb) {
	if(users.length == 0) {
		var fileContent = fs.readFileSync(userFile);
		console.log('fileread: ' + fileContent)
		users = JSON.parse(fileContent.toString('utf8').replace(/^\uFEFF/, ''));
	}
	user.Id = guid();
	users.push(user);
	fs.writeFile(userFile, JSON.stringify(users), function(err) {
	    if(err) {
	        return console.log(err);
	    }

   	 	console.log("The file was saved!");
   	 	cb(null, user);
	}); 

}

exports.login = function (login, cb) {
	loadAllUsers(function(err, data) {
		var filter = data.filter(function(u) {
			return u.Username == login.Username && u.Password == login.Password
		})
		if(filter && filter.length >0) {
			cb(null, filter[0])
		}
		else{
			cb({err: 'not found'}, null);
		}
	})
}
