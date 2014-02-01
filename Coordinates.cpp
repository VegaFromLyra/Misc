// Coordinates.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <list>
#include <math.h>
#include <vector>
#include <algorithm>
#include <functional>
#include <iostream>

using namespace std;

#define MAX 5

// Time complexity - ?
// Space complexity - ?

struct Coordinate
{
    Coordinate()
    {

    }

    Coordinate(int p, int q)
    {
        x = p;
        y = q;
    };

    ~Coordinate()
    {
    }

    int x;
    int y;
};

struct CoordinateWithWeight
{
    CoordinateWithWeight()
    {
    }

    CoordinateWithWeight(Coordinate& pt, double dist)
    {
        point.x = pt.x;
        point.y = pt.y;
        distance = dist;
    };

    ~CoordinateWithWeight()
    {
    }

    Coordinate point;
    double distance;
    bool operator < (const CoordinateWithWeight & coord) const
    {
        return distance < coord.distance;
    }

    bool operator == (CoordinateWithWeight& coord)
    {
        if (coord.distance == distance)
        {
            return true;
        }

        return false;
    }
 };

double GetDistanceFromOrigin(Coordinate& point)
{
    return sqrt((point.x * point.x) + (point.y * point.y));
}

list<Coordinate> FindTop5FromOrigin(list<Coordinate> inputList)
{
    int count = 0;
    vector<CoordinateWithWeight> listCoordinates;

    for (list<Coordinate>::iterator iter = inputList.begin(); iter != inputList.end(); iter++)
    {
        double distance = GetDistanceFromOrigin(*iter);

        CoordinateWithWeight coordinate(*iter, distance);

        if (count < MAX)
        {
            listCoordinates.push_back(coordinate);
            make_heap(listCoordinates.begin(), listCoordinates.end());  // O(logn) 
        }
        else
        {
            if (distance < listCoordinates[0].distance)
            {
                listCoordinates.erase(listCoordinates.begin());  // O(1)

                listCoordinates.push_back(coordinate);
                make_heap(listCoordinates.begin(), listCoordinates.end());  // O(log(n)) ?
            }
        }

        count++;
    }

    list<Coordinate> outputList;
    for (vector<CoordinateWithWeight>::iterator iter = listCoordinates.begin(); iter != listCoordinates.end(); iter++)  // O(n) where n is ~ MAX
    {
        outputList.push_back(iter->point);
    }

    return outputList;
}


int _tmain(int argc, _TCHAR* argv[])
{
    Coordinate coord1(1, 1);
    Coordinate coord2(3, 3);
    Coordinate coord3(4, 4);
    Coordinate coord4(5, 5);
    Coordinate coord5(6, 6);
    Coordinate coord6(2, 2);

    list<Coordinate> input;

    input.push_back(coord1);
    input.push_back(coord2);
    input.push_back(coord3);
    input.push_back(coord4);
    input.push_back(coord5);
    input.push_back(coord6);

    list<Coordinate> closeCoordinates = FindTop5FromOrigin(input);

    cout << "The closest co-ordinates are\n";

    for (list<Coordinate>::iterator iter = closeCoordinates.begin(); iter != closeCoordinates.end(); iter++)
    {
        cout << "X: " << (*iter).x << " Y: " << (*iter).y << endl; 
    }

	return 0;

}

