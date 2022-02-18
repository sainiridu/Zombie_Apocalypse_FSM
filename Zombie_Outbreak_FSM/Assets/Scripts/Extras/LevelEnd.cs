using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public GameObject toDisable;
    public GameObject toEnable;
    public Health playerHealth;

    public void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void Update()
    {
        if (playerHealth.isDead)
        {
            Time.timeScale = 0.0f;

            toDisable.SetActive(false);

            toEnable.SetActive(true);
        }
    }
}
