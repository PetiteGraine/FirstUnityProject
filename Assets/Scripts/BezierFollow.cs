using System.Collections;
using UnityEngine;

public class BezierFollow : MonoBehaviour
{
    [SerializeField] private Transform[] _routes;
    [SerializeField] private float _speedModifier = 0.2f;
    private int _routeToGo;
    private float _tParam;
    private Vector3 _objectPosition;
    private bool _coroutineAllowed;


    void Start()
    {
        _routeToGo = 0;
        _tParam = 0f;
        _coroutineAllowed = true;
    }

    void Update()
    {
        if (_coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(_routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNum)
    {
        _coroutineAllowed = false;

        Vector3 p0 = _routes[routeNum].GetChild(0).position;
        Vector3 p1 = _routes[routeNum].GetChild(1).position;
        Vector3 p2 = _routes[routeNum].GetChild(2).position;
        Vector3 p3 = _routes[routeNum].GetChild(3).position;

        while (_tParam < 1)
        {
            _tParam += Time.deltaTime * _speedModifier;

            _objectPosition = Mathf.Pow(1 - _tParam, 3) * p0 + 3 * Mathf.Pow(1 - _tParam, 2) * _tParam * p1 + 3 * (1 - _tParam) * Mathf.Pow(_tParam, 2) * p2 + Mathf.Pow(_tParam, 3) * p3;

            transform.position = _objectPosition;
            yield return new WaitForEndOfFrame();
        }

        _tParam = 0f;

        _routeToGo += 1;

        if (_routeToGo > _routes.Length - 1)
        {
            _routeToGo = 0;
        }

        _coroutineAllowed = true;

    }
}