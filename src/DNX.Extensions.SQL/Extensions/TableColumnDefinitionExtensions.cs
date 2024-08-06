using System;
using System.Collections.Generic;
using System.Linq;
using DNX.Extensions.SQL.Objects;
using Shouldly;

// ReSharper disable PossibleMultipleEnumeration

namespace DNX.Extensions.SQL.Extensions;

public static class TableColumnDefinitionExtensions
{
    public static void AssertAll(this IEnumerable<TableColumnDefinition> tableColumnDefinitions,
        IDictionary<string, Dictionary<string, object>> schemaResult,
        Action<string> outputWriter = null
        )
    {
        tableColumnDefinitions.ShouldNotBeNull($"{nameof(tableColumnDefinitions)} not supplied");
        schemaResult.ShouldNotBeNull($"{nameof(schemaResult)} not supplied");

        tableColumnDefinitions.Count().ShouldBe(schemaResult.Count, $"{nameof(tableColumnDefinitions)} column count is not {nameof(schemaResult)} column count");

        foreach (var column in tableColumnDefinitions)
        {
            var columnExists = schemaResult.TryGetValue(column.ColumnName, out var schemaResultColumnDefinition);
            columnExists.ShouldBeTrue($"Column: {column.ColumnName} not found");
            schemaResult.ShouldNotBeNull($"Column: {column.ColumnName} not found");
            outputWriter?.Invoke($"Column: {column.ColumnName} exists");

            column.AssertColumnName(schemaResultColumnDefinition, outputWriter);
            column.AssertColumnOrdinal(schemaResultColumnDefinition, outputWriter);
            column.AssertColumnSize(schemaResultColumnDefinition, outputWriter);
            column.AssertDataType(schemaResultColumnDefinition, outputWriter);
            column.AssertAllowDBNull(schemaResultColumnDefinition, outputWriter);
            column.AssertPrecision(schemaResultColumnDefinition, outputWriter);
            column.AssertNumericScale(schemaResultColumnDefinition, outputWriter);
            column.AssertIsUnique(schemaResultColumnDefinition, outputWriter);
            column.AssertIsKey(schemaResultColumnDefinition, outputWriter);
            column.AssertIsExpression(schemaResultColumnDefinition, outputWriter);
            column.AssertIsReadOnly(schemaResultColumnDefinition, outputWriter);
            column.AssertIsIdentity(schemaResultColumnDefinition, outputWriter);
            column.AssertIsAutoIncrement(schemaResultColumnDefinition, outputWriter);
        }
    }

    public static void AssertColumnName(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.ColumnName];

        column.ColumnName.ShouldBe(
            schemaValue,
            $"Column: {column.ColumnName} {nameof(TableColumnDefinition.ColumnName)} is not {column.ColumnName}"
        );

        outputWriter?.Invoke($"Column {column.ColumnName} {Constants.SchemaColumnNames.ColumnName} is {column.ColumnName}");
    }

    public static void AssertColumnOrdinal(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.ColumnOrdinal.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.ColumnOrdinal];

            column.ColumnOrdinal.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.ColumnOrdinal)} is not {column.ColumnOrdinal}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.ColumnOrdinal)} is {column.ColumnOrdinal}");
        }
    }

    public static void AssertDataType(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
        )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.DataType != null)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.DataType];

            column.DataType.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.DataType)} is not {column.DataType}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.DataType)} is {column.DataType}");
        }
    }

    public static void AssertAllowDBNull(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.AllowDBNull.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.AllowDBNull];

            column.AllowDBNull.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.AllowDBNull)} is not {column.AllowDBNull}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.AllowDBNull)} is {column.AllowDBNull}");
        }
    }

    public static void AssertColumnSize(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.ColumnSize.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.ColumnSize];

            column.ColumnSize.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.ColumnSize)} is not {column.ColumnSize}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.ColumnSize)} is {column.ColumnSize}");
        }
    }

    public static void AssertPrecision(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.NumericPrecision.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.NumericPrecision];

            column.NumericPrecision.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.NumericPrecision)} is not {column.NumericPrecision}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.NumericPrecision)} is {column.NumericPrecision}");
        }
    }

    public static void AssertNumericScale(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.NumericScale.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.NumericScale];

            column.NumericScale.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.NumericScale)} is not {column.NumericScale}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.NumericScale)} is {column.NumericScale}");
        }
    }

    public static void AssertIsUnique(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsUnique.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsUnique];

            column.IsUnique.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsUnique)} is not {column.IsUnique}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsUnique)} is {column.IsUnique}");
        }
    }

    public static void AssertIsKey(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsKey.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsKey];

            column.IsKey.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsKey)} is not {column.IsKey}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsKey)} is {column.IsKey}");
        }
    }

    public static void AssertIsExpression(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsExpression.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsExpression];

            column.IsExpression.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsExpression)} is not {column.IsExpression}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsExpression)} is {column.IsExpression}");
        }
    }

    public static void AssertIsReadOnly(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsReadOnly.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsReadOnly];

            column.IsReadOnly.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsReadOnly)} is not {column.IsReadOnly}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsReadOnly)} is {column.IsReadOnly}");
        }
    }

    public static void AssertIsIdentity(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsIdentity.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsIdentity];

            column.IsIdentity.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsIdentity)} is not {column.IsIdentity}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsIdentity)} is {column.IsIdentity}");
        }
    }

    public static void AssertIsAutoIncrement(
        this TableColumnDefinition column,
        Dictionary<string, object> schemaResultColumnDefinition,
        Action<string> outputWriter = null
    )
    {
        column.ShouldNotBeNull();
        schemaResultColumnDefinition.ShouldNotBeNull();

        if (column.IsAutoIncrement.HasValue)
        {
            var schemaValue = schemaResultColumnDefinition[Constants.SchemaColumnNames.IsAutoIncrement];

            column.IsAutoIncrement.Value.ShouldBe(
                schemaValue,
                $"Column: {column.ColumnName} {nameof(TableColumnDefinition.IsAutoIncrement)} is not {column.IsAutoIncrement}"
            );

            outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.IsAutoIncrement)} is {column.IsAutoIncrement}");
        }
    }
}
