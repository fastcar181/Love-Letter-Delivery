using System.Collections;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score Instance; // Singleton instance

    private int NumDelivered = 0;
    private int ScoreNum = 0;
    public bool end = false;

    public GameObject EndGamePanel;
    public Text EndGameText;

    private void Awake()
    {
        EndGamePanel.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensures only one instance exists
        }
    }

    public bool CheckDeliveryStatus()
    {
        return NumDelivered == 6;
    }

    public void IncreaseNumDelivered()
    {
        NumDelivered++;
    }

    public void IncreaseScoreNum()
    {
        ScoreNum++;
    }

    public void DetermineEnding()
    {
        end = true;
        EndGamePanel.SetActive(true);
        EndGameText.text = (NumDelivered == ScoreNum) ? "YOU WON!" : "YOU LOSE!";
        EndGameText.text += $"\nYou delivered {ScoreNum} letter(s) correctly!";
        EndGameText.text += "Whether you won or lost, I love my Nick, and Happy Valentine's Day!";
        StartCoroutine(QuitGameAfterDelay());
    }

    private IEnumerator QuitGameAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
