using UnityEngine;

public class PowerUpMultiApple : MonoBehaviour
{
    public float respawnTimeMin;
    public float respawnTimeMax;
    private float timeTillRespawn;
    public GameObject appleToDuplicate;

    // Use this for initialization
    void Start()
    {
        respawnTimeMin = VariableManager.instance.multiAppleTimeMin;
        respawnTimeMax = VariableManager.instance.multiAppleTimeMax;
        ScheduleRespawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Snake")
        {
            Debug.Log("Snake hit some food");
            MovementSnake.instance.GrowSnake();
            AudioManager.instance.playSnakeEat();
            VariableManager.instance.eatPoints();

            for (int i = 0; i < VariableManager.instance.multiAppleExtraApples; i++)
            {
                //SPAWNS A NORMAL FOOD AND NOT AGAIN OF THE MULTIAPPLE POWERUP!
                //GameObject newApple = Instantiate(appleToDuplicate);
                GameObject newApple = Instantiate<GameObject>(appleToDuplicate);
                newApple.name = appleToDuplicate.name;
                Food logicOfApple = newApple.GetComponent<Food>();
                logicOfApple.selfDestructOnUse = true;
                logicOfApple.SpawnAtNewPosition();
                logicOfApple.showObject();
            }

            ScheduleRespawn();
        }
    }

    public void ScheduleRespawn()
    {
        timeTillRespawn = ((respawnTimeMax - respawnTimeMin) * UnityEngine.Random.value) + respawnTimeMin;
        hideObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isVisible)
        {
            timeTillRespawn -= Time.deltaTime;
            if (timeTillRespawn <= 0)
            {
                SpawnAtNewPosition();
            }
        }
    }

    private void SpawnAtNewPosition()
    {
        showObject();
        Vector3 newPosition = Vector3Extensions.getRandomVector();
        newPosition.Scale(VariableManager.instance.mapSize);
        transform.position = newPosition.floorComponentsPlusPoint5();
    }

    private bool isVisible;

    public void MoveToLocation(Vector3 newPosition)
    {
        showObject();
        transform.position = newPosition;
    }

    public void hideObject()
    {
        isVisible = false;
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            r.enabled = false;
        }
    }

    void showObject()
    {
        isVisible = true;
        Renderer[] rs = GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rs)
        {
            r.enabled = true;
        }
    }
}
