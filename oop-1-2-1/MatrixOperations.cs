using System;

public partial class MyMatrix
{
    public static MyMatrix operator +(MyMatrix a, MyMatrix b)
    {
        if (a.Height != b.Height || a.Width != b.Width)
            throw new ArgumentException("Для додавання матриці мають бути однакової розмірності");

        double[,] result = new double[a.Height, a.Width];
        for (int i = 0; i < a.Height; i++)
        for (int j = 0; j < a.Width; j++)
            result[i, j] = a[i, j] + b[i, j];

        return new MyMatrix(result);
    } 
    public static MyMatrix operator *(MyMatrix a, MyMatrix b)
    {
        if (a.Width != b.Height)
            throw new ArgumentException("К-ть рядків першої матриці має співпадати з к-тю стовпчиків іншої");

        double[,] result = new double[a.Height, b.Width];
        for (int i = 0; i < a.Height; i++)
        for (int j = 0; j < b.Width; j++)
        for (int k = 0; k < a.Width; k++)
            result[i, j] += a[i, k] * b[k, j];

        return new MyMatrix(result);
    }
}