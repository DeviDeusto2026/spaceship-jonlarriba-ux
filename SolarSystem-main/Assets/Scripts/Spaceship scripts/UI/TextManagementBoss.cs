using TMPro;
using UnityEngine;

public class TextManagementBoss : MonoBehaviour
{
    public TextMeshProUGUI textBomb;
    public TextMeshProUGUI textHealth;

    void Update()
    {
        textHealth.SetText("Remaining health: " + PlayerData.bossHealth);
        textBomb.SetText("Bombs left: " + PlayerData.remainingBombs);
    }
}
