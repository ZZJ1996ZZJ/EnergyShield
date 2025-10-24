using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowShield : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 1f;
    public GameObject obj;
    private Material material;
    public AnimationCurve curve;
    private float timer;
    private bool isRunning;
    private Button button;

    public void Start()
    {
        timer = 0;
        isRunning = false;
        button = GetComponent<Button>();
        button.onClick.AddListener(Show);
        Renderer renderer = obj.GetComponent<Renderer>();
        material = renderer.material;
    }

    public void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            float t = curve.Evaluate(Mathf.Clamp01(timer / duration));
            material.SetFloat("_DissolveThreshold", t);
            Debug.Log(t);
            
            if(t == 1)
            {
                timer = 0;
                isRunning = false;
            }
           
        }
    }

    public void Show()
    {
        isRunning = true;         
    }    
}
