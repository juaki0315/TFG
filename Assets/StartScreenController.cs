using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject startPanel;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            startPanel.SetActive(false);
        }
    }
}
