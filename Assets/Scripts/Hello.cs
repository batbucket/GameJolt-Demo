using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hello : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI text;

    private void Update() {
        if (GameJoltAPI.Instance.HasSignedInUser) {
            text.SetText("Hello, " + GameJoltAPI.Instance.CurrentUser.Name);
        }
    }
}
