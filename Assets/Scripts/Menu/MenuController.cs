using System.Collections;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuView view;
    [SerializeField] private CreateItemController createItemController;
    [SerializeField] private SearchItemController searchItemController;

    public enum Panel
    {
        Create,
        Search
    }

    private Panel currentPanel;
    private IEnumerator ShowInformationEnumerator;

    private void Awake()
    {
        createItemController.Init(InformationUpdate);
        searchItemController.Init(InformationUpdate);

        currentPanel = Panel.Create;
        ChangePanel(currentPanel);

        view.ChangeInformation(string.Empty);
        view.AddListenerToChangePanelButton(() => ChangePanel(currentPanel == Panel.Create ? Panel.Search : Panel.Create));
    }

    public void InformationUpdate(string itemName)
    {
        StopCoroutine(ShowInformationEnumerator);
        
        ShowInformationEnumerator = ShowInformation(itemName);
        StartCoroutine(ShowInformationEnumerator);
    }

    private IEnumerator ShowInformation(string newInformation)
    {
        view.ChangeInformation(newInformation);

        yield return new WaitForSeconds(5);

        view.ChangeInformation(string.Empty);
    }

    private void ChangePanel(Panel newPanel)
    {
        if (currentPanel == Panel.Create)
        {
            searchItemController.ClosePanel();
            createItemController.OpenPanel();

            view.ChangeTitle("Create Item");
            view.ChangePanelText("Search");
        }
        else if (currentPanel == Panel.Search)
        {
            createItemController.ClosePanel();
            searchItemController.OpenPanel();

            view.ChangeTitle("Search and Update Item");
            view.ChangePanelText("Create");
        }
        currentPanel = newPanel;
    }
}