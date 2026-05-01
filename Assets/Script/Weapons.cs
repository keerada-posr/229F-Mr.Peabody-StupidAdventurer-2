using UnityEngine;

public class Weapons : MonoBehaviour
{
    public float z;
    public bool lateStart = true;
    public int damage = 25; // Adjust per weapon type

    private CameraController cam;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
        cam.SetTarget(transform);
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

        // ── NEW: hit a player ──────────────────────────────────────────
        if (other.collider.CompareTag("Player"))
        {
            PlayerHealth health = other.collider.GetComponentInParent<PlayerHealth>();
            if (health != null)
                health.TakeDamage(damage);

            Destroy(gameObject); // Arrow disappears on hit
        }
        // ──────────────────────────────────────────────────────────────

        // if (other.collider.CompareTag("Square"))
        // {
        //     GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        // }

        if (other.collider.CompareTag("Ground"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
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