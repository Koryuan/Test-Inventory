using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class CreateItemView : IPanelView
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField descriptionInputField;
    [SerializeField] private Button createButton;

    public void SetPanelActivation(bool activation)
    {
        panel.SetActive(activation);
    }

    public void RefreshInputField()
    {
        nameInputField.text = string.Empty;
        descriptionInputField.text = string.Empty;
    }

    public void AddListenerToCreateButton(Action OnCreate)
    {
        createButton.onClick.RemoveAllListeners();
        createButton.onClick.AddListener(() => OnCreate?.Invoke());
    }

    public (string Name, string Description) GetValue()
        => (nameInputField.text, descriptionInputField.text);
}
