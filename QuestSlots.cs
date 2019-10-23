using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestSlots : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    
    public event Action<Quest> OnLeftClickEvent;
    public Quest _quest;
    public Text text;
    public Quest Quest
    {
        get { return _quest; }
        set
        {
            _quest = value;
            if (_quest == null)
            {
                //image.enabled = false;
                text.enabled = false;

            }
            else
            {
                //image.sprite = _item.icon;
                //image.enabled = true;
                text.enabled = true;
                text.text = Quest.QuestName;
            }
        }
    }
    private Item _Item;




    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            if (Quest != null && OnLeftClickEvent != null)
            {

            }
        }
    }
}
