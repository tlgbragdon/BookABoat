namespace BookABoat
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BoathouseModel : DbContext
    {
        // Your context has been configured to use a 'BoathouseModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BookABoat.BoathouseModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BoathouseModel' 
        // connection string in the application configuration file.
        public BoathouseModel()
            : base("name=BoathouseModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Rower> Rowers { get; set; }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}