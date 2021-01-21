using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Character : MonoBehaviour {

    [HideInInspector] public Animator playerKilledAnim;
    [HideInInspector] public GameObject crosshair;

    public GameObject restartMenu;
    public string levelName;

    enum PlayerState {
        alive,
        dead
    }   
    static PlayerState playerCurrentState = PlayerState.alive;

    public GameObject bullet;

    public int health = 3;
    // Start is called before the first frame update
    void Start() {
        
        playerKilledAnim = this.GetComponent<Animator>();
        restartMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (health <= 0) {
            playerCurrentState = PlayerState.dead;
            Debug.Log("PLAYER DEAD");
            playerKilledAnim.Play("PlayerDead", 0);
            restartMenu.SetActive(true);
            crosshair.SetActive(false);
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(levelName);
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Bullet") {
            health--;
        }
        if(health == 0) {
            SoundManager.PlaySound("restart");
        }
        
    }




}
