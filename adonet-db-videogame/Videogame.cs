using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{
    public class Videogame
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Overview { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public long SoftwareHouyseId { get; private set; }

        public Videogame(long id, string name, string overview, DateTime releaseDate, long softwareHouseId)
        {
            this.Id = id;
            this.Name = name;
            this.Overview = overview;
            this.ReleaseDate = releaseDate;
            this.SoftwareHouyseId = softwareHouseId;
        }

        public override string ToString()
        {
            return @$"
Nome: {Name};
Descrizione: {Overview};
Data di rilascio: {ReleaseDate.ToString()};
            ";
        }
    }
}
