using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindAnyObjectByType<EventManager>();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Action<int> OnScoreIncremented;

    public Action OnCollect;

    public Action OnCollectableDrop;

}
