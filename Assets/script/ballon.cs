using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballon : MonoBehaviour
{
    public GameObject chara;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bird")
        {
            chara.GetComponent<character>().chara_death();
        }
    }
}
