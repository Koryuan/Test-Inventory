using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private MenuView view;
    [SerializeField] private CreateItemController createItemController;

    private void Awake()
    {
        createItemController.Init();
    }
}