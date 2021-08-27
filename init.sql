﻿DROP TABLE lyrics;
DROP TABLE song;
DROP TABLE genre;
DROP TABLE album;
DROP TABLE artist;
DROP TABLE serveruser;

CREATE TABLE serveruser(
	user_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT user_pk PRIMARY KEY DEFAULT NEWID(),
	username VARCHAR(128) NOT NULL UNIQUE,
	hash CHAR(256) NOT NULL,
	salt CHAR(64) NOT NULL,
	role CHAR(32) NOT NULL,
	creation_time TIMESTAMP
);

CREATE TABLE artist(
	artist_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT artist_pk PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(128) NOT NULL,
	creation_time TIMESTAMP
);

CREATE TABLE album(
	album_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT album_pk PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(128) NOT NULL,
	number_of_tracks INTEGER,
	year INTEGER,
	cover VARCHAR(512),
	artist_id UNIQUEIDENTIFIER 
	CONSTRAINT album_fk_artist_id REFERENCES artist(artist_id),
	creation_time TIMESTAMP
);

CREATE TABLE genre(
	genre_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT genre_pk PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(128) NOT NULL
);

CREATE TABLE song(
	song_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT song_pk PRIMARY KEY DEFAULT NEWID(),
	name VARCHAR(128) NOT NULL,
	album_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT song_fk_album_id REFERENCES album(album_id),
	genre_id UNIQUEIDENTIFIER 
	CONSTRAINT song_fk_genre_id REFERENCES genre(genre_id),
	creation_time TIMESTAMP
);

CREATE TABLE lyrics(
	lyrics_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT lyrics_pk PRIMARY KEY DEFAULT NEWID(),
	text VARCHAR(MAX) NOT NULL,
	user_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT lyrics_fk_user_id REFERENCES serveruser(user_id),
	song_id UNIQUEIDENTIFIER NOT NULL
	CONSTRAINT lyrics_fk_song_id REFERENCES song(song_id),
	creation_time TIMESTAMP
);

INSERT INTO serveruser(user_id, username, hash, salt, role) VALUES
('00000000-0000-0000-0000-000000000000', 'db', '0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000', '0000000000000000000000000000000000000000000000000000000000000000', 'ADMIN');



SELECT * FROM serveruser;
SELECT * FROM artist;
SELECT * FROM album;
SELECT * FROM genre;
SELECT * FROM song;
SELECT * FROM lyrics;