using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelInstruction : MonoBehaviour
{
    public TextMeshProUGUI lvlInstruction;
    void Start()
    {
        lvlInstruction.enabled = true;
        Invoke("DisableText", 3f);
    }
    private void DisableText()
    {
        lvlInstruction.enabled = false;
    }
}
