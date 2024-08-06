using System.Text;

namespace DNX.Extensions.SQL.ProviderSpecific;

public static class SQLServer
{
    public static class Qualifiers
    {
        public const string OpeningNameBrace = "[";
        public const string ClosingNameBrace = "]";
        public const string NameSeparator = ".";
    }

    public class Defaults
    {
        public const string SchemaName = "dbo";
    }

    public static string QuoteName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return name;

        if (!name.StartsWith(Qualifiers.OpeningNameBrace))
            name = Qualifiers.OpeningNameBrace + name;

        if (!name.EndsWith(Qualifiers.ClosingNameBrace))
            name += Qualifiers.ClosingNameBrace;

        return name;
    }

    public static string CreateQualifiedName(
        string objectName
        , string schemaName = null
        , string databaseName = null
        , string serverName = null
    )
    {
        var qualifiedName = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(serverName))
        {
            qualifiedName.Append(QuoteName(serverName));
        }

        if (!string.IsNullOrWhiteSpace(databaseName))
        {
            if (qualifiedName.Length > 0)
                qualifiedName.Append(Qualifiers.NameSeparator);

            qualifiedName.Append(QuoteName(databaseName));
        }

        if (!string.IsNullOrWhiteSpace(schemaName) || qualifiedName.Length > 0)
        {
            if (qualifiedName.Length > 0)
                qualifiedName.Append(Qualifiers.NameSeparator);

            var quotedName = QuoteName(schemaName);
            if (string.IsNullOrWhiteSpace(quotedName))
                quotedName = QuoteName(Defaults.SchemaName);

            qualifiedName.Append(quotedName);
        }

        if (qualifiedName.Length > 0)
            qualifiedName.Append(Qualifiers.NameSeparator);

        qualifiedName.Append(QuoteName(objectName));

        return qualifiedName.ToString();
    }
}
