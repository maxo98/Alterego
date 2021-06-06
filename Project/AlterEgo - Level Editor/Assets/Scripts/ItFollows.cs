using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItFollows : MonoBehaviour
{
    [SerializeField] private MousePosition mouse;
    private Vector3 scaleChange, xScaleChange, yScaleChange, zScaleChange;
    private Quaternion rotateChange;
    public KeyCode mykey;



    private void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MousePosition>();
        scaleChange = new Vector3(0.02f, 0.02f, 0.02f);
        xScaleChange = new Vector3(0.02f, 0, 0);
        yScaleChange = new Vector3(0, 0.02f, 0);
        zScaleChange = new Vector3(0, 0, 0.02f);
        rotateChange = new Quaternion(0, 45, 0, 2);
    }
    void Update()
    {
        transform.position = mouse.position;



        if (objectMode.instance.scale)
        {
            if (objectMode.instance.xToggle.isOn)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.transform.localScale += xScaleChange;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.transform.localScale -= xScaleChange;
                }
            }
            else if (objectMode.instance.yToggle.isOn)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.transform.localScale += yScaleChange;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.transform.localScale -= yScaleChange;
                }
            }

            else if (objectMode.instance.zToggle.isOn)
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.transform.localScale += zScaleChange;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.transform.localScale -= zScaleChange;
                }
            }
            else
            {
                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    this.transform.localScale += scaleChange;
                }
                else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    this.transform.localScale -= scaleChange;
                }
            }

        }
        if (objectMode.instance.rotate)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                this.transform.localRotation *= rotateChange;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                Quaternion temp = Quaternion.Inverse(rotateChange);
                this.transform.localRotation *= temp;
            }
        }

    }
}
