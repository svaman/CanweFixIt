﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using CanWeFixIt.Domain;
using System.Data;

namespace CanWeFixIt.Data
{
    public class DatabaseService : IDatabaseService
    {
        // See SQLite In-Memory example:
        // https://github.com/dotnet/docs/blob/main/samples/snippets/standard/data/sqlite/InMemorySample/Program.cs

        // Using a name and a shared cache allows multiple connections to access the same
        // in-memory database
        private IDbConnection _connection;

        public DatabaseService(IDbConnection connection)
        {
            // The in-memory database only persists while a connection is open to it. To manage
            // its lifetime, keep one open connection around for as long as you need it.
            _connection = connection;
            _connection.Open();
        }

        public async Task<IEnumerable<Instrument>> Instruments()
        {
            return await _connection.QueryAsync<Instrument>(@"
SELECT  Id, Sedol, Name, Active 
FROM    Instrument 
WHERE   Active = 1");
        }

        public async Task<IEnumerable<MarketDataDto>> MarketData()
        {
            return await _connection.QueryAsync<MarketDataDto>(@"
SELECT  m.Id, m.DataValue, i.Id as 'InstrumentId', m.Active 
FROM    MarketData as m 
INNER JOIN Instrument as i on m.Sedol = i.Sedol 
WHERE   m.Active = 1");
        }

        public async Task<IEnumerable<Valuation>> Valuations()
        {
            return await _connection.QueryAsync<Valuation>(@"
SELECT  'DataValueTotal' as 'Name', SUM(DataValue) as 'Total' 
FROM    MarketData 
WHERE   Active = 1");
        }

        /// <summary>
        /// This is complete and will correctly load the test data.
        /// It is called during app startup 
        /// </summary>
        public void SetupDatabase()
        {
            const string createInstruments = @"
                CREATE TABLE instrument
                (
                    id     int,
                    sedol  text,
                    name   text,
                    active int
                );
                INSERT INTO instrument
                VALUES (1, 'Sedol1', 'Name1', 0),
                       (2, 'Sedol2', 'Name2', 1),
                       (3, 'Sedol3', 'Name3', 0),
                       (4, 'Sedol4', 'Name4', 1),
                       (5, 'Sedol5', 'Name5', 0),
                       (6, '', 'Name6', 1),
                       (7, 'Sedol7', 'Name7', 0),
                       (8, 'Sedol8', 'Name8', 1),
                       (9, 'Sedol9', 'Name9', 0)";

            _connection.Execute(createInstruments);

            const string createMarketData = @"
                CREATE TABLE marketdata
                (
                    id        int,
                    datavalue int,
                    sedol     text,
                    active    int
                );
                INSERT INTO marketdata
                VALUES (1, 1111, 'Sedol1', 0),
                       (2, 2222, 'Sedol2', 1),
                       (3, 3333, 'Sedol3', 0),
                       (4, 4444, 'Sedol4', 1),
                       (5, 5555, 'Sedol5', 0),
                       (6, 6666, 'Sedol6', 1)";

            _connection.Execute(createMarketData);
        }
    }
}