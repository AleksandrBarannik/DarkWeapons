using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Что-то базовое что можно сделать со всеми предметами
[Serializable]
public abstract class Item
{
    [Tooltip("Id in DataBase")][SerializeField]
    private int _id;
    public int ID => _id;
    
    [Tooltip("Name object(item)")][SerializeField]
    private string _name;
    public string Name => _name;

    [Tooltip("For Scale Item")][SerializeField]
    private Vector3 _scaleElement;
    public Vector3 ScaleElement => _scaleElement;
    
    [Tooltip("Description object(item)")][SerializeField]
    private string _description;
    
    [Tooltip("Maximum items in stack")][SerializeField]
    private int _stackMaxCount = 1;
    public int StackMaxCount => _stackMaxCount;
    
    [Tooltip("now count items in stack")][SerializeField]
    private int _stackCount = 1;
    public int StackCount => _stackCount;

    [SerializeField]
    private Sprite _icon;
    public Sprite Icon => _icon;
    
    [Tooltip("Нужно для смены самого меша")][SerializeField]
    private Mesh _mesh;
    public Mesh Mesh => _mesh;
    
    [Tooltip("Material Item(Object)")][SerializeField]
    private Material _material;
    public Material Material => _material;
    
    

    //Метод когда предмет попадает в инвентарь
    public virtual void OnCollect(){}
    
    //при двойном клике на предмет взаимодействие с ним 
    public virtual void OnInteract(){}
    
    




}
