int limiteSuperior = 100000;
int mayorNum = 0;
int terminos = 0;

// crea un diccionario para almacenar los números como claves con sus respectivas cantidades de términos
Dictionary<int, int> anteriores = new Dictionary<int, int>();

// itera desde el número 1 hasta el límite superior definido más arriba
for (int i = 1; i <= limiteSuperior; i++)
{
    // llama a la función que calcula la cantidad de términos y los almacena en una variable
    int terminosAux = TerminosCollatz(i);

    // si la cantidad de términos para el número calculado es mayor que la anterior,
    // guarda el número y la cantidad de términos en sus respectivas variables
   
    if (terminosAux > terminos)
    {
        terminos = terminosAux;
        mayorNum = i;
    }
}

Console.WriteLine(
    $"El número inicial que produce la mayor cantidad de términos es {mayorNum} con un total de {terminos} términos.");

int TerminosCollatz(int num)
{
    // inicializa las variables
    int terminos = 0;
    int numAux = num; // guarda el número original para agregarlo posteriormente al diccionario
      
    // mientras el número no haya llegado a 1, aplicar las reglas definidas para la sucesión 
    while (num != 1)
    {
        // si el diccionario ya contiene la cantidad de términos para el número, agrega esa cantidad y sale del bucle
        if (anteriores.TryGetValue(num, out var collatz))
        {
            terminos += collatz;
            break;
        }
      
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

    // Agrega el número original al diccionario con la cantidad de términos que genera como valor
    anteriores.Add(numAux, terminos);
    return terminos;
}