#include "pch.h"
#include <iostream>
#include "C:\Users\Vlad\source\repos\Lab2+\StaticLib2/Lib2.h"

using namespace std;

int main()
{
	int ind = -1;
	char a[10];
	cin >> a;
	Ryadok r1(a);
	/*Container main = new Container();
	main.Add(ref main.Text, r1, ref ind);
	main.Add(ref main.Text, r3, ref ind);
	main.Add(ref main.Text, r4, ref ind);
	Output(main.Text, ind);
	main.Remove(ref main.Text, r3, ref ind);
	Output(main.Text, ind);
	main.Clear(ref main.Text, ref ind);
	Output(main.Text, ind);
	main.Add(ref main.Text, r3, ref ind);
	main.Add(ref main.Text, r2, ref ind);
	main.Add(ref main.Text, r2, ref ind);
	Output(main.Text, ind);
	Console.WriteLine(main.Find(main.Text, r2, ind));
	main.Replace(ref main.Text, r2, r1, ind);
	Output(main.Text, ind);*/
	system("pause");
	return 0;
}

static void Output(Ryadok Text[], int ind)
{
	for (int i = 0; i <= ind; i++)
		cout << Text[i].str;
	cout << '/n';
}
