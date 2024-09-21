using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sora_con : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {

        Destroy(gameObject, 45);
    }
    void FixedUpdate()
    {
        transform.Translate(0, -0.01f, 0);
    }
}
