using System;
using UnityEngine;

[Serializable]
public class CreateItemController : IPanelController
{
    [SerializeField] private CreateItemView view;

    private Action<string> OnItemCreatedSuccessfully;

    public void Init(Action<string> OnItemCreatedSuccessfully)
    {
        this.OnItemCreatedSuccessfully = OnItemCreatedSuccessfully;

        view.RefreshInputField();

        view.AddListenerToCreateButton(CreateItem);
    }

    public void CreateItem()
    {
        var value = view.GetValue();
        bool success = Inventory.Instance.CreateItem(value.Name, value.Description);

        string information = success ? $"Item [{value.Name}] create successfully" : "Failed to create item";
        OnItemCreatedSuccessfully?.Invoke(information);
    }

    public void OpenPanel()
    {
        view.RefreshInputField();
        view.SetPanelActivation(true);
    }

    public void ClosePanel()
    {
        view.SetPanelActivation(false);
    }
}