var fs = require('fs'),
	FileQueue = require('../helpers/filequeue/FileQueue'),
	stories,
	fullStories = [],
	genresList,
	genresCache = {};


var fq = new FileQueue(100);

var data_root = 'E:\\uptruyen.com\\';

data_root = 'C:\\Users\\truong.n.nguyen\\Desktop\\uptruyen.com\\';

function readStories(cb) {
	if(stories == null) {
		fs.readFile(data_root +'stories.json',  function(err, data) {
				stories = JSON.parse(data.toString('utf8').replace(/^\uFEFF/, ''))
				for (var i = stories.length - 1; i > 0; i--) {
					 fq.readFile(data_root + stories[i].JsonFileName, {encoding: 'utf8'}, function(err, fileContent) {
					 	var s = JSON.parse(fileContent.toString('utf8').replace(/^\uFEFF/, ''));
					 	s.ChapterCount = s.Chapters.length;

				      	fullStories.push(s);

				    });
				};
				
				cb(err, stories)
			});
	}
	else{
		cb(null, fullStories);
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
function readStoryInfoSync(dataFile) {
	var data = fs.readFileSync(data_root +dataFile); 
	var s = JSON.parse(data.toString('utf8').replace(/^\uFEFF/, ''));
	return s;
			
}

// Write the callback function
function handleFile(err, data) {
    if (err) throw err
    stories = JSON.parse(data)
    // You can now play with your datas
}

exports.genreStories = function(name, page, cb) {
	if(genresCache[name]) {
		var PageSize = 50;
		var s = genresCache[name].Stories;
		var PageCount  = Math.ceil(s.length/ PageSize)
		cb(null,  {
			TotalItems : s.length,
			Stories: s.slice(page * PageSize,  page *PageSize + PageSize),
			PageSize: PageSize,
			PageCount: PageCount
		});

	}
	cb(null, {})
}
exports.genres = function(cb) {
    if (genresList && genresList.length >0)  { cb(null,genresList); }
    readStories(function(err, data) {
        genresList = new Array();
         genresCache = {};
        data.forEach(function(s) {
            s.Categories = s.Categories || [];
            s.Categories.forEach(function(c) {
            
                if (!genresCache[c]) {
                    genresCache[c] =  {
                    	Name:c,
                    	Stories: [],
                    };
                }

                genresCache[c].Stories.push(s)

        	})
        });

        for (var x in genresCache) {
        	//console.log(x + " :" +temp[x]);
            genresList.push({
                Name: x,
                StoriesCount: genresCache[x].Stories.length
            });
        }

        cb(null,genresList)
    });
}


exports.randoms = function(number,cb) {
  number = number || 1;
  var list = new Array();
  readStories(function(err, data) {
  	for (var i = 0; i < number; i++) {
  		var index = Math.round(data.length * Math.random());
  		var story = data[index];	
  		list.push(readStoryInfoSync(story.JsonFileName));
  	};

  	if(number == 1) { cb(null, list[1])}
  		else{
  			cb(null, list)
  		}
  })
  
}

//stories = require(data_root+'stories.json')

exports.random = function(cb) {
  readStories(function(err, data) {
  	var index = Math.round(data.length * Math.random());
  	var story = data[index];
  	readStoryInfo(story.JsonFileName, cb);
  })
  
}

exports.getTop10 = function(number, cb) {
  readStories(function(err, data) {
  	var sorted = data.sort(function(x,y) {
  			return y.ChapterCount - x.ChapterCount;

  	}).slice(1, number);
  	sorted.forEach(function(s) {
  		s = readStoryInfoSync(s.JsonFileName);
  	})

  	cb(null,sorted);
  })
  
}

function toPaged(list, pageIndex, pageSize) {
	var pageCount = Math.ceil(list.length / pageSize);
	return {
			TotalItems : list.length,
			Stories: list.slice(pageIndex * pageSize,  pageIndex *pageSize + pageSize),
			PageSize: pageSize,
			PageCount: pageCount
		};
}
exports.all = function(name, page,cb) {
  var pageSize = 50;
  readStories(function(err, data) {
  	if(name == 'All') {
  		cb(null, toPaged(data, page, pageSize));
  	}
  	else{
  			console.log('filtered: ' + name);
  		var filtered = data.filter(function(s) {return s.Group ==name});

  		cb(null, toPaged(filtered, page, pageSize));	
	}
  })
cb(null,  { name:name, page: page});
  
}
exports.storyInfo = function(name, cb) {
	readStories(function(err, data) {

		filter = data.filter(function(s)  { return s.Name == name})[0];
		cb(null, readStoryInfoSync(filter.JsonFileName));

	});		
}

exports.chapInfo = function(storyName, chapName, cb) {
	//storyName = storyName.replace('%20',' ')
	//chapName =chapName.replace('%20',' ')
	chapName = decodeURIComponent(chapName)
	storyName = decodeURIComponent(storyName)
	readStories(function(err, data) {
		if(err) cb(err, null)

		console.log('Story: ' + storyName )
		console.log('CHap : ' + chapName);
		filter = data.filter(function(s)  { return s.Name == storyName})[0];
		var story = readStoryInfoSync(filter.JsonFileName);
		var chap = story.Chapters.filter(function(c) {return c.Name == chapName})[0]
		chap = readStoryInfoSync(chap.JsonFileName);

		cb(null,  {
			Name: chap.Name,
			Story: story,
			Pages: chap.Pages
		});
	});		
}


