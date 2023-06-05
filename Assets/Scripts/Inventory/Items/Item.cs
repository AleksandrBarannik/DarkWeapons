using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Что-то базовое что можно сделать со всеми предметами
[Serializable]
public  class Item
{
    [Tooltip("Id in DataBase")][SerializeField]
    protected int _id;
    public int ID => _id;
    
    [Tooltip("Name object(item)")][SerializeField]
    protected string _name;
    public string Name => _name;

    [Tooltip("For Scale Item")][SerializeField]
    protected Vector3 _scaleElement;
    public Vector3 ScaleElement => _scaleElement;
    
    [SerializeField][Tooltip("For Scale ColiderItem")]
    protected Vector3 _colliderSize;
    public Vector3 ColliderSize => _colliderSize;
    
    [SerializeField][Tooltip("Выбор центра для предмета (для мечей и тд  он не нулевой)")]
    protected Vector3 _colliderCenter;
    public Vector3 ColliderCenter => _colliderCenter;
    
    [Tooltip("Description object(item)")][SerializeField]
    protected string _description;
    
    [Tooltip("Maximum items in stack")][SerializeField]
    protected int _stackMaxCount = 1;
    public int StackMaxCount => _stackMaxCount;
    
    [Tooltip("now count items in stack")][SerializeField]
    protected int _stackCount = 1;
    public int StackCount
    {
        get { return _stackCount; }
        set
        {
            _stackCount = value;
            if (0 > _stackCount || _stackCount > _stackMaxCount)
                throw new ArgumentException();
        }
    }

    [SerializeField]
    protected Sprite _icon;
    public Sprite Icon => _icon;
    
    [Tooltip("Нужно для смены самого меша")][SerializeField]
    protected Mesh _mesh;
    public Mesh Mesh => _mesh;
    
    [Tooltip("Material Item(Object)")][SerializeField]
    protected Material _material;
    public Material Material => _material;
    
    

    //Метод когда предмет попадает в инвентарь
    public virtual void OnCollect(){}
    
    //при двойном клике на предмет взаимодействие с ним 
    public virtual void OnInteract(){}

    public virtual Item Copy()
    {
        throw  new  NotImplementedException();
        
    }


}
