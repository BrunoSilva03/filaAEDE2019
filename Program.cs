using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilaAEDE
{
    public class elemento
    {
        public int numero;
        public elemento proximo;
    }


    public class fila
    {
        public elemento inicio = null;
        public elemento fim = null;
        public int tamanho = 0;


        public bool pesquisarIterativo(int num)
        {
            elemento auxiliar = fim;

            while (auxiliar != null)
            {
                if (auxiliar.numero == num)
                {
                    return true;
                }
                else
                {
                    auxiliar = auxiliar.proximo;
                }
            }

            return false;
        }



        public bool pesquisarRecursivo(int num, elemento auxiliar)
        {
            if (auxiliar == null)
            {
                return false;
            }
            else
            {
                if (auxiliar.numero == num)
                {
                    return true;
                }
                else
                {
                    return pesquisarRecursivo(num, auxiliar.proximo);
                }
            }
        }

        public void enfileirar(int num)
        {
            if (pesquisarIterativo(num) == true)
            {
                Console.WriteLine("Esse número já está na fila");
            }
            else
            {

                if (inicio == null)
                {

                    elemento novoElemento = new elemento();
                    novoElemento.numero = num;
                    inicio = novoElemento;
                    fim = novoElemento;
                    tamanho++;

                }
                else
                {
                    elemento novoElemento = new elemento();
                    novoElemento.numero = num;
                    novoElemento.proximo = fim;
                    fim = novoElemento;
                    tamanho++;
                }

            }
        }



        public elemento desenfileirar()
        {
            elemento auxiliar = inicio;
            elemento percorre = fim;
            elemento novoInicio;
            if (inicio != null)
            {
                if (percorre == inicio)
                {
                    novoInicio = null;
                    inicio = null;
                    fim = null;
                    tamanho--;
                }
                else
                {

                    while (percorre != inicio)
                    {
                        if (percorre.proximo == inicio)
                        {
                            novoInicio = percorre;
                            inicio = novoInicio;
                        }
                        else
                        {

                            percorre = percorre.proximo;
                        }

                    }

                    tamanho--;
                }
            }



            return auxiliar;
        }








        public void exibirIterativo()
        {
            elemento auxiliar = fim;

            if (inicio == null)
            {
                Console.WriteLine(" ");
            }
            else
            {
                while (auxiliar != inicio)
                {
                    Console.WriteLine("{0} ", auxiliar.numero);
                    auxiliar = auxiliar.proximo;
                }

                Console.WriteLine("{0} ", auxiliar.numero);       //Início

                Console.WriteLine("Inicio: " + inicio.numero);
                Console.WriteLine("Fim: " + fim.numero);

            }
        }


        public void exibirRecursivo(elemento auxiliar)
        {
            if (auxiliar == null)
            {
                Console.WriteLine("Fila vazia");
            }
            else
            {


                if ((auxiliar != null) && (auxiliar != inicio))
                {
                    Console.WriteLine("{0} ", auxiliar.numero);
                    exibirRecursivo(auxiliar.proximo);
                }

                if ((auxiliar != null) && (auxiliar == inicio))
                {
                    Console.WriteLine("{0} ", auxiliar.numero);
                }

            }
        }



        public void esvaziar()
        {
            elemento auxiliar = fim;
            elemento esvaziandoFila;

            while (auxiliar != inicio)
            {
                esvaziandoFila = auxiliar;
                esvaziandoFila = null;
                auxiliar = auxiliar.proximo;

            }

            fim = null;
            inicio = null;
            tamanho = 0;
        }



        public bool verificaFilaVazia()
        {
            if ((inicio == null) && (fim == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int contagemMaioresInicioIterativo()
        {

            elemento percorre = fim;
            int maiores = 0;

            while (percorre != inicio)
            {
                if (percorre.numero > inicio.numero)
                {
                    maiores++;
                    percorre = percorre.proximo;
                }
                else
                {
                    percorre = percorre.proximo;
                }
            }

            return maiores;
        }


        
        public int contagemMaioresInicioRecursivo(elemento inicial, elemento percorre, int maiores)
        {
            if (percorre != inicio)
            {
                if (percorre.numero > inicial.numero)
                {
                    maiores = maiores + 1;
                    return contagemMaioresInicioRecursivo(inicial, percorre.proximo, maiores);
                }
                else
                {
                    return contagemMaioresInicioRecursivo(inicial, percorre.proximo, maiores);
                }

            }




            return maiores;

        }



        public int contagemMaioresFinalIterativo()
        {
            if (verificaFilaVazia() == true)
            {
                return 0;
            }


            elemento auxiliar = fim.proximo;
            elemento Final = fim;
            int maioresFinal = 0;




            if (inicio == fim)
            {
                return 0;
            }
            else
            {
                while (auxiliar != inicio)
                {
                    if (auxiliar.numero > Final.numero)
                    {
                        maioresFinal++;
                        auxiliar = auxiliar.proximo;
                    }
                    else
                    {
                        auxiliar = auxiliar.proximo;
                    }
                }


                if (inicio.numero > Final.numero)
                {
                    maioresFinal++;
                }

            }


            return maioresFinal;
        }


        public int contagemMaioresFinalRecursivo(elemento Final, elemento percorre, int maioresFinalDois)
        {                                             //fim              //fim.proximo
            


            if (inicio == fim)
            {
                return 0;
            }
            else
            {
                if (percorre != inicio)
                {
                    if (percorre.numero > Final.numero)
                    {
                        maioresFinalDois++;
                        return contagemMaioresFinalRecursivo(Final, percorre.proximo, maioresFinalDois);
                    }
                    else
                    {
                        return contagemMaioresFinalRecursivo(Final, percorre.proximo,maioresFinalDois);
                    }
                }

                if (percorre == inicio)
                {
                    if (percorre.numero > Final.numero)
                    {
                        maioresFinalDois++;
                    }
                }
            }

            return maioresFinalDois;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            int opc = 1;
            fila fillas = new fila();

            while (opc != 0)
            {
                Console.Clear();
                Console.WriteLine("******************MENU**************");
                Console.WriteLine("1. pesquisar");
                Console.WriteLine("2. enfileirar");
                Console.WriteLine("3. desenfileirar");
                Console.WriteLine("4. exibir");
                Console.WriteLine("5. esvaziar fila");
                Console.WriteLine("6. verificar se a fila está vazia");
                Console.WriteLine("7. contagem de elementos maiores que o início");
                Console.WriteLine("8. contagem de elementos maiores que o fim");
                opc = int.Parse(Console.ReadLine());


                switch (opc)
                {
                    case 1:
                        {
                            Console.Clear();
                            int num;

                            Console.WriteLine("Digite o número que você deseja pesquisar na fila de forma ITERATIVA: ");
                            num = int.Parse(Console.ReadLine());

                            if (fillas.pesquisarIterativo(num) == true)
                            {
                                Console.WriteLine("O número {0} está presente na fila", num);
                            }
                            else
                            {
                                Console.WriteLine("O número {0} não está presente na fila", num);
                            }


                            Console.ReadKey();


                            Console.Clear();
                            Console.WriteLine("Digite o número que você deseja pesquisar na fila de forma RECURSIVA: ");
                            num = int.Parse(Console.ReadLine());

                            if (fillas.pesquisarRecursivo(num, fillas.fim) == true)
                            {
                                Console.WriteLine("O número {0} está presente na fila", num);
                            }
                            else
                            {
                                Console.WriteLine("O número {0} não está presente na fila", num);
                            }


                            Console.ReadKey();
                        }
                        break;


                    case 2:
                        {
                            Console.Clear();
                            int num;

                            Console.WriteLine("Digite o número que deseja adicionar á fila: ");
                            num = int.Parse(Console.ReadLine());

                            fillas.enfileirar(num);
                            Console.ReadKey();
                        }
                        break;




                    case 3:
                        {


                            Console.Clear();
                            fillas.desenfileirar();


                            Console.WriteLine("Desenfileirado com sucesso");



                            Console.ReadKey();

                        }
                        break;




                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Exibir Iterativo: \n\n");
                            fillas.exibirIterativo();
                            Console.WriteLine("\n\n Atualmente a fila tem {0} componentes", fillas.tamanho);
                            Console.ReadKey();


                            Console.Clear();
                            Console.WriteLine("Exibir Recursivo: \n\n");
                            fillas.exibirRecursivo(fillas.fim);
                            Console.WriteLine("Atualmente a fila tem {0} componentes", fillas.tamanho);
                            Console.ReadKey();
                        }
                        break;




                    case 5:
                        {
                            Console.Clear();
                            fillas.esvaziar();


                            Console.WriteLine("Fila esvaziada com sucesso");
                            Console.ReadKey();
                        }
                        break;




                    case 6:
                        {
                            Console.Clear();
                            if ((fillas.verificaFilaVazia()) == true)
                            {
                                Console.WriteLine("A fila atualmente está vazia");
                            }
                            else
                            {
                                Console.WriteLine("Atualmente a fila NÃO está vazia!");
                            }


                            Console.ReadKey();

                        }
                        break;




                    case 7:
                        {
                            int maiores = 0;
                            Console.Clear();
                            Console.WriteLine("Número de elementos maiores que o início: ");
                            Console.WriteLine("Iterativo: \n\n");
                            Console.WriteLine("{0} ", fillas.contagemMaioresInicioIterativo());
                            Console.ReadKey();



                            Console.Clear();
                            Console.WriteLine("Número de elementos maiores que o início: ");
                            Console.WriteLine("Recursivo: \n\n");
                            Console.WriteLine("{0} ", fillas.contagemMaioresInicioRecursivo(fillas.inicio, fillas.fim, maiores));
                            Console.ReadKey();
                        }
                        break;


                    case 8:
                        {
                            int maioresFinalDois = 0;
                            Console.Clear();
                            Console.WriteLine("Número de elementos maiores que o final: ");
                            Console.WriteLine("Iterativo: ");
                            Console.WriteLine("{0} ", fillas.contagemMaioresFinalIterativo());
                            Console.ReadKey();


                            Console.Clear();
                            Console.WriteLine("Número de elementos maiores que o final: ");
                            Console.WriteLine("Recursivo: ");
                            if (fillas.verificaFilaVazia() == true)
                            {
                                Console.WriteLine("{0} ", 0);
                            }
                            else
                            {

                                Console.WriteLine("{0} ", fillas.contagemMaioresFinalRecursivo(fillas.fim, fillas.fim.proximo, maioresFinalDois));
                            }
                            Console.ReadKey();

                        }
                        break;


                }
            }
        }
    }
}
