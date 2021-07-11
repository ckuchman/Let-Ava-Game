using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        popUpIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++) {
            if (i == popUpIndex) {
                popUps[popUpIndex].SetActive(true);
            } else {
                popUps[popUpIndex].SetActive(false);
            }
        }

        if (popUpIndex <= 1) {
            // Teach player how to jump and double jump
            if(Input.GetKeyDown(KeyCode.UpArrow)) {
                popUpIndex++;
            }
        } else if(popUpIndex == 2) {
            spawner.SetActive(true);
        }
    }
}
