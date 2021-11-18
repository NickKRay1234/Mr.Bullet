using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D target) 
    {
        if(target.gameObject.tag == "Box")
        {
            Destroy(target.gameObject);
        }
    }
}
