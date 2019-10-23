using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public GameObject[] Quests;
    [SerializeField] List<Quest> QuestUiNotes;
    [SerializeField] Transform itemsParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    public void GetTheUpdate()
    {

    }

    public void ActivateQuest(int questnum, Quest quest)
    {
        Quests[questnum].SetActive(true);
        Addquest(quest);
    }

    public void Addquest(Quest quest)
    {

    }




}
