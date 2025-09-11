using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private Vector2 startPos;
    private bool ifShake = false;
    private float[] magnitudeStages = {0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f};
    public int stage = 0;

    // Start is called before the first frame update
    private void Start()
    {
        startPos = transform.localPosition;
        StartShake(magnitudeStages[stage], 0.05f, 5f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (ifShake)
        {
            ifShake = false;
            StartShake(magnitudeStages[stage], 0.05f, 5f);
        }
        //Debug.Log(stage);
    }
    public void StartShake(float magnitude, float update, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeFunction(magnitude, update, duration));
    }

    private IEnumerator ShakeFunction(float magnitude, float update, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            transform.localPosition = startPos + new Vector2(x, y);

            yield return new WaitForSeconds(update);
            elapsed += update;
        }

        stage = Random.Range(0, 6);
        ifShake = true;
        transform.localPosition = startPos;
    }
}
