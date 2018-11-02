using GameJolt.API;
using GameJolt.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Authenticate : MonoBehaviour {
    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI text;

    public void SignIn() {
        if (!GameJoltAPI.Instance.HasSignedInUser) {

            // This shows the sign in window
            GameJoltUI.Instance.ShowSignIn(

                // Callback for what happens when the sign in is successful/unsuccessful
                (bool signInSuccess) => {
                    if (signInSuccess) {
                        button.gameObject.SetActive(false);
                    }
                    Debug.Log(string.Format("Sign-in {0}", signInSuccess ? "successful" : "failed"));
                },

                // Callback for what happens when the user's info is fetched
                (bool userFetchedSuccess) => {
                    Debug.Log(string.Format("User fetched {0}", userFetchedSuccess ? "successful" : "failed"));
                }
            );
        } else {
            // Hmm what does this do...?
            GameJoltAPI.Instance.CurrentUser.SignOut();
        }
    }

    private void Update() {
        if (GameJoltAPI.Instance.HasSignedInUser) {
            text.SetText("Sign out");
        } else {
            text.SetText("Sign in");
        }
    }
}
