using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenController : MonoBehaviour
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
        
    }
}
