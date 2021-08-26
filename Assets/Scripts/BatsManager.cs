﻿using DG.Tweening;
using UnityEngine;

public class BatsManager : MonoBehaviour
{
    [SerializeField] private GameObject bats;
    [SerializeField] private GameObject target;
    [SerializeField] private float rotationSpeed;
    private ParticleSystem batsParticleSystem;
    private bool rotateAroundBool;

    private void Start()
    {
        batsParticleSystem = bats.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (rotateAroundBool)
            bats.transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Boat"))
        {
            bats.transform.DOMove(target.transform.position, 1);
            batsParticleSystem.Play();
            bats.GetComponent<AudioSource>().DOFade(1, 2);
            bats.GetComponent<AudioSource>().Play();
            MoveBats();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name.Equals("Boat"))
        {
            rotateAroundBool = false;
            batsParticleSystem.Stop();
            bats.GetComponent<AudioSource>().DOFade(0, 2).OnComplete(StopAudio);
        }
    }

    private void MoveBats()
    {
        rotateAroundBool = true;
    }

    private void StopAudio()
    {
        bats.GetComponent<AudioSource>().Pause();
    }
}