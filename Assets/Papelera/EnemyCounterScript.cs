using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterScript : MonoBehaviour
{
    public Text enemyCounterText;
    private int enemyCounter = 0;

    public void UpdateEnemyCounter()
    {
        enemyCounter++;
        enemyCounterText.text = "Enemigos eliminados: " + enemyCounter;
    }
}

