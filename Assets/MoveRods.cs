using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRods : MonoBehaviour {
    public Transform target;
    public float speed;
 
    private void Update() {
        if (target != null) {
            if (Vector3.Distance(transform.position, target.position) > speed * Time.deltaTime) {
                transform.position += Time.deltaTime * speed * (target.transform.position - transform.position).normalized;
            }
            else {
                transform.position = target.position;
            }

        }
    }
}


