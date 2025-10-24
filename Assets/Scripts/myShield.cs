using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myShield : MonoBehaviour
{
    // Start is called before the first frame update
    public float duration = 1f;
    public GameObject obj;
    private Material material;
    public AnimationCurve curve;
    private float timer;
    private Coroutine coroutine;

    public void Start()
    {       
        Renderer renderer = obj.GetComponent<Renderer>();
        material = renderer.material;
    }

    public void StartHide()
    {
        timer = 0;
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Hide());
        }
    }

    public void StartShow()
    {
        timer = 0;
        if (coroutine == null)
        {
            coroutine = StartCoroutine(Show());
        }
    }

    IEnumerator Hide()
    {
        while (true)
        {
            timer += Time.deltaTime;
            float t = curve.Evaluate(1 - Mathf.Clamp01(timer / duration));
            if (t > 0)
            {
                material.SetFloat("_DissolveThreshold", t);
                Debug.Log(t);
            }
            else
            {
                StopCoroutine(Hide());
                coroutine = null;
            }
            yield return new WaitForSeconds(0.02f);
        } 
    }

    IEnumerator Show()
    {
        while (true)
        {
            timer += Time.deltaTime;
            float t = curve.Evaluate(Mathf.Clamp01(timer / duration));
            if (t < 1)
            {
                material.SetFloat("_DissolveThreshold", t);
                Debug.Log(t);
            }
            else
            {
                StopCoroutine(Show());
                coroutine = null;
            }
            yield return new WaitForSeconds(0.02f);
        }
    }
}
