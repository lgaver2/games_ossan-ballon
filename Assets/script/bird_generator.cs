using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_generator : MonoBehaviour
{
    public GameObject birds;
    float l;
    float spawn_time;
    float r_heigth, r_sens;
    bool play;
    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (spawn_time >= (3f - l))
            {
                GameObject b = Instantiate(birds) as GameObject;
                r_sens = Random.Range(0, 2);
                r_heigth = Random.Range(-4, 5);
                b.transform.position = new Vector2(int2bool(r_sens) * 4, r_heigth);
                b.GetComponent<bird>().key(int2bool(r_sens));
                Destroy(b, 4f);
                spawn_time = 0;
            }
            spawn_time += Time.deltaTime;
        }
        
    }

    float int2bool(float num)
    {
        if (num == 0) return 1;
        else return -1;
    }

    public void lvl(int lv)
    {
        switch (lv)
        {
            case 1:
                l = 0;
                break;
            case 2:
                l = 0.5f;
                break;
            case 3:
                l = 1;
                break;
            case 4:
                l = 1.5f;
                break;
            case 5:
                l = 2f;
                break;
        }
    }
    public void restart_bird()
    {
        spawn_time = 0;
        l = 0;
        play = true;
    }
    public void d_bird() { play = false; }
}
