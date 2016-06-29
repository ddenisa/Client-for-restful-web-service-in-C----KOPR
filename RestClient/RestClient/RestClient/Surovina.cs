using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient
{
    public class Surovina
    {
        
        public String nazov { get; set; }
        public double mnozstvo { get; set; }
        public String jednotka { get; set; }

        public Surovina(String nazov, double mnozstvo, String jednotka)
        {
            this.nazov = nazov;
            this.mnozstvo = mnozstvo;
            this.jednotka = jednotka;
        }

        public String print()
        {
            return "Nazov suroviny: " + nazov + "; Mnozstvo: " + mnozstvo + "; " + jednotka + " ";
        }

        public String getNazov()
        {
            return this.nazov;
        }
        public void setNazov(String nazov)
        {
            this.nazov = nazov;
        }
        public void setJednotka(String jednotka)
        {
            this.jednotka = jednotka;
        }
        public void setMnozstvo(double mnozstvo)
        {
            this.mnozstvo = mnozstvo;
        }

        public double getMnozstvo()
        {
            return this.mnozstvo;
        }

        public String getJednotka()
        {
            return this.jednotka;
        }

        public bool compare(Surovina toCompare)
        {
            if (this.nazov == toCompare.nazov)
            {
                if (this.mnozstvo == toCompare.mnozstvo)
                {
                    if (this.jednotka == toCompare.jednotka)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
