using System;
using System.Collections.Generic;
using System.Text;

namespace Settimana5.Classi
{
    public class Studente
    {
        public string Nome { get; }
        public string Cognome { get; }
        public int AnnoDiNascita { get; }
        public Immatricolazione immatricolazione { get; set; }
        public List<Esami> esami { get; set; } //contiene tutti gli esami
        public bool RichiestaDiLaurea { get; set; }

        //Non dichiaro il costruttore di default perchè nome e cognome non possono essere nulli
        public Studente(string nome, string cognome, int data, CorsoDiLaurea corso)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoDiNascita = data;
            immatricolazione = new Immatricolazione(corso);
            esami = new List<Esami>(); //all'immatricolazione non ho esami, uso il costruttore di default
            RichiestaDiLaurea = false; //appena immatricolato ha 0 cfu, non si può laureare
        }

        //Metodi:

        //Richiedere un esami
        public static void RichiediEsame(Studente studente, Esami esame)
        {
            /*Uno studente può richiedere un esame solo se esso è presente nel Corso di Laurea associato allo studente, 
             * se i CFU del corso associato all’esame non superino i CFU massimi del Corso di laurea 
             * e se non ha il flag RichiestaLaurea assegnato a vero.
              Nel caso le condizioni siano verificate, lo studente aggiunge l’esame alla lista Esami.*/
            if (Contiene(esame,studente.immatricolazione.CorsoLaurea.CorsiAssociati) && 
                (esame.Corso.CFUCorso + studente.immatricolazione.CFUAccumulati <= studente.immatricolazione.CorsoLaurea.CFUPerLaurea)
                && studente.RichiestaDiLaurea != true)
            {
                //Allora può richiedere l'esame
                Console.WriteLine($"Richiesta esame accettata: {studente.Nome}, {esame.Corso.Nome}");
                studente.esami.Add(esame);
            }
            else
            {
                Console.WriteLine($"Lo studente non può iscriversi all'esame: {studente.Nome}, {esame.Corso.Nome}");
            }
        }

        //Esame passato
        public void EsamePassato(Esami esame)
        {
            /*EsamePassato che, dato un esame, vada ad aggiornare i CFU accumulati dallo studente, 
             * metta il flag Passato sull’esame 
             * e verifichi se con tale esame sono stati raggiunti i CFU necessari 
             * per richiedere la laurea(e quindi metta il flag Richiestalaurea a true); */
            //Controllo se si è iscirtto all'esame
            foreach(var item in esami)
            {
                //Controllo se si è iscirtto all'esame
                if (item.Corso.CFUCorso == esame.Corso.CFUCorso && item.Corso.Nome == esame.Corso.Nome)
                {
                    //controllo se non l'ha ancora passato
                    if (item.Passato == false)
                    {
                        Console.WriteLine($"Lo studente ha passato l'esame: {Nome}, {esame.Corso.Nome}");
                        immatricolazione.CFUAccumulati += esame.Corso.CFUCorso;
                        int index = esami.IndexOf(esame);
                        esami[index].Passato = true;
                        if (immatricolazione.CFUAccumulati == immatricolazione.CorsoLaurea.CFUPerLaurea)
                        {
                            Console.WriteLine("Ha raggiunto i cfu necessari per la laurea");
                            RichiestaDiLaurea = true;
                        }
                        return;
                    }
                    //Se l'ha gia passato ritorna
                    Console.WriteLine($"Lo studente ha già passato l'esame: {Nome}, {esame.Corso.Nome}");
                    return;
                }
            }
            Console.WriteLine($"Lo studente non può passare l'esame perchè non è iscritto: {Nome}, {esame.Corso.Nome}");
        }


        //Ho dovuto ridefinire un metodo per vedere se nella lista dei corsi di laurea è presente un esame
        //Contains non funzionava perchè hanno indirizzi diversi
        //Suppongo che la coppia nomeEsame,Cfu sia univoca per ogni corso di laurea
        private static bool Contiene(Esami esame, List<Corsi> corsi)
        {
            foreach(var item in corsi)
            {
                if(item.CFUCorso == esame.Corso.CFUCorso && item.Nome == esame.Corso.Nome)
                {
                    //Console.WriteLine("Contine l'esame");
                    return true;
                }
            }
            //Console.WriteLine("non contiene l'esame");
            return false;
        }
    }
}
