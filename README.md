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
int terminos_collatz(int num);

int main()
{
  // Declara la variable del límite superior, hasta el cual se calculará la cantidad de términos generados
  int limite_superior = 100000;

  // Declara las variables del número que produce la mayor cantidad de términos y la cantidad de términos que produce 
  int mayor_num;
  int terminos = 0;

  // Repite el proceso desde el 1 hasta el límite superior
  for (int i = 1; i <= limite_superior; i++)
  {
    // llama a la función que calcula la cantidad de términos y los almacena en una variable
    int terminos_aux = terminos_collatz(i);

    // si la cantidad de términos para el número calculado es mayor que la anterior, guarda el número y la cantidad de términos en sus respectivas variables
    if (terminos_aux > terminos)
    {
      terminos = terminos_aux;
      mayor_num = i;
    }
  }

  printf("El número inicial que produce la mayor cantidad de términos es %d con un total de %d términos.\n", mayor_num, terminos);
  return 0;
}

// función que recibe un número entero y devuelve la cantidad de términos que genera
int terminos_collatz(int num)
{
  int terminos = 0;

  // mientras el número no haya llegado a 1, aplicar las reglas definidas para la sucesión 
  while (num != 1)
  {
    // por cada operación que realiza agrega 1 a la cantidad de términos
    terminos++;

    // Si el número es par, divide entre 2, si es impar multiplica por 3 y suma 1
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
