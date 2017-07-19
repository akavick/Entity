using System.Data.Entity;

namespace EntityExample001.Context
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