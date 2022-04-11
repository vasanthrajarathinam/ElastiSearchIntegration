namespace ElastiSearchIntegration
{

    public class City
    {
       

        public City(int iD, string name, string state, string country, string population)
        {
            ID = iD;
            Name = name;
            State = state;
            Country = country;
            Population = population;
        }

        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Population
        {
            get;
            set;
        }
    }
}

