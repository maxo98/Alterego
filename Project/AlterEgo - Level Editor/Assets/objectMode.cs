using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectMode : MonoBehaviour
{
    #region Singleton
    public static objectMode instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

    }
    #endregion

    public bool rotate, scale = false;
    public Toggle rotToggle, scaToggle, zoomToggle, xToggle, yToggle, zToggle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (rotate || scale)
        {
            cameraController.instance.canScroll = false;
            zoomToggle.isOn = false;
        }
        else
        {
            cameraController.instance.canScroll = true;
            zoomToggle.isOn = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scale = !scale;
            scaToggle.isOn = !scaToggle.isOn;
            rotate = false;
            rotToggle.isOn = false;

        }

        if (scale)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (!xToggle.isOn)
                {
                    allScaleOff();
                    xToggle.isOn = true;
                }
                else
                {
                    allScaleOff();
                }
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!yToggle.isOn)
                {
                    allScaleOff();
                    yToggle.isOn = true;
                }
                else
                {
                    allScaleOff();
                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!zToggle.isOn)
                {
                    allScaleOff();
                    zToggle.isOn = true;
                }
                else
                {
                    allScaleOff();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rotate = !rotate;
            rotToggle.isOn = !rotToggle.isOn;
            scaToggle.isOn = false;
            scale = false;
        }


    }

    private void allScaleOn()
    {
        xToggle.isOn = true;
        yToggle.isOn = true;
        zToggle.isOn = true;
    }

    private void allScaleOff()
    {
        xToggle.isOn = false;
        yToggle.isOn = false;
        zToggle.isOn = false;
    }

    public void switchEnable()
    {
        xToggle.gameObject.SetActive(scale);
        yToggle.gameObject.SetActive(scale);
        zToggle.gameObject.SetActive(scale);
    }

}
