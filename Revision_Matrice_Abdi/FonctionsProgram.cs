using System;
using System.Collections.Generic;
using System.Text;

namespace Revision_Matrice_Abdi
{
    internal class FonctionsProgram
    {
        public static void LireEntier(string question, out int resultat)
        {
            do
            {
                Console.WriteLine(question);
            }
            while (!int.TryParse(Console.ReadLine(), out resultat));
        }
        public static void ChiffrerVigenere(string message, string cle, out string[,] matrice)
        {
            int nbColonnes = message.Length;
            matrice = new string[4, nbColonnes];

            int iColonne = 0;
            int iCle = 0;
            while (iColonne < nbColonnes)
            {
                matrice[0, iColonne] = message[iColonne].ToString();
                matrice[1, iColonne] = cle[iCle].ToString();
                int codeClair = (int)message[iColonne];
                int codeCle = (int)cle[iCle];
                iCle = iCle + 1;
                if (iCle >= cle.Length)
                {
                    iCle = 0;
                }
                int decalage = codeCle - 65;
                matrice[2, iColonne] = Convert.ToString(decalage);
                int codeChiffre = ((codeClair - 65) + decalage) % 26;
                matrice[3, iColonne] = Convert.ToChar(codeChiffre + 65).ToString();

                iColonne = iColonne + 1;
            }
        }
        public static void ChiffrerAffine(string message, int a, int b, out string[,] matrice)
        {
            int nbColonnes = message.Length;
            matrice = new string[4, nbColonnes];

            int iColonne = 0;
            while (iColonne < nbColonnes)
            {
                matrice[0, iColonne] = message[iColonne].ToString();

                int x = (int)message[iColonne] - 65;
                matrice[1, iColonne] = Convert.ToString(x);

                int y = (a * x + b) % 26;
                matrice[2, iColonne] = Convert.ToString(y);

                matrice[3, iColonne] = Convert.ToChar(y + 65).ToString();

                iColonne = iColonne + 1;
            }
        }
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
        public static void NettoyerMessage(string messageBrut, out string messagePropre)
        {
            messagePropre = "";
            int iCaractere = 0;
            while (iCaractere < messageBrut.Length)
            {
                char c = messageBrut[iCaractere];
                if (c != ' ')
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        c = (char)(c - 32);
                    }
                    messagePropre = messagePropre + c;
                }
                iCaractere = iCaractere + 1;
            }
        }
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
