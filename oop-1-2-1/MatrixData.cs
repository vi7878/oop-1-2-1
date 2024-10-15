using System;
using System.Linq;
public partial class MyMatrix
{
    private readonly double[,] data;
    public int Height { get; }
    public int Width { get; }
    public MyMatrix(MyMatrix other)
    {
        Height = other.Height;
        Width = other.Width;
        data = new double[Height, Width];
        Array.Copy(other.data, data, other.data.Length);
    }
    public MyMatrix(double[,] array)
    {
        Height = array.GetLength(0);
        Width = array.GetLength(1);
        data = new double[Height, Width];
        Array.Copy(array, data, array.Length);
    }
    public MyMatrix(double[][] jaggedArray)
    {
        if (!jaggedArray.All(row => row.Length == jaggedArray[0].Length))
            throw new ArgumentException("Зубчастий масив - це не прямокутний");

        Height = jaggedArray.Length;
        Width = jaggedArray[0].Length;
        data = new double[Height, Width];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                data[i, j] = jaggedArray[i][j];
    }
    public MyMatrix(string[] rows)
    {
        var parsedRows = rows.Select(row => 
            row.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray()
        ).ToArray();
        if (!parsedRows.All(row => row.Length == parsedRows[0].Length))
            throw new ArgumentException("Масив рядків не представляє прямокутну матрицю");
        Height = parsedRows.Length;
        Width = parsedRows[0].Length;
        data = new double[Height, Width];
        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                data[i, j] = parsedRows[i][j];
    }
    public MyMatrix(string matrixString)
    {
        var rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        var parsedRows = rows.Select(row =>
            row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(double.Parse)
               .ToArray()
        ).ToArray();

        if (!parsedRows.All(row => row.Length == parsedRows[0].Length))
            throw new ArgumentException("Рядок не представляє прямокутну матрицю");

        Height = parsedRows.Length;
        Width = parsedRows[0].Length;
        data = new double[Height, Width];

        for (int i = 0; i < Height; i++)
            for (int j = 0; j < Width; j++)
                data[i, j] = parsedRows[i][j];
    }
    public int getHeight() => Height;
    public int getWidth() => Width;
    public double this[int i, int j]
    {
        get => data[i, j];
        set => data[i, j] = value;
    }
    public double GetElement(int i, int j) => data[i, j];
    public void SetElement(int i, int j, double value) => data[i, j] = value;
    public override string ToString()
    {
        string[] rows = new string[Height];
        for (int i = 0; i < Height; i++)
        {
            string[] rowElements = new string[Width];
            for (int j = 0; j < Width; j++)
            {
                rowElements[j] = data[i, j].ToString();
            }
            rows[i] = string.Join("\t", rowElements);
        }
        return string.Join("\n", rows);
    }
}