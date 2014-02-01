// LastKLinesFromFile.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <fstream>
#include <string>
#include <algorithm> // min

using namespace std;

void PrintLastKLines(char* filename, int k)
{
    ifstream file(filename);

    string* lines = new string[k];

    int count = 0;

    while (file.good())
    {
        getline(file, lines[count % k]);
        count++;
    }

    int start = count > k ? count % k : 0;

    int size = min(k, count);

    for(int i = 0; i < size; i++)
    {
        cout << lines[(start + i) % k] << endl;
    }

    delete[] lines;
}


int _tmain(int argc, _TCHAR* argv[])
{
    PrintLastKLines("sampleInput.txt", 3);
    return 0;
}



