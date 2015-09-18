using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class File
    {
        public int permission;
        public string name;
        public Directory parent;
        public File(string name, Directory parent, int permission)
        {
            this.name = name;
            this.parent = parent;
            this.permission = permission;
        }



        public virtual bool mkdir(string name)
        {
            return false;
        }


        public virtual bool createNewFile(string name)
        {
            return false;
        }


        public virtual File cd(string name)
        {
            return null;
        }


        public virtual bool renameTo(string newName)
        {
            this.name = newName;
            return true;
        }


        public virtual bool chmod(int permission)
        {
            this.permission = permission;
            return true;
        }



        public virtual List<File> ls()
        {
            return null;
        }


        public virtual bool isFile()
        {
            if (typeof(File) == this.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public virtual bool isDirectory()
        {
            if (typeof(Directory) == this.GetType())
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public virtual string getName()
        {
            return null;
        }



        public virtual File getParent()
        {

            return this.parent;
        }

        public string getPath()
        {
            File getWay = this;
            string path = "";

            while (getWay.name != "racine")
            {

                path = getWay.name + "racine" + path;
                getWay = getWay.parent;

            }

            return path;

        }


        public virtual File getRoot()
        {
            File racine = this;

            while (racine.parent.name != "racine")
            {
                racine = racine.parent;

            }

            return racine;

        }

        public virtual bool delete(string Nom)
        {
            return false;
        }


        public virtual List<File> search(string name)
        {
            return null;
        }


        public virtual bool canWrite()
        {
            return (this.permission & 2) > 0;
        }

        public virtual bool canExecute()
        {
            return (this.permission & 1) > 0;
        }

        public virtual bool canRead()
        {
            return (this.permission & 4) > 0;
        }


    }
}
