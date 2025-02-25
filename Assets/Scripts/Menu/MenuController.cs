using System.Collections;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuView view;
    [SerializeField] private CreateItemController createItemController;

    private IEnumerator ShowInformationEnumerator;

    private void Awake()
    {
        createItemController.Init(InformationUpdate);
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
}