using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {

    Slider slider;
    public float num;//抜いた枚数（仮置き）
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();

    }

    float bar = 0.0f;

    void Update()
    {
        UpdateBar(num);
    }
    void UpdateBar(float num)
    {
        if (bar <= num)
        {
            bar += 0.01f;
        }
        slider.value = bar;
    }

    
}
