using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioJugar
{
    class Tablero
    {

       /* public string Tirar(string Coordenadas)
        {

        }*/
        int[] mapa = new int[100];
        int[,] campo = new int[10, 10];
        int[] vacio = new int[]
            {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100};
        int[] mapa_minas = new int[20];





        public void Iniciar()
        {
            Random r = new Random();


            for (int i = 1; i < campo.GetLength(0); i++)
            {
                for (int j = 1; j < campo.GetLength(1); j++)
                {
                    campo[i, j] = 0;
                }
            }

            for (int i = 1; i < mapa.Length; i++)
            {
                List<int> lista = null;

                lista = Posicion_guardada(i);
                campo[lista[1], lista[0]] = 0;
                mapa[i] = 0;

                

                
            }


            int indice = 0;

            while (indice < 20)
            {
                int contador_minas = 0;
                int mina = r.Next(1, 144);
                bool es_vacia = vacio.Contains(mina);
                if (es_vacia == false)
                {

                    bool es_mina = mapa_minas.Contains(mina);
                    if (es_mina == false)
                    {
                        List<int> lista = Posicion_guardada(mina);

                        int y = lista[0];
                        int x = lista[1];
                        campo[x, y] = 9;
                        mapa[mina] = 9;
                        mapa_minas[indice] = mina;

                        for (int j = 0; j < campo.GetLength(1); j++)
                        {
                            for (int i = 0; i < campo.GetLength(0); i++)
                            {
                                if (campo[i, j] == 9)
                                {
                                    contador_minas++;
                                }
                            }

                        }

                        if (x + 1 < 12)
                            if (campo[x + 1, y] < 9)
                                campo[x + 1, y] = campo[x + 1, y] + 1;

                        if (y + 1 < 12)
                            if (campo[x, y + 1] < 9)
                                campo[x, y + 1] = campo[x, y + 1] + 1;

                        if (x - 1 >= 0)
                            if (campo[x - 1, y] < 9)
                                campo[x - 1, y]++;

                        if (y - 1 >= 0)
                            if (campo[x, y - 1] < 9)
                                campo[x, y - 1]++;

                        if (x + 1 < 12 && y + 1 < 12)
                            if (campo[x + 1, y + 1] < 9)
                                campo[x + 1, y + 1]++;

                        if (x + 1 < 12 && y - 1 >= 0)
                            if (campo[x + 1, y - 1] < 9)
                                campo[x + 1, y - 1]++;

                        if (x - 1 >= 0 && y - 1 >= 0)
                            if (campo[x - 1, y - 1] < 9)
                                campo[x - 1, y - 1]++;

                        if (x - 1 >= 0 && y + 1 < 12)
                            if (campo[x - 1, y + 1] < 9)
                                campo[x - 1, y + 1]++;


                        indice = contador_minas;
                    }
                }
            }


        }

        private List<int> Posicion_guardada(int num)
        {
            int pos = 0;
            List<int> total = new List<int>();

            for (int i = 0; i < campo.GetLength(1); i++)
            {
                for (int j = 0; j < campo.GetLength(0); j++)
                {
                    if (pos == num - 1)
                    {
                        total.Add(i);
                        total.Add(j);
                    }
                    else
                    {
                        pos++;
                    }
                }
            }
            return total;
        }


    }

}