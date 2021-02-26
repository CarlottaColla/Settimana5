using System;
using System.Collections.Generic;
using System.Text;

namespace Settimana5.Classi
{
    public class Corsi
    {
        public string Nome { get; }
        public int CFUCorso { get; }


        public Corsi()
        {
            Nome = null;
            CFUCorso = 0;
        }
        public Corsi(string nome, int cfu)
        {
            Nome = nome;
            CFUCorso = cfu;
        }


        //Medoto utilizzato per creare velocemente una lista di corsi
        public static List<Corsi> CreaCorsi(string nomeCorsoDiLaurea)
        {
            List<Corsi> corsi = new List<Corsi>();
            switch (nomeCorsoDiLaurea)
            {
                case "Matematica":
                    Corsi corso1 = new Corsi("Analisi 1", 9);
                    corsi.Add(corso1);
                    Corsi corso2 = new Corsi("Analisi 2", 12);
                    corsi.Add(corso2);
                    Corsi corso3 = new Corsi("Geometria", 6);
                    corsi.Add(corso3);
                    break;
                case "Informatica":
                    Corsi corso4 = new Corsi("Programmzione 1", 12);
                    corsi.Add(corso4);
                    Corsi corso5 = new Corsi("Algoritmi", 9);
                    corsi.Add(corso5);
                    Corsi corso6 = new Corsi("Analisi", 8);
                    corsi.Add(corso6);
                    break;
                case "Fisica":
                    Corsi corso7 = new Corsi("Analisi 2", 9);
                    corsi.Add(corso7);
                    Corsi corso8 = new Corsi("Fisica 1", 12);
                    corsi.Add(corso8);
                    Corsi corso9 = new Corsi("Programmzazione", 6);
                    corsi.Add(corso9);
                    break;
            }
            return corsi;
        }
    }
    
}
