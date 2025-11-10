using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;

    [Header("Target Info")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxTorque;
    [SerializeField] private float xRange;
    [SerializeField] private float ySpawnPos;

    public int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    

    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        targetRB.AddForce(RandomSpeed(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.isGameActive)
        {
            if (gameObject.CompareTag("Bad"))
            {
                GameManager.instance.lives--;

                GameManager.instance.UpdateLives();
            }

            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.instance.UpdateScore(pointValue);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private Vector3 RandomSpeed()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
       return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
