using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMesh : MonoBehaviour {

    public GameObject _Mesh01;
    public GameObject _Mesh02;
    public GameObject _Mesh03;
    public GameObject _Mesh04;


    public void Start()
    {
        Mesh01();
    }

    public void Mesh01()
    {

        _Mesh01.SetActive(true);
        _Mesh02.SetActive(false);
        _Mesh03.SetActive(false);
        _Mesh04.SetActive(false);

    }

    public void Mesh02()
    {

        _Mesh01.SetActive(false);
        _Mesh02.SetActive(true);
        _Mesh03.SetActive(false);
        _Mesh04.SetActive(false);

    }

    public void Mesh03()
    {

        _Mesh01.SetActive(false);
        _Mesh02.SetActive(false);
        _Mesh03.SetActive(true);
        _Mesh04.SetActive(false);

    }

    public void Mesh04()
    {

        _Mesh01.SetActive(false);
        _Mesh02.SetActive(false);
        _Mesh03.SetActive(false);
        _Mesh04.SetActive(true);

    }
}
