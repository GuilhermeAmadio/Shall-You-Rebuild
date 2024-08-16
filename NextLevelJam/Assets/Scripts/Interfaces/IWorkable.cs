using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkable
{
    public void AddWorker(PersonWork worker);
    public void StartWork();
    public void StopWork();
}
