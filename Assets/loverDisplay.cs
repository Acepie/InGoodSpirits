using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loverDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(Score.displayLover);
    }
}
