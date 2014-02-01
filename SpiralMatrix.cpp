// SpiralMatrix.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void PrintInSpiral(int matrix[4][4], int xSize, int ySize)
{
	int currentX = 0;
	int currentY = 0;
	int i = 0;

	xSize--;
	ySize--;

	while ((currentX <= xSize) && (currentY <= ySize))
	{
		for (i = currentY; i <= ySize; i++)
		{
			cout << matrix[currentX][i] << " " << endl;
		}
		currentX++;

		for (i = currentX; i <= xSize; i++)
		{
			cout << matrix[i][ySize] << " " << endl;
		}
		ySize--;

		for (i = ySize; i >= currentY; i--)
		{
			cout << matrix[xSize][i] << " " << endl;
		}
		xSize--;

		for (i = xSize; i >= currentX; i--)
		{
			cout << matrix[i][currentY] << " " << endl;
		}
		currentY++;
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	int matrix[4][4] =  {
						 {1, 2, 3, 4},
						 {5, 6, 7, 8},
						 {9, 10, 11, 12},
						 {13, 14, 15, 16}
					    };

	PrintInSpiral(matrix, 4, 4);

	return 0;
}

