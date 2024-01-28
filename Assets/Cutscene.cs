using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public DialogTrigger trigger;
    void OnEnable()
    {
        trigger.StartDialogue();
    }
}
