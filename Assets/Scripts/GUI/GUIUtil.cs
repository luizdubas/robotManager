using UnityEngine;
using System.Collections;

public class GUIUtil : MonoBehaviour {

	public static Texture2D getBlackTexture(){
		Texture2D texture = new Texture2D(128, 128);

        for (int y = 0; y < texture.height; ++y)
        {
            for (int x = 0; x < texture.width; ++x)
            {
                Color color = new Color(0, 0, 0);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
		return texture;
	}
}
