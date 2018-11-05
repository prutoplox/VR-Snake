using UnityEngine;

public class Food : MonoBehaviour
{
    public float respawnTimeMin;
    public float respawnTimeMax;
    private float timeTillRespawn;
    public bool selfDestructOnUse;

    // Use this for initialization
    void Start()
    {
        respawnTimeMin = VariableManager.instance.foodTimeMin;
        respawnTimeMax = VariableManager.instance.foodTimeMax;
        ScheduleRespawn();
    }

    public void ScheduleRespawn()
    {
        if (selfDestructOnUse)
        {
            Destroy(this);
        }
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

    public void SpawnAtNewPosition()
    {
        Vector3 newPosition = Vector3Extensions.getRandomVector();
        newPosition.Scale(VariableManager.instance.mapSize);
        MoveToLocation(newPosition.floorComponentsPlusPoint5());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Snake")
        {
            Debug.Log("Snake hit some food");
            MovementSnake.instance.GrowSnake();
            AudioManager.instance.playSnakeEat();
            VariableManager.instance.eatPoints();
            ScheduleRespawn();
        }
    }

    private bool isVisible;

    public void MoveToLocation(Vector3 newPosition)
    {
        showObject();
        transform.position = newPosition;
    }

    void hideObject()
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
