using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SearchItemView : IPanelView
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject subPanel;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_InputField searchInputField;
    [SerializeField] private TMP_InputField descriptionInputField;

    [Header("Button")]
    [SerializeField] private Button searchButton;
    [SerializeField] private Button updateButton;
    [SerializeField] private Button deleteButton;

    public void SetPanelActivation(bool activation)
    {
        mainPanel.SetActive(activation);
    }

    public void SetSubPanelActivation(bool actvation)
    {
        subPanel.SetActive(actvation);
    }

    public void SetItemData(string Name, string Description)
    {
        nameText.text = Name;
        descriptionInputField.text = Description;
    }

    public void ResetInputField()
    {
        searchInputField.text = string.Empty;
        descriptionInputField.text = string.Empty;
    }

    public void AddListenerToSearchButton(Action OnCreate)
    {
        searchButton.onClick.RemoveAllListeners();
        searchButton.onClick.AddListener(() => OnCreate?.Invoke());
    }

    public void AddListenerToUpdateButton(Action OnCreate)
    {
        updateButton.onClick.RemoveAllListeners();
        updateButton.onClick.AddListener(() => OnCreate?.Invoke());
    }

    public void AddListenerToDeleteButton(Action OnCreate)
    {
        deleteButton.onClick.RemoveAllListeners();
        deleteButton.onClick.AddListener(() => OnCreate?.Invoke());
    }

    public string GetSearchValue()
        => searchInputField.text;

    public string GetDescriptionValue()
        => descriptionInputField.text;
}