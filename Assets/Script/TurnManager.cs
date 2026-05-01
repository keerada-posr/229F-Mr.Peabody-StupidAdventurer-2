using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;

    public Transform player1;
    public Transform player2;

    public bool isPlayer1Turn = true;
    public bool isSwitching = false; // Lock during switch

    void Awake()
    {
        Instance = this;
    }

    public Transform GetCurrentShooter()
    {
        return isPlayer1Turn ? player1 : player2;
    }

    public void EndTurn()
    {
        if (!isSwitching)
            StartCoroutine(SwitchTurn());
    }

    IEnumerator SwitchTurn()
    {
        isSwitching = true;
        isPlayer1Turn = !isPlayer1Turn;
        yield return null; // Wait one frame before allowing input again
        isSwitching = false;
    }

    public bool IsPlayer1Turn() => isPlayer1Turn;

    public void ResetShooters()
    {
        Shoot[] allShooters = FindObjectsByType<Shoot>(FindObjectsSortMode.None);
        foreach (Shoot s in allShooters)
            s.ResetTurn();
    }
}