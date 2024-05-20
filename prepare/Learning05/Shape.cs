abstract class Shape
{
    private int _color;

    public Shape(int color)
    {
        _color = color;
    }
    public int GetColor()
    {
        return _color;
    }
    public void setColor(int color)
    {
        _color = color;
    }

    public abstract double GetArea();
}