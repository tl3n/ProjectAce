using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject representing a specific artefact type: Mushroom.
/// Inherits from ItemsData to define artefact properties.
/// </summary>
[CreateAssetMenu(menuName = "ArtefactSO/Mushroom")]
public class MushroomArtefact : ItemsData
{
    /// <summary>
    /// Initializes the artefact by creating an instance using the MushroomCreator factory.
    /// </summary>
    private void OnEnable()
    {
        Initialize();
    }

    /// <summary>
    /// Initializes the artefact instance by copying data from a factory-created artefact.
    /// </summary>
    private void Initialize()
    {
        // Create an instance of the MushroomCreator factory
        ArtefactFactory factory = ScriptableObject.CreateInstance<MushroomCreator>();
        // Create an artefact using the factory
        var artifact = factory.CreateArtefact();

        // Copy data from the factory-created artifact to this instance
        this.Name = artifact.Name;
        this.Id = artifact.Id;
        this.Description = artifact.Description;
        this.ItemQuantity = artifact.ItemQuantity;
        this.effects = artifact.effects;
        this.icon = artifact.icon;
        this.prefab = artifact.prefab;
    }
}
