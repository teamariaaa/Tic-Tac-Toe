using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MyBoard : MonoBehaviour
{
    public TMP_Text TextX;
    public TMP_Text Text0;
    public TMP_Text TextDraw;

    public TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
        text.enabled = false;
    }
}
