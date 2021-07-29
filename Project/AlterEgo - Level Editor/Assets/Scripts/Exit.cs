using UnityEngine;

public class Exit : MonoBehaviour {

    [SerializeField] KeyCode touchedesortie;
    private void Update()
    {
        if (Input.GetKeyDown(touchedesortie)) EXIT();
    }


    public void EXIT () 
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
