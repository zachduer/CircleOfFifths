using UnityEngine;
using UnityEngine.UI;

public class RuneDisplayController : MonoBehaviour
{
    public RuneInterfaceController runeInterfaceController;

    Image runeImage;

    private void Awake()
    {
        runeImage = GetComponent<Image>();
        runeInterfaceController.OnRuneSubmitted += ShowRune;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutRune();
    }

    public void ShowRune()
    {
        //runeImage.enabled = true;
        runeImage.color = new Color(1, 1, 1, 1);
    }

    public void FadeOutRune()
    {
        Color tempColor = runeImage.color;
        tempColor.a -= 0.001f;
        runeImage.color = tempColor;
    }
}
