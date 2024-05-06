class Fraction 
{
    private int _top;
    private int _bottom;

    public Fraction() 
    {
        _top = 1;
        _bottom = 1;
    }
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
    /*
    better way:
    public Fraction(int top = 1, int bottom = 1)
    {
        _top = top;
        _bottom = bottom;
    }
    */

    int GetTop() 
    {
        return _top;
    }
    void SetTop(int top)
    {
        _top = top;
    }
    int GetBottom()
    {
        return _bottom;
    }
    void setBottom(int bottom)
    {
        _bottom = bottom;
    }

    string GetFractionalString()
    {
        return $"{_top}/{_bottom}";
    }
    double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}