using UnityEngine;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
    public Button exit;
    public Button exit2;

    // Use this for initialization
    void Start()
    {
        if (exit != null)
        {
            exit.onClick.AddListener(exitGame);
        }
        if (exit2 != null)
        {
            exit2.onClick.AddListener(exitGame);
        }
    }

    private void exitGame()
    {
        Debug.Log("APP QUIT");
        Application.Quit();
    }
}
