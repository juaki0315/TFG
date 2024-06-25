using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    public int maxHearts = 3;
    public int currentHearts;
    public GameObject heartPrefab;

    private GameObject[] hearts;

    void Start()
    {
        currentHearts = maxHearts;

        hearts = new GameObject[maxHearts];

        for (int i = 0; i < maxHearts; i++)
        {
            hearts[i] = Instantiate(heartPrefab, transform);
        }
    }

    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            Destroy(hearts[currentHearts]); 
            hearts[currentHearts] = null;

            if (currentHearts == 0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
