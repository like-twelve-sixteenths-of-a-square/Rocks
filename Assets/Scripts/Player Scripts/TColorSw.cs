using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TColorSw : MonoBehaviour
{
    public Material[] colors;

    public MeshRenderer mr;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    IEnumerator SwappoColore()
    {
        int chooseColore = Random.Range(0, colors.Length);
        yield return new WaitForSeconds(0.2f);
        mr.materials[1] = colors[chooseColore];
    }
}
