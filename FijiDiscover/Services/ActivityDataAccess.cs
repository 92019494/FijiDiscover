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

        public void AddNewActivity()
        {
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
        }

        public void AddTestData()
        {
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
            this.Activities.Add(new Activity
            {
                SourceURL = "www.google.com",
                Name = "Drinking cocktails",
                Description = "Have a refreshing drink at a Bar",
                Location = "Capital Bar, Fiji"
            });
        }

        public Activity GetActivity(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Activity>().FirstOrDefault(activity => activity.Activity_id == id);
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