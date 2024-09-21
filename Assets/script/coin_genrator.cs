using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin_genrator : MonoBehaviour
{
    public GameObject coin;
    float spawn_time;
    float r_heigth;
    bool play = false;
    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (spawn_time >= 5)
            {
                GameObject c = Instantiate(coin) as GameObject;
                r_heigth = Random.Range(-4, 4);
                c.transform.position = new Vector2(0, r_heigth);
                Destroy(c, 3f);
                spawn_time = 0;
            }
            spawn_time += Time.deltaTime;
        }
    }
    public void restart_coin()
    {
        spawn_time = 0;
        play = true;
    }
    public void d_coin() { play = false; }
}
