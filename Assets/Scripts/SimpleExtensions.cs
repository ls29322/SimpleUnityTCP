﻿using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// This class collects all the extensions used to improve or facilitate the use of in-build methods
/// Remember to use this. to use extensions on monobehaviour scripts
/// </summary>
public static class SimpleExtensions
{    
    //Invoke
    public static void Invoke(this MonoBehaviour mono, Action action, float delay)
    {
        mono.StartCoroutine(ExecuteAfterTime(action, delay));
    }
    private static IEnumerator ExecuteAfterTime(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    //Invoke Repeating
    public static void InvokeRepeating(this MonoBehaviour mono, Action action, float repeatRate = 1, float initialDelay = 0)
    {
        mono.StartCoroutine(ExecuteRepeatedlyAfterTime(action, repeatRate, initialDelay));
    }
    private static IEnumerator ExecuteRepeatedlyAfterTime(Action action, float repeatRate, float initialDelay)
    {
        yield return new WaitForSeconds(initialDelay);

        while (true)
        {
            action?.Invoke();
            yield return new WaitForSeconds(repeatRate);
        }
    }
}