using System.Data.Entity;

namespace EntityExample001.Context
{
    public class DropCreateAlwaysHwDataBase : DropCreateDatabaseAlways<HwDataBase>
    {
        protected override void Seed(HwDataBase db)
        {
            base.Seed(db);
            Seeder.Seed(db);
        }
    }
}