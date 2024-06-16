using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract base class for creating artefact instances.
/// Extend this class to define specific artefact factories.
/// </summary>
public abstract class ArtefactFactory : ScriptableObject
{
    /// <summary>
    /// Creates and returns a new artefact instance.
    /// </summary>
    /// <returns>The created artefact instance.</returns>
    public abstract ItemsData CreateArtefact();
}
