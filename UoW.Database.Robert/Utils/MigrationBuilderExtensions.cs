namespace UoW.Database.Robert.Utils
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public static class MigrationBuilderExtensions
    {
        public static void AddTemporalTableSupport(this MigrationBuilder builder, string tableName)
        {
            builder.Sql($@"ALTER TABLE {tableName} ADD 
            ValidFrom datetime2(0) GENERATED ALWAYS AS ROW START HIDDEN CONSTRAINT DF_{tableName}_ValidFrom DEFAULT DATEADD(second, -1, SYSUTCDATETIME()) NOT NULL,
            ValidTo datetime2(0) GENERATED ALWAYS AS ROW END HIDDEN CONSTRAINT DF_{tableName}_ValidTo DEFAULT '9999.12.31 23:59:59.99' NOT NULL,
            PERIOD FOR SYSTEM_TIME (ValidFrom, ValidTo);");
            builder.Sql($@"ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.{tableName}_history ));");
        }

        public static void DropTemporalTableSupport(this MigrationBuilder builder, string tableName)
        {
            builder.Sql($@"BEGIN TRAN
            ALTER TABLE {tableName} SET (SYSTEM_VERSIONING = OFF);
            TRUNCATE TABLE {tableName}_history WITH (PARTITIONS (1,2));
            ALTER TABLE {tableName} DROP CONSTRAINT DF_{tableName}_ValidFrom;
            ALTER TABLE {tableName} DROP CONSTRAINT DF_{tableName}_ValidTo;
            ALTER TABLE {tableName} DROP PERIOD FOR SYSTEM_TIME;
            DROP TABLE {tableName}_history;
            COMMIT;");
        }
    }
}
