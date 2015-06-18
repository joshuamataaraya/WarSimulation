#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <math.h>

int main()
{
    int i=200000;
    float grado;
    int id;
    char *accion[2]={"avanzar","disparar"};
    float valor;
    srand(time(NULL));
    while(i>0)
    {
        grado=((float)rand()/(float)RAND_MAX);
        id=rand();
        id= id % 1000;
        if(id<100)
        {
            id=id+100;
        }
        valor=((float)rand()/(float)RAND_MAX)+100;
        valor=fmod(valor,4.2);
        if (valor <0.8)
        {
            valor=valor+0.8;
        }

        printf("%0.2f|%d|%s|%0.1f\n",grado,id,accion[rand()%2],valor);
        i--;
    }
    return 0;
}
