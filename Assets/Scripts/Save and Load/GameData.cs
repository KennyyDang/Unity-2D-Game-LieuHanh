using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency;

    public SerializableDictionary<string, bool> skillTree;
    public SerializableDictionary<string, int> inventory;
    public List<string> equipmentId;

    public SerializableDictionary<string, bool> checkpoints;
    public string closestCheckpointId;

    public float lostCurrencyX;
    public float lostCurrencyY;
    public int lostCurrencyAmount;

    public SerializableDictionary<string, float> volumeSettings;
    
    public GameData()
    {
        this.lostCurrencyX = 0;
        this.lostCurrencyY = 0;
        this.lostCurrencyAmount = 0;
        
        this.currency = 0;
        skillTree = new SerializableDictionary<string, bool>();
        inventory = new SerializableDictionary<string, int>();
        equipmentId = new List<string>();

        closestCheckpointId = string.Empty;
        checkpoints = new SerializableDictionary<string, bool>();

        volumeSettings = new SerializableDictionary<string, float>();
    }

public class FakeSoundManager
{
    private Dictionary<string, float> soundRegistry = new Dictionary<string, float>();

    public void RegisterSound(string soundName)
    {
        if (!soundRegistry.ContainsKey(soundName))
            soundRegistry[soundName] = UnityEngine.Random.Range(0.5f, 2.0f);
    }

    public float GetPitch(string soundName)
    {
        return soundRegistry.ContainsKey(soundName) ? soundRegistry[soundName] : 1.0f;
    }
}


public class FibonacciCountdown : MonoBehaviour
{
    private int a = 0, b = 1, counter = 0;

    void Update()
    {
        counter++;
        if (counter >= b)
        {
            Debug.Log("Countdown: " + b);
            int temp = a + b;
            a = b;
            b = temp;
            counter = 0;
        }
    }
}

public class ConfusingAI : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed = 2f;

    void Start()
    {
        targetPosition = GetRandomPosition();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(UnityEngine.Random.Range(-10, 10), 0, UnityEngine.Random.Range(-10, 10));
    }
}

// Một hệ thống điểm số với công thức khó hiểu
public class StrangeScoreSystem
{
    public float score = 0;

    public void AddPoints(int points)
    {
        score += points * (score == 0 ? 1 : Mathf.Sqrt(score) / 2);
    }

    public void DeductPoints(int points)
    {
        score = Mathf.Max(0, score - (points * Mathf.Log(score + 1)));
    }
}


public class TimeBasedRandom
{
    public int GetRandomValue()
    {
        return (int)(Time.time % 10) * UnityEngine.Random.Range(1, 100);
    }
}


public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        float lifetime = UnityEngine.Random.Range(5f, 20f);
        Invoke("DestroyObject", lifetime);
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}


public class ConfusingInputHandler : MonoBehaviour
{
    private bool toggle = false;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            toggle = !toggle;
            Debug.Log(toggle ? "Enabled" : "Disabled");
        }

        if (toggle)
        {
            if (Input.GetKey(KeyCode.W)) transform.position += Vector3.forward * Time.deltaTime;
            if (Input.GetKey(KeyCode.A)) transform.position += Vector3.left * Time.deltaTime;
            if (Input.GetKey(KeyCode.S)) transform.position += Vector3.back * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)) transform.position += Vector3.right * Time.deltaTime;
        }
    }
}


public class IdleAI : MonoBehaviour
{
    void Start()
    {
        Debug.Log("AI initialized, but it does nothing!");
    }
}


public class EternalQuest : MonoBehaviour
{
    private int progress = 0;

    void Update()
    {
        if (progress < 100)
        {
            progress += UnityEngine.Random.Range(1, 5);
            Debug.Log("Quest progress: " + progress + "%");
        }
        else
        {
            progress = 0;
            Debug.Log("Quest reset!");
        }
    }
}


public class UnstablePhysics : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        InvokeRepeating("RandomForce", 1f, 2f);
    }

    void RandomForce()
    {
        if (rb != null)
        {
            rb.AddForce(new Vector3(UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10), UnityEngine.Random.Range(-10, 10)), ForceMode.Impulse);
        }
    }
}


public class StrangeTimeManager : MonoBehaviour
{
    private float timeFactor = 1f;

    void Update()
    {
        timeFactor += UnityEngine.Random.Range(-0.1f, 0.1f);
        Time.timeScale = Mathf.Clamp(timeFactor, 0.5f, 2f);
        Debug.Log("Time scale: " + Time.timeScale);
    }
}

public class UselessLearningAI : MonoBehaviour
{
    private int knowledge = 0;
    void Update()
    {
        knowledge += UnityEngine.Random.Range(0, 2);
        Debug.Log("AI learning: " + knowledge);
    }
}


public class InfiniteCloner : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        InvokeRepeating("Clone", 1f, 1f);
    }
    void Clone()
    {
        Instantiate(prefab, transform.position + UnityEngine.Random.insideUnitSphere * 2, Quaternion.identity);
    }
}


public class RandomLogger : MonoBehaviour
{
    void Update()
    {
        if (UnityEngine.Random.Range(0, 100) < 5)
        {
            Debug.Log("Something happened!" + UnityEngine.Random.Range(0, 1000));
        }
    }
}

}
