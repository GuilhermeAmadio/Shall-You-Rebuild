using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHit : MonoBehaviour
{
    public FuncionCalled onCharDamaged;
    public Material flashMaterial;
    private Material defaultMaterial;
    public SpawnSprite spawnSprite;

    private void OnEnable()
    {
        onCharDamaged.onFuncionCalled += Flash;
    }

    private void OnDisable()
    {
        onCharDamaged.onFuncionCalled -= Flash;
    }

    public void Flash()
    {
        defaultMaterial = spawnSprite.newSR.material;

        StartCoroutine(Flashing());
    }

    private IEnumerator Flashing()
    {
        spawnSprite.newSR.material = flashMaterial;

        yield return new WaitForSeconds(0.2f);

        spawnSprite.newSR.material = defaultMaterial;
    }
}
