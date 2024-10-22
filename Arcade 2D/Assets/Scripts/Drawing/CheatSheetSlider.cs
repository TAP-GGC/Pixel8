using UnityEngine;
using UnityEngine.UI;

public class CheatSheetSlider : MonoBehaviour
{
    public RectTransform cheatSheetPanel; 
    public Button cheatSheetToggle;      

    private Vector2 hiddenPosition;       
    private Vector2 visiblePosition;      
    private float slideSpeed = 500f;      

    private bool isVisible = true;        
    private bool isSliding = false;       

    void Start()
    {
        // Set positions
        visiblePosition = cheatSheetPanel.anchoredPosition; 
        hiddenPosition = new Vector2(visiblePosition.x + 500, visiblePosition.y);

        
        cheatSheetPanel.anchoredPosition = hiddenPosition;
        
        // Add listener to toggle the cheat sheet
        cheatSheetToggle.onClick.AddListener(OnToggleCheatSheet);
    }

    void Update()
    {
        // Animate the panel sliding
        if (isSliding)
        {
            if (isVisible)
            {
                // Slide out (hide)
                cheatSheetPanel.anchoredPosition = Vector2.MoveTowards(cheatSheetPanel.anchoredPosition, hiddenPosition, slideSpeed * Time.deltaTime);
                if (cheatSheetPanel.anchoredPosition == hiddenPosition)
                {
                    isSliding = false; // Stop sliding when reached the hidden position
                }
            }
            else
            {
                // Slide in (show)
                cheatSheetPanel.anchoredPosition = Vector2.MoveTowards(cheatSheetPanel.anchoredPosition, visiblePosition, slideSpeed * Time.deltaTime);
                if (cheatSheetPanel.anchoredPosition == visiblePosition)
                {
                    isSliding = false; // Stop sliding when reached the visible position
                }
            }
        }
    }

    // Toggles the cheat sheet visibility and starts sliding animation
    void OnToggleCheatSheet()
    {
        if (!isSliding) // Prevent toggling while already sliding
        {
            isVisible = !isVisible; // Toggle the visibility state
            isSliding = true; // Start sliding animation
        }
    }
}
