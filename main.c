#include <stdio.h>

/* 1er Desafío de programación - Matemática Discreta I */
/* Santiago Blanco - Grupo M1 */

int main()
{
  int terminos = 0;
  int mayor_num = 0;

  for (int i = 1; i <= 100000; i++)
  {
    int terminos_aux = 0;
    int num = i;

    while (num != 1)
    {
      terminos_aux++;
      if (num % 2 == 0)
      {
	num /= 2;
      }
      else
      {
	num = num * 3 + 1;
      }
    }

    if (terminos_aux > terminos)
    {
      terminos = terminos_aux;
      mayor_num = i;
    }
  }

  printf("El número inicial que produce la mayor cantidad de términos es %d con un total de %d términos.\n", mayor_num, terminos);
  return 0;
}
