using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace RustWPFApp
{
    public class Rust
    {

    }

    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageURL { get; set; }

    }

    public class Guns
    {
        [Key]
        public int GunId { get; set; }
        public string GunName { get; set; }
        public string GunDescription { get; set; }
        public string GunImageURL { get; set; }
    }
    public class Animals
    {
        [Key]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalDescription { get; set; }
        public string AnimalImageURL { get; set; }
    }
    public class RustData : DbContext
    {
        public RustData() : base("MyRustData") { }

        public DbSet<Items> Items { get; set; }
        public DbSet<Guns> Guns { get; set; }
        public DbSet<Animals> Animals { get; set; }

    }
}
