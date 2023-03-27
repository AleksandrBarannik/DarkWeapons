using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Что-то базовое что можно сделать со всеми предметами
[Serializable]
public abstract class Item
{
    private string _name;
    private string _description;
    
    [Tooltip("Максимум предметов в пачке")][SerializeField]
    private int _stackMaxCount = 1;
    public int StackMaxCount => _stackMaxCount;
    
    [Tooltip("Сейчас предметов в пачке")][SerializeField]
    private int _stackCount = 1;
    public int StackCount => _stackCount;

    [SerializeField]
    private Sprite _icon;
    public Sprite Icon => _icon;
    
    [SerializeField]
    private MeshRenderer _meshRenderer;
    public MeshRenderer MeshRenderer => _meshRenderer;

    [SerializeField]
    private Material _material;
    public Material Material => _material;

    [SerializeField]
    private int _id;

    public int ID => _id;


    //Метод когда предмет попадает в инвентарь
    public virtual void OnCollect(){}
    
    //при двойном клике на предмет взаимодействие с ним 
    public virtual void OnInteract(){}
    
    




}
