#include <windows.h> 
#include <GL/gl.h>
#include <GL/glu.h>
#include <GL/GLAux.h>
#include <math.h>

void CALLBACK resize(int width, int height);
void CALLBACK display(void);
void CALLBACK rotateLeft();
void CALLBACK rotateRight();
void CALLBACK rotateUp();
void CALLBACK rotateDown();
double angleX = 0.0;
double angleY = 0.0;

void main()
{
	auxInitDisplayMode(AUX_RGBA | AUX_DEPTH | AUX_DOUBLE);
	auxInitPosition(50, 10, 400, 400);
	auxInitWindow("OpenGL");
	auxIdleFunc(display);
	auxReshapeFunc(resize);

	glEnable(GL_ALPHA_TEST);
	glEnable(GL_DEPTH_TEST);
	glEnable(GL_COLOR_MATERIAL);
	glEnable(GL_BLEND);
	glBlendFunc(GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA);
	glEnable(GL_LIGHTING);
	glEnable(GL_LIGHT0);
	float pos[4] = { 3, 3, 3, 1 };
	float dir[3] = { -1, -1, -1 };
	glLightfv(GL_LIGHT0, GL_POSITION, pos);
	glLightfv(GL_LIGHT0, GL_SPOT_DIRECTION, dir);

	auxKeyFunc(AUX_LEFT, rotateLeft);
	auxKeyFunc(AUX_RIGHT, rotateRight);
	auxKeyFunc(AUX_UP, rotateUp);
	auxKeyFunc(AUX_DOWN, rotateDown);

	auxMainLoop(display);
}
void CALLBACK resize(int width, int height)
{
	// ”казание окна дл€ вывода кадра OpenGL
	glViewport(0, 0, width, height);
	glMatrixMode(GL_PROJECTION);
	glLoadIdentity();
	glOrtho(-5, 5, -5, 5, 2, 12);
	//eye pos, center, up-vector
	gluLookAt(5, 0, 0, 0, 0, 0, 0, 1, 0);
	glMatrixMode(GL_MODELVIEW);
}
void CALLBACK display(void)
{
	glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

	glPushMatrix();
	{
		glRotated(angleY, 0, 1, 0);
		glRotated(angleX, 1, 0, 0);

		//auxSolidCube(3);
		/*
		glBegin(GL_TRIANGLES);
		{
			glVertex3d(0, 0, 0);
			glVertex3d(3, 0, 0);
			glVertex3d(3, 0, 3);

			glVertex3d(0, 0, 0);
			glVertex3d(3, 0, 3);
			glVertex3d(0, 0, 3);

			glVertex3d(0, 0, 0);
			glVertex3d(1.5, 3, 1.5);
			glVertex3d(0, 0, 3);

			glVertex3d(0, 0, 3);
			glVertex3d(1.5, 3, 1.5);
			glVertex3d(3, 0, 3);

			glVertex3d(3, 0, 3);
			glVertex3d(1.5, 3, 1.5);
			glVertex3d(3, 0, 0);

			glVertex3d(3, 0, 0);
			glVertex3d(1.5, 3, 1.5);
			glVertex3d(0, 0, 0);
		}
		glEnd();
		*/
	}
	glPopMatrix();


	auxSwapBuffers();
}

void CALLBACK rotateLeft(void)
{
	angleY -= 2;
}

void CALLBACK rotateRight(void)
{
	angleY += 2;
}

void CALLBACK rotateUp(void)
{
	angleX += 2;
}

void CALLBACK rotateDown(void)
{
	angleX -= 2;
}