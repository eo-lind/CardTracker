SET IDENTITY_INSERT [User] ON
INSERT INTO [User]
    ([Id], [UserName])
VALUES
    (1, 'Zoe'),
    (2, 'Olivia')
SET IDENTITY_INSERT [User] OFF

SET IDENTITY_INSERT [Player] ON
INSERT INTO [Player]
    ([Id], [NameFirst], [NameLast], [ImageUrlHeadshot])
VALUES
    (1, 'David', 'Legwand', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8467330.jpg'),
    (2, 'Keith', 'Brown', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8445713.jpg'),
    (3, 'Gerard', 'Gallant', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8447001.jpg'),
    (4, 'Steve', 'Kasper', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8448411.jpg'),
    (5, 'Ulf', 'Dahlen', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8446295.jpg'),
    (6, 'Steve', 'Sullivan', 'https://cms.nhl.bamgrid.com/images/headshots/current/168x168/8460719.jpg')
SET IDENTITY_INSERT [Player] OFF

SET IDENTITY_INSERT [Team] ON
INSERT INTO [Team]
    ([Id], [TeamName], [Website], [ImageUrlLogo])
VALUES
    (1, 'Nashville Predators', 'https://www.nhl.com/predators/', 'https://www-league.nhlstatic.com/nhl.com/builds/site-core/a5ff564cc78abe4cd1289ac6ef81b0e1a7ffde96_1659462381/images/logos/team/current/team-18-dark.svg'),
    (2, 'Chicago Blackhawks', 'https://www.nhl.com/blackhawks', 'https://cms.nhl.bamgrid.com/images/assets/binary/301971744/binary-file/file.svg'),
    (3, 'Detroit Red Wings', 'https://www.nhl.com/redwings', 'https://www-league.nhlstatic.com/images/logos/teams-current-primary-light/17.svg'),
    (4, 'Los Angeles Kings', 'https://www.nhl.com/kings', 'https://cms.nhl.bamgrid.com/images/assets/binary/308180580/binary-file/file.svg'),
    (5, 'Minnesota North Stars', 'https://www.hockeydb.com/stte/minnesota-north-stars-6876.html', 'https://www.hockeydb.com/ihdb/stats/thumbnail.php?in_file=nhl/minnesota_north_stars_1982.gif')
SET IDENTITY_INSERT [Team] OFF

SET IDENTITY_INSERT [Manufacturer] ON
INSERT INTO [Manufacturer]
    ([Id], [MfrName])
VALUES
    (1, 'Upper Deck'),
    (2, 'Pro Set'),
    (3, 'Topps'),
    (4, 'Bowman/Topps'),
    (5, 'Pacific Trading Cards')
SET IDENTITY_INSERT [Manufacturer] OFF

SET IDENTITY_INSERT [Status] ON
INSERT INTO [Status]
    ([Id], [StatusName])
VALUES
    (1, 'In Collection'),
    (2, 'Wishlist'),
    (3, 'For Sale')
SET IDENTITY_INSERT [Status] OFF

SET IDENTITY_INSERT [Attribute] ON
INSERT INTO [Attribute]
    ([Id], [AttributeName])
VALUES
    (1, 'Autographed'),
    (2, 'Pre-Rookie Card'),
    (3, 'Rookie Card')
SET IDENTITY_INSERT [Attribute] OFF

SET IDENTITY_INSERT [Series] ON
INSERT INTO [Series]
    ([Id], [SeriesName], [ManufacturerId])
VALUES
    (1, 'Black Diamond', 1),
    (2, 'Artistic Impressions', 1),
    (3, 'Mask Collection', 1),
    (4, '2021-22 Upper Deck Series 1 Hockey', 1),
    (5, '2020-21 Upper Deck Series 2 Hockey', 1),
    (6, '2020-21 Upper Deck Extended Series', 1),
    (7, 'Topps Gold Label', 3),
    (8,'Pacific 2004', 5),
    (9, 'Topps Young Stars Game', 4)
SET IDENTITY_INSERT [Series] OFF

SET IDENTITY_INSERT [Card] ON
INSERT INTO [Card]
    ([Id], [ImageUrlFront], [ImageUrlBack], [NumInSeries], [ManufactureYear], [ManufacturerId], [StatusId], [PlayerId], [TeamId], [UserId], [AttributeId], [SeriesId])
VALUES
    (1, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 76, 2003, 5, 1, 6, 2, 1, NULL, 8),
    (2, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 78, 2001, 3, 1, 1, 1, 1, NULL, 7),
    (3, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 13, 2003, 1, 1, 1, 1, 1, NULL, 1),
    (4, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 50, 2003, 1, 1, 1, 1, 1, NULL, 2),
    (5, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 53, 2002, 1, 1, 1, 1, 1, NULL, 3),
    (6, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 32, 2000, 1, 1, 1, 1, 1, NULL, 1),
    (7, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 96, 2003, 4, 1, 1, 1, 1, NULL, 9),
    (8, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 49, 1990, 2, 1, 2, 2, 1, NULL, NULL),
    (9, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 71, 1990, 2, 1, 3, 3, 1, NULL, NULL),
    (10, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 120, 1990, 2, 1, 4, 4, 1, NULL, NULL),
    (11, 'https://i.etsystatic.com/23968014/r/il/5e31c3/2435876581/il_794xN.2435876581_cfdn.jpg', 'https://www.pngkey.com/png/full/230-2302165_free-template-blank-trading-card-template-large-size.png', 136, 1990, 2, 1, 5, 5, 1, NULL, NULL)
SET IDENTITY_INSERT [Card] OFF

--SET IDENTITY_INSERT [PlayerTeam] ON
--INSERT INTO [PlayerTeam]
--    ([Id], [PlayerId], [TeamId])
--VALUES
--    (1, #, #),
--    (2, #, #)
--SET IDENTITY_INSERT [PlayerTeam] OFF