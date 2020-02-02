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
        if (IsDead == true) return;

        Health--;
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
    }

    public void Attack()
    {
        Instantiate(acidEffectPrefab, transform.position, Quaternion.identity);
    }

    public override void Update()
    {
    }
}
