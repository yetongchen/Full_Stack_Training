using System.Runtime.Intrinsics.X86;

namespace Assignment03;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    // Constructors
    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }
    public Color(int red, int green, int blue)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = 255;
    }

    // Getters and setters
    public int GetRed()
    {
        return red;
    }
    public void setRed(int red)
    {
        this.red = red;
    }
    public int getGreen()
    {
        return green;
    }
    public void setGreen(int green)
    {
        this.green = green;
    }
    public int getBlue()
    {
        return blue;
    }
    public void setBlue(int blue)
    {
        this.blue = blue;
    }
    public int GetAlpha() {
        return alpha;
    }
    public void SetAlpha(int alpha) {
        this.alpha = alpha;
    }

    // Method to get the grayscale value
    public int GetGrayscale()
    {
        return (red + green + blue) / 3;
    }
}

public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    // Constructor
    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    // Getters and setters
    public int GetSize()
    {
        return size;
    }
    public void SetSize(int size)
    {
        this.size = size;
    }
    public void Pop()
    {
        size = 0;
    }

    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
        }
    }

    public int GetThrowCount()
    {
        return throwCount;
    }
}
