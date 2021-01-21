using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    private float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 10;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");

    }
}
