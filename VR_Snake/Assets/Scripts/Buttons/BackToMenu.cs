using UnityEngine;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    public Button back1;
    public Button back2;

    // Use this for initialization
    void Start()
    {
        back1.onClick.AddListener(backToMenu);
        back2.onClick.AddListener(backToMenu);
    }

    private void backToMenu()
    {
        VariableManager.instance.showMainMenuMenu();
    }
}
