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
}