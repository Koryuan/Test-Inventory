using UnityEngine;

[System.Serializable]
public class CreateItemController : IPanelController
{
    [SerializeField] private CreateItemView view;

    public void Init()
    {
        view.RefreshInputField();
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