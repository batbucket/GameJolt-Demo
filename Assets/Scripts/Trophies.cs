using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophies : MonoBehaviour {
    public void UnlockBronze() {
        UnlockTrophy(99858); 
    }

    public void UnlockSilver() {
        UnlockTrophy(99859);
    }

    public void ShowTrophies() {
        GameJoltUI.Instance.ShowTrophies(); // This shows the achievements window, it looks ugly.
    }

    private void UnlockTrophy(int trophyId) {
        GameJolt.API.Trophies.Unlock(trophyId); // These IDs are found on the trophies page
    }
}
