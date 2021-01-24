using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bobnemimi : MonoBehaviour {

    private void Start()
    {
        transform.DOMoveZ(endValue: -1.990f,duration: 1.0f).SetLoops(-1,LoopType.Yoyo);
    }
}
