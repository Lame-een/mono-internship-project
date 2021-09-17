DELETE FROM lyrics;
DELETE FROM song;
DELETE FROM genre;
DELETE FROM album;
DELETE FROM artist;

INSERT INTO genre (name) VALUES ('Pop');
INSERT INTO genre (name) VALUES ('J-Pop');
INSERT INTO genre (name) VALUES ('J-Rock');
INSERT INTO genre (name) VALUES ('K-Pop');
INSERT INTO genre (name) VALUES ('Hip Hop');
INSERT INTO genre (name) VALUES ('Experimental hip hop');
INSERT INTO genre (name) VALUES ('Progressive');
INSERT INTO genre (name) VALUES ('Alternative');
INSERT INTO genre (name) VALUES ('Rock and Roll');
INSERT INTO genre (name) VALUES ('Blues');
INSERT INTO genre (name) VALUES ('Alternative rock');
INSERT INTO genre (name) VALUES ('EDM');
INSERT INTO genre (name) VALUES ('Techno');
INSERT INTO genre (name) VALUES ('House');
INSERT INTO genre (name) VALUES ('Future house');
INSERT INTO genre (name) VALUES ('Future bass');
INSERT INTO genre (name) VALUES ('Electro house');
INSERT INTO genre (name) VALUES ('Electro');
INSERT INTO genre (name) VALUES ('Trap');
INSERT INTO genre (name) VALUES ('Chill trap');
INSERT INTO genre (name) VALUES ('Chill');
INSERT INTO genre (name) VALUES ('Trance');
INSERT INTO genre (name) VALUES ('Glitch Hop');
INSERT INTO genre (name) VALUES ('Dubstep');
INSERT INTO genre (name) VALUES ('Drum and bass');
INSERT INTO genre (name) VALUES ('Synth');
INSERT INTO genre (name) VALUES ('Grunge');
INSERT INTO genre (name) VALUES ('Metal');
INSERT INTO genre (name) VALUES ('Black metal');
INSERT INTO genre (name) VALUES ('Death metal');
INSERT INTO genre (name) VALUES ('Speed metal');
INSERT INTO genre (name) VALUES ('Power metal');
INSERT INTO genre (name) VALUES ('Indie');
INSERT INTO genre (name) VALUES ('Indie pop');
INSERT INTO genre (name) VALUES ('Gospel');


INSERT INTO artist (name, creationTime) VALUES ('Foo Fighters', '20210902 00:00:00');
INSERT INTO artist (name, creationTime) VALUES ('Kanye West', '20210902 00:00:00');
INSERT INTO artist (name, creationTime) VALUES ('FewJar', '20210902 00:00:00');
INSERT INTO artist (name, creationTime) VALUES ('EDEN', '20210902 00:00:00');
INSERT INTO artist (name, creationTime) VALUES ('Pegboard Nerds', '20210902 00:00:00');

INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('Donda', 27, 2021, (SELECT artistID FROM artist WHERE name = 'Kanye West'), '20210902 00:00:00', 'https://static.highsnobiety.com/thumbor/f6U8VHJqMd7h72Ldu6ATFKNvLYc=/1600x1067/static.highsnobiety.com/wp-content/uploads/2021/08/18122835/kanye-west-donda-album-cover-02.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('The Colour and the Shape', 13, 1997, (SELECT artistID FROM artist WHERE name = 'Foo Fighters'), '20210902 00:00:00', 'https://images-na.ssl-images-amazon.com/images/I/61kk%2BSr75BL._SL1500_.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('AFewSides', 12, 2013, (SELECT artistID FROM artist WHERE name = 'FewJar'), '20210902 00:00:00', 'https://f4.bcbits.com/img/a3016905903_10.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('Gamma', 8, 2018, (SELECT artistID FROM artist WHERE name = 'FewJar'), '20210902 00:00:00', 'https://images-na.ssl-images-amazon.com/images/I/712tuJS57ML._SL1200_.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('Badboi', 1, 2014, (SELECT artistID FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00', 'https://i1.sndcdn.com/artworks-000088442109-7jcbju-t500x500.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('Nerds by Nature', 6, 2017, (SELECT artistID FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00', 'https://f4.bcbits.com/img/a2466451685_10.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('End Credits', 7, 2015, (SELECT artistID FROM artist WHERE name = 'EDEN'), '20210902 00:00:00', 'https://upload.wikimedia.org/wikipedia/en/1/1d/End_Credits_by_EDEN-Official%2CDecember2015.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('i think you think too much of me', 7, 2016, (SELECT artistID FROM artist WHERE name = 'EDEN'), '20210902 00:00:00', 'https://img.discogs.com/u-YYIpKHykh9xelJAUN9LGWaiOw=/fit-in/600x600/filters:strip_icc():format(jpeg):mode_rgb():quality(90)/discogs-images/R-8938708-1471863091-1189.jpeg.jpg');


INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('02:09', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('End Credits', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Gravity', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Nocturne', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Interlude', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Wake Up', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('catch me if you can', (SELECT albumID FROM album WHERE name = 'End Credits'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('sex', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('drugs', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('and', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('rock + roll', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Fumes', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('XO', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Circles', (SELECT albumID FROM album WHERE name = 'i think you think too much of me'), (SELECT genreID FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Speed of Light', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Chill'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Melodymania', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Electro house'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Talk About It (feat. Desirée Dawson)', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Future bass'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Go Berzerk (with Quiet Disorder)', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Dubstep'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('BAMF', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Dubstep'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Blackout', (SELECT albumID FROM album WHERE name = 'Nerds By Nature'), (SELECT genreID FROM genre WHERE name = 'Future house'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Badboi', (SELECT albumID FROM album WHERE name = 'Badboi'), (SELECT genreID FROM genre WHERE name = 'Trap'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Cepheus', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Bale In Your Pocket', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Chalkbird (feat. Lara Hamzehpour)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Anatom, Problem 1', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('S.p.a.m. (feat. Tommy Blackout)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Control, Problem 2 (Andre Moghimi Rework)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Tapirsupper', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('A Billion (feat. Tell You What Now)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Absolution', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Polemonium (feat. Frodo)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Gluttony, Problem 3 (feat. SpaceApparat)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Risen To A Flood (feat. Andre Moghimi)', (SELECT albumID FROM album WHERE name = 'AFewSides'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Skeleton', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Gamma', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('How Many of You Are in There?', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Of Nothing', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Structured', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Despite This', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('(This is Not) Worth it', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Treasure', (SELECT albumID FROM album WHERE name = 'Gamma'), (SELECT genreID FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Doll', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Monkey Wrench', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Hey, Johnny Park!', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('My Poor Brain', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Wind Up', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Up in Arms', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('My Hero', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('See You', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Enough Space', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('February Stars', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Everlong', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Walking After You', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('New Way Home', (SELECT albumID FROM album WHERE name = 'The Colour and the Shape'), (SELECT genreID FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Donda Chant', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Jail', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('God Breathed', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Off the Grid', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Hurricane', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Praise God', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Gospel'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Jonah', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Ok Ok', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Junya', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Believe What I Say', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('24', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Remote Control', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Moon', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Chill'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Heaven and Hell', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Donda', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Keep My Spirit Alive', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Jesus Lord', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Gospel'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('New Again', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Tell the Vision', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Lord I Need You', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Pure Souls', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Come to Life', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('No Child Left Behind', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Jail, Pt. 2', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Ok Ok, Pt. 2', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Junya, Pt. 2', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, albumID, genreID, creationTime) VALUES
('Jesus Lord, Pt. 2', (SELECT albumID FROM album WHERE name = 'Donda'), (SELECT genreID FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');


INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('If you fall, I''ll catch you

So I''ve been thinking ''bout something
Lately I''ve been alive
Cause I found my reason in nothing
So I won''t close my eyes
Cause I don''t want to miss one second
And I don''t want to feel so cold
And I don''t want to be so sad that we are who we are
Cause we had no control

But only by the night
Will we ever make headlines
Will we ever make things right
When we''ve only ourselves to blame
When we''ve only ourselves to blame

So I won''t sleep
No more
No I won''t sleep
No more
I won''t sleep
I always thought that there''d be more than just wishing
No more
My life away
No DMT will stop me
Like I could always
Figure it out and never have to abandon what''s in-front of me
Dream

No more

So get this doubt out of my head
It''s only real if you let it
And I''ve been letting go of my ghosts
I''ll never let them catch me no more
But these words are all I have
So I''ll just keep dreaming out loud
And if I just keep talking
Maybe I''ll figure all this out

But only by the night
Will we ever make headlines
Will we ever make things right
When we''ve only ourselves to blame
When we''ve only ourselves to blame

So I won''t sleep
No more
No I won''t sleep
No more
No I won''t sleep
I always thought that there''d be more than just wishing
No more
My life away
No DMT will stop me
Like I could always
Figure it out and never have to abandon what''s in-front of me
Dream

No more (source azlyrics.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Nocturne'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('What have we done with innocence?
It disappeared with time, it never made much sense
Adolescent resident
Wasting another night on planning my revenge

One in ten
One in ten
One in ten

Don''t want to be your monkey wrench
One more indecent accident
I''d rather leave than suffer this
I''ll never be your monkey wrench

All this time to make amends
What do you do when all your enemies are friends?
Now and then I''ll try to bend
Under pressure, wind up snapping in the end

One in ten
One in ten
One in ten

Don''t want to be your monkey wrench
One more indecent accident
I''d rather leave than suffer this
I''ll never be your monkey wrench

Temper
Temper
Temper

One last thing before I quit
I never wanted any more than I could fit
Into my head
I still remember every single word you said
And all the shit that somehow came along with it
Still there''s one thing that comforts me
Since I was always caged and now I''m free

Don''t want to be your monkey wrench
One more indecent accident
I''d rather leave than suffer this
I''ll never be your monkey wrench

Don''t want to be your monkey wrench (fall in, fall out)
Don''t want to be your monkey wrench (fall in, fall out)
Don''t want to be your monkey wrench (fall in, fall out)
Don''t want to be your monkey wrench (source azlyrics.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Monkey Wrench'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Bad motherf-, bad motherf-
Bad motherf-, bad motherf-
Bad motherf-, bad motherf- (C''mon)
Bad motherf-, bad motherf- (Mother fucker I''m-)
Mother fucker I''m-

(Bad, bad, bad)

Mother fucker I''m-

(Bad, bad, bad)

Bad motherf-, bad motherf-
Bad motherf-, bad motherf-
Mother fucker I''m-

Hands up
(Bad, bad)

Hands up (source genius.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'BAMF'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Embraced
By the signs of zaconiac
Behold her
Relieve her
Mother
Father

How did I end up here, stone bound?
All I feel is the striking distance to the clouds
My flesh is fettered on the skin of the soil
But even so I almost reach the sparks in the void
Sailing through the vakuum, am I drowned or alive?

The lights are moving on, go around, come inside over my head
I know, I know
That the time, it will be low, they invade, cause they need, what I have
Behold, behold me

Like father Cepheus
In the night of oblivion
While the waiting for erasure
I skip my earthly tied conscience
Sail to light cataracts
Move into the luminary
Attend nemesis, the last act

So I vanish from the line of your sprout
No need to retain me, I was cursed as you (we)''re crowned

Like father Cepheus
In the night of oblivion
While the waiting for erasure
I skip my earthly tied conscience
Sail to light cataracts
Move into the luminary
Attend nemesis, the last act (source genius.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Cepheus'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Download failed
End of a viral tale
Runs down our throat
Heading the blind alley
I''m begging you advertise me
Cause I had been swallowed (ah)
Dropped in their sated lungs
Stuck in fictitious grunge
Laser signs on a cryptic shrine
Stunning pyramid like
And it''s trying to catch us
By the night keep adrenalized
Watch opportunities rise
And we''re trying to catch it

Uuuuhhhh
While the world''s mouth is wide open

Atomized in my lidless eye
A scream of a faintest light
And while the words explain themselves
They vanish from our sight
Pealed from our lactic callus

[Tommy Blackout]
Die helle Scheibe rutscht aus dem Bildrand des Displays
Bunte Fixsterne bilden die Pixel meines Sichtfelds
Willkommen in der Neonwelt - Betaversion
Halogen leuchtet aus dem gläsernen Mond

Ich steige aus dem Straßenzug, halte meine Nase zu
Synthetischer Staub, schmerzt bei jedem Atemzug
Mein Adblocker defekt, mein Spamordner gecrackt
Der Trojaner setzt den Sprengkoffer perfekt

Die Firewall bricht ein, das Lichtermeer kommt näher
Und richtet seinen Laser in die Richtung meines Herz
Neonwellen brechen an den Klippen meiner Netzhaut
Mein Geist wird überschwemmt - (Blackout), (Blackout), Blackout

Bits, Bytes, Clicks, Likes prasseln auf mein Nervenkleid
Es gibt kein Mitleid, nur die Tasten um den Schmerz zu teilen
Ich bin von Lärm umgeben, höre auf zu reden
In dieser Zeile könnte ihre Werbung stehen

Gall of a thousand colors
On a tongue of a million bladders
And it etches its way
Through the plenty open gates
Of your unfullfilled perception

Gall of a thousand colors
On a tongue of a million bladders
And it etches its way
Through the plenty open gates
Of your unfullfilled perception

Atomized in my lidless eye
A scream of a faintest light
And while the words explain themselves
They vanish from our sight
Pealed from our lactic callus 

Atomized in my lidless eye
A scream of a faintest light
And while the words explain themselves
They vanish from our sight
Pealed from our lactic callus 

Whhhhhy,
Paaaaraaaaaliiiiized!!
Adreeeenaaaaaliiiiized! (source genius.com & musixmatch.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'S.p.a.m. (feat. Tommy Blackout)'), '20210902 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('See this in 3D, all lights out for me
All lights out for me, lightning strikes the beach
Eighty degrees, warm it up for me
Finally free, found the God in me
And I want you to see, I can walk on water
Thousand miles from shore, I can float on the water
Father, hold me close, don''t let me drown
I know you won''t

Yeah, walkin'' on the bridge, I threw my sins over the deep end
Sippin'' ''til my stomach hurt, this month I done lost three friends
Early mornin'', brainstormin'', normally I can''t sleep in
Sometimes I just wanna restart it, but it all depends
If I''ma be that same young, hungry **** from West End
Wrote my hardest wrongs and the crazy part, I ain''t have no pen
Maybach interior camе with sheepskin
Still remember whеn I just had three bands
Now I''m the one everyone call on ''cause I got deep pants
Bro told me to wait to beat the game, it''s only defense and
Never fazed by names that they might call me, but they gon'' respect
And I feel like you better off tryin'' to call, I might not get the message
She just tried to run off with my heart, but I blocked off the exit, yeah

Oh-oh, I know You won''t (I know You won''t)
I know You won''t (Oh, yeah, oh, yeah, yeah, yeah)
I know You won''t
I know that You look over us (I know)
So we silently sleep
Bring down the rain, yeah, oh
[Verse 2: Kanye West]
Mm-mm-mm-mm-mm, I was out for self
Mm-mm-mm-mm-mm, I was up for sale, but I couldn''t tell
God made it rain, the devil made it hail
Dropped out of school, but I''m that one at Yale
Made the best tracks and still went off the rail
Had to go down, down, down, this the new town, town, town
This the new ten, ten, ten, I''m goin'' in, in, in
Here I go on a new trip, here I go actin'' too lit
Here I go actin'' too rich, here I go with a new chick
And I know what the truth is, still playin'' after two kids
It''s a lot to digest when your life always movin''
Architectural Digest, but I needed home improvement
Sixty-million-dollar home, never went home to it
Genius gone clueless, it''s a whole lot to risk
Alcohol anonymous, who''s the busiest loser?
Heated by the rumors, read into it too much
Fiendin'' for some true love, ask Kim, "What do you love?"
Hard to find what the truth is, but the truth was that the truth suck
Always seem to do stuff, but this time it was too much
Mm-mm-mm-mm-mm, everybody so judgemental
Everybody so judgemental
Everybody hurts, but I don''t judge rentals
Mm-mm-mm-mm-mm, it was all so simple


I see you in 3D, the dawn is bright for me
No more dark for me, I know You''re watchin'' me
Eighty degrees, burnin'' up the leaves
Finally, I''m free, finally, I''m free
As I go out to sea, I can walk on water
Won''t you shine Your light? Demons stuck on my shoulder
Father, hold me close, don''t let me drown
I know You won''t source genius.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Hurricane'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Speed of light (ohhhh- Ohhh- ohhhh-ohh)
Ohhhh
Speed of light
Ohhh
Speed of light
Ohhh
Speed of light
Ohhh
Catch me, Catch me
Catch me, Catch me
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
(Background singing)
Speed of light
Speed of light
Speed of light
Speed of light
(Background singing)
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
Speed of light
I cant slow down, i cant slooow down
I cant slow down, im at the speed of light
At the speed of light.
Im at the speeeed of light
At the speed of liiight
Im at the speed of light
Cant
Slow
Down
Now (source: genius.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Speed of Light'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('I wanted you to be the last thing on my mind
I wanted you to be the reason I close my eyes
But I can''t sleep
And oh God, I wanted to be your high
But everything I said, went unheard
And everything you saw
With eyes straight blurred became our downfall
''Cause you say I drink
And I smoke, and I talk too much
But I know you lied
When you said you just gotta go and save yourself
So hear me out
You know everybody talks girl
And it means nothing ''til you let it
But if you keep second guessing
Then there''s only gonna be one end
But you can leave, if you really want to
And you can run, if you feel you have to
Now I''ll be fine, if you ever ask me
I know it''s hard, but no one said it''s easy
Falling''s easy
But there''s only one way up
So, I''ve been thinking that I think too much
And I can''t sleep, but I can dream of us
And I''ve been seeing shit, like horror cuts
It''s burning down, I gotta drown this out
And you said you need me to let this go
But it''s who I am, or am I just losing it
''Cause you said jump and I went first
But falling''s always been my downfall
And you say I drink
And I smoke, and I talk too much
But I know you lied
When you said that you just had enough and save yourself
So hear me out
You know everybody talks girl
And it means nothing ''til you let it
And if you keep second guessing
Then there''s only gonna be one end
But you can leave, if you really want to
And you can run, if you feel you have to
And I can drink, if I feel I have to
I know it''s hard, but I can''t feel like I used to
Like I used to
''Cause I used to, defy gravity
Defy gravity
Goodbyes keep dragging me down
And I''m fighting gravity
Defying gravity
I tried, but I keep falling
''Cause falling''s easy
But it only brings you down (source: musixmatch.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Gravity'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('And I said, what''s up?
What you been thinking?
''Cause you''ve been staring at that roof so long I''d swear it''s come alive
And she spoke nine words
And now we''re sinking
But I can''t find it in myself to want to lie to keep this thing from going down
''Cause that girl took my heart
And I ain''t want it back
No
I''m laying down my cards
''Cause you said it meant nothing
And I should''ve kept my silence
But I guess I''m too attached to my own pride to let you know
That all these words meant nothing
And I''ve always been this heartless
And we were just having sex no I would never call it love
But love
Oh no, I think I''m catching feelings
And I don''t know if this is empathy I feel
Just hold on
Remember why you said this was the last time?
So I guess it''s...
Let die to let live
And what''s good
When both choices I''ve got have us staring down the barrel to the bullets I can''t stop?
And so I stand off
Like indecision''s Kevlar
''Til this fear of feeling stops and I''m done
But you
No, I don''t know how to forget you
No, I don''t know how to forget you
No, I don''t know how to forget you
No, I don''t know how to forget you
''Cause that girl took my heart
(No, I don''t know how to forget you)
And I ain''t want it back, no
(No, I don''t know how to forget you)
A bulletproof restart
Oh no, I think I''m catching feelings and
I don''t know if this is empathy I feel
Just hold on
Remember why you said this was the last time?
So I guess it''s...
Let die to let live
No, I don''t know how to forget you
No, I don''t know how to forget you
No, I don''t know how to forget you
No, I don''t know how to forget you (source: musixmatch.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'sex'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Ooh-ooh-ooh
Keep my spirit alive
Keep my spirit alive, alive
More than enough
You can take it all, but the Lord on my side
The spirit won''t die-ie
Oh, oh, all my life, yeah
Is in His hands, so I don''t stress, I pray and strategize
Yo, flushed the work just in time and they raided
Thank God (thank God)
Screamin'' through the GT roof like, we done made it (skrrt)
Thank God (thank God)
Hundred round drum didn''t jam when my shooter try spray it
Thank God (thank God) (brrr)
Dropped a thousand grams, got two thousand grands when we waited
Thank God (thank God)
I was facin'' fifteen and I beat it (and I beat it)
Just spent about twenty up at Neimans (up at Neimans)
Did two-hundred in a Demon (in a Demon, skrrt)
I''m the illest n-, and I mean it (and I mean it)
My homie droppin'' bodies for no reason (boom, boom, boom)
Now his kids see him on the weekends (argh)
Got the baking soda for the remix (remix)
Millionaires on, I can see it
More than enough
You can take it all, but the Lord on my side
The spirit won''t die-ie
Oh, oh, all my life, yeah
Is in His hands, so I don''t stress, I pray and strategize
Yeah, don''t hate me ''cause my heart is full of love
No weapon formed against me ''cause I''m covered in the blood
Layin'' in the hospital when I got shot, fam
Mama prayed for me, said she left it in God''s hands, yeah
So I''ma leave it in God''s hands
Everything I''m doin'' now is God''s plan
Doctor said I wouldn''t walk no more, now I stand
Then I ran, here I am, Machine
Keep my spirit alive
More than enough
You can take it all, but the Lord on my side
Well, between a mix of bad schools with the fast-food
Bad had tools and a bad mood
If you don''t turn to a lil'' Gotti they gon'' drain all the strength in your lil'' body
They turned me into a lil'' Gotti, uh, yeah
Not Wakanda but Wakanda is kinda like what we ''bout to make
And who gon'' make it? Kan'', duh
Who the squad? Donda
Who the mom? Donda
Who can see? Don, duh, get Don C
Who needs practice? I don''t do rehearsals
And I don''t do commercials ''cause they too commercial
Give it all to God and let Jesus reimburse you
She said "You in the studio with who? I''ma hurt you"
How I''m forty-two and you got a curfew?
How nerves dictate how they gon'' curve you?
Quiet all the cordialness
We walk in God''s spiritual ordinance
We know the blacks, the orphans, refused to be runaways
Rebel, renegade, must stay paid
More than enough
You can take it all, but the Lord on my side
The spirit won''t die-ie
Oh, oh, all my life, yeah
Is in His hands, so I don''t stress, I pray and strategize (source: lyricfind.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Keep My Spirit Alive'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('I wanna go to the moon, don''t leave so soon (Don''t leave so soon)
How could I get through? (How could I get through?)
I wanna go to the moon, don''t leave so soon (Don''t leave so soon)
How could I get through? (How could I get through?)
I wanna go to the moon, don''t leave so soon (Don''t leave so soon)
How could I get through? (How could I get through?)

Mhm, here we go strappin'', we up
Never forget all the memories
Sittin'', I sip out my cup
Thinkin'' I should be a better me
Truly I''m blessed from the start
So much to say in these melodies, oh
Stare at the sky, the moon singin'' sweet
Oh, my God, such a sweet moment
Angels, they say I''m not ever weak, such a lonely moment
Heaven knows I might never sleep, trouble in my soul
Hey, I''ve been prayin'', life can be drainin'', oh
Hey, we were late, tryna keep haulin'' on
I''m ashamed and yet, what I will see, ain''t nobody knows, so I go

How can I get through? (Don''t leave so soon)
How can I get through? (To the moon)
How can I get through? (To the moon)
Early afternoon, I wanna go to the moon (Take you to the moon)
Don''t leave so soon (Woah)
Don''t leave so soon
How could I get through? (Yeah)
How can I get through? (Ooh)
Early afternoon, I wanna go to the moon (Ooh, take you to the moon)
Don''t leave so soon (Ooh)
Don''t leave so soon (Don''t leave so soon)
How could I get through? (How could I get through?)
[Outro: Kid Cudi, Don Toliver]
Yeah-yeah
Woah-oh, oh-oh, oh-oh
Woah-oh, oh-oh, oh-oh (source: genius.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Moon'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Melodymania
Don''t break that spell
Don''t take me out
Losing self-control again
He calls my name
He calls my name
Do Do Do Do
Melody
Do Do Do Do
Mania
Do Do Do Do
Melody
Do Do Do Do
Mania
Melody will set you free
Let you take control of me
Mania
Melody will set you free
Let you take control of me
Melody will set you free
Oh - breathe - oh - oh
Melodymania
Don''t break that spell
Don''t take me out
Losing self-control again
He calls my name
He calls my name
Do Do Do Do
Melody
Do Do Do Do
Mania
Do Do Do Do
Melody
Do Do Do Do
Mania
Melody will set you free
Let you take control of me
Oh
Mania
Mania
Melody will set you free
Let you take control of me
Melody will set you free
Oh - breathe - oh - oh (source: musixmatch.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Melodymania'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Staring back in trance
Barely moaning
Eyes creep over her face
Holes are lonely
Can I hand you a ladder
Before I''m million miles above?
Oh let me shine through you
Seeing clearly ain''t enough

Tear me into the big black hole again
It''s the only place for gamma rays

I''ve been calling out your name
Don''t hesitate
I''ve been sending you the ray
At a tearing pace

I''ve been calling out
Don''t hesitate
I''ve been sending you
At a tearing pace

Fading is part of the game
Oh I told ya
A fake view through the pane
That''s what I sold ya
Hey! We got stuck!
We chose the villain and how he''ll end it
Don''t tell me that I need ya
Watch the big black hole expanding
Load the gamma rays

I''ve been calling out your name
Don''t hesitate
I''ve been sending you the ray
At a tearing pace

Let me go through ya
Let me conclude us
A fortunate failure
Many unexpected flavors

Pressures begin to rise. This is mission control Houston. 
We are taking over commentary at this point as we come up on 
the first two critical Orion program milestones – the service module 
fairing panel jettison and the Launch Abort System jettison. 
Standing by for those first two critical events

I''ve been calling out your name
Don''t hesitate
I''ve been sending you the ray
At a tearing pace

Let me go through ya
Let me conclude us
Don''t hesitate
A fortunate failure
Many unexpected flavors
At a tearing pace

Gamma, gamma rays
Gamma
Gamma, gamma rays
Gamma
Gamma, gamma rays
Gamma
Gamma, gamma rays
Gamma
Gamma, gamma rays
Gamma
Gamma, gamma rays
Gamma (source: genius.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Gamma'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Since you feel the skull behind my cheek
You''re scared that I''m not well anymore
No matter who you tell
They say I gave my smile for black rings
Then it becomes night when I blink
No matter who you tell

Since you feel the skull behind my cheek
You''re scared that I''m not well anymore
No matter who you tell
No reason to live healthy, ''cause
Sky ain''t the limit, sky ain''t the limit
Death is

So hold on to me
Although our way won''t be
A safe terrain
Oh hollow me
Tell me would you hold on
To a skeleton

You''re scared that I''m not well anymore
No matter who you tell
They say I gave my smile for dark rings
Then it becomes night when I blink
Hold on to me
Although our way won''t be
A safe terrain
Oh hollow me
Tell me would you hold on
To a skeleton

Hold on to me
Although our way won''t be
A safe terrain
Oh hollow me
Tell me would you hold on
To a skeleton

Hold on to me
Tell me would you hold on

Hold on to me

Then I lost my mind
In the prairie of time
But a bird was kind
And sang a song

Brother wind led the tones
The way I had to go
Would you sing for me now
As I lie on the ground
And the only direction
Is heaven? (source: genius.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Skeleton'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('Take what you want
Take everything
Take what you want
Take what you want
Better that I change my number so you can''t explain
Violence in the night, violence in the night
Priors, priors, do you have any priors?
Well, that one time, I''ll be honest
I''ll be honest, we all liars
Let it go
I''ll be honest, we all liars
I''ll be honest, we all liars
I''m pulled over and I got priors
Guess we goin'' down, guess who''s goin'' to jail?
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
God gon'' post my bail tonight
Don''t you curse at me on text, why you try to hit the flex?
I hold up, like, "What?" I scroll, I scroll up like, "Next"
Guess who''s gettin'' exed? Like, next
Guess who''s gettin'' exed?
You made a choice, that''s your bad
Single life ain''t so bad, but we ain''t finna go there
Something''s off, I''ll tell you why
Guess who''s goin'' to jail tonight?
What a grand plan to sell you out
I could scream and shout, let it out
I''ll be honest, we all liars
I''ll be honest, we all liars
I''m pulled over and I got priors
Guess we goin'' down, guess who''s goin'' to jail?
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
God gon'' post my bail tonight
God in my cells, that''s my celly
Made in the image of God, that''s a selfie
Pray five times a day, so many felonies
Who gon'' post my bail? Lord, help me
Hol'' up, Donda, I''m with your baby when I touch back road
Told him, "Stop all of that red cap, we goin'' home"
Not me with all of these sins, casting stones
This might be the return of The Throne, Throne
Hova and Yeezus, like Moses and Jesus
You are not in control of my thesis
You already know what I think ''bout thinkpieces
''Fore you ask, he already told you who he think he is
Don''t try to jail my thoughts and think precincts
I can''t be controlled with program and presets
Reset
On my cell, in my cell tonight
Don''t have to see you to touch you
This is what braille look like, it''s on sight, huh, huh, huh
If they take me to jail, call my girl, tell her send my mail
We know what Hell look like, still, it''s a hell of a life, yikes
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
Guess who''s goin'' to jail tonight?
God gon'' post my bail tonigh (souce: musixmatch.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'Jail'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('''Cause I had the best of the worst sides
And I had these lungs, oh
And I had too many flash fires
That I just let them burn
''Til my chest is on fire
And my head just won''t die
I guess I''m lying ''cause I wanna
I guess I''m lying ''cause I don''t
''Cause I just feel so tired
Like it''s move or slowly die
You say, you ain''t you when you''re like this
This ain''t you and you know it
But ain''t that just the point?
You don''t know
How to let go, who said this must be all or nothing?
But I''m still caught below
And I''ll never let you know
No, I can''t tell you nothing
''Cause I''m a fucking mess sometimes
But still I could always be
Whatever you wanted but not what you needed
Especially when you been needing me
''Cause I''m a fucking mess sometimes
And I''ll say what I don''t mean
Just ''cause I wanted or maybe I need it
Swear lying''s the only rush I need, yeah
''Cause all I needed was some words to say
That all these feelings don''t mean shit to me
''Cause it''s all just chemicals anyway, anyway, yeah
And I got way too many routes to take to make this all just go away
And find another heart to break, so heartless with these words I say
Just saying what I''m supposed to say ''cause I had nothing for you
I can''t love when I can''t even love myself
Things I would rather be, thoughts at the back of my head but I''m addicted to hurting
And I got these lungs, yeah
And I spent too many late nights
Just thinking a hole in the earth
''Til the sky is on fire
And my head still won''t die
I guess I''m lying ''cause I want to
I guess I''m lying ''cause I don''t
''Cause I just feel so tired
Like I need something to come alive
She said, "you ain''t you when you''re like this
This ain''t you, what you done?"
And I said, "That''s the point"
And you don''t know how to let go
Who said this must be all or nothing?
But I''m still caught below
And I''ll never let you know
No I can''t tell you nothing
''Cause I''m a fucking mess sometimes
But still, I could always be
Whatever you wanted but not what you needed
Especially when you been needing me
''Cause I''m a fucking mess inside
And I''ll say what I don''t mean
Just ''cause I wanted or maybe I need it
Swear lying''s the only rush I need, yeah, yeah, yeah, yeah
Yeah I need it, I need it, yeah, yeah, yeah (souce: lyricfind.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'drugs'), '20210917 00:00:00');

INSERT INTO lyrics (text, verified, userID, songID, creationTime) VALUES
('So tell me this is who you are
They tell me, I''ve got something more
And oh, you could be loved
But I don''t want the lights to
Find me when I''m dark and lost, but never on my own
''Cause I just wanna swing like Sinatra
Singing like I can''t stop
''Cause I can never rock like a Rolling Stone
I just wanna live like the ones before, yeah
And maybe I could play guitar like Hendrix
Or save the world or end it
And maybe they''ll remember me when I''m gone
That''s all I could ever want
That''s all I want
So I got ten minutes to be all or nothing to
Whoever wants to hear
And I got ten weeks of talking bullshit on repeat
''Til I''m burnt out and disappear
But I owe you nothing
And I own my luck
Oh, they say you''ll never be alone again
But I don''t think you understand me or what I fear
But you could be loved
But I don''t wanna lie to
Tell myself I''m more than all the mistakes I''ve outrun
But I''m only here for a minute
And I don''t care what you say
''Cause I know you''re only here ''cause I''m winning
But I can be my own kind of rock and roll, like
I don''t really care if you say, you don''t fuck with me
And I can say what the fuck I want ''cause it''s down to me
And I got love for you even if you were doubting me
Like, oh my God, I just can''t stop
''Cause I just wanna sing like Sinatra
With ethanol my soundtrack
''Cause I could never rock like a Rolling Stone
And wonder how it feels to burnout young
''Cause I just wanna die before my heart fails
From heartbreak or cocktails
And maybe you''ll cry once you know I''m gone
That''s all I could ever want
Oh, that''s all I want, yeah
''Cause I ain''t scared of livin''
No, I ain''t scared of livin''
(Yes, It gets easier)
(Oh yeah? Lo
No I ain''t scared of livin''
''Cause it''s all we''ve got
What are we breathin'' for if we ain''t livin''?
And I don''t want your love
I just wanna feel like I''m still livin''
And if there is no God
I''ll know the day I die I lived through heaven
And that I gave it hell
And if it hurt, oh well
At least that''s living
That''s all I want
(The less you let things upset you)
That''s all I want
(I just don''t know what I''m supposed to be)
(Ya know?)
(I tried being a writer, but umf
I hate what I write and ahh
I tried taking pictures, but
They''re so mediocre, you know?
And every girl goes through a photography phase
You know, like horses?
And take uh, dumb pictures of your feet)
(You''ll figure that out
I''m not worried about you) (source: musixmatch.com)'
, 'Y', '00000000-0000-0000-0000-000000000000', (SELECT songID FROM song WHERE name = 'rock + roll'), '20210917 00:00:00');