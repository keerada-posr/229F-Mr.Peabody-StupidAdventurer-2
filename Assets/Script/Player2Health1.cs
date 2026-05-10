using UnityEngine;

public class Player2Health1 : MonoBehaviour
{
    public int maxHP = 8;          // Change this to however many hearts you want
    public int currentHP;
    public HealthUI1 health1UI;      // Drag the HealthUI object here in Inspector

    void Start()
    {
        currentHP = maxHP;

        // Tell the UI how many hearts to create
        if (health1UI != null)
            health1UI.SetMaxHealth(maxHP);
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        // Update hearts display every time damage is taken
        if (health1UI != null)
            health1UI.UpdateHealth(currentHP);

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has been destroyed!");
        GameOverManager.Instance?.PlayerDied(gameObject);
        gameObject.SetActive(false);
    }
}