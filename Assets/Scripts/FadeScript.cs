using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    //We devrease the opacity of the object and destroy it when it is 0
    void FixedUpdate()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color.a > 0) gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.1f);
        else Destroy(gameObject);
    }
}
