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

INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('Donda', 27, 2021, (SELECT artistID FROM artist WHERE name = 'Kanye West'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('The Colour and the Shape', 13, 1997, (SELECT artistID FROM artist WHERE name = 'Foo Fighters'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('AFewSides', 12, 2013, (SELECT artistID FROM artist WHERE name = 'FewJar'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('Gamma', 8, 2018, (SELECT artistID FROM artist WHERE name = 'FewJar'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime, cover) VALUES
('Badboi', 1, 2014, (SELECT artistID FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00', 'https://i1.sndcdn.com/artworks-000088442109-7jcbju-t500x500.jpg');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('Nerds by Nature', 6, 2017, (SELECT artistID FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('End Credits', 7, 2015, (SELECT artistID FROM artist WHERE name = 'EDEN'), '20210902 00:00:00');
INSERT INTO album (name, numberOfTracks, year, artistID, creationTime) VALUES
('i think you think too much of me', 7, 2016, (SELECT artistID FROM artist WHERE name = 'EDEN'), '20210902 00:00:00');


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