using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    GameObject player;
    Vector3 offset;

    bool follow;

    private void Start()
    {
        offset = new Vector3(0, 0, -5);
        player = GameObject.FindGameObjectWithTag("Player");

        follow = true;
    }

    // Update is called once per frame
    void LateUpdate () {
        if(follow)
            gameObject.transform.position = player.GetComponent<MovementController>().GetTransform().position + offset;
	}

    public void setFollow(bool b) {
        follow = b;
    }
}
