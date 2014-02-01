// kLargestNumbers.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <queue>   //priority_queue
#include <iostream>
#include <functional> // greater
#include <list>

using namespace std;

list<int> GetkLargest(int input[], int length, int k)
{
    list<int> output;

    priority_queue<int, vector<int>, greater<int> > queue;

    for (int i = 0; i < length; i++)
    {
        if (queue.size() == k)
        {
            int value = queue.top();

            if (value < input[i])
            {
                queue.pop();
                queue.push(input[i]);
            }
        }
        else
        {
            queue.push(input[i]);
        }
    }

    while(queue.size() > 0)
    {
        output.push_back(queue.top());
        queue.pop();
    }

    return output;
}



int _tmain(int argc, _TCHAR* argv[])
{
    int k = 5;

    int input[] = {5, 7, 8, 9, 11, 100, 23, 15, 33, 167, 88};

    int length = sizeof(input) / sizeof(int);

    list<int> result = GetkLargest(input, length, k);
    
    for(list<int>::iterator iter = result.begin(); iter != result.end(); iter++)
    {
        cout << *iter << endl;
    }

    return 0;
}