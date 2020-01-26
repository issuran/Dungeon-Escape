using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable {

    public int Health { get; set; }
    public GameObject acidEffectPrefab;

    // use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }

    public void Damage()
    {
        Health--;
        if (Health < 1)
        {
            IsDead = true;
            anim.SetTrigger("Death");
            //Destroy(this.gameObject);
        }
    }

    public override void Movement()
    {
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

    public override void Update()
    {
    }
}
