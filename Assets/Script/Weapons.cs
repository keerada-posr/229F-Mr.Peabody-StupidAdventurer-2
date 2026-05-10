using UnityEngine;
 
public class Weapons : MonoBehaviour

{

    public float z;

    public bool lateStart = true;

    public int damage = 1;
 
    [Header("Sounds")]

    public AudioClip throwSound;

    public AudioClip hitSound;
 
    private CameraController cam;

    private AudioSource audioSource;
 
    void Start()

    {

        cam = Camera.main.GetComponent<CameraController>();

        cam.SetTarget(transform);
 
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.spatialBlend = 0f;

        audioSource.playOnAwake = false;
 
        if (throwSound != null)

            audioSource.PlayOneShot(throwSound);

    }
 
    void Update()

    {

        if (lateStart)

        {

            z = transform.localEulerAngles.z;

            lateStart = false;

        }
 
        transform.rotation = Quaternion.Euler(0, 0, z);

    }
 
    void OnCollisionEnter2D(Collision2D other)

    {

        if (other.collider.CompareTag("Circle"))

        {

            z -= 5f;

        }
 
        if (other.collider.CompareTag("Player"))

        {

            // Try PlayerHealth (Player 1)

            PlayerHealth health1 = other.collider.GetComponent<PlayerHealth>();

            if (health1 == null)

                health1 = other.collider.GetComponentInParent<PlayerHealth>();
 
            // Try Player2Health1 (Enemy / Player 2)

            Player2Health1 health2 = other.collider.GetComponent<Player2Health1>();

            if (health2 == null)

                health2 = other.collider.GetComponentInParent<Player2Health1>();
 
            if (health1 != null)

            {

                if (hitSound != null)

                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
 
                health1.TakeDamage(damage);

                Debug.Log("Hit Player 1");

            }

            else if (health2 != null)

            {

                if (hitSound != null)

                    AudioSource.PlayClipAtPoint(hitSound, transform.position);
 
                health2.TakeDamage(damage);

                Debug.Log("Hit Player 2");

            }

            else

            {

                Debug.LogWarning("No PlayerHealth found on " + other.gameObject.name);

            }
 
            Destroy(gameObject);

        }
 
        if (other.collider.CompareTag("Ground"))

        {

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
 
            // Force dynamic first so velocity can be set

            rb.bodyType = RigidbodyType2D.Dynamic;

            rb.linearVelocity = Vector2.zero;

            rb.angularVelocity = 0f;
 
            // Now safe to set static

            rb.bodyType = RigidbodyType2D.Static;
 
            Destroy(gameObject, 2f);

        }

    }
 
    void OnDestroy()

    {

        if (cam != null)

            cam.SetTarget(TurnManager.Instance.GetCurrentShooter());

    }

}
 