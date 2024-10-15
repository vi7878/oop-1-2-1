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
    
}