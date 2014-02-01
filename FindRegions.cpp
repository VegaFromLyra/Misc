// FindRegions.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <list>

using namespace std;

class Block
{

public:

	Block() {};
	Block (int row, int column)
	{ 
		this->row = row;
		this->column = column;
	};

	~Block() {}

	int row;
	int column;
};

void Initialize(bool** matrix, int row, int column)
{
	for (int i = 0; i < row; i++)
	{
		for (int j = 0; j < column; j++)
		{
			matrix[i][j] = false;
		}
	}
}

// from given (row, column) block find the next true block, searching 
// bfs manner
Block* FindNextTrueBlock(bool** matrix, int row, int column, int rows, int columns)
{
	for (int i = row; i < rows; i++)
	{
		for (int j = column; j < columns; j++)
		{
			if (matrix[i][j] == true)
			{
				Block* block = new Block(i, j);
				return block;
			}
		}
	}

	return NULL;
}

void ExtendBlock(Block& block, list<Block>& visitedBlocks, bool** matrix, int rows, int columns)
{
	// row, column - 1
	// row - 1, column
	// row, column + 1
	// row + 1, column

	if ((block.column - 1) > 0)
	{
		if (matrix[block.row][block.column - 1] == true)
		{
			Block* addBlock = new Block(block.row, block.column - 1);
			visitedBlocks.push_back(*addBlock);
		}
	}

    if ((block.row - 1) > 0)
	{
		if (matrix[block.row - 1][block.column] == true)
		{
			Block* addBlock = new Block(block.row - 1, block.column);
			visitedBlocks.push_back(*addBlock);
		}
	}

	if ((block.column + 1) < columns)
	{
		if (matrix[block.row][block.column + 1] == true)
		{
			Block* addBlock = new Block(block.row, block.column + 1);
			visitedBlocks.push_back(*addBlock);
		}
	}

	if ((block.row + 1) < rows)
	{
		if (matrix[block.row + 1][block.column] == true)
		{
			Block* addBlock = new Block(block.row + 1, block.column);
			visitedBlocks.push_back(*addBlock);
		}
	}
}

bool IsVisited(Block* trueBlock, list<Block> visitedBlocks)
{
	for (list<Block>::iterator iter = visitedBlocks.begin(); iter != visitedBlocks.end(); iter++)
	{
		Block block = *iter;
		if ((block.row == trueBlock->row) &&
			(block.column == trueBlock->column))
		{
			return true;
		}
	}

	return false;
}

int GetRegions(bool** matrix, int rows, int columns)
{
	int countRegions = 0;
	int row = 0;
	int column = 0;
	Block* trueBlock = FindNextTrueBlock(matrix, row, column, rows, columns);
	list<Block> visitedBlocks;

	while ((trueBlock != NULL) && (!IsVisited(trueBlock, visitedBlocks)))
	{
		countRegions++;
		visitedBlocks.push_back(*trueBlock);
		ExtendBlock(*trueBlock, visitedBlocks, matrix, rows, columns);

		if ((trueBlock->row == (rows - 1)) &&
			(trueBlock->column == (columns - 1)))
		{
			break;
		}
		else
		{
			if ((trueBlock->column) < columns)
			{
				// move to next column, same row
				column = trueBlock->column + 1;
			}
			else
			{
				// move to next row, first column
				row++;
				column = 0;
			}
		}

		trueBlock = FindNextTrueBlock(matrix, row, column, rows, columns);
	}

	// TODO 
	// need to free up visitedBlocks

	return countRegions;
}

int _tmain(int argc, _TCHAR* argv[])
{
	bool** inputArray = NULL;
	int rows = 2;
	int columns = 2;
	inputArray = new bool* [rows];

	for (int i = 0; i < rows; i++)
	{
		inputArray[i] = new bool[columns];
	}

	// Initialize(inputArray, rows, columns);

	inputArray[0][0] = true;
	inputArray[0][1] = true;
	inputArray[1][0] = true;
	inputArray[1][1] = true;

	cout << "The number of regions is " << GetRegions(inputArray, rows, columns) << endl;

	delete inputArray;

	return 0;
}

