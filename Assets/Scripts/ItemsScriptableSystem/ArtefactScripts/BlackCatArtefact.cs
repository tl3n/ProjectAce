using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ScriptableObject representing a specific artefact type: Black Cat.
/// Inherits from ItemsData to define artefact properties.
/// </summary>
[CreateAssetMenu(menuName = "ArtefactSO/Black Cat")]
public class BlackCatArtefact : ItemsData
{
    /// <summary>
    /// Initializes the artefact by creating an instance using the BlackCatCreator factory.
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
        // Create an instance of the BlackCatCreator factory
        ArtefactFactory factory = ScriptableObject.CreateInstance<BlackCatCreator>();
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
