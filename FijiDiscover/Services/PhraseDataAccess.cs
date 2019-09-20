
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FijiDiscover;
using FijiDiscover.Models;
using SQLite;
using Xamarin.Forms;

namespace FijiDiscover.Services
{
    public class PhraseDataAccess
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Phrase> Phrases { get; set; }

        public PhraseDataAccess()
        {
            
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Phrase>();
            this.Phrases = new ObservableCollection<Phrase>(database.Table<Phrase>());
            if (this.Phrases.Count < 1)
            {
                DeleteAllPhrases();
                AddPhrases();
                SaveAllPhrases();

            }
        }

        public void AddPhrases()
        {
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Bula Vinaka",
                PhraseEnglish = "Hello",
                VoiceClip = "bul.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Tou lai kana",
                PhraseEnglish = "Let's eat",
                VoiceClip = "tou.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Loloma yani",
                PhraseEnglish = "Send my love/regards",
                VoiceClip = "lol.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Iko Hale cava?",
                PhraseEnglish = "What Hale do you live in?",
                VoiceClip = "iko.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Kerekere waraki au",
                PhraseEnglish = "Please wait for me",
                VoiceClip = "ker.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Iko lako i vei?",
                PhraseEnglish = "Where are you going?",
                VoiceClip = "ikoTwo.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Iko bulabula vinaka tiko?",
                PhraseEnglish = "Are you feeling well?",
                VoiceClip = "ikoThree.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Moce",
                PhraseEnglish = "Goodbye",
                VoiceClip = "moc.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Au domoni iko",
                PhraseEnglish = "I love you",
                VoiceClip = "aud.mp3"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Vinaka vakalevu",
                PhraseEnglish = "Thank you",
                VoiceClip = "vin.mp3"

            });
        }

        public Phrase GetPhrase(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Phrase>().FirstOrDefault(phrase => phrase.Phrase_id == id);
            }
        }

        public int SavePhrase(Phrase phraseInstance)
        {
            lock (collisionLock)
            {
                if (phraseInstance.Phrase_id != 0)
                {
                    database.Update(phraseInstance);
                    return phraseInstance.Phrase_id;
                }
                else
                {
                    database.Insert(phraseInstance);
                    return phraseInstance.Phrase_id;
                }
            }
        }

        public void SaveAllPhrases()
        {
            lock (collisionLock)
            {
                foreach (var phraseInstance in this.Phrases)
                {
                    if (phraseInstance.Phrase_id != 0)

                    {
                        database.Update(phraseInstance);
                    }
                    else
                    {
                        database.Insert(phraseInstance);
                    }
                }
            }
        }


        public void DeleteAllPhrases()
        {
            lock (collisionLock)
            {
                database.DropTable<Phrase>();
                database.CreateTable<Phrase>();
            }
            this.Phrases = null;
            this.Phrases = new ObservableCollection<Phrase>(database.Table<Phrase>());
        }

    }
}