SELECT c.Id, c.ImageUrlFront, c.ImageUrlBack, p.NameFirst, p.NameLast, t.TeamName, t.Website, m.MfrName, c.ManufactureYear, ser.SeriesName, c.NumInSeries, a.AttributeName, stat.StatusName, m.Id AS MFRId, stat.Id AS STATId, p.Id AS PId, t.Id AS TId, a.Id AS AId, ser.Id AS SERId, c.PlayerId, c.TeamId, c.ManufacturerId, c.SeriesId, c.AttributeId, c.StatusId, c.UserId
    FROM [Card] c
    LEFT JOIN Manufacturer m ON c.ManufacturerId = m.Id
    LEFT JOIN [Status] stat ON c.StatusId = stat.Id
    LEFT JOIN Player p ON c.PlayerId = p.Id
    LEFT JOIN Team t ON c.TeamId = t.Id
    LEFT JOIN Attribute a ON c.AttributeId = a.id
    LEFT JOIN Series ser ON c.SeriesId = ser.Id
    WHERE c.Id = 4

SELECT *
FROM [Card]
WHERE Id = 4

SELECT *
FROM [User]

SELECT *
FROM Player

SELECT *
FROM Team

SELECT *
FROM Manufacturer

SELECT *
FROM [Status]

SELECT *
FROM Attribute

SELECT *
FROM Series

SELECT *
FROM [Status]