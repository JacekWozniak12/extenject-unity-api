[System.Serializable]
public struct FoodType
{
    string _name;

    public FoodType(string name)
    {
        _name = name;
    }

    public override string ToString() => _name;
    public static implicit operator string(FoodType a) => a._name;
}