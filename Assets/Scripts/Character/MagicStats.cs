using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicStats : Stats
{
    [SerializeField]
    protected int intelligence = 1;

    [SerializeField]
    protected int wisdom = 1;

    public int CurrentManaPoints;
    public int MaxMana => Mathf.Max(5, intelligence * (wisdom * 5));
    public float SpeedMagicCast =>Mathf.Max(1,  1 + (0.1f * intelligence * wisdom));
    public int MagicDamage => Mathf.Max(1, 1 *wisdom);
    public int MagicBulletCount => Mathf.Max(1, 3 * intelligence);

    public override void Initialize()
    {
        base.Initialize();
        CurrentManaPoints = MaxMana;
    }
}
