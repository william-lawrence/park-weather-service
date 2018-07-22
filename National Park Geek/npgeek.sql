
-- Switch to the system (aka master) database
USE master;
GO

-- Delete the NPGeek Database (IF EXISTS)
IF EXISTS(select * from sys.databases where name='NPGeek')
DROP DATABASE NPGeek;
GO

-- Create a new NPGeek Database
CREATE DATABASE NPGeek;
GO

-- Switch to the NPGeek Database
USE NPGeek
GO

BEGIN TRANSACTION;

create table park
(
	parkCode varchar(10) not null,
	parkName varchar(200) not null,
	state varchar(30) not null,
	acreage int not null,
	elevationInFeet int not null,
	milesOfTrail real not null,
	numberOfCampsites int not null,
	climate varchar(100) not null,
	yearFounded int not null,
	annualVisitorCount int not null,
	inspirationalQuote varchar(max) not null,
	inspirationalQuoteSource varchar(200) not null,
	parkDescription varchar(max) not null,
	entryFee int not null,
	numberOfAnimalSpecies int not null,
	weatherUrlSlice varchar(100),
	mapUrlSlice varchar(max),

	constraint pk_park primary key (parkCode)
);

CREATE TABLE weather
(
	parkCode varchar(10) not null,
	fiveDayForecastValue int not null,
	low int not null,
	high int not null,
	forecast varchar(100) not null,

	constraint pk_weather primary key (parkCode, fiveDayForecastValue),
	constraint fk_weather_park foreign key (parkCode) references park (parkCode)

);

CREATE TABLE survey_result
(
	surveyId int identity(1,1) not null,
	parkCode varchar(10) not null,
	emailAddress varchar(100) not null,
	state varchar(30) not null,
	activityLevel varchar(100) not null,
	
	constraint pk_survey_result primary key (surveyId),
	constraint fk_survey_result_park foreign key (parkCode) references park (parkCode)
);

INSERT park VALUES ('CVNP', 'Cuyahoga Valley National Park', 'Ohio', 32832, 696, 125, 0, 'Woodland', 2000, 2189849, 'Of all the paths you take in life, make sure a few of them are dirt.', 'John Muir', 'Though a short distance from the urban areas of Cleveland and Akron, Cuyahoga Valley National Park seems worlds away. The park is a refuge for native plants and wildlife, and provides routes of discovery for visitors. The winding Cuyahoga River gives way to deep forests, rolling hills, and open farmlands. Walk or ride the Towpath Trail to follow the historic route of the Ohio & Erie Canal.', 0, 390, '41d24n81d55/peninsula', '!1m18!1m12!1m3!1d191983.37525448226!2d-81.70947674810141!3d41.24921590572913!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8830de482229f575%3A0xcac9be4a7c9ee5aa!2sCuyahoga+Valley+National+Park!5e0!3m2!1sen!2sus!4v1532106287064');
INSERT park VALUES ('ENP', 'Everglades National Park', 'Florida', 1508538, 0, 35, 0, 'Tropical', 1934, 1110901, 'There are no other Everglades in the world. They are, they have always been, one of the unique regions of the earth; remote, never wholly known. Nothing anywhere else is like them.', 'Marjory Stoneman Douglas', 'The Florida Everglades, located in southern Florida, is one of the largest wetlands in the world. Several hundred years ago, this wetlands was a major part of a 5,184,000 acre watershed that covered almost a third of the entire state of Florida. The Everglades consist of a shallow sheet of fresh water that rolls slowly over the lowlands and through billions of blades of sawgrass. As water moves through the Everglades, it causes the sawgrass to ripple like green waves; this is why the Everglades received the nickname "River of Grass."', 8, 760, '25d47n80d48/homestead', '!1m18!1m12!1m3!1d922898.464501013!2d-81.51401508009091!3d25.368899057519005!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x88d0ab6ae2b1d795%3A0x1fc940aec720d93e!2sEverglades+National+Park%2C+Florida!5e0!3m2!1sen!2sus!4v1532106673359');
INSERT park VALUES ('GCNP', 'Grand Canyon National Park', 'Arizona', 1217262, 8000, 115, 120, 'Desert', 1919, 4756771, 'It is the one great wonders. . . every American should see.', 'Theodore Roosevelt', 'If there is any place on Earth that puts into perspective the grandiosity of Mother Nature, it is the Grand Canyon. The natural wonder, located in northern Arizona, is a window into the regio''s geological and Native American past. As one of the country''s first national parks, the Grand Canyon has long been considered a U.S. treasure, and continues to inspire scientific study and puzzlement.', 8, 450, '36d05n112d14/grand-canyon-village', '!1m18!1m12!1m3!1d825369.031362653!2d-113.40362574859743!3d36.09110442575191!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x873312ae759b4d15%3A0x1f38a9bec9912029!2sGrand+Canyon+National+Park!5e0!3m2!1sen!2sus!4v1532106697185');
INSERT park VALUES ('GNP', 'Glacier National Park', 'Montana', 1013322, 6646, 745.6, 923, 'Temperate', 1910, 2338528, 'Far away in northwestern Montana, hidden from view by clustering mountain peaks, lies an unmapped corner—the Crown of the Continent.', 'George Bird Grinnell', 'Glacier might very well be the most beautiful of America''s national parks. John Muir called it "the best care-killing scenery on the continent." The mountains are steep, snowcapped, and punctuated by stunning mountain lakes and creeks. Much of the land remains wild and pristine, a result of its remote location and the lack of visitation in the 19th century.  ', 12, 300, '48d49n113d98/west-glacier', '!1m18!1m12!1m3!1d674673.1474320606!2d-114.406305940027!3d48.65878940030032!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x5368901555555555%3A0xaf16bc2215c55dec!2sGlacier+National+Park!5e0!3m2!1sen!2sus!4v1532106765587');
INSERT park VALUES ('GSMNP', 'Great Smoky Mountains National Park', 'Tennessee', 522419, 6500, 850, 939, 'Temperate', 1934, 10099276, 'May your trails be crooked, winding, lonesome, dangerous, leading to the most amazing view. May your mountains rise into and above the clouds.', 'Edward Abbey', 'The Great Smoky Mountains are a mountain range rising along the Tennessee–North Carolina border in the southeastern United States. They are a subrange of the Appalachian Mountains, and form part of the Blue Ridge Physiographic Province. The range is sometimes called the Smoky Mountains and the name is commonly shortened to the Smokies. The Great Smokies are best known as the home of the Great Smoky Mountains National Park, which protects most of the range. The park was established in 1934, and, with over 9 million visits per year, it is the most-visited national park in the United States.', 0, 400, '35d71n83d51/gatlinburg', '!1m18!1m12!1m3!1d415347.7071323032!2d-83.81147853459309!3d35.58076217778525!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x885e986b88fb1815%3A0x3c926fc1a7752461!2sGreat+Smoky+Mountains+National+Park!5e0!3m2!1sen!2sus!4v1532106789845');
INSERT park VALUES ('GTNP', 'Grand Teton National Park', 'Wyoming', 310000, 6800, 200, 1206, 'Temperate', 1929, 2791392, 'We can not have freedom without wilderness.', 'Edward Abbey', 'The peaks of the Teton Range, regal and imposing as they stand nearly 7,000 feet above the valley floor, make one of the boldest geologic statements in the Rockies. Unencumbered by foothills, they rise through steep coniferous forest into alpine meadows strewn with wildflowers, past blue and white glaciers to naked granite pinnacles. The Grand, Middle, and South Tetons form the heart of the range. But their neighbors, especially Mount Owen, Teewinot Mountain, and Mount Moran, are no less spectacular.', 15, 380, '43d66n110d72/moose', '!1m18!1m12!1m3!1d368555.34927994135!2d-110.968707445196!3d43.807334188730884!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x5352519ec95d1ba9%3A0xa5a0b88ecc91a337!2sGrand+Teton+National+Park!5e0!3m2!1sen!2sus!4v1532106818211');
INSERT park VALUES ('MRNP', 'Mount Rainier National Park', 'Washington', 236381, 5500, 260, 573, 'Rainforest', 1899, 1038229, 'Of all the fire mountains which like beacons, once blazed along the Pacific Coast, Mount Rainier is the noblest.', 'Unknown', 'Mt. Rainier National Park is one of three national parks in the state of Washington and is one of America''s oldest parks, being one of only five founded in the 19th century. The park was created to preserve one of America''s most spectacular scenic wonders, the snow-capped volcano known as Tahcoma to Indians in ages past and as Mt. Rainier now. While the mountain is unquestionably the centerpiece of the park, its 235,612 acres (378 square miles) also contain mountain ranges, elaborate glaciers, rivers, deep forests, lush meadows covered with wildflowers during the summer, and over 300 miles of trails. 96% of the park is classified as wilderness.', 20, 280, '46d76n122d03/ashford', '!1m18!1m12!1m3!1d349207.4621272165!2d-121.99511429728673!3d46.85976511955594!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x5490cde6eec94b87%3A0x5cf4a1fb4f91a418!2sMount+Rainier+National+Park!5e0!3m2!1sen!2sus!4v1532106836378');
INSERT park VALUES ('RMNP', 'Rocky Mountain National Park', 'Colorado', 265761, 7800, 300, 660, 'Woodland', 1915, 3176941, 'It''s not the mountain we conquer, but ourselves.', 'Sir Edmund Hillary', 'Rocky Mountain National Park is one of the highest national parks in the nation, with elevations from 7,860 feet to 14,259 feet. Sixty mountain peaks over 12,000 feet high result in world-renowned scenery. The Continental Divide runs north - south through the park, and marks a climatic division. Ancient glaciers carved the topography into an amazing range of ecological zones. What you see within short distances at Rocky is similar to the wider landscape changes seen on a drive from Denver to northern Alaska.', 20, 360, '40d38n105d52/estes-park', '!1m18!1m12!1m3!1d389201.5592435785!2d-105.95667461471754!3d40.35039388738717!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x876979e4455903e9%3A0xfa27ee43a78e8217!2sRocky+Mountain+National+Park!5e0!3m2!1sen!2sus!4v1532106903507');
INSERT park VALUES ('YNP', 'Yellowstone National Park', 'Wyoming', 2219791, 8000, 900, 1900, 'Temperate', 1872, 3394326, 'Yellowstone Park is no more representative of America than is Disneyland.', 'John Steinbeck', 'Yellowstone National Park is a protected area showcasing significant geological phenomena and processes. It is also a unique manifestation of geothermal forces, natural beauty, and wild ecosystems where rare and endangered species thrive. As the site of one of the few remaining intact large ecosystems in the northern temperate zone of earth, Yellowstone’s ecological communities provide unparalleled opportunities for conservation, study, and enjoyment of large-scale wildland ecosystem processes.', 15, 390, '44d43n110d59/yellowstone-national-park', '!1m18!1m12!1m3!1d727453.6986585216!2d-111.0745224586646!3d44.58442465862721!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x5351e55555555555%3A0xaca8f930348fe1bb!2sYellowstone+National+Park!5e0!3m2!1sen!2sus!4v1532106930114');
INSERT park VALUES ('YNP2', 'Yosemite National Park', 'California', 747956, 5000, 800, 1720, 'Forest', 1890, 3882642, 'Yosemite Valley, to me, is always a sunrise, a glitter of green and golden wonder in a vast edifice of stone and space.', 'Ansel Adams', 'Yosemite National Park vividly illustrates the effects of glacial erosion of granitic bedrock, creating geologic features that are unique in the world. Repeated glaciations over millions of years have resulted in a concentration of distinctive landscape features, including soaring cliffs, domes, and free-falling waterfalls. There is exceptional glaciated topography, including the spectacular Yosemite Valley, a 914-meter (1/2 mile) deep, glacier-carved cleft with massive sheer granite walls. These geologic features provide a scenic backdrop for mountain meadows and giant sequoia groves, resulting in a diverse landscape of exceptional natural and scenic beauty.', 15, 420, '37d75n119d59/yosemite-valley', '!1m18!1m12!1m3!1d403240.0037355467!2d-119.83130741818239!3d37.85297713638047!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x8096f09df58aecc5%3A0x2d249c2ced8003fe!2sYosemite+National+Park!5e0!3m2!1sen!2sus!4v1532106948131');



INSERT INTO weather VALUES ('GNP',1,27,40,'snow');
INSERT INTO weather VALUES ('GNP',2,31,43,'snow');
INSERT INTO weather VALUES ('GNP',3,28,40,'partly cloudy');
INSERT INTO weather VALUES ('GNP',4,24,34,'cloudy');
INSERT INTO weather VALUES ('GNP',5,25,32,'snow');
INSERT INTO weather VALUES ('GCNP',1,35,66,'sunny');
INSERT INTO weather VALUES ('GCNP',2,34,69,'partly cloudy');
INSERT INTO weather VALUES ('GCNP',3,32,57,'rain');
INSERT INTO weather VALUES ('GCNP',4,34,62,'sunny');
INSERT INTO weather VALUES ('GCNP',5,31,62,'partly cloudy');
INSERT INTO weather VALUES ('GTNP',1,27,46,'cloudy');
INSERT INTO weather VALUES ('GTNP',2,30,49,'partly cloudy');
INSERT INTO weather VALUES ('GTNP',3,31,46,'rain');
INSERT INTO weather VALUES ('GTNP',4,28,41,'rain');
INSERT INTO weather VALUES ('GTNP',5,22,38,'snow');
INSERT INTO weather VALUES ('MRNP',1,23,30,'snow');
INSERT INTO weather VALUES ('MRNP',2,24,32,'snow');
INSERT INTO weather VALUES ('MRNP',3,21,27,'snow');
INSERT INTO weather VALUES ('MRNP',4,23,27,'snow');
INSERT INTO weather VALUES ('MRNP',5,21,25,'snow');
INSERT INTO weather VALUES ('GSMNP',1,58,70,'partly cloudy');
INSERT INTO weather VALUES ('GSMNP',2,56,70,'thunderstorms');
INSERT INTO weather VALUES ('GSMNP',3,56,74,'cloudy');
INSERT INTO weather VALUES ('GSMNP',4,53,68,'thunderstorms');
INSERT INTO weather VALUES ('GSMNP',5,52,66,'thunderstorms');
INSERT INTO weather VALUES ('ENP',1,70,82,'partly cloudy');
INSERT INTO weather VALUES ('ENP',2,70,81,'partly cloudy');
INSERT INTO weather VALUES ('ENP',3,70,81,'partly cloudy');
INSERT INTO weather VALUES ('ENP',4,71,82,'thunderstorms');
INSERT INTO weather VALUES ('ENP',5,70,85,'sunny');
INSERT INTO weather VALUES ('YNP',1,23,43,'cloudy');
INSERT INTO weather VALUES ('YNP',2,26,47,'partly cloudy');
INSERT INTO weather VALUES ('YNP',3,25,44,'sunny');
INSERT INTO weather VALUES ('YNP',4,21,37,'snow');
INSERT INTO weather VALUES ('YNP',5,16,36,'snow');
INSERT INTO weather VALUES ('YNP2',1,34,51,'partly cloudy');
INSERT INTO weather VALUES ('YNP2',2,25,39,'snow');
INSERT INTO weather VALUES ('YNP2',3,29,40,'sunny');
INSERT INTO weather VALUES ('YNP2',4,32,38,'snow');
INSERT INTO weather VALUES ('YNP2',5,23,34,'snow');
INSERT INTO weather VALUES ('CVNP',1,38,62,'rain');
INSERT INTO weather VALUES ('CVNP',2,38,56,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',3,51,66,'partly cloudy');
INSERT INTO weather VALUES ('CVNP',4,55,65,'rain');
INSERT INTO weather VALUES ('CVNP',5,53,69,'thunderstorms');
INSERT INTO weather VALUES ('RMNP',1,30,47,'sunny');
INSERT INTO weather VALUES ('RMNP',2,35,55,'sunny');
INSERT INTO weather VALUES ('RMNP',3,34,50,'partly cloudy');
INSERT INTO weather VALUES ('RMNP',4,33,47,'partly cloudy');
INSERT INTO weather VALUES ('RMNP',5,30,43,'rain');

COMMIT;