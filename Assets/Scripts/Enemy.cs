using UnityEngine;
using System.Collections;

public class Enemy : Ship {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Projectile projectile = collider.gameObject.GetComponent<Projectile>();
        if (projectile != null)
        {
            if ((this.tag == "Hostile" && projectile.tag == "FriendlyShot"))
            {
                health -= projectile.damage;
                var renderer = collider.gameObject.GetComponent<Renderer>();
                hitFlash(renderer);
                if (health <= 0)
                {
                    if (this.tag == "Hostile")
                    {
                        EnemyManager.Instance.RemoveEnemy(this);
                    }
                    Destroy(gameObject);
                }
                Destroy(collider.gameObject);

            }
        }
    }
    IEnumerator hitFlash(Renderer renderer)
    {
        renderer.material.color = Color.red;
        yield return new WaitForSeconds(.5f);
        renderer.material.color = Color.white;
    }

}
