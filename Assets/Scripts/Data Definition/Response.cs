[System.Serializable]
public struct Response
{
    public Dish Dish;
    public string Error;

    public Response(string e)
    {
        Dish = null;
        Error = e;
    }

    public Response(Dish d)
    {
        Error = null;
        Dish = d;
    }
}