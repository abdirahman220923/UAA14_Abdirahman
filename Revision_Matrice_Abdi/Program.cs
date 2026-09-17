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
            string[,] matrice;
            bool valide;

            Console.WriteLine("BienvenueBienvenue dans l'application de cryptage");

            do
            {
                Console.WriteLine("Choisissez une méthode de cryptage :");
                Console.WriteLine("1 = Chiffre de Vigenère");
                Console.WriteLine("2 = Chiffre Affine");
                FonctionsProgram.LireEntier("Votre choix : ", out choix);

                if (choix == 1)
                {
                    Console.WriteLine("Entrez votre message :");
                    messageBrut = Console.ReadLine();
                    FonctionsProgram.NettoyerMessage(messageBrut, out messagePropre);

                    Console.WriteLine("Entrez la clé :");
                    cle = Console.ReadLine();

                    FonctionsProgram.ChiffrerVigenere(messagePropre, cle, out matrice);

                    Console.WriteLine(" MATRICE DE CRYPTAGE ");
                    FonctionsProgram.AfficherMatrice(matrice, 4, messagePropre.Length);

                    Console.WriteLine("Message chiffré : ");
                    int iColonne = 0;
                    while (iColonne < messagePropre.Length)
                    {
                        Console.WriteLine(matrice[3, iColonne]);
                        iColonne = iColonne + 1;
                    }
                    Console.WriteLine();
                }
                else if (choix == 2)
                {
                    Console.WriteLine("Entrez votre message :");
                    messageBrut = Console.ReadLine();
                    FonctionsProgram.NettoyerMessage(messageBrut, out messagePropre);

                    do
                    {
                        FonctionsProgram.LireEntier("Entrez a (valeurs possibles : 1,3,5,7,9,11,15,17,19,21,23,25) :", out a);
                        FonctionsProgram.VerifierA(a, out valide);
                        if (valide == false)
                        {
                            Console.WriteLine("Valeur de a invalide ! Recommencez.");
                        }
                    }
                    while (valide == false);

                    do
                    {
                        FonctionsProgram.LireEntier("Entrez b (entre 0 et 25) :", out b);
                        if (b < 0 || b > 25)
                        {
                            Console.WriteLine("Valeur de b invalide ! Recommencez.");
                        }
                    }
                    while (b < 0 || b > 25);
                    FonctionsProgram.ChiffrerAffine(messagePropre, a, b, out matrice);

                    Console.WriteLine("=== MATRICE DE CRYPTAGE ===");
                    FonctionsProgram.AfficherMatrice(matrice, 4, messagePropre.Length);

                    Console.WriteLine ("Message chiffré : ");
                    int iColonne = 0;
                    while (iColonne < messagePropre.Length)
                    {
                        Console.WriteLine(matrice[3, iColonne]);
                        iColonne = iColonne + 1;
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Choix invalide !");
                }


                Console.WriteLine("Voulez-vous recommencer ? (espace = oui / autre = non)");
                recommencer = Console.ReadLine();
            } while (recommencer == " ");
        }
    }
}
