using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    public void OnDamage(int damage, Vector3 hitposition, Vector3 direction,Transform playerPosition);
   
}
