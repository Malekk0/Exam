#include <iostream>
#include <conio.h>
#include <thread>
#include <mutex>
using namespace std;

mutex m1;

long long s = 0;

void func(long long b)
{
	long long _s = 0;
	for (long long i = 0; i < b; i++)
	{
		_s += 1;
	}

	m1.lock();
	s += _s;
	m1.unlock();
}

int main()
{
	thread t1(func, 10000000);
	thread *t2 = new thread(func, 10000000);

	t1.join();
	t2->join();

	delete t2;

	printf("%d", s);
	_getch();
	return 0;
}