using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceLabel : MonoBehaviour
{
    private string labelText = "Default";
    public float heightAboveObject = 2f;
    public float scale = 0.01f;

    private Camera cam;
    private TextMeshProUGUI tmp;
    private Transform labelCanvas;

    void Awake()
    {
        cam = Camera.main;

        GameObject canvasObj = CreateCanvas();
        CreateTextMeshPro(canvasObj);
    }

    void LateUpdate()
    {
        if (cam != null && labelCanvas != null)
        {
            Vector3 lookPos = cam.transform.position;
            lookPos.y = labelCanvas.position.y;
            labelCanvas.LookAt(lookPos);
            labelCanvas.Rotate(0, 180, 0);
        }
    }

    public void SetLabel(string newText)
    {
        if (tmp != null)
            tmp.text = newText;
    }

    private GameObject CreateCanvas()
    {
        GameObject canvasObj = new GameObject("LabelCanvas");
        canvasObj.transform.SetParent(transform, false);
        canvasObj.transform.localPosition = new Vector3(0, heightAboveObject, 0);
        canvasObj.transform.localRotation = Quaternion.identity;
        canvasObj.transform.localScale = Vector3.one * scale;

        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.WorldSpace;

        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        return canvasObj;
    }

    private void CreateTextMeshPro(GameObject canvasObj)
    {
        GameObject textObj = new GameObject("LabelText");
        textObj.transform.SetParent(canvasObj.transform, false);

        tmp = textObj.AddComponent<TextMeshProUGUI>();
        tmp.text = labelText;
        tmp.fontSize = 30;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = Color.white;

        RectTransform rect = tmp.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(500, 200);

        labelCanvas = canvasObj.transform;
    }
}
