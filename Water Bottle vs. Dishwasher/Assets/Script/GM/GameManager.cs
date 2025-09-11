using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject up;
    [SerializeField] private GameObject down;
    [SerializeField] private GameObject left;
    [SerializeField] private GameObject right;
    private Vector2 spawnPos;

    // Start is called before the first frame update
    private void Start()
    {
        spawnPos = new Vector2 (0,0);
        Instantiate(down, spawnPos, down.transform.rotation);
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
