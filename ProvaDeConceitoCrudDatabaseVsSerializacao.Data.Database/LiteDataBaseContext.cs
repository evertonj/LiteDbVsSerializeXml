using LiteDB;

namespace ProvaDeConceitoCrudDatabaseVsSerializacao.Data.Database
{
    public class LiteDataBaseContext
    {
        private static LiteDatabase LiteDatabase;

        private LiteDataBaseContext() {}

        public static LiteDatabase GetDatabase(string fileName = "DefaultData.litedb", string password = "password")
        { 
            var connectionString = new ConnectionString {Password = password, Filename = fileName };
            if (LiteDatabase == null)
                LiteDatabase = new LiteDatabase(connectionString);
            return LiteDatabase;
        }
    }
}
