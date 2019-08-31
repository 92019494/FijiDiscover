using System;
using System.ComponentModel;
using SQLite;
namespace FijiDiscover.Models
{
    public class Activity : INotifyPropertyChanged
    {
        private int activity_id;
        [PrimaryKey, AutoIncrement]

        public int Activity_id
        {
            get
            {
                return activity_id;
            }
            set
            {
                this.activity_id = value;
                OnPropertyChanged(nameof(Activity_id));
            }
        }

        private string sourceURL;
        [NotNull]

        public string SourceURL
        {
            get
            {
                return sourceURL;
            }
            set
            {
                this.sourceURL = value;
                OnPropertyChanged(nameof(SourceURL));
            }
        }

        private string name;
        [NotNull]

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string description;
        [NotNull]

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                this.description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string location;
        [NotNull]

        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                this.location = value;
                OnPropertyChanged(nameof(Location));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
