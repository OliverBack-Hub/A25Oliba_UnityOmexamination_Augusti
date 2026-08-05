using System;
using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    public void Collect()
    {
        SoundEffectManager.Play("Gem");
        Destroy(gameObject);
    }
}