using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    public IntSO resourceCount, maxCount;
    public DelegateFuncionSO onResourceCollected;

    public TextMeshProUGUI resourceText;

    private void Start()
    {
        ResourceCollected();
    }

    private void ResourceCollected()
    {
        resourceText.text = resourceCount.value.ToString();

        if (maxCount != null)
        {
            resourceText.text += "/" + maxCount.value.ToString();
        }
    }

    private void OnEnable()
    {
        onResourceCollected.onFuncionCalled += ResourceCollected;
    }

    private void OnDisable()
    {
        onResourceCollected.onFuncionCalled -= ResourceCollected;
    }
}
