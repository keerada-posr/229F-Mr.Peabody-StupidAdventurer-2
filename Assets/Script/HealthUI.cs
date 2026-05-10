using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUI : MonoBehaviour
{
    public Image hearts1;
    public Sprite heart1Sprites;
    public Sprite heart1Empty;
    private List<Image> heartImages = new List<Image>();

    public void SetMaxHealth(int maxHealth)
    {
        foreach (Image heart in heartImages)
            Destroy(heart.gameObject);

        heartImages.Clear();

        for (int i = 0; i < maxHealth; i++)
        {
            Image heartImage = Instantiate(hearts1, transform);
            heartImage.sprite = heart1Sprites;
            heartImage.color = Color.red;
            heartImages.Add(heartImage);
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < heartImages.Count; i++)
        {
            if (i < currentHealth)
            {
                heartImages[i].sprite = heart1Sprites;
                heartImages[i].color = Color.red;
            }
            else
            {
                heartImages[i].sprite = heart1Empty;
                heartImages[i].color = Color.white;
            }
        }
    }
}
