using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O3 : MonoBehaviour
{
    public GameObject chara;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bird")
        {
            Destroy(collision.gameObject);
            chara.GetComponent<character>().char_point();
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
        }
        else
        {
            chara.GetComponent<character>().char_point_minus();
            PlayerPrefs.SetInt("bird", PlayerPrefs.GetInt("bird") + 1);
        }
    }
}
