using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RestClient
{
    public class Recept
    {
        public int id { get; set; }
        public List<Surovina> suroviny { get; set; }
        public String nazov { get; set; }
        public String postup { get; set; }
        public String autor { get; set; }

        public Recept(List<Surovina> suroviny, String nazov, String postup, String autor)
        {
            this.id = 0;
            this.suroviny = suroviny;
            this.nazov = nazov;
            this.postup = postup;
            this.autor = autor;
        }

        public Recept(int id,List<Surovina> suroviny, String nazov, String postup, String autor)
        {
            this.id = id;
            this.suroviny = suroviny;
            this.nazov = nazov;
            this.postup = postup;
            this.autor = autor;
        }

        public Recept()
        {

        }

        public Recept(string json)
        {
            List<Surovina> sur = new List<Surovina>();
            var recepty = JsonConvert.DeserializeObject<Recept>(json);
            foreach (var surovina in recepty.suroviny)
            {
                
                sur.Add(surovina);
            }
            
            this.suroviny = sur;
            this.postup = recepty.postup;
            this.id = recepty.id;
            this.nazov = recepty.nazov;
            this.autor = recepty.autor;
            Console.WriteLine(this.print());
        }

        public String getAutor()
        {
            return this.autor;
        }

        public void setAutor(String autor)
        {
            this.autor = autor;
        }

        public void zmenSurovinu(Surovina stara, Surovina nova)
        {
            int index = -1;
            foreach (Surovina sur in suroviny)
            {
                if (sur.compare(stara))
                {
                    index = suroviny.IndexOf(sur);
                    break;
                     
                }
            }
            if (index != -1)
            {
                
                suroviny[index] = nova;
            }

        }

        public string print()
        {
            String output = "Nazov: " + nazov + "; Suroviny: ";
            foreach (Surovina surovina in suroviny)
            {
                output += surovina.print();
            }
            output += "; postup: " + postup;
            output += " ; autor: " + autor;
            return output;
        }

        public String getNazov()
        {
            return this.nazov;
        }

        public List<Surovina> getSuroviny()
        {
            return this.suroviny;
        }

        public void setNazov(String nazov)
        {
            this.nazov = nazov;
        }

        public void setPostop(String postop)
        {
            this.postup = postup;
        }

        public void setSuroviny(List<Surovina> suroviny)
        {
            this.suroviny = suroviny;
        }
        public String getPostup()
        {
            return this.postup;
        }

    }
}
