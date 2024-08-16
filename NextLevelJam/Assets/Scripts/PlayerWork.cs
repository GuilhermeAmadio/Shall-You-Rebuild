using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWork : MonoBehaviour
{
    public List<PersonWork> workers = new List<PersonWork>();

    public void FindWorker(Resource resource, Transform workPos, IWorkable workable)
    {
        foreach (PersonWork worker in workers)
        {
            if (worker.resource.type == resource.type)
            {
                if (!worker.IsWorking())
                {
                    worker.Work(workPos, workable);
                    workable.AddWorker(worker);
                }
            }
        }
    }

    public bool UseAllWorkersOfType(Resource resource, Transform workPos, IWorkable workable)
    {
        bool returnSomething = false;

        foreach (PersonWork worker in workers)
        {
            if (worker.resource.type == resource.type)
            {
                if (!worker.IsWorking())
                {
                    worker.Work(workPos, workable);
                    workable.AddWorker(worker);

                    returnSomething = true;
                }
            }
        }

        return returnSomething;
    }

    public PersonWork RestWorker(Resource resource, Transform restPos)
    {
        foreach (PersonWork worker in workers)
        {
            if (worker.resource.type == resource.type)
            {
                worker.Rest(restPos);
                RemoveWorker(worker);

                return worker;
            }
        }

        return null;
    }

    public void AddWorker(PersonWork worker)
    {
        workers.Add(worker);
    }

    public void RemoveWorker(PersonWork worker)
    {
        workers.Remove(worker);
    }
}
