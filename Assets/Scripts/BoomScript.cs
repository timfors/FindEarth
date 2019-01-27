using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    public GameObject createExploid;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "arm")
        {
            GameObject exp = Instantiate(createExploid, transform.position, Quaternion.identity);
            exp.transform.localScale = new Vector3(0.2f, 0.3f, 0.1f);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Destroy(gameObject);
        }
    }
}
