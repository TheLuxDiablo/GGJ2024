using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WDAudio : MonoBehaviour
{
    public float targetTime = 0f;
    private float startTargetTime = 0f;

    [SerializeField] private AudioSource wdAudio_1;
    [SerializeField] private AudioSource wdAudio_2;
    [SerializeField] private AudioSource wdAudio_3;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        targetTime += Time.deltaTime;

        if (targetTime == 14f)
        {
            wdAudio_1.Play();
        }
        else if (targetTime == 25f)
        {
            wdAudio_2.Play();
        }
        else if (targetTime == 38f)
        {
            wdAudio_3.Play();
            targetTime = startTargetTime;
        }
    }
}
