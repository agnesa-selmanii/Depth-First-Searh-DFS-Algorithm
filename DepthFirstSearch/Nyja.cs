using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepthFirstSearch
{
    internal class Nyja
    {
        public int Vlera { get; set; }
        public Nyja DegaMajte { get; set; } //e tipit Nyja sepse referon te nje nyje tjeter
        public Nyja DegaDjathte { get; set; }
    }

    internal class PemaBinare
    {
        public Nyja Rrenja { get; set; }

        public bool ShtoNyje(int vlere)
        {
            Nyja pas = Rrenja;
            Nyja para = null;

            while (pas != null) //kur te mberrijme ne fund te pemes
            {
                para = pas;
                if (vlere < pas.Vlera)
                {
                    pas = pas.DegaMajte;
                }
                else if (vlere > pas.Vlera)
                {
                    pas = pas.DegaDjathte;
                }
                else
                {
                    return false;
                }
            }

            Nyja NyjaRe = new Nyja();
            NyjaRe.Vlera = vlere;

            if (Rrenja == null)
            {
                Rrenja = NyjaRe;
            }
            else
            {

                if (vlere < para.Vlera)
                {
                   para.DegaMajte=NyjaRe;
                }
                else
                {
                   para.DegaDjathte=NyjaRe;
                }
            }
            return true;
        }

        //depth first search
        public void DFS(Nyja rrenja, int shuma)
        {
            if (rrenja != null)
            {
                shuma += rrenja.Vlera;
                DFS(rrenja.DegaMajte, shuma);
                DFS(rrenja.DegaDjathte, shuma);

                if ((rrenja.DegaMajte==null) && (rrenja.DegaDjathte==null))
                {
                    Console.WriteLine(shuma);
                }
            }
        }
    }
}
