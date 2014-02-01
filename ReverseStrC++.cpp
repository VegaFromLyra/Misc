// ReverseStrC++.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>

using namespace std;

void reverse (char* str)
{
   char* start = str;
   char* end = str;

   while (*end != NULL)
   {
       end++;
   }

   end--;

   while (start < end)
   {
       char temp = *start;
       *start = *end;
       *end = temp;

      start++;
      end--;
   }
}

int _tmain(int argc, _TCHAR* argv[])
{
	char str[] = "abcd\0";

	reverse(str);

	cout << str << endl;

	return 0;
}

