using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip fireSound;
    public static AudioClip footLeftStepSound;
    public static AudioClip footRightStepSound;
    public static AudioClip rifleReloadSound;
    public static AudioClip emptyMagSound;
    public static AudioClip deathSound;
    public static AudioClip surfaceHitSound;
    public static AudioClip pistolSound;
    public static AudioClip pistolReload;
    public static AudioClip playButton;
    public static AudioClip restartButton;


    static AudioSource audioSrc;

    [HideInInspector]public float volume = .5f;


    // Start is called before the first frame update
    void Start()
    {
        footLeftStepSound = Resources.Load<AudioClip>("Floor_step0");
        footRightStepSound = Resources.Load<AudioClip>("Floor_step1");
        emptyMagSound = Resources.Load<AudioClip>("empty_mag_sound");
        deathSound = Resources.Load<AudioClip>("Death_sound");
        surfaceHitSound = Resources.Load<AudioClip>("bullet_hit_surface");
        pistolSound = Resources.Load<AudioClip>("silencer_pistol");
        pistolReload = Resources.Load<AudioClip>("pistol_reload");
        playButton = Resources.Load<AudioClip>("play");
        restartButton = Resources.Load<AudioClip>("restart");

        fireSound = Resources.Load<AudioClip>("rifle_fire_audio");
        rifleReloadSound = Resources.Load<AudioClip>("rifle_reload");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "fire":
                audioSrc.PlayOneShot(pistolSound, .5f);
                break;
            case "foot_left_step":
                audioSrc.PlayOneShot(footLeftStepSound, .75f);
                break;
            case "foot_right_step":
                audioSrc.PlayOneShot(footRightStepSound, .75f);
                break;
            case "reloading":
                audioSrc.PlayOneShot(pistolReload);
                break;
            case "empty_mag":
                audioSrc.PlayOneShot(emptyMagSound);
                break;
            case "dead":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "bullet_surface_hit":
                audioSrc.PlayOneShot(surfaceHitSound);
                break;
            case "enemy_fire":
                audioSrc.PlayOneShot(fireSound);
                break;
            case "play":
                audioSrc.PlayOneShot(playButton);
                break;
            case "restart":
                audioSrc.PlayOneShot(restartButton);
                break;
        }
    }  
}
