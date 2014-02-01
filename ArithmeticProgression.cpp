// ArithmeticProgression.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <iostream>
#include <vector>
#include <sstream>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
    int n = 0;

    do
    {
        cout << "Enter number of values\n";
        cin >> n;
    }
    while (n <= 1);

    string input;

    do
    {
        input.clear();
        cout << "Please, enter at least one value: ";
        cin.ignore();
        getline (std::cin,input);
    }
    while (input.length() <= 2);

    istringstream stringStream(input);
    int temp;

    vector<int> list;
    while(stringStream >> temp)
    {
       list.push_back(temp);
    }

    // Find missing number

    int difference = list[1] - list[0];

    // 1, 3, 5, 9, 11

    int missingValue = 0;

    for(int i = 0; i < n - 1; i++)
    {
        if (list[i + 1] - list[i] != difference)
        {
            missingValue =  list[i] + difference;
            break;
        }
    }

    if (missingValue == 0)
    {
        cout << "Missing value not found\n";
    }
    else
    {
        cout << "Missing value is " << missingValue << endl;
    }

    return 0;
}

