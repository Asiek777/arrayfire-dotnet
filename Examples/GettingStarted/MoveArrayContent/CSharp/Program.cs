using ArrayFire;
using System;

namespace GettingStarted__MoveArrayContent__CSharp_
{
    class Program
    {
        static void Main(string[] args)
        {
            Device.SetBackend(Backend.CPU);
            Device.PrintInfo();

            float[] data = new float[] {1.1f, 1.2f, 1.3f, 1.4f,
                                        2.1f, 2.2f, 2.3f, 2.4f,
                                        3.1f, 3.2f, 3.3f, 3.4f,
                                        4.1f, 4.2f, 4.3f, 4.4f };
            ArrayFire.Array A = Data.CreateArray(data);
            ArrayFire.Array A_4D = Data.ModDimensions(A, 2, 2, 2, 2);
            ArrayFire.Array A_2D = Data.ModDimensions(A, 4, 4);

            Console.Write("--\nModifying dimensions of array\n");

            Util.Print(A, "A");
            Util.Print(A_2D, "A_2D = Data.ModDimensions(A, 4, 4)");
            Util.Print(A_4D, "A_4D = Data.ModDimensions(A, 2, 2, 2, 2)");

            Util.Print(Data.Flat(A_2D), "Data.Flat(A_2D)");

            Console.Write("--\nFLipping data along specified dimension\n");

            Util.Print(A_4D, "A_4D");
            Util.Print(Data.Flip(A_4D, 3), "Data.Flip(A_4D, 3)");
            Util.Print(A_2D, "A_2D");
            Util.Print(Data.Flip(A_2D, 1), "Data.Flip(A_2D, 1)");


            Console.Write("--\nShifting data along specified dimensions\n");

            Util.Print(A_2D, "A_2D");
            Util.Print(Data.Shift(A_2D, 2), "Data.Shift(A_2D, 2)");
            Util.Print(Data.Shift(A_2D, 1, 1), "Data.Shift(A_2D, 1, 1)");

            Console.Write("--\nTransposing Matrix\n");

            Util.Print(A_2D, "A_2D");
            Util.Print(Matrix.Transpose(A_2D, false), "Matrix.Transpose(A_2D, false)");

            Console.Write("--\nTile Array\n");
            Util.Print(A_4D, "A_4D");
            Util.Print(Data.Tile(A_4D, 1, 2, 1, 1), "Data.Tile(A_4D, 1, 2, 1, 1)");

            Console.Write("--\nJoining arrays\n");

            Util.Print(Data.Join(0, A_4D[Util.Span, Util.Span, 1, 1], A_2D[Util.Seq(0, 1), Util.Seq(0, 1)]),
                "Data.Join(1, A_4D[1, 1, Util.Span, Util.Span], A_2D[Util.Seq(0, 2), Util.Seq(0, 2)])");

            Console.Write("--\nReordering arrays\n");
            Util.Print(A_2D, "A_2D");
            Util.Print(Data.Reorder(A_2D, 1, 0), "Data.Reorder(A_2D, 1, 0)");
        }
    }
}
