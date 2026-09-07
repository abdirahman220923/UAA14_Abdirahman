using System;
using System.IO.IsolatedStorage;

namespace ACT00_REVISION
{
    class Program
    {
        public static void Main(string[] args)
        {
            // déclaration des variables.... COMPLETER AVEC CE QUI MANQUE

            string rep;
            
            double c1 = 0;
            double c2 = 0;
            double c3 = 0;
            bool ok = false;
            string infos;

            Console.WriteLine("Testez les polygones !");
            //On recommence tant que désiré
            do
            {
                //lecture des 3 côtés => A FAIRE
                
                c1 = lireDouble(1);
                c2 = lireDouble(2);
                c3 = lireDouble(3);

                // ordonner les côtés => APPEL ORDONNECOTES
                MethodesDuProjet.OrdonneCotes(ref c1, ref c2, ref c3);
                // série de test (voir consignes)
                // si on a un triangle...
                if (MethodesDuProjet.Triangle(c1, c2, c3))
                {
                    // préparation et affichage du résultat du test 'triangle' avec la procédure 'Affiche'
                    MethodesDuProjet.PrepareAffichage(out infos, "triangle", true);
                    Console.WriteLine(infos);

                    // vérification équilatéral
                    if (MethodesDuProjet.Equi(c1, c2, c3))// si on a un triangle équilatéral...
                    {
                        // préparation et affichage du résultat du test 'equilateral' avec la procédure 'Affiche'
                        MethodesDuProjet.PrepareAffichage(out infos, "equilateral", true);
                        Console.WriteLine(infos);
                    }
                    else
                    {
                        // vérification triangle rectangle
                        if (MethodesDuProjet.TriangleRectangle(c1, c2, c3))// si on a un triangle rectangle...
                        {
                            // préparation et affichage du résultat positif du test 'rectangle' avec la procédure 'Affiche'
                            MethodesDuProjet.PrepareAffichage(out infos, "rectangle", true);
                            Console.WriteLine(infos);
                        }
                        else
                        {
                            // préparation et affichage du résultat négatif du test 'rectangle' avec la procédure 'Affiche'
                            MethodesDuProjet.PrepareAffichage(out infos, "rectangle", false);
                            Console.WriteLine(infos);
                        }
                        // vérification du cas isocèle et affichage dans le cas positif
                        MethodesDuProjet.Isocele(c1, c2, c3, out ok);
                        if(ok)
                        {
                            // préparation et affichage du résultat positif du test 'isocele' avec la procédure 'Affiche'
                            MethodesDuProjet.PrepareAffichage(out infos, "isocele", true);
                            Console.WriteLine(infos);

                            //... A vous de voir en combien de lignes...
                        }
                    }
                }
                else // si ce n'est pas un triangle
                {
                    // préparation et affichage du résultat négataif du test 'triangle' avec la procédure 'Affiche'
                    MethodesDuProjet.PrepareAffichage(out infos, "triangle", false);
                    Console.WriteLine(infos);
                }
                // reprise ?
                Console.WriteLine("Voulez-vous tester un autre polygône ? (Tapez espace)");
                rep = Console.ReadLine();
            } while (rep == " ");
        }
        //Récupération d'une donnée fournie par l'utilisateur en 'double' : on suppose qu'il ne se trompe pas !
        static double lireDouble(int numeroCote)
        {
            double cote;
            Console.Write("Tapez la valeur du côté " + numeroCote + " : ");
            cote = double.Parse(Console.ReadLine());
            return cote;
        }
    }
}
