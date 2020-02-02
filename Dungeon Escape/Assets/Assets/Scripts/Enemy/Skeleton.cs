using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        if (IsDead == true) return;

        Health -= 1;
        base.anim.SetTrigger("Hit");
        base.isHit = true;
        base.anim.SetBool("InCombat", true);

        if (Health < 1) {
            IsDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            //Destroy(this.gameObject);
        }
    }
}
