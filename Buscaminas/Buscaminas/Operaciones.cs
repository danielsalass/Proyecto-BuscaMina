using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    class Operaciones
    {


        int[,] tablero1 = new int[10, 10] {
            { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 1},
            { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1, 0, 1, 1},
            { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1},
            { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0}};
        int[,] tablero2 = new int[10, 10] {
            { 1, 0, 0, 0, 0, 0, 1, 0, 0, 0},
            { 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
            { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 1, 0, 0, 0},
            { 1, 0, 0, 0, 0, 0, 0, 0, 1, 1},
            { 1, 0, 1, 0, 0, 0, 0, 1, 0, 0},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            { 0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 1, 0, 1, 1}};
        int[,] tablero3 = new int[10, 10] {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0, 1, 1, 0, 1},
            { 1, 0, 1, 0, 0, 1, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 0, 0, 1, 0, 1},
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0},
            { 0, 0, 1, 1, 0, 1, 0, 0, 1, 0},
            { 1, 1, 0, 0, 0, 0, 1, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}};
        int[,] tablero4 = new int[10, 10] {
            { 1, 0, 0, 0, 1, 0, 0, 0, 1, 1},
            { 0, 0, 0, 1, 0, 0, 1, 0, 0, 1},
            { 1, 0, 0, 0, 0, 1, 0, 0, 1, 0},
            { 0, 0, 1, 0, 0, 1, 1, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 1, 0, 1, 0, 1},
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
            { 0, 0, 1, 1, 0, 0, 0, 0, 1, 0},
            { 1, 1, 0, 0, 0, 0, 1, 0, 0, 0},
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1}};


        int[,] matrizAuxiliar = new int[10, 10];

        public int buscaMinaAlrededor(int columna, int fila)
        {
            int contador = 0;
            int i = columna;
            int k = fila;
            if (tablero1[i, k] == 0)
            {
                //Revisa laterales
                if ((k + 1) < 9)
                {
                    if (tablero1[i, k + 1] == 1)
                    {
                        contador++;
                    }
                }
                if ((k - 1) >= 0)
                {
                    if (tablero1[i, k - 1] == 1)
                    {
                        contador++;
                    }
                }

                //Revisa superior e inferior
                if ((i + 1) < 9)
                {
                    if (tablero1[i + 1, k] == 1)
                    {
                        contador++;
                    }
                }
                if ((i - 1) >= 0)
                {
                    if (tablero1[i - 1, k] == 1)
                    {
                        contador++;
                    }
                }

                //Revisa diaginales arriba
                if ((i + 1) < 9)
                {
                    if ((k + 1) < 9)
                    {
                        if (tablero1[i + 1, k + 1] == 1)
                        {
                            contador++;
                        }
                    }
                }
                if ((i + 1) < 9)
                {
                    if ((k - 1) >= 0)
                    {
                        if (tablero1[i + 1, k - 1] == 1)
                        {
                            contador++;
                        }
                    }
                }

                //Revisa diagonales abajo
                if ((i - 1) >= 0)
                {
                    if ((k + 1) < 9)
                    {
                        if (tablero1[i - 1, k  + 1] == 1)
                        {
                            contador++;
                        }
                    }
                }
                if ((i - 1) >= 0)
                {
                    if ((k - 1) >= 0)
                    {
                        if (tablero1[i - 1, k - 1] == 1)
                        {
                            contador++;
                        }
                    }
                }

                //Console.WriteLine(contador);
                
            }

            return contador;
        }
 
        public int revisaMina(int columna, int fila)
        {
            if (tablero1[columna, fila] == 1)
            {
                return 9;
            }
            else
            {
                return buscaMinaAlrededor(columna, fila);
            }
        }

        



    }
}
