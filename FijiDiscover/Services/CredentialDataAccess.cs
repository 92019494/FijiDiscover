using System;
using System.Collections.ObjectModel;
using FijiDiscover.Models;
using SQLite;
using Xamarin.Forms;

namespace FijiDiscover.Services
{
    public class CredentialDataAccess
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Credential> Credentials { get; set; }

        public CredentialDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Credential>();
            this.Credentials = new ObservableCollection<Credential>(database.Table<Credential>());
            if (this.Credentials.Count < 1)
            {
                AddTestAdminUser();
                SaveAllCredentials();

            }
        }

        public void AddTestAdminUser()
        {
            this.Credentials.Add(new Credential
            {
                Email = "admin@hotmail.com",
                Password = "admin"
            });
        }

        public void SaveAllCredentials()
        {
            lock (collisionLock)
            {
                foreach (var credentialInstance in this.Credentials)
                {
                    if (credentialInstance.Email != null && credentialInstance.Email != "")

                    {
                        database.Update(credentialInstance);
                    }
                    else
                    {
                        database.Insert(credentialInstance);
                    }
                }
            }
        }

        public bool LogInAdminUser(string email, string password)
        {
            lock (collisionLock)
            {
                foreach (var credentialInstance in this.Credentials)
                {
                    if (credentialInstance.Email == email & credentialInstance.Password == password)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
