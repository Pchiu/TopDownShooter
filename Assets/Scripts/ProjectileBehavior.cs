using UnityEngine;
using System.Collections;

public class ProjectileBehavior : MonoBehaviour {
    public virtual void Action(Transform transform, float speed)
    {
        transform.position += new Vector3(transform.up.x * speed * Time.deltaTime, transform.up.y * speed * Time.deltaTime, 0);
    }
}
