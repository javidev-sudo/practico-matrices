using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico_Matrices
{
    class Matriz
    {

        const int MAXF = 50;
        const int MAXC = 50;
        private int[,] x;
        private int f, c;

        public Matriz()
        {
            x = new int[MAXF,MAXC];
            f = 0; c = 0;
        }

        public void Cargar(int nf, int nc, int a, int b)
        {
            f = nf;
            c = nc;
            Random r = new Random();

            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a,b+1);
                }
            }
        }

        public string Descargar()
        {
            string s = "";

            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    s = s + x[f1,c1] + "\x0009";


                }

                s = s + "\x000d" + "\x000a";

            }

            return s;
        }

        public bool Esprimo(double num)
        {
            int i = 1;
            int cont = 0;
            while (i <= num)
            {
                if (num % i == 0)
                {
                    cont++;
                }

                i++;
            }

            return (cont == 2);
        }


        public double AcumEle()
        {
            
            double s = 0;
            bool b = true;

            for (int f1 = f; f1 >= 1 ; f1--)
            {
                for (int c1 = c; c1 >= 1; c1--)
                {
                    if (Esprimo(x[f1,c1]))
                    {
                        if (b)
                        {
                            s = s - Math.Sqrt(x[f1,c1]);
                        }
                        else
                        {
                            s = s + Math.Sqrt(x[f1,c1]);
                        }

                        b = !b;
                    }
                }
            }

            return Math.Round(s,3);
        }


        public int Frecuele(int ele)
        {
            int fre = 0;
            for (int c1 = 1; c1 <= c; c1++)
            {
                for (int f1 = f; f1 >= 1 ; f1--)
                {
                    if (x[f1,c1] == ele)
                    {
                        fre++;
                    }
                }
            }

            return fre;
        }

        public int EleNoRep()
        {
            int Norep = 0;
            int ele;
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    ele = x[f1, c1];
                    if (Frecuele(ele)==1)
                    {
                        Norep++;
                    }
                }
            }

            return Norep;
        }

        public void Cargarfibo(int nf, int nc)
        {
            f = nf;
            c = nc;
            int a, b, re;
            a = -1; b = 1;
            bool ban = true;
            for (int f1 = 1; f1 <= f; f1++)
            {
                int c3 = ban ? 1 : c;

                while(ban == true && c3 <= c || !ban == true && c3 >= 1)
                {
                    re = a + b; a = b; b = re;
                    x[f1, c3] = re;
                    if (ban)
                    {
                        c3++;
                    }else
                    {
                        c3--;
                    }
                }
                ban = !ban;

                /* if (ban)
                 {
                     for (int c1 = 1; c1 <= c ; c1++)
                     {
                         re = a + b; a = b; b = re;
                         x[f1, c1] = re;
                     }
                 }
                 else
                 {

                     for (int c1 = c; c1 >= 1; c1--)
                     {
                         re = a + b; a = b; b = re;
                         x[f1, c1] = re;
                     }
                 }*/

            }
           
        }


        private bool verifFilaAS(int nf) //  funcion de ayuda
        {
            int c1 = 1;
            bool b = true;
            while(c1 < c && b)
            {
                if (x[nf,c1] > x[nf,c1+1])
                {
                    b = false;
                }
                c1++;
            }
            return b;
        }

        public bool VerifTofiOr()
        {
            bool b = true;
            int f1 = 1;
            while (f1 <= f && b)
            {
                b = verifFilaAS(f1);
                f1++;
            }
            return b;
        }


 
        public int EleMayorfre(int nf)
        {

            int fre;
            int mayorfre = 0;
            int eleMayor = x[nf,1];
            for (int c1 = 1; c1 <= c - 1; c1++)
            {
                int ele = x[nf, c1];
                fre = 1;

                for (int cd = c1 + 1; cd <= c; cd++)
                {
                    if (ele == x[nf, cd])
                    {
                        fre++;
                    }
                }
                if (fre > mayorfre)
                {
                    mayorfre = fre;
                    eleMayor = ele;
                }
            }

            return eleMayor;
        }

        public void ElemenMayorFre()
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                x[f1, c + 1] = EleMayorfre(f1);
            }

            c++;
        }

        public bool OrdenRig1()
        {
            int f1, c1;
            bool b = true;
            f1 = f;
            int ele = x[f, 1] - 1;

            while (f1>=1 && b)
            {
                c1 = 1;
                while (c1<=c && b)
                {
                    if (x[f1,c1] != ele + 1)
                    {
                        b = false;
                    }
                        ele++;
                        c1++;             
                }

                f1--;
            }
            return b;
        }

        private bool ExisteEle(int num)
        {
            int f1, c1;
            bool b = false;
            f1 = 1;
            
            while (f1 <= f && b == false)
            {
                c1 = 1;
                while (c1 <= c && b == false)
                {
                    if (num == x[f1,c1])
                    {
                        b = true;
                    }

                    c1++;
                }
                f1++;
            }
            return b;
        }

        public bool VerifMaEleOtra(Matriz x2)
        {
            int f1, c1;
            f1 = 1;
            
            bool b = true;
            while (f1 <= f && b)
            {
                c1 = 1;
                while (c1 <= c && b)
                {
                    if (!x2.ExisteEle(x[f1,c1]))
                    {
                        b = false;
                    }
                    c1++;
                }

                f1++;
            }

            return b;
        }

        public void Inter(int f1, int c1, int f2, int c2)
        {
            int ele = x[f1,c1];
            x[f1, c1] = x[f2, c2];
            x[f2, c2] = ele;
        }

        public bool Espar(int num)
        {
            return num % 2 == 0;
        }


        public void SegmeFila(int nf)
        {
            int n1, n2;

            for (int fp = 1; fp <= c - 1 ; fp++)
            {
                for (int cd = fp + 1; cd <= c; cd++)
                {
                    n1 = x[nf,cd]; n2 = x[nf, fp];

                    if (Espar(n1) && !Espar(n2) ||
                        Espar(n1) &&  Espar(n2) && x[nf,cd] < x[nf,fp] ||
                       !Espar(n1) && !Espar(n2) && x[nf, cd] < x[nf, fp])
                    {
                        Inter(nf,cd,nf,fp);
                    }
                }
            }


        }

        public void SegmenfILMatr()
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                SegmeFila(f1);
            }
        }


        public void interFilas(int f1, int f2)
        {
            for (int c1 = 1; c1 <= c; c1++)
            {
                Inter(f1,c1,f2,c1);
            }
        }

        public int NumPrimFi(int nf)
        {
            int cont = 0;
            for (int c1 = 1; c1 <= c; c1++)
            {
                if (Esprimo(x[nf,c1]))
                {
                    cont++;
                }
            }

            return cont;
        }


        public void AddPrim()
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                x[f1,c+1] = NumPrimFi(f1);
            }
            c++;
        }
    


        public void OrdCoprim() 
        {
            for (int t = f;  t >= 2; t--)
            {
                for (int d = 1; d <= t - 1; d++)
                {
                    if (x[d,c] > x[d+1,c])
                    {
                        interFilas(d , d+1);
                    }
                }
            }
        }



        /// <summary>
        /// practico parte 2
        /// </summary>

        public int FrecueRango(int ele ,int fi, int ff, int ci, int cf)
        {
            int freecu = 0;
            for (int c1 = cf; c1 >= ci; c1--)
            {
                for (int f1 = fi; f1 <= ff; f1++)
                {
                    if (ele == x[f1,c1])
                    {
                        freecu++;
                    }
                }
            }

            return freecu;
        }

        public void OrdenarElePorFre(int fi, int ff, int ci, int cf)
        {

            int i;
            for (int c1 = cf; c1 >= ci ; c1--)
            {
                for (int f1 = fi; f1 <= ff; f1++)
                {
                    for (int c2 = c1; c2 >= ci; c2--)
                    {
                        if (c2 == c1)
                        {
                            i = f1;
                        }
                        else
                        {
                            i = fi;
                        }
                        for (int f2 = i; f2 <= ff; f2++)
                        {
                            if ((FrecueRango(x[f2, c2],fi, ff, ci, cf) > FrecueRango(x[f1, c1],fi, ff, ci, cf)) ||
                                (FrecueRango(x[f2, c2],fi, ff, ci, cf) == FrecueRango(x[f1, c1], fi, ff, ci, cf)) && (x[f2, c2] < x[f1, c1]))
                            {
                                Inter(f2,c2,f1,c1);
                            }
                        }
                    }
                }
            }
        }


        private void invertircol(int nc)
        {
            int conti, contf;
            conti = 0;
            contf = f + 1;

            for (int i = 1; i <= f/2; i++)
            {
                conti++;
                contf--;
                Inter(conti,nc,contf,nc);
            }
        }


        public void ordZeno()
        {
            int i;
            for (int c1 = 1; c1 <= c; c1++)
            {
                for (int f1 = f; f1 >= 1; f1--)
                {
                    for (int c2 = c1; c2 <= c; c2++)
                    {
                        if (c2==c1)
                        {
                            i = f1;
                        }
                        else
                        {
                            i = f;
                        }

                        for (int f2 = i; f2 >= 1; f2--)
                        {
                            if (x[f2,c2] < x[f1,c1])
                            {
                                Inter(f2,c2,f1,c1);
                            }
                        }
                    }
                }
            }

            for (int i2 = 1; i2 <= c / 2; i2++)
            {
                invertircol(i2 * 2);
            }
        }



        public bool Esfibo(int ele)
        {
            int a, b, c;
            a = -1; b = 1;
            do
            {
                c = a + b; a = b; b = c;

            } while (!((c == ele )||(c > ele)));

            return c == ele;
        }


        public void IntercalarFibo()
        {
            bool b = true;
            int ic;
            for (int f1 = f; f1 >= 1; f1--)
            {
                for (int c1 = 1; c1 <= c; c1++)
                {
                    if (b)
                    {
                        for (int f2 = f1; f2 >= 1; f2--)
                        {
                            if (f2 == f1)
                            {
                                ic = c1;
                            }
                            else
                            {
                                ic = 1;
                            }

                            for (int c2 = ic; c2 <= c; c2++)
                            {
                                if (Esfibo(x[f2,c2]) && !Esfibo(x[f1,c1]) ||
                                    Esfibo(x[f2, c2]) && Esfibo(x[f1, c1]) && x[f2,c2] < x[f1,c1] ||
                                    !Esfibo(x[f2, c2]) && !Esfibo(x[f1, c1]) && x[f2, c2] < x[f1, c1])
                                {
                                    Inter(f2,c2,f1,c1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int f2 = f1; f2 >= 1; f2--)
                        {
                            if (f2 == f1)
                            {
                                ic = c1;
                            }
                            else
                            {
                                ic = 1;
                            }
                            for (int c2 = ic; c2 <= c; c2++)
                            {
                                if (!Esfibo(x[f2, c2]) && Esfibo(x[f1, c1]) ||
                                    !Esfibo(x[f2, c2]) && !Esfibo(x[f1, c1]) && x[f2, c2] < x[f1, c1] ||
                                    Esfibo(x[f2, c2]) && Esfibo(x[f1, c1]) && x[f2, c2] < x[f1, c1])
                                {
                                    Inter(f2, c2, f1, c1);
                                }
                            }
                        }
                    }

                    b = !b;
                }
            }
        }

        public void OrdTrian1()
        {
            
            for (int f1 = 1; f1 <= f-1; f1++)
            {

                for (int c1 = f1+1 ; c1 <= c; c1++)
                {
                    for (int f2 = 1; f2 <= f-1; f2++)
                    {

                        for (int c2 = f2+1; c2 <= c; c2++)
                        {
                            if (x[f2,c2] > x[f1,c1])
                            {
                                Inter(f2,c2,f1,c1);
                            }
                        }
                    }
                    
                }
            }

            
        }

        public void OrdTri()
        {
            for (int c1 = 1+1; c1 <= c; c1++)
            {
                for (int f1 = f; f1 >= f - c1 + 1 + 1; f1--)
                {
                    for (int c2 = 1+1; c2 <= c; c2++)
                    {
                        for (int f2 = f; f2 >= f - c2 + 1 + 1; f2--)
                        {
                            if (!Espar(x[f2,c2]) && Espar(x[f1,c1]) ||
                                !Espar(x[f2, c2]) && !Espar(x[f1, c1]) && x[f2,c2] > x[f1,c1] ||
                                Espar(x[f2, c2]) && Espar(x[f1, c1]) && x[f2, c2] > x[f1, c1])
                            {
                                Inter(f2,c2,f1,c1);
                            }
                        }
                    }
                }
            }
        }

        public void ordeDIa()
        {
            for (int f1 = 1; f1 <= f; f1++)
            {
                for (int f2 = 1; f2 <= f; f2++)
                {
                    if (x[f2,f-f2+1] > x[f1,f-f1+1])
                    {
                        Inter(f2, f - f2 + 1, f1, f - f1 + 1);
                    }
                }
            }
        }

      // ver si funciona
        public int NumeroMayorF(int nf, int nc)
        {
            int ele = x[nf, nc];

            for (int inc = nc; inc <= c-1; inc++)
            {
                if (x[nf, nc + 1] > ele )
                {
                    ele = x[nf, nc + 1];
                }
            }

            return ele;
        }

        public int MayorFil(int f1)
        {
            int mayor = 0;
            for (int c1 = c - f1 + 1; c1 <= c; c1++)
            {
                if (x[f1,c1] > mayor)
                {
                    mayor = x[f1, c1];
                }
            }

            return mayor;
        }

        public void InserEleMa()
        {
            for (int f1 = 1;  f1 <= f; f1++)
            {
                x[f1, c + 1] = MayorFil(f1);
            }

            c++;
        }






    }
}
