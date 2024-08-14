# 1er Desafío de programación
## Matemática Discreta I

### Consigna
Una sucesión se define para el conjunto de enteros positivos de la siguiente manera:
- n → n/2 (n es par)
- n → 3n + 1 (n es impar)

Usando la regla anterior y comenzando con 13, generamos la siguiente secuencia:
- 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

Se puede ver que esta secuencia (que comienza en 13 y termina en 1) contiene 10 términos. Aunque aún no ha sido probado (Problema de Collatz), se piensa que todos los números iniciales terminan en 1. ¿Qué número inicial, por debajo de 100000, produce la cadena más larga?

NOTA: Una vez que la cadena comienza, los términos pueden superar 100000.

### Proceso y fundamento
En este documento explico el proceso que culminó en la solución actual y desarrollo sobre el funcionamiento del programa.

#### Solución inicial
Inicialmente decidí hacerlo lo más sencillo y elegí el lenguaje de programación C por su simplicidad y eficiencia y también porque el código se puede ejecutar de manera rápida haciendo uso de cualquier compilador, sin la necesidad de crear un proyecto ni depender de un entorno de desarrollo. Es así que implementé una función que calcula los términos de la secuencia para todos los números desde el 1 hasta el límite superior, que en este caso es 100.000:

```c
// Solución inicial en C
#include <stdio.h>

int terminos_collatz(int num);

int main()
{
  int limite_superior = 100000;

  int mayor_num;
  int terminos = 0;

  for (int i = 1; i <= limite_superior; i++)
  {
    int terminos_aux = terminos_collatz(i);

    if (terminos_aux > terminos)
    {
      terminos = terminos_aux;
      mayor_num = i;
    }
  }

  printf("El número inicial que produce la mayor cantidad de términos es %d con un total de %d términos.\n", mayor_num, terminos);
  return 0;
}

int terminos_collatz(int num)
{
  int terminos = 0;

  while (num != 1)
  {
    terminos++;

    if (num % 2 == 0)
    {
      num /= 2;
    }
    else
    {
      num = num * 3 + 1;
    }
  }
  return terminos;
}
```

Lo primero que se ve es que se declaran dos variables de tipo entero donde se va a almacenar el mayor número de términos y el número que los genera.

Luego recorre cada número desde 1 hasta 100.000. Para cada número, se llama a una función que devuelve la cantidad de términos en la sucesión de Collatz para ese número.

Si la cantidad de términos para el número por el que se está iterando es mayor que la cantidad máxima registrada, se actualizan las variables declaradas incialmente.

El problema con esta solución es que es muy rudimentaria y hace uso de la "fuerza bruta" para llegar a la solución. Iterar sobre todos los números y calcular los términos para cada uno funciona, pero no es eficiente en lo absoluto.

#### Solución final 
Con este problema en mente decidí investigar para buscar soluciones más eficientes. Me encontré entonces con la posibilidad de usar diccionarios para ir guardando los resultados previos, siendo los números almacenados como claves y su respectiva cantidad de términos como valores, eliminando la necesidad de calcular toda la secuencia de Collatz nuevamente para cada número iterado.

Como los diccionarios no existen en C y no tengo los conocimientos suficientes para implementar algo que funcione de manera similar, decidí usar C#.

En el archivo Program.cs de este repositorio está el código principal con los comentarios que explican la solución, pero esencialmente se trata de lo siguiente:

Primero se declaran las variables correspondientes, igual que en el anterior.
Luego crea un diccionario para almacenar los números ya calculados con la cantidad de términos que generaron. Esto evita la necesidad de volver a calcular los términos para números ya procesados.

De la misma manera que el anterior itera sobre los números desde el 1 hasta el 100.000, llamando a una función que calcula los términos para cada número.

Esa función verifica antes de calcular la secuencia si el número ya está en el diccionario. Si está, devuelve directamente el número de términos almacendo. De otro modo inicializa una variable para contar los términos y otra que guarda el número original para que al final de la función se agregue al diccionario junto con la cantidad de términos que genera.

Lo siguiente es un bucle que se ejecuta mientras el número sea diferente de 1. Dentro de ese bucle, primero se verifica si el diccionario ya contiene la cantidad de términos para el número, agrega esa cantidad a los términos y sale del bucle. En caso contrario realiza las operaciones correspondientes agregando uno al contador de términos como en la solución inicial.




