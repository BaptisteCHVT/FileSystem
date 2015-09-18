using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Certaines commandes ne fonctionnent pas du faite d'une liste qui retourne l'une après un cd
// j'ai longtemps cherché pourquoi et je n'ai malheureusement pas trouvé, j'espère que tu pourras me dire pourquoi.



namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            File Racine = new Directory("racine", null, 7);
            File current = Racine;
            string Saisie = null;

            do
            {

                Console.Write("<" + current.name + "># "); // affichage
                // on entre les commandes et les arguments
                Saisie = Console.ReadLine();
                string argument;
                string[] Commande = Saisie.Split(' ');
                string instruction = Commande[0];
                if (Commande.Length > 1)
                {
                    argument = Commande[1];
                }
                else
                {
                    argument = null;
                }


                switch (instruction)
                {

                    case "create":
                        bool creationFile = Racine.createNewFile(argument);
                        if (creationFile && argument != null)
                        {
                            Console.WriteLine("File créé !");

                        }
                        else
                        {
                            Console.WriteLine("Echec de la création de file !");
                        }

                        break;

                    case "mkdir":
                        if (current.isDirectory() && argument != null)
                        {
                            bool creationDirectory = Racine.mkdir(argument);
                            if (creationDirectory)
                            {

                                Console.WriteLine("Directory créé !");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Echec de la création de directory !");
                        }

                        break;

                    case "ls":
                        if (current.canRead())
                        {
                            if (current.ls() == null)
                            {
                                Console.WriteLine("Dossier vide");
                            }
                            else
                            {
                                foreach (File item in current.ls())
                                {
                                    Console.WriteLine(item.name + " (" + item.GetType() + ")" + "permission : " + item.permission);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Affichage du fichier impossible, droits insuffisants ou argument non valide");
                        }

                        break;


                    case "cd":
                        if (argument != null)
                        {

                            File nextFile = current.cd(argument);
                            if (nextFile == null)
                            {
                                Console.WriteLine("Déplacement invalide");
                            }
                            else
                            {
                                current = nextFile;
                            }
                        }
                        break;





                    case "file":
                        if (current.isFile() == true)
                        {
                            Console.WriteLine("Le fichier courant est un file");
                        }
                        else
                        {
                            Console.WriteLine("Le fichier courant n'est pas un file");
                        }

                        break;

                    case "directory":
                        if (current.isDirectory() == true)
                        {
                            Console.WriteLine("Le fichier courant est un directory");
                        }
                        else
                        {
                            Console.WriteLine("Le fichier courant n'est pas un directory");
                        }

                        break;

                    case "name":
                        Console.WriteLine("Le nom du fichier courant est : " + current.getName());

                        break;


                    case "rename":
                        if (argument != null)
                        {
                            current.renameTo(argument);
                        }
                        break;


                    case "parent":
                        if (argument != null)
                        {
                            current = current.getParent();
                        }

                        break;


                    case "path":
                        string path = current.getPath();
                        Console.WriteLine(path);

                        break;


                    case "root":
                        File root = current.getRoot();
                        Console.WriteLine(root.name);

                        break;

                    case "delete":
                        if (argument != null)
                        {
                            bool supp = current.delete(argument);

                            if (supp)
                            {
                                Console.WriteLine("Fichier supprimé");
                            }
                            else
                            {
                                Console.WriteLine("Fichier non supprimé");
                            }
                        }

                        break;


                    case "search":

                        List<File> recherche = current.search(argument);

                        if (recherche != null)
                        {

                            foreach (File listeFile in recherche)

                                Console.WriteLine("\\" + listeFile.getPath() + "\\");

                        }

                        break;

                    case "chmod":
                        int numPermission = Convert.ToInt32(argument);
                        if (argument != null)
                        {
                            if (numPermission < 0 && numPermission > 7)
                            {
                                current.chmod(numPermission);
                            }
                            else
                            {
                                Console.WriteLine("La permission doit se situer entre 0 et 8");
                            }
                        }

                        break;

                }
            } while (Saisie != "shutdown");

            Console.ReadLine();




        }
    }
}
