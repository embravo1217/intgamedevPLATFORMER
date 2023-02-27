using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private float xAxis, yAxis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void Update()
    {
        transform.position = new Vector3(Player.transform.position.x + xAxis, Player.transform.position.y + yAxis);
    }
}
