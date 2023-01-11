using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = UnityEngine.Object;

public class DeleteObject : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(6);
        Object.Destroy(this.gameObject);
    }
}
