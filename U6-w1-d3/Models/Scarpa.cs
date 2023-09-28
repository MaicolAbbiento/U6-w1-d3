using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U6_w1_d3.Models
{
    public class Scarpa
    {
        public int Id { get; set; }
        public string NomeArticolo { get; set; }
        public decimal Prezzo { get; set; }
        public string Descrizione { get; set; }
        public string Immagine { get; set; } = "a";

        public string ImmaginiAggiuntiva1 { get; set; } = "a";
        public string ImmaginiAggiuntiva2 { get; set; } = "a";
        public bool Presente { get; set; } = true;

        public Scarpa(string nomeArticolo, decimal prezzo, string descrizione, string immagine, string immaginiAggiuntiva1, string immaginiAggiuntiva2)
        {
            NomeArticolo = nomeArticolo;
            Prezzo = prezzo;
            Descrizione = descrizione;
            Immagine = immagine;
            ImmaginiAggiuntiva1 = immaginiAggiuntiva1;
            ImmaginiAggiuntiva2 = immaginiAggiuntiva2;
        }

        public Scarpa(int id, string nomeArticolo, decimal prezzo, string descrizione, string immagine, string immaginiAggiuntiva1, string immaginiAggiuntiva2)
        {
            Id = id;
            NomeArticolo = nomeArticolo;
            Prezzo = prezzo;
            Descrizione = descrizione;
            Immagine = immagine;
            ImmaginiAggiuntiva1 = immaginiAggiuntiva1;
            ImmaginiAggiuntiva2 = immaginiAggiuntiva2;
        }

        public Scarpa()
        { }

        public Scarpa(string nomeArticolo, decimal prezzo, string descrizione)
        {
            NomeArticolo = nomeArticolo;
            Prezzo = prezzo;
            Descrizione = descrizione;
        }

        public static List<Scarpa> ScarpaList { get; set; } = new List<Scarpa>();
    }
}