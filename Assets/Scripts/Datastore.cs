using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Datastore : MonoBehaviour {
    [SerializeField]
    private TMP_InputField key;

    [SerializeField]
    private TMP_InputField value;

    [SerializeField]
    private TextMeshProUGUI text;

    private List<string> keyValues = new List<string>();

    private void Start() {
        StartCoroutine(UpdateText());
    }

    // Posts to the data store using the inputfields.
    public void Post() {
        GameJolt.API.DataStore.Set(key.text, value.text, true, isSuccess => Debug.Log("post success=" + isSuccess));
        value.text = string.Empty;
        key.text = string.Empty;
    }

    // This is just for displaying all the key values that exist globally.
    // Realistically, you'll probably just call Get on a single key from time to time.
    public IEnumerator UpdateText() {
        while (true) {
            keyValues.Clear();
            GameJolt.API.DataStore.GetKeys(true, keys => {
                foreach (string key in keys) {

                    GameJolt.API.DataStore.Get(key, true, value => {
                        keyValues.Add(key + "/" + value);
                    });
                }
                
            });
            yield return new WaitForSeconds(5);
        }
    }

    private void Update() {
        text.SetText(string.Join("\n", keyValues.ToArray()));
    }
}
