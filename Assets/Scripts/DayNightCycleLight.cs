using UnityEngine;

public class DayLight : MonoBehaviour
{
    [SerializeField] private Light _dayLight;
    public float dayLengthInSecs = 60f;
    private float _currentTime = 0;
    private bool _isCycleComplete = false;

    void Start()
    {
        _currentTime = dayLengthInSecs / 2;
    }
    void Update()
    {

        LightUpdate();
        if (_currentTime >= dayLengthInSecs || _currentTime <= 0) NextCycle();
        _dayLight.intensity = _currentTime / dayLengthInSecs * 2;
    }

    void LightUpdate()
    {
        if (!_isCycleComplete) _currentTime += Time.deltaTime;
        else _currentTime -= Time.deltaTime;
    }

    void NextCycle()
    {
        _isCycleComplete = !_isCycleComplete;
    }
}
