using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable] 
public class MenuView
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text informationText;
    [SerializeField] private TMP_Text changePanelText;

    [SerializeField] private Button changePanelButton;

    public void ChangeTitle(string newTitle)
    {
        titleText.text = newTitle;
    }

    public void ChangeInformation(string newInformation)
    {
        informationText.text = newInformation;
    }

    public void ChangePanelText(string newPanelText)
    {
        changePanelText.text = newPanelText;
    }

    public void AddListenerToChangePanelButton(Action OnCreate)
    {
        changePanelButton.onClick.RemoveAllListeners();
        changePanelButton.onClick.AddListener(() => OnCreate?.Invoke());
    }
}
