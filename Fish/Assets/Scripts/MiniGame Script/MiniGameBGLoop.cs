using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameBGLoop : MonoBehaviour
{
    public float loopSpeed;
    public Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(loopSpeed * Time.deltaTime, 0f);
    }
}
