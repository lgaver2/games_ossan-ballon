using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void key(float k)
    {
        this.rigid = GetComponent<Rigidbody2D>();
        this.rigid.AddForce(transform.right * 100*-k);
        transform.localScale = new Vector2(k * 0.1f, 0.1f);    
    }
}
