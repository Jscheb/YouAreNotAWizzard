using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaCharacterChange : MonoBehaviour
{
    private RawImage charImage;

    void Start()
    {
        charImage = GetComponent<RawImage>();

    }

    // Update is called once per frame
    public void setNewCharImage(Texture texture)
    {
        charImage.texture = texture;
    }
}
