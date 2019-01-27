using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakerDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(Score.displayBaker);
    }
}
