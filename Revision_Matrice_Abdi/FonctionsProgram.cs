using System;

namespace Revision_Matrice_Abdi
{
    public class FonctionsProgram
    {
        // Lire un entier avec validation
        public static int LireEntier(string question)
        {
            int resultat;
            do
            {
                Console.WriteLine(question);
            }
            while (!int.TryParse(Console.ReadLine(), out resultat));
            return resultat;
        }

        // Lire une chaîne non vide
        public static string LireChaine(string question)
        {
            string resultat;
            do
            {
                Console.WriteLine(question);
                resultat = Console.ReadLine();
            }
            while (resultat == "" || resultat == null);
            return resultat;
        }

        // Nettoyer le message : supprimer espaces + majuscules
        public static void NettoyerMessage(string messageBrut, out string messagePropre)
        {
            messagePropre = "";
            int i = 0;
            while (i < messageBrut.Length)
            {
                char c = messageBrut[i];
                if (c != ' ')
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        c = (char)(c - 32);
                    }
                    messagePropre = messagePropre + c;
                }
                i = i + 1;
            }
        }

        // Chiffre de Vigenère
        public static void ChiffrerVigenere(string message, string cle, out char[,] matrice)
        {
            int nbColonnes = message.Length;
            matrice = new char[4, nbColonnes];

            int i = 0;
            int iCle = 0;
            while (i < nbColonnes)
            {
                matrice[0, i] = message[i];
                matrice[1, i] = cle[iCle];

                int codeClair = (int)message[i];
                int codeCle = (int)cle[iCle];
                int decalage = codeCle - 65;
                matrice[2, i] = Convert.ToChar(decalage + 48);

                int codeChiffre = ((codeClair - 65) + decalage) % 26;
                matrice[3, i] = Convert.ToChar(codeChiffre + 65);

                iCle = iCle + 1;
                if (iCle >= cle.Length)
                {
                    iCle = 0;
                }

                i = i + 1;
            }
        }

        // Chiffre Affine
        public static void ChiffrerAffine(string message, int a, int b, out char[,] matrice)
        {
            int nbColonnes = message.Length;
            matrice = new char[4, nbColonnes];

            int i = 0;
            while (i < nbColonnes)
            {
                matrice[0, i] = message[i];

                int x = (int)message[i] - 65;
                matrice[1, i] = Convert.ToChar(x + 48);

                int y = (a * x + b) % 26;
                matrice[2, i] = Convert.ToChar(y + 48);

                matrice[3, i] = Convert.ToChar(y + 65);

                i = i + 1;
            }
        }

        // Afficher une matrice
        public static void AfficherMatrice(char[,] matrice, int nbLignes, int nbColonnes)
        {
            int iLigne = 0;
            while (iLigne < nbLignes)
            {
                string chaine = "";
                int iColonne = 0;
                while (iColonne < nbColonnes)
                {
                    chaine = chaine + matrice[iLigne, iColonne] + " ";
                    iColonne = iColonne + 1;
                }
                Console.WriteLine(chaine);
                iLigne = iLigne + 1;
            }
        }

        // Vérifier la valeur de a
        public static void VerifierA(int a, out bool valide)
        {
            valide = false;
            if (a == 1 || a == 3 || a == 5 || a == 7 || a == 9 || a == 11)
            {
                valide = true;
            }
            if (a == 15 || a == 17 || a == 19 || a == 21 || a == 23 || a == 25)
            {
                valide = true;
            }
        }
    }
}