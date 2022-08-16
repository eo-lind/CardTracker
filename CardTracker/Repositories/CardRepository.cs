using Microsoft.Extensions.Configuration;
using CardTracker.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using CardTracker.Utils;

namespace CardTracker.Repositories
{
    public class CardRepository : BaseRepository, ICardRepository
    {
        public CardRepository(IConfiguration configuration) : base(configuration) { }

        public List<Card> GetAll()
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT c.Id AS CardId, c.ImageUrlFront, c.ImageUrlBack, p.NameFirst, p.NameLast, t.TeamName, t.Website, m.MfrName, c.ManufactureYear, ser.SeriesName, c.NumInSeries, a.AttributeName, stat.StatusName, m.Id, stat.Id, p.Id, t.Id, a.Id, ser.Id
                        FROM [Card] c
                        LEFT JOIN Manufacturer m ON c.ManufacturerId = m.Id
                        LEFT JOIN [Status] stat ON c.StatusId = stat.Id
                        LEFT JOIN Player p ON c.PlayerId = p.Id
                        LEFT JOIN Team t ON c.TeamId = t.Id
                        LEFT JOIN Attribute a ON c.AttributeId = a.Id
                        LEFT JOIN Series ser ON c.SeriesId = ser.Id
                        ORDER BY p.NameLast, p.NameFirst, c.ManufactureYear
                        ";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        var cards = new List<Card>();

                        while (reader.Read())
                        {
                            cards.Add(new Card()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                ImageUrlFront = DbUtils.GetString(reader, "ImageUrlFront"),
                                ImageUrlBack = DbUtils.GetString(reader, "ImageUrlBack"),
                                ManufactureYear = DbUtils.GetInt(reader, "ManufactureYear"),
                                NumInSeries = DbUtils.GetInt(reader, "NumInSeries"),
                                Player = new Player()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    NameFirst = DbUtils.GetString(reader, "NameFirst"),
                                    NameLast = DbUtils.GetString(reader, "NameLast")
                                },
                                Team = new Team()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    TeamName = DbUtils.GetString(reader, "TeamName"),
                                    Website = DbUtils.GetString(reader, "Website")
                                },
                                Manufacturer = new Manufacturer()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    MfrName = DbUtils.GetString(reader, "MfrName")
                                },
                                Series = new Series()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    SeriesName = DbUtils.GetString(reader, "SeriesName")
                                },
                                Attribute = new Attribute()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    AttributeName = DbUtils.GetString(reader, "AttributeName")
                                },
                                Status = new Status()
                                {
                                    Id = DbUtils.GetInt(reader, "Id"),
                                    StatusName = DbUtils.GetString(reader, "StatusName")
                                }
                            });
                        }

                        return cards;
                    }
                }
            }
        }

        public Card GetById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT c.Id, c.ImageUrlFront, c.ImageUrlBack, p.NameFirst, p.NameLast, t.TeamName, t.Website, m.MfrName, c.ManufactureYear, ser.SeriesName, c.NumInSeries, a.AttributeName, stat.StatusName, m.Id AS MFRId, stat.Id AS STATId, p.Id AS PId, t.Id AS TId, a.Id AS AId, ser.Id AS SERId, c.PlayerId, c.TeamId, c.ManufacturerId, c.SeriesId, c.AttributeId, c.StatusId, c.UserId
                        FROM [Card] c
                        LEFT JOIN Manufacturer m ON c.ManufacturerId = m.Id
                        LEFT JOIN [Status] stat ON c.StatusId = stat.Id
                        LEFT JOIN Player p ON c.PlayerId = p.Id
                        LEFT JOIN Team t ON c.TeamId = t.Id
                        LEFT JOIN Attribute a ON c.AttributeId = a.id
                        LEFT JOIN Series ser ON c.SeriesId = ser.Id
                        WHERE c.Id = @Id
                        ";

                    DbUtils.AddParameter(cmd, "@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Card card = null;
                        if (reader.Read())
                        {
                            card = new Card()
                            {
                                Id = DbUtils.GetInt(reader, "Id"),
                                ImageUrlFront = DbUtils.GetString(reader, "ImageUrlFront"),
                                ImageUrlBack = DbUtils.GetString(reader, "ImageUrlBack"),
                                ManufactureYear = DbUtils.GetInt(reader, "ManufactureYear"),
                                NumInSeries = DbUtils.GetInt(reader, "NumInSeries"),
                                Player = new Player()
                                {
                                    NameFirst = DbUtils.GetString(reader, "NameFirst"),
                                    NameLast = DbUtils.GetString(reader, "NameLast")
                                },
                                Team = new Team()
                                {
                                    TeamName = DbUtils.GetString(reader, "TeamName"),
                                    Website = DbUtils.GetString(reader, "Website")
                                },
                                Manufacturer = new Manufacturer()
                                { 
                                    MfrName = DbUtils.GetString(reader, "MfrName")
                                },
                                Series = new Series()
                                {
                                    SeriesName = DbUtils.GetString(reader, "SeriesName")
                                },
                                Attribute = new Attribute()
                                {
                                    AttributeName = DbUtils.GetString(reader, "AttributeName")
                                },
                                Status = new Status()
                                {
                                    StatusName = DbUtils.GetString(reader, "StatusName")
                                }
                            };
                        }

                        return card;
                    }
                }
            }
        }

        public void Add(Card card)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Card (ImageUrlFront, ImageUrlBack, NumInSeries, ManufactureYear, ManufacturerId, StatusId, PlayerId, TeamId, UserId, AttributeId, SeriesId)
                        OUTPUT INSERTED.ID
                        VALUES (@ImageUrlFront, @ImageUrlBack, @NumInSeries, @ManufactureYear, @ManufacturerId, @StatusId, @PlayerId, @TeamId, @UserId, @AttributeId, @SeriesId)";

                    DbUtils.AddParameter(cmd, "@ImageUrlFront", card.ImageUrlFront);
                    DbUtils.AddParameter(cmd, "@ImageUrlBack", card.ImageUrlBack);
                    DbUtils.AddParameter(cmd, "@NumInSeries", card.NumInSeries);
                    DbUtils.AddParameter(cmd, "@ManufactureYear", card.ManufactureYear);
                    DbUtils.AddParameter(cmd, "@ManufacturerId", card.ManufacturerId);
                    DbUtils.AddParameter(cmd, "@StatusId", card.StatusId);
                    DbUtils.AddParameter(cmd, "@PlayerId", card.PlayerId);
                    DbUtils.AddParameter(cmd, "@TeamId", card.TeamId);
                    DbUtils.AddParameter(cmd, "@UserId", card.UserId);
                    DbUtils.AddParameter(cmd, "@AttributeId", card.AttributeId);
                    DbUtils.AddParameter(cmd, "@SeriesId", card.SeriesId);

                    card.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Card card)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Card
                           SET ImageUrlFront = @ImageUrlFront,
                               ImageUrlBack = @ImageUrlBack,
                               NumInSeries = @NumInSeries,
                               ManufactureYear = @ManufactureYear,
                               ManufacturerId = @ManufacturerId,
                               StatusId = @StatusId,
                               PlayerId = @PlayerId,
                               TeamId = @TeamId,
                               UserId = @UserId,
                               AttributeId = @AttributeId,
                               SeriesId = @SeriesId
                         WHERE Id = @Id";

                    DbUtils.AddParameter(cmd, "@ImageUrlFront", card.ImageUrlFront);
                    DbUtils.AddParameter(cmd, "@ImageUrlBack", card.ImageUrlBack);
                    DbUtils.AddParameter(cmd, "@NumInSeries", card.NumInSeries);
                    DbUtils.AddParameter(cmd, "@ManufactureYear", card.ManufactureYear);
                    DbUtils.AddParameter(cmd, "@ManufacturerId", card.ManufacturerId);
                    DbUtils.AddParameter(cmd, "@StatusId", card.StatusId);
                    DbUtils.AddParameter(cmd, "@PlayerId", card.PlayerId);
                    DbUtils.AddParameter(cmd, "@TeamId", card.TeamId);
                    DbUtils.AddParameter(cmd, "@UserId", card.UserId);
                    DbUtils.AddParameter(cmd, "@AttributeId", card.AttributeId);
                    DbUtils.AddParameter(cmd, "@SeriesId", card.SeriesId);
                    DbUtils.AddParameter(cmd, "@Id", card.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Card WHERE Id = @Id";
                    DbUtils.AddParameter(cmd, "@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

