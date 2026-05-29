using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractAttack
{
    [SerializeField] public abstract int Priority { get; }
    [SerializeField] public abstract AbstractAttack[] ComboRequirement { get; }

    public abstract void Activate(GameObject user, Animator animator);
}
