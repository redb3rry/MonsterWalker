using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //config
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 9f;
    [SerializeField] float screenWidthInUnits = 9f;

    //state
    private Touch touch;
    private Vector2 playerPos; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);
        playerPos = new Vector2(transform.position.x, transform.position.y);
        playerPos.x = Mathf.Clamp(GetPositionX(), minX, maxX);
        transform.position = playerPos;
    }
    private float GetPositionX()
    {
        return touch.position.x / Screen.width * screenWidthInUnits;
    }
}
