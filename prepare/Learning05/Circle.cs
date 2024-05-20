class Circle : Shape
{
    private double _radius;
    public Circle(int color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}