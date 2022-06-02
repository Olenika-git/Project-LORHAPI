namespace LORHAPI_API.Entities
{
    public class InsertionSector
    {
        public int IdSector { get; set; }
        public string Name { get; set; }

        public InsertionSector(int idSecteur, string secteur)
        {
            IdSector = idSecteur;
            Name = secteur;
        }
    }
}
