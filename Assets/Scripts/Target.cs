using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private AudioSource targetAudio;

    [Header("Target Info")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float maxTorque;
    [SerializeField] private float xRange;
    [SerializeField] private float ySpawnPos;

    public int pointValue;
    [SerializeField] private ParticleSystem explosionParticle;

    [Header("Music Elements")]
    [SerializeField] private AudioClip normalSFX;
    [SerializeField] private AudioClip bombSFX;

    void Start()
    {
        targetRB = GetComponent<Rigidbody>();
        targetAudio = GetComponent<AudioSource>();

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

                AudioSource.PlayClipAtPoint(bombSFX, transform.position, 1.0f);
            }

            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            GameManager.instance.UpdateScore(pointValue);
            AudioSource.PlayClipAtPoint(normalSFX, transform.position, 1.0f);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        GameManager.instance.score -= 10;
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
