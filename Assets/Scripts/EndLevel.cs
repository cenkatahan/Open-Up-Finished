using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndLevel : MonoBehaviour {

    public string currentLevel;



    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Player") {
            if(currentLevel == "MapLevel1") {
                SceneManager.LoadScene("MapLevel2");

            } else if (currentLevel == "MapLevel2") {
                SceneManager.LoadScene("MapLevel3");
            } else {
                SceneManager.LoadScene("Credits");
            }
        }
    }

}
