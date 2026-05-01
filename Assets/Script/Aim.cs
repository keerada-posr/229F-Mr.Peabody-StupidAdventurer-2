using UnityEngine;

public class Aim : MonoBehaviour
{
    public Vector2 Direction;
    public float force;

    public GameObject PointPrefab;
    public GameObject[] Points;
    public int numberOfPoints;

    private bool isFlipped = false;

    void Start()
    {
        Points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab, transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (TurnManager.Instance == null) return;

        Transform currentShooter = TurnManager.Instance.GetCurrentShooter();
        bool isMyTurn = currentShooter == transform.root;

        foreach (var p in Points)
            p.SetActive(isMyTurn);

        if (!isMyTurn) return;

        isFlipped = !TurnManager.Instance.IsPlayer1Turn();

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bowPos = transform.position;
        Direction = mousePos - bowPos;

        if (isFlipped)
            Direction.x = -Mathf.Abs(Direction.x);
        else
            Direction.x = Mathf.Abs(Direction.x);

        FaceMouse();

        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i].transform.position = PointPosition(i * 0.1f);
        }
    }

    void FaceMouse()
    {
        transform.right = Direction;
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position
            + (Direction.normalized * force * t)
            + 0.5f * Physics2D.gravity * (t * t);

        return currentPointPos;
    }
}