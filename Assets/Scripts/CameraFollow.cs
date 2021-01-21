using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform targetToFollow;
    public float mapAxisX;
    public float mapAxisXMinus;
    public float mapAxisY;
    public float mapAxisYMinus;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, mapAxisXMinus, mapAxisX),
                                            Mathf.Clamp(targetToFollow.position.y, mapAxisYMinus, mapAxisY),
                                            transform.position.z);

    }
}
