using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public GameObject deathObject;

    public void destroy_self() {
        Instantiate(deathObject, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        Destroy(gameObject);
    }
}
