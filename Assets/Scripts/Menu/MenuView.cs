using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable] 
public class MenuView
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text informationText;

    public void ChangeTitle(string newTitle)
    {
        titleText.text = newTitle;
    }

    public void ChangeInformation(string newInformation)
    {
        informationText.text = newInformation;
    }
}
