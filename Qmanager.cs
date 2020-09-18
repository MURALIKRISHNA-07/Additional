using System.Collections.Generic;
using UnityEngine;
namespace QuestSystem
{
    public class Qmanager
    {
        //It allow us to access the info without explicitly calling Object
        private IQuestinfo info;
        public IQuestinfo Information
        {
            get { return info; }
        }

        private List<IQuestObjective> objectives;

        private bool Completed()
        {
            for (int i = 0; i < objectives.Count; i++)
            {

                if(!objectives[i].IsCompleted)
                {
                    return false;
                }
            }

                return true;
            
        }
    }


    public class Questinfo : IQuestinfo
    {
        string name;
        string descriptionsummary;
        string dialogue;
        int sourceid;
        int questid;
        int chainquestid;

        public string Name => name;

        public string DescriptionSummary => descriptionsummary;

        public string Dialogue => dialogue;

        public int Sourceid => sourceid;

        public int Questid => questid;

        public int ChainQuestid => chainquestid;
    }

    public class CollectionObjective : IQuestObjective
    {
        string O_Name;
        string O_description;
        string Title;
        bool iscompleted;
        int collectionamount;//How much to be collected
        int currentamount;//starts at 0

        private GameObject itemstocollect;

        public string Name => O_Name;

        public string DescriptionSummary => O_description;

        public bool IsCompleted => iscompleted;

        public int CollectionAmount => collectionamount;


        public CollectionObjective(string title,int totalamount,GameObject item,string descrp)
        {
            O_Name = title + " " + totalamount + " " + item.name;
            Title = title;
            O_description = descrp;
            itemstocollect = item;
            collectionamount = totalamount;
            currentamount = 0;
            CheckProgress();
        }

        public void CheckProgress()
        {
            if (currentamount >= collectionamount)
                iscompleted = true;
            else
                iscompleted = false;
        }

        public void UpdateProgress()
        {
            throw new System.NotImplementedException();
        }

        //how much gathered
        public override string ToString()
        {
            return currentamount + "/" + collectionamount + " " + itemstocollect.name + " " + Title;
        }
    }


    public class LocationObjective : IQuestObjective
    {

        string O_Name;
        string O_description;
        bool iscompleted;

        private Location TargetLocation;

        public string Name => O_Name;

        public string DescriptionSummary => O_description;

        public bool IsCompleted => iscompleted;

       

        public void CheckProgress()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateProgress()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Location
    {
        private Vector3 worldcord;

        public Vector3 WorldCord => worldcord;
        

        public Location(Vector3 Loc)
        {
            this.worldcord = Loc;
        }

        public bool Compare(Location location)
        {
            if (location.worldcord == worldcord)
                return true;
            else
                return false;
        }

    }

    public interface IQuestinfo
    {
        string Name { get; }
        string DescriptionSummary { get; }
        string Dialogue { get; }
        int Sourceid { get; }
        int Questid { get; }
        int ChainQuestid { get; }
    }

    public interface IQuestObjective
    {
        string Name { get; }
        string DescriptionSummary { get; }

        bool IsCompleted { get; }
        
        

        void CheckProgress();
        void UpdateProgress();
    }
}
