#include <iostream>
#include <conio.h>
#include <mpi.h>

int main(int *argc, char **argv)
{
	MPI_Init(argc, &argv);

	int a[100];

	for (int i = 0; i < 100; i++)
	{
		a[i] = i + 1;
	}
	//Требуется умножить все элементы на 2

	int rank;
	int size;
	MPI_Comm_rank(MPI_COMM_WORLD, &rank);
	MPI_Comm_size(MPI_COMM_WORLD, &size);

	printf("%d\n", rank);
	printf("%d\n", size);

	if (rank == 0)
	{
		for (int i = 0; i < 50; i++)
		{
			a[i] *= 2;
		}

		MPI_Recv(a + 50, 50, MPI_INTEGER, 1, MPI_ANY_TAG, MPI_COMM_WORLD, MPI_STATUSES_IGNORE);

		for (int i = 0; i < 100; i++)
		{
			printf("%d\n", a[i]);
		}
	}
	else
	{
		for (int i = 50; i < 100; i++)
		{
			a[i] *= 2;
		}

		MPI_Send(a + 50, 50, MPI_INTEGER, 0, 0, MPI_COMM_WORLD); // MPI_Send(a + 50, ...);
	}


	MPI_Finalize();
	return 0;
}