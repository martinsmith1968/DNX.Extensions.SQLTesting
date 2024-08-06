using System;

namespace DNX.Extensions.SQL.Objects;

/// <summary>
/// Represents a column in a table
/// </summary>
public class TableColumnDefinition
{
    public string ColumnName { get; private set; }

    public int? ColumnOrdinal { get; private set; }

    public int? ColumnSize { get; private set; }

    public Type DataType { get; private set; }

    public bool? AllowDBNull { get; private set; }

    public int? NumericPrecision { get; private set; }

    public int? NumericScale { get; private set; }

    public bool? IsUnique { get; private set; }

    public bool? IsKey { get; private set; }

    public bool? IsExpression { get; private set; }

    public bool? IsReadOnly { get; private set; }

    public bool? IsIdentity { get; private set; }

    public bool? IsAutoIncrement { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="TableColumnDefinition" /> class.
    /// </summary>
    /// <param name="columnName">The columnName.</param>
    /// <param name="columnOrdinal">The column ordinal position.</param>
    /// <param name="columnSize">The size of the column.</param>
    /// <param name="dataType">Type of the data.</param>
    /// <param name="allowDBNull">The column allows nulls.</param>
    /// <param name="numericPrecision">The numeric Precision.</param>
    /// <param name="numericScale">The numeric scale.</param>
    /// <param name="isUnique">Are the values in this column unique.</param>
    /// <param name="isKey">Is this a key.</param>
    /// <param name="isExpression">Is this an expression.</param>
    /// <param name="isReadOnly">Is this read only.</param>
    /// /// <param name="isIdentity">Is this an Identity column.</param>
    /// /// <param name="isAutoIncrement">Is this column an Auto Incrementing value.</param>
    public TableColumnDefinition(
        string columnName
        , int? columnOrdinal = null
        , int? columnSize = null
        , Type dataType = null
        , bool? allowDBNull = null
        , int? numericPrecision = null
        , int? numericScale = null
        , bool? isUnique = null
        , bool? isKey = null
        , bool? isExpression = null
        , bool? isReadOnly = null
        , bool? isIdentity = null
        , bool? isAutoIncrement = null
    )
    {
        ColumnName       = columnName;
        ColumnOrdinal    = columnOrdinal;
        ColumnSize       = columnSize;
        DataType         = dataType;
        AllowDBNull      = allowDBNull;
        NumericPrecision = numericPrecision;
        NumericScale     = numericScale;
        IsUnique         = isUnique;
        IsKey            = isKey;
        IsExpression     = isExpression;
        IsReadOnly       = isReadOnly;
        IsIdentity       = isIdentity;
        IsAutoIncrement  = isAutoIncrement;
    }

    public TableColumnDefinition WithColumnOrdinal(int? columnOrdinal)
    {
        ColumnOrdinal = columnOrdinal;
        return this;
    }

    public TableColumnDefinition WithColumnSize(int? columnSize)
    {
        ColumnSize = columnSize;
        return this;
    }

    public TableColumnDefinition WithDataType(Type dataType)
    {
        DataType = dataType;
        return this;
    }

    public TableColumnDefinition WithAllowDBNull(bool? allowDBNull = true)
    {
        AllowDBNull = allowDBNull;
        return this;
    }

    public TableColumnDefinition WithPrecision(int? numericPrecision)
    {
        NumericPrecision = numericPrecision;
        return this;
    }

    public TableColumnDefinition WithScale(int? numericScale)
    {
        NumericScale = numericScale;
        return this;
    }

    public TableColumnDefinition WithIsUnique(bool? isUnique = true)
    {
        IsUnique = isUnique;
        return this;
    }

    public TableColumnDefinition WithIsKey(bool? isKey = true)
    {
        IsKey = isKey;
        return this;
    }

    public TableColumnDefinition WithIsExpression(bool? isExpression = true)
    {
        IsExpression = isExpression;
        return this;
    }

    public TableColumnDefinition WithIsReadOnly(bool? isReadOnly = true)
    {
        IsReadOnly = isReadOnly;
        return this;
    }

    public TableColumnDefinition WithIsIdentity(bool? isIdentity = true)
    {
        IsIdentity = isIdentity;
        return this;
    }

    public TableColumnDefinition WithIsAutoIncrement(bool? isAutoIncrement = true)
    {
        IsAutoIncrement = isAutoIncrement;
        return this;
    }
}
