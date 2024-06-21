using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    public int maxHearts = 3; // Número máximo de corazones
    public int currentHearts; // Corazones actuales del jugador
    public GameObject heartPrefab; // Prefab del corazón

    private GameObject[] hearts; // Array para almacenar los corazones

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
