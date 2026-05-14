using TMPro;
using UnityEngine;

public class TextManagement : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    public TextMeshProUGUI textBomb;


    void Update()
    {
        textBomb.SetText("Bombs left: " + PlayerData.remainingBombs);
        textTime.SetText("Time until boss: " + PlayerData.timeUntilBoss);
    }
}
