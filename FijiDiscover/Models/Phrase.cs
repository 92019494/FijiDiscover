using System;
using System.ComponentModel;
using SQLite;
namespace FijiDiscover.Models
{
    public class Phrase : INotifyPropertyChanged
    {
        private int phrase_id;
        [PrimaryKey, AutoIncrement]

        public int Phrase_id
        {
            get
            {
                return phrase_id;
            }
            set
            {
                this.phrase_id = value;
                OnPropertyChanged(nameof(Phrase_id));
            }
        }

        private string phraseFijian;
        [NotNull]

        public string PhraseFijian
        {
            get
            {
                return phraseFijian;
            }
            set
            {
                this.phraseFijian = value;
                OnPropertyChanged(nameof(PhraseFijian));
            }
        }

        private string phraseEnglish;
        [NotNull]

        public string PhraseEnglish
        {
            get
            {
                return phraseEnglish;
            }
            set
            {
                this.phraseEnglish = value;
                OnPropertyChanged(nameof(PhraseEnglish));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

