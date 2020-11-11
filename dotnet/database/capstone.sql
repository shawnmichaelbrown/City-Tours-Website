USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE landmarks (
	landmark_id int IDENTITY(1,1) NOT NULL,
	landmark_name varchar(50) NOT NULL,
	landmark_address varchar(200) NOT NULL,
	landmark_description varchar(255),
)
CREATE TABLE itineraries (
	id int IDENTITY (1,1) NOT NULL,
	user_id int NOT NULL,
	itinerary_name varchar(100) NOT NULL,
	starting_address varchar(255) NOT NULL,
	locations varchar(255)
FOREIGN KEY (user_id) REFERENCES users(user_id) 
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Ohio Stadium','411 Woody Hayes Dr, Columbus, OH 43210','OSU football stadium');
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Thurber House','77 Jefferson Ave, Columbus, OH 43215','Writers House');
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Columbus Zoo and Aquarium','4850 West Powell Road Powell OH 43065','Worlds Best Zoo');
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('North Market','59 Spruce St, Columbus, OH 43215','8 different types of chinese food');
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('COSI', '333 W Broad St, Columbus, OH 43215', 'Sciency stuff')
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Columbus Museum of Art', '480 E Broad St, Columbus, OH 43215', 'Arty stuff')
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Franklin Park Conservatory', '1777 E Broad St, Columbus, OH 43205', 'Bountiful trees for all to enjoy')
INSERT INTO landmarks (landmark_name, landmark_address, landmark_description) VALUES ('Main Street Bridge (Columbus, Ohio)', '303 W Main StColumbusOH43215', 'Great view')

GO