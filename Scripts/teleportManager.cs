using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportManager : MonoBehaviour
{
    public Transform playerRoom;
    public Material skyboxMat;

    public void teleportToJumpPad(Transform jumpPad)
    {
        playerRoom.transform.position = jumpPad.position;
    }

    public void changeSkybox(Texture skyboxTex)
    {
        skyboxMat.SetTexture("_Tex", skyboxTex);
    }
}
