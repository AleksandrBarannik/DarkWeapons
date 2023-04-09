using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Применяется при поднятии мнгновенно (автоматически)

[Serializable]
public class InstantItem : Item
{
    [SerializeField][Tooltip("For Money")]
    private int CountData;
}
