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


INSERT INTO artist (name, creation_time) VALUES ('Foo Fighters', '20210902 00:00:00');
INSERT INTO artist (name, creation_time) VALUES ('Kanye West', '20210902 00:00:00');
INSERT INTO artist (name, creation_time) VALUES ('FewJar', '20210902 00:00:00');
INSERT INTO artist (name, creation_time) VALUES ('EDEN', '20210902 00:00:00');
INSERT INTO artist (name, creation_time) VALUES ('Pegboard Nerds', '20210902 00:00:00');

INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('Donda', 27, 2021, (SELECT artist_id FROM artist WHERE name = 'Kanye West'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('The Colour and the Shape', 13, 1997, (SELECT artist_id FROM artist WHERE name = 'Foo Fighters'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('AFewSides', 12, 2013, (SELECT artist_id FROM artist WHERE name = 'FewJar'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('Gamma', 8, 2018, (SELECT artist_id FROM artist WHERE name = 'FewJar'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('Badboi', 1, 2014, (SELECT artist_id FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('Nerds by Nature', 6, 2017, (SELECT artist_id FROM artist WHERE name = 'Pegboard Nerds'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('End Credits', 7, 2015, (SELECT artist_id FROM artist WHERE name = 'EDEN'), '20210902 00:00:00');
INSERT INTO album (name, number_of_tracks, year, artist_id, creation_time) VALUES
('i think you think too much of me', 7, 2016, (SELECT artist_id FROM artist WHERE name = 'EDEN'), '20210902 00:00:00');


INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('02:09', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('End Credits', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Gravity', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Nocturne', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Interlude', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Wake Up', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('catch me if you can', (SELECT album_id FROM album WHERE name = 'End Credits'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('sex', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('drugs', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('and', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('rock + roll', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Fumes', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('XO', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Circles', (SELECT album_id FROM album WHERE name = 'i think you think too much of me'), (SELECT genre_id FROM genre WHERE name = 'Indie pop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Speed of Light', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Chill'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Melodymania', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Electro house'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Talk About It (feat. Desirée Dawson)', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Future bass'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Go Berzerk (with Quiet Disorder)', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Dubstep'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('BAMF', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Dubstep'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Blackout', (SELECT album_id FROM album WHERE name = 'Nerds By Nature'), (SELECT genre_id FROM genre WHERE name = 'Future house'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Badboi', (SELECT album_id FROM album WHERE name = 'Badboi'), (SELECT genre_id FROM genre WHERE name = 'Trap'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Cepheus', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Bale In Your Pocket', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Chalkbird (feat. Lara Hamzehpour)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Anatom, Problem 1', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('S.p.a.m. (feat. Tommy Blackout)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Control, Problem 2 (Andre Moghimi Rework)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Tapirsupper', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('A Billion (feat. Tell You What Now)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Absolution', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Polemonium (feat. Frodo)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Gluttony, Problem 3 (feat. SpaceApparat)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Risen To A Flood (feat. Andre Moghimi)', (SELECT album_id FROM album WHERE name = 'AFewSides'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Skeleton', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Gamma', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('How Many of You Are in There?', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Of Nothing', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Structured', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Despite This', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('(This is Not) Worth it', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Treasure', (SELECT album_id FROM album WHERE name = 'Gamma'), (SELECT genre_id FROM genre WHERE name = 'Progressive'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Doll', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Monkey Wrench', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Hey, Johnny Park!', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('My Poor Brain', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Wind Up', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Up in Arms', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('My Hero', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('See You', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Enough Space', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('February Stars', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Everlong', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Walking After You', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('New Way Home', (SELECT album_id FROM album WHERE name = 'The Colour and the Shape'), (SELECT genre_id FROM genre WHERE name = 'Alternative rock'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Donda Chant', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Jail', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('God Breathed', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Off the Grid', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Hurricane', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Praise God', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Gospel'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Jonah', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Ok Ok', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Junya', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Believe What I Say', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('24', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Remote Control', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Moon', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Chill'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Heaven and Hell', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Donda', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Keep My Spirit Alive', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Jesus Lord', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Gospel'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('New Again', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Tell the Vision', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Lord I Need You', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Pure Souls', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Come to Life', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('No Child Left Behind', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Jail, Pt. 2', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Ok Ok, Pt. 2', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Junya, Pt. 2', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');
INSERT INTO song (name, album_id, genre_id, creation_time) VALUES
('Jesus Lord, Pt. 2', (SELECT album_id FROM album WHERE name = 'Donda'), (SELECT genre_id FROM genre WHERE name = 'Experimental hip hop'), '20210902 00:00:00');


INSERT INTO lyrics (text, verified, user_id, song_id, creation_time) VALUES
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

No more (source azlyrics.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT song_id FROM song WHERE name = 'Nocturne'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, user_id, song_id, creation_time) VALUES
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
Don''t want to be your monkey wrench (source azlyrics.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT song_id FROM song WHERE name = 'Monkey Wrench'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, user_id, song_id, creation_time) VALUES
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

Hands up (source genius.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT song_id FROM song WHERE name = 'BAMF'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, user_id, song_id, creation_time) VALUES
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
Attend nemesis, the last act (source genius.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT song_id FROM song WHERE name = 'Cepheus'), '20210902 00:00:00');
INSERT INTO lyrics (text, verified, user_id, song_id, creation_time) VALUES
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
Adreeeenaaaaaliiiiized! (source genius.com & musixmatch.com)', 'Y', '00000000-0000-0000-0000-000000000000', (SELECT song_id FROM song WHERE name = 'S.p.a.m. (feat. Tommy Blackout)'), '20210902 00:00:00');