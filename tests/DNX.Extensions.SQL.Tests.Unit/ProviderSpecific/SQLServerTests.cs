using DNX.Extensions.SQL.ProviderSpecific;
using FluentAssertions;
using Xunit;

namespace DNX.Extensions.SQL.Tests.Unit.ProviderSpecific;
public class SQLServerTests
{
    [Theory]
    [MemberData(nameof(QuoteName_Data))]
    public void QuoteName_Tests(string name, string expectedResult)
    {
        // Act
        var result = SQLServer.QuoteName(name);

        // Assert
        result.Should().Be(expectedResult);
    }

    [Theory]
    [MemberData(nameof(CreateQualifiedName_Data))]
    public void CreateQualifiedName_Tests(string objectName, string schemaName, string databaseName, string serverName, string expectedResult)
    {
        // Act
        var result = SQLServer.CreateQualifiedName(objectName, schemaName, databaseName, serverName);

        // Assert
        result.Should().Be(expectedResult);
    }

    public static IEnumerable<object[]> QuoteName_Data()
    {
        yield return new object[] { null, null };
        yield return new object[] { string.Empty, string.Empty };
        yield return new object[] { "   ", "   " };
        yield return new object[] { "bob", "[bob]" };
        yield return new object[] { "[bob]", "[bob]" };
        yield return new object[] { "bob]", "[bob]" };
        yield return new object[] { "[bob", "[bob]" };
    }

    public static IEnumerable<object[]> CreateQualifiedName_Data()
    {
        yield return new object[] { null, null, null, null, string.Empty };
        yield return new object[] { null, null, null, string.Empty, string.Empty };
        yield return new object[] { null, null, string.Empty, string.Empty, string.Empty };
        yield return new object[] { null, string.Empty, string.Empty, string.Empty, string.Empty };
        yield return new object[] { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };
        yield return new object[] { "MyTable", string.Empty, string.Empty, string.Empty, "[MyTable]" };
        yield return new object[] { "MyTable", "MySchema", string.Empty, string.Empty, "[MySchema].[MyTable]" };
        yield return new object[] { "MyTable", "MySchema", "MyDatabase", string.Empty, "[MyDatabase].[MySchema].[MyTable]" };
        yield return new object[] { "MyTable", "MySchema", "MyDatabase", "MyServer", "[MyServer].[MyDatabase].[MySchema].[MyTable]" };
        yield return new object[] { "MyTable", "", "MyDatabase", "MyServer", "[MyServer].[MyDatabase].[dbo].[MyTable]" };
    }
}
