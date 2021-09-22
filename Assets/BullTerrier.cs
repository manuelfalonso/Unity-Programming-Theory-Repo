using UnityEngine;

// INHERITANCE
public class BullTerrier : Dog
{
    private AudioSource bark;

    // POLYMORPHISM
    public override void Attack()
    {
        base.Attack();
        bark = GetComponent<AudioSource>();
        bark.PlayDelayed(.5f);
    }
}
