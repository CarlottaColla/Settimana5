using System;
using System.Collections.Generic;
using System.Text;

namespace Settimana5.Classi
{
    public class CorsoDiLaurea
    {
        public enum Nome
        {
            Matematica,
            Fisica,
            Informatica,
            Ingegneria,
            Lettere
        }
        public Nome NomeCorso { get; }
        public int AnniDiCorso { get; }
        public int CFUPerLaurea { get; }
        public List<Corsi> CorsiAssociati { get; }

        //Creo un costruttore con parametri
        public CorsoDiLaurea(Nome nomecorso, int anni, int cfu)
        {
            NomeCorso = nomecorso;
            AnniDiCorso = anni;
            CFUPerLaurea = cfu;
            CorsiAssociati = new List<Corsi>();
            //medoto utilizzato per creare velocemente una lista di corsi
            CorsiAssociati = Corsi.CreaCorsi(NomeCorso.ToString());
        }


    }
}
