
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
                AddPhrases();
                SaveAllPhrases();

            }
        }

        public void AddNewPhrase()
        {
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Bula",
                PhraseEnglish = "Hello"
               
            });
        }

        public void AddPhrases()
        {
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Bula",
                PhraseEnglish = "Hello"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Vinaka",
                PhraseEnglish = "Thank You"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Moce",
                PhraseEnglish = "Goodbye"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Yadra",
                PhraseEnglish = "Good Morning"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Kerekere",
                PhraseEnglish = "Please"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Vacava tiko?",
                PhraseEnglish = "How are you?"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Au domoni iko",
                PhraseEnglish = "I love you"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Lo",
                PhraseEnglish = "Yes"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Sega",
                PhraseEnglish = "No"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Sega la neqa",
                PhraseEnglish = "No worries"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Sota tale",
                PhraseEnglish = "See you later"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Dabe ira",
                PhraseEnglish = "Sit down"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Lako mai ke",
                PhraseEnglish = "Come here"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Mai kana",
                PhraseEnglish = "Come and eat"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Baleta?",
                PhraseEnglish = "Why?"

            });
            this.Phrases.Add(new Phrase
            {
                PhraseFijian = "Vainui vinaka e nomu volau",
                PhraseEnglish = "Have a safe journey"

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



        public int DeletePhrases(Phrase phraseInstance)
        {
            var id = phraseInstance.Phrase_id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Activity>(id);
                }
            }
            this.Phrases.Remove(phraseInstance);
            return id;
        }


        public void DeleteAllActivities()
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