using UnityEngine;

//Script to Create the World Map (Grid of Spheres)
public class CreateMap : MonoBehaviour
{
    public Transform startSphere;
    public GameObject sphere;
    public static CreateMap instance;

    void Start()
    {
        Vector3 size = VariableManager.instance.mapSize;
        instance = this;
        VariableManager.instance.scalefactor = 1;

        for (int i = 0; i <= size.x; i++)
        {
            for (int j = 0; j <= size.y; j++)
            {
                for (int k = 0; k <= size.z; k++)
                {
                    GameObject newGrid = Instantiate(sphere, startSphere.transform.position + new Vector3(i * VariableManager.instance.scalefactor, j * VariableManager.instance.scalefactor, k * VariableManager.instance.scalefactor), startSphere.rotation, sphere.transform.parent);

                    //newGrid.GetComponent<Renderer>().material.color = new Color(i / size.x, j / size.y, k / size.z);

                    if (i % VariableManager.instance.largerGrid == 0 && j % VariableManager.instance.largerGrid == 0 && k % VariableManager.instance.largerGrid == 0)
                    {
                        newGrid.transform.localScale = VariableManager.instance.largerGridSizeFactor * newGrid.transform.localScale;
                    }
                }
            }
        }
    }
}
