using System;
using System.IO;

namespace Homework
{
    class Account
    {
        string login;
        string password;

        public Account()
        {
            this.login = "";
            this.password = "";
        }

        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void setLoginPassword(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public string getLogin()
        {
            return this.login;
        }

        public string getPassword()
        {
            return this.password;
        }

        public bool IsEntered()
        {
            string login = "root";
            string password = "GeekBrains";
            bool bLogin = String.Equals(this.login, login);
            bool bPassword = String.Equals(this.password, password);
            if (bLogin && bPassword)
                return true;
            else
            {
                this.login = "";
                this.password = "";
                return false;
            }
        }

        public static string[,] ReadFromFile(string filename)
        {
            string[] readTXT;
            if (File.Exists(filename))
            {
                readTXT = File.ReadAllText(filename).Split("\r\n");
                int length = readTXT.Length;
                string[,] loginPassword = new string[length / 2, 2];
                int k = 0;
                for (int i = 0; i < length / 2; i++)
                    for (int j = 0; j < 2; j++)
                    {
                        loginPassword[i, j] = readTXT[k];
                        k++;
                    }
                return loginPassword;
            }
            else
            {
                Console.WriteLine("File does not exist.");
                return null;
            }
        }

        public override string ToString()
        {
            return $@"Login: {this.login}
Password: {this.password}";
        }
    }
}
