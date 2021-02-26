using System;
using System.Collections.Generic;
using System.Text;

namespace Settimana5.Classi
{
    public class Esami
    {
        public Corsi Corso { get; }
        public bool Passato { get; set; }

        //Deve avere il costruttore di default perchè i nuovi immatricolati hanno 0 esami
        public Esami()
        {
            Corso = new Corsi();
            Passato = false;
        }
        public Esami(Corsi corso)
        {
            Corso = corso;
            Passato = false;
        }
    }
}
