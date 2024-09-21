using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START : MonoBehaviour
{
    public GameObject chara;
    public GameObject coing;
    public GameObject birdg;
    public GameObject resu;

    public void res_start()
    {
        Time.timeScale = 1;
        chara.GetComponent<character>().reset_chara();
        birdg.GetComponent<bird_generator>().restart_bird();
        coing.GetComponent<coin_genrator>().restart_coin();
        resu.GetComponent<result_d>().restart_res();
        gameObject.SetActive(false);
    }

}
