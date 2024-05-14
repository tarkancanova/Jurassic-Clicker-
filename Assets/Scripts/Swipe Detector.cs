using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 currentSwipe;
    private bool isSwiping = false;
    public float minSwipeDistance = 50f;
    [SerializeField] private Overdose _overdose;
    public float maxReductionFactor = 1f;

    void Update()
    {
        SwipeDetection();
    }

    private void CalmAnimal(float reductionFactor)
    {
        float stressReduction = reductionFactor;
        _overdose.UpdateOverdose(-stressReduction);
        _overdose.UpdateOverdoseBar();
    }

    private void SwipeDetection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray mouseClick = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseClick, out hit))
            {
                if (hit.collider.CompareTag("Dino"))
                {
                    startPosition = Input.mousePosition;
                    isSwiping = true;
                }
            }
        }

        if (isSwiping)
        {
            currentSwipe = (Vector2)Input.mousePosition - startPosition;

            if (currentSwipe.magnitude > minSwipeDistance)
            {

                float reductionFactor = Mathf.Clamp01(currentSwipe.magnitude / minSwipeDistance) * maxReductionFactor;

                if (currentSwipe.x > 0)
                {
                    Debug.Log("Swipe Right");
                    CalmAnimal(reductionFactor);
                }
                else
                {
                    Debug.Log("Swipe Left");
                    CalmAnimal(reductionFactor);
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSwiping = false;
        }
    }
}
