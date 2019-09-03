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
    public class ActivityDataAccess
    {

        private SQLiteConnection database;
        private static object collisionLock = new object();

        public ObservableCollection<Activity> Activities { get; set; }

        public ActivityDataAccess()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Activity>();
            this.Activities = new ObservableCollection<Activity>(database.Table<Activity>());
            if (this.Activities.Count < 1)
            {
                AddTestData();
                SaveAllActivities();
                
            }
        }

   
        public void AddNewActivity(string url, string name, string description, string location)
        {
            this.Activities.Add(new Activity
            {
                SourceURL = url,
                Name = name,
                Description = description,
                Location = location
            });
        }

        public void AddTestData()
        {
            this.Activities.Add(new Activity
            {
                SourceURL = "https://www.fiji-budget-vacations.com/images/cloudnine62.jpg",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "https://media.tacdn.com/media/attractions-splice-spp-674x446/07/a7/12/de.jpg",
                Name = "Fijian Day Cruise",
                Description = "Cruise around the islands of Fiji in luxury",
                Location = "Mamanuca"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "https://media.tacdn.com/media/attractions-splice-spp-674x446/07/1d/82/45.jpg",
                Name = "Nadi Tivua Island Cruise",
                Description = "Set sail by tall ship to the island sanctuary of Tivua, a small but pristine tropical island in Fiji. Be greeted with a kava welcome ceremony, then spend plenty of free time sunbathing, snorkeling or exploring the tropical waters by canoe or on a glass-bottom boat tour. Morning and afternoon tea, a barbecue buffet lunch, plus unlimited beer, wine and soft drinks keep you fortified all day. This full-day trip includes hotel pickup and drop-off in Nadi, Denarau and Coral Coast",
                Location = "Denarau Island, Fiji"
            });
            this.Activities.Add(new Activity 
            {
                SourceURL = "https://media.tacdn.com/media/attractions-splice-spp-674x446/06/6a/e6/f1.jpg",
                Name = "Mud Pool Tour",
                Description = "See the highlights of Nadi on a half-day tour, starting with the Sri Siva Subramaniya Temple. Learn about its Hindu features from your knowledgeable guide before a scenic drive to a handicraft market. After some shopping, stop by Namaka fruit market and admire orchids at the Garden of the Sleeping Giant. Finish with a therapeutic mud bath at Sabeto Hot Springs.",
                Location = "Nadi, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "https://media.tacdn.com/media/attractions-splice-spp-674x446/07/01/8f/b3.jpg",
                Name = "Cultural Night Tour",
                Description = "Experience a celebration after sunset in a local Fijian village on this guided tour that includes a Kava Ceremony and Meke Show. Tour a traditional village and see how a traditional meal is prepared and enjoyed here. Learn the etiquette and take part in a Kava Ceremony drinking the root of the same name. Afterward take in a fire dance and Meke show while enjoying your meal.",
                Location = "Nadi, Fiji"
            });
        }

        public Activity GetActivity(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Activity>().FirstOrDefault(activity => activity.Activity_id == id);
            }
        }

        public int GetActivityID(Activity activityInstance)
        {
            lock (collisionLock)
            {
                return activityInstance.Activity_id;
            }
        }



        public int SaveActivity(Activity activityInstance)
        {
            lock (collisionLock)
            {
                if (activityInstance.Activity_id != 0)
                {
                    database.Update(activityInstance);
                    return activityInstance.Activity_id;
                }
                else
                {
                    database.Insert(activityInstance);
                    return activityInstance.Activity_id;
                }
            }
        }

        public void SaveAllActivities()
        {
            lock (collisionLock)
            {
                foreach (var activityInstance in this.Activities)
                {
                    if (activityInstance.Activity_id != 0)

                    {
                        database.Update(activityInstance);
                    }
                    else
                    {
                        database.Insert(activityInstance);
                    }
                }
            }
        }



        public int DeleteActivity(Activity activityInstance)
        {
            var id = activityInstance.Activity_id;
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Activity>(id);
                }
            }
            this.Activities.Remove(activityInstance);
            return id;
        }


        public void DeleteAllActivities()
        {
            lock (collisionLock)
            {
                database.DropTable<Activity>();
                database.CreateTable<Activity>();
            }
            this.Activities = null;
            this.Activities = new ObservableCollection<Activity>(database.Table<Activity>());
        }

    }
}