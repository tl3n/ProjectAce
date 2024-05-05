using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridComponent
{
    /// <summary>
    /// Returns name of the grid components
    /// </summary>
    /// <returns>Name of the leaf or list of the components</returns>
    public string GetName();

    /// <summary>
    /// Add component into the list if current is not leaf
    /// </summary>
    /// <param name="component">Grid component</param>
    public void Add(IGridComponent component);

    /// <summary>
    /// Remove component from the list if current is not leaf
    /// </summary>
    /// <param name="component">Grid component</param>
    public void Remove(IGridComponent component);

    /// <summary>
    /// Check if component is composite
    /// </summary>
    /// <returns>True if it is otherwise false</returns>
    public bool IsComposite();

    /// <summary>
    /// Change state of the components
    /// </summary>
    /// <param name="state">State to which it will be changed</param>
    public void SetActive(bool state);
}
