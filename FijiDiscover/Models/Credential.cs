using System;
using System.ComponentModel;
using SQLite;

namespace FijiDiscover.Models

{
    public class Credential : INotifyPropertyChanged
    {
       

        private string email;
        [NotNull, Unique, PrimaryKey]

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                this.email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string password;
        [NotNull]


        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


     

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
