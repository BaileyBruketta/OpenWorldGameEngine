
using UnityEngine;
using UnityEngine.UI;

public class StatDisplay : MonoBehaviour
{
    public Text Nametext;
    public Text Valuetext;

    private void OnValidate()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        Nametext = texts[0];
        Valuetext = texts[1];
    }
}