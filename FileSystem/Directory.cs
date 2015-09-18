using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Directory : File
    {
        List<File> listeFile = new List<File>();
        // j'ai un problème avec ma liste, retourne null losque l'on se déplace dans un fichier avec le cd 

        public Directory(string name, Directory parent, int permission) :
            base(name, parent, permission)
        {
            this.name = name;
            this.parent = parent;
        }

        override public bool mkdir(string name)
        {
            if (base.canWrite())
            {
                Directory newDirectory = new Directory(name, this, 4);
                listeFile.Add(newDirectory);
                return true;
            }
            else
            {
                return false;
            }
        }

        override public bool createNewFile(string name)
        {
            if (canWrite())
            {
                File newFile = new File(name, this, 4);
                listeFile.Add(newFile);
                return true;
            }
            else { return false; }
        }

        override public File cd(string Nom)
        {
            if (canRead())
            {
                foreach (File newFile in listeFile)
                {

                    if (newFile.name == Nom)
                    {
                        return newFile;
                    }
                }
            }
            else
            {
                return null;

            }
            return null;


        }


        override public bool renameTo(string newName)
        {
            if (canWrite())
            {
                this.name = newName;
                return true;
            }
            else { return false; }
        }

        override public List<File> ls()
        {
            return listeFile;

        }


        override public string getName()
        {
            return name;
        }


        override public bool delete(string Nom)
        {
            if (canWrite())
            {
                foreach (File courant in listeFile)
                {

                    if (courant.name == Nom)
                    {
                        listeFile.Remove(courant);
                        return true;
                    }
                }
            }
            return false;

        }




        override public List<File> search(string Nom)
        {
            List<File> recherche = null;

            recherche = new List<File>();

            foreach (File courant in listeFile)
            {

                if (courant.name == Nom)
                {
                    recherche.Add(courant);
                }
            }

            return recherche;
        }


        override public File getParent()
        {
            return null;
        }



        override public bool chmod(int permission)
        {
            this.permission = permission;
            return true;
        }

        override public bool canWrite()
        {
            return (this.permission & 2) > 0;
        }

        override public bool canExecute()
        {
            return (this.permission & 1) > 0;
        }

        override public bool canRead()
        {
            return (this.permission & 4) > 0;
        }




    }
}
