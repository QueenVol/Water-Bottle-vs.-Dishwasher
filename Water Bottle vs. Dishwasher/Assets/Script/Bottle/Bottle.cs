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
    private SpriteRenderer spriteRenderer;
    private bool isBroken = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Debug.Log(breakProgress);
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
        }

        Time.timeScale = 0f;
    }
}
