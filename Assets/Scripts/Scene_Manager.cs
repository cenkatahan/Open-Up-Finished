using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Scene_Manager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Play_Scene() {
        SceneManager.LoadScene("MapLevel1");
    }

    public void Exit_Game() {
        Application.Quit();
    }

    public void Credits_Scene() {
        SceneManager.LoadScene("Credits");
    }

}
