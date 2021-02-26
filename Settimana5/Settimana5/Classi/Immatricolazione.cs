using System;
using System.Collections.Generic;
using System.Text;

namespace Settimana5.Classi
{
    public class Immatricolazione
    {
        //Matriola autogenerata e readonly
        private static int MatricolaSeed = 100000;
        public string Matricola { get; }
        public DateTime DataInizio { get; }
        public CorsoDiLaurea CorsoLaurea { get; }
        public bool FuoriCorso { get; set; }
        public int CFUAccumulati { get; set; }

        //Non dichiaro il costruttore di default perchè il corso di laura non deve essere nullo
        //suppongo che siano tutti nuovi studente e che non abbiamo cfu
        public Immatricolazione(CorsoDiLaurea corso)
        {
            //Assegno la matricola e la aumento per renderla univoca
            Matricola = MatricolaSeed.ToString();
            MatricolaSeed++;
            DataInizio = DateTime.Now;
            CorsoLaurea = corso;
            FuoriCorso = false;
            CFUAccumulati = 0;
        }
    }
}
