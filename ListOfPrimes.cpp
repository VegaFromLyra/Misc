#include "stdafx.h"
#include <list>
#include <math.h>
#include <iostream>

using namespace std;

bool IsPrime(int num)
{
    if (num < 2)
    {
        return false;
    }

    for(int i = 2; i <= (int)sqrt(num); i++)
    {
        if (num % i == 0)
        {
            return false;
        }
    }

    return true;
}

list<int> GetPrimesLessThanN(int n)
{
    list<int> result;

    for(int i = 1; i < n; i++)
    {
        if (IsPrime(i))
        {
            result.push_back(i);
        }
    }

    return result;
}