using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    #region Singleton
    public static cameraController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private float speed = 100f;
    private float cameraBorderLimit = 10f;
    public Vector2 panLimit;
    public bool canScroll = true;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - cameraBorderLimit) pos.z += speed * Time.deltaTime;
        if (Input.mousePosition.y <= cameraBorderLimit) pos.z -= speed * Time.deltaTime;
        if (Input.mousePosition.x >= Screen.width - cameraBorderLimit) pos.x += speed * Time.deltaTime;
        if (Input.mousePosition.x <= cameraBorderLimit) pos.x -= speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);
        
        if (canScroll)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= scroll * speed * 100f * Time.deltaTime;
        }

        transform.position = pos;
    }
}
