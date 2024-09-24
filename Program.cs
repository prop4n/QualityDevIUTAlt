using System;

namespace QualiteDeDev
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            Livre livre = new Livre();
            livre.titre = "Le seigneur des anneaux";
            livre.numero_reference = 1;
            livre.exemplaires_dispos = 5;
            livre.auteur = "J.R.R. Tolkien";

            bibliotheque.AjouterMedia(livre);
            bibliotheque.EmprunterMedia(1);
            bibliotheque.AfficherBibliotheque();
            bibliotheque.RetournerMedia(1);
            bibliotheque.AfficherBibliotheque();
        }
    }

    class Bibliotheque {
        List<Media> mediasCollection = new List<Media>();
        
        public Media this[int referenceDemandee] {
            get {
                return mediasCollection.Find(media => media.numero_reference == referenceDemandee);
            }
        }

        public void RechercherMedia(string titre = null, string auteur = null, string artiste = null) {
            List<Media> mediasTrouves = new List<Media>();

            if (titre != null) {
                mediasTrouves = mediasCollection.FindAll(media => media.titre == titre);
            }
        }

        public void AjouterMedia(Media nouveauMedia) {
            mediasCollection.Add(nouveauMedia);
        }

        public void RetierMedia(int referenceMedia) {
            mediasCollection.Remove(this[referenceMedia]);
        }

        public Media EmprunterMedia(int referenceMedia) {
            Media media = this[referenceMedia];
            if (media.exemplaires_dispos > 0) {
                media.exemplaires_dispos--;
            }
            return media;
        }

        public void RetournerMedia(int referenceMedia) {
            this[referenceMedia].exemplaires_dispos++;
        }

        public void AfficherBibliotheque() {
            foreach (Media media in mediasCollection) {
                media.AfficherInfos();
            }
        }
    }

    class Media {
        public string titre { get; set; }
        public int numero_reference { get; set; }
        public int exemplaires_dispos { get; set; }

        public virtual void AfficherInfos() {
            Console.WriteLine("Titre : " + titre);
            Console.WriteLine("Numero de reference : " + numero_reference);
            Console.WriteLine("Exemplaires disponibles : " + exemplaires_dispos);
        }
    }

    class Livre : Media {
        public string auteur { get; set; }

        public override void AfficherInfos() {
            base.AfficherInfos();
            Console.WriteLine("Auteur : " + auteur);
        }
    }

    class DVD : Media {
        public int duree { get; set; }

        public override void AfficherInfos() {
            base.AfficherInfos();
            Console.WriteLine("Duree : " + duree);
        }
    }

    class CD : Media {
        public string artiste { get; set; }

        public override void AfficherInfos() {
            base.AfficherInfos();
            Console.WriteLine("Artiste : " + artiste);
        }
    }
}