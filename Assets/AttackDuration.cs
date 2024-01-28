using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDuration : MonoBehaviour
{

    private float duration;

    // Update is called once per frame
    void Update()
    {
        duration += Time.deltaTime;

        if (duration > 2)
        {
            Destroy(gameObject);
        }
    }
}
