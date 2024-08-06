using AutoFixture;
using DNX.Extensions.SQL.Objects;
using FluentAssertions;
using Xunit;

namespace DNX.Extensions.SQL.Tests.Unit.Objects;

public class TableColumnDefinitionTests
{
    public static readonly Fixture AutoFixture = new();
    public static readonly Random Randomizer = new();

    public class ConstructorTests
    {
        private static string GenerateRandomName() => Faker.Internet.DomainWord();
        private static Type GenerateRandomDataType() => typeof(string);
        private static int GenerateRandomOrdinal() => Randomizer.Next(0, 50);
        private static bool GenerateRandomBool() => AutoFixture.Create<bool>();
        private static int GenerateRandomColumnSize() => Randomizer.Next(1, 256);
        private static int GenerateRandomNumericPrecision() => Randomizer.Next(4, 20);
        private static int GenerateRandomNumericScale() => Randomizer.Next(0, 4);

        [Fact]
        public void Default_Constructor_with_minimal_arguments_creates_successfully()
        {
            var name = GenerateRandomName();

            // Act
            var sut = new TableColumnDefinition(name);

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_Ordinal_creates_successfully()
        {
            var name = GenerateRandomName();
            var ordinal = GenerateRandomOrdinal();

            // Act
            var sut = new TableColumnDefinition(
                name,
                columnOrdinal: ordinal
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().Be(ordinal);
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_DataType_creates_successfully()
        {
            var name = GenerateRandomName();
            var dataType = GenerateRandomDataType();

            // Act
            var sut = new TableColumnDefinition(
                name,
                dataType: dataType
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().Be(dataType);
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_AllowDBNull_creates_successfully()
        {
            var name = GenerateRandomName();
            var AllowDBNull = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                allowDBNull: AllowDBNull
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().Be(AllowDBNull);
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_ColumnSize_creates_successfully()
        {
            var name = GenerateRandomName();
            var columnSize = GenerateRandomColumnSize();

            // Act
            var sut = new TableColumnDefinition(
                name,
                columnSize: columnSize
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().Be(columnSize);
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_NumericPrecision_creates_successfully()
        {
            var name = GenerateRandomName();
            var numericPrecision = GenerateRandomNumericPrecision();

            // Act
            var sut = new TableColumnDefinition(
                name,
                numericPrecision
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().Be(numericPrecision);
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_NumericScale_creates_successfully()
        {
            var name = GenerateRandomName();
            var numericScale = GenerateRandomNumericScale();

            // Act
            var sut = new TableColumnDefinition(
                name,
                numericScale
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().Be(numericScale);
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_IsUnique_creates_successfully()
        {
            var name = GenerateRandomName();
            var isUnique = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                isUnique: isUnique
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().Be(isUnique);
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_IsKey_creates_successfully()
        {
            var name = GenerateRandomName();
            var isKey = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                isKey: isKey
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().Be(isKey);
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_IsExpression_creates_successfully()
        {
            var name = GenerateRandomName();
            var isExpression = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                isExpression: isExpression
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().Be(isExpression);
            sut.IsReadOnly.Should().BeNull();
        }

        [Fact]
        public void Constructor_with_IsReadOnly_creates_successfully()
        {
            var name = GenerateRandomName();
            var isReadOnly = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                isReadOnly: isReadOnly
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().BeNull();
            sut.DataType.Should().BeNull();
            sut.AllowDBNull.Should().BeNull();
            sut.ColumnSize.Should().BeNull();
            sut.NumericPrecision.Should().BeNull();
            sut.NumericScale.Should().BeNull();
            sut.IsUnique.Should().BeNull();
            sut.IsKey.Should().BeNull();
            sut.IsExpression.Should().BeNull();
            sut.IsReadOnly.Should().Be(isReadOnly);
        }

        [Fact]
        public void Constructor_with_all_arguments_populated_creates_successfully()
        {
            var name = GenerateRandomName();
            var ordinal = GenerateRandomOrdinal();
            var dataType = GenerateRandomDataType();
            var AllowDBNull = GenerateRandomBool();
            var columnSize = GenerateRandomColumnSize();
            var numericPrecision = GenerateRandomNumericPrecision();
            var numericScale = GenerateRandomNumericScale();
            var isUnique = GenerateRandomBool();
            var isKey = GenerateRandomBool();
            var isExpression = GenerateRandomBool();
            var isReadOnly = GenerateRandomBool();

            // Act
            var sut = new TableColumnDefinition(
                name,
                columnOrdinal: ordinal,
                dataType: dataType,
                allowDBNull: AllowDBNull,
                columnSize: columnSize,
                numericPrecision: numericPrecision,
                numericScale: numericScale,
                isUnique: isUnique,
                isKey: isKey,
                isExpression: isExpression,
                isReadOnly: isReadOnly
            );

            // Assert
            sut.Should().NotBeNull();
            sut.ColumnName.Should().Be(name);
            sut.ColumnOrdinal.Should().Be(ordinal);
            sut.DataType.Should().Be(dataType);
            sut.AllowDBNull.Should().Be(AllowDBNull);
            sut.ColumnSize.Should().Be(columnSize);
            sut.NumericPrecision.Should().Be(numericPrecision);
            sut.NumericScale.Should().Be(numericScale);
            sut.IsUnique.Should().Be(isUnique);
            sut.IsKey.Should().Be(isKey);
            sut.IsExpression.Should().Be(isExpression);
            sut.IsReadOnly.Should().Be(isReadOnly);
        }
    }
}
