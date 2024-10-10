using UnityEngine;
using UnityEngine.UI;

public class cheat : MonoBehaviour
{
    public RectTransform cheatSheetPanel;
    public Toggle cheatSheetToggle;

    private Vector2 hiddenPosition;
    private Vector2 visiblePosition;
    private float slideSpeed = 500f;

    private bool isVisible = false;

    void Start()
    {
        // Set positions
        visiblePosition = cheatSheetPanel.anchoredPosition; // The position when visible
        hiddenPosition = new Vector2(visiblePosition.x + 350, visiblePosition.y); // Off-screen position

        // Initially set the cheat sheet off-screen
        cheatSheetPanel.anchoredPosition = hiddenPosition;

        // Add listener to toggle the cheat sheet
        cheatSheetToggle.onValueChanged.AddListener(OnToggleCheatSheet);
    }

    void Update()
    {
        // slide animation
        if (isVisible)
        {
            cheatSheetPanel.anchoredPosition = Vector2.MoveTowards(cheatSheetPanel.anchoredPosition, visiblePosition, slideSpeed * Time.deltaTime);
        }
        else
        {
            cheatSheetPanel.anchoredPosition = Vector2.MoveTowards(cheatSheetPanel.anchoredPosition, hiddenPosition, slideSpeed * Time.deltaTime);
        }
    }

    // Toggles the cheat sheet visibility
    void OnToggleCheatSheet(bool isOn)
    {
        isVisible = isOn;
    }
}