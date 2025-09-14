using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bottle : MonoBehaviour
{
    public float breakProgress = 1f;
    public Slider slider;
    [SerializeField] private Sprite brokenBottle;
    [SerializeField] private GameObject endingScreen;
    [SerializeField] private GameObject processSlider;
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource backgroundNoise;
    [SerializeField] private AudioSource endMusic;
    private SpriteRenderer spriteRenderer;
    private bool isBroken = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundMusic.PlayDelayed(3f);
    }

    private void Update()
    {
        //Debug.Log(breakProgress);
        if(breakProgress > 1f )
        {
            breakProgress = 1f;
        }
        slider.value = breakProgress;

        if (breakProgress <= 0f && !isBroken)
        {
            spriteRenderer.sprite = brokenBottle;
            transform.localScale = new Vector2(0.4f, 0.4f);
            isBroken = true;

            ShowEndingScreen();
        }
    }

    private void ShowEndingScreen()
    {
        if (endingScreen != null)
        {
            endingScreen.SetActive(true);
            processSlider.SetActive(false);
            backgroundMusic.Stop();
            backgroundNoise.Stop();
            endMusic.Play();
        }

        Time.timeScale = 0f;
    }
}
