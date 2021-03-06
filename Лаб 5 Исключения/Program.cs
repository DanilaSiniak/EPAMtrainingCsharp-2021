﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5exeptions
{
     static class MatrixGetRowsColumns
    {

  
        // получения количества строк матрицы
        public static int RowsCount(this int[,] matrix)
        {
            return matrix.GetLength(0);
        }

        //  получения количества столбцов матрицы
        public static int ColumnsCount(this int[,] matrix)
        {
            return matrix.GetLength(1);
        }

    }

    class Matrix
    {
        // получения матрицы из консоли
        static int[,] GetMatrixFromConsole(string name)
        {
            Console.Write("Количество строк матрицы {0}:    ", name);
            var r = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы {0}: ", name);
            var c = int.Parse(Console.ReadLine());

           
            var matrix = new int[r, c];



            for (var i = 0; i < r; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }

        // метод для вывода матрицы на экран
        static void PrintMatrix(int[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        // метод для сложения двух матриц
        static int[,] MatrixSum(int[,] matrixA, int[,] matrixB)
        {
            
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    try
                    {
                        matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                    catch(IndexOutOfRangeException) 
                    {
                        throw new Exception("Операция невозможна! Количество столбцов первой матрицы не равно количеству строк второй матрицы." +
                            "последующие операции так же невозможны");
                    }
                }
            }

            return matrixC;
        }

        // метод для умножения матриц
        static int[,] MatrixMultiplication(int[,] matrixA, int[,] matrixB)
        {
           
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        try
                        {
                         matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                        catch(IndexOutOfRangeException)
                        {
                            throw new Exception("Операция невозможна! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                        }
                       
                    }
                }
            }

            return matrixC;
        }

        // метод для вычитания двух матриц
        static int[,] MatrixSubstract(int[,] matrixA, int[,] matrixB)
        {
          
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;
                    try
                    {
                       matrixC[i, j] = matrixA[i, j] - matrixB[i, j];
                    }
                                        
                    catch (IndexOutOfRangeException)
                    {
                            throw new Exception("Операция невозможна! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                    }
                
                    
                }
            }

            return matrixC;
        }
        //// Задание создать  метод GetEmpty(…), который возвращает нулевую матрицу заданного размера
        static int[,] MatrixGetEmpty(int[,] matrixA, int[,] matrixB)
        {
            var matrixC = new int[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for(var i = 0; i < matrixA.RowsCount(); i++ )
            {
                for ( var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    try
                    {
                        matrixC[i, j] = 0;
                    }
                    catch (IndexOutOfRangeException)
                    {

                        throw new Exception("Операция невозможна! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
                    }
                    
                }
            }


            return matrixC;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Программа для сложения/произведение/вычитания двух матриц");

            var a = GetMatrixFromConsole("A");
            var b = GetMatrixFromConsole("B");


            Console.WriteLine("Матрица A:");
            PrintMatrix(a);

            Console.WriteLine("Матрица B:");
            PrintMatrix(b);

            //// Результат сложения матриц
            var resultSum = MatrixSum(a, b);
            Console.WriteLine("Сумма матриц:");
            PrintMatrix(resultSum);

            //// Результат произведения матриц
            var resultMultiplication = MatrixMultiplication(a, b);
            Console.WriteLine("Произведение матриц:");
            PrintMatrix(resultMultiplication);

            //// Разность матриц
            var resultSubstract = MatrixSubstract(a, b);
            Console.WriteLine("Разность матриц: ");
            PrintMatrix(resultSubstract);

            //// Метод GetEmpty
            var resultMatrixGetEmpty = MatrixGetEmpty(a, b);
            Console.WriteLine("Нулевая матрица: ");
            PrintMatrix(resultMatrixGetEmpty);

            Console.ReadLine();
        }
    }
}
