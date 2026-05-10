using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI1 : MonoBehaviour
{
    public Image hearts2;
    public Sprite heart2Sprites;
    public Sprite heart2Empty;
    private List<Image> heart2Images = new List<Image>();

    public void SetMaxHealth(int maxHealth)
    {
        foreach (Image heart2 in heart2Images)
            Destroy(heart2.gameObject);

        heart2Images.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            Image heart2Image = Instantiate(hearts2, transform);
            heart2Image.sprite = heart2Sprites;
            heart2Image.color = Color.red;
            heart2Images.Add(heart2Image);
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < heart2Images.Count; i++)
        {
            if (i < currentHealth)
            {
                heart2Images[i].sprite = heart2Sprites;
                heart2Images[i].color = Color.red;
            }
            else
            {
                heart2Images[i].sprite = heart2Empty;
                heart2Images[i].color = Color.white;
            }
        }
    }
}
