// DeepCopy.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <string>
#include <iostream>

using namespace std;

class A
{
    public: 
        
    string member;

    // this assigment operator does a deep copy
    A& operator= (A& other)
    {
        A* obj = new A();
        obj->member.assign(member.c_str());
        return *obj;
    }
};

int _tmain(int argc, _TCHAR* argv[])
{
    A* obj1 = new A();

    obj1->member.assign("test");

    A obj2 = *obj1;

    obj1->member.assign("test2");

    cout << "Value is " << obj2.member.c_str() << endl;

	return 0;
}

