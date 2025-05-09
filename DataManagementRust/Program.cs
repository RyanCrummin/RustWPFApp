using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RustWPFApp;
using static System.Net.WebRequestMethods;

namespace DataManagementRust
{
    class Program
    {
        static void Main(string[] args)
        {
            RustData db = new RustData();

            using (db)
            {
                Guns ak47 = new Guns { GunId = 1, GunDescription = "High damage machine rifle", GunImageURL = "https://files.facepunch.com/rust/item/rifle.ak_512.png", GunName = "AK-47" };
                Guns mp5 = new Guns { GunId = 2, GunDescription = "Submachine gun with a high rate of fire", GunImageURL = "https://static.wikia.nocookie.net/play-rust/images/c/c0/MP5A4_icon.png/revision/latest?cb=20161013162633", GunName = "MP5" };
                Guns sar = new Guns { GunId = 3, GunDescription = "Accurate semi-automatic rifle", GunImageURL = "https://static.wikia.nocookie.net/play-rust/images/8/8d/Semi-Automatic_Rifle_icon.png/revision/latest?cb=20160128160721", GunName = "SAR" };
                Guns semiAutoPistol = new Guns { GunId = 4, GunDescription = "Reliable semi-automatic sidearm", GunImageURL = "https://static.wikia.nocookie.net/play-rust/images/6/6b/Semi-Automatic_Pistol_icon.png/revision/latest?cb=20160211200319", GunName = "Semi-Automatic Pistol" };
                Guns lr300 = new Guns { GunId = 5, GunDescription = "Lightweight and versatile rifle", GunImageURL = "https://wiki.rustclash.com/img/items180/rifle.lr300.png", GunName = "LR-300" };

                Animals boar = new Animals { AnimalId = 1, AnimalDescription = "Small animal that deals moderate damage, provides mostly animal fat but also provides bones, leather, and small amounts of cloth. ", AnimalName = "Boar", AnimalImageURL = "https://files.facepunch.com/wiki/files/e334/8d9ce7939753a20.jpg" };
                Animals deer = new Animals { AnimalId = 2, AnimalDescription = "Large herbivore that provides a good amount of meat, leather, and bones.", AnimalName = "Deer", AnimalImageURL = "https://files.facepunch.com/wiki/files/e334/8d9ce72fcdb7287.jpg" };
                Animals chicken = new Animals { AnimalId = 3, AnimalDescription = "Small bird that provides a small amount of meat and feathers.", AnimalName = "Chicken", AnimalImageURL = "https://files.facepunch.com/wiki/files/e334/8d9ce7abbcd3afc.jpg" };
                Animals bear = new Animals { AnimalId = 4, AnimalDescription = "Large and dangerous predator that yields a significant amount of meat, animal fat, and leather.", AnimalName = "Bear", AnimalImageURL = "https://files.facepunch.com/wiki/files/e334/8d9ce72e850b17d.jpg" };
                Animals crocodile = new Animals { AnimalId = 5, AnimalDescription = "Large reptile found in water that provides a decent amount of meat and leather.", AnimalName = "Crocodile", AnimalImageURL = "https://www.gtxgaming.co.uk/wp-content/uploads/2023/12/rust-crocodiles-1024x536.png" };

                Items hatchet = new Items { ItemId = 1, ItemDescription = "Used to harvest wood, and animals efficiently", ItemName = "Hatchet", ItemImageURL = "https://wiki.rustclash.com/img/items180/hatchet.png" };
                Items pickaxe = new Items { ItemId = 2, ItemDescription = "Essential tool for mining stone, metal ore, and sulfur.", ItemName = "Pickaxe", ItemImageURL = "https://static.wikia.nocookie.net/play-rust/images/8/86/Pick_Axe_icon.png/revision/latest?cb=20151106061323" };
                Items boneknife = new Items { ItemId = 3, ItemDescription = "Primitive melee weapon crafted from bone.", ItemName = "Boneknife", ItemImageURL = "https://wiki.rustclash.com/img/items180/knife.bone.png" };
                Items c4 = new Items { ItemId = 4, ItemDescription = "Powerful explosive device used for raiding and demolition.", ItemName = "C4", ItemImageURL = "https://files.facepunch.com/rust/item/explosive.timed_512.png" };
                Items rocket = new Items { ItemId = 5, ItemDescription = "High-damage projectile used with rocket launchers.", ItemName = "Rocket", ItemImageURL = "https://files.facepunch.com/rust/item/ammo.rocket.basic_512.png " };


                db.Guns.Add(ak47);
                db.Guns.Add(mp5);
                db.Guns.Add(sar);
                db.Guns.Add(semiAutoPistol);
                db.Guns.Add(lr300);

                Console.WriteLine("Added Guns to the database.");

                db.Animals.Add(boar);
                db.Animals.Add(deer);
                db.Animals.Add(chicken);
                db.Animals.Add(bear);
                db.Animals.Add(crocodile);

                Console.WriteLine("Added Animals to the database.");

                db.Items.Add(hatchet);
                db.Items.Add(pickaxe);
                db.Items.Add(boneknife);
                db.Items.Add(c4);
                db.Items.Add(rocket);

                Console.WriteLine("Added items to the database.");

                db.SaveChanges();

                Console.WriteLine("Saved to database successfully.");

            }

        }
    }
}
