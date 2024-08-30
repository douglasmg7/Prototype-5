using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Rigidbody targetRb;
    private float minForce = 12;
    private float maxForce = 17;
    private float maxTorque = 10;
    private float xRange = 4f;
    private float ySpawnPosition = -4;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForece(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    private void OnMouseDown() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }

    private Vector3 RandomForece(){
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private Vector3 RandomTorque(){
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }

    private Vector3 RandomSpawnPosition() {
        return new Vector3(Random.Range(-xRange ,xRange), ySpawnPosition);
    }
}
