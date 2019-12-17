using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginDialogue());
    }

    IEnumerator BeginDialogue()
    {
        yield return 1;
        dialogueTrigger.TriggerDialogue();
    }
}
