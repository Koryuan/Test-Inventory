using System;
using UnityEngine;

[Serializable]
public class SearchItemController : IPanelController
{
    [SerializeField] private SearchItemView view;

    private ItemData targetData = null;

    private Action<string> ShowInformationAction;

    public void Init(Action<string> ShowInformationAction)
    {
        this.ShowInformationAction = ShowInformationAction;

        view.AddListenerToSearchButton(SearchItem);
        view.AddListenerToUpdateButton(UpdateItem);
        view.AddListenerToDeleteButton(DeleteItem);
    }


    public void OpenPanel()
    {
        view.ResetInputField();
        view.SetPanelActivation(true);
        view.SetSubPanelActivation(false);
    }

    public void ClosePanel()
    {
        view.SetPanelActivation(false);
        view.SetSubPanelActivation(false);
    }

    private void SearchItem()
    {
        var searchName = view.GetSearchValue();
        bool success = Inventory.Instance.RetriveItem(searchName, out ItemData output);

        if (!success)
        {
            ShowInformationAction?.Invoke($"Failed to search item: {searchName}");
            return;
        }

        targetData = output;

        view.SetItemData(targetData.Name, targetData.Description);
        view.SetSubPanelActivation(true);

        ShowInformationAction?.Invoke($"Success find item name: {searchName}");
    }

    private void UpdateItem()
    {
        if (targetData == null)
        {
            ShowInformationAction("There is no data to update");
            return;
        }

        var newDescription = view.GetDescriptionValue();
        bool success = Inventory.Instance.UpdateItemDescription(targetData.Name, newDescription);
        if (!success) ShowInformationAction?.Invoke($"Failed to update item");
        else ShowInformationAction?.Invoke($"Successfully update item data");

    }

    private void DeleteItem()
    {
        if (targetData == null)
        {
            ShowInformationAction("There is no data to delete");
            return;
        }

        bool success = Inventory.Instance.DeleteItem(targetData.Name);
        if (!success) ShowInformationAction?.Invoke($"Failed to delete item");
        else
        {
            view.SetSubPanelActivation(false);
            ShowInformationAction?.Invoke($"Successfully delete item");
        }
    }
}