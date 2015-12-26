using UnityEngine;
using System.Collections;

public class SplitShot : ProjectileBehavior {
    public float splitDelay;
    public float elapsedDelay;
    public Projectile submunition;
    public override void Action(Transform projectile, float speed)
    {
        base.Action(projectile, speed);
        if (elapsedDelay >= splitDelay)
        {
            Instantiate(submunition, projectile.position, projectile.rotation);
            elapsedDelay = 0;
        }
        elapsedDelay += Time.deltaTime;
    }
}
