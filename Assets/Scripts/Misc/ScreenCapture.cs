using System.Collections;
using System.IO;
using UnityEngine;

public class ScreenCapture : MonoBehaviour
{
    [SerializeField] private string screenshotDirectory = "Screenshots";
    [SerializeField] private KeyCode screenshotKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(screenshotKey))
        {
            StartCoroutine(TakeScreenshot());
        }
    }

    private IEnumerator TakeScreenshot()
    {
        // Espera un frame para asegurarse de que se ha renderizado todo
        yield return new WaitForEndOfFrame();

        // Crea el directorio si no existe
        string directory = Path.Combine(Application.dataPath, screenshotDirectory);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        // Toma la captura de pantalla
        string filename = Path.Combine(directory, "screenshot.png");
        Texture2D screenshot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        screenshot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenshot.Apply();

        // Guarda la captura de pantalla en disco
        byte[] bytes = screenshot.EncodeToPNG();
        File.WriteAllBytes(filename, bytes);

        // Abre la carpeta de la captura de pantalla
        Application.OpenURL(directory);
    }
}
