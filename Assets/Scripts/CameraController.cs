using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform playerTransform;
	private float cameraDisplacement;
	private Vector3 newPosition;

    // Start is called before the first frame update
    void Start()
    {
       	cameraDisplacement = playerTransform.position.y - transform.position.y;
	}
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, playerTransform.position.y - cameraDisplacement, -11);
    }
}
