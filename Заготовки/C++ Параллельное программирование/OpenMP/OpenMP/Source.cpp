#include<iostream>
#include<conio.h>

using namespace std;

long long s = 0;

void Sum()
{
	long long _s = 0;
	for (int i = 0; i < 1000000; i++)
	{
		_s += 1;
	}

	#pragma omp critical
	s += _s;
}

//Свойства -> C/C++ -> язык -> openMP
int main()
{
	#pragma omp parallel
	{
		#pragma omp sections
		{
			#pragma omp section
			{
				Sum();
			}
			#pragma omp section
			{
				Sum();
			}
		}
	}

	printf("%d", s);
	_getch();
	return 0;
}