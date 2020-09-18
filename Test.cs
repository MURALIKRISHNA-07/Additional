using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuestSystem;

public class Test : MonoBehaviour
{
    GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        IQuestObjective qb = new CollectionObjective("Mission1", 10, item, "Collect");
        Debug.Log(qb.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
