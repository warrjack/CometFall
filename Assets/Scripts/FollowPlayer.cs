using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

	public GameObject player;
	private float zPos;
    // Start is called before the first frame update
    void Start()
    {
    	zPos = -11.24f;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, zPos);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, player.transform.rotation.z));
    }
}
