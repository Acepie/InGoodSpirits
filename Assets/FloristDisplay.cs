﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloristDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(Score.displayFlorist);
    }
}
