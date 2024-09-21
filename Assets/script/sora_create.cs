using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sora_create : MonoBehaviour
{
    public GameObject sora;
    float time;
    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0)) { Time.timeScale = 0; Debug.Log(time); }
        time += Time.deltaTime;*/
        if (time >= 15f)
        {
            GameObject s = Instantiate(sora) as GameObject;
            s.transform.position = new Vector2(1.615723f, 13.87f);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
