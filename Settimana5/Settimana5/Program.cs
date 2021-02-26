using Settimana5.Classi;
using System;

namespace Settimana5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo i corsi di laurea
            CorsoDiLaurea informatica = new CorsoDiLaurea(CorsoDiLaurea.Nome.Informatica, 3, 20);
            CorsoDiLaurea Matematica = new CorsoDiLaurea(CorsoDiLaurea.Nome.Matematica, 3, 25);
            //Creo gli studenti
            Studente studente1 = new Studente("Carlotta", "Colla", 1997, informatica);
            Studente studente2 = new Studente("Anna", "Rossi", 1995, Matematica);
            //Creo i corsi per associarli agli esami
            Corsi corso1 = new Corsi("Programmzione 1", 12); //Corso appartenente a informatica
            Corsi corso2 = new Corsi("Analisi 1", 9); //Corso di matematica
            Corsi corso3 = new Corsi("Algoritmi", 9); //Corso di Informatica
            Corsi corso4 = new Corsi("Analisi", 8); //corso di informatica
            //Creo gli esami
            Esami esame1 = new Esami(corso1);
            Esami esame2 = new Esami(corso2);
            Esami esame3 = new Esami(corso3);
            Esami esame4 = new Esami(corso4);


            //Utilizzo il metodo richiedi esame
            //Studente di informatica richiede un esame che appartiene al proprio corso
            Studente.RichiediEsame(studente1, esame1); //Lo studente si è iscritto

            //Lo studente prova a iscriversi a un esame di un altro corso
            Studente.RichiediEsame(studente1, esame2);

            Studente.RichiediEsame(studente2, esame2); //iscritto
            Studente.RichiediEsame(studente2, esame1); //non iscritto

            //uno studente passa un esame a cui è iscirtto
            studente1.EsamePassato(esame1); //lo passa
            //uno studente non può passare un esame in cui non è iscritto
            studente1.EsamePassato(esame2);
            //Uno studente non può passare due volte lo stesso esame
            studente1.EsamePassato(esame1);


            //Studente1 ha superato un corso con 12 cfu, informatica ha massimo 20 cfu
            //controllo che non può iscriversi a un esame, appartenente al suo corso, con cui supererebbe i cfu massimi
            Studente.RichiediEsame(studente1, esame3); //non iscirtto

            //Controllo che il falg richiesta di laure = true
            //se si iscrive e passa un esame che lo porta ai cfu massimi
            Studente.RichiediEsame(studente1, esame4);
            studente1.EsamePassato(esame4);

        }
    }
}
