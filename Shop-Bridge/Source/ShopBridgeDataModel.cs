namespace Shop_Bridge
{
    using Shop_Bridge.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopBridgeDataModel : DbContext
    {
        // Your context has been configured to use a 'ShopBridgeDataModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Shop_Bridge.ShopBridgeDataModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ShopBridgeDataModel' 
        // connection string in the application configuration file.
        public ShopBridgeDataModel()
            : base("name=con")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Product> Items { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Item>()
        //        .Property(i => i.Name)
        //        .IsRequired();

        //    base.OnModelCreating(modelBuilder);
        //}
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}