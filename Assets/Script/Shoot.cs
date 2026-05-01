using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Arrow;
    public float LaunchForce = 5f;

    private Aim aim;
    private bool hasShotThisTurn = false;

    void Start()
    {
        aim = GetComponent<Aim>();
    }

    void Update()
    {
        if (TurnManager.Instance == null) return;
        if (TurnManager.Instance.isSwitching) return; // Block during switch

        Transform currentShooter = TurnManager.Instance.GetCurrentShooter();
        if (currentShooter != transform.root) return;
        if (hasShotThisTurn) return;

        if (Input.GetKeyDown(KeyCode.Space))
            ShootArrow();
    }

    void ShootArrow()
    {
        hasShotThisTurn = true;

        Vector3 spawnPos = transform.position + (Vector3)aim.Direction.normalized;
        GameObject arrowIns = Instantiate(Arrow, spawnPos, transform.rotation);

        Rigidbody2D rb = arrowIns.GetComponent<Rigidbody2D>();
        if (rb == null) { Debug.LogError("Missing Rigidbody2D!"); return; }

        rb.linearVelocity = aim.Direction.normalized * LaunchForce;
        TurnManager.Instance.EndTurn();
        TurnManager.Instance.ResetShooters();
    }

    public void ResetTurn()
    {
        hasShotThisTurn = false;
    }
}