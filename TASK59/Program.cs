/*
 Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.
 */

using System;
using static System.Console;

Clear();
int firstDimension = new Random().Next(4, 10); ;
int secondDimension = new Random().Next(4, 10); ;

WriteLine($"Сгенерирован случайный массиве {firstDimension}X{secondDimension}");

int[,] matrix = GetRandomArray(firstDimension, secondDimension);
PrintArray(matrix);
var (minRow, minColumn) = GetMinElementPosition(matrix);

WriteLine($"Минимальное значение елемента находится в сторе {minRow + 1} столбце {minColumn + 1}");

int[,] modifedMatrix = GetModifedArray(matrix, minRow, minColumn);

WriteLine($"Из двумерного массива целых чисел {firstDimension}X{secondDimension} удалили строку {minRow + 1} и столбец {minColumn + 1}, на пересечении которых расположен наименьший элемент:");

PrintArray(modifedMatrix);


int[,] GetModifedArray(int[,] array, int minRow, int minColumn)
{
    int[,] result = new int[array.GetLength(0) - 1, array.GetLength(1) - 1];
    for (int i = 0; i < array.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            if (i < minRow & j >= minColumn) result[i, j] = array[i, j + 1];
            if (i >= minRow & j < minColumn) result[i, j] = array[i + 1, j];
            if (i < minRow & j < minColumn) result[i, j] = array[i, j];
            if (i >= minRow & j >= minColumn) result[i, j] = array[i + 1, j + 1];
        }
    }
    return result;
}

(int RowPosition, int ColumnPosition) GetMinElementPosition(int[,] array) //поиск адреса строки и столбца с минимальным элементом (кортежи)
{
    int minElement = array[0, 0];
    int minElementRowPosition = 0;
    int minElementColumnPosition = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (minElement > array[i, j])
            {
                minElement = array[i, j];
                minElementRowPosition = i;
                minElementColumnPosition = j;
            }
        }
    }

    return (minElementRowPosition, minElementColumnPosition);
}

int[,] GetRandomArray(int rows, int columns)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int element;
            do
            {
                element = new Random().Next(10, 100);
            }
            while (SerchElement(result, element) == true);
            result[i, j] = element;
        }
    }
    return result;
}

bool SerchElement(int[,] array, int number)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (number == array[i, j]) return true;
        }
    }
    return false;
}


void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i, j]} ");
        }
        WriteLine("");
    }
}



