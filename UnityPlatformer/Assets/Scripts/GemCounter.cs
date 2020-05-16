using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GemCounter : MonoBehaviour
{
    private Text _gemCounter;
    private int _gems = 0;

    private void Start()
    {
        _gemCounter = GetComponent<Text>();   
    }

    public void IncreaseGems()
    {
        _gems++;
        _gemCounter.text = _gems.ToString();
    }
}
