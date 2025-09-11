using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    [SerializeField] private Bottle bottle;
    [SerializeField] private float lifeTime = 5f;

    private void Awake()
    {
        bottle = FindObjectOfType<Bottle>();
    }

    private void Start()
    {
        Invoke(nameof(AutoDelete), lifeTime);
    }

    private void Update()
    {
        Delete();
    }

    private void Delete()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Destroy(gameObject);
            bottle.breakProgress += 0.1f;
        }
    }

    private void AutoDelete()
    {
        Destroy(gameObject);
        bottle.breakProgress -= 0.1f;
    }
}
