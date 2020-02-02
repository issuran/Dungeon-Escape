using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable {
    
    public int Health { get; set; }

    // use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        if (IsDead == true) return;

        Health -= 1;
        base.anim.SetTrigger("Hit");
        base.isHit = true;
        base.anim.SetBool("InCombat", true);

        if (Health < 1)
        {
            IsDead = true;
            anim.SetTrigger("Death");
            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
            //Destroy(this.gameObject);
        }
    }

    public override void Movement()
    {
        base.Movement();
    }
}
