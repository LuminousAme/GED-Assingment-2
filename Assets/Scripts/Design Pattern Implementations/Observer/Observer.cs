using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//based on observer pattern video : https://youtu.be/UWMmib1RYFE

//observer
public abstract class Observer : MonoBehaviour
{
    public static event Action myStaticEvent;

    private void Update()
    {
        myStaticEvent?.Invoke();
    }

}
