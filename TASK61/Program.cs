﻿
using System;
using static System.Console;

Clear();
int firstDimension = 16;
int secondDimension = firstDimension * 2;

WriteLine($"Треугольник Паскаля до {firstDimension}-го порядка");

int[,] matrix = GetRandomArray(firstDimension, secondDimension);
PrintArray(matrix);

WriteLine("");

int[,] GetRandomArray(int rows, int columns)
{
    int midle = columns / 2 + columns % 2;
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = midle - (i + 1); j <= midle + (i + 1); j += 2)
        {
            if (i == 0 & j == midle - (i + 1)) result[i, j] = 1;
            if (i > 0 & j == midle - (i + 1)) result[i, j] = 1;
            if (i > 0 && j > midle - (i + 1) && j < columns - 1) result[i, j] = result[i - 1, j - 1] + result[i - 1, j + 1];
        }
    }
    return result;
}



void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {

        for (int j = 0; j < array.GetLength(1); j++)
        {

            if (array[i, j].ToString().Length == 4) Write($" {array[i, j]}");
            if (array[i, j].ToString().Length == 3) Write($" {array[i, j]} ");
            if (array[i, j].ToString().Length == 2) Write($"  {array[i, j]} ");
            if (array[i, j].ToString().Length == 1 && array[i, j] != 0) Write($"  {array[i, j]}  ");
            if (array[i, j] == 0) Write($"     ");

        }
        WriteLine();
    }
}



