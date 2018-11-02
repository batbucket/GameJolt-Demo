using GameJolt.API;
using GameJolt.API.Objects;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscores : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI text;

    public void PostToHighscoresAsUser() {
        int randomNumber = Random.Range(0, 10000);

        // First parameter is number value, second is what is seen
        // Example: 100, "100 jumps"
        Scores.Add(randomNumber, randomNumber.ToString());
    }

    public void PostToHighscoresAsGuest() {
        int randomNumber = Random.Range(0, 10000);

        // There's a parameter for specifying a guest name.
        Scores.Add(randomNumber, randomNumber.ToString(), SystemInfo.deviceModel + "@" + SystemInfo.batteryLevel);
    }

    public void ShowHighScores() {
        // Ugly leaderboards display.
        GameJoltUI.Instance.ShowLeaderboards();
    }
    
    // Show leaderboards in the text.
    private void Update() {
        Scores.Get(scores => {
            List<string> scoreTexts = new List<string>();
            foreach (Score score in scores) {
                scoreTexts.Add(score.PlayerName + "/" + score.Value);
            }
            text.SetText(string.Join("\n", scoreTexts.ToArray()));
        }, 0, 100);
    }
}