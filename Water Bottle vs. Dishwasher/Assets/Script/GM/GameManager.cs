using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    [SerializeField] private Shake shake;
    private Vector2 spawnPos;
    private float spawnTime;
    private int stage;

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        float spawnRate = GetSpawnRate(shake.stage);

        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0f)
        {
            SpawnRandom();
            spawnTime = spawnRate;
        }
    }

    private void SpawnRandom()
    {
        int choice = Random.Range(0, 4);
        GameObject prefab = null;

        switch (choice)
        {
            case 0: 
                prefab = up; 
            break;
            case 1: 
                prefab = down; 
            break;
            case 2: 
                prefab = left; 
            break;
            case 3: 
                prefab = right; 
            break;
        }

        if (prefab != null)
            Instantiate(prefab, GetRandomScreenPosition(), prefab.transform.rotation);
    }

    private float GetSpawnRate(int stage)
    {
        switch (stage)
        {
            case 0: 
                return 3f;
            case 1: 
                return 2.5f;
            case 2: 
                return 2f;
            case 3: 
                return 1.5f;
            case 4:
                return 1f;
            case 5: 
                return 0.5f;
            default: 
                return 3f;
        }
    }

    private Vector2 GetRandomScreenPosition()
    {
        Camera cam = Camera.main;

        float x = Random.Range(0, Screen.width);
        float y = Random.Range(0, Screen.height);

        spawnPos = cam.ScreenToWorldPoint(new Vector2(x, y));

        return spawnPos;
    }
}
