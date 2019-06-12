#include <iostream>
#include <conio.h>

void func_dynamic_arr2(int **arr)
{
	printf("%d\n", arr[0][0]);
}

void func_dynamic_arr(int *arr)
{
	printf("%d\n", arr[0]);
}

void func(int a[][2])
{
	printf("%d\n", a[2][1]);
}

int main()
{
	int arr[3][2] = { 
		{ 1, 2 },
		{ 3, 4 },
		{ 5, 6 }
	};

	func(arr);

	//------- Динамический массив

	int *arr_pointer = new int[50];

	for (int i = 0; i < 50; i++)
	{
		arr_pointer[i] = i;
	}

	func_dynamic_arr(arr_pointer);

	delete[] arr_pointer;

	//------- Динамический 2-мерный массив

	int **arr2_pointer = new int*[50];

	for (int i = 0; i < 50; i++)
	{
		arr2_pointer[i] = new int[10];
		for (int j = 0; j < 10; j++)
		{
			arr2_pointer[i][j] = j;
		}
	}

	func_dynamic_arr2(arr2_pointer);


	for (int i = 0; i < 50; i++)
	{
		delete [] arr2_pointer[i];
	}

	delete [] arr2_pointer;

	_getch();
	return 0;
}