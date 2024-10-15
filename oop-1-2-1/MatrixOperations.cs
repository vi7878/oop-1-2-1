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
}