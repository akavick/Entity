using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using HwEntityLevikoffVictorP11015.Entities;

namespace HwEntityLevikoffVictorP11015.Context
{
    public class DropCreateIfModelChangedHwDataBase : DropCreateDatabaseIfModelChanges<HwDataBase>
    {
        protected override void Seed(HwDataBase db)
        {
            base.Seed(db);
            Seeder.Seed(db);
        }
    }
}