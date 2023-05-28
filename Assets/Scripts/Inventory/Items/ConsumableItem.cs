using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Можно применить и исчесзнет (но можно положить в инвентарь)

[Serializable]
public class ConsumableItem : Item
{
    [SerializeField]
    private ParticleSystem _particle;
    public ParticleSystem Particle => _particle;

}
