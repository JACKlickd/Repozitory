#include "Lib2.h"
#include "stdafx.h"

using namespace std;

class Ryadok
{
public:

	char str[10];

	Ryadok(char r[10])
	{
		for (int i = 0; i < 10; i++)
			str[i] = r[i];
	}

	char& operator[] (const int index);
};

char& Ryadok::operator[] (const int index)
{
	return str[index];
}