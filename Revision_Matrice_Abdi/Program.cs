namespace Revision_Matrice_Abdi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string messageBrut;
            string messagePropre;
            string cle;
            int a;
            int b;
            int choix;
            string recommencer;
            char[,] matrice;

            Console.WriteLine("Bienvenue dans l'application de cryptage");

            do
            {
                Console.WriteLine("Choisissez une méthode de cryptage :");
                Console.WriteLine("1 = Chiffre de Vigenère");
                Console.WriteLine("2 = Chiffre Affine");
                choix = FonctionsProgram.LireEntier("Votre choix : ");

                if (choix == 1)
                {
                    messageBrut = FonctionsProgram.LireChaine("Entrez votre message :");
                    FonctionsProgram.NettoyerMessage(messageBrut, out messagePropre);
                    cle = FonctionsProgram.LireChaine("Entrez la clé :");

                    FonctionsProgram.ChiffrerVigenere(messagePropre, cle, out matrice);

                    Console.WriteLine("=== MATRICE DE CRYPTAGE ===");
                    FonctionsProgram.AfficherMatrice(matrice, 4, messagePropre.Length);

                    Console.Write("Message chiffré : ");
                    int i = 0;
                    while (i < messagePropre.Length)
                    {
                        Console.Write(matrice[3, i]);
                        i = i + 1;
                    }
                    Console.WriteLine();
                }
                else if (choix == 2)
                {
                    messageBrut = FonctionsProgram.LireChaine("Entrez votre message :");
                    FonctionsProgram.NettoyerMessage(messageBrut, out messagePropre);

                    bool valide;
                    do
                    {
                        a = FonctionsProgram.LireEntier("Entrez a (valeurs possibles : 1,3,5,7,9,11,15,17,19,21,23,25) :");
                        FonctionsProgram.VerifierA(a, out valide);
                        if (valide == false)
                        {
                            Console.WriteLine("Valeur de a invalide ! Recommencez.");
                        }
                    }
                    while (valide == false);

                    do
                    {
                        b = FonctionsProgram.LireEntier("Entrez b (entre 0 et 25) :");
                        if (b < 0 || b > 25)
                        {
                            Console.WriteLine("Valeur de b invalide ! Recommencez.");
                        }
                    }
                    while (b < 0 || b > 25);

                    FonctionsProgram.ChiffrerAffine(messagePropre, a, b, out matrice);

                    Console.WriteLine("=== MATRICE DE CRYPTAGE ===");
                    FonctionsProgram.AfficherMatrice(matrice, 4, messagePropre.Length);

                    Console.Write("Message chiffré : ");
                    int i = 0;
                    while (i < messagePropre.Length)
                    {
                        Console.Write(matrice[3, i]);
                        i = i + 1;
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Choix invalide !");
                }

                Console.WriteLine("Voulez-vous recommencer ? (espace = oui / autre = non)");
                recommencer = Console.ReadLine();
            }
            while (recommencer == " ");
        }
    }
}
