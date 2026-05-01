using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public Slider hpSlider;

    void Start()
    {
        currentHP = maxHP;

        if (hpSlider != null)
        {
            hpSlider.maxValue = maxHP;
            hpSlider.value = currentHP;
        }
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);

        if (hpSlider != null)
            hpSlider.value = currentHP;

        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has been destroyed!");
        // Notify TurnManager so the game knows someone died
        GameOverManager.Instance?.PlayerDied(gameObject);
        gameObject.SetActive(false);
    }
}
