using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Button options;
    public Button options1;

    // Use this for initialization
    void Start()
    {
        options.onClick.AddListener(VariableManager.instance.showOptionsMenu);
        options1.onClick.AddListener(VariableManager.instance.showOptionsMenu);
    }
}
