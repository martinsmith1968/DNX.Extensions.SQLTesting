using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DNX.Extensions.SQL.Objects;

// ReSharper disable PossibleMultipleEnumeration

namespace DNX.Extensions.SQL.Extensions;

/// <summary>
/// Table Column Definition Extensions
/// </summary>
public static class TableColumnDefinitionExtensions2
{
    /// <summary>
    /// Verifies the table columns.
    /// </summary>
    /// <param name="tableColumnDefinitions">The table column definitions.</param>
    /// <param name="schemaResult">The schema result.</param>
    /// <param name="outputWriter">The output writer.</param>
    /// <exception cref="ArgumentNullException">
    /// tableColumnDefinitions
    /// or
    /// schemaResult
    /// </exception>
    /// <exception cref="Exception">
    /// {nameof(schemaResult)} column count is not {nameof(tableColumnDefinitions)} column count
    /// or
    /// Column: {column.Name} {nameof(TableColumnDefinition.MaxLength)} is not {column.MaxLength}
    /// or
    /// Column: {column.Name} {nameof(TableColumnDefinition.NumericScale)} is not {column.NumericScale}
    /// or
    /// Column: {column.Name} {nameof(TableColumnDefinition.NumericPrecision)} is not {column.NumericPrecision}
    /// </exception>
    /// <exception cref="InvalidDataException">
    /// Column: {column.Name} not found
    /// or
    /// Column: {column.Name} {nameof(TableColumnDefinition.DataType)} is not {column.DataType}
    /// or
    /// Column: {column.Name} {nameof(TableColumnDefinition.AllowDBNull)} is not {column.AllowDBNull}
    /// </exception>
    public static void VerifyTableColumns(this IEnumerable<TableColumnDefinition> tableColumnDefinitions,
        IDictionary<string, Dictionary<string, object>> schemaResult,
        Action<string> outputWriter = null
    )
    {
        if (tableColumnDefinitions == null) throw new ArgumentNullException(nameof(tableColumnDefinitions));
        if (schemaResult == null) throw new ArgumentNullException(nameof(schemaResult));

        if (schemaResult.Count != tableColumnDefinitions.Count())
            throw new Exception($"{nameof(schemaResult)} column count is not {nameof(tableColumnDefinitions)} column count");

        foreach (var column in tableColumnDefinitions)
        {
            if (!schemaResult.ContainsKey(column.ColumnName))
                throw new InvalidDataException($"Column: {column.ColumnName} not found");
            outputWriter?.Invoke($"Column {column.ColumnName} exists");

            if (column.DataType != null)
            {
                if (schemaResult[column.ColumnName][Constants.SchemaColumnNames.DataType] as Type != column.DataType)
                    throw new InvalidDataException($"Column: {column.ColumnName} {nameof(TableColumnDefinition.DataType)} is not {column.DataType}");

                outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.DataType)} is {column.DataType}");
            }

            if (column.AllowDBNull.HasValue)
            {
                if (Convert.ToBoolean(schemaResult[column.ColumnName][Constants.SchemaColumnNames.AllowDBNull]) != column.AllowDBNull.Value)
                    throw new InvalidDataException($"Column: {column.ColumnName} {nameof(TableColumnDefinition.AllowDBNull)} is not {column.AllowDBNull}");

                outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.AllowDBNull)} is {column.AllowDBNull}");
            }

            if (column.ColumnSize.HasValue)
            {
                if (Convert.ToInt32(schemaResult[column.ColumnName][Constants.SchemaColumnNames.ColumnSize]) != column.ColumnSize.Value)
                    throw new Exception($"Column: {column.ColumnName} {nameof(TableColumnDefinition.ColumnSize)} is not {column.ColumnSize}");

                outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.ColumnSize)} is {column.ColumnSize}");
            }

            if (column.NumericScale.HasValue)
            {
                if (Convert.ToInt32(schemaResult[column.ColumnName][Constants.SchemaColumnNames.NumericScale]) != column.NumericScale.Value)
                    throw new Exception($"Column: {column.ColumnName} {nameof(TableColumnDefinition.NumericScale)} is not {column.NumericScale}");

                outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.NumericScale)} is {column.NumericScale}");
            }

            if (column.NumericPrecision.HasValue)
            {
                if (Convert.ToInt32(schemaResult[column.ColumnName][Constants.SchemaColumnNames.NumericPrecision]) != column.NumericPrecision.Value)
                    throw new Exception($"Column: {column.ColumnName} {nameof(TableColumnDefinition.NumericPrecision)} is not {column.NumericPrecision}");

                outputWriter?.Invoke($"Column {column.ColumnName} {nameof(TableColumnDefinition.NumericPrecision)} is {column.NumericPrecision}");
            }
        }
    }
}
