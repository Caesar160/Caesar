namespace Caesar.Common.Constants;

public readonly struct ConfigurationStrings
{
    public readonly struct ConfigSection
    {
        public static readonly string DefaultConnectionName = "DefaultConnection";

        public static readonly string UseInMemoryDatabase = "UseInMemoryDatabase";
    }

    public static readonly string MigrationsAssemblyName = "Caesar.Persistence";

    public static readonly string ApplicationSettingsJsonFileName = "appsettings.json";
}
