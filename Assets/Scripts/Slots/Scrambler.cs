using System;
using System.Collections.Generic;
using UnityEngine;

public class Scrambler : MonoBehaviour
{
    public void Scramble()
    {
        List<Transform> items = new List<Transform>();

        foreach (Transform item in transform)
            items.Add(item);

        for (int i = 0; i < items.Count; i++)
        {
            int rand = UnityEngine.Random.Range(i, items.Count);
            (items[i], items[rand]) = (items[rand], items[i]);
        }

        for (int i = 0; i < items.Count; i++)
        {
            items[i].SetSiblingIndex(i);
        }
    }
}