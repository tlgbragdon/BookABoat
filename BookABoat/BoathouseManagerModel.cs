namespace BookABoat
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BoathouseManagerModel : DbContext
    {
        // Your context has been configured to use a 'BoathouseManagerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookABoat.BoathouseManagerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BoathouseManagerModel' 
        // connection string in the application configuration file.
        public BoathouseManagerModel()
            : base("name=BoathouseManagerModel.cs")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Boat> Boats { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}