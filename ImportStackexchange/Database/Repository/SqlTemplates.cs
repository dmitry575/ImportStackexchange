namespace ImportStackexchange.Database.Repository
{
    /// <summary>
    /// Differnt sql queries tamplates
    /// </summary>
    class SqlTemplates
    {
        public const string ExistsTable = "select case when exists (select* from information_schema.tables where table_name = '{0}') then 1 else 0 end";
    }
}
