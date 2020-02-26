#include "Header.h"
#include "pch.h"
#include <iostream>

using namespace std;

void Inc(int a);

bool Equal(int b, int c);

int main()
{
	int a, b, c;
	bool e;
	cout << "Enter first number: ";
	cin >> a;
	Inc(a);
	cout << "Enter second number: ";
	cin >> b;
	cout << "Enter third number: ";
	cin >> c;
	e = Equal(b, c);
	if (e) cout << "Numbers are equal." << endl;
	else cout << "Numbers are not equal." << endl;
	system ("pause");
}