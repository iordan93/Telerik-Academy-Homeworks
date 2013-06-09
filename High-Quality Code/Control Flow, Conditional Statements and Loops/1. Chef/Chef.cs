using System;

public class Chef
{
    public Chef()
    {
        // ...
    }

    public void Cook()
    {
        Potato potato = this.GetPotato();
        Carrot carrot = this.GetCarrot();
        Bowl bowl;

        bowl = this.GetBowl();

        bowl.Add(potato);
        bowl.Add(carrot);

        this.Peel(potato);
        this.Peel(carrot);
        
        this.Cut(potato);
        this.Cut(carrot);
    }

    private Bowl GetBowl()
    {
        return new Bowl();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private void Peel(Vegetable vegetable)
    {
        // ...
    }

    private void Cut(Vegetable vegetable)
    {
        // ...
    }
}